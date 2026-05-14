Partial Class EtudiantForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents grpInformations As System.Windows.Forms.GroupBox
    Private WithEvents lblNom As System.Windows.Forms.Label
    Private WithEvents txtNom As System.Windows.Forms.TextBox
    Private WithEvents lblPrenom As System.Windows.Forms.Label
    Private WithEvents txtPrenom As System.Windows.Forms.TextBox
    Private WithEvents lblDateNaiss As System.Windows.Forms.Label
    Private WithEvents dtpDateNaiss As System.Windows.Forms.DateTimePicker
    Private WithEvents lblLieuNaiss As System.Windows.Forms.Label
    Private WithEvents txtLieuNaiss As System.Windows.Forms.TextBox
    Private WithEvents lblSexe As System.Windows.Forms.Label
    Private WithEvents rbtnMasculin As System.Windows.Forms.RadioButton
    Private WithEvents rbtnFeminin As System.Windows.Forms.RadioButton
    Private WithEvents lblEmail As System.Windows.Forms.Label
    Private WithEvents txtEmail As System.Windows.Forms.TextBox
    Private WithEvents lblTelephone As System.Windows.Forms.Label
    Private WithEvents txtTelephone As System.Windows.Forms.TextBox
    Private WithEvents lblAdresse As System.Windows.Forms.Label
    Private WithEvents txtAdresse As System.Windows.Forms.TextBox
    Private WithEvents lblFiliere As System.Windows.Forms.Label
    Private WithEvents cmbFiliere As System.Windows.Forms.ComboBox
    Private WithEvents lblPhoto As System.Windows.Forms.Label
    Private WithEvents picPhoto As System.Windows.Forms.PictureBox
    Private WithEvents btnParcourirPhoto As System.Windows.Forms.Button
    Private WithEvents grpRecherche As System.Windows.Forms.GroupBox
    Private WithEvents lblRecherche As System.Windows.Forms.Label
    Private WithEvents txtRecherche As System.Windows.Forms.TextBox
    Private WithEvents lblNiveau As System.Windows.Forms.Label
    Private WithEvents nudNiveau As System.Windows.Forms.NumericUpDown
    Private WithEvents btnRechercher As System.Windows.Forms.Button
    Private WithEvents dgvEtudiants As System.Windows.Forms.DataGridView
    Private WithEvents btnAjouter As System.Windows.Forms.Button
    Private WithEvents btnModifier As System.Windows.Forms.Button
    Private WithEvents btnSupprimer As System.Windows.Forms.Button
    Private WithEvents btnEffacer As System.Windows.Forms.Button
    Private WithEvents btnFermer As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.grpInformations = New System.Windows.Forms.GroupBox()
        Me.lblFiliere = New System.Windows.Forms.Label()
        Me.cmbFiliere = New System.Windows.Forms.ComboBox()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.picPhoto = New System.Windows.Forms.PictureBox()
        Me.btnParcourirPhoto = New System.Windows.Forms.Button()
        Me.lblAdresse = New System.Windows.Forms.Label()
        Me.txtAdresse = New System.Windows.Forms.TextBox()
        Me.lblTelephone = New System.Windows.Forms.Label()
        Me.txtTelephone = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.rbtnFeminin = New System.Windows.Forms.RadioButton()
        Me.rbtnMasculin = New System.Windows.Forms.RadioButton()
        Me.lblSexe = New System.Windows.Forms.Label()
        Me.lblLieuNaiss = New System.Windows.Forms.Label()
        Me.txtLieuNaiss = New System.Windows.Forms.TextBox()
        Me.lblDateNaiss = New System.Windows.Forms.Label()
        Me.dtpDateNaiss = New System.Windows.Forms.DateTimePicker()
        Me.lblPrenom = New System.Windows.Forms.Label()
        Me.txtPrenom = New System.Windows.Forms.TextBox()
        Me.lblNom = New System.Windows.Forms.Label()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.grpRecherche = New System.Windows.Forms.GroupBox()
        Me.nudNiveau = New System.Windows.Forms.NumericUpDown()
        Me.lblNiveau = New System.Windows.Forms.Label()
        Me.btnRechercher = New System.Windows.Forms.Button()
        Me.txtRecherche = New System.Windows.Forms.TextBox()
        Me.lblRecherche = New System.Windows.Forms.Label()
        Me.dgvEtudiants = New System.Windows.Forms.DataGridView()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnModifier = New System.Windows.Forms.Button()
        Me.btnSupprimer = New System.Windows.Forms.Button()
        Me.btnEffacer = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        Me.grpInformations.SuspendLayout()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpRecherche.SuspendLayout()
        CType(Me.nudNiveau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvEtudiants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTitre.Location = New System.Drawing.Point(20, 10)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(400, 35)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Gestion des Étudiants"

        Me.grpInformations.Controls.Add(Me.lblFiliere)
        Me.grpInformations.Controls.Add(Me.cmbFiliere)
        Me.grpInformations.Controls.Add(Me.lblPhoto)
        Me.grpInformations.Controls.Add(Me.picPhoto)
        Me.grpInformations.Controls.Add(Me.btnParcourirPhoto)
        Me.grpInformations.Controls.Add(Me.lblAdresse)
        Me.grpInformations.Controls.Add(Me.txtAdresse)
        Me.grpInformations.Controls.Add(Me.lblTelephone)
        Me.grpInformations.Controls.Add(Me.txtTelephone)
        Me.grpInformations.Controls.Add(Me.lblEmail)
        Me.grpInformations.Controls.Add(Me.txtEmail)
        Me.grpInformations.Controls.Add(Me.rbtnFeminin)
        Me.grpInformations.Controls.Add(Me.rbtnMasculin)
        Me.grpInformations.Controls.Add(Me.lblSexe)
        Me.grpInformations.Controls.Add(Me.lblLieuNaiss)
        Me.grpInformations.Controls.Add(Me.txtLieuNaiss)
        Me.grpInformations.Controls.Add(Me.lblDateNaiss)
        Me.grpInformations.Controls.Add(Me.dtpDateNaiss)
        Me.grpInformations.Controls.Add(Me.lblPrenom)
        Me.grpInformations.Controls.Add(Me.txtPrenom)
        Me.grpInformations.Controls.Add(Me.lblNom)
        Me.grpInformations.Controls.Add(Me.txtNom)
        Me.grpInformations.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpInformations.Location = New System.Drawing.Point(20, 55)
        Me.grpInformations.Name = "grpInformations"
        Me.grpInformations.Size = New System.Drawing.Size(400, 500)
        Me.grpInformations.TabIndex = 1
        Me.grpInformations.TabStop = False
        Me.grpInformations.Text = "Informations de l'étudiant"

        Me.lblNom.AutoSize = True
        Me.lblNom.Location = New System.Drawing.Point(15, 30)
        Me.lblNom.Name = "lblNom"
        Me.lblNom.Size = New System.Drawing.Size(40, 19)
        Me.lblNom.TabIndex = 0
        Me.lblNom.Text = "Nom:"

        Me.txtNom.Location = New System.Drawing.Point(15, 52)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(360, 25)
        Me.txtNom.TabIndex = 1

        Me.lblPrenom.AutoSize = True
        Me.lblPrenom.Location = New System.Drawing.Point(15, 85)
        Me.lblPrenom.Name = "lblPrenom"
        Me.lblPrenom.Size = New System.Drawing.Size(60, 19)
        Me.lblPrenom.TabIndex = 2
        Me.lblPrenom.Text = "Prénom:"

        Me.txtPrenom.Location = New System.Drawing.Point(15, 107)
        Me.txtPrenom.Name = "txtPrenom"
        Me.txtPrenom.Size = New System.Drawing.Size(360, 25)
        Me.txtPrenom.TabIndex = 3

        Me.lblDateNaiss.AutoSize = True
        Me.lblDateNaiss.Location = New System.Drawing.Point(15, 140)
        Me.lblDateNaiss.Name = "lblDateNaiss"
        Me.lblDateNaiss.Size = New System.Drawing.Size(115, 19)
        Me.lblDateNaiss.TabIndex = 4
        Me.lblDateNaiss.Text = "Date de naissance:"

        Me.dtpDateNaiss.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDateNaiss.Location = New System.Drawing.Point(15, 162)
        Me.dtpDateNaiss.Name = "dtpDateNaiss"
        Me.dtpDateNaiss.Size = New System.Drawing.Size(200, 25)
        Me.dtpDateNaiss.TabIndex = 5

        Me.lblLieuNaiss.AutoSize = True
        Me.lblLieuNaiss.Location = New System.Drawing.Point(230, 140)
        Me.lblLieuNaiss.Name = "lblLieuNaiss"
        Me.lblLieuNaiss.Size = New System.Drawing.Size(110, 19)
        Me.lblLieuNaiss.TabIndex = 6
        Me.lblLieuNaiss.Text = "Lieu de naissance:"

        Me.txtLieuNaiss.Location = New System.Drawing.Point(230, 162)
        Me.txtLieuNaiss.Name = "txtLieuNaiss"
        Me.txtLieuNaiss.Size = New System.Drawing.Size(145, 25)
        Me.txtLieuNaiss.TabIndex = 7

        Me.lblSexe.AutoSize = True
        Me.lblSexe.Location = New System.Drawing.Point(15, 195)
        Me.lblSexe.Name = "lblSexe"
        Me.lblSexe.Size = New System.Drawing.Size(40, 19)
        Me.lblSexe.TabIndex = 8
        Me.lblSexe.Text = "Sexe:"

        Me.rbtnMasculin.AutoSize = True
        Me.rbtnMasculin.Checked = True
        Me.rbtnMasculin.Location = New System.Drawing.Point(15, 217)
        Me.rbtnMasculin.Name = "rbtnMasculin"
        Me.rbtnMasculin.Size = New System.Drawing.Size(75, 19)
        Me.rbtnMasculin.TabIndex = 9
        Me.rbtnMasculin.TabStop = True
        Me.rbtnMasculin.Text = "Masculin"
        Me.rbtnMasculin.UseVisualStyleBackColor = True

        Me.rbtnFeminin.AutoSize = True
        Me.rbtnFeminin.Location = New System.Drawing.Point(110, 217)
        Me.rbtnFeminin.Name = "rbtnFeminin"
        Me.rbtnFeminin.Size = New System.Drawing.Size(65, 19)
        Me.rbtnFeminin.TabIndex = 10
        Me.rbtnFeminin.Text = "Féminin"
        Me.rbtnFeminin.UseVisualStyleBackColor = True

        Me.lblEmail.AutoSize = True
        Me.lblEmail.Location = New System.Drawing.Point(15, 250)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(45, 19)
        Me.lblEmail.TabIndex = 11
        Me.lblEmail.Text = "Email:"

        Me.txtEmail.Location = New System.Drawing.Point(15, 272)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(360, 25)
        Me.txtEmail.TabIndex = 12

        Me.lblTelephone.AutoSize = True
        Me.lblTelephone.Location = New System.Drawing.Point(15, 305)
        Me.lblTelephone.Name = "lblTelephone"
        Me.lblTelephone.Size = New System.Drawing.Size(75, 19)
        Me.lblTelephone.TabIndex = 13
        Me.lblTelephone.Text = "Téléphone:"

        Me.txtTelephone.Location = New System.Drawing.Point(15, 327)
        Me.txtTelephone.Name = "txtTelephone"
        Me.txtTelephone.Size = New System.Drawing.Size(360, 25)
        Me.txtTelephone.TabIndex = 14

        Me.lblAdresse.AutoSize = True
        Me.lblAdresse.Location = New System.Drawing.Point(15, 360)
        Me.lblAdresse.Name = "lblAdresse"
        Me.lblAdresse.Size = New System.Drawing.Size(60, 19)
        Me.lblAdresse.TabIndex = 15
        Me.lblAdresse.Text = "Adresse:"

        Me.txtAdresse.Location = New System.Drawing.Point(15, 382)
        Me.txtAdresse.Multiline = True
        Me.txtAdresse.Name = "txtAdresse"
        Me.txtAdresse.Size = New System.Drawing.Size(360, 40)
        Me.txtAdresse.TabIndex = 16

        Me.lblFiliere.AutoSize = True
        Me.lblFiliere.Location = New System.Drawing.Point(15, 435)
        Me.lblFiliere.Name = "lblFiliere"
        Me.lblFiliere.Size = New System.Drawing.Size(50, 19)
        Me.lblFiliere.TabIndex = 17
        Me.lblFiliere.Text = "Filière:"

        Me.cmbFiliere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiliere.FormattingEnabled = True
        Me.cmbFiliere.Location = New System.Drawing.Point(15, 457)
        Me.cmbFiliere.Name = "cmbFiliere"
        Me.cmbFiliere.Size = New System.Drawing.Size(280, 23)
        Me.cmbFiliere.TabIndex = 18

        Me.lblPhoto.AutoSize = True
        Me.lblPhoto.Location = New System.Drawing.Point(310, 435)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(40, 19)
        Me.lblPhoto.TabIndex = 19
        Me.lblPhoto.Text = "Photo:"

        Me.picPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picPhoto.Location = New System.Drawing.Point(310, 457)
        Me.picPhoto.Name = "picPhoto"
        Me.picPhoto.Size = New System.Drawing.Size(65, 30)
        Me.picPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPhoto.TabIndex = 20
        Me.picPhoto.TabStop = False

        Me.btnParcourirPhoto.Location = New System.Drawing.Point(310, 495)
        Me.btnParcourirPhoto.Name = "btnParcourirPhoto"
        Me.btnParcourirPhoto.Size = New System.Drawing.Size(65, 25)
        Me.btnParcourirPhoto.TabIndex = 21
        Me.btnParcourirPhoto.Text = "Parcourir"
        Me.btnParcourirPhoto.UseVisualStyleBackColor = True

        Me.grpRecherche.Controls.Add(Me.nudNiveau)
        Me.grpRecherche.Controls.Add(Me.lblNiveau)
        Me.grpRecherche.Controls.Add(Me.btnRechercher)
        Me.grpRecherche.Controls.Add(Me.txtRecherche)
        Me.grpRecherche.Controls.Add(Me.lblRecherche)
        Me.grpRecherche.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpRecherche.Location = New System.Drawing.Point(430, 55)
        Me.grpRecherche.Name = "grpRecherche"
        Me.grpRecherche.Size = New System.Drawing.Size(500, 100)
        Me.grpRecherche.TabIndex = 2
        Me.grpRecherche.TabStop = False
        Me.grpRecherche.Text = "Recherche et Filtrage"

        Me.lblRecherche.AutoSize = True
        Me.lblRecherche.Location = New System.Drawing.Point(15, 30)
        Me.lblRecherche.Name = "lblRecherche"
        Me.lblRecherche.Size = New System.Drawing.Size(70, 19)
        Me.lblRecherche.TabIndex = 0
        Me.lblRecherche.Text = "Rechercher:"

        Me.txtRecherche.Location = New System.Drawing.Point(15, 55)
        Me.txtRecherche.Name = "txtRecherche"
        Me.txtRecherche.Size = New System.Drawing.Size(200, 25)
        Me.txtRecherche.TabIndex = 1

        Me.lblNiveau.AutoSize = True
        Me.lblNiveau.Location = New System.Drawing.Point(230, 30)
        Me.lblNiveau.Name = "lblNiveau"
        Me.lblNiveau.Size = New System.Drawing.Size(50, 19)
        Me.lblNiveau.TabIndex = 2
        Me.lblNiveau.Text = "Niveau:"

        Me.nudNiveau.Location = New System.Drawing.Point(230, 55)
        Me.nudNiveau.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudNiveau.Minimum = New Decimal(New Integer() {0, 0, 0, 0})
        Me.nudNiveau.Name = "nudNiveau"
        Me.nudNiveau.Size = New System.Drawing.Size(60, 25)
        Me.nudNiveau.TabIndex = 3

        Me.btnRechercher.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnRechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRechercher.ForeColor = System.Drawing.Color.White
        Me.btnRechercher.Location = New System.Drawing.Point(350, 50)
        Me.btnRechercher.Name = "btnRechercher"
        Me.btnRechercher.Size = New System.Drawing.Size(120, 30)
        Me.btnRechercher.TabIndex = 4
        Me.btnRechercher.Text = "Rechercher"
        Me.btnRechercher.UseVisualStyleBackColor = False

        Me.dgvEtudiants.AllowUserToAddRows = False
        Me.dgvEtudiants.AllowUserToDeleteRows = False
        Me.dgvEtudiants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEtudiants.Location = New System.Drawing.Point(430, 165)
        Me.dgvEtudiants.Name = "dgvEtudiants"
        Me.dgvEtudiants.ReadOnly = True
        Me.dgvEtudiants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEtudiants.Size = New System.Drawing.Size(700, 300)
        Me.dgvEtudiants.TabIndex = 3

        Me.btnAjouter.BackColor = System.Drawing.Color.FromArgb(0, 180, 0)
        Me.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjouter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAjouter.ForeColor = System.Drawing.Color.White
        Me.btnAjouter.Location = New System.Drawing.Point(20, 565)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(100, 35)
        Me.btnAjouter.TabIndex = 4
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = False

        Me.btnModifier.BackColor = System.Drawing.Color.FromArgb(255, 140, 0)
        Me.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModifier.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnModifier.ForeColor = System.Drawing.Color.White
        Me.btnModifier.Location = New System.Drawing.Point(130, 565)
        Me.btnModifier.Name = "btnModifier"
        Me.btnModifier.Size = New System.Drawing.Size(100, 35)
        Me.btnModifier.TabIndex = 5
        Me.btnModifier.Text = "Modifier"
        Me.btnModifier.UseVisualStyleBackColor = False

        Me.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(220, 0, 0)
        Me.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupprimer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupprimer.ForeColor = System.Drawing.Color.White
        Me.btnSupprimer.Location = New System.Drawing.Point(240, 565)
        Me.btnSupprimer.Name = "btnSupprimer"
        Me.btnSupprimer.Size = New System.Drawing.Size(100, 35)
        Me.btnSupprimer.TabIndex = 6
        Me.btnSupprimer.Text = "Supprimer"
        Me.btnSupprimer.UseVisualStyleBackColor = False

        Me.btnEffacer.BackColor = System.Drawing.Color.Gray
        Me.btnEffacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEffacer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEffacer.ForeColor = System.Drawing.Color.White
        Me.btnEffacer.Location = New System.Drawing.Point(350, 565)
        Me.btnEffacer.Name = "btnEffacer"
        Me.btnEffacer.Size = New System.Drawing.Size(100, 35)
        Me.btnEffacer.TabIndex = 7
        Me.btnEffacer.Text = "Effacer"
        Me.btnEffacer.UseVisualStyleBackColor = False

        Me.btnFermer.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFermer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Location = New System.Drawing.Point(1030, 565)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(100, 35)
        Me.btnFermer.TabIndex = 8
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 620)
        Me.Controls.Add(Me.btnFermer)
        Me.Controls.Add(Me.btnEffacer)
        Me.Controls.Add(Me.btnSupprimer)
        Me.Controls.Add(Me.btnModifier)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.dgvEtudiants)
        Me.Controls.Add(Me.grpRecherche)
        Me.Controls.Add(Me.grpInformations)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "EtudiantForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des Étudiants"
        Me.grpInformations.ResumeLayout(False)
        Me.grpInformations.PerformLayout()
        CType(Me.picPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpRecherche.ResumeLayout(False)
        Me.grpRecherche.PerformLayout()
        CType(Me.nudNiveau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvEtudiants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
