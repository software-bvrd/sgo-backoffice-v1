Imports System.Data


Partial Class Formularios_EditarBaseLiquidacion
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")


            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("BaseLiquidacionID")
            End If

            If ViewState("EsNuevo") = True Then
                RadToolBar1.Items.Item(2).Enabled = False
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If

        End If
        'Borrar base liquidacion  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If
        txtNombre.Focus()


    End Sub
    Sub Nuevo()
        If ViewState("EsNuevo") = True Then

            Dim cSql As String = "INSERT INTO BaseLiquidacion (Nombre, DiasNatural,AnoNatural,Tipo, Activo) VALUES ('" &
                                 txtNombre.Text & "'," &
                                 txtDiasNatural.Text & "," &
                                 txtAnoNatural.Text & ",'" &
                                 Me.RadComboBox1.SelectedValue & "'," &
                                 IIf(chkActivo.Checked, "1", "0") & ")"

            oper.ExecuteNonQuery(cSql)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Base Liquidación", "EditarBaseLiquidacion", cSql)

        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT Nombre, DiasNatural, AnoNatural,Tipo,Activo FROM  [BaseLiquidacion]  where BaseLiquidacionID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("DiasNatural")) Then Me.txtDiasNatural.Text = Trim(MyRow.Item("DiasNatural"))
            If Not IsDBNull(MyRow.Item("AnoNatural")) Then Me.txtAnoNatural.Text = Trim(MyRow.Item("AnoNatural"))
            If Not IsDBNull(MyRow.Item("Tipo")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("Tipo"))
            chkActivo.Checked = MyRow.Item("Activo")
        Next
    End Sub
    Sub Actualizar()

        Dim cSql As String = "Update [BaseLiquidacion] set  Nombre ='" & txtNombre.Text & "'," &
                             " DiasNatural =" & txtDiasNatural.Text & "," &
                             " AnoNatural =" & txtAnoNatural.Text & "," &
                             " Tipo ='" & RadComboBox1.SelectedValue & "'," &
                             " Activo = " & IIf(chkActivo.Checked, "1", "0") &
                             " where BaseLiquidacionID='" & CInt(ViewState("Code")) & "'"
        oper.ExecuteNonQuery(cSql)
        ViewState("EsNuevo") = False

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Base Liquidación", "EditarBaseLiquidacion", cSql)

    End Sub
    Sub Borrar()
        Dim cSql As String = "delete from dbo.BaseLiquidacion where BaseLiquidacionID='" & ViewState("Code") & "'"
        If oper.ExecuteNonQuery(cSql) Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"

            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Base Liquidación", "EditarBaseLiquidacion", cSql)

        Else

            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
        End If
    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
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

        Session("Ajax") = False

    End Sub



End Class
