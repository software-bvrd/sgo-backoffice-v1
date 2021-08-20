Imports System.Data

Partial Class Formularios_EditarCiudad
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""

        ViewState("EsNuevo") = Request.QueryString("EsNuevo")

        If Session("Ajax") = True Then
            ViewState("Code") = Session("Code")
        Else
            ViewState("Code") = Request.QueryString("CiudadID")
        End If
        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False

        End If

        If IsPostBack = False Then
            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If
        'Borrar Ciudad utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            BorrarCiudad()
        End If

        'txtNombre.Focus()
        txtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

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

        ElseIf e.Item.Value = 3 Then  ' Borrar
            InjectScriptLabelImprimir.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub
    Sub Nuevo()

        If ViewState("EsNuevo") = True Then
            Dim cSql As String = "INSERT INTO Ciudad (Nombre, PaisID) VALUES ('" & txtNombre.Text & "','" & Me.RadComboBox1.SelectedValue & "')"
            oper.ExecuteNonQuery(cSql)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Ciudad", "EditarCiudad", cSql)
        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Ciudad]  where CiudadID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("PaisID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("PaisID"))
        Next
    End Sub
    Sub Actualizar()
        Dim cSql As String = "Update [Ciudad] set  Nombre='" & txtNombre.Text & "', PaisID = '" & Me.RadComboBox1.SelectedValue & "'   where CiudadID='" & CInt(ViewState("Code")) & "'"
        oper.ExecuteNonQuery(cSql)
        ViewState("EsNuevo") = False

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Ciudad", "EditarCiudad", cSql)

    End Sub
    Sub BorrarCiudad()
        Dim ID = CInt(ViewState("Code"))
        Dim VerificarEmisor As String = ""
        VerificarEmisor = oper.ExecuteScalar("select Count(*) from dbo.Emisor where CiudadID ='" & ViewState("Code") & "'")
        If Integer.Parse(VerificarEmisor) > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se puede borrar la ciudad, esta asociado a una emisor.')</" + "script>"
        Else
            Dim cSql As String = "delete from dbo.Ciudad where CiudadID='" & ID & "'"
            If oper.ExecuteNonQuery(cSql) Then
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Ciudad", "EditarCiudad", cSql)

            Else
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Error al borrar el registro.')</" + "script>"

            End If
        End If
    End Sub
End Class
