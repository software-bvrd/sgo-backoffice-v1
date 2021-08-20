Imports Telerik.Web.UI
Imports System.Data

Partial Class Formularios_EditarTipoEntidad
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then
            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("TipoEntidadID")
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
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
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

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            Dim Check As String
            Check = CheckBox1.Checked
            oper.ExecuteNonQuery("INSERT INTO TipoEntidad (Nombre,Siglas, Activo) VALUES ('" & txtNombre.Text & "','" & txtSiglas.Text & "','" & Check & "')")
        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [TipoEntidad]  where TipoEntidadID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Siglas")) Then Me.txtSiglas.Text = Trim(MyRow.Item("Siglas"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))
            If Not IsDBNull(MyRow.Item("IncluirEnComision")) Then Me.chkIncluirEnComision.Checked = Trim(MyRow.Item("IncluirEnComision"))

        Next
    End Sub
    Sub Actualizar()
        Dim Check As String
        Dim CheckComision As String
        Check = CheckBox1.Checked
        CheckComision = chkIncluirEnComision.Checked

        oper.ExecuteNonQuery("Update [TipoEntidad] set  Nombre='" & txtNombre.Text & "', Siglas='" & txtSiglas.Text & "',IncluirEnComision='" & CheckComision & "',Activo='" & Check & "'  where TipoEntidadID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        If oper.ExecuteNonQuery("delete from dbo.TipoEntidad where TipoEntidadID='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
        End If
    End Sub
End Class
