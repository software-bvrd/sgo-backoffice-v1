Imports System.Globalization

Partial Class Transacciones_ListaRegistroNAV
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then
            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditaRegistroNAV.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True

            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then

            ViewState("Seleccionado") = 0

            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid.SelectedItems
                ViewState("Code") = dataItem("ID").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then
                Dim MyWindow As New Telerik.Web.UI.RadWindow
                MyWindow.NavigateUrl = "EditaRegistroNAV.aspx?NAVID=" & ViewState("Code") & "&EsNuevo=" & False
                MyWindow.VisibleOnPageLoad = True
                MyWindow.BackColor = Drawing.Color.Blue
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            End If


        ElseIf e.Item.Value = 5 Then

            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid.SelectedItems
                ViewState("Code") = dataItem("ID").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then
                oper.ExecuteNonQuery("DELETE FROM [TBL_NAV] WHERE ID=" & ViewState("Code") & "")
            End If


        ElseIf e.Item.Value = 90 Then ' Exportar

            RadGrid.MasterTableView.ExportToExcel()

        ElseIf e.Item.Value = 91 Then

            RadGrid.MasterTableView.ExportToPdf()

        ElseIf e.Item.Value = 92 Then

            RadGrid.MasterTableView.ExportToCSV()

        ElseIf e.Item.Value = 93 Then

            RadGrid.MasterTableView.ExportToWord()


        End If

        Session("Ajax") = False
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        If IsPostBack = False Then
            With RadGrid
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        End If

        InjectScriptLabelImprimir.Text = ""
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid.SelectedItems
            Session("Code") = dataItem("ID").Text
            Session("Ajax") = True
        Next
    End Sub

End Class
