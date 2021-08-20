Imports System.Globalization
Imports Telerik.Web.UI

Partial Class Formularios_ListaPuestoBolsa
    Inherits Page
    Private oper As New operation
    'Dim boConn As Connection.Connection.DBConnection = New Connection.Connection.DBConnection()

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then

            Dim MyWindow As New RadWindow
            MyWindow.NavigateUrl = "EditarPuestoBolsa.aspx?EsNuevo=" & True
            MyWindow.VisibleOnPageLoad = True
            MyWindow.AutoSize = True

            RadWindowManager1.Windows.Clear()
            RadWindowManager1.Windows.Add(MyWindow)

        ElseIf e.Item.Value = 1 Then

            ViewState("Seleccionado") = 0

            For Each dataItem As GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("PuestoBolsaID").Text
                ViewState("Seleccionado") = 1
            Next

            If ViewState("Seleccionado") = 1 Then
                Dim MyWindow As New RadWindow
                MyWindow.NavigateUrl = "EditarPuestoBolsa.aspx?PuestoBolsaID=" & ViewState("Code") & "&EsNuevo=" & False
                MyWindow.VisibleOnPageLoad = True
                MyWindow.BackColor = Drawing.Color.Blue
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para editar.')</" + "script>"

            End If

        ElseIf e.Item.Value = 2 Then

        ElseIf e.Item.Value = 3 Then
            For Each dataItem As GridDataItem In RadGrid1.SelectedItems
                ViewState("Code") = dataItem("PuestoBolsaID").Text
            Next
            oper.ExecuteNonQuery(String.Format("delete from dbo.PuestoBolsaCorredor  where PuestoBolsaID='{0}'", ViewState("Code")))
            oper.ExecuteNonQuery(String.Format("delete from dbo.PuestoBolsaDirectivo  where PuestoBolsaID='{0}'", ViewState("Code")))
            oper.ExecuteNonQuery(String.Format("delete from dbo.PuestoBolsaDocumento  where PuestoBolsaID='{0}'", ViewState("Code")))
            oper.ExecuteNonQuery(String.Format("delete from dbo.PuestoBolsa  where PuestoBolsaID='{0}'", ViewState("Code")))
            Me.RadGrid1.Rebind()

        ElseIf e.Item.Value = 90 Then ' Exportar
            RadGrid1.MasterTableView.ExportToExcel()

        ElseIf e.Item.Value = 91 Then
            RadGrid1.MasterTableView.ExportToPdf()

        ElseIf e.Item.Value = 92 Then
            RadGrid1.MasterTableView.ExportToCSV()

        ElseIf e.Item.Value = 93 Then
            RadGrid1.MasterTableView.ExportToWord()

        ElseIf e.Item.Value = 7 Then
            InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../edicion/ListaPuestoBolsa.aspx','1000','600')</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        End If
        Session("Ajax") = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            'SqlListaPuestoBolsa.ConnectionString = boConn.getConnectionString
            'SqlListaPuestoBolsa.SelectCommand = "SELECT * FROM [vPuestoBolsa] order by Nombre"

            Dim expression As GridGroupByExpression = New GridGroupByExpression
            Dim gridGroupByField As GridGroupByField = New GridGroupByField

            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            Try
                gridGroupByField = New GridGroupByField
                gridGroupByField.FieldName = "Descripcion"
                gridGroupByField.HeaderText = "Tipo Participante"
                gridGroupByField.HeaderValueSeparator = " : "
                gridGroupByField.FormatString = "<strong>{0}</strong>"
                expression.SelectFields.Add(gridGroupByField)
                gridGroupByField = New GridGroupByField
                gridGroupByField.FieldName = "Descripcion"
                expression.GroupByFields.Add(gridGroupByField)
                RadGrid1.MasterTableView.GroupByExpressions.Add(expression)
            Catch ex As Exception
            Finally
                RadGrid1.Rebind()
            End Try
        End If
    End Sub

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("PuestoBolsaID").Text
            Session("Ajax") = True
        Next
    End Sub

End Class