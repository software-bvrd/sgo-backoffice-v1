
Partial Class Edicion_ActivarEmision
    Inherits System.Web.UI.Page

    Private oper As New operation




    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then ' Guardar
            oper.ExecuteNonQuery("Update [Emision] set Estatus = '" & cbEstatus.SelectedValue & "' where EmisionID = " & RadComboBoxEmisionID.SelectedValue)

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Protected Sub RadComboBoxEmisionID_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEmisionID.SelectedIndexChanged

        Dim cSatus As String = oper.ExecuteScalar("select Estatus from Emision where EmisionID = " & RadComboBoxEmisionID.SelectedValue)

        cbEstatus.SelectedValue = Trim(cSatus)


    End Sub
End Class
