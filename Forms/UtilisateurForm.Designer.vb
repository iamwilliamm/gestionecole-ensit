Partial Class UtilisateurForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents grpInformations As System.Windows.Forms.GroupBox
    Private WithEvents lblLogin As System.Windows.Forms.Label
    Private WithEvents txtLogin As System.Windows.Forms.TextBox
    Private WithEvents lblMotDePasse As System.Windows.Forms.Label
    Private WithEvents txtMotDePasse As System.Windows.Forms.TextBox
    Private WithEvents lblRole As System.Windows.Forms.Label
    Private WithEvents cmbRole As System.Windows.Forms.ComboBox
    Private WithEvents lblNomComplet As System.Windows.Forms.Label
    Private WithEvents txtNomComplet As System.Windows.Forms.TextBox
    Private WithEvents dgvUtilisateurs As System.Windows.Forms.DataGridView
    Private WithEvents btnAjouter As System.Windows.Forms.Button
    Private WithEvents btnModifier As System.Windows.Forms.Button
    Private WithEvents btnSupprimer As System.Windows.Forms.Button
    Private WithEvents btnFermer As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.grpInformations = New System.Windows.Forms.GroupBox()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.lblMotDePasse = New System.Windows.Forms.Label()
        Me.txtMotDePasse = New System.Windows.Forms.TextBox()
        Me.lblRole = New System.Windows.Forms.Label()
        Me.cmbRole = New System.Windows.Forms.ComboBox()
        Me.lblNomComplet = New System.Windows.Forms.Label()
        Me.txtNomComplet = New System.Windows.Forms.TextBox()
        Me.dgvUtilisateurs = New System.Windows.Forms.DataGridView()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnModifier = New System.Windows.Forms.Button()
        Me.btnSupprimer = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        Me.grpInformations.SuspendLayout()
        CType(Me.dgvUtilisateurs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTitre.Location = New System.Drawing.Point(20, 10)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(300, 35)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Gestion des Utilisateurs"

        Me.grpInformations.Controls.Add(Me.lblLogin)
        Me.grpInformations.Controls.Add(Me.txtLogin)
        Me.grpInformations.Controls.Add(Me.lblMotDePasse)
        Me.grpInformations.Controls.Add(Me.txtMotDePasse)
        Me.grpInformations.Controls.Add(Me.lblRole)
        Me.grpInformations.Controls.Add(Me.cmbRole)
        Me.grpInformations.Controls.Add(Me.lblNomComplet)
        Me.grpInformations.Controls.Add(Me.txtNomComplet)
        Me.grpInformations.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpInformations.Location = New System.Drawing.Point(20, 55)
        Me.grpInformations.Name = "grpInformations"
        Me.grpInformations.Size = New System.Drawing.Size(400, 220)
        Me.grpInformations.TabIndex = 1
        Me.grpInformations.TabStop = False
        Me.grpInformations.Text = "Informations"

        Me.lblLogin.AutoSize = True
        Me.lblLogin.Location = New System.Drawing.Point(15, 30)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(45, 19)
        Me.lblLogin.TabIndex = 0
        Me.lblLogin.Text = "Login:"

        Me.txtLogin.Location = New System.Drawing.Point(15, 55)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(360, 25)
        Me.txtLogin.TabIndex = 1

        Me.lblMotDePasse.AutoSize = True
        Me.lblMotDePasse.Location = New System.Drawing.Point(15, 85)
        Me.lblMotDePasse.Name = "lblMotDePasse"
        Me.lblMotDePasse.Size = New System.Drawing.Size(85, 19)
        Me.lblMotDePasse.TabIndex = 2
        Me.lblMotDePasse.Text = "Mot de passe:"

        Me.txtMotDePasse.Location = New System.Drawing.Point(15, 107)
        Me.txtMotDePasse.Name = "txtMotDePasse"
        Me.txtMotDePasse.PasswordChar = "*"c
        Me.txtMotDePasse.Size = New System.Drawing.Size(360, 25)
        Me.txtMotDePasse.TabIndex = 3

        Me.lblRole.AutoSize = True
        Me.lblRole.Location = New System.Drawing.Point(15, 140)
        Me.lblRole.Name = "lblRole"
        Me.lblRole.Size = New System.Drawing.Size(35, 19)
        Me.lblRole.TabIndex = 4
        Me.lblRole.Text = "Rôle:"

        Me.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRole.FormattingEnabled = True
        Me.cmbRole.Items.AddRange(New Object() {"administrateur", "personnel"})
        Me.cmbRole.Location = New System.Drawing.Point(15, 162)
        Me.cmbRole.Name = "cmbRole"
        Me.cmbRole.Size = New System.Drawing.Size(200, 23)
        Me.cmbRole.TabIndex = 5
        Me.cmbRole.SelectedIndex = 0

        Me.lblNomComplet.AutoSize = True
        Me.lblNomComplet.Location = New System.Drawing.Point(15, 190)
        Me.lblNomComplet.Name = "lblNomComplet"
        Me.lblNomComplet.Size = New System.Drawing.Size(85, 19)
        Me.lblNomComplet.TabIndex = 6
        Me.lblNomComplet.Text = "Nom complet:"

        Me.txtNomComplet.Location = New System.Drawing.Point(15, 212)
        Me.txtNomComplet.Name = "txtNomComplet"
        Me.txtNomComplet.Size = New System.Drawing.Size(360, 25)
        Me.txtNomComplet.TabIndex = 7

        Me.dgvUtilisateurs.AllowUserToAddRows = False
        Me.dgvUtilisateurs.AllowUserToDeleteRows = False
        Me.dgvUtilisateurs.Location = New System.Drawing.Point(430, 55)
        Me.dgvUtilisateurs.Name = "dgvUtilisateurs"
        Me.dgvUtilisateurs.ReadOnly = True
        Me.dgvUtilisateurs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUtilisateurs.Size = New System.Drawing.Size(500, 350)
        Me.dgvUtilisateurs.TabIndex = 2

        Me.btnAjouter.BackColor = System.Drawing.Color.FromArgb(0, 180, 0)
        Me.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjouter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAjouter.ForeColor = System.Drawing.Color.White
        Me.btnAjouter.Location = New System.Drawing.Point(20, 285)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(90, 35)
        Me.btnAjouter.TabIndex = 3
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = False

        Me.btnModifier.BackColor = System.Drawing.Color.FromArgb(255, 140, 0)
        Me.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModifier.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnModifier.ForeColor = System.Drawing.Color.White
        Me.btnModifier.Location = New System.Drawing.Point(120, 285)
        Me.btnModifier.Name = "btnModifier"
        Me.btnModifier.Size = New System.Drawing.Size(90, 35)
        Me.btnModifier.TabIndex = 4
        Me.btnModifier.Text = "Modifier"
        Me.btnModifier.UseVisualStyleBackColor = False

        Me.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(220, 0, 0)
        Me.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupprimer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupprimer.ForeColor = System.Drawing.Color.White
        Me.btnSupprimer.Location = New System.Drawing.Point(220, 285)
        Me.btnSupprimer.Name = "btnSupprimer"
        Me.btnSupprimer.Size = New System.Drawing.Size(90, 35)
        Me.btnSupprimer.TabIndex = 5
        Me.btnSupprimer.Text = "Supprimer"
        Me.btnSupprimer.UseVisualStyleBackColor = False

        Me.btnFermer.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFermer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Location = New System.Drawing.Point(830, 285)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(100, 35)
        Me.btnFermer.TabIndex = 6
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 350)
        Me.Controls.Add(Me.btnFermer)
        Me.Controls.Add(Me.btnSupprimer)
        Me.Controls.Add(Me.btnModifier)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.dgvUtilisateurs)
        Me.Controls.Add(Me.grpInformations)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "UtilisateurForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des Utilisateurs"
        Me.grpInformations.ResumeLayout(False)
        Me.grpInformations.PerformLayout()
        CType(Me.dgvUtilisateurs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
