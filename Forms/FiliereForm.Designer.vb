Partial Class FiliereForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents grpInformations As System.Windows.Forms.GroupBox
    Private WithEvents lblLibelle As System.Windows.Forms.Label
    Private WithEvents txtLibelle As System.Windows.Forms.TextBox
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents dgvFilieres As System.Windows.Forms.DataGridView
    Private WithEvents btnAjouter As System.Windows.Forms.Button
    Private WithEvents btnModifier As System.Windows.Forms.Button
    Private WithEvents btnSupprimer As System.Windows.Forms.Button
    Private WithEvents btnEffacer As System.Windows.Forms.Button
    Private WithEvents btnFermer As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.grpInformations = New System.Windows.Forms.GroupBox()
        Me.lblLibelle = New System.Windows.Forms.Label()
        Me.txtLibelle = New System.Windows.Forms.TextBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.dgvFilieres = New System.Windows.Forms.DataGridView()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnModifier = New System.Windows.Forms.Button()
        Me.btnSupprimer = New System.Windows.Forms.Button()
        Me.btnEffacer = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        Me.grpInformations.SuspendLayout()
        CType(Me.dgvFilieres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTitre.Location = New System.Drawing.Point(20, 10)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(250, 35)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Gestion des Filières"

        Me.grpInformations.Controls.Add(Me.lblLibelle)
        Me.grpInformations.Controls.Add(Me.txtLibelle)
        Me.grpInformations.Controls.Add(Me.lblDescription)
        Me.grpInformations.Controls.Add(Me.txtDescription)
        Me.grpInformations.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpInformations.Location = New System.Drawing.Point(20, 55)
        Me.grpInformations.Name = "grpInformations"
        Me.grpInformations.Size = New System.Drawing.Size(400, 180)
        Me.grpInformations.TabIndex = 1
        Me.grpInformations.TabStop = False
        Me.grpInformations.Text = "Informations"

        Me.lblLibelle.AutoSize = True
        Me.lblLibelle.Location = New System.Drawing.Point(15, 30)
        Me.lblLibelle.Name = "lblLibelle"
        Me.lblLibelle.Size = New System.Drawing.Size(55, 19)
        Me.lblLibelle.TabIndex = 0
        Me.lblLibelle.Text = "Libellé:"

        Me.txtLibelle.Location = New System.Drawing.Point(15, 55)
        Me.txtLibelle.Name = "txtLibelle"
        Me.txtLibelle.Size = New System.Drawing.Size(360, 25)
        Me.txtLibelle.TabIndex = 1

        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(15, 90)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(80, 19)
        Me.lblDescription.TabIndex = 2
        Me.lblDescription.Text = "Description:"

        Me.txtDescription.Location = New System.Drawing.Point(15, 115)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(360, 50)
        Me.txtDescription.TabIndex = 3

        Me.dgvFilieres.AllowUserToAddRows = False
        Me.dgvFilieres.AllowUserToDeleteRows = False
        Me.dgvFilieres.Location = New System.Drawing.Point(430, 55)
        Me.dgvFilieres.Name = "dgvFilieres"
        Me.dgvFilieres.ReadOnly = True
        Me.dgvFilieres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFilieres.Size = New System.Drawing.Size(500, 350)
        Me.dgvFilieres.TabIndex = 2

        Me.btnAjouter.BackColor = System.Drawing.Color.FromArgb(0, 180, 0)
        Me.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAjouter.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAjouter.ForeColor = System.Drawing.Color.White
        Me.btnAjouter.Location = New System.Drawing.Point(20, 250)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(90, 35)
        Me.btnAjouter.TabIndex = 3
        Me.btnAjouter.Text = "Ajouter"
        Me.btnAjouter.UseVisualStyleBackColor = False

        Me.btnModifier.BackColor = System.Drawing.Color.FromArgb(255, 140, 0)
        Me.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModifier.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnModifier.ForeColor = System.Drawing.Color.White
        Me.btnModifier.Location = New System.Drawing.Point(120, 250)
        Me.btnModifier.Name = "btnModifier"
        Me.btnModifier.Size = New System.Drawing.Size(90, 35)
        Me.btnModifier.TabIndex = 4
        Me.btnModifier.Text = "Modifier"
        Me.btnModifier.UseVisualStyleBackColor = False

        Me.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(220, 0, 0)
        Me.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSupprimer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSupprimer.ForeColor = System.Drawing.Color.White
        Me.btnSupprimer.Location = New System.Drawing.Point(220, 250)
        Me.btnSupprimer.Name = "btnSupprimer"
        Me.btnSupprimer.Size = New System.Drawing.Size(90, 35)
        Me.btnSupprimer.TabIndex = 5
        Me.btnSupprimer.Text = "Supprimer"
        Me.btnSupprimer.UseVisualStyleBackColor = False

        Me.btnEffacer.BackColor = System.Drawing.Color.Gray
        Me.btnEffacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEffacer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnEffacer.ForeColor = System.Drawing.Color.White
        Me.btnEffacer.Location = New System.Drawing.Point(320, 250)
        Me.btnEffacer.Name = "btnEffacer"
        Me.btnEffacer.Size = New System.Drawing.Size(90, 35)
        Me.btnEffacer.TabIndex = 6
        Me.btnEffacer.Text = "Effacer"
        Me.btnEffacer.UseVisualStyleBackColor = False

        Me.btnFermer.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFermer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Location = New System.Drawing.Point(830, 250)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(100, 35)
        Me.btnFermer.TabIndex = 7
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 320)
        Me.Controls.Add(Me.btnFermer)
        Me.Controls.Add(Me.btnEffacer)
        Me.Controls.Add(Me.btnSupprimer)
        Me.Controls.Add(Me.btnModifier)
        Me.Controls.Add(Me.btnAjouter)
        Me.Controls.Add(Me.dgvFilieres)
        Me.Controls.Add(Me.grpInformations)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "FiliereForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des Filières"
        Me.grpInformations.ResumeLayout(False)
        Me.grpInformations.PerformLayout()
        CType(Me.dgvFilieres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
