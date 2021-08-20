Imports System.Data

Partial Class Formularios_EditarTipoEmisor
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
                ViewState("Code") = Request.QueryString("TipoEmisorID")
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If

            txtNombre.Focus()

        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False
        End If

        'Borrar Tipo Emisor  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If

    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
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
            oper.ExecuteNonQuery("INSERT INTO TipoEmisor (Nombre,  Activo) VALUES ('" & txtNombre.Text & "','" & Check & "')")
        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [TipoEmisor]  where TipoEmisorID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))
        Next
    End Sub

    Sub Actualizar()
        Dim Check As String
        Check = CheckBox1.Checked
        oper.ExecuteNonQuery("Update [TipoEmisor] set  Nombre='" & txtNombre.Text & "', Activo='" & Check & "'  where TipoEmisorID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        Dim ID As String = ""
        ID = oper.ExecuteScalar("Select count (*) from dbo.Emisor  where TipoEmisorID='" & ViewState("Code") & "'")

        If ID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a un emisor.')</" + "script>"
        Else
            If oper.ExecuteNonQuery("delete from dbo.TipoEmisor  where TipoEmisorID='" & ViewState("Code") & "'") Then
                InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a otras entidades.')</" + "script>"
            End If
        End If

    End Sub

End Class
