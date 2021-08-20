Imports System.Globalization
Imports System.Data
Partial Class Formularios_ListaInstrumento
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Nuevo

            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditarInstrumento.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True
            MyWindow.AutoSize = True

            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then ' Editar

            ViewState("Seleccionado") = 0

            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("InstrumentoID").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then
                Dim MyWindow As New Telerik.Web.UI.RadWindow
                MyWindow.NavigateUrl = "EditarInstrumento.aspx?InstrumentoID=" & ViewState("Code") & "&EsNuevo=" & False
                MyWindow.VisibleOnPageLoad = True
                MyWindow.BackColor = Drawing.Color.Blue
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para editar.')</" + "script>"

            End If


        ElseIf e.Item.Value = 3 Then 'Borrar
            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("InstrumentoID").Text
            Next
            oper.ExecuteNonQuery("delete from dbo.Instrumento  where InstrumentoID='" & ViewState("Code") & "'")
            Me.RadGrid1.Rebind()

        ElseIf e.Item.Value = 7 Then 'Mover
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Formularios/ListaTipoLiquidacion.aspx','1000','600')</" + "script>"

        ElseIf e.Item.Value = 90 Then ' Exportar

            RadGrid1.MasterTableView.ExportToExcel()

        ElseIf e.Item.Value = 91 Then

            RadGrid1.MasterTableView.ExportToPdf()

        ElseIf e.Item.Value = 92 Then

            RadGrid1.MasterTableView.ExportToCSV()

        ElseIf e.Item.Value = 93 Then

            RadGrid1.MasterTableView.ExportToWord()

        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"

        End If

        Session("Ajax") = False

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'limpiamos las label para que no se ejecuten cada vez que carga la página
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        With RadGrid1
            .Culture = New CultureInfo("es-DO")
            .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
        End With
    End Sub
    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("InstrumentoID").Text
            Session("Ajax") = True
        Next
    End Sub
End Class
