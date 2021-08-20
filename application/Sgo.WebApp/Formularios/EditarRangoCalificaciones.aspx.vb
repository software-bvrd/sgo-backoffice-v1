Imports System.Data


Partial Class Formularios_RangoCalificaciones
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("RangoCalificacionID")
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If

        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False
        End If

        'Borrar empresa calificadora  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If

        RadComboEmpresaCalificadora.Focus()


    End Sub

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            oper.ExecuteNonQuery("INSERT INTO RangoCalificacion (Nombre, EmpresaCalificadoraID) VALUES ('" &
                                 Me.txtNombre.Text & "','" & RadComboEmpresaCalificadora.SelectedValue & "')")
        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT Nombre,EmpresaCalificadoraID FROM  [RangoCalificacion]  where RangoCalificacionID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("EmpresaCalificadoraID")) Then Me.RadComboEmpresaCalificadora.SelectedValue = Trim(MyRow.Item("EmpresaCalificadoraID"))
        Next
    End Sub
    Sub Actualizar()
        oper.ExecuteNonQuery("Update [RangoCalificacion] set  Nombre ='" & txtNombre.Text & "', EmpresaCalificadoraID = '" & Me.RadComboEmpresaCalificadora.SelectedValue & "' where RangoCalificacionID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        If oper.ExecuteNonQuery("delete from dbo.RangoCalificacion where RangoCalificacionID='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
        End If
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar

            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then ' Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

End Class
