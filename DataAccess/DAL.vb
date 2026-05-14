Imports System.Data.OleDb

Public Class DAL

    Public Shared Function ExecuterRequete(sql As String, parametres As OleDbParameter()) As Integer
        Using conn As OleDbConnection = Connexion.GetConnection()
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                If parametres IsNot Nothing Then
                    cmd.Parameters.AddRange(parametres)
                End If
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    Public Shared Function ExecuterRequeteSelect(sql As String, parametres As OleDbParameter()) As DataTable
        Using conn As OleDbConnection = Connexion.GetConnection()
            conn.Open()
            Using cmd As New OleDbCommand(sql, conn)
                If parametres IsNot Nothing Then
                    cmd.Parameters.AddRange(parametres)
                End If
                Using da As New OleDbDataAdapter(cmd)
                    Dim dt As New DataTable()
                    da.Fill(dt)
                    Return dt
                End Using
            End Using
        End Using
    End Function

    Public Shared Function GenererNumeroInscription() As String
        Dim annee As String = DateTime.Now.Year.ToString()
        Dim random As New Random()
        Dim numero As String = $"ETU-{annee}-{random.Next(1000, 9999)}"
        Return numero
    End Function

    Public Class UtilisateurDAL
        Public Shared Function Authentifier(login As String, motDePasse As String) As DataTable
            Dim sql As String = "SELECT * FROM UTILISATEUR WHERE login = ? AND mot_de_passe = ?"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@login", login),
                New OleDbParameter("@mot_de_passe", motDePasse)
            }
            Return ExecuterRequeteSelect(sql, params)
        End Function

        Public Shared Function GetAll() As DataTable
            Return ExecuterRequeteSelect("SELECT * FROM UTILISATEUR", Nothing)
        End Function

        Public Shared Function Ajouter(login As String, motDePasse As String, role As String, nomComplet As String) As Integer
            Dim sql As String = "INSERT INTO UTILISATEUR (login, mot_de_passe, role, nom_complet, date_creation) VALUES (?, ?, ?, ?, ?)"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@login", login),
                New OleDbParameter("@mot_de_passe", motDePasse),
                New OleDbParameter("@role", role),
                New OleDbParameter("@nom_complet", nomComplet),
                New OleDbParameter("@date_creation", DateTime.Now)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Modifier(id As Integer, login As String, motDePasse As String, role As String, nomComplet As String) As Integer
            Dim sql As String = "UPDATE UTILISATEUR SET login = ?, mot_de_passe = ?, role = ?, nom_complet = ? WHERE id_utilisateur = ?"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@login", login),
                New OleDbParameter("@mot_de_passe", motDePasse),
                New OleDbParameter("@role", role),
                New OleDbParameter("@nom_complet", nomComplet),
                New OleDbParameter("@id", id)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Supprimer(id As Integer) As Integer
            Dim sql As String = "DELETE FROM UTILISATEUR WHERE id_utilisateur = ?"
            Dim params As OleDbParameter() = {New OleDbParameter("@id", id)}
            Return ExecuterRequete(sql, params)
        End Function
    End Class

    Public Class FiliereDAL
        Public Shared Function GetAll() As DataTable
            Return ExecuterRequeteSelect("SELECT * FROM FILIERE ORDER BY libelle", Nothing)
        End Function

        Public Shared Function GetById(id As Integer) As DataTable
            Dim sql As String = "SELECT * FROM FILIERE WHERE id_filiere = ?"
            Dim params As OleDbParameter() = {New OleDbParameter("@id", id)}
            Return ExecuterRequeteSelect(sql, params)
        End Function

        Public Shared Function Ajouter(libelle As String, description As String) As Integer
            Dim sql As String = "INSERT INTO FILIERE (libelle, description) VALUES (?, ?)"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@libelle", libelle),
                New OleDbParameter("@description", description)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Modifier(id As Integer, libelle As String, description As String) As Integer
            Dim sql As String = "UPDATE FILIERE SET libelle = ?, description = ? WHERE id_filiere = ?"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@libelle", libelle),
                New OleDbParameter("@description", description),
                New OleDbParameter("@id", id)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Supprimer(id As Integer) As Integer
            Dim sql As String = "DELETE FROM FILIERE WHERE id_filiere = ?"
            Dim params As OleDbParameter() = {New OleDbParameter("@id", id)}
            Return ExecuterRequete(sql, params)
        End Function
    End Class

    Public Class EtudiantDAL
        Public Shared Function GetAll() As DataTable
            Dim sql As String = "SELECT e.*, f.libelle as nom_filiere FROM ETUDIANT e LEFT JOIN FILIERE f ON e.id_filiere = f.id_filiere ORDER BY e.nom, e.prenom"
            Return ExecuterRequeteSelect(sql, Nothing)
        End Function

        Public Shared Function GetById(id As Integer) As DataTable
            Dim sql As String = "SELECT e.*, f.libelle as nom_filiere FROM ETUDIANT e LEFT JOIN FILIERE f ON e.id_filiere = f.id_filiere WHERE e.id_etudiant = ?"
            Dim params As OleDbParameter() = {New OleDbParameter("@id", id)}
            Return ExecuterRequeteSelect(sql, params)
        End Function

        Public Shared Function Rechercher(terme As String, Optional idFiliere As Integer = 0, Optional niveau As Integer = 0) As DataTable
            Dim sql As String = "SELECT e.*, f.libelle as nom_filiere, r.niveau as niveau_actuel FROM ETUDIANT e LEFT JOIN FILIERE f ON e.id_filiere = f.id_filiere LEFT JOIN (SELECT id_etudiant, niveau FROM REINSCRIPTION WHERE id_reinscription IN (SELECT MAX(id_reinscription) FROM REINSCRIPTION GROUP BY id_etudiant)) r ON e.id_etudiant = r.id_etudiant WHERE 1=1"
            Dim params As New List(Of OleDbParameter)()

            If Not String.IsNullOrEmpty(terme) Then
                sql &= " AND (e.nom LIKE ? OR e.prenom LIKE ? OR e.numero_inscription LIKE ?)"
                Dim paramTerm As String = "%" & terme & "%"
                params.Add(New OleDbParameter("@terme1", paramTerm))
                params.Add(New OleDbParameter("@terme2", paramTerm))
                params.Add(New OleDbParameter("@terme3", paramTerm))
            End If

            If idFiliere > 0 Then
                sql &= " AND e.id_filiere = ?"
                params.Add(New OleDbParameter("@id_filiere", idFiliere))
            End If

            If niveau > 0 Then
                sql &= " AND r.niveau = ?"
                params.Add(New OleDbParameter("@niveau", niveau))
            End If

            sql &= " ORDER BY e.nom, e.prenom"
            Return ExecuterRequeteSelect(sql, params.ToArray())
        End Function

        Public Shared Function Ajouter(nom As String, prenom As String, dateNaissance As Date, lieuNaissance As String, 
                                     sexe As String, email As String, telephone As String, adresse As String, 
                                     photo As String, idFiliere As Integer) As Integer
            Dim numeroInscription As String = GenererNumeroInscription()
            Dim sql As String = "INSERT INTO ETUDIANT (nom, prenom, date_naissance, lieu_naissance, sexe, email, telephone, adresse, photo, numero_inscription, id_filiere, date_inscription) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@nom", nom),
                New OleDbParameter("@prenom", prenom),
                New OleDbParameter("@date_naissance", dateNaissance),
                New OleDbParameter("@lieu_naissance", lieuNaissance),
                New OleDbParameter("@sexe", sexe),
                New OleDbParameter("@email", email),
                New OleDbParameter("@telephone", telephone),
                New OleDbParameter("@adresse", adresse),
                New OleDbParameter("@photo", photo),
                New OleDbParameter("@numero_inscription", numeroInscription),
                New OleDbParameter("@id_filiere", idFiliere),
                New OleDbParameter("@date_inscription", DateTime.Now)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Modifier(id As Integer, nom As String, prenom As String, dateNaissance As Date, 
                                      lieuNaissance As String, sexe As String, email As String, telephone As String, 
                                      adresse As String, photo As String, idFiliere As Integer) As Integer
            Dim sql As String = "UPDATE ETUDIANT SET nom = ?, prenom = ?, date_naissance = ?, lieu_naissance = ?, sexe = ?, email = ?, telephone = ?, adresse = ?, photo = ?, id_filiere = ? WHERE id_etudiant = ?"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@nom", nom),
                New OleDbParameter("@prenom", prenom),
                New OleDbParameter("@date_naissance", dateNaissance),
                New OleDbParameter("@lieu_naissance", lieuNaissance),
                New OleDbParameter("@sexe", sexe),
                New OleDbParameter("@email", email),
                New OleDbParameter("@telephone", telephone),
                New OleDbParameter("@adresse", adresse),
                New OleDbParameter("@photo", photo),
                New OleDbParameter("@id_filiere", idFiliere),
                New OleDbParameter("@id", id)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Supprimer(id As Integer) As Integer
            Dim sql As String = "DELETE FROM ETUDIANT WHERE id_etudiant = ?"
            Dim params As OleDbParameter() = {New OleDbParameter("@id", id)}
            Return ExecuterRequete(sql, params)
        End Function
    End Class

    Public Class ReinscriptionDAL
        Public Shared Function GetAll() As DataTable
            Dim sql As String = "SELECT r.*, e.nom, e.prenom, e.numero_inscription FROM REINSCRIPTION r INNER JOIN ETUDIANT e ON r.id_etudiant = e.id_etudiant ORDER BY r.date_reinscription DESC"
            Return ExecuterRequeteSelect(sql, Nothing)
        End Function

        Public Shared Function GetByEtudiant(idEtudiant As Integer) As DataTable
            Dim sql As String = "SELECT r.*, e.nom, e.prenom FROM REINSCRIPTION r INNER JOIN ETUDIANT e ON r.id_etudiant = e.id_etudiant WHERE r.id_etudiant = ? ORDER BY r.annee_scolaire DESC"
            Dim params As OleDbParameter() = {New OleDbParameter("@id_etudiant", idEtudiant)}
            Return ExecuterRequeteSelect(sql, params)
        End Function

        Public Shared Function GetDerniereNiveau(idEtudiant As Integer) As Integer
            Dim sql As String = "SELECT TOP 1 niveau FROM REINSCRIPTION WHERE id_etudiant = ? ORDER BY id_reinscription DESC"
            Dim params As OleDbParameter() = {New OleDbParameter("@id_etudiant", idEtudiant)}
            Dim dt As DataTable = ExecuterRequeteSelect(sql, params)
            If dt.Rows.Count > 0 Then
                Return Convert.ToInt32(dt.Rows(0)("niveau"))
            End If
            Return 0
        End Function

        Public Shared Function Ajouter(idEtudiant As Integer, anneeScolaire As String, niveau As Integer, observations As String) As Integer
            Dim sql As String = "INSERT INTO REINSCRIPTION (id_etudiant, annee_scolaire, niveau, date_reinscription, observations) VALUES (?, ?, ?, ?, ?)"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@id_etudiant", idEtudiant),
                New OleDbParameter("@annee_scolaire", anneeScolaire),
                New OleDbParameter("@niveau", niveau),
                New OleDbParameter("@date_reinscription", DateTime.Now),
                New OleDbParameter("@observations", observations)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Supprimer(id As Integer) As Integer
            Dim sql As String = "DELETE FROM REINSCRIPTION WHERE id_reinscription = ?"
            Dim params As OleDbParameter() = {New OleDbParameter("@id", id)}
            Return ExecuterRequete(sql, params)
        End Function
    End Class

    Public Class PaiementDAL
        Public Shared Function GetAll() As DataTable
            Dim sql As String = "SELECT p.*, e.nom, e.prenom, e.numero_inscription FROM PAIEMENT p INNER JOIN ETUDIANT e ON p.id_etudiant = e.id_etudiant ORDER BY p.date_paiement DESC"
            Return ExecuterRequeteSelect(sql, Nothing)
        End Function

        Public Shared Function GetByEtudiant(idEtudiant As Integer) As DataTable
            Dim sql As String = "SELECT p.*, e.nom, e.prenom FROM PAIEMENT p INNER JOIN ETUDIANT e ON p.id_etudiant = e.id_etudiant WHERE p.id_etudiant = ? ORDER BY p.date_paiement DESC"
            Dim params As OleDbParameter() = {New OleDbParameter("@id_etudiant", idEtudiant)}
            Return ExecuterRequeteSelect(sql, params)
        End Function

        Public Shared Function GetImpayes() As DataTable
            Dim sql As String = "SELECT e.id_etudiant, e.nom, e.prenom, e.numero_inscription, f.libelle as filiere, " &
                               "(SELECT SUM(montant) FROM PAIEMENT WHERE id_etudiant = e.id_etudiant AND statut <> 'en_attente') as total_paye " &
                               "FROM ETUDIANT e LEFT JOIN FILIERE f ON e.id_filiere = f.id_filiere " &
                               "WHERE e.id_etudiant NOT IN (SELECT id_etudiant FROM PAIEMENT WHERE statut = 'complet') " &
                               "OR (SELECT SUM(montant) FROM PAIEMENT WHERE id_etudiant = e.id_etudiant AND statut <> 'en_attente') IS NULL " &
                               "ORDER BY e.nom, e.prenom"
            Return ExecuterRequeteSelect(sql, Nothing)
        End Function

        Public Shared Function Ajouter(idEtudiant As Integer, idReinscription As Integer, montant As Decimal, 
                                      datePaiement As Date, typeFrais As String, modePaiement As String, 
                                      reference As String, statut As String, observations As String) As Integer
            Dim sql As String = "INSERT INTO PAIEMENT (id_etudiant, id_reinscription, montant, date_paiement, type_frais, mode_paiement, reference, statut, observations) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@id_etudiant", idEtudiant),
                New OleDbParameter("@id_reinscription", If(idReinscription > 0, idReinscription, DBNull.Value)),
                New OleDbParameter("@montant", montant),
                New OleDbParameter("@date_paiement", datePaiement),
                New OleDbParameter("@type_frais", typeFrais),
                New OleDbParameter("@mode_paiement", modePaiement),
                New OleDbParameter("@reference", reference),
                New OleDbParameter("@statut", statut),
                New OleDbParameter("@observations", observations)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Modifier(id As Integer, montant As Decimal, datePaiement As Date, typeFrais As String, 
                                      modePaiement As String, reference As String, statut As String, observations As String) As Integer
            Dim sql As String = "UPDATE PAIEMENT SET montant = ?, date_paiement = ?, type_frais = ?, mode_paiement = ?, reference = ?, statut = ?, observations = ? WHERE id_paiement = ?"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@montant", montant),
                New OleDbParameter("@date_paiement", datePaiement),
                New OleDbParameter("@type_frais", typeFrais),
                New OleDbParameter("@mode_paiement", modePaiement),
                New OleDbParameter("@reference", reference),
                New OleDbParameter("@statut", statut),
                New OleDbParameter("@observations", observations),
                New OleDbParameter("@id", id)
            }
            Return ExecuterRequete(sql, params)
        End Function

        Public Shared Function Supprimer(id As Integer) As Integer
            Dim sql As String = "DELETE FROM PAIEMENT WHERE id_paiement = ?"
            Dim params As OleDbParameter() = {New OleDbParameter("@id", id)}
            Return ExecuterRequete(sql, params)
        End Function
    End Class

    Public Class JournalDAL
        Public Shared Sub EnregistrerAction(idUtilisateur As Integer, action As String, description As String)
            Dim sql As String = "INSERT INTO JOURNAL (id_utilisateur, action, date_action, description) VALUES (?, ?, ?, ?)"
            Dim params As OleDbParameter() = {
                New OleDbParameter("@id_utilisateur", idUtilisateur),
                New OleDbParameter("@action", action),
                New OleDbParameter("@date_action", DateTime.Now),
                New OleDbParameter("@description", description)
            }
            ExecuterRequete(sql, params)
        End Sub

        Public Shared Function GetAll() As DataTable
            Dim sql As String = "SELECT j.*, u.login, u.nom_complet FROM JOURNAL j LEFT JOIN UTILISATEUR u ON j.id_utilisateur = u.id_utilisateur ORDER BY j.date_action DESC"
            Return ExecuterRequeteSelect(sql, Nothing)
        End Function
    End Class
End Class
