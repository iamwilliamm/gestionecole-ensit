Partial Class PaiementForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents grpInformations As System.Windows.Forms.GroupBox
    Private WithEvents lblEtudiant As System.Windows.Forms.Label
    Private WithEvents cmbEtudiant As System.Windows.Forms.ComboBox
    Private WithEvents lblMontant As System.Windows.Forms.Label
    Private WithEvents nudMontant As System.Windows.Forms.NumericUpDown
    Private WithEvents lblDate As System.Windows.Forms.Label
    Private WithEvents dtpDatePaiement As System.Windows.Forms.DateTimePicker
    Private WithEvents lblTypeFrais As System.Windows.Forms.Label
    Private WithEvents cmbTypeFrais As System.Windows.Forms.ComboBox
    Private WithEvents lblMode As System.Windows.Forms.Label
    Private WithEvents cmbModePaiement As System.Windows.Forms.ComboBox
    Private WithEvents lblReference As System.Windows.Forms.Label
    Private WithEvents txtReference As System.Windows.Forms.TextBox
    Private WithEvents lblStatut As System.Windows.Forms.Label
    Private WithEvents cmbStatut As System.Windows.Forms.ComboBox
    Private WithEvents lblObservations As System.Windows.Forms.Label
    Private WithEvents txtObservations As System.Windows.Forms.TextBox
    Private WithEvents dgvPaiements As System.Windows.Forms.DataGridView
    Private WithEvents btnAjouter As System.Windows.Forms.Button
    Private WithEvents btnModifier As System.Windows.Forms.Button
    Private WithEvents btnSupprimer As System.Windows.Forms.Button
    Private WithEvents btnImpayes As System.Windows.Forms.Button
    Private WithEvents btnTous As System.Windows.Forms.Button
    Private WithEvents btnFermer As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.grpInformations = New System.Windows.Forms.GroupBox()
        Me.lblEtudiant = New System.Windows.Forms.Label()
        Me.cmbEtudiant = New System.Windows.Forms.ComboBox()
        Me.lblMontant = New System.Windows.Forms.Label()
        Me.nudMontant = New System.Windows.Forms.NumericUpDown()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtpDatePaiement = New System.Windows.Forms.DateTimePicker()
        Me.lblTypeFrais = New System.Windows.Forms.Label()
        Me.cmbTypeFrais = New System.Windows.Forms.ComboBox()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.cmbModePaiement = New System.Windows.Forms.ComboBox()
        Me.lblReference = New System.Windows.Forms.Label()
        Me.txtReference = New System.Windows.Forms.TextBox()
        Me.lblStatut = New System.Windows.Forms.Label()
        Me.cmbStatut = New System.Windows.Forms.ComboBox()
        Me.lblObservations = New System.Windows.Forms.Label()
        Me.txtObservations = New System.Windows.Forms.TextBox()
        Me.dgvPaiements = New System.Windows.Forms.DataGridView()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnModifier = New System.Windows.Forms.Button()
        Me.btnSupprimer = New System.Windows.Forms.Button()
        Me.btnImpayes = New System.Windows.Forms.Button()
        Me.btnTous = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        Me.grpInformations.SuspendLayout()
        CType(Me.nudMontant, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPaiements, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTitre.Location = New System.Drawing.Point(20, 10)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(250, 35)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Gestion des Paiements"

        Me.grpInformations.Controls.Add(Me.lblEtudiant)
        Me.grpInformations.Controls.Add(Me.cmbEtudiant)
        Me.grpInformations.Controls.Add(Me.lblMontant)
        Me.grpInformations.Controls.Add(Me.nudMontant)
        Me.grpInformations.Controls.Add(Me.lblDate)
        Me.grpInformations.Controls.Add(Me.dtpDatePaiement)
        Me.grpInformations.Controls.Add(Me.lblTypeFrais)
        Me.grpInformations.Controls.Add(Me.cmbTypeFrais)
        Me.grpInformations.Controls.Add(Me.lblMode)
        Me.grpInformations.Controls.Add(Me.cmbModePaiement)
        Me.grpInformations.Controls.Add(Me.lblReference)
        Me.grpInformations.Controls.Add(Me.txtReference)
        Me.grpInformations.Controls.Add(Me.lblStatut)
        Me.grpInformations.Controls.Add(Me.cmbStatut)
        Me.grpInformations.Controls.Add(Me.lblObservations)
        Me.grpInformations.Controls.Add(Me.txtObservations)
        Me.grpInformations.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpInformations.Location = New System.Drawing.Point(20, 55)
        Me.grpInformations.Name = "grpInformations"
        Me.grpInformations.Size = New System.Drawing.Size(400, 380)
        Me.grpInformations.TabIndex = 1
        Me.grpInformations.TabStop = False
        Me.grpInformations.Text = "Paiement"

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

        Me.lblMontant.AutoSize = True
        Me.lblMontant.Location = New System.Drawing.Point(15, 85)
        Me.lblMontant.Name = "lblMontant"
        Me.lblMontant.Size = New System.Drawing.Size(55, 19)
        Me.lblMontant.TabIndex = 2
        Me.lblMontant.Text = "Montant:"

        Me.nudMontant.DecimalPlaces = 2
        Me.nudMontant.Location = New System.Drawing.Point(15, 107)
        Me.nudMontant.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudMontant.Name = "nudMontant"
        Me.nudMontant.Size = New System.Drawing.Size(150, 25)
        Me.nudMontant.TabIndex = 3

        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(180, 85)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(35, 19)
        Me.lblDate.TabIndex = 4
        Me.lblDate.Text = "Date:"

        Me.dtpDatePaiement.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpDatePaiement.Location = New System.Drawing.Point(180, 107)
        Me.dtpDatePaiement.Name = "dtpDatePaiement"
        Me.dtpDatePaiement.Size = New System.Drawing.Size(150, 25)
        Me.dtpDatePaiement.TabIndex = 5

        Me.lblTypeFrais.AutoSize = True
        Me.lblTypeFrais.Location = New System.Drawing.Point(15, 140)
        Me.lblTypeFrais.Name = "lblTypeFrais"
        Me.lblTypeFrais.Size = New System.Drawing.Size(75, 19)
        Me.lblTypeFrais.TabIndex = 6
        Me.lblTypeFrais.Text = "Type frais:"

        Me.cmbTypeFrais.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTypeFrais.FormattingEnabled = True
        Me.cmbTypeFrais.Location = New System.Drawing.Point(15, 162)
        Me.cmbTypeFrais.Name = "cmbTypeFrais"
        Me.cmbTypeFrais.Size = New System.Drawing.Size(150, 23)
        Me.cmbTypeFrais.TabIndex = 7

        Me.lblMode.AutoSize = True
        Me.lblMode.Location = New System.Drawing.Point(180, 140)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(90, 19)
        Me.lblMode.TabIndex = 8
        Me.lblMode.Text = "Mode paiement:"

        Me.cmbModePaiement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbModePaiement.FormattingEnabled = True
        Me.cmbModePaiement.Location = New System.Drawing.Point(180, 162)
        Me.cmbModePaiement.Name = "cmbModePaiement"
        Me.cmbModePaiement.Size = New System.Drawing.Size(150, 23)
        Me.cmbModePaiement.TabIndex = 9

        Me.lblReference.AutoSize = True
        Me.lblReference.Location = New System.Drawing.Point(15, 195)
        Me.lblReference.Name = "lblReference"
        Me.lblReference.Size = New System.Drawing.Size(70, 19)
        Me.lblReference.TabIndex = 10
        Me.lblReference.Text = "Référence:"

        Me.txtReference.Location = New System.Drawing.Point(15, 217)
        Me.txtReference.Name = "txtReference"
        Me.txtReference.Size = New System.Drawing.Size(360, 25)
        Me.txtReference.TabIndex = 11

        Me.lblStatut.AutoSize = True
        Me.lblStatut.Location = New System.Drawing.Point(15, 250)
        Me.lblStatut.Name = "lblStatut"
        Me.lblStatut.Size = New System.Drawing.Size(45, 19)
        Me.lblStatut.TabIndex = 12
        Me.lblStatut.Text = "Statut:"

        Me.cmbStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStatut.FormattingEnabled = True
        Me.cmbStatut.Location = New System.Drawing.Point(15, 272)
        Me.cmbStatut.Name = "cmbStatut"
        Me.cmbStatut.Size = New System.Drawing.Size(150, 23)
        Me.cmbStatut.TabIndex = 13

        Me.lblObservations.AutoSize = True
        Me.lblObservations.Location = New System.Drawing.Point(15, 305)
        Me.lblObservations.Name = "lblObservations"
        Me.lblObservations.Size = New System.Drawing.Size(95, 19)
        Me.lblObservations.TabIndex = 14
        Me.lblObservations.Text = "Observations:"

        Me.txtObservations.Location = New System.Drawing.Point(15, 327)
        Me.txtObservations.Multiline = True
        Me.txtObservations.Name = "txtObservations"
        Me.txtObservations.Size = New System.Drawing.Size(360, 40)
        Me.txtObservations.TabIndex = 15

        Me.dgvPaiements.AllowUserToAddRows = False
        Me.dgvPaiements.AllowUserToDeleteRows = False
        Me.dgvPaiements.Location = New System.Drawing.Point(430, 55)
        Me.dgvPaiements.Name = "dgvPaiements"
        Me.dgvPaiements.ReadOnly = True
        Me.dgvPaiements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPaiements.Size = New System.Drawing.Size(700, 380)
        Me.dgvPaiements.TabIndex = 2

        Me.btnAjouter.BackColor = System.Drawing.Color.FromArgb(0, 180, 0)
        Me.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjouter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAjouter.ForeColor = System.Drawing.Color.White
        Me.btnAjouter.Location = New System.Drawing.Point(20, 445)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(90, 35)
        Me.btnAjouter.TabIndex = 3
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = False

        Me.btnModifier.BackColor = System.Drawing.Color.FromArgb(255, 140, 0)
        Me.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModifier.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnModifier.ForeColor = System.Drawing.Color.White
        Me.btnModifier.Location = New System.Drawing.Point(120, 445)
        Me.btnModifier.Name = "btnModifier"
        Me.btnModifier.Size = New System.Drawing.Size(90, 35)
        Me.btnModifier.TabIndex = 4
        Me.btnModifier.Text = "Modifier"
        Me.btnModifier.UseVisualStyleBackColor = False

        Me.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(220, 0, 0)
        Me.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupprimer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupprimer.ForeColor = System.Drawing.Color.White
        Me.btnSupprimer.Location = New System.Drawing.Point(220, 445)
        Me.btnSupprimer.Name = "btnSupprimer"
        Me.btnSupprimer.Size = New System.Drawing.Size(90, 35)
        Me.btnSupprimer.TabIndex = 5
        Me.btnSupprimer.Text = "Supprimer"
        Me.btnSupprimer.UseVisualStyleBackColor = False

        Me.btnImpayes.BackColor = System.Drawing.Color.FromArgb(220, 0, 0)
        Me.btnImpayes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImpayes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnImpayes.ForeColor = System.Drawing.Color.White
        Me.btnImpayes.Location = New System.Drawing.Point(430, 445)
        Me.btnImpayes.Name = "btnImpayes"
        Me.btnImpayes.Size = New System.Drawing.Size(120, 35)
        Me.btnImpayes.TabIndex = 6
        Me.btnImpayes.Text = "Voir impayés"
        Me.btnImpayes.UseVisualStyleBackColor = False

        Me.btnTous.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnTous.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTous.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTous.ForeColor = System.Drawing.Color.White
        Me.btnTous.Location = New System.Drawing.Point(560, 445)
        Me.btnTous.Name = "btnTous"
        Me.btnTous.Size = New System.Drawing.Size(120, 35)
        Me.btnTous.TabIndex = 7
        Me.btnTous.Text = "Tous les paiements"
        Me.btnTous.UseVisualStyleBackColor = False

        Me.btnFermer.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFermer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Location = New System.Drawing.Point(1030, 445)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(100, 35)
        Me.btnFermer.TabIndex = 8
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 500)
        Me.Controls.Add(Me.btnFermer)
        Me.Controls.Add(Me.btnTous)
        Me.Controls.Add(Me.btnImpayes)
        Me.Controls.Add(Me.btnSupprimer)
        Me.Controls.Add(Me.btnModifier)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.dgvPaiements)
        Me.Controls.Add(Me.grpInformations)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "PaiementForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des Paiements"
        Me.grpInformations.ResumeLayout(False)
        Me.grpInformations.PerformLayout()
        CType(Me.nudMontant, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPaiements, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
