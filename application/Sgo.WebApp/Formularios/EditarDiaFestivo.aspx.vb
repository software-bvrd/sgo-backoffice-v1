Imports System.Data
Imports System.Globalization

Public Class EditarDiaFestivo
    Inherits System.Web.UI.Page
    Private oper As New operation
    Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())


    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")


            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("DiaFestivoID")
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

        txtFecha.Focus()


    End Sub
    Sub Nuevo()

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Dim dt As DateTime = Convert.ToDateTime(txtFecha.SelectedDate)
        Dim txtFechaUpdate As String = dt.ToShortDateString()


        Dim cSql As String = "INSERT INTO DiaFestivo (Descripcion, Fecha, Activo) VALUES ('" &
                                 Me.txtDescripcion.Text & "','" & txtFechaUpdate & "'," & IIf(chkLocal.Checked, "1", "0") & ")"

        If ViewState("EsNuevo") = True Then
            oper.ExecuteNonQuery(cSql)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Moneda", "EditarMoneda", cSql)

        End If


        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub
    Sub Editar()
        Dim cSql As String = "SELECT Fecha, Descripcion, Activo FROM  [DiaFestivo]  where DiaFestivoID='" & CInt(ViewState("Code")) & "'"
        Dim ds As DataSet = oper.ExDataSet(cSql)
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcion.Text = Trim(MyRow.Item("Descripcion"))
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFecha.SelectedDate = Trim(MyRow.Item("Fecha"))
            chkLocal.Checked = MyRow.Item("Activo")
        Next
    End Sub
    Sub Actualizar()
        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Dim dt As DateTime = Convert.ToDateTime(txtFecha.SelectedDate)
        Dim txtFechaUpdate As String = dt.ToShortDateString()


        Dim cSql As String = "Update [DiaFestivo] set  Descripcion ='" & txtDescripcion.Text & "'," &
                             " Fecha ='" & txtFechaUpdate & "'," &
                             " Activo = " & IIf(chkLocal.Checked, "1", "0") &
                             " where DiaFestivoID='" & CInt(ViewState("Code")) & "'"

        oper.ExecuteNonQuery(cSql)

        ViewState("EsNuevo") = False

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Moneda", "EditarMoneda", cSql)

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat


    End Sub
    Sub Borrar()
        Dim ID As String = ""
        ID = 0 'oper.ExecuteScalar("Select count (*) from dbo.DiaFestivo  where DiaFestivoID='" & ViewState("Code") & "'")

        If ID > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro. Esta asociado a .')</" + "script>"
        Else
            Try
                Dim cSql As String = "delete from dbo.DiaFestivo  where DiaFestivoID='" & ViewState("Code") & "'"
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