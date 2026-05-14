Public Class FiliereForm
    Private Sub FiliereForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerFilieres()
    End Sub

    Private Sub ChargerFilieres()
        Try
            Dim dt As DataTable = DAL.FiliereDAL.GetAll()
            dgvFilieres.DataSource = dt
            ConfigurerDataGridView()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurerDataGridView()
        If dgvFilieres.Columns.Count > 0 Then
            dgvFilieres.Columns("id_filiere").HeaderText = "ID"
            dgvFilieres.Columns("libelle").HeaderText = "Libellé"
            dgvFilieres.Columns("description").HeaderText = "Description"
            For Each col As DataGridViewColumn In dgvFilieres.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End If
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        If String.IsNullOrWhiteSpace(txtLibelle.Text) Then
            MessageBox.Show("Le libellé est obligatoire.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            DAL.FiliereDAL.Ajouter(txtLibelle.Text.Trim(), txtDescription.Text.Trim())
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "AJOUT_FILIERE", $"Ajout filière: {txtLibelle.Text}")
            MessageBox.Show("Filière ajoutée!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerFilieres()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click
        If dgvFilieres.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez une filière.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim id As Integer = Convert.ToInt32(dgvFilieres.SelectedRows(0).Cells("id_filiere").Value)
            DAL.FiliereDAL.Modifier(id, txtLibelle.Text.Trim(), txtDescription.Text.Trim())
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "MODIF_FILIERE", $"Modification filière ID: {id}")
            MessageBox.Show("Filière modifiée!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerFilieres()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        If dgvFilieres.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez une filière.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show("Supprimer cette filière?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Return
        Try
            Dim id As Integer = Convert.ToInt32(dgvFilieres.SelectedRows(0).Cells("id_filiere").Value)
            DAL.FiliereDAL.Supprimer(id)
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "SUPPR_FILIERE", $"Suppression filière ID: {id}")
            MessageBox.Show("Filière supprimée!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerFilieres()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvFilieres_SelectionChanged(sender As Object, e As EventArgs) Handles dgvFilieres.SelectionChanged
        If dgvFilieres.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvFilieres.SelectedRows(0)
            txtLibelle.Text = row.Cells("libelle").Value?.ToString()
            txtDescription.Text = row.Cells("description").Value?.ToString()
        End If
    End Sub

    Private Sub btnEffacer_Click(sender As Object, e As EventArgs) Handles btnEffacer.Click
        EffacerChamps()
    End Sub

    Private Sub EffacerChamps()
        txtLibelle.Clear()
        txtDescription.Clear()
    End Sub

    Private Sub btnFermer_Click(sender As Object, e As EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub
End Class
