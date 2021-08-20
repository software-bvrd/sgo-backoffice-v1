Imports Telerik.Web.UI

Partial Class Usuarios
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Nuevo
            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditUsuario.aspx?cmd=new"
            MyWindow.ShowContentDuringLoad = True
            MyWindow.VisibleOnPageLoad = True
            RadWindowManager1.Windows.Add(MyWindow)
        ElseIf e.Item.Value = 1 Then ' Editar
            'For Each dataitem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.SelectedItems
            '    'dataitem("Id").Text
            '    Dim MyWindow As New Telerik.Web.UI.RadWindow
            '    MyWindow.NavigateUrl = "EditUsuario.aspx?cmd=edit&Id=" & dataitem("IdUsuario").Text & ""
            '    MyWindow.ShowContentDuringLoad = True
            '    MyWindow.VisibleOnPageLoad = True
            '    RadWindowManager1.Windows.Add(MyWindow)
            'Next
        ElseIf e.Item.Value = 3 Then ' Borrar
            For Each dataitem As Telerik.Web.UI.GridDataItem In Me.RadGrid1.SelectedItems
                oper.ExecuteNonQuery(" Delete from TBL_Usuarios where IdUsuario=" & dataitem("IdUsuario").Text & "")
            Next
            Me.RadGrid1.DataBind()

        ElseIf e.Item.Value = 7 Then ' Mover
            InjectScriptLabel.Text = "<script>ventanaSecundaria('../Herramientas/Usuarios.aspx','1000','600')</" + "script>"

        ElseIf e.Item.Value = 2 Then ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If
    End Sub
    Protected Sub RadAjaxManager1_AjaxRequest(ByVal sender As Object, ByVal e As Telerik.Web.UI.AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("IdUsuario").Text
            Session("Editar") = "edit"
            Session("Ajax") = True
        Next
    End Sub


End Class
