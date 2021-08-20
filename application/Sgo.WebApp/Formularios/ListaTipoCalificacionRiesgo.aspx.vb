Imports System.Globalization
Partial Class Formularios_ListaTipoCalificacionRiesgo
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        Dim cCantidadTipoCalificacionRiesgo As String = ""


        If e.Item.Value = 0 Then 'Nueva

            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditarTipoCalificacionRiesgo.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True
            MyWindow.AutoSize = True

            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then 'Editar

            ViewState("Seleccionado") = 0

            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("TipoCalificacionRiesgoID").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then
                Dim MyWindow As New Telerik.Web.UI.RadWindow
                MyWindow.NavigateUrl = "EditarTipoCalificacionRiesgo.aspx?TipoCalificacionRiesgoID=" & ViewState("Code") & "&EsNuevo=" & False
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
                ViewState("Code") = dataItem("TipoCalificacionRiesgoID").Text
            Next

            ' -----------------------------------------------------------
            ' Verificar si esta asignada a una Emision o a Un Emisor
            ' ------------------------------------------------------------

            cCantidadTipoCalificacionRiesgo = oper.ExecuteScalar("select conteo from vCalificacionesRiesgoAsignadasEmisor where TipoCalificacionRiesgoID ='" & ViewState("Code") & "'")
            cCantidadTipoCalificacionRiesgo = IIf(cCantidadTipoCalificacionRiesgo = "", "0", cCantidadTipoCalificacionRiesgo)

            If Integer.Parse(cCantidadTipoCalificacionRiesgo) > 0 Then

                RadWindowManager1.RadAlert("<br/><b>No se puede borrar este tipo de Calificación de Riesgo, ya esta asociada a un Emisor o Emisión</b><br/>", 400, 200, "Verifique", "")
                ''MsgBox("No se puede borrar este tipo de Calificación de Riesgo, ya esta asociada a un Emisor o Emisión")

            Else
                InjectScriptLabel.Text = "<script>Delete()</" + "script>"

            End If
            Me.RadGrid1.Rebind()

        ElseIf e.Item.Value = 7 Then 'Mover
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Formularios/ListaTipoCalificacionRiesgo.aspx','1000','600')</" + "script>"

        ElseIf e.Item.Value = 2 Then 'Cancelar
            InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"

        ElseIf e.Item.Value = 4 Then 'imprimir
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../reportes/ReporteCalificacionesRiesgo.aspx','1000','600')</" + "script>"

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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'limpiamos las label para que no se ejecuten cada vez que carga la página
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With
        End If

        'Borrar Serie  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()

        End If

    End Sub
    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("TipoCalificacionRiesgoID").Text
            Session("Ajax") = True
        Next
    End Sub


    Protected Sub Borrar()
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            ViewState("Code") = dataItem("TipoCalificacionRiesgoID").Text
        Next
        oper.ExecuteNonQuery("delete from dbo.TipoCalificacionRiesgo  where TipoCalificacionRiesgoID='" & ViewState("Code") & "'")


    End Sub


End Class
