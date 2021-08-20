Imports System.Data

Partial Class Formularios_EditarMoneda

    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")


            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("TipoMonedaID")
            End If

            If ViewState("EsNuevo") = True Then
                RadToolBar1.Items.Item(2).Enabled = False
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If

        End If

        'Borrar Serie  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If
        txtNombre.Focus()
        txtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

    End Sub
    Sub Nuevo()
        Dim cSql As String = "INSERT INTO TipoMoneda (Nombre, simbolo, local) VALUES ('" &
                                 Me.txtNombre.Text & "','" & txtSimbolo.Text & "'," & IIf(chkLocal.Checked, "1", "0") & ")"

        If ViewState("EsNuevo") = True Then
            oper.ExecuteNonQuery(cSql)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Moneda", "EditarMoneda", cSql)

        End If
    End Sub
    Sub Editar()
        Dim cSql As String = "SELECT Nombre, Simbolo, local FROM  [TipoMoneda]  where TipoMonedaID='" & CInt(ViewState("Code")) & "'"
        Dim ds As DataSet = oper.ExDataSet(cSql)
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Simbolo")) Then Me.txtSimbolo.Text = Trim(MyRow.Item("Simbolo"))
            chkLocal.Checked = MyRow.Item("local")
        Next
    End Sub
    Sub Actualizar()
        Dim cSql As String = "Update [TipoMoneda] set  Nombre ='" & txtNombre.Text & "'," &
                             " Simbolo ='" & txtSimbolo.Text & "'," &
                             " local = " & IIf(chkLocal.Checked, "1", "0") &
                             " where TipoMonedaID='" & CInt(ViewState("Code")) & "'"

        oper.ExecuteNonQuery(cSql)

        ViewState("EsNuevo") = False

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Moneda", "EditarMoneda", cSql)

    End Sub
    Sub Borrar()
        Dim ID As String = ""
        ID = oper.ExecuteScalar("Select count (*) from dbo.MonedasHistoricoTasas  where TipoMonedaID='" & ViewState("Code") & "'")

        If ID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a tasas de cambios.')</" + "script>"
        Else
            Try
                Dim cSql As String = "delete from dbo.TipoMoneda  where TipoMonedaID='" & ViewState("Code") & "'"
                oper.ExecuteNonQuery(cSql)

                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Moneda", "EditarMoneda", cSql)

                InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
            Catch ex As Exception
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Error al borrar el registro.')</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            End Try


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

        ElseIf e.Item.Value = 2 Then  ' Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        End If

        Session("Ajax") = False

    End Sub

End Class
