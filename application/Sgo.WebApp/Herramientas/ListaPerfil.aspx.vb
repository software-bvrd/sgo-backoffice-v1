Imports System.Globalization

Partial Class Herramientas_ListaPerfil
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then 'Nuevo
            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditarPerfil.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True
            MyWindow.AutoSize = True

            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then 'Editar

            'ViewState("Seleccionado") = 0

            'For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            '    ViewState("Code") = dataItem("IdPerfil").Text
            '    ViewState("Seleccionado") = 1
            'Next

            'If ViewState("Seleccionado") = 1 Then
            '    Dim MyWindow As New Telerik.Web.UI.RadWindow
            '    MyWindow.NavigateUrl = "EditarPerfil.aspx?IdPerfil=" & ViewState("Code") & "&EsNuevo=" & False
            '    MyWindow.VisibleOnPageLoad = True
            '    MyWindow.BackColor = Drawing.Color.Blue
            '    MyWindow.AutoSize = True
            '    RadWindowManager1.Windows.Clear()
            '    RadWindowManager1.Windows.Add(MyWindow)
            'Else
            '    InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para editar.')</" + "script>"

            'End If


        ElseIf e.Item.Value = 7 Then 'Mover
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Herramientas/ListaPerfil.aspx','1000','600')</" + "script>"

        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"


        End If

        Session("Ajax") = False

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'limpiamos las label para que no se ejecuten cada vez que carga la página
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If Not IsPostBack Then
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With
        End If
    End Sub
    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("IdPerfil").Text
            Session("Ajax") = True
        Next
    End Sub



End Class
