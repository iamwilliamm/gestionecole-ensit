Namespace Themes
    ''' <summary>
    ''' Classe de thème contenant les couleurs et styles de l'ENSIT
    ''' Couleurs officielles : Bleu marine, Blanc, Or/Doré
    ''' </summary>
    Public Class ENSITTheme
        
        ' Couleurs principales ENSIT
        Public Shared ReadOnly Property BleuMarine As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(0, 51, 102) ' #003366
            End Get
        End Property
        
        Public Shared ReadOnly Property BleuClair As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(51, 122, 183) ' #337AB7
            End Get
        End Property
        
        Public Shared ReadOnly Property CouleurOr As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(218, 165, 32) ' #DAA520
            End Get
        End Property
        
        Public Shared ReadOnly Property OrClair As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(255, 215, 0) ' #FFD700
            End Get
        End Property
        
        ' Couleurs de fond
        Public Shared ReadOnly Property FondPrincipal As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(245, 245, 250)
            End Get
        End Property
        
        Public Shared ReadOnly Property FondSecondaire As System.Drawing.Color
            Get
                Return System.Drawing.Color.White
            End Get
        End Property
        
        ' Couleurs de texte
        Public Shared ReadOnly Property TextePrincipal As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(33, 37, 41)
            End Get
        End Property
        
        Public Shared ReadOnly Property TexteClair As System.Drawing.Color
            Get
                Return System.Drawing.Color.White
            End Get
        End Property
        
        ' Couleurs d'état
        Public Shared ReadOnly Property Succes As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(40, 167, 69)
            End Get
        End Property
        
        Public Shared ReadOnly Property Danger As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(220, 53, 69)
            End Get
        End Property
        
        Public Shared ReadOnly Property Avertissement As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(255, 193, 7)
            End Get
        End Property
        
        Public Shared ReadOnly Property Info As System.Drawing.Color
            Get
                Return System.Drawing.Color.FromArgb(23, 162, 184)
            End Get
        End Property
        
        ''' <summary>
        ''' Applique le style bouton principal (bleu marine)
        ''' </summary>
        Public Shared Sub ApplyPrimaryButtonStyle(button As System.Windows.Forms.Button)
            button.BackColor = BleuMarine
            button.ForeColor = TexteClair
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            button.FlatAppearance.BorderSize = 0
            button.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            button.Cursor = System.Windows.Forms.Cursors.Hand
        End Sub
        
        ''' <summary>
        ''' Applique le style bouton secondaire (or)
        ''' </summary>
        Public Shared Sub ApplySecondaryButtonStyle(button As System.Windows.Forms.Button)
            button.BackColor = CouleurOr
            button.ForeColor = TextePrincipal
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            button.FlatAppearance.BorderSize = 0
            button.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            button.Cursor = System.Windows.Forms.Cursors.Hand
        End Sub
        
        ''' <summary>
        ''' Applique le style bouton danger (rouge)
        ''' </summary>
        Public Shared Sub ApplyDangerButtonStyle(button As System.Windows.Forms.Button)
            button.BackColor = Danger
            button.ForeColor = TexteClair
            button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            button.FlatAppearance.BorderSize = 0
            button.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            button.Cursor = System.Windows.Forms.Cursors.Hand
        End Sub
        
        ''' <summary>
        ''' Applique le style DataGridView
        ''' </summary>
        Public Shared Sub ApplyDataGridViewStyle(dgv As System.Windows.Forms.DataGridView)
            dgv.BackgroundColor = FondPrincipal
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
            dgv.EnableHeadersVisualStyles = False
            
            ' En-têtes
            dgv.ColumnHeadersDefaultCellStyle.BackColor = BleuMarine
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TexteClair
            dgv.ColumnHeadersDefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            dgv.ColumnHeadersHeight = 40
            
            ' Lignes
            dgv.DefaultCellStyle.BackColor = FondSecondaire
            dgv.DefaultCellStyle.ForeColor = TextePrincipal
            dgv.DefaultCellStyle.Font = New System.Drawing.Font("Segoe UI", 9.5F)
            dgv.DefaultCellStyle.SelectionBackColor = BleuClair
            dgv.DefaultCellStyle.SelectionForeColor = TexteClair
            dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 245)
            
            ' Autres propriétés
            dgv.RowTemplate.Height = 35
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        End Sub
        
        ''' <summary>
        ''' Applique le style Panel d'en-tête
        ''' </summary>
        Public Shared Sub ApplyHeaderPanelStyle(panel As System.Windows.Forms.Panel)
            panel.BackColor = BleuMarine
        End Sub
        
        ''' <summary>
        ''' Applique le style Label de titre
        ''' </summary>
        Public Shared Sub ApplyTitleLabelStyle(label As System.Windows.Forms.Label)
            label.ForeColor = BleuMarine
            label.Font = New System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold)
        End Sub
        
        ''' <summary>
        ''' Applique le style TextBox
        ''' </summary>
        Public Shared Sub ApplyTextBoxStyle(textBox As System.Windows.Forms.TextBox)
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            textBox.Font = New System.Drawing.Font("Segoe UI", 10)
            textBox.Height = 30
        End Sub
        
        ''' <summary>
        ''' Crée un dégradé pour les panels
        ''' </summary>
        Public Shared Function CreateGradientBrush(rectangle As System.Drawing.Rectangle) As System.Drawing.Drawing2D.LinearGradientBrush
            Dim brush As New System.Drawing.Drawing2D.LinearGradientBrush(
                rectangle,
                BleuMarine,
                BleuClair,
                System.Drawing.Drawing2D.LinearGradientMode.Horizontal)
            Return brush
        End Function
    End Class
End Namespace
