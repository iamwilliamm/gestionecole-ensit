Public Class RapportForm
    Private Sub RapportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerFilieres()
    End Sub

    Private Sub ChargerFilieres()
        Try
            Dim dt As DataTable = DAL.FiliereDAL.GetAll()
            cmbFiliere.DataSource = dt
            cmbFiliere.DisplayMember = "libelle"
            cmbFiliere.ValueMember = "id_filiere"
            cmbFiliere.Items.Insert(0, New With {.id_filiere = 0, .libelle = "Toutes les filières"})
            cmbFiliere.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRapportEtudiants_Click(sender As Object, e As EventArgs) Handles btnRapportEtudiants.Click
        Try
            Dim dt As DataTable
            If cmbFiliere.SelectedIndex > 0 Then
                Dim idFiliere As Integer = Convert.ToInt32(cmbFiliere.SelectedValue)
                dt = DAL.EtudiantDAL.Rechercher("", idFiliere, 0)
            Else
                dt = DAL.EtudiantDAL.GetAll()
            End If

            dgvRapport.DataSource = dt
            For Each col As DataGridViewColumn In dgvRapport.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            lblTypeRapport.Text = "Rapport: Liste des étudiants"
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRapportPaiements_Click(sender As Object, e As EventArgs) Handles btnRapportPaiements.Click
        Try
            Dim dt As DataTable = DAL.PaiementDAL.GetAll()
            dgvRapport.DataSource = dt
            For Each col As DataGridViewColumn In dgvRapport.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            lblTypeRapport.Text = "Rapport: Liste des paiements"
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRapportImpayes_Click(sender As Object, e As EventArgs) Handles btnRapportImpayes.Click
        Try
            Dim dt As DataTable = DAL.PaiementDAL.GetImpayes()
            dgvRapport.DataSource = dt
            For Each col As DataGridViewColumn In dgvRapport.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
            lblTypeRapport.Text = "Rapport: Étudiants impayés"
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExporterExcel_Click(sender As Object, e As EventArgs) Handles btnExporterExcel.Click
        If dgvRapport.Rows.Count = 0 Then
            MessageBox.Show("Aucun rapport à exporter.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Using dialog As New SaveFileDialog()
            dialog.Filter = "Fichiers Excel|*.xlsx"
            dialog.DefaultExt = "xlsx"
            dialog.FileName = $"Rapport_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"

            If dialog.ShowDialog() = DialogResult.OK Then
                Try
                    ExporterEnExcel(dgvRapport, dialog.FileName)
                    MessageBox.Show("Exportation réussie!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "EXPORT_EXCEL", $"Exportation rapport: {lblTypeRapport.Text}")
                Catch ex As Exception
                    MessageBox.Show("Erreur lors de l'exportation: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub ExporterEnExcel(dgv As DataGridView, fichier As String)
        Dim workbook = New NPOI.XSSF.UserModel.XSSFWorkbook()
        Dim sheet = workbook.CreateSheet("Rapport")

        Dim headerRow = sheet.CreateRow(0)
        For i As Integer = 0 To dgv.Columns.Count - 1
            Dim cell = headerRow.CreateCell(i)
            cell.SetCellValue(dgv.Columns(i).HeaderText)
        Next

        For i As Integer = 0 To dgv.Rows.Count - 1
            Dim row = sheet.CreateRow(i + 1)
            For j As Integer = 0 To dgv.Columns.Count - 1
                Dim cell = row.CreateCell(j)
                Dim value = dgv.Rows(i).Cells(j).Value
                If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                    If TypeOf value Is Decimal OrElse TypeOf value Is Double Then
                        cell.SetCellValue(Convert.ToDouble(value))
                    ElseIf TypeOf value Is Integer Then
                        cell.SetCellValue(Convert.ToInt32(value))
                    Else
                        cell.SetCellValue(value.ToString())
                    End If
                End If
            Next
        Next

        For i As Integer = 0 To dgv.Columns.Count - 1
            sheet.AutoSizeColumn(i)
        Next

        Using fs As New IO.FileStream(fichier, IO.FileMode.Create)
            workbook.Write(fs)
        End Using
    End Sub

    Private Sub btnFermer_Click(sender As Object, e As EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub
End Class
