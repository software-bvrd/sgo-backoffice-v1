Imports System.Data

Partial Class Formularios_EditarMercado
    Inherits System.Web.UI.Page
    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")


            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("MercadoID")
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If

            If ViewState("EsNuevo") = True Then
                RadToolBar1.Items.Item(2).Enabled = False
            End If

            txtNombre.Focus()

        End If
        'Borrar tipo periodo  utilizando la confirmacion del usuario
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
            InjectScriptLabelImprimir.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            Dim Check As String
            Dim Check2 As String
            Check = CheckBox1.Checked
            Check2 = CheckBox2.Checked
            oper.ExecuteNonQuery("INSERT INTO Mercado (Nombre, Alias, CodigoMercado ,TipoMercadoID, Activo, IncluirReporteBoletin) VALUES ('" & txtNombre.Text & "','" & TxtAlias.Text & "','" & txtCodigoMercado.Text & "','" & Me.RadComboBox1.SelectedValue & "','" & Check & "','" & Check2 & "')")
        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vMercado]  where MercadoID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Alias")) Then Me.TxtAlias.Text = Trim(MyRow.Item("Alias"))
            If Not IsDBNull(MyRow.Item("CodigoMercado")) Then Me.txtCodigoMercado.Text = Trim(MyRow.Item("CodigoMercado"))
            If Not IsDBNull(MyRow.Item("TipoMercadoID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("TipoMercadoID"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))
            If Not IsDBNull(MyRow.Item("IncluirReporteBoletin")) Then Me.CheckBox2.Checked = Trim(MyRow.Item("IncluirReporteBoletin"))

        Next
    End Sub
    Sub Actualizar()
        Dim Check As String
        Dim Check2 As String
        Check = CheckBox1.Checked
        Check2 = CheckBox2.Checked
        oper.ExecuteNonQuery("Update [Mercado] set  Nombre='" & txtNombre.Text & "', Alias='" & TxtAlias.Text & "', CodigoMercado='" & txtCodigoMercado.Text & "', TipoMercadoID = '" & Me.RadComboBox1.SelectedValue & "', Activo='" & Check & "', IncluirReporteBoletin='" & Check2 & "'  where MercadoID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub
    Sub Borrar()
        Dim CodigoMercado As String = ""
        Dim Asociado As String = ""
        CodigoMercado = oper.ExecuteScalar("Select CodigoMercado from dbo.Mercado  where MercadoID='" & ViewState("Code") & "'")
        Asociado = oper.ExecuteScalar("Select count (*) from dbo.OperacionesCSV  where mercado='" & CodigoMercado & "'")

        If Asociado > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a Operaciones.')</" + "script>"
        Else
            If oper.ExecuteNonQuery("delete from dbo.Mercado  where MercadoID='" & ViewState("Code") & "'") Then
                InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a otras entidades.')</" + "script>"
            End If
        End If
    End Sub

End Class
