Imports System.Data

Partial Class Formularios_EditarTipoDocumento
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
                ViewState("Code") = Request.QueryString("TipoDocumentoID")
            End If


            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False
        End If

        'Borrar Tipo Emisor  utilizando la confirmacion del usuario
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
            oper.ExecuteNonQuery("INSERT INTO TipoDocumento (Nombre, Activo) VALUES ('" & txtNombre.Text & "','" & Check & "')")
        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [TipoDocumento]  where TipoDocumentoID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))
        Next
    End Sub

    Sub Actualizar()
        Dim Check As String
        Check = CheckBox1.Checked
        oper.ExecuteNonQuery("Update [TipoDocumento] set  Nombre='" & txtNombre.Text & "', Activo='" & Check & "'  where TipoDocumentoID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        Dim VerificarEmisionID As String = ""
        Dim VerificarEmisorID As String = ""
        Dim VerificarPuestoBolsaID As String = ""

        VerificarEmisionID = oper.ExecuteScalar("Select count (*) from dbo.EmisionDocumento  where TipoDocumentoID='" & ViewState("Code") & "'")
        VerificarEmisorID = oper.ExecuteScalar("Select count (*) from dbo.EmisorDocumento  where TipoDocumentoID='" & ViewState("Code") & "'")
        VerificarPuestoBolsaID = oper.ExecuteScalar("Select count (*) from dbo.PuestoBolsaDocumento  where TipoDocumentoID='" & ViewState("Code") & "'")

        If VerificarEmisionID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a una emisión.')</" + "script>"
        ElseIf VerificarEmisorID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a un emisor.')</" + "script>"
        ElseIf VerificarPuestoBolsaID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a un Puesto de Bolsa.')</" + "script>"
        Else
            If oper.ExecuteNonQuery("delete from dbo.TipoDocumento where TipoDocumentoID='" & ViewState("Code") & "'") Then
                InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a otras entidades.')</" + "script>"
            End If
        End If

    End Sub



End Class
