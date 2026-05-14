Imports System.Drawing.Drawing2D

Public Class LoginForm
    Inherits System.Windows.Forms.Form
    
    ' Contrôles déclarés une seule fois
    Private txtLogin As TextBox
    Private txtPassword As TextBox
    Private btnConnexion As Button
    Private btnQuitter As Button
    
    Public Sub New()
        ' Appeler InitializeComponent
        InitializeComponent()
    End Sub
    
    Private Sub InitializeComponent()
        ' Configuration du formulaire
        Me.Text = "ENSIT - Connexion"
        Me.Size = New Size(500, 600)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.BackColor = Color.FromArgb(245, 245, 250)
        
        ' Panel principal
        Dim mainPanel As New Panel()
        mainPanel.Size = New Size(420, 520)
        mainPanel.Location = New Point(40, 30)
        mainPanel.BackColor = Color.White
        
        ' Ombre
        Dim shadowPanel As New Panel()
        shadowPanel.Size = New Size(430, 530)
        shadowPanel.Location = New Point(45, 35)
        shadowPanel.BackColor = Color.FromArgb(30, 0, 0, 0)
        Me.Controls.Add(shadowPanel)
        
        ' Logo
        Dim logoPanel As New Panel()
        logoPanel.Size = New Size(100, 100)
        logoPanel.Location = New Point(160, 20)
        logoPanel.BackColor = Color.FromArgb(0, 51, 102)
        AddHandler logoPanel.Paint, AddressOf LogoPanel_Paint
        mainPanel.Controls.Add(logoPanel)
        
        ' Titre ENSIT
        Dim lblTitre As New Label()
        lblTitre.Text = "ENSIT"
        lblTitre.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblTitre.ForeColor = Color.FromArgb(0, 51, 102)
        lblTitre.AutoSize = True
        lblTitre.Location = New Point(170, 130)
        mainPanel.Controls.Add(lblTitre)
        
        ' Sous-titre
        Dim lblSousTitre As New Label()
        lblSousTitre.Text = "École Nouvelle Supérieure d'Ingénieurs" & vbCrLf & "Système de Gestion des Inscriptions"
        lblSousTitre.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblSousTitre.ForeColor = Color.Gray
        lblSousTitre.TextAlign = ContentAlignment.MiddleCenter
        lblSousTitre.Size = New Size(380, 40)
        lblSousTitre.Location = New Point(20, 170)
        mainPanel.Controls.Add(lblSousTitre)
        
        ' Label Login
        Dim lblUser As New Label()
        lblUser.Text = "Nom d'utilisateur"
        lblUser.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblUser.ForeColor = Color.FromArgb(33, 37, 41)
        lblUser.Location = New Point(40, 230)
        lblUser.AutoSize = True
        mainPanel.Controls.Add(lblUser)
        
        ' TextBox Login
        txtLogin = New TextBox()
        txtLogin.Location = New Point(40, 255)
        txtLogin.Size = New Size(340, 30)
        txtLogin.Font = New Font("Segoe UI", 11)
        txtLogin.BorderStyle = BorderStyle.FixedSingle
        mainPanel.Controls.Add(txtLogin)
        
        ' Label Password
        Dim lblPass As New Label()
        lblPass.Text = "Mot de passe"
        lblPass.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblPass.ForeColor = Color.FromArgb(33, 37, 41)
        lblPass.Location = New Point(40, 300)
        lblPass.AutoSize = True
        mainPanel.Controls.Add(lblPass)
        
        ' TextBox Password
        txtPassword = New TextBox()
        txtPassword.Location = New Point(40, 325)
        txtPassword.Size = New Size(340, 30)
        txtPassword.Font = New Font("Segoe UI", 11)
        txtPassword.BorderStyle = BorderStyle.FixedSingle
        txtPassword.PasswordChar = "*"c
        mainPanel.Controls.Add(txtPassword)
        
        ' Bouton Connexion
        btnConnexion = New Button()
        btnConnexion.Text = "SE CONNECTER"
        btnConnexion.Location = New Point(40, 390)
        btnConnexion.Size = New Size(340, 45)
        btnConnexion.BackColor = Color.FromArgb(0, 51, 102)
        btnConnexion.ForeColor = Color.White
        btnConnexion.FlatStyle = FlatStyle.Flat
        btnConnexion.FlatAppearance.BorderSize = 0
        btnConnexion.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnConnexion.Cursor = Cursors.Hand
        AddHandler btnConnexion.Click, AddressOf btnConnexion_Click
        mainPanel.Controls.Add(btnConnexion)
        
        ' Bouton Quitter
        btnQuitter = New Button()
        btnQuitter.Text = "QUITTER"
        btnQuitter.Location = New Point(40, 445)
        btnQuitter.Size = New Size(340, 35)
        btnQuitter.BackColor = Color.LightGray
        btnQuitter.ForeColor = Color.DarkGray
        btnQuitter.FlatStyle = FlatStyle.Flat
        btnQuitter.FlatAppearance.BorderSize = 0
        btnQuitter.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        AddHandler btnQuitter.Click, AddressOf btnQuitter_Click
        mainPanel.Controls.Add(btnQuitter)
        
        ' Version
        Dim lblVersion As New Label()
        lblVersion.Text = "Version 1.0 - © 2025 ENSIT"
        lblVersion.Font = New Font("Segoe UI", 8, FontStyle.Regular)
        lblVersion.ForeColor = Color.LightGray
        lblVersion.Location = New Point(140, 495)
        lblVersion.AutoSize = True
        mainPanel.Controls.Add(lblVersion)
        
        Me.Controls.Add(mainPanel)
        shadowPanel.SendToBack()
    End Sub
    
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Connexion.InitialiserBaseDeDonnees()
        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'initialisation: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub LogoPanel_Paint(sender As Object, e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.AntiAlias
        
        Dim rect As New Rectangle(5, 5, 90, 90)
        Using brush As New SolidBrush(Color.FromArgb(0, 51, 102))
            g.FillEllipse(brush, rect)
        End Using
        
        Using pen As New Pen(Color.FromArgb(218, 165, 32), 3)
            g.DrawEllipse(pen, rect)
        End Using
        
        Using brush As New SolidBrush(Color.White)
            Using font As New Font("Segoe UI", 14, FontStyle.Bold)
                Dim textSize As SizeF = g.MeasureString("ENS", font)
                g.DrawString("ENS", font, brush, (100 - textSize.Width) / 2, 25)
                textSize = g.MeasureString("IT", font)
                g.DrawString("IT", font, brush, (100 - textSize.Width) / 2, 48)
            End Using
        End Using
    End Sub
    
    Private Sub btnConnexion_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrWhiteSpace(txtLogin.Text) Then
                MessageBox.Show("Veuillez saisir votre nom d'utilisateur", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtLogin.Focus()
                Return
            End If
            
            If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                MessageBox.Show("Veuillez saisir votre mot de passe", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtPassword.Focus()
                Return
            End If
            
            ' Hasher le mot de passe
            Dim hashedPassword As String = Helpers.SecurityHelper.HashPassword(txtPassword.Text)
            
            ' Vérifier les identifiants
            Dim dt As DataTable = DAL.UtilisateurDAL.Authentifier(txtLogin.Text, hashedPassword)
            
            If dt.Rows.Count > 0 Then
                UtilisateurConnecte.Id = Convert.ToInt32(dt.Rows(0)("id_utilisateur"))
                UtilisateurConnecte.Login = dt.Rows(0)("login").ToString()
                UtilisateurConnecte.Role = dt.Rows(0)("role").ToString()
                UtilisateurConnecte.NomComplet = dt.Rows(0)("nom_complet").ToString()
                
                DAL.JournalDAL.EnregistrerAction(UtilisateurConnecte.Id, "CONNEXION", "Connexion réussie")
                
                MessageBox.Show($"Bienvenue {UtilisateurConnecte.NomComplet}!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                
                Dim mainForm As New MainForm()
                mainForm.Show()
                Me.Hide()
            Else
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Clear()
                txtPassword.Focus()
            End If
            
        Catch ex As Exception
            MessageBox.Show($"Erreur de connexion: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    
    Private Sub btnQuitter_Click(sender As Object, e As EventArgs)
        If MessageBox.Show("Voulez-vous vraiment quitter l'application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
