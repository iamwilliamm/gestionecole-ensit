Public Class PaiementForm
    Private Sub PaiementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerEtudiants()
        ChargerPaiements()
        ConfigurerDataGridView()
        ConfigurerComboBoxes()
    End Sub

    Private Sub ConfigurerComboBoxes()
        cmbTypeFrais.Items.AddRange(New String() {"Inscription", "Scolarite", "Materiel", "Examen", "Transport", "Autre"})
        cmbTypeFrais.SelectedIndex = 0
        cmbModePaiement.Items.AddRange(New String() {"Especes", "Virement", "Cheque", "Carte bancaire"})
        cmbModePaiement.SelectedIndex = 0
        cmbStatut.Items.AddRange(New String() {"partiel", "complet", "en_attente"})
        cmbStatut.SelectedIndex = 0
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

    Private Sub ChargerPaiements()
        Try
            Dim dt As DataTable = DAL.PaiementDAL.GetAll()
            dgvPaiements.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChargerImpayes()
        Try
            Dim dt As DataTable = DAL.PaiementDAL.GetImpayes()
            dgvPaiements.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurerDataGridView()
        If dgvPaiements.Columns.Count > 0 Then
            dgvPaiements.Columns("id_paiement").HeaderText = "ID"
            dgvPaiements.Columns("nom").HeaderText = "Nom"
            dgvPaiements.Columns("prenom").HeaderText = "Prénom"
            dgvPaiements.Columns("numero_inscription").HeaderText = "N° Inscription"
            dgvPaiements.Columns("montant").HeaderText = "Montant"
            dgvPaiements.Columns("date_paiement").HeaderText = "Date"
            dgvPaiements.Columns("type_frais").HeaderText = "Type de frais"
            dgvPaiements.Columns("mode_paiement").HeaderText = "Mode"
            dgvPaiements.Columns("reference").HeaderText = "Référence"
            dgvPaiements.Columns("statut").HeaderText = "Statut"
            dgvPaiements.Columns("id_etudiant").Visible = False
            dgvPaiements.Columns("id_reinscription").Visible = False
            For Each col As DataGridViewColumn In dgvPaiements.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End If
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        If cmbEtudiant.SelectedIndex < 0 Then
            MessageBox.Show("Sélectionnez un étudiant.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If nudMontant.Value <= 0 Then
            MessageBox.Show("Le montant doit être positif.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            Dim idEtudiant As Integer = Convert.ToInt32(cmbEtudiant.SelectedValue)
            DAL.PaiementDAL.Ajouter(idEtudiant, 0, nudMontant.Value, dtpDatePaiement.Value, cmbTypeFrais.SelectedItem.ToString(), cmbModePaiement.SelectedItem.ToString(), txtReference.Text.Trim(), cmbStatut.SelectedItem.ToString(), txtObservations.Text.Trim())
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "AJOUT_PAIEMENT", $"Paiement étudiant ID: {idEtudiant}, Montant: {nudMontant.Value}")
            MessageBox.Show("Paiement enregistré!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerPaiements()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click
        If dgvPaiements.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez un paiement.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim id As Integer = Convert.ToInt32(dgvPaiements.SelectedRows(0).Cells("id_paiement").Value)
            DAL.PaiementDAL.Modifier(id, nudMontant.Value, dtpDatePaiement.Value, cmbTypeFrais.SelectedItem.ToString(), cmbModePaiement.SelectedItem.ToString(), txtReference.Text.Trim(), cmbStatut.SelectedItem.ToString(), txtObservations.Text.Trim())
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "MODIF_PAIEMENT", $"Modification paiement ID: {id}")
            MessageBox.Show("Paiement modifié!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ChargerPaiements()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        If dgvPaiements.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez un paiement.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show("Supprimer ce paiement?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Return
        Try
            Dim id As Integer = Convert.ToInt32(dgvPaiements.SelectedRows(0).Cells("id_paiement").Value)
            DAL.PaiementDAL.Supprimer(id)
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "SUPPR_PAIEMENT", $"Suppression paiement ID: {id}")
            MessageBox.Show("Paiement supprimé!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ChargerPaiements()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnImpayes_Click(sender As Object, e As EventArgs) Handles btnImpayes.Click
        ChargerImpayes()
    End Sub

    Private Sub btnTous_Click(sender As Object, e As EventArgs) Handles btnTous.Click
        ChargerPaiements()
    End Sub

    Private Sub dgvPaiements_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPaiements.SelectionChanged
        If dgvPaiements.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvPaiements.SelectedRows(0)
            nudMontant.Value = Convert.ToDecimal(row.Cells("montant").Value)
            dtpDatePaiement.Value = Convert.ToDateTime(row.Cells("date_paiement").Value)
            txtReference.Text = row.Cells("reference").Value?.ToString()
            txtObservations.Text = row.Cells("observations").Value?.ToString()
            Dim typeFrais As String = row.Cells("type_frais").Value?.ToString()
            If cmbTypeFrais.Items.Contains(typeFrais) Then cmbTypeFrais.SelectedItem = typeFrais
            Dim mode As String = row.Cells("mode_paiement").Value?.ToString()
            If cmbModePaiement.Items.Contains(mode) Then cmbModePaiement.SelectedItem = mode
            Dim statut As String = row.Cells("statut").Value?.ToString()
            If cmbStatut.Items.Contains(statut) Then cmbStatut.SelectedItem = statut
        End If
    End Sub

    Private Sub btnFermer_Click(sender As Object, e As EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub

    Private Sub EffacerChamps()
        nudMontant.Value = 0
        txtReference.Clear()
        txtObservations.Clear()
        cmbTypeFrais.SelectedIndex = 0
        cmbModePaiement.SelectedIndex = 0
        cmbStatut.SelectedIndex = 0
    End Sub
End Class
