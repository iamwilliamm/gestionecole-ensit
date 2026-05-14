Public Class ReinscriptionForm
    Private Sub ReinscriptionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerEtudiants()
        ChargerReinscriptions()
        ConfigurerDataGridView()
    End Sub

    Private Sub ChargerEtudiants()
        Try
            Dim dt As DataTable = DAL.EtudiantDAL.GetAll()
            cmbEtudiant.DataSource = dt
            cmbEtudiant.DisplayMember = "nom"
            cmbEtudiant.ValueMember = "id_etudiant"
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChargerReinscriptions()
        Try
            Dim dt As DataTable = DAL.ReinscriptionDAL.GetAll()
            dgvReinscriptions.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurerDataGridView()
        If dgvReinscriptions.Columns.Count > 0 Then
            dgvReinscriptions.Columns("id_reinscription").HeaderText = "ID"
            dgvReinscriptions.Columns("nom").HeaderText = "Nom"
            dgvReinscriptions.Columns("prenom").HeaderText = "Prénom"
            dgvReinscriptions.Columns("numero_inscription").HeaderText = "N° Inscription"
            dgvReinscriptions.Columns("annee_scolaire").HeaderText = "Année scolaire"
            dgvReinscriptions.Columns("niveau").HeaderText = "Niveau"
            dgvReinscriptions.Columns("date_reinscription").HeaderText = "Date"
            dgvReinscriptions.Columns("observations").HeaderText = "Observations"
            dgvReinscriptions.Columns("id_etudiant").Visible = False
            For Each col As DataGridViewColumn In dgvReinscriptions.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End If
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        If cmbEtudiant.SelectedIndex < 0 Then
            MessageBox.Show("Sélectionnez un étudiant.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If nudNiveau.Value < 1 Or nudNiveau.Value > 5 Then
            MessageBox.Show("Le niveau doit être entre 1 et 5.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Dim idEtudiant As Integer = Convert.ToInt32(cmbEtudiant.SelectedValue)
            Dim niveauActuel As Integer = DAL.ReinscriptionDAL.GetDerniereNiveau(idEtudiant)
            If niveauActuel >= 5 Then
                MessageBox.Show("L'étudiant est déjà au niveau maximum (5).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            Dim nouvelleAnnee As Integer = DateTime.Now.Year
            Dim nouvelleAnneeScolaire As String = $"{nouvelleAnnee}-{nouvelleAnnee + 1}"

            DAL.ReinscriptionDAL.Ajouter(idEtudiant, nouvelleAnneeScolaire, Convert.ToInt32(nudNiveau.Value), txtObservations.Text.Trim())
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "AJOUT_REINSCRIPTION", $"Réinscription étudiant ID: {idEtudiant}, Niveau: {nudNiveau.Value}")
            MessageBox.Show("Réinscription ajoutée!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerReinscriptions()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        If dgvReinscriptions.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez une réinscription.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show("Supprimer cette réinscription?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Return
        Try
            Dim id As Integer = Convert.ToInt32(dgvReinscriptions.SelectedRows(0).Cells("id_reinscription").Value)
            DAL.ReinscriptionDAL.Supprimer(id)
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "SUPPR_REINSCRIPTION", $"Suppression réinscription ID: {id}")
            MessageBox.Show("Réinscription supprimée!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ChargerReinscriptions()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnFermer_Click(sender As Object, e As EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub

    Private Sub EffacerChamps()
        nudNiveau.Value = 1
        txtObservations.Clear()
    End Sub

    Private Sub cmbEtudiant_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEtudiant.SelectedIndexChanged
        If cmbEtudiant.SelectedIndex >= 0 Then
            Try
                Dim idEtudiant As Integer = Convert.ToInt32(cmbEtudiant.SelectedValue)
                Dim niveauActuel As Integer = DAL.ReinscriptionDAL.GetDerniereNiveau(idEtudiant)
                lblNiveauActuel.Text = $"Niveau actuel: {If(niveauActuel > 0, niveauActuel.ToString(), "Non inscrit")}"
            Catch
            End Try
        End If
    End Sub
End Class
