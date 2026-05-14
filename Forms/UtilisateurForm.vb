Public Class UtilisateurForm
    Private Sub UtilisateurForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerUtilisateurs()
    End Sub

    Private Sub ChargerUtilisateurs()
        Try
            Dim dt As DataTable = DAL.UtilisateurDAL.GetAll()
            dgvUtilisateurs.DataSource = dt
            ConfigurerDataGridView()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurerDataGridView()
        If dgvUtilisateurs.Columns.Count > 0 Then
            dgvUtilisateurs.Columns("id_utilisateur").HeaderText = "ID"
            dgvUtilisateurs.Columns("login").HeaderText = "Login"
            dgvUtilisateurs.Columns("role").HeaderText = "Rôle"
            dgvUtilisateurs.Columns("nom_complet").HeaderText = "Nom complet"
            dgvUtilisateurs.Columns("date_creation").HeaderText = "Date création"
            dgvUtilisateurs.Columns("mot_de_passe").Visible = False
            For Each col As DataGridViewColumn In dgvUtilisateurs.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End If
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        If String.IsNullOrWhiteSpace(txtLogin.Text) Or String.IsNullOrWhiteSpace(txtMotDePasse.Text) Then
            MessageBox.Show("Le login et le mot de passe sont obligatoires.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Try
            DAL.UtilisateurDAL.Ajouter(txtLogin.Text.Trim(), txtMotDePasse.Text.Trim(), cmbRole.SelectedItem.ToString(), txtNomComplet.Text.Trim())
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "AJOUT_UTILISATEUR", $"Ajout utilisateur: {txtLogin.Text}")
            MessageBox.Show("Utilisateur ajouté!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerUtilisateurs()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click
        If dgvUtilisateurs.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez un utilisateur.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Try
            Dim id As Integer = Convert.ToInt32(dgvUtilisateurs.SelectedRows(0).Cells("id_utilisateur").Value)
            DAL.UtilisateurDAL.Modifier(id, txtLogin.Text.Trim(), txtMotDePasse.Text.Trim(), cmbRole.SelectedItem.ToString(), txtNomComplet.Text.Trim())
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "MODIF_UTILISATEUR", $"Modification utilisateur ID: {id}")
            MessageBox.Show("Utilisateur modifié!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ChargerUtilisateurs()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        If dgvUtilisateurs.SelectedRows.Count = 0 Then
            MessageBox.Show("Sélectionnez un utilisateur.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Dim result As DialogResult = MessageBox.Show("Supprimer cet utilisateur?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Return
        Try
            Dim id As Integer = Convert.ToInt32(dgvUtilisateurs.SelectedRows(0).Cells("id_utilisateur").Value)
            If id = UtilisateurConnecte.Id Then
                MessageBox.Show("Vous ne pouvez pas supprimer votre propre compte.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            DAL.UtilisateurDAL.Supprimer(id)
            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "SUPPR_UTILISATEUR", $"Suppression utilisateur ID: {id}")
            MessageBox.Show("Utilisateur supprimé!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ChargerUtilisateurs()
        Catch ex As Exception
            MessageBox.Show("Erreur: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvUtilisateurs_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUtilisateurs.SelectionChanged
        If dgvUtilisateurs.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvUtilisateurs.SelectedRows(0)
            txtLogin.Text = row.Cells("login").Value?.ToString()
            txtMotDePasse.Text = ""
            txtNomComplet.Text = row.Cells("nom_complet").Value?.ToString()
            Dim role As String = row.Cells("role").Value?.ToString()
            If cmbRole.Items.Contains(role) Then cmbRole.SelectedItem = role
        End If
    End Sub

    Private Sub btnFermer_Click(sender As Object, e As EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub

    Private Sub EffacerChamps()
        txtLogin.Clear()
        txtMotDePasse.Clear()
        txtNomComplet.Clear()
        cmbRole.SelectedIndex = 0
    End Sub
End Class
