Imports System.Drawing.Drawing2D

Public Class MainForm
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configuration du formulaire MDI
        Me.IsMdiContainer = True
        Me.Text = "ENSIT - Système de Gestion des Inscriptions et Paiements"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Themes.ENSITTheme.FondPrincipal
        
        ' Créer l'en-tête
        CreateHeader()
        
        ' Créer le menu latéral
        CreateSideMenu()
        
        ' Créer la barre de statut
        CreateStatusBar()
        
        ' Afficher le dashboard au démarrage
        ShowDashboard()
        
        ' Vérifier les permissions
        If Not UtilisateurConnecte.IsAdministrateur Then
            ' Désactiver les fonctionnalités admin
            For Each ctrl As Control In sideMenuPanel.Controls
                If ctrl.Tag IsNot Nothing AndAlso ctrl.Tag.ToString() = "admin" Then
                    ctrl.Enabled = False
                    ctrl.Visible = False
                End If
            Next
        End If
    End Sub
    
    Private headerPanel As Panel
    Private sideMenuPanel As Panel
    Private contentPanel As Panel
    Private statusBar As StatusStrip
    
    Private Sub CreateHeader()
        ' Panel d'en-tête
        headerPanel = New Panel()
        headerPanel.Dock = DockStyle.Top
        headerPanel.Height = 70
        headerPanel.BackColor = Themes.ENSITTheme.BleuMarine
        
        ' Logo
        Dim logoPanel As New Panel()
        logoPanel.Size = New Size(60, 60)
        logoPanel.Location = New Point(10, 5)
        logoPanel.BackColor = Color.Transparent
        AddHandler logoPanel.Paint, AddressOf LogoPanel_Paint
        headerPanel.Controls.Add(logoPanel)
        
        ' Titre
        Dim lblTitre As New Label()
        lblTitre.Text = "ENSIT"
        lblTitre.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblTitre.ForeColor = Color.White
        lblTitre.Location = New Point(80, 10)
        lblTitre.AutoSize = True
        headerPanel.Controls.Add(lblTitre)
        
        ' Sous-titre
        Dim lblSousTitre As New Label()
        lblSousTitre.Text = "Système de Gestion"
        lblSousTitre.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblSousTitre.ForeColor = Color.FromArgb(200, 200, 200)
        lblSousTitre.Location = New Point(80, 40)
        lblSousTitre.AutoSize = True
        headerPanel.Controls.Add(lblSousTitre)
        
        ' Informations utilisateur (à droite)
        Dim userPanel As New Panel()
        userPanel.Dock = DockStyle.Right
        userPanel.Width = 300
        userPanel.BackColor = Color.Transparent
        
        Dim lblUtilisateur As New Label()
        lblUtilisateur.Text = $"👤 {UtilisateurConnecte.NomComplet}"
        lblUtilisateur.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        lblUtilisateur.ForeColor = Color.White
        lblUtilisateur.Location = New Point(10, 10)
        lblUtilisateur.AutoSize = True
        userPanel.Controls.Add(lblUtilisateur)
        
        Dim lblRole As New Label()
        lblRole.Text = $"Rôle: {UtilisateurConnecte.Role}"
        lblRole.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblRole.ForeColor = Themes.ENSITTheme.CouleurOr
        lblRole.Location = New Point(10, 35)
        lblRole.AutoSize = True
        userPanel.Controls.Add(lblRole)
        
        headerPanel.Controls.Add(userPanel)
        
        Me.Controls.Add(headerPanel)
    End Sub
    
    Private Sub CreateSideMenu()
        ' Panel du menu latéral
        sideMenuPanel = New Panel()
        sideMenuPanel.Dock = DockStyle.Left
        sideMenuPanel.Width = 250
        sideMenuPanel.BackColor = Color.FromArgb(40, 40, 50)
        sideMenuPanel.Padding = New Padding(0, 20, 0, 0)
        
        ' Titre du menu
        Dim lblMenu As New Label()
        lblMenu.Text = "MENU PRINCIPAL"
        lblMenu.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblMenu.ForeColor = Color.Gray
        lblMenu.Location = New Point(20, 10)
        lblMenu.AutoSize = True
        sideMenuPanel.Controls.Add(lblMenu)
        
        ' Boutons du menu
        Dim topPosition As Integer = 50
        
        ' Dashboard
        CreateMenuButton("📊 Tableau de bord", topPosition, AddressOf btnDashboard_Click)
        topPosition += 60
        
        ' Étudiants
        CreateMenuButton("👥 Gestion des étudiants", topPosition, AddressOf btnEtudiants_Click)
        topPosition += 60
        
        ' Filières
        CreateMenuButton("📚 Filières", topPosition, AddressOf btnFilieres_Click)
        topPosition += 60
        
        ' Réinscriptions
        CreateMenuButton("📝 Réinscriptions", topPosition, AddressOf btnReinscriptions_Click)
        topPosition += 60
        
        ' Paiements
        CreateMenuButton("💰 Paiements", topPosition, AddressOf btnPaiements_Click)
        topPosition += 60
        
        ' Rapports
        CreateMenuButton("📈 Rapports", topPosition, AddressOf btnRapports_Click)
        topPosition += 60
        
        ' Séparateur
        topPosition += 20
        
        ' Administration (tag admin)
        Dim btnAdmin As Button = CreateMenuButton("⚙️ Administration", topPosition, AddressOf btnGestionUtilisateurs_Click)
        btnAdmin.Tag = "admin"
        topPosition += 60
        
        ' Journal (tag admin)
        Dim btnJournal As Button = CreateMenuButton("📋 Journal d'activités", topPosition, AddressOf btnJournal_Click)
        btnJournal.Tag = "admin"
        topPosition += 80
        
        ' Déconnexion
        Dim btnDeconnexion As New Button()
        btnDeconnexion.Text = "🚪 Déconnexion"
        btnDeconnexion.Location = New Point(10, topPosition)
        btnDeconnexion.Size = New Size(230, 45)
        btnDeconnexion.BackColor = Themes.ENSITTheme.Danger
        btnDeconnexion.ForeColor = Color.White
        btnDeconnexion.FlatStyle = FlatStyle.Flat
        btnDeconnexion.FlatAppearance.BorderSize = 0
        btnDeconnexion.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnDeconnexion.Cursor = Cursors.Hand
        AddHandler btnDeconnexion.Click, AddressOf btnDeconnexion_Click
        sideMenuPanel.Controls.Add(btnDeconnexion)
        
        Me.Controls.Add(sideMenuPanel)
    End Sub
    
    Private Function CreateMenuButton(text As String, top As Integer, handler As EventHandler) As Button
        Dim btn As New Button()
        btn.Text = text
        btn.Location = New Point(10, top)
        btn.Size = New Size(230, 50)
        btn.BackColor = Color.Transparent
        btn.ForeColor = Color.White
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        btn.Cursor = Cursors.Hand
        btn.TextAlign = ContentAlignment.MiddleLeft
        btn.Padding = New Padding(10, 0, 0, 0)
        
        ' Effet hover
        AddHandler btn.MouseEnter, Sub()
                                      btn.BackColor = Themes.ENSITTheme.BleuClair
                                   End Sub
        AddHandler btn.MouseLeave, Sub()
                                      btn.BackColor = Color.Transparent
                                   End Sub
        
        AddHandler btn.Click, handler
        sideMenuPanel.Controls.Add(btn)
        
        Return btn
    End Function
    
    Private Sub CreateStatusBar()
        statusBar = New StatusStrip()
        statusBar.Dock = DockStyle.Bottom
        statusBar.BackColor = Themes.ENSITTheme.BleuMarine
        
        ' Label date et heure
        Dim lblDate As New ToolStripStatusLabel()
        lblDate.Text = DateTime.Now.ToString("dddd dd MMMM yyyy - HH:mm")
        lblDate.ForeColor = Color.White
        lblDate.Font = New Font("Segoe UI", 9)
        statusBar.Items.Add(lblDate)
        
        ' Séparateur
        statusBar.Items.Add(New ToolStripStatusLabel("     "))
        
        ' Label version
        Dim lblVersion As New ToolStripStatusLabel()
        lblVersion.Text = "Version 1.0"
        lblVersion.ForeColor = Color.FromArgb(200, 200, 200)
        lblVersion.Font = New Font("Segoe UI", 9)
        statusBar.Items.Add(lblVersion)
        
        ' Horloge (timer)
        Dim timer As New Timer()
        timer.Interval = 1000
        AddHandler timer.Tick, Sub()
                                  lblDate.Text = DateTime.Now.ToString("dddd dd MMMM yyyy - HH:mm:ss")
                               End Sub
        timer.Start()
        
        Me.Controls.Add(statusBar)
    End Sub
    
    Private Sub ShowDashboard()
        ' Créer le panel de contenu s'il n'existe pas
        If contentPanel Is Nothing Then
            contentPanel = New Panel()
            contentPanel.Dock = DockStyle.Fill
            contentPanel.BackColor = Themes.ENSITTheme.FondPrincipal
            contentPanel.Padding = New Padding(20)
            Me.Controls.Add(contentPanel)
        End If
        
        ' Vider le contenu
        contentPanel.Controls.Clear()
        
        ' Afficher le dashboard
        Dim dashboard As New DashboardForm()
        dashboard.TopLevel = False
        dashboard.FormBorderStyle = FormBorderStyle.None
        dashboard.Dock = DockStyle.Fill
        contentPanel.Controls.Add(dashboard)
        dashboard.Show()
    End Sub
    
    Private Sub LogoPanel_Paint(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        
        ' Dessiner un cercle doré
        Dim rect As New Rectangle(5, 5, 50, 50)
        Using brush As New SolidBrush(Themes.ENSITTheme.CouleurOr)
            g.FillEllipse(brush, rect)
        End Using
        
        ' Dessiner le texte ENSIT
        Using brush As New SolidBrush(Themes.ENSITTheme.BleuMarine)
            Using font As New Font("Segoe UI", 10, FontStyle.Bold)
                g.DrawString("E", font, brush, 18, 12)
                g.DrawString("N", font, brush, 18, 24)
            End Using
        End Using
    End Sub
    
    ' Événements des boutons
    Private Sub btnDashboard_Click(sender As Object, e As EventArgs)
        ShowDashboard()
    End Sub
    
    Private Sub btnEtudiants_Click(sender As Object, e As EventArgs)
        ShowForm(New EtudiantForm())
    End Sub
    
    Private Sub btnFilieres_Click(sender As Object, e As EventArgs)
        ShowForm(New FiliereForm())
    End Sub
    
    Private Sub btnReinscriptions_Click(sender As Object, e As EventArgs)
        ShowForm(New ReinscriptionForm())
    End Sub
    
    Private Sub btnPaiements_Click(sender As Object, e As EventArgs)
        ShowForm(New PaiementForm())
    End Sub
    
    Private Sub btnRapports_Click(sender As Object, e As EventArgs)
        ShowForm(New RapportForm())
    End Sub
    
    Private Sub btnGestionUtilisateurs_Click(sender As Object, e As EventArgs)
        ShowForm(New UtilisateurForm())
    End Sub
    
    Private Sub btnJournal_Click(sender As Object, e As EventArgs)
        ShowForm(New JournalForm())
    End Sub
    
    Private Sub btnDeconnexion_Click(sender As Object, e As EventArgs)
        If Helpers.MessageHelper.Confirm("Voulez-vous vraiment vous déconnecter?") Then
            UtilisateurConnecte.Deconnexion()
            Dim loginForm As New LoginForm()
            Me.Hide()
            loginForm.ShowDialog()
            Me.Close()
        End If
    End Sub
    
    Private Sub ShowForm(frm As Form)
        ' Vider le contenu précédent
        contentPanel.Controls.Clear()
        
        ' Afficher le formulaire
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        contentPanel.Controls.Add(frm)
        frm.Show()
    End Sub
End Class
