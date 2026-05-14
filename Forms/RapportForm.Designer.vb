Partial Class RapportForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents grpFiltres As System.Windows.Forms.GroupBox
    Private WithEvents lblFiliere As System.Windows.Forms.Label
    Private WithEvents cmbFiliere As System.Windows.Forms.ComboBox
    Private WithEvents btnRapportEtudiants As System.Windows.Forms.Button
    Private WithEvents btnRapportPaiements As System.Windows.Forms.Button
    Private WithEvents btnRapportImpayes As System.Windows.Forms.Button
    Private WithEvents lblTypeRapport As System.Windows.Forms.Label
    Private WithEvents dgvRapport As System.Windows.Forms.DataGridView
    Private WithEvents btnExporterExcel As System.Windows.Forms.Button
    Private WithEvents btnFermer As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.grpFiltres = New System.Windows.Forms.GroupBox()
        Me.lblFiliere = New System.Windows.Forms.Label()
        Me.cmbFiliere = New System.Windows.Forms.ComboBox()
        Me.btnRapportEtudiants = New System.Windows.Forms.Button()
        Me.btnRapportPaiements = New System.Windows.Forms.Button()
        Me.btnRapportImpayes = New System.Windows.Forms.Button()
        Me.lblTypeRapport = New System.Windows.Forms.Label()
        Me.dgvRapport = New System.Windows.Forms.DataGridView()
        Me.btnExporterExcel = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        Me.grpFiltres.SuspendLayout()
        CType(Me.dgvRapport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTitre.Location = New System.Drawing.Point(20, 10)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(200, 35)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Rapports"

        Me.grpFiltres.Controls.Add(Me.lblFiliere)
        Me.grpFiltres.Controls.Add(Me.cmbFiliere)
        Me.grpFiltres.Controls.Add(Me.btnRapportEtudiants)
        Me.grpFiltres.Controls.Add(Me.btnRapportPaiements)
        Me.grpFiltres.Controls.Add(Me.btnRapportImpayes)
        Me.grpFiltres.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.grpFiltres.Location = New System.Drawing.Point(20, 55)
        Me.grpFiltres.Name = "grpFiltres"
        Me.grpFiltres.Size = New System.Drawing.Size(400, 120)
        Me.grpFiltres.TabIndex = 1
        Me.grpFiltres.TabStop = False
        Me.grpFiltres.Text = "Générer un rapport"

        Me.lblFiliere.AutoSize = True
        Me.lblFiliere.Location = New System.Drawing.Point(15, 30)
        Me.lblFiliere.Name = "lblFiliere"
        Me.lblFiliere.Size = New System.Drawing.Size(50, 19)
        Me.lblFiliere.TabIndex = 0
        Me.lblFiliere.Text = "Filière:"

        Me.cmbFiliere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiliere.FormattingEnabled = True
        Me.cmbFiliere.Location = New System.Drawing.Point(15, 55)
        Me.cmbFiliere.Name = "cmbFiliere"
        Me.cmbFiliere.Size = New System.Drawing.Size(200, 23)
        Me.cmbFiliere.TabIndex = 1

        Me.btnRapportEtudiants.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnRapportEtudiants.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRapportEtudiants.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRapportEtudiants.ForeColor = System.Drawing.Color.White
        Me.btnRapportEtudiants.Location = New System.Drawing.Point(230, 30)
        Me.btnRapportEtudiants.Name = "btnRapportEtudiants"
        Me.btnRapportEtudiants.Size = New System.Drawing.Size(150, 30)
        Me.btnRapportEtudiants.TabIndex = 2
        Me.btnRapportEtudiants.Text = "Liste étudiants"
        Me.btnRapportEtudiants.UseVisualStyleBackColor = False

        Me.btnRapportPaiements.BackColor = System.Drawing.Color.FromArgb(0, 180, 0)
        Me.btnRapportPaiements.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRapportPaiements.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRapportPaiements.ForeColor = System.Drawing.Color.White
        Me.btnRapportPaiements.Location = New System.Drawing.Point(230, 65)
        Me.btnRapportPaiements.Name = "btnRapportPaiements"
        Me.btnRapportPaiements.Size = New System.Drawing.Size(150, 30)
        Me.btnRapportPaiements.TabIndex = 3
        Me.btnRapportPaiements.Text = "Paiements reçus"
        Me.btnRapportPaiements.UseVisualStyleBackColor = False

        Me.btnRapportImpayes.BackColor = System.Drawing.Color.FromArgb(220, 0, 0)
        Me.btnRapportImpayes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRapportImpayes.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.btnRapportImpayes.ForeColor = System.Drawing.Color.White
        Me.btnRapportImpayes.Location = New System.Drawing.Point(15, 80)
        Me.btnRapportImpayes.Name = "btnRapportImpayes"
        Me.btnRapportImpayes.Size = New System.Drawing.Size(150, 30)
        Me.btnRapportImpayes.TabIndex = 4
        Me.btnRapportImpayes.Text = "Étudiants impayés"
        Me.btnRapportImpayes.UseVisualStyleBackColor = False

        Me.lblTypeRapport.AutoSize = True
        Me.lblTypeRapport.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic)
        Me.lblTypeRapport.Location = New System.Drawing.Point(430, 70)
        Me.lblTypeRapport.Name = "lblTypeRapport"
        Me.lblTypeRapport.Size = New System.Drawing.Size(120, 19)
        Me.lblTypeRapport.TabIndex = 2
        Me.lblTypeRapport.Text = "Sélectionnez un rapport"

        Me.dgvRapport.AllowUserToAddRows = False
        Me.dgvRapport.AllowUserToDeleteRows = False
        Me.dgvRapport.Location = New System.Drawing.Point(20, 185)
        Me.dgvRapport.Name = "dgvRapport"
        Me.dgvRapport.ReadOnly = True
        Me.dgvRapport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRapport.Size = New System.Drawing.Size(1100, 350)
        Me.dgvRapport.TabIndex = 3

        Me.btnExporterExcel.BackColor = System.Drawing.Color.FromArgb(0, 180, 0)
        Me.btnExporterExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExporterExcel.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnExporterExcel.ForeColor = System.Drawing.Color.White
        Me.btnExporterExcel.Location = New System.Drawing.Point(20, 545)
        Me.btnExporterExcel.Name = "btnExporterExcel"
        Me.btnExporterExcel.Size = New System.Drawing.Size(200, 40)
        Me.btnExporterExcel.TabIndex = 4
        Me.btnExporterExcel.Text = "Exporter en Excel"
        Me.btnExporterExcel.UseVisualStyleBackColor = False

        Me.btnFermer.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFermer.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Location = New System.Drawing.Point(920, 545)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(200, 40)
        Me.btnFermer.TabIndex = 5
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 600)
        Me.Controls.Add(Me.btnFermer)
        Me.Controls.Add(Me.btnExporterExcel)
        Me.Controls.Add(Me.dgvRapport)
        Me.Controls.Add(Me.lblTypeRapport)
        Me.Controls.Add(Me.grpFiltres)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "RapportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rapports"
        Me.grpFiltres.ResumeLayout(False)
        Me.grpFiltres.PerformLayout()
        CType(Me.dgvRapport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
