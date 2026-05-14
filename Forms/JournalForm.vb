Public Class JournalForm
    Private Sub JournalForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerJournal()
    End Sub

    Private Sub ChargerJournal()
        Try
            Dim dt As DataTable = DAL.JournalDAL.GetAll()
            dgvJournal.DataSource = dt
            ConfigurerDataGridView()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurerDataGridView()
        If dgvJournal.Columns.Count > 0 Then
            dgvJournal.Columns("id").HeaderText = "ID"
            dgvJournal.Columns("login").HeaderText = "Utilisateur"
            dgvJournal.Columns("nom_complet").HeaderText = "Nom complet"
            dgvJournal.Columns("action").HeaderText = "Action"
            dgvJournal.Columns("date_action").HeaderText = "Date"
            dgvJournal.Columns("description").HeaderText = "Description"
            dgvJournal.Columns("id_utilisateur").Visible = False
            For Each col As DataGridViewColumn In dgvJournal.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End If
    End Sub

    Private Sub btnActualiser_Click(sender As Object, e As EventArgs) Handles btnActualiser.Click
        ChargerJournal()
    End Sub

    Private Sub btnFermer_Click(sender As Object, e As EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub
End Class
