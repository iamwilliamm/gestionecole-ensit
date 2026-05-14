Namespace Models
    ''' <summary>
    ''' Modèle pour les statistiques du tableau de bord
    ''' </summary>
    Public Class DashboardStats
        Public Property TotalEtudiants As Integer
        Public Property TotalInscriptionsAnnee As Integer
        Public Property TotalPaiementsComplets As Integer
        Public Property TotalPaiementsPartiels As Integer
        Public Property TotalImpayes As Integer
        Public Property MontantTotalRecu As Decimal
        Public Property MontantTotalEnAttente As Decimal
        Public Property NouveauxEtudiantsMois As Integer
        Public Property EtudiantsParFiliere As Dictionary(Of String, Integer)
        Public Property PaiementsParMois As Dictionary(Of String, Decimal)
        
        Public Sub New()
            EtudiantsParFiliere = New Dictionary(Of String, Integer)
            PaiementsParMois = New Dictionary(Of String, Decimal)
        End Sub
    End Class
    
    ''' <summary>
    ''' Modèle pour les configurations de l'application
    ''' </summary>
    Public Class Configuration
        Public Shared Property FraisInscription As Decimal = 50000
        Public Shared Property FraisScolariteNiveau1 As Decimal = 150000
        Public Shared Property FraisScolariteNiveau2 As Decimal = 150000
        Public Shared Property FraisScolariteNiveau3 As Decimal = 150000
        Public Shared Property FraisScolariteNiveau4 As Decimal = 200000
        Public Shared Property FraisScolariteNiveau5 As Decimal = 200000
        Public Shared Property FraisMateriel As Decimal = 25000
        Public Shared Property FraisExamen As Decimal = 15000
        
        ''' <summary>
        ''' Retourne les frais de scolarité selon le niveau
        ''' </summary>
        Public Shared Function GetFraisScolarite(niveau As Integer) As Decimal
            Select Case niveau
                Case 1
                    Return FraisScolariteNiveau1
                Case 2
                    Return FraisScolariteNiveau2
                Case 3
                    Return FraisScolariteNiveau3
                Case 4
                    Return FraisScolariteNiveau4
                Case 5
                    Return FraisScolariteNiveau5
                Case Else
                    Return 0
            End Select
        End Function
        
        ''' <summary>
        ''' Calcule le total des frais pour une inscription
        ''' </summary>
        Public Shared Function CalculerTotalFrais(niveau As Integer, Optional avecMateriel As Boolean = False, 
                                                   Optional avecExamen As Boolean = False) As Decimal
            Dim total As Decimal = FraisInscription + GetFraisScolarite(niveau)
            
            If avecMateriel Then
                total += FraisMateriel
            End If
            
            If avecExamen Then
                total += FraisExamen
            End If
            
            Return total
        End Function
    End Class
    
    ''' <summary>
    ''' Modèle pour un étudiant avec ses informations complètes
    ''' </summary>
    Public Class EtudiantModel
        Public Property Id As Integer
        Public Property NumeroInscription As String
        Public Property Nom As String
        Public Property Prenom As String
        Public ReadOnly Property NomComplet As String
            Get
                Return $"{Nom} {Prenom}"
            End Get
        End Property
        Public Property DateNaissance As Date
        Public Property LieuNaissance As String
        Public Property Sexe As String
        Public Property Email As String
        Public Property Telephone As String
        Public Property Adresse As String
        Public Property Photo As String
        Public Property IdFiliere As Integer
        Public Property NomFiliere As String
        Public Property DateInscription As Date
        Public Property NiveauActuel As Integer
        Public Property AnneeScolaire As String
        Public Property StatutPaiement As String
        
        ''' <summary>
        ''' Retourne l'âge de l'étudiant
        ''' </summary>
        Public ReadOnly Property Age As Integer
            Get
                Dim calculatedAge As Integer = DateTime.Now.Year - DateNaissance.Year
                If DateTime.Now.DayOfYear < DateNaissance.DayOfYear Then
                    calculatedAge -= 1
                End If
                Return calculatedAge
            End Get
        End Property
    End Class
    
    ''' <summary>
    ''' Modèle pour un paiement avec les informations de l'étudiant
    ''' </summary>
    Public Class PaiementModel
        Public Property Id As Integer
        Public Property IdEtudiant As Integer
        Public Property IdReinscription As Integer
        Public Property NomEtudiant As String
        Public Property PrenomEtudiant As String
        Public Property NumeroInscription As String
        Public Property Montant As Decimal
        Public Property DatePaiement As Date
        Public Property TypeFrais As String
        Public Property ModePaiement As String
        Public Property Reference As String
        Public Property Statut As String
        Public Property Observations As String
        Public Property NomFiliere As String
        
        Public ReadOnly Property NomCompletEtudiant As String
            Get
                Return $"{NomEtudiant} {PrenomEtudiant}"
            End Get
        End Property
    End Class
End Namespace
