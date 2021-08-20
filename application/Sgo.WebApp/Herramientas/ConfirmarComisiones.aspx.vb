Imports System.Data


Partial Class ConfirmarComisiones
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")


            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("ComisionHistoricoID")
                ViewState("Estatus") = Request.QueryString("Estatus")
            End If
            Codigo.Text = ViewState("Code")
            If ViewState("Estatus") <> "P" Then
                RadToolBar1.Items.Item(0).Enabled = False
            End If
            If ViewState("EsNuevo") = True Then
                RadToolBar1.Items.Item(2).Enabled = False
            End If


        End If
        'Borrar base liquidacion  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            'Borrar()
        End If





    End Sub

    Sub ActualizarEstatus()

        Dim cSql As String = "Update ComisionHistorico set  Estatus = 'C' where ComisionHistoricoID='" & CInt(ViewState("Code")) & "'"
        oper.ExecuteNonQuery(cSql)
        'ViewState("EsNuevo") = False

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Estatus comisiones", "ConfirmarComisiones", cSql)

    End Sub
    'Sub Borrar()
    '    Dim cSql As String = "delete from dbo.BaseLiquidacion where BaseLiquidacionID='" & ViewState("Code") & "'"
    '    If oper.ExecuteNonQuery(cSql) Then
    '        InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
    '        InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"

    '        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Base Liquidación", "EditarBaseLiquidacion", cSql)

    '    Else

    '        InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
    '    End If
    'End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Confirmar

            ActualizarEstatus()

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then ' Borrar
            'InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        End If

        Session("Ajax") = False

    End Sub



End Class
