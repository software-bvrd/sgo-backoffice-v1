Imports Telerik.Web.UI

Public Class EditarTipoUsuarioSiopel
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then
            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("BO_TipoUsuarios_Siopel_TID")
            End If

            If ViewState("EsNuevo") = True Then
                RadToolBar1.Items.Item(2).Enabled = False
            End If

            If IsPostBack = False Then
                If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                    Call Editar()
                End If
            End If
        End If
        'Borrar base liquidacion utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If
        txtNombre.Focus()
        txtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

    End Sub




    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            Dim Check As String
            Check = CheckBox1.Checked
            oper.ExecuteNonQuery("INSERT INTO BO_TipoUsuarios_Siopel_T (Nombre, Activo) VALUES ('" & txtNombre.Text & "','" & Check & "')")
        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [BO_TipoUsuarios_Siopel_T]  where BO_TipoUsuarios_Siopel_TID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))

        Next
    End Sub

    Sub Actualizar()
        Dim Check As String
        Check = CheckBox1.Checked
        oper.ExecuteNonQuery("Update [BO_TipoUsuarios_Siopel_T] set  Nombre='" & txtNombre.Text & "', Activo='" & Check & "'  where BO_TipoUsuarios_Siopel_TID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub

    Sub Borrar()
        If oper.ExecuteNonQuery("delete from dbo.BO_TipoUsuarios_Siopel_T where BO_TipoUsuarios_Siopel_TID='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
        End If
    End Sub

    Private Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

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