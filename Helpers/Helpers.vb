Imports System.Security.Cryptography
Imports System.Text

Namespace Helpers
    ''' <summary>
    ''' Helper pour la sécurité (hashage, cryptage)
    ''' </summary>
    Public Class SecurityHelper
        
        ''' <summary>
        ''' Hash un mot de passe avec SHA256 + Salt
        ''' </summary>
        Public Shared Function HashPassword(password As String) As String
            Using sha256 As SHA256 = SHA256.Create()
                ' Ajouter un salt fixe pour l'application
                Dim salt As String = "ENSIT_GestionEcole_2025"
                Dim combined As String = password & salt
                
                Dim bytes As Byte() = Encoding.UTF8.GetBytes(combined)
                Dim hash As Byte() = sha256.ComputeHash(bytes)
                
                Return Convert.ToBase64String(hash)
            End Using
        End Function
        
        ''' <summary>
        ''' Vérifie si un mot de passe correspond au hash
        ''' </summary>
        Public Shared Function VerifyPassword(password As String, hash As String) As Boolean
            Return HashPassword(password) = hash
        End Function
        
        ''' <summary>
        ''' Génère un token de session unique
        ''' </summary>
        Public Shared Function GenerateSessionToken() As String
            Return Guid.NewGuid().ToString("N")
        End Function
    End Class
    
    ''' <summary>
    ''' Helper pour la validation des données
    ''' </summary>
    Public Class ValidationHelper
        
        ''' <summary>
        ''' Valide une adresse email
        ''' </summary>
        Public Shared Function IsValidEmail(email As String) As Boolean
            If String.IsNullOrWhiteSpace(email) Then Return False
            
            Try
                Dim addr As New System.Net.Mail.MailAddress(email)
                Return addr.Address = email
            Catch
                Return False
            End Try
        End Function
        
        ''' <summary>
        ''' Valide un numéro de téléphone
        ''' </summary>
        Public Shared Function IsValidPhone(phone As String) As Boolean
            If String.IsNullOrWhiteSpace(phone) Then Return False
            
            ' Nettoyer le numéro
            Dim cleaned As String = System.Text.RegularExpressions.Regex.Replace(phone, "[^0-9]", "")
            
            ' Vérifier la longueur (8 à 15 chiffres)
            Return cleaned.Length >= 8 AndAlso cleaned.Length <= 15
        End Function
        
        ''' <summary>
        ''' Valide une date de naissance (15-100 ans)
        ''' </summary>
        Public Shared Function IsValidBirthDate(dateNaissance As Date) As Boolean
            Dim age As Integer = DateTime.Now.Year - dateNaissance.Year
            If DateTime.Now.DayOfYear < dateNaissance.DayOfYear Then
                age -= 1
            End If
            
            Return age >= 15 AndAlso age <= 100
        End Function
        
        ''' <summary>
        ''' Valide un montant positif
        ''' </summary>
        Public Shared Function IsValidAmount(montant As Decimal) As Boolean
            Return montant > 0
        End Function
        
        ''' <summary>
        ''' Nettoie une chaîne pour éviter l'injection SQL
        ''' </summary>
        Public Shared Function SanitizeInput(input As String) As String
            If String.IsNullOrWhiteSpace(input) Then Return String.Empty
            
            ' Supprimer les caractères dangereux
            Dim dangerous As String() = {"'", ";", "--", "/*", "*/", "xp_", "sp_"}
            Dim result As String = input
            
            For Each d As String In dangerous
                result = result.Replace(d, String.Empty)
            Next
            
            Return result.Trim()
        End Function
    End Class
    
    ''' <summary>
    ''' Helper pour les messages utilisateur
    ''' </summary>
    Public Class MessageHelper
        
        Public Shared Sub ShowSuccess(message As String)
            MessageBox.Show(message, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
        
        Public Shared Sub ShowError(message As String)
            MessageBox.Show(message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub
        
        Public Shared Sub ShowWarning(message As String)
            MessageBox.Show(message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub
        
        Public Shared Function Confirm(message As String) As Boolean
            Return MessageBox.Show(message, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes
        End Function
    End Class
    
    ''' <summary>
    ''' Helper pour le formatage
    ''' </summary>
    Public Class FormatHelper
        
        ''' <summary>
        ''' Formate un montant en devise
        ''' </summary>
        Public Shared Function FormatCurrency(montant As Decimal) As String
            Return String.Format("{0:N0} FCFA", montant)
        End Function
        
        ''' <summary>
        ''' Formate une date en format français
        ''' </summary>
        Public Shared Function FormatDate(dateValue As Date) As String
            Return dateValue.ToString("dd/MM/yyyy")
        End Function
        
        ''' <summary>
        ''' Formate un numéro de téléphone
        ''' </summary>
        Public Shared Function FormatPhone(phone As String) As String
            If String.IsNullOrWhiteSpace(phone) Then Return String.Empty
            
            ' Garder uniquement les chiffres
            Dim cleaned As String = System.Text.RegularExpressions.Regex.Replace(phone, "[^0-9]", "")
            
            ' Formater selon la longueur
            If cleaned.Length = 8 Then
                ' Format: XX XX XX XX
                Return String.Format("{0:## ## ## ##}", Convert.ToInt64(cleaned))
            ElseIf cleaned.Length = 10 Then
                ' Format: XX XX XX XX XX
                Return String.Format("{0:## ## ## ## ##}", Convert.ToInt64(cleaned))
            End If
            
            Return phone
        End Function
    End Class
    
    ''' <summary>
    ''' Helper pour les exports
    ''' </summary>
    Public Class ExportHelper
        
        ''' <summary>
        ''' Exporte un DataTable vers Excel (utilise NPOI)
        ''' </summary>
        Public Shared Sub ExportToExcel(dt As DataTable, fileName As String, sheetName As String)
            Try
                Dim workbook As New NPOI.XSSF.UserModel.XSSFWorkbook()
                Dim sheet As NPOI.SS.UserModel.ISheet = workbook.CreateSheet(sheetName)
                
                ' Style pour l'en-tête
                Dim headerStyle As NPOI.SS.UserModel.ICellStyle = workbook.CreateCellStyle()
                headerStyle.FillForegroundColor = NPOI.SS.UserModel.IndexedColors.Grey25Percent.Index
                headerStyle.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground
                Dim headerFont As NPOI.SS.UserModel.IFont = workbook.CreateFont()
                headerFont.IsBold = True
                headerStyle.SetFont(headerFont)
                
                ' Créer l'en-tête
                Dim headerRow As NPOI.SS.UserModel.IRow = sheet.CreateRow(0)
                For i As Integer = 0 To dt.Columns.Count - 1
                    Dim cell As NPOI.SS.UserModel.ICell = headerRow.CreateCell(i)
                    cell.SetCellValue(dt.Columns(i).ColumnName)
                    cell.CellStyle = headerStyle
                Next
                
                ' Ajouter les données
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim row As NPOI.SS.UserModel.IRow = sheet.CreateRow(i + 1)
                    For j As Integer = 0 To dt.Columns.Count - 1
                        Dim value As Object = dt.Rows(i)(j)
                        If value IsNot DBNull.Value Then
                            row.CreateCell(j).SetCellValue(value.ToString())
                        End If
                    Next
                Next
                
                ' Ajuster la largeur des colonnes
                For i As Integer = 0 To dt.Columns.Count - 1
                    sheet.AutoSizeColumn(i)
                Next
                
                ' Sauvegarder
                Using fs As New System.IO.FileStream(fileName, System.IO.FileMode.Create)
                    workbook.Write(fs)
                End Using
                
                MessageHelper.ShowSuccess($"Export réussi !\nFichier: {fileName}")
                
            Catch ex As Exception
                MessageHelper.ShowError($"Erreur lors de l'export: {ex.Message}")
            End Try
        End Sub
    End Class
End Namespace
