Partial Class MainForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private WithEvents panelMenu As System.Windows.Forms.Panel
    Private WithEvents lblTitre As System.Windows.Forms.Label
    Private WithEvents lblBienvenue As System.Windows.Forms.Label
    Private WithEvents btnEtudiants As System.Windows.Forms.Button
    Private WithEvents btnFilieres As System.Windows.Forms.Button
    Private WithEvents btnReinscriptions As System.Windows.Forms.Button
    Private WithEvents btnPaiements As System.Windows.Forms.Button
    Private WithEvents btnRapports As System.Windows.Forms.Button
    Private WithEvents btnGestionUtilisateurs As System.Windows.Forms.Button
    Private WithEvents btnJournal As System.Windows.Forms.Button
    Private WithEvents btnDeconnexion As System.Windows.Forms.Button
    Private WithEvents panelHeader As System.Windows.Forms.Panel

    Private Sub InitializeComponent()
        Me.panelMenu = New System.Windows.Forms.Panel()
        Me.panelHeader = New System.Windows.Forms.Panel()
        Me.lblBienvenue = New System.Windows.Forms.Label()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.btnEtudiants = New System.Windows.Forms.Button()
        Me.btnFilieres = New System.Windows.Forms.Button()
        Me.btnReinscriptions = New System.Windows.Forms.Button()
        Me.btnPaiements = New System.Windows.Forms.Button()
        Me.btnRapports = New System.Windows.Forms.Button()
        Me.btnGestionUtilisateurs = New System.Windows.Forms.Button()
        Me.btnJournal = New System.Windows.Forms.Button()
        Me.btnDeconnexion = New System.Windows.Forms.Button()
        Me.panelMenu.SuspendLayout()
        Me.panelHeader.SuspendLayout()
        Me.SuspendLayout()

        Me.panelMenu.BackColor = System.Drawing.Color.FromArgb(45, 45, 48)
        Me.panelMenu.Controls.Add(Me.btnDeconnexion)
        Me.panelMenu.Controls.Add(Me.btnJournal)
        Me.panelMenu.Controls.Add(Me.btnGestionUtilisateurs)
        Me.panelMenu.Controls.Add(Me.btnRapports)
        Me.panelMenu.Controls.Add(Me.btnPaiements)
        Me.panelMenu.Controls.Add(Me.btnReinscriptions)
        Me.panelMenu.Controls.Add(Me.btnFilieres)
        Me.panelMenu.Controls.Add(Me.btnEtudiants)
        Me.panelMenu.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelMenu.Location = New System.Drawing.Point(0, 0)
        Me.panelMenu.Name = "panelMenu"
        Me.panelMenu.Size = New System.Drawing.Size(250, 600)
        Me.panelMenu.TabIndex = 0

        Me.btnEtudiants.FlatAppearance.BorderSize = 0
        Me.btnEtudiants.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEtudiants.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnEtudiants.ForeColor = System.Drawing.Color.White
        Me.btnEtudiants.Location = New System.Drawing.Point(0, 100)
        Me.btnEtudiants.Name = "btnEtudiants"
        Me.btnEtudiants.Size = New System.Drawing.Size(250, 50)
        Me.btnEtudiants.TabIndex = 0
        Me.btnEtudiants.Text = "Gestion Étudiants"
        Me.btnEtudiants.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEtudiants.UseVisualStyleBackColor = True

        Me.btnFilieres.FlatAppearance.BorderSize = 0
        Me.btnFilieres.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilieres.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnFilieres.ForeColor = System.Drawing.Color.White
        Me.btnFilieres.Location = New System.Drawing.Point(0, 150)
        Me.btnFilieres.Name = "btnFilieres"
        Me.btnFilieres.Size = New System.Drawing.Size(250, 50)
        Me.btnFilieres.TabIndex = 1
        Me.btnFilieres.Text = "Gestion Filières"
        Me.btnFilieres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFilieres.UseVisualStyleBackColor = True

        Me.btnReinscriptions.FlatAppearance.BorderSize = 0
        Me.btnReinscriptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReinscriptions.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnReinscriptions.ForeColor = System.Drawing.Color.White
        Me.btnReinscriptions.Location = New System.Drawing.Point(0, 200)
        Me.btnReinscriptions.Name = "btnReinscriptions"
        Me.btnReinscriptions.Size = New System.Drawing.Size(250, 50)
        Me.btnReinscriptions.TabIndex = 2
        Me.btnReinscriptions.Text = "Réinscriptions"
        Me.btnReinscriptions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReinscriptions.UseVisualStyleBackColor = True

        Me.btnPaiements.FlatAppearance.BorderSize = 0
        Me.btnPaiements.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPaiements.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnPaiements.ForeColor = System.Drawing.Color.White
        Me.btnPaiements.Location = New System.Drawing.Point(0, 250)
        Me.btnPaiements.Name = "btnPaiements"
        Me.btnPaiements.Size = New System.Drawing.Size(250, 50)
        Me.btnPaiements.TabIndex = 3
        Me.btnPaiements.Text = "Paiements"
        Me.btnPaiements.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPaiements.UseVisualStyleBackColor = True

        Me.btnRapports.FlatAppearance.BorderSize = 0
        Me.btnRapports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRapports.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnRapports.ForeColor = System.Drawing.Color.White
        Me.btnRapports.Location = New System.Drawing.Point(0, 300)
        Me.btnRapports.Name = "btnRapports"
        Me.btnRapports.Size = New System.Drawing.Size(250, 50)
        Me.btnRapports.TabIndex = 4
        Me.btnRapports.Text = "Rapports"
        Me.btnRapports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRapports.UseVisualStyleBackColor = True

        Me.btnGestionUtilisateurs.FlatAppearance.BorderSize = 0
        Me.btnGestionUtilisateurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGestionUtilisateurs.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnGestionUtilisateurs.ForeColor = System.Drawing.Color.White
        Me.btnGestionUtilisateurs.Location = New System.Drawing.Point(0, 350)
        Me.btnGestionUtilisateurs.Name = "btnGestionUtilisateurs"
        Me.btnGestionUtilisateurs.Size = New System.Drawing.Size(250, 50)
        Me.btnGestionUtilisateurs.TabIndex = 5
        Me.btnGestionUtilisateurs.Text = "Utilisateurs"
        Me.btnGestionUtilisateurs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGestionUtilisateurs.UseVisualStyleBackColor = True

        Me.btnJournal.FlatAppearance.BorderSize = 0
        Me.btnJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJournal.Font = New System.Drawing.Font("Segoe UI", 11.0!)
        Me.btnJournal.ForeColor = System.Drawing.Color.White
        Me.btnJournal.Location = New System.Drawing.Point(0, 400)
        Me.btnJournal.Name = "btnJournal"
        Me.btnJournal.Size = New System.Drawing.Size(250, 50)
        Me.btnJournal.TabIndex = 6
        Me.btnJournal.Text = "Journal des actions"
        Me.btnJournal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnJournal.UseVisualStyleBackColor = True

        Me.btnDeconnexion.FlatAppearance.BorderSize = 0
        Me.btnDeconnexion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeconnexion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnDeconnexion.ForeColor = System.Drawing.Color.White
        Me.btnDeconnexion.Location = New System.Drawing.Point(0, 520)
        Me.btnDeconnexion.Name = "btnDeconnexion"
        Me.btnDeconnexion.Size = New System.Drawing.Size(250, 50)
        Me.btnDeconnexion.TabIndex = 7
        Me.btnDeconnexion.Text = "Déconnexion"
        Me.btnDeconnexion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDeconnexion.UseVisualStyleBackColor = True

        Me.panelHeader.BackColor = System.Drawing.Color.FromArgb(0, 120, 215)
        Me.panelHeader.Controls.Add(Me.lblBienvenue)
        Me.panelHeader.Controls.Add(Me.lblTitre)
        Me.panelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHeader.Location = New System.Drawing.Point(250, 0)
        Me.panelHeader.Name = "panelHeader"
        Me.panelHeader.Size = New System.Drawing.Size(800, 80)
        Me.panelHeader.TabIndex = 1

        Me.lblTitre.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitre.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitre.ForeColor = System.Drawing.Color.White
        Me.lblTitre.Location = New System.Drawing.Point(0, 0)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(800, 50)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Gestion des Inscriptions et Paiements"
        Me.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.lblBienvenue.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblBienvenue.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblBienvenue.ForeColor = System.Drawing.Color.White
        Me.lblBienvenue.Location = New System.Drawing.Point(0, 50)
        Me.lblBienvenue.Name = "lblBienvenue"
        Me.lblBienvenue.Size = New System.Drawing.Size(800, 30)
        Me.lblBienvenue.TabIndex = 1
        Me.lblBienvenue.Text = "Bienvenue"
        Me.lblBienvenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter

        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1050, 600)
        Me.Controls.Add(Me.panelHeader)
        Me.Controls.Add(Me.panelMenu)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion École"
        Me.panelMenu.ResumeLayout(False)
        Me.panelHeader.ResumeLayout(False)
        Me.ResumeLayout(False)
    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
End Class
