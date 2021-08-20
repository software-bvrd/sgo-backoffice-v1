Imports System.Data

Partial Class Formularios_EditarActividadEconomica
    Inherits System.Web.UI.Page

    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        ViewState("EsNuevo") = Request.QueryString("EsNuevo")

        If Session("Ajax") = True Then
            ViewState("Code") = Session("Code")
        Else
            ViewState("Code") = Request.QueryString("ActividadEconomicaID")
        End If

        If IsPostBack = False Then
            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False
        End If

        'Borrar tipo periodo  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If

        txtNombre.Focus()
        txtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll
        
    End Sub
    Sub Nuevo()

        Dim cSql As String = "INSERT INTO ActividadEconomica (Nombre, Activo) VALUES ('" &
                                 Me.txtNombre.Text & "'," & IIf(chkLocal.Checked, "1", "0") & ")"

        If ViewState("EsNuevo") = True Then
            oper.ExecuteNonQuery(cSql)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Actividad Económica", "ActividadEconomica", cSql)
        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT Nombre, Activo FROM  [ActividadEconomica]  where ActividadEconomicaID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            chkLocal.Checked = MyRow.Item("Activo")
        Next
    End Sub
    Sub Actualizar()
        Dim cSql As String = "Update [ActividadEconomica] set  Nombre ='" & txtNombre.Text & "'," &
                             " Activo = " & IIf(chkLocal.Checked, "1", "0") &
                             " where ActividadEconomicaID='" & CInt(ViewState("Code")) & "'"
        oper.ExecuteNonQuery(cSql)
        ViewState("EsNuevo") = False
        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Actividad Económica", "ActividadEconomica", cSql)

    End Sub
    Sub Borrar()
        Dim ID As String = ""
        Dim EmiID As String = ""
        EmiID = oper.ExecuteScalar("Select count (*) from dbo.Emisor  where ActividadEconomicaID='" & ViewState("Code") & "'")
        ID = oper.ExecuteScalar("Select count (*) from dbo.sector  where ActividadEconomicaID='" & ViewState("Code") & "'")

        If EmiID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a un emisor.')</" + "script>"
        ElseIf ID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a una actividad económica.')</" + "script>"
        Else

            Dim cSql As String = "delete from dbo.ActividadEconomica where ActividadEconomicaID='" & ViewState("Code") & "'"
            If oper.ExecuteNonQuery(cSql) Then
                InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Actividad Económica", "ActividadEconomica", cSql)
            Else
                InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
            End If
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

    End Sub


End Class
