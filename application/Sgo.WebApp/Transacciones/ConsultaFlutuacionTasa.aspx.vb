
Partial Class Transacciones_ConsultaFlutuacionTasa
    Inherits System.Web.UI.Page




    Protected Sub RadNumericTextBox1_TextChanged(sender As Object, e As System.EventArgs) Handles RadNumericTextBox1.TextChanged
        RadHtmlChart1.ChartTitle.Text = "Fluctuación Tasa " & RadNumericTextBox1.Text
        RadHtmlChart1.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then

            RadNumericTextBox1.Text = Today.Year.ToString
            RadNumericTextBox1_TextChanged(sender, e)

        End If
    End Sub
End Class
