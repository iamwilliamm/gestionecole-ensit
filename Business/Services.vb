Imports System.Text.RegularExpressions

Namespace Business
    ''' <summary>
    ''' Couche métier pour la gestion des étudiants
    ''' </summary>
    Public Class EtudiantService
        
        ''' <summary>
        ''' Valide les données d'un étudiant avant enregistrement
        ''' </summary>
        Public Shared Function ValiderEtudiant(nom As String, prenom As String, email As String, 
                                              telephone As String, dateNaissance As Date) As List(Of String)
            Dim erreurs As New List(Of String)
            
            ' Validation du nom
            If String.IsNullOrWhiteSpace(nom) OrElse nom.Length < 2 Then
                erreurs.Add("Le nom doit contenir au moins 2 caractères")
            End If
            
            ' Validation du prénom
            If String.IsNullOrWhiteSpace(prenom) OrElse prenom.Length < 2 Then
                erreurs.Add("Le prénom doit contenir au moins 2 caractères")
            End If
            
            ' Validation de l'email
            If Not String.IsNullOrWhiteSpace(email) Then
                Dim emailPattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
                If Not Regex.IsMatch(email, emailPattern) Then
                    erreurs.Add("L'adresse email n'est pas valide")
                End If
            End If
            
            ' Validation du téléphone
            If Not String.IsNullOrWhiteSpace(telephone) Then
                Dim telPattern As String = "^[0-9\s\-\+\(\)]{8,20}$"
                If Not Regex.IsMatch(telephone, telPattern) Then
                    erreurs.Add("Le numéro de téléphone n'est pas valide")
                End If
            End If
            
            ' Validation de la date de naissance
            If dateNaissance > DateTime.Now Then
                erreurs.Add("La date de naissance ne peut pas être dans le futur")
            ElseIf DateTime.Now.Year - dateNaissance.Year < 15 Then
                erreurs.Add("L'étudiant doit avoir au moins 15 ans")
            End If
            
            Return erreurs
        End Function
        
        ''' <summary>
        ''' Vérifie si un étudiant a des paiements en attente
        ''' </summary>
        Public Shared Function ADesPaiementsEnAttente(idEtudiant As Integer) As Boolean
            Dim dt As DataTable = DAL.PaiementDAL.GetByEtudiant(idEtudiant)
            For Each row As DataRow In dt.Rows
                If row("statut").ToString() = "en_attente" Then
                    Return True
                End If
            Next
            Return False
        End Function
        
        ''' <summary>
        ''' Calcule le solde financier d'un étudiant
        ''' </summary>
        Public Shared Function CalculerSolde(idEtudiant As Integer, fraisTotal As Decimal) As Decimal
            Dim dt As DataTable = DAL.PaiementDAL.GetByEtudiant(idEtudiant)
            Dim totalPaye As Decimal = 0
            
            For Each row As DataRow In dt.Rows
                If row("statut").ToString() <> "en_attente" Then
                    totalPaye += Convert.ToDecimal(row("montant"))
                End If
            Next
            
            Return fraisTotal - totalPaye
        End Function
        
        ''' <summary>
        ''' Vérifie si un étudiant peut passer au niveau supérieur
        ''' </summary>
        Public Shared Function PeutPasserNiveauSup(idEtudiant As Integer) As Boolean
            Dim dernierNiveau As Integer = DAL.ReinscriptionDAL.GetDerniereNiveau(idEtudiant)
            
            ' Vérifier si l'étudiant n'est pas déjà au niveau maximum
            If dernierNiveau >= 5 Then
                Return False
            End If
            
            ' Vérifier les paiements
            Return Not ADesPaiementsEnAttente(idEtudiant)
        End Function
        
        ''' <summary>
        ''' Retourne les statistiques d'un étudiant
        ''' </summary>
        Public Shared Function GetStatistiques(idEtudiant As Integer) As Dictionary(Of String, Object)
            Dim stats As New Dictionary(Of String, Object)
            
            ' Nombre de réinscriptions
            Dim dtReinsc As DataTable = DAL.ReinscriptionDAL.GetByEtudiant(idEtudiant)
            stats("nombre_reinscriptions") = dtReinsc.Rows.Count
            
            ' Dernier niveau
            stats("niveau_actuel") = DAL.ReinscriptionDAL.GetDerniereNiveau(idEtudiant)
            
            ' Nombre de paiements
            Dim dtPaiement As DataTable = DAL.PaiementDAL.GetByEtudiant(idEtudiant)
            stats("nombre_paiements") = dtPaiement.Rows.Count
            
            ' Total payé
            Dim totalPaye As Decimal = 0
            For Each row As DataRow In dtPaiement.Rows
                If row("statut").ToString() <> "en_attente" Then
                    totalPaye += Convert.ToDecimal(row("montant"))
                End If
            Next
            stats("total_paye") = totalPaye
            
            ' Années scolaires
            Dim annees As New List(Of String)
            For Each row As DataRow In dtReinsc.Rows
                annees.Add(row("annee_scolaire").ToString())
            Next
            stats("annees_scolaires") = annees
            
            Return stats
        End Function
    End Class
    
    ''' <summary>
    ''' Couche métier pour la gestion des paiements
    ''' </summary>
    Public Class PaiementService
        
        ''' <summary>
        ''' Détermine le statut d'un paiement selon le montant payé
        ''' </summary>
        Public Shared Function DeterminerStatut(montantPaye As Decimal, montantAttendu As Decimal) As String
            If montantPaye >= montantAttendu Then
                Return "complet"
            ElseIf montantPaye > 0 Then
                Return "partiel"
            Else
                Return "en_attente"
            End If
        End Function
        
        ''' <summary>
        ''' Calcule les statistiques financières globales
        ''' </summary>
        Public Shared Function GetStatistiquesFinancieres() As Dictionary(Of String, Decimal)
            Dim stats As New Dictionary(Of String, Decimal)
            
            Dim dt As DataTable = DAL.PaiementDAL.GetAll()
            Dim totalRecu As Decimal = 0
            Dim totalPartiel As Decimal = 0
            Dim totalEnAttente As Decimal = 0
            
            For Each row As DataRow In dt.Rows
                Dim montant As Decimal = Convert.ToDecimal(row("montant"))
                Select Case row("statut").ToString()
                    Case "complet"
                        totalRecu += montant
                    Case "partiel"
                        totalPartiel += montant
                    Case "en_attente"
                        totalEnAttente += montant
                End Select
            Next
            
            stats("total_recu") = totalRecu
            stats("total_partiel") = totalPartiel
            stats("total_en_attente") = totalEnAttente
            stats("total_global") = totalRecu + totalPartiel
            
            Return stats
        End Function
        
        ''' <summary>
        ''' Retourne le nombre d'étudiants impayés par filière
        ''' </summary>
        Public Shared Function GetImpayesParFiliere() As Dictionary(Of String, Integer)
            Dim result As New Dictionary(Of String, Integer)
            Dim dt As DataTable = DAL.PaiementDAL.GetImpayes()
            
            For Each row As DataRow In dt.Rows
                Dim filiere As String = row("filiere").ToString()
                If result.ContainsKey(filiere) Then
                    result(filiere) += 1
                Else
                    result(filiere) = 1
                End If
            Next
            
            Return result
        End Function
    End Class
    
    ''' <summary>
    ''' Couche métier pour la gestion des utilisateurs
    ''' </summary>
    Public Class UtilisateurService
        
        ''' <summary>
        ''' Change le mot de passe d'un utilisateur avec vérification de l'ancien
        ''' </summary>
        Public Shared Function ChangerMotDePasse(idUtilisateur As Integer, 
                                                  ancienMotDePasse As String, 
                                                  nouveauMotDePasse As String) As Boolean
            ' Vérifier l'ancien mot de passe
            Dim dt As DataTable = DAL.UtilisateurDAL.Authentifier(
                UtilisateurConnecte.Login, 
                ancienMotDePasse)
            
            If dt.Rows.Count = 0 Then
                Return False
            End If
            
            ' Valider le nouveau mot de passe
            If nouveauMotDePasse.Length < 6 Then
                Throw New Exception("Le nouveau mot de passe doit contenir au moins 6 caractères")
            End If
            
            ' Hasher et mettre à jour
            Dim hashedPassword As String = Helpers.SecurityHelper.HashPassword(nouveauMotDePasse)
            
            ' Note: Il faudrait ajouter une méthode ModifierMotDePasse dans le DAL
            ' Pour l'instant, on utilise la méthode existante
            Dim user As DataRow = dt.Rows(0)
            DAL.UtilisateurDAL.Modifier(
                idUtilisateur,
                user("login").ToString(),
                hashedPassword,
                user("role").ToString(),
                user("nom_complet").ToString())
            
            Return True
        End Function
    End Class
End Namespace
