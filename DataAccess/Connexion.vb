Imports System.Data.OleDb

Public Class Connexion
    Private Shared _chaineConnexion As String = ""
    Private Shared _fichierBDD As String = "GestionEcole.accdb"

    Public Shared Property ChaineConnexion As String
        Get
            If String.IsNullOrEmpty(_chaineConnexion) Then
                Dim cheminBDD As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fichierBDD)
                _chaineConnexion = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={cheminBDD};"
            End If
            Return _chaineConnexion
        End Get
        Set(value As String)
            _chaineConnexion = value
        End Set
    End Property

    Public Shared Function GetConnection() As OleDbConnection
        Return New OleDbConnection(ChaineConnexion)
    End Function

    Public Shared Sub InitialiserBaseDeDonnees()
        Dim cheminBDD As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, _fichierBDD)

        If Not IO.File.Exists(cheminBDD) Then
            Dim catType As Type = Type.GetTypeFromProgID("ADOX.Catalog")
            If catType IsNot Nothing Then
                Dim cat As Object = Activator.CreateInstance(catType)
                catType.InvokeMember("Create", System.Reflection.BindingFlags.InvokeMethod, Nothing, cat, 
                    New Object() {"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & cheminBDD})
                System.Runtime.InteropServices.Marshal.ReleaseComObject(cat)
            End If

            CreerTables()
            InsererDonneesTest()
        End If
    End Sub

    Private Shared Sub CreerTables()
        Using conn As OleDbConnection = GetConnection()
            conn.Open()

            Dim createTables As String() = {
                "CREATE TABLE IF NOT EXISTS FILIERE (id_filiere COUNTER PRIMARY KEY, libelle TEXT(100) NOT NULL, description MEMO)",
                "CREATE TABLE IF NOT EXISTS UTILISATEUR (id_utilisateur COUNTER PRIMARY KEY, login TEXT(50) NOT NULL UNIQUE, mot_de_passe TEXT(255) NOT NULL, role TEXT(20) NOT NULL, nom_complet TEXT(100), date_creation DATETIME)",
                "CREATE TABLE IF NOT EXISTS ETUDIANT (id_etudiant COUNTER PRIMARY KEY, nom TEXT(100) NOT NULL, prenom TEXT(100) NOT NULL, date_naissance DATE, lieu_naissance TEXT(100), sexe TEXT(1), email TEXT(100), telephone TEXT(20), adresse MEMO, photo MEMO, numero_inscription TEXT(20) NOT NULL UNIQUE, id_filiere INTEGER, date_inscription DATETIME, FOREIGN KEY (id_filiere) REFERENCES FILIERE(id_filiere))",
                "CREATE TABLE IF NOT EXISTS REINSCRIPTION (id_reinscription COUNTER PRIMARY KEY, id_etudiant INTEGER NOT NULL, annee_scolaire TEXT(9) NOT NULL, niveau INTEGER NOT NULL, date_reinscription DATETIME, observations MEMO, FOREIGN KEY (id_etudiant) REFERENCES ETUDIANT(id_etudiant))",
                "CREATE TABLE IF NOT EXISTS PAIEMENT (id_paiement COUNTER PRIMARY KEY, id_etudiant INTEGER NOT NULL, id_reinscription INTEGER, montant DECIMAL(10,2) NOT NULL, date_paiement DATETIME, type_frais TEXT(50), mode_paiement TEXT(50), reference TEXT(50), statut TEXT(20) NOT NULL, observations MEMO, FOREIGN KEY (id_etudiant) REFERENCES ETUDIANT(id_etudiant), FOREIGN KEY (id_reinscription) REFERENCES REINSCRIPTION(id_reinscription))",
                "CREATE TABLE IF NOT EXISTS JOURNAL (id INTEGER COUNTER PRIMARY KEY, id_utilisateur INTEGER, action TEXT(50) NOT NULL, date_action DATETIME NOT NULL, description MEMO, FOREIGN KEY (id_utilisateur) REFERENCES UTILISATEUR(id_utilisateur))"
            }

            For Each sql As String In createTables
                Try
                    Using cmd As New OleDbCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                    End Using
                Catch ex As Exception
                End Try
            Next
        End Using
    End Sub

    Private Shared Sub InsererDonneesTest()
        Using conn As OleDbConnection = GetConnection()
            conn.Open()

            Using cmd As New OleDbCommand("SELECT COUNT(*) FROM FILIERE", conn)
                If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then
                    Dim filieres As String() = {"Informatique", "Gestion", "Comptabilité", "Marketing", "Droit"}
                    For Each f As String In filieres
                        Using insertCmd As New OleDbCommand("INSERT INTO FILIERE (libelle, description) VALUES (?, ?)", conn)
                            insertCmd.Parameters.AddWithValue("?", f)
                            insertCmd.Parameters.AddWithValue("?", f & " - Formation professionnelle")
                            insertCmd.ExecuteNonQuery()
                        End Using
                    Next
                End If
            End Using

            Using cmd As New OleDbCommand("SELECT COUNT(*) FROM UTILISATEUR", conn)
                If Convert.ToInt32(cmd.ExecuteScalar()) = 0 Then
                    Dim md5 As String = "827ccb0eea8a706c4c34a16891f84e7b"
                    Using insertCmd As New OleDbCommand("INSERT INTO UTILISATEUR (login, mot_de_passe, role, nom_complet, date_creation) VALUES (?, ?, ?, ?, ?)", conn)
                        insertCmd.Parameters.AddWithValue("?", "admin")
                        insertCmd.Parameters.AddWithValue("?", md5)
                        insertCmd.Parameters.AddWithValue("?", "administrateur")
                        insertCmd.Parameters.AddWithValue("?", "Administrateur")
                        insertCmd.Parameters.AddWithValue("?", DateTime.Now)
                        insertCmd.ExecuteNonQuery()
                    End Using

                    Using insertCmd As New OleDbCommand("INSERT INTO UTILISATEUR (login, mot_de_passe, role, nom_complet, date_creation) VALUES (?, ?, ?, ?, ?)", conn)
                        insertCmd.Parameters.AddWithValue("?", "secretariat")
                        insertCmd.Parameters.AddWithValue("?", md5)
                        insertCmd.Parameters.AddWithValue("?", "personnel")
                        insertCmd.Parameters.AddWithValue("?", "Secrétaire")
                        insertCmd.Parameters.AddWithValue("?", DateTime.Now)
                        insertCmd.ExecuteNonQuery()
                    End Using
                End If
            End Using
        End Using
    End Sub
End Class
