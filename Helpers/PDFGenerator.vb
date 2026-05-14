Imports PdfSharpCore
Imports PdfSharpCore.Drawing
Imports PdfSharpCore.Pdf
Imports PdfSharpCore.Fonts
Imports PdfSharpCore.Utils
Imports System.IO

Namespace Helpers
    ''' <summary>
    ''' Générateur de reçus et rapports PDF simplifié
    ''' Utilise PdfSharpCore
    ''' </summary>
    Public Class PDFGenerator
        
        ''' <summary>
        ''' Génère un reçu de paiement au format PDF
        ''' </summary>
        Public Shared Function GenererRecuPaiement(
            numeroRecu As String,
            nomEtudiant As String,
            prenomEtudiant As String,
            numeroInscription As String,
            filiere As String,
            niveau As String,
            montant As Decimal,
            typeFrais As String,
            modePaiement As String,
            datePaiement As Date,
            nomCaissier As String
        ) As String
            
            Try
                ' Créer le document PDF
                Dim document As New PdfDocument()
                document.Info.Title = $"Reçu de paiement - {numeroRecu}"
                document.Info.Author = "ENSIT - Système de Gestion"
                document.Info.Subject = "Reçu de paiement"
                
                ' Ajouter une page
                Dim page As PdfPage = document.AddPage()
                page.Size = PageSize.A4
                
                ' Créer le graphique
                Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
                
                ' Définir les polices
                Dim fontTitle As New XFont("Arial", 20, XFontStyle.Bold)
                Dim fontSubtitle As New XFont("Arial", 14, XFontStyle.Bold)
                Dim fontNormal As New XFont("Arial", 11, XFontStyle.Regular)
                Dim fontBold As New XFont("Arial", 11, XFontStyle.Bold)
                Dim fontSmall As New XFont("Arial", 9, XFontStyle.Regular)
                
                ' Couleurs
                Dim bleuMarine As XColor = XColor.FromArgb(0, 51, 102)
                Dim orColor As XColor = XColor.FromArgb(218, 165, 32)
                Dim gris As XColor = XColor.FromArgb(128, 128, 128)
                
                Dim brushBleu As New XSolidBrush(bleuMarine)
                Dim brushOr As New XSolidBrush(orColor)
                Dim brushNoir As New XSolidBrush(XColors.Black)
                Dim brushGris As New XSolidBrush(gris)
                Dim brushBlanc As New XSolidBrush(XColors.White)
                
                ' Position Y de départ
                Dim y As Double = 40
                
                ' En-tête avec logo
                ' Dessiner un rectangle bleu marine
                gfx.DrawRectangle(brushBleu, 40, y, 100, 60)
                gfx.DrawString("ENSIT", New XFont("Arial", 16, XFontStyle.Bold), brushBlanc, New XRect(40, y + 15, 100, 30), XStringFormats.Center)
                
                ' Informations école
                gfx.DrawString("ÉCOLE NOUVELLE SUPÉRIEURE", fontBold, brushNoir, New XPoint(160, y + 10))
                gfx.DrawString("D'INGÉNIEURS ET DE TECHNOLOGIE", fontBold, brushNoir, New XPoint(160, y + 25))
                gfx.DrawString("Contact: info@ensit.edu", fontSmall, brushGris, New XPoint(160, y + 45))
                
                y += 90
                
                ' Ligne de séparation
                gfx.DrawLine(New XPen(bleuMarine, 2), 40, y, 555, y)
                y += 20
                
                ' Titre
                gfx.DrawString("REÇU DE PAIEMENT", fontTitle, brushBleu, New XPoint(180, y))
                y += 30
                
                ' Numéro de reçu
                gfx.DrawString($"N° {numeroRecu}", fontSubtitle, brushOr, New XPoint(220, y))
                y += 40
                
                ' Ligne de séparation
                gfx.DrawLine(New XPen(gris, 0.5), 40, y, 555, y)
                y += 20
                
                ' Section: Informations étudiant
                gfx.DrawString("INFORMATIONS DE L'ÉTUDIANT", fontBold, brushBleu, New XPoint(40, y))
                y += 25
                
                gfx.DrawString("Nom:", fontBold, brushNoir, New XPoint(40, y))
                gfx.DrawString($"{nomEtudiant} {prenomEtudiant}", fontNormal, brushNoir, New XPoint(150, y))
                y += 20
                
                gfx.DrawString("N° Inscription:", fontBold, brushNoir, New XPoint(40, y))
                gfx.DrawString(numeroInscription, fontNormal, brushNoir, New XPoint(150, y))
                y += 20
                
                gfx.DrawString("Filière:", fontBold, brushNoir, New XPoint(40, y))
                gfx.DrawString(filiere, fontNormal, brushNoir, New XPoint(150, y))
                y += 20
                
                gfx.DrawString("Niveau:", fontBold, brushNoir, New XPoint(40, y))
                gfx.DrawString($"{niveau}ème année", fontNormal, brushNoir, New XPoint(150, y))
                y += 30
                
                ' Ligne de séparation
                gfx.DrawLine(New XPen(gris, 0.5), 40, y, 555, y)
                y += 20
                
                ' Section: Détails paiement
                gfx.DrawString("DÉTAILS DU PAIEMENT", fontBold, brushBleu, New XPoint(40, y))
                y += 25
                
                ' Encadrer le montant
                gfx.DrawRectangle(New XPen(orColor, 2), 40, y - 5, 515, 30)
                gfx.DrawString("Montant payé:", fontBold, brushNoir, New XPoint(50, y + 10))
                gfx.DrawString($"{montant:N0} FCFA", New XFont("Arial", 14, XFontStyle.Bold), brushOr, New XPoint(350, y + 10))
                y += 40
                
                gfx.DrawString("Type de frais:", fontBold, brushNoir, New XPoint(40, y))
                gfx.DrawString(typeFrais, fontNormal, brushNoir, New XPoint(150, y))
                y += 20
                
                gfx.DrawString("Mode de paiement:", fontBold, brushNoir, New XPoint(40, y))
                gfx.DrawString(modePaiement, fontNormal, brushNoir, New XPoint(150, y))
                y += 20
                
                gfx.DrawString("Date:", fontBold, brushNoir, New XPoint(40, y))
                gfx.DrawString(datePaiement.ToString("dd/MM/yyyy"), fontNormal, brushNoir, New XPoint(150, y))
                y += 30
                
                ' Ligne de séparation
                gfx.DrawLine(New XPen(gris, 0.5), 40, y, 555, y)
                y += 15
                
                ' Montant en lettres
                gfx.DrawString($"Montant en lettres: {ConvertirMontantEnLettres(montant)} francs CFA", 
                              New XFont("Arial", 10, XFontStyle.Italic), brushGris, New XPoint(40, y))
                y += 50
                
                ' Signature
                gfx.DrawString("Le Caissier,", fontNormal, brushNoir, New XPoint(400, y))
                y += 40
                gfx.DrawString(nomCaissier, fontBold, brushNoir, New XPoint(400, y))
                
                ' Pied de page
                y = 780
                gfx.DrawLine(New XPen(gris, 0.5), 40, y, 555, y)
                y += 10
                gfx.DrawString("Ce reçu est un document officiel de l'ENSIT. Conservez-le précieusement.", 
                              New XFont("Arial", 8, XFontStyle.Italic), brushGris, New XPoint(130, y))
                
                ' Sauvegarder
                Dim fileName As String = $"Recu_{numeroRecu}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                Dim folderPath As String = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "ENSIT_Recus")
                Directory.CreateDirectory(folderPath)
                Dim filePath As String = Path.Combine(folderPath, fileName)
                
                document.Save(filePath)
                document.Close()
                
                Return filePath
                
            Catch ex As Exception
                Throw New Exception($"Erreur lors de la génération du PDF: {ex.Message}", ex)
            End Try
        End Function
        
        ''' <summary>
        ''' Convertit un montant en lettres (simplifié)
        ''' </summary>
        Private Shared Function ConvertirMontantEnLettres(montant As Decimal) As String
            If montant = 0 Then Return "zéro"
            
            Dim units As String() = {"", "un", "deux", "trois", "quatre", "cinq", "six", "sept", "huit", "neuf"}
            Dim teens As String() = {"dix", "onze", "douze", "treize", "quatorze", "quinze", "seize", "dix-sept", "dix-huit", "dix-neuf"}
            Dim tens As String() = {"", "dix", "vingt", "trente", "quarante", "cinquante", "soixante", "soixante-dix", "quatre-vingt", "quatre-vingt-dix"}
            
            Dim entier As Integer = CInt(Math.Floor(montant))
            
            If entier < 10 Then
                Return units(entier)
            ElseIf entier < 20 Then
                Return teens(entier - 10)
            ElseIf entier < 100 Then
                Dim dizaine As Integer = entier \ 10
                Dim unite As Integer = entier Mod 10
                If unite = 0 Then
                    Return tens(dizaine)
                Else
                    Return tens(dizaine) & "-" & units(unite)
                End If
            ElseIf entier < 1000 Then
                Dim centaine As Integer = entier \ 100
                Dim reste As Integer = entier Mod 100
                If centaine = 1 Then
                    Return If(reste = 0, "cent", "cent " & ConvertirMontantEnLettres(reste))
                Else
                    Return units(centaine) & " cent" & If(reste = 0, "s", " " & ConvertirMontantEnLettres(reste))
                End If
            ElseIf entier < 1000000 Then
                Dim millier As Integer = entier \ 1000
                Dim reste As Integer = entier Mod 1000
                Dim millierText As String = If(millier = 1, "mille", ConvertirMontantEnLettres(millier) & " mille")
                Return If(reste = 0, millierText, millierText & " " & ConvertirMontantEnLettres(reste))
            Else
                Return entier.ToString()
            End If
        End Function
        
        ''' <summary>
        ''' Génère un rapport simple des étudiants
        ''' </summary>
        Public Shared Function GenererRapportEtudiants(
            dt As DataTable,
            titreRapport As String,
            filtre As String
        ) As String
            
            Try
                Dim document As New PdfDocument()
                document.Info.Title = titreRapport
                document.Info.Author = "ENSIT"
                
                Dim page As PdfPage = document.AddPage()
                page.Size = PageSize.A4
                page.Orientation = PageOrientation.Landscape
                
                Dim gfx As XGraphics = XGraphics.FromPdfPage(page)
                Dim fontTitle As New XFont("Arial", 16, XFontStyle.Bold)
                Dim fontHeader As New XFont("Arial", 9, XFontStyle.Bold)
                Dim fontNormal As New XFont("Arial", 8, XFontStyle.Regular)
                Dim fontSmall As New XFont("Arial", 7, XFontStyle.Regular)
                
                Dim bleuMarine As XColor = XColor.FromArgb(0, 51, 102)
                Dim brushBleu As New XSolidBrush(bleuMarine)
                Dim brushNoir As New XSolidBrush(XColors.Black)
                Dim brushGris As New XSolidBrush(XColors.Gray)
                Dim brushBlanc As New XSolidBrush(XColors.White)
                
                Dim y As Double = 30
                
                ' Titre
                gfx.DrawString(titreRapport, fontTitle, brushBleu, New XPoint(250, y))
                y += 25
                
                ' Filtre
                If Not String.IsNullOrEmpty(filtre) Then
                    gfx.DrawString($"Filtre: {filtre}", New XFont("Arial", 10, XFontStyle.Italic), brushGris, New XPoint(40, y))
                    y += 20
                End If
                
                ' En-têtes du tableau
                Dim colWidth As Double = 750 / dt.Columns.Count
                gfx.DrawRectangle(brushBleu, 40, y - 15, 750, 20)
                
                Dim x As Double = 40
                For Each col As DataColumn In dt.Columns
                    gfx.DrawString(col.ColumnName, fontHeader, brushBlanc, New XPoint(x + 2, y))
                    x += colWidth
                Next
                y += 10
                
                ' Lignes de données
                For Each row As DataRow In dt.Rows
                    y += 15
                    x = 40
                    
                    ' Alternance de couleurs
                    If y Mod 30 < 15 Then
                        gfx.DrawRectangle(New XSolidBrush(XColor.FromArgb(240, 240, 240)), 40, y - 12, 750, 15)
                    End If
                    
                    For i As Integer = 0 To dt.Columns.Count - 1
                        Dim value As String = If(row(i) IsNot DBNull.Value, row(i).ToString(), "")
                        ' Tronquer si trop long
                        If value.Length > 25 Then
                            value = value.Substring(0, 22) & "..."
                        End If
                        gfx.DrawString(value, fontNormal, brushNoir, New XPoint(x + 2, y))
                        x += colWidth
                    Next
                    
                    ' Nouvelle page si nécessaire
                    If y > 520 Then
                        page = document.AddPage()
                        page.Size = PageSize.A4
                        page.Orientation = PageOrientation.Landscape
                        gfx = XGraphics.FromPdfPage(page)
                        y = 30
                    End If
                Next
                
                ' Pied de page
                y = 550
                gfx.DrawString($"Généré le {DateTime.Now:dd/MM/yyyy à HH:mm} - ENSIT", fontSmall, brushGris, New XPoint(600, y))
                
                ' Sauvegarder
                Dim fileName As String = $"Rapport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                Dim folderPath As String = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "ENSIT_Rapports")
                Directory.CreateDirectory(folderPath)
                Dim filePath As String = Path.Combine(folderPath, fileName)
                
                document.Save(filePath)
                document.Close()
                
                Return filePath
                
            Catch ex As Exception
                Throw New Exception($"Erreur lors de la génération du rapport: {ex.Message}", ex)
            End Try
        End Function
    End Class
End Namespace
