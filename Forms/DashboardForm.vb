Imports System.Windows.Forms.DataVisualization.Charting

Public Class DashboardForm
    Inherits System.Windows.Forms.Form
    
    Private components As System.ComponentModel.IContainer
    
    Private Sub DashboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Configuration du formulaire
        Me.Text = "Tableau de Bord - ENSIT"
        Me.WindowState = FormWindowState.Maximized
        Me.BackColor = Themes.ENSITTheme.FondPrincipal
        
        ' Charger les données
        LoadDashboard()
    End Sub
    
    Private Sub LoadDashboard()
        ' Obtenir les statistiques
        Dim stats As New Dictionary(Of String, Object)
        
        ' Nombre total d'étudiants
        Dim dtEtudiants As DataTable = DAL.EtudiantDAL.GetAll()
        stats("total_etudiants") = dtEtudiants.Rows.Count
        
        ' Paiements par statut
        Dim dtPaiements As DataTable = DAL.PaiementDAL.GetAll()
        Dim totalComplets As Integer = 0
        Dim totalPartiels As Integer = 0
        Dim totalEnAttente As Integer = 0
        Dim montantTotal As Decimal = 0
        Dim montantEnAttente As Decimal = 0
        
        For Each row As DataRow In dtPaiements.Rows
            Dim montant As Decimal = Convert.ToDecimal(row("montant"))
            Select Case row("statut").ToString()
                Case "complet"
                    totalComplets += 1
                    montantTotal += montant
                Case "partiel"
                    totalPartiels += 1
                    montantTotal += montant
                Case "en_attente"
                    totalEnAttente += 1
                    montantEnAttente += montant
            End Select
        Next
        
        stats("paiements_complets") = totalComplets
        stats("paiements_partiels") = totalPartiels
        stats("paiements_attente") = totalEnAttente
        stats("montant_total") = montantTotal
        stats("montant_attente") = montantEnAttente
        
        ' Étudiants par filière
        Dim etudiantsParFiliere As New Dictionary(Of String, Integer)
        For Each row As DataRow In dtEtudiants.Rows
            Dim filiere As String = If(row("nom_filiere") IsNot DBNull.Value, row("nom_filiere").ToString(), "Non assigné")
            If etudiantsParFiliere.ContainsKey(filiere) Then
                etudiantsParFiliere(filiere) += 1
            Else
                etudiantsParFiliere(filiere) = 1
            End If
        Next
        stats("etudiants_par_filiere") = etudiantsParFiliere
        
        ' Afficher le dashboard
        InitializeDashboard(stats)
    End Sub
    
    Private Sub InitializeDashboard(stats As Dictionary(Of String, Object))
        ' Panel principal
        Dim mainPanel As New Panel()
        mainPanel.Dock = DockStyle.Fill
        mainPanel.AutoScroll = True
        mainPanel.BackColor = Themes.ENSITTheme.FondPrincipal
        mainPanel.Padding = New Padding(20)
        
        ' Titre
        Dim lblTitre As New Label()
        lblTitre.Text = "TABLEAU DE BORD"
        lblTitre.Font = New Font("Segoe UI", 24, FontStyle.Bold)
        lblTitre.ForeColor = Themes.ENSITTheme.BleuMarine
        lblTitre.AutoSize = True
        lblTitre.Location = New Point(20, 20)
        mainPanel.Controls.Add(lblTitre)
        
        ' Date et heure
        Dim lblDate As New Label()
        lblDate.Text = DateTime.Now.ToString("dddd dd MMMM yyyy - HH:mm")
        lblDate.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        lblDate.ForeColor = Color.Gray
        lblDate.AutoSize = True
        lblDate.Location = New Point(20, 60)
        mainPanel.Controls.Add(lblDate)
        
        ' Panel des KPI (Key Performance Indicators)
        Dim kpiPanel As New Panel()
        kpiPanel.Location = New Point(20, 100)
        kpiPanel.Size = New Size(1200, 150)
        kpiPanel.BackColor = Color.Transparent
        
        ' KPI 1: Total Étudiants
        CreateKPICard(kpiPanel, "TOTAL ÉTUDIANTS", stats("total_etudiants").ToString(), 
                     "👥", Themes.ENSITTheme.BleuMarine, 0)
        
        ' KPI 2: Paiements Complets
        CreateKPICard(kpiPanel, "PAIEMENTS COMPLÈTS", stats("paiements_complets").ToString(), 
                     "✓", Themes.ENSITTheme.Succes, 240)
        
        ' KPI 3: Paiements Partiels
        CreateKPICard(kpiPanel, "PAIEMENTS PARTIELS", stats("paiements_partiels").ToString(), 
                     "◐", Themes.ENSITTheme.Avertissement, 480)
        
        ' KPI 4: Paiements en Attente
        CreateKPICard(kpiPanel, "PAIEMENTS EN ATTENTE", stats("paiements_attente").ToString(), 
                     "⚠", Themes.ENSITTheme.Danger, 720)
        
        ' KPI 5: Montant Total
        Dim montantTotal As Decimal = Convert.ToDecimal(stats("montant_total"))
        CreateKPICard(kpiPanel, "MONTANT TOTAL REÇU", montantTotal.ToString("N0") & " FCFA", 
                     "💰", Themes.ENSITTheme.CouleurOr, 960)
        
        mainPanel.Controls.Add(kpiPanel)
        
        ' Panel des graphiques
        Dim chartsPanel As New Panel()
        chartsPanel.Location = New Point(20, 270)
        chartsPanel.Size = New Size(1200, 400)
        chartsPanel.BackColor = Color.Transparent
        
        ' Graphique 1: Étudiants par filière
        CreateBarChart(chartsPanel, "Répartition des étudiants par filière", 
                      CType(stats("etudiants_par_filiere"), Dictionary(Of String, Integer)), 0, 0)
        
        ' Graphique 2: Paiements par statut
        Dim paiementsData As New Dictionary(Of String, Integer)
        paiementsData("Complèts") = Convert.ToInt32(stats("paiements_complets"))
        paiementsData("Partiels") = Convert.ToInt32(stats("paiements_partiels"))
        paiementsData("En attente") = Convert.ToInt32(stats("paiements_attente"))
        CreatePieChart(chartsPanel, "Statut des paiements", paiementsData, 600, 0)
        
        mainPanel.Controls.Add(chartsPanel)
        
        ' Panel d'actions rapides
        Dim actionPanel As New Panel()
        actionPanel.Location = New Point(20, 690)
        actionPanel.Size = New Size(1200, 100)
        actionPanel.BackColor = Color.White
        actionPanel.BorderStyle = BorderStyle.FixedSingle
        
        Dim lblAction As New Label()
        lblAction.Text = "ACTIONS RAPIDES"
        lblAction.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblAction.ForeColor = Themes.ENSITTheme.BleuMarine
        lblAction.Location = New Point(20, 15)
        lblAction.AutoSize = True
        actionPanel.Controls.Add(lblAction)
        
        ' Bouton ajouter étudiant
        Dim btnAddEtudiant As New Button()
        btnAddEtudiant.Text = "+ Nouvel étudiant"
        btnAddEtudiant.Location = New Point(20, 50)
        btnAddEtudiant.Size = New Size(150, 35)
        Themes.ENSITTheme.ApplyPrimaryButtonStyle(btnAddEtudiant)
        AddHandler btnAddEtudiant.Click, Sub()
                                            Dim frm As New EtudiantForm()
                                            frm.MdiParent = Me.MdiParent
                                            frm.Show()
                                         End Sub
        actionPanel.Controls.Add(btnAddEtudiant)
        
        ' Bouton enregistrer paiement
        Dim btnAddPaiement As New Button()
        btnAddPaiement.Text = "+ Nouveau paiement"
        btnAddPaiement.Location = New Point(190, 50)
        btnAddPaiement.Size = New Size(150, 35)
        Themes.ENSITTheme.ApplySecondaryButtonStyle(btnAddPaiement)
        AddHandler btnAddPaiement.Click, Sub()
                                            Dim frm As New PaiementForm()
                                            frm.MdiParent = Me.MdiParent
                                            frm.Show()
                                         End Sub
        actionPanel.Controls.Add(btnAddPaiement)
        
        ' Bouton voir impayés
        Dim btnImpayes As New Button()
        btnImpayes.Text = "⚠ Voir les impayés"
        btnImpayes.Location = New Point(360, 50)
        btnImpayes.Size = New Size(150, 35)
        btnImpayes.BackColor = Themes.ENSITTheme.Danger
        btnImpayes.ForeColor = Color.White
        btnImpayes.FlatStyle = FlatStyle.Flat
        btnImpayes.FlatAppearance.BorderSize = 0
        btnImpayes.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnImpayes.Cursor = Cursors.Hand
        AddHandler btnImpayes.Click, Sub()
                                        Dim frm As New RapportForm()
                                        frm.MdiParent = Me.MdiParent
                                        frm.Show()
                                     End Sub
        actionPanel.Controls.Add(btnImpayes)
        
        mainPanel.Controls.Add(actionPanel)
        
        Me.Controls.Add(mainPanel)
    End Sub
    
    Private Sub CreateKPICard(parent As Panel, titre As String, valeur As String, icone As String, 
                            couleur As Color, positionX As Integer)
        Dim card As New Panel()
        card.Size = New Size(220, 130)
        card.Location = New Point(positionX, 10)
        card.BackColor = Color.White
        card.BorderStyle = BorderStyle.None
        
        ' Ombre
        AddHandler card.Paint, Sub(sender, e)
                          Using brush As New SolidBrush(Color.FromArgb(20, 0, 0, 0))
                              e.Graphics.FillRectangle(brush, 5, 5, card.Width, card.Height)
                          End Using
                      End Sub
        
        ' Icône
        Dim lblIcone As New Label()
        lblIcone.Text = icone
        lblIcone.Font = New Font("Segoe UI", 30)
        lblIcone.ForeColor = couleur
        lblIcone.Location = New Point(15, 15)
        lblIcone.AutoSize = True
        card.Controls.Add(lblIcone)
        
        ' Valeur
        Dim lblValeur As New Label()
        lblValeur.Text = valeur
        lblValeur.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblValeur.ForeColor = couleur
        lblValeur.Location = New Point(15, 55)
        lblValeur.Size = New Size(190, 40)
        card.Controls.Add(lblValeur)
        
        ' Titre
        Dim lblTitre As New Label()
        lblTitre.Text = titre
        lblTitre.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblTitre.ForeColor = Color.Gray
        lblTitre.Location = New Point(15, 95)
        lblTitre.Size = New Size(190, 25)
        card.Controls.Add(lblTitre)
        
        parent.Controls.Add(card)
    End Sub
    
    Private Sub CreateBarChart(parent As Panel, titre As String, data As Dictionary(Of String, Integer), 
                              posX As Integer, posY As Integer)
        Dim chart As New Chart()
        chart.Size = New Size(550, 350)
        chart.Location = New Point(posX, posY)
        chart.BackColor = Color.White
        
        ' Titre
        Dim chartTitle As New Title()
        chartTitle.Text = titre
        chartTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        chartTitle.ForeColor = Themes.ENSITTheme.BleuMarine
        chart.Titles.Add(chartTitle)
        
        ' Zone de graphique
        Dim chartArea As New ChartArea()
        chartArea.Name = "MainArea"
        chartArea.AxisX.Title = "Filières"
        chartArea.AxisY.Title = "Nombre d'étudiants"
        chartArea.AxisX.Interval = 1
        chart.ChartAreas.Add(chartArea)
        
        ' Série de données
        Dim series As New Series()
        series.Name = "Etudiants"
        series.ChartType = SeriesChartType.Column
        series.Color = Themes.ENSITTheme.BleuMarine
        
        For Each kvp As KeyValuePair(Of String, Integer) In data
            series.Points.AddXY(kvp.Key, kvp.Value)
        Next
        
        chart.Series.Add(series)
        
        ' Légende
        Dim legend As New Legend()
        legend.Name = "Legend"
        chart.Legends.Add(legend)
        
        parent.Controls.Add(chart)
    End Sub
    
    Private Sub CreatePieChart(parent As Panel, titre As String, data As Dictionary(Of String, Integer), 
                              posX As Integer, posY As Integer)
        Dim chart As New Chart()
        chart.Size = New Size(550, 350)
        chart.Location = New Point(posX, posY)
        chart.BackColor = Color.White
        
        ' Titre
        Dim chartTitle As New Title()
        chartTitle.Text = titre
        chartTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        chartTitle.ForeColor = Themes.ENSITTheme.BleuMarine
        chart.Titles.Add(chartTitle)
        
        ' Zone de graphique
        Dim chartArea As New ChartArea()
        chartArea.Name = "MainArea"
        chart.ChartAreas.Add(chartArea)
        
        ' Série de données
        Dim series As New Series()
        series.Name = "Paiements"
        series.ChartType = SeriesChartType.Pie
        
        ' Couleurs
        Dim colors As Color() = {Themes.ENSITTheme.Succes, Themes.ENSITTheme.Avertissement, Themes.ENSITTheme.Danger}
        Dim i As Integer = 0
        
        For Each kvp As KeyValuePair(Of String, Integer) In data
            series.Points.AddXY(kvp.Key, kvp.Value)
            Dim point As DataPoint = series.Points(series.Points.Count - 1)
            point.Color = colors(i Mod colors.Length)
            point.Label = $"{kvp.Key}: {kvp.Value}"
            i += 1
        Next
        
        chart.Series.Add(series)
        
        ' Légende
        Dim legend As New Legend()
        legend.Name = "Legend"
        legend.Docking = Docking.Bottom
        chart.Legends.Add(legend)
        
        parent.Controls.Add(chart)
    End Sub
End Class
