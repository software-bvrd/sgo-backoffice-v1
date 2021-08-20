Imports System.Globalization
Imports Telerik.Web.UI

Public Class BB_ListaConfiguracion
    Inherits System.Web.UI.Page
    Private oper As New operation
    Private Sub BB_ListaConfiguracion_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
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

    Private Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then 'nuevo

            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "BB_EditarConfiguracion.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True
            MyWindow.AutoSize = True

            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then 'editar

            ViewState("Seleccionado") = 0

            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("BoletinConfiguracionID").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then
                Dim MyWindow As New Telerik.Web.UI.RadWindow
                MyWindow.NavigateUrl = "BB_EditarConfiguracion.aspx?BoletinConfiguracionID=" & ViewState("Code") & "&EsNuevo=" & False
                MyWindow.VisibleOnPageLoad = True
                MyWindow.BackColor = Drawing.Color.Blue
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para editar.')</" + "script>"
            End If

        ElseIf e.Item.Value = 2 Then 'cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"

        ElseIf e.Item.Value = 3 Then 'borrar
            ViewState("SeleccionadoBorrar") = 0
            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("BoletinConfiguracionID").Text
                ViewState("SeleccionadoBorrar") = 1
            Next

            If ViewState("SeleccionadoBorrar") = 1 Then
                oper.ExecuteNonQuery("delete from dbo.BoletinConfiguracion  where BoletinConfiguracionID='" & ViewState("Code") & "'")
                Me.RadGrid1.Rebind()
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para borrar.')</" + "script>"
            End If

        ElseIf e.Item.Value = 7 Then
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Formularios/ListaTipoTasa.aspx','1000','600')</" + "script>"

        ElseIf e.Item.Value = 90 Then ' Exportar

            RadGrid1.MasterTableView.ExportToExcel()

        ElseIf e.Item.Value = 91 Then

            RadGrid1.MasterTableView.ExportToPdf()

        ElseIf e.Item.Value = 92 Then

            RadGrid1.MasterTableView.ExportToCSV()

        ElseIf e.Item.Value = 93 Then

            RadGrid1.MasterTableView.ExportToWord()
        End If

        Session("Ajax") = False
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("BoletinConfiguracionID").Text
            Session("Ajax") = True
        Next
    End Sub

End Class