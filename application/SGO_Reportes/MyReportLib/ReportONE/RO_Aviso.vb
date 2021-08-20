Partial Public Class RO_Aviso
    Inherits Telerik.Reporting.Report
    Public Sub New()
        InitializeComponent()
    End Sub

    'Private Sub MK_BoletinPortada_ItemDataBound(sender As Object, e As EventArgs) Handles MyBase.ItemDataBound

    '    Dim report As Telerik.Reporting.Processing.Report = DirectCast(sender, Telerik.Reporting.Processing.Report)
    '    Dim Mercado As String = report.Parameters("Mercado").Value.ToString()

    '    If Mercado = "33" Then
    '        TextBox1.Visible = True
    '        TextBox2.Visible = True
    '        PictureBox1.Visible = True
    '    Else
    '        TextBox1.Visible = False
    '        TextBox2.Visible = False
    '        PictureBox1.Visible = False
    '    End If

    '    If Mercado <> "33" Then
    '        TextBox3.Visible = True
    '        TextBox4.Visible = True
    '        PictureBox2.Visible = True
    '        PictureBox3.Visible = True
    '    Else
    '        TextBox3.Visible = False
    '        TextBox4.Visible = False
    '        PictureBox2.Visible = False
    '        PictureBox3.Visible = False
    '    End If
    'End Sub


End Class