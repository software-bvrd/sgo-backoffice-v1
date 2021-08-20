Imports System.Data
Imports System.Drawing

Partial Class Formularios_EditarTipoCalificacionRiesgo
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
                ViewState("Code") = Request.QueryString("TipoCalificacionRiesgoID")
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

        RadComboBox2.Focus()

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
            oper.ExecuteNonQuery("INSERT INTO TipoCalificacionRiesgo (Nombre,CodEnSistema,Color, Definicion,RangoCalificacionID,EmpresaCalificadoraID) VALUES ('" & txtNombre.Text & "','" & txtCodEnSistema.Text & "','" & ColorTranslator.ToHtml(RadColorPicker2.SelectedColor) & "','" & txtDefinicion.Text & "','" & Me.RadComboBox1.SelectedValue & "','" & Me.RadComboBox2.SelectedValue & "')")
        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [TipoCalificacionRiesgo]  where TipoCalificacionRiesgoID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("CodEnSistema")) Then Me.txtCodEnSistema.Text = Trim(MyRow.Item("CodEnSistema"))
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Color")) Then
                RadColorPicker2.SelectedColor = ColorTranslator.FromHtml(MyRow.Item("Color"))
            End If

            If Not IsDBNull(MyRow.Item("Definicion")) Then Me.txtDefinicion.Text = Trim(MyRow.Item("Definicion"))
            If Not IsDBNull(MyRow.Item("RangoCalificacionID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("RangoCalificacionID"))
            If Not IsDBNull(MyRow.Item("EmpresaCalificadoraID")) Then Me.RadComboBox2.SelectedValue = Trim(MyRow.Item("EmpresaCalificadoraID"))
        Next

    End Sub
    Sub Actualizar()
        oper.ExecuteNonQuery("Update [TipoCalificacionRiesgo] set  Nombre ='" & txtNombre.Text & "', CodEnSistema ='" & txtCodEnSistema.Text & "', Color ='" & ColorTranslator.ToHtml(RadColorPicker2.SelectedColor) & "', Definicion ='" & txtDefinicion.Text & "', RangoCalificacionID = '" & Me.RadComboBox1.SelectedValue & "', EmpresaCalificadoraID = '" & Me.RadComboBox2.SelectedValue & "' where TipoCalificacionRiesgoID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        If oper.ExecuteNonQuery("delete from dbo.TipoCalificacionRiesgo where TipoCalificacionRiesgoID='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
        End If
    End Sub

End Class
