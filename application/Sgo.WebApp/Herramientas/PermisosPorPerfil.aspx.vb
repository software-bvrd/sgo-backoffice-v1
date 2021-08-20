Imports Telerik.Web.UI
Imports System.Globalization

Partial Class PermisosPorPerfil
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then ' Nuevo
            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditPermisoPerfil.aspx?cmd=new"
            MyWindow.ShowContentDuringLoad = True
            MyWindow.VisibleOnPageLoad = True
            RadWindowManager1.Windows.Add(MyWindow)
        ElseIf e.Item.Value = 1 Then ' Editar
            'For Each dataitem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.SelectedItems
            '    Dim MyWindow As New Telerik.Web.UI.RadWindow
            '    MyWindow.NavigateUrl = "EditPermisoPerfil.aspx?cmd=edit&Id=" & dataitem("IdPerfil").Text & ""
            '    MyWindow.ShowContentDuringLoad = True
            '    MyWindow.VisibleOnPageLoad = True
            '    RadWindowManager1.Windows.Add(MyWindow)
            'Next

        ElseIf e.Item.Value = 3 Then ' Borrar

        ElseIf e.Item.Value = 7 Then ' Mover


        ElseIf e.Item.Value = 2 Then ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If



    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim expression As GridGroupByExpression = New GridGroupByExpression
        'Dim gridGroupByField As GridGroupByField = New GridGroupByField


        'With RadGrid1
        '    .Culture = New CultureInfo("es-DO")
        '    .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")


        '    Try
        '        gridGroupByField = New GridGroupByField
        '        gridGroupByField.FieldName = "Perfil"
        '        gridGroupByField.HeaderText = "Perfil"
        '        gridGroupByField.HeaderValueSeparator = " : "
        '        gridGroupByField.FormatString = "<strong>{0}</strong>"
        '        expression.SelectFields.Add(gridGroupByField)

        '        gridGroupByField = New GridGroupByField
        '        gridGroupByField.FieldName = "Perfil"

        '        expression.GroupByFields.Add(gridGroupByField)
        '        .MasterTableView.GroupByExpressions.Add(expression)



        '    Catch ex As Exception

        '    Finally
        '        RadGrid1.Rebind()
        '    End Try

        'End With
    End Sub
    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("IdPerfil") = dataItem("IdPerfil").Text
            Session("Editar") = "edit"
            Session("Ajax") = True
        Next
    End Sub
End Class
