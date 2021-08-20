Imports System.Data
Public Class EditarClasificacionParticipante
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
                ViewState("Code") = Request.QueryString("ClasificacionParticipanteID")
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

        txtDescripcion.Focus()
        txtDescripcion.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll
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
            oper.ExecuteNonQuery("INSERT INTO ClasificacionParticipante (Descripcion, CodigoMercado,MecanismosNegociacionID,Estatus) VALUES ('" & txtDescripcion.Text & "','" & txtCodigoMercado.Text & "','" & RadComboMecanismoNegociacion.SelectedValue & "','" & Check & "')")
        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [ClasificacionParticipante]  where ClasificacionParticipanteID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcion.Text = Trim(MyRow.Item("Descripcion"))
            If Not IsDBNull(MyRow.Item("CodigoMercado")) Then Me.txtCodigoMercado.Text = Trim(MyRow.Item("CodigoMercado"))
            If Not IsDBNull(MyRow.Item("MecanismosNegociacionID")) Then Me.RadComboMecanismoNegociacion.SelectedValue = Trim(MyRow.Item("MecanismosNegociacionID"))
            If Not IsDBNull(MyRow.Item("Estatus")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Estatus"))
        Next
    End Sub

    Sub Actualizar()
        Dim Check As String
        Check = CheckBox1.Checked
        oper.ExecuteNonQuery("Update [ClasificacionParticipante] set  Descripcion='" & txtDescripcion.Text & "',CodigoMercado='" & txtCodigoMercado.Text & "', MecanismosNegociacionID = '" & Me.RadComboMecanismoNegociacion.SelectedValue & "', Estatus='" & Check & "'  where ClasificacionParticipanteID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub

    Sub Borrar()
        Dim VerificarPuestoBolsaID As String = ""

        VerificarPuestoBolsaID = oper.ExecuteScalar("Select count (*) from dbo.PuestoBolsaMecanismosNegociacion  where ClasificacionParticipanteID='" & ViewState("Code") & "'")

        If VerificarPuestoBolsaID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a un Puesto de Bolsa.')</" + "script>"
        Else
            If oper.ExecuteNonQuery("delete from dbo.ClasificacionParticipante where ClasificacionParticipanteID='" & ViewState("Code") & "'") Then
                InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a otras entidades.')</" + "script>"
            End If
        End If

    End Sub



End Class