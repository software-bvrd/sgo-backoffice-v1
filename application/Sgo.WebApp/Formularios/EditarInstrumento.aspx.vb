Imports System.Data

Partial Class EditarInstrumento
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        ViewState("EsNuevo") = Request.QueryString("EsNuevo")

        If Session("Ajax") = True Then
            ViewState("Code") = Session("Code")
        Else
            ViewState("Code") = Request.QueryString("InstrumentoID")
        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = True
        End If

        If IsPostBack = False Then
            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If

        'Borrar istrumento  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If

        txtNombre.Focus()
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

        ElseIf e.Item.Value = 2 Then  ' Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            Dim Check As String
            Check = CheckBox1.Checked
            oper.ExecuteNonQuery("INSERT INTO Instrumento (Nombre, CodSistema, TipoInstrumentoID, Activo) VALUES ('" _
                                 & txtNombre.Text & "','" & txtCodSistema.Text & "','" & Me.RadComboBox1.SelectedValue & "','" & Check & "')")
        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Instrumento]  where InstrumentoID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("CodSistema")) Then Me.txtCodSistema.Text = Trim(MyRow.Item("CodSistema"))
            If Not IsDBNull(MyRow.Item("TipoInstrumentoID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("TipoInstrumentoID"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))

        Next
    End Sub

    Sub Actualizar()
        Dim Check As String
        Check = CheckBox1.Checked
        oper.ExecuteNonQuery("Update [Instrumento] set  Nombre='" & txtNombre.Text & "', CodSistema = '" & txtCodSistema.Text & "', TipoInstrumentoID = '" & Me.RadComboBox1.SelectedValue & "', Activo='" & Check & "'  where InstrumentoID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        If oper.ExecuteNonQuery("delete from dbo.Instrumento where InstrumentoID='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro.')</" + "script>"
        End If
    End Sub

End Class
