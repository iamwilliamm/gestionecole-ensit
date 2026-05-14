Partial Class ReinscriptionForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents grpInformations As System.Windows.Forms.GroupBox
    Private WithEvents lblEtudiant As System.Windows.Forms.Label
    Private WithEvents cmbEtudiant As System.Windows.Forms.ComboBox
    Private WithEvents lblNiveauActuel As System.Windows.Forms.Label
    Private WithEvents lblNiveau As System.Windows.Forms.Label
    Private WithEvents nudNiveau As System.Windows.Forms.NumericUpDown
    Private WithEvents lblObservations As System.Windows.Forms.Label
    Private WithEvents txtObservations As System.Windows.Forms.TextBox
    Private WithEvents dgvReinscriptions As System.Windows.Forms.DataGridView
    Private WithEvents btnAjouter As System.Windows.Forms.Button
    Private WithEvents btnSupprimer As System.Windows.Forms.Button
    Private WithEvents btnFermer As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.grpInformations = New System.Windows.Forms.GroupBox()
        Me.lblEtudiant = New System.Windows.Forms.Label()
        Me.cmbEtudiant = New System.Windows.Forms.ComboBox()
        Me.lblNiveauActuel = New System.Windows.Forms.Label()
        Me.lblNiveau = New System.Windows.Forms.Label()
        Me.nudNiveau = New System.Windows.Forms.NumericUpDown()
        Me.lblObservations = New System.Windows.Forms.Label()
        Me.txtObservations = New System.Windows.Forms.TextBox()
        Me.dgvReinscriptions = New System.Windows.Forms.DataGridView()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnSupprimer = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        Me.grpInformations.SuspendLayout()
        CType(Me.nudNiveau, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReinscriptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTitre.Location = New System.Drawing.Point(20, 10)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(300, 35)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Gestion des Réinscriptions"

        Me.grpInformations.Controls.Add(Me.lblEtudiant)
        Me.grpInformations.Controls.Add(Me.cmbEtudiant)
        Me.grpInformations.Controls.Add(Me.lblNiveauActuel)
        Me.grpInformations.Controls.Add(Me.lblNiveau)
        Me.grpInformations.Controls.Add(Me.nudNiveau)
        Me.grpInformations.Controls.Add(Me.lblObservations)
        Me.grpInformations.Controls.Add(Me.txtObservations)
        Me.grpInformations.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpInformations.Location = New System.Drawing.Point(20, 55)
        Me.grpInformations.Name = "grpInformations"
        Me.grpInformations.Size = New System.Drawing.Size(400, 250)
        Me.grpInformations.TabIndex = 1
        Me.grpInformations.TabStop = False
        Me.grpInformations.Text = "Nouvelle réinscription"

        Me.lblEtudiant.AutoSize = True
        Me.lblEtudiant.Location = New System.Drawing.Point(15, 30)
        Me.lblEtudiant.Name = "lblEtudiant"
        Me.lblEtudiant.Size = New System.Drawing.Size(65, 19)
        Me.lblEtudiant.TabIndex = 0
        Me.lblEtudiant.Text = "Étudiant:"

        Me.cmbEtudiant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEtudiant.FormattingEnabled = True
        Me.cmbEtudiant.Location = New System.Drawing.Point(15, 55)
        Me.cmbEtudiant.Name = "cmbEtudiant"
        Me.cmbEtudiant.Size = New System.Drawing.Size(360, 23)
        Me.cmbEtudiant.TabIndex = 1

        Me.lblNiveauActuel.AutoSize = True
        Me.lblNiveauActuel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic)
        Me.lblNiveauActuel.ForeColor = System.Drawing.Color.Gray
        Me.lblNiveauActuel.Location = New System.Drawing.Point(15, 85)
        Me.lblNiveauActuel.Name = "lblNiveauActuel"
        Me.lblNiveauActuel.Size = New System.Drawing.Size(100, 15)
        Me.lblNiveauActuel.TabIndex = 2
        Me.lblNiveauActuel.Text = "Niveau actuel: -"

        Me.lblNiveau.AutoSize = True
        Me.lblNiveau.Location = New System.Drawing.Point(15, 115)
        Me.lblNiveau.Name = "lblNiveau"
        Me.lblNiveau.Size = New System.Drawing.Size(50, 19)
        Me.lblNiveau.TabIndex = 3
        Me.lblNiveau.Text = "Niveau:"

        Me.nudNiveau.Location = New System.Drawing.Point(15, 137)
        Me.nudNiveau.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.nudNiveau.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNiveau.Name = "nudNiveau"
        Me.nudNiveau.Size = New System.Drawing.Size(60, 25)
        Me.nudNiveau.TabIndex = 4
        Me.nudNiveau.Value = New Decimal(New Integer() {1, 0, 0, 0})

        Me.lblObservations.AutoSize = True
        Me.lblObservations.Location = New System.Drawing.Point(15, 175)
        Me.lblObservations.Name = "lblObservations"
        Me.lblObservations.Size = New System.Drawing.Size(95, 19)
        Me.lblObservations.TabIndex = 5
        Me.lblObservations.Text = "Observations:"

        Me.txtObservations.Location = New System.Drawing.Point(15, 197)
        Me.txtObservations.Multiline = True
        Me.txtObservations.Name = "txtObservations"
        Me.txtObservations.Size = New System.Drawing.Size(360, 40)
        Me.txtObservations.TabIndex = 6

        Me.dgvReinscriptions.AllowUserToAddRows = False
        Me.dgvReinscriptions.AllowUserToDeleteRows = False
        Me.dgvReinscriptions.Location = New System.Drawing.Point(430, 55)
        Me.dgvReinscriptions.Name = "dgvReinscriptions"
        Me.dgvReinscriptions.ReadOnly = True
        Me.dgvReinscriptions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReinscriptions.Size = New System.Drawing.Size(700, 350)
        Me.dgvReinscriptions.TabIndex = 2

        Me.btnAjouter.BackColor = System.Drawing.Color.FromArgb(0, 180, 0)
        Me.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjouter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAjouter.ForeColor = System.Drawing.Color.White
        Me.btnAjouter.Location = New System.Drawing.Point(20, 315)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(120, 35)
        Me.btnAjouter.TabIndex = 3
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = False

        Me.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(220, 0, 0)
        Me.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupprimer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupprimer.ForeColor = System.Drawing.Color.White
        Me.btnSupprimer.Location = New System.Drawing.Point(160, 315)
        Me.btnSupprimer.Name = "btnSupprimer"
        Me.btnSupprimer.Size = New System.Drawing.Size(120, 35)
        Me.btnSupprimer.TabIndex = 4
        Me.btnSupprimer.Text = "Supprimer"
        Me.btnSupprimer.UseVisualStyleBackColor = False

        Me.btnFermer.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFermer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Location = New System.Drawing.Point(1030, 315)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(100, 35)
        Me.btnFermer.TabIndex = 5
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 370)
        Me.Controls.Add(Me.btnFermer)
        Me.Controls.Add(Me.btnSupprimer)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.dgvReinscriptions)
        Me.Controls.Add(Me.grpInformations)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "ReinscriptionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des Réinscriptions"
        Me.grpInformations.ResumeLayout(False)
        Me.grpInformations.PerformLayout()
        CType(Me.nudNiveau, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReinscriptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
