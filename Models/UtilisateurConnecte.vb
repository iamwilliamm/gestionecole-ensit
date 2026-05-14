Public Class UtilisateurConnecte
    Private Shared _id As Integer
    Private Shared _login As String = ""
    Private Shared _role As String = ""
    Private Shared _nomComplet As String = ""

    Public Shared Property Id As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property

    Public Shared Property Login As String
        Get
            Return _login
        End Get
        Set(value As String)
            _login = value
        End Set
    End Property

    Public Shared Property Role As String
        Get
            Return _role
        End Get
        Set(value As String)
            _role = value
        End Set
    End Property

    Public Shared Property NomComplet As String
        Get
            Return _nomComplet
        End Get
        Set(value As String)
            _nomComplet = value
        End Set
    End Property

    Public Shared ReadOnly Property IsAdministrateur As Boolean
        Get
            Return _role = "administrateur"
        End Get
    End Property

    Public Shared Sub Deconnexion()
        DAL.JournalDAL.EnregistrerAction(_id, "DECONNEXION", "Déconnexion du système")
        _id = 0
        _login = ""
        _role = ""
        _nomComplet = ""
    End Sub
End Class
