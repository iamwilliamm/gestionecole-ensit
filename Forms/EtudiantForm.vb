Public Class EtudiantForm
    Private Sub EtudiantForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ChargerFilieres()
        ChargerEtudiants()
        ConfigurerDataGridView()
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
            MessageBox.Show("Erreur lors du chargement des filières: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ChargerEtudiants()
        Try
            Dim dt As DataTable = DAL.EtudiantDAL.GetAll()
            dgvEtudiants.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des étudiants: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ConfigurerDataGridView()
        If dgvEtudiants.Columns.Count > 0 Then
            dgvEtudiants.Columns("id_etudiant").HeaderText = "ID"
            dgvEtudiants.Columns("nom").HeaderText = "Nom"
            dgvEtudiants.Columns("prenom").HeaderText = "Prénom"
            dgvEtudiants.Columns("date_naissance").HeaderText = "Date de naissance"
            dgvEtudiants.Columns("lieu_naissance").HeaderText = "Lieu de naissance"
            dgvEtudiants.Columns("sexe").HeaderText = "Sexe"
            dgvEtudiants.Columns("email").HeaderText = "Email"
            dgvEtudiants.Columns("telephone").HeaderText = "Téléphone"
            dgvEtudiants.Columns("adresse").HeaderText = "Adresse"
            dgvEtudiants.Columns("photo").HeaderText = "Photo"
            dgvEtudiants.Columns("numero_inscription").HeaderText = "N° Inscription"
            dgvEtudiants.Columns("id_filiere").Visible = False
            dgvEtudiants.Columns("date_inscription").HeaderText = "Date d'inscription"
            dgvEtudiants.Columns("nom_filiere").HeaderText = "Filière"

            For Each col As DataGridViewColumn In dgvEtudiants.Columns
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Next
        End If
    End Sub

    Private Sub btnRechercher_Click(sender As Object, e As EventArgs) Handles btnRechercher.Click
        Try
            Dim terme As String = txtRecherche.Text.Trim()
            Dim idFiliere As Integer = If(cmbFiliere.SelectedIndex > 0, Convert.ToInt32(cmbFiliere.SelectedValue), 0)
            Dim niveau As Integer = If(nudNiveau.Value > 0, Convert.ToInt32(nudNiveau.Value), 0)

            Dim dt As DataTable = DAL.EtudiantDAL.Rechercher(terme, idFiliere, niveau)
            dgvEtudiants.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la recherche: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAjouter_Click(sender As Object, e As EventArgs) Handles btnAjouter.Click
        If Not Validation() Then Return

        Try
            Dim photo As String = If(picPhoto.ImageLocation IsNot Nothing, picPhoto.ImageLocation, "")

            DAL.EtudiantDAL.Ajouter(
                txtNom.Text.Trim(),
                txtPrenom.Text.Trim(),
                dtpDateNaiss.Value,
                txtLieuNaiss.Text.Trim(),
                If(rbtnMasculin.Checked, "M", "F"),
                txtEmail.Text.Trim(),
                txtTelephone.Text.Trim(),
                txtAdresse.Text.Trim(),
                photo,
                Convert.ToInt32(cmbFiliere.SelectedValue)
            )

            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "AJOUT_ETUDIANT", $"Ajout étudiant: {txtNom.Text} {txtPrenom.Text}")

            MessageBox.Show("Étudiant ajouté avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerEtudiants()
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'ajout: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModifier_Click(sender As Object, e As EventArgs) Handles btnModifier.Click
        If dgvEtudiants.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un étudiant à modifier.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If Not Validation() Then Return

        Try
            Dim id As Integer = Convert.ToInt32(dgvEtudiants.SelectedRows(0).Cells("id_etudiant").Value)
            Dim photo As String = If(picPhoto.ImageLocation IsNot Nothing, picPhoto.ImageLocation, "")

            DAL.EtudiantDAL.Modifier(
                id,
                txtNom.Text.Trim(),
                txtPrenom.Text.Trim(),
                dtpDateNaiss.Value,
                txtLieuNaiss.Text.Trim(),
                If(rbtnMasculin.Checked, "M", "F"),
                txtEmail.Text.Trim(),
                txtTelephone.Text.Trim(),
                txtAdresse.Text.Trim(),
                photo,
                Convert.ToInt32(cmbFiliere.SelectedValue)
            )

            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "MODIF_ETUDIANT", $"Modification étudiant ID: {id}")

            MessageBox.Show("Étudiant modifié avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerEtudiants()
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la modification: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        If dgvEtudiants.SelectedRows.Count = 0 Then
            MessageBox.Show("Veuillez sélectionner un étudiant à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet étudiant?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then Return

        Try
            Dim id As Integer = Convert.ToInt32(dgvEtudiants.SelectedRows(0).Cells("id_etudiant").Value)
            DAL.EtudiantDAL.Supprimer(id)

            DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "SUPPR_ETUDIANT", $"Suppression étudiant ID: {id}")

            MessageBox.Show("Étudiant supprimé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
            EffacerChamps()
            ChargerEtudiants()
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnParcourirPhoto_Click(sender As Object, e As EventArgs) Handles btnParcourirPhoto.Click
        Using dialog As New OpenFileDialog()
            dialog.Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp"
            If dialog.ShowDialog() = DialogResult.OK Then
                picPhoto.ImageLocation = dialog.FileName
            End If
        End Using
    End Sub

    Private Sub dgvEtudiants_SelectionChanged(sender As Object, e As EventArgs) Handles dgvEtudiants.SelectionChanged
        If dgvEtudiants.SelectedRows.Count > 0 Then
            Dim row As DataGridViewRow = dgvEtudiants.SelectedRows(0)
            txtNom.Text = row.Cells("nom").Value?.ToString()
            txtPrenom.Text = row.Cells("prenom").Value?.ToString()
            dtpDateNaiss.Value = If(row.Cells("date_naissance").Value IsNot DBNull.Value, Convert.ToDateTime(row.Cells("date_naissance").Value), DateTime.Now)
            txtLieuNaiss.Text = row.Cells("lieu_naissance").Value?.ToString()
            If row.Cells("sexe").Value?.ToString() = "M" Then rbtnMasculin.Checked = True Else rbtnFeminin.Checked = True
            txtEmail.Text = row.Cells("email").Value?.ToString()
            txtTelephone.Text = row.Cells("telephone").Value?.ToString()
            txtAdresse.Text = row.Cells("adresse").Value?.ToString()
            If row.Cells("photo").Value IsNot DBNull.Value AndAlso Not String.IsNullOrEmpty(row.Cells("photo").Value.ToString()) Then
                picPhoto.ImageLocation = row.Cells("photo").Value.ToString()
            Else
                picPhoto.ImageLocation = Nothing
            End If

            If row.Cells("id_filiere").Value IsNot DBNull.Value Then
                cmbFiliere.SelectedValue = Convert.ToInt32(row.Cells("id_filiere").Value)
            End If
        End If
    End Sub

    Private Sub btnEffacer_Click(sender As Object, e As EventArgs) Handles btnEffacer.Click
        EffacerChamps()
    End Sub

    Private Sub EffacerChamps()
        txtNom.Clear()
        txtPrenom.Clear()
        txtLieuNaiss.Clear()
        txtEmail.Clear()
        txtTelephone.Clear()
        txtAdresse.Clear()
        picPhoto.ImageLocation = Nothing
        rbtnMasculin.Checked = True
        dtpDateNaiss.Value = DateTime.Now.AddYears(-20)
        cmbFiliere.SelectedIndex = 0
    End Sub

    Private Function Validation() As Boolean
        If String.IsNullOrWhiteSpace(txtNom.Text) Or String.IsNullOrWhiteSpace(txtPrenom.Text) Then
            MessageBox.Show("Le nom et le prénom sont obligatoires.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If cmbFiliere.SelectedIndex <= 0 Then
            MessageBox.Show("Veuillez sélectionner une filière.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnFermer_Click(sender As Object, e As EventArgs) Handles btnFermer.Click
        Me.Close()
    End Sub
End Class
