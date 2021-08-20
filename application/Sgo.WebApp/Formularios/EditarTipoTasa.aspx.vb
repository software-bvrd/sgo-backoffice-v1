Imports System.Data

Partial Class Formularios_EditarTipoTasa
    Inherits System.Web.UI.Page

    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        ViewState("EsNuevo") = Request.QueryString("EsNuevo")

        If Session("Ajax") = True Then
            ViewState("Code") = Session("Code")
        Else
            ViewState("Code") = Request.QueryString("idTipotasa")
        End If

        If ViewState("EsNuevo") = True Then

            RadToolBar1.Items.Item(2).Enabled = False

        End If

        If IsPostBack = False Then

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If

        'Borrar Serie  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If

        txtDescricion.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar
            Dim Cantidad As String = oper.ExecuteScalar("SELECT count(*) AS cantidad FROM TipoTasa WHERE Descripcion = '" & txtDescricion.Text & "'")
            If Cantidad > 0 Then
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Ya existe una descripcion igual.')</" + "script>"
                Return
            End If

            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then 'borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        End If

    End Sub

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            oper.ExecuteNonQuery("INSERT INTO TipoTasa (Descripcion, DescripcionCorta, Atributo, Frecuencia) VALUES ('" & txtDescricion.Text & "','" & txtDescripcionCorta.Text & "','" & Me.RadComboBox1.SelectedValue & "','" & txtFrecuencia.Text & "')")
        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [TipoTasa]  where idTipotasa='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescricion.Text = Trim(MyRow.Item("Descripcion"))
            If Not IsDBNull(MyRow.Item("DescripcionCorta")) Then Me.txtDescripcionCorta.Text = Trim(MyRow.Item("DescripcionCorta"))
            If Not IsDBNull(MyRow.Item("Atributo")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("Atributo"))
            If Not IsDBNull(MyRow.Item("Frecuencia")) Then Me.txtFrecuencia.Text = Trim(MyRow.Item("Frecuencia"))

        Next
    End Sub
    Sub Actualizar()

        oper.ExecuteNonQuery("Update [TipoTasa] set  Descripcion='" & txtDescricion.Text & "', DescripcionCorta = '" & txtDescripcionCorta.Text & "', Atributo = '" & Me.RadComboBox1.SelectedValue & "', Frecuencia='" & txtFrecuencia.Text & "'  where idTipotasa='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        If oper.ExecuteNonQuery("delete from dbo.TipoTasa  where idTipotasa='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabelImprimir.Text = "<script>MensajePopup('Error al borrar el registro.')</" + "script>"
        End If

    End Sub


End Class
