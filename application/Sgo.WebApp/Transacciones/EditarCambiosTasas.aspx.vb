' Notas : 2016.10.20 : Cambiar formato de Fecha de 103 a 101
Imports System.Globalization

Partial Class Transacciones_EditarCambiosTasas
    Inherits Page
    Private oper As New operation

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ViewState("EsNuevo") = Request.QueryString("EsNuevo")
            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("MonedasHistoricoTasasID")
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            Else
                txtFecha.DbSelectedDate = Today.Date
            End If

            txtFecha.Focus()
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

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            ClosePage()
        End If

    End Sub

    Sub Nuevo()

        Dim cSql As String = ""
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Try

            If ViewState("EsNuevo") = True Then
                txtTIPP.Text = IIf(txtTIPP.Text.Trim = "", "0", txtTIPP.Text.Trim)

                If ValidateControl() Then
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "ValidationForm", "ShowMessage('Datos incompletos', 'Favor completar los datos requeridos para proceder...');", True)

                ElseIf Exist(txtFecha.SelectedDate.Value, RadComboBox1.SelectedValue) Then

                    cSql = String.Format("INSERT INTO MonedasHistoricoTasas ([TipoMonedaID],[Fecha],[TasaCompra],[TasaVenta],[TIPP],[TPCV10],[TPCV01]) VALUES ('{0}', CONVERT(datetime,'{1}',101),{2},{3},{4},{5},{6})", RadComboBox1.SelectedValue, txtFecha.SelectedDate.Value, txtTasaCompra.Text, txtTasaVenta.Text, txtTIPP.Text, txtTPCV10.Text, txtTPCV01.Text)

                    If oper.ExecuteNonQuery(cSql) Then
                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "SuccessSave", "ShowMessage('Datos guardados', 'Datos guardados satisfactoriamente.');", True)
                    Else
                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "FailSaving", "ShowMessage('Error en datos', 'Error insertando');", True)

                    End If
                Else
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "CurrencyExist", "ShowMessage('Error en datos', 'Estimad@ ya existe una tasa para el dia de hoy con los parametros introducidos');", True)

                End If
            End If

        Catch ex As Exception
            Throw
        End Try

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet(String.Format("Select * FROM  [MonedasHistoricoTasas]  where MonedasHistoricoTasasID='{0}'", CInt(ViewState("Code"))))
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("TipoMonedaID")) Then RadComboBox1.SelectedValue = Trim(MyRow.Item("TipoMonedaID"))
            If Not IsDBNull(MyRow.Item("Fecha")) Then txtFecha.SelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("TasaCompra")) Then txtTasaCompra.Text = Trim(MyRow.Item("TasaCompra"))
            If Not IsDBNull(MyRow.Item("TasaVenta")) Then txtTasaVenta.Text = Trim(MyRow.Item("TasaVenta"))
            If Not IsDBNull(MyRow.Item("TIPP")) Then txtTIPP.Text = Trim(MyRow.Item("TIPP"))
            If Not IsDBNull(MyRow.Item("TPCV10")) Then txtTPCV10.Text = Trim(MyRow.Item("TPCV10"))
            If Not IsDBNull(MyRow.Item("TPCV01")) Then txtTPCV01.Text = Trim(MyRow.Item("TPCV01"))

        Next

        ' ------------------------------------------------------------------
        ' Esto es para limitar la edición al día en curso
        ' 2016.07.03 : Se habilita la posibilidad de realizar cambios de 
        '              fechas anteriores. Se comentan la lineas de protección.
        '
        If txtFecha.DbSelectedDate = Today.Date Then
        Else
            RadComboBox1.Enabled = False
            txtFecha.Enabled = False
            ' If txtTasaVenta.Text <> "" Then txtTasaVenta.ReadOnly = True
            ' If txtTasaCompra.Text <> "" Then txtTasaCompra.ReadOnly = True
            ' If txtTIPP.Text <> "0" Then txtTIPP.ReadOnly = True
        End If

    End Sub

    Sub Actualizar()
        Dim cSql As String = ""
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        txtTIPP.Text = IIf(txtTIPP.Text.Trim = "", "0", txtTIPP.Text.Trim)
        txtTPCV10.Text = IIf(txtTPCV10.Text.Trim = "", "0", txtTPCV10.Text.Trim)
        txtTPCV01.Text = IIf(txtTPCV01.Text.Trim = "", "0", txtTPCV01.Text.Trim)


        cSql = String.Format("Update [MonedasHistoricoTasas] set TipoMonedaID = '{0}', Fecha= CONVERT(datetime,'{1}',101), TasaCompra={2}, TasaVenta ={3}, TIPP ={4}, TPCV10 = {5}, TPCV01 = {6}  where MonedasHistoricoTasasID='{7}'", RadComboBox1.SelectedValue, txtFecha.SelectedDate.Value, txtTasaCompra.Text, txtTasaVenta.Text, txtTIPP.Text, txtTPCV10.Text, txtTPCV01.Text, CInt(ViewState("Code")))
        oper.ExecuteNonQuery(cSql)

        ViewState("EsNuevo") = False

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub

    Function Exist(ByVal currencyDate As String, ByVal currencyDeno As String) As Boolean
        Dim cSql As String = ""
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Try
            Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT * FROM [MonedasHistoricoTasas] where fecha = CONVERT(datetime,'{0}',101) and TipoMonedaID='{1}'", currencyDate, currencyDeno))
            If ds Is Nothing Or ds.Tables(0).Rows.Count = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw
        End Try

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Function

    Private Sub ClosePage()
        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
    End Sub

    Private Function ValidateControl() As Boolean
        If [String].IsNullOrEmpty(RadComboBox1.SelectedValue) Or [String].IsNullOrEmpty(txtTasaCompra.Text) Or [String].IsNullOrEmpty(txtTasaVenta.Text) Or [String].IsNullOrEmpty(txtTIPP.Text) Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Sub txtTasaVenta_TextChanged(sender As Object, e As EventArgs) Handles txtTasaVenta.TextChanged
        Dim cSql As String = ""
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Try
            cSql = String.Format("select dbo.fn_CalcularTasaPromediodeLasNUltimasTasasdeComprayVenta(10, '{0}','{1}',{2})", txtFecha.SelectedDate.Value, txtTasaCompra.Text, txtTasaVenta.Text)

            txtTPCV10.Text = oper.ExecuteScalar(cSql)
            txtTPCV01.Text = (Val(txtTasaCompra.Text) + Val(txtTasaVenta.Text)) / 2

        Catch ex As Exception


        End Try


        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub


    Protected Sub RecalcularTasasPromedio()
    End Sub





End Class
