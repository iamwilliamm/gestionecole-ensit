Partial Class JournalForm
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.IContainer
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents dgvJournal As System.Windows.Forms.DataGridView
    Private WithEvents btnActualiser As System.Windows.Forms.Button
    Private WithEvents btnFermer As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.dgvJournal = New System.Windows.Forms.DataGridView()
        Me.btnActualiser = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        CType(Me.dgvJournal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()

        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.lblTitre.Location = New System.Drawing.Point(20, 10)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(350, 35)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Journal des actions"

        Me.dgvJournal.AllowUserToAddRows = False
        Me.dgvJournal.AllowUserToDeleteRows = False
        Me.dgvJournal.Location = New System.Drawing.Point(20, 55)
        Me.dgvJournal.Name = "dgvJournal"
        Me.dgvJournal.ReadOnly = True
        Me.dgvJournal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvJournal.Size = New System.Drawing.Size(1100, 400)
        Me.dgvJournal.TabIndex = 1

        Me.btnActualiser.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.btnActualiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnActualiser.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnActualiser.ForeColor = System.Drawing.Color.White
        Me.btnActualiser.Location = New System.Drawing.Point(20, 465)
        Me.btnActualiser.Name = "btnActualiser"
        Me.btnActualiser.Size = New System.Drawing.Size(150, 35)
        Me.btnActualiser.TabIndex = 2
        Me.btnActualiser.Text = "Actualiser"
        Me.btnActualiser.UseVisualStyleBackColor = False

        Me.btnFermer.BackColor = System.Drawing.Color.FromArgb(100, 100, 100)
        Me.btnFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFermer.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnFermer.ForeColor = System.Drawing.Color.White
        Me.btnFermer.Location = New System.Drawing.Point(1020, 465)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(100, 35)
        Me.btnFermer.TabIndex = 3
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = False

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1140, 520)
        Me.Controls.Add(Me.btnFermer)
        Me.Controls.Add(Me.btnActualiser)
        Me.Controls.Add(Me.dgvJournal)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "JournalForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal des actions"
        CType(Me.dgvJournal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then components.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class
