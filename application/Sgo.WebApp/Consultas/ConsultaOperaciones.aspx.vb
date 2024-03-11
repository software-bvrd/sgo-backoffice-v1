Imports System.Globalization
Imports System.IO
Imports System.Xml

Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports FluentNHibernate.MappingModel.Collections
Imports System.Data.SqlTypes
Imports System.Net
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Windows.Forms.AxHost
Imports System.Net.Mail
Imports Telerik.Web.UI.com.hisoftware.api2
Imports System.Net.Security.SslPolicyErrors
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Ajax.Utilities
Imports System.Security.Authentication
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json

Partial Class ConsultaOperaciones
    Inherits Page
    Private oper As New operation
    Private cStringWhere As String = ""
    Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
    Dim StrFiltros As String
    Dim FechaFiltrada
    Dim dtRespuestaCevaldom = New DataTable()
    Dim _strCadena As String
    Public strtoken As String = ""
    Public _strbody As String = ""
    Public _strfilename As String = ""
    Private eventId As Integer = 1
    Public strruta As String = ConfigurationManager.AppSettings("strruta").ToString() '"\\arp22b\xml\"
    'Public strruta As String = "\\adb03\xmlWebservices\"
    Private Lista As ArrayList = New ArrayList()
    Private Dias As String() = New String(1) {"SÁBADO", "DOMINGO"}
    Private HorarioEstadoLiquidacion As String() = New String(8) {"09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00"}
    Private rownumber2 As Integer = 0
    Private strdate As String = ""
    Private struser As String = "BVRDADM"
    Private strcode As String = ""
    Private strnumero As String = ""
    Private strmensaje As String = ""
    Private strguid As String = ""
    Private webResponse1 As HttpWebResponse = Nothing
    Private errorCode As Integer = 0
    Private errorCodeDescription As String = ""
    Private txtUserName As String = "bvrd\soportetecnico3"
    Private txtPassword As String = "Sop##bv6697"
    Private ESTATUS As String
    Private ORIGEN As String
    Private VENDEDOR As String
    Private COMPRADOR As String
    Private MECANISMO As String
    Private MODALIDAD As Int64
    Private REFERENCIA As String
    Private PACTADA As String
    Private PROCESO As Int64
    Private SOLICITUD As Int64
    Private OPERACION As String
    Private TRN As String
    Private VINCULADA As String
    Private INCUMPLIMIENTO As String
    Private ESTADO As String
    Private Cadena As ArrayList = New ArrayList()
    Private RESPUESTA As String
    Private CONTADO As String
    Private PLAZO As String
    Private strCadena As String
    Private HoraMercadoInicial As Integer = 7
    Private HoraMercadoFinal As Integer = 25
    Public Fecha As String = ""
    Public TipoFecha As String = ""

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        If Not IsPostBack Then
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Operaciones", "Consulta de Operaciones", "")
            txtIdUsuario.Text = Session("IdUsuario")
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            ' Iniciar con la fecha del día 
            Dim FechaOperacion As Date = oper.ExecuteScalar("Select Top(1) fecha_oper from [vConsultaOperacionesCSV] order by fecha_oper desc")
            cStringWhere = String.Format("[fecha_oper]='{0}'", FechaOperacion)

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            'Filtro por defecto 
            Dim editor As New RadFilterTextFieldEditor()
            RadFilter1.FieldEditors.Add(editor)
            If Not IsPostBack Then
                editor.FieldName = "Fecha operación"
                editor.DataType = GetType(Date)

                Dim expr As New RadFilterEqualToFilterExpression(Of Date)("fecha_oper")
                'Fecha = oper.FormatoFechayymmdd(FechaOperacion)
                Fecha = Convert.ToDateTime(FechaOperacion).ToString("dd/MM/yyyy")
                expr.Value = Fecha
                TipoFecha = "REGISTRO"
                RadFilter1.RootGroup.Expressions.Add(expr)
            End If

            txtIdConsulta.Text = 0
            RadFilter1.ApplyButtonText = "Aplicar Filtro"
            LlenarInformacionListaFiltros()
            DataRefresh()
        End If

        If Request.Params("__EVENTTARGET") = "ActualizarFiltros" Then
            LlenarInformacionListaFiltros1()
            If Session("NombreConsultaTemp") <> "" Then
                txtNombreConsultaUsuario.Text = Session("NombreConsultaTemp")
                CargarInformacionFiltro(Session("NombreConsultaTemp"))
                Session.Remove("NombreConsultaTemp")
            End If
            RadWindowManager1.Windows.Clear()
            Exit Sub
        End If
        If Session("FiltroBorrado") = 1 Then
            txtIdConsulta.Text = 0
            txtNombreConsultaUsuario.Text = ""
            Session.Remove("FiltroBorrado")
        End If
        If txtNombreConsultaUsuario.Text <> "" Then
            Page.Header.Title = "Consulta de operaciones -> " & txtNombreConsultaUsuario.Text
        End If

        'InjectScriptLabelImprimir.Text = "<script>MensajePopup('" + "URL:  # voy ')</" + "script>"
    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick, RadToolBar2.ButtonClick


        If e.Item.Value <> "" Then
            If e.Item.Value = 0 Then 'Mover
                InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Consultas/ConsultaOperaciones.aspx','1000','600')</" + "script>"
            ElseIf e.Item.Value = 1 Then 'Cancelar
                InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
            ElseIf e.Item.Value = 2 Then 'Guardar
                Dim SavePersister As New GridSettingsPersister(RadGrid1)
                Dim cSettingGrid As String = ""

                cSettingGrid = SavePersister.SaveSettings()
                Session("EstruturaGrid") = SavePersister.SaveSettings()
                Session("Filtro") = RadFilter1.SaveSettings()
                Dim MyWindow As New RadWindow
                MyWindow.NavigateUrl = String.Format("NombreConsultaUsuario.aspx?ID={0}&NC=ConsultaOperaciones&U={1}&NCU={2}", txtIdConsulta.Text, txtIdUsuario.Text, txtNombreConsultaUsuario.Text) '& "&F=" & RadFilter1.SaveSettings()
                MyWindow.VisibleOnPageLoad = True
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            ElseIf e.Item.Value = 4 Then 'Exportar excel

                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With

                RadGrid1.MasterTableView.ExportToExcel()

            ElseIf e.Item.Value = 5 Then 'Exportar pdf
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With
                RadGrid1.MasterTableView.ExportToPdf()

            ElseIf e.Item.Value = 6 Then 'Exportar csv
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With
                RadGrid1.MasterTableView.ExportToCSV()
            ElseIf e.Item.Value = 12 Then 'Exportar csv
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With
                Call GenXMLforOperationCEVALDOM()

            End If
        Else
            If e.Item.Text <> "" Then
                txtNombreConsultaUsuario.Text = e.Item.Text
                Page.Header.Title = "Consulta de operaciones -> " & e.Item.Text
                CargarInformacionFiltro(e.Item.Text)
            End If
        End If
    End Sub

    Public Sub LimpiarVariables()
        ESTATUS = ""
        VENDEDOR = ""
        COMPRADOR = ""
        MECANISMO = ""
        MODALIDAD = 0
        REFERENCIA = ""
        PACTADA = ""
        PROCESO = 0
        SOLICITUD = 0
        OPERACION = ""
        TRN = ""
        ESTADO = ""
    End Sub

    Public Sub SendMail(ByVal Subject As String, ByVal Body As String, ByVal Attachments As String)
        'Dim server As String = Environment.MachineName.ToString()
        'Subject = server & " : " & Subject
        'Dim MailClient As SmtpClient = New SmtpClient(ConfigurationManager.AppSettings("MailClient").ToString(), ConfigurationManager.AppSettings("Port").ToString())
        'Dim From As String = ConfigurationManager.AppSettings("From").ToString()
        'Dim [To] As String = ConfigurationManager.AppSettings("To").ToString()
        'Dim AuthUsername As String = ConfigurationManager.AppSettings("AuthUsername").ToString()
        'Dim AuthPassword As String = ConfigurationManager.AppSettings("AuthPassword").ToString()

        'MailClient.DeliveryMethod = SmtpDeliveryMethod.Network
        'MailClient.Credentials = New System.Net.NetworkCredential(AuthUsername, AuthPassword)

        'Dim MailMessage = New MailMessage(From, [To], Subject, Body)
        'MailMessage.IsBodyHtml = True
        'MailClient.EnableSsl = False

        'If (Attachments.ToString() <> "") Then
        '    MailMessage.Attachments.Add(New Attachment(Attachments))
        'End If

        'MailClient.Send(MailMessage)
        'MailClient.Dispose()
        'MailMessage.Dispose()
    End Sub

    Public Sub EstadoOperacionLiquidacionCevaldom(ByVal ESTATUS As String, ByVal VENDEDOR As String, ByVal COMPRADOR As String, ByVal MECANISMO As String, ByVal MODALIDAD As Int64, ByVal REFERENCIA As String, ByVal PACTADA As String, ByVal PROCESO As Int64, ByVal SOLICITUD As Int64, ByVal OPERACION As String, ByVal TRN As String, ByVal CONTADO As String, ByVal PLAZO As String, ByVal ESTADO As String, ByVal VINCULADA As String, ByVal INCUMPLIMIENTO As String, ByVal ORIGEN As String, ESTADOPLAZO As String, OPERACIONPLAZO As String)
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() 'ConectionString

            Using con As SqlConnection = New SqlConnection(strString)

                Using cmd As SqlCommand = New SqlCommand("P_SUBE_XML_EstadoOperacionLiquidacion_CEVALDOM", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    con.Open()
                    cmd.Parameters.Add("@ESTATUS", SqlDbType.VarChar).Value = ESTATUS
                    cmd.Parameters.Add("@VENDEDOR", SqlDbType.VarChar).Value = VENDEDOR
                    cmd.Parameters.Add("@COMPRADOR", SqlDbType.VarChar).Value = COMPRADOR
                    cmd.Parameters.Add("@MECANISMO", SqlDbType.VarChar).Value = MECANISMO
                    cmd.Parameters.Add("@MODALIDAD", SqlDbType.Int).Value = MODALIDAD
                    cmd.Parameters.Add("@REFERENCIA", SqlDbType.VarChar).Value = REFERENCIA

                    If String.IsNullOrEmpty(PACTADA) Then
                        PACTADA = ""
                    End If

                    cmd.Parameters.Add("@PACTADA", SqlDbType.VarChar).Value = PACTADA
                    cmd.Parameters.Add("@PROCESO", SqlDbType.Int).Value = PROCESO
                    cmd.Parameters.Add("@SOLICITUD", SqlDbType.Int).Value = SOLICITUD
                    cmd.Parameters.Add("@OPERACION", SqlDbType.VarChar).Value = OPERACION
                    cmd.Parameters.Add("@TRN", SqlDbType.VarChar).Value = TRN
                    cmd.Parameters.Add("@CONTADO", SqlDbType.VarChar).Value = CONTADO
                    cmd.Parameters.Add("@PLAZO", SqlDbType.VarChar).Value = PLAZO
                    cmd.Parameters.Add("@ESTADO_CONTADO", SqlDbType.VarChar).Value = ESTADO
                    cmd.Parameters.Add("@VINCULADA", SqlDbType.VarChar).Value = VINCULADA
                    cmd.Parameters.Add("@INCUMPLIMIENTO", SqlDbType.VarChar).Value = INCUMPLIMIENTO
                    cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar).Value = ORIGEN
                    cmd.Parameters.Add("@ESTADO_PLAZO", SqlDbType.VarChar).Value = ESTADOPLAZO
                    cmd.Parameters.Add("@OPERACION_PLAZO", SqlDbType.VarChar).Value = OPERACIONPLAZO
                    Dim result As Integer = cmd.ExecuteNonQuery()
                    con.Dispose()
                    LimpiarVariables()
                End Using
            End Using

        Catch ex As Exception
            _strbody = "Webservice Money Market - Error: " & ex.Message.ToString() & " " & "; NOTA: SUBIENDO EL ESTADO DE LAS OPERACION DE CEVALDOM DE LA SOLICITUD # " & SOLICITUD.ToString()
            _strfilename = ""
            SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
        End Try
    End Sub

    Public Function DsObtieneCodigo(ByVal Mecanismo As String) As DataSet
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() ' ConectionString

            Using con As SqlConnection = New SqlConnection(strString)

                Using cmd As SqlCommand = New SqlCommand("P_GEN_CEVALDOM_OPER_CODIGO", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@Mecanismo", SqlDbType.VarChar).Value = Mecanismo
                    con.Open()
                    Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
                    adp.Fill(ds)
                End Using
            End Using

            Return ds
        Catch ex As Exception
            _strbody = "Webservice Money Market - Error: " & ex.Message.ToString() & " " & "; NOTA:  CONSULTANDO LA BASE DE DATOS "
            _strfilename = ""
            SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
            Return ds
        End Try
    End Function

    Public Function RandomNumber(ByVal Mecanismo As String) As Integer
        Dim rownumber As Integer = 0
        Dim ds As DataSet = DsObtieneCodigo(Mecanismo)
        rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())

        If Lista.Contains(rownumber) Then
            ds = DsObtieneCodigo(Mecanismo)
            rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())

            If rownumber2 = rownumber Then
                ds = DsObtieneCodigo(Mecanismo)
                rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())
            End If
        End If

        Lista.Add(rownumber)

        If Lista.Count = 10 Then
            Lista.Clear()
            rownumber2 = 0
            ds = DsObtieneCodigo(Mecanismo)
            rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())
        End If

        rownumber2 = rownumber

        If (rownumber2 - 1) = rownumber Then
            rownumber = rownumber + 1

            If rownumber > 9 Then
                ds = DsObtieneCodigo(Mecanismo)
                rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())
            End If

            Lista.Add(rownumber)
        End If

        Console.WriteLine("CODIGO RANDOM: " & rownumber.ToString())
        Return rownumber
    End Function

    'Method para Actualizar estado operaciones
    Public Sub EstadosOperacionesWS(ByVal Mecanismo As String)

        If Fecha.ToString() <> "" Then
            Dim horaMercado As Integer = -1
            Dim Hoy As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            Dim NombredelDia As String = Hoy.ToString("dddd", New CultureInfo("es-ES")).ToUpper()
            Dim ValidaFindeSemana As Boolean = Dias.Contains(NombredelDia)
            Dim horaEstado As String = Convert.ToString(DateTime.Now.ToString("HH:mm"))
            Dim ValidaHorarioEstadoLiq As Boolean = HorarioEstadoLiquidacion.Contains(horaEstado.ToString())
            horaMercado = Convert.ToInt16(DateTime.Now.ToString("HH"))
            ' Console.Write(ValidaHorarioEstadoLiq.ToString())

            If ValidaFindeSemana = False Then
                If horaMercado > HoraMercadoInicial AndAlso horaMercado < HoraMercadoFinal Then
                    Dim i As Integer = 0
                    Dim dt As DataTable = New DataTable()
                    dt.Columns.AddRange(New DataColumn(2) {New DataColumn("CODIGO", GetType(String)), New DataColumn("NUMERO", GetType(String)), New DataColumn("GUID", GetType(Int64))})

                    If (Mecanismo = "BVRD") Then
                        struser = "BVRDADM"
                        dt.Rows.Add()
                        dt.Rows(0)("CODIGO") = "0"
                        dt.Rows(0)("NUMERO") = "9936"
                        dt.Rows(0)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(1)("CODIGO") = "1"
                        dt.Rows(1)("NUMERO") = "8576"
                        dt.Rows(1)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(2)("CODIGO") = "2"
                        dt.Rows(2)("NUMERO") = "9350"
                        dt.Rows(2)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(3)("CODIGO") = "3"
                        dt.Rows(3)("NUMERO") = "8116"
                        dt.Rows(3)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(4)("CODIGO") = "4"
                        dt.Rows(4)("NUMERO") = "9825"
                        dt.Rows(4)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(5)("CODIGO") = "5"
                        dt.Rows(5)("NUMERO") = "2819"
                        dt.Rows(5)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(6)("CODIGO") = "6"
                        dt.Rows(6)("NUMERO") = "7789"
                        dt.Rows(6)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(7)("CODIGO") = "7"
                        dt.Rows(7)("NUMERO") = "9277"
                        dt.Rows(7)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(8)("CODIGO") = "8"
                        dt.Rows(8)("NUMERO") = "8652"
                        dt.Rows(8)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(9)("CODIGO") = "9"
                        dt.Rows(9)("NUMERO") = "2391"
                        dt.Rows(9)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                    End If

                    If (Mecanismo = "MHRD") Then
                        struser = "SEHADM"
                        dt.Rows.Add()
                        dt.Rows(0)("CODIGO") = "0"
                        dt.Rows(0)("NUMERO") = "6745"
                        dt.Rows(0)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(1)("CODIGO") = "1"
                        dt.Rows(1)("NUMERO") = "9861"
                        dt.Rows(1)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(2)("CODIGO") = "2"
                        dt.Rows(2)("NUMERO") = "4724"
                        dt.Rows(2)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(3)("CODIGO") = "3"
                        dt.Rows(3)("NUMERO") = "3367"
                        dt.Rows(3)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(4)("CODIGO") = "4"
                        dt.Rows(4)("NUMERO") = "6913"
                        dt.Rows(4)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(5)("CODIGO") = "5"
                        dt.Rows(5)("NUMERO") = "2001"
                        dt.Rows(5)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(6)("CODIGO") = "6"
                        dt.Rows(6)("NUMERO") = "4594"
                        dt.Rows(6)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(7)("CODIGO") = "7"
                        dt.Rows(7)("NUMERO") = "7344"
                        dt.Rows(7)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(8)("CODIGO") = "8"
                        dt.Rows(8)("NUMERO") = "7133"
                        dt.Rows(8)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                        dt.Rows.Add()
                        dt.Rows(9)("CODIGO") = "9"
                        dt.Rows(9)("NUMERO") = "9565"
                        dt.Rows(9)("GUID") = System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                    End If


                    Try
                        Dim rownumber As Integer = RandomNumber(Mecanismo)
                        strdate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
                        strcode = dt.Rows(rownumber)("CODIGO").ToString()
                        strnumero = dt.Rows(rownumber)("NUMERO").ToString()
                        strguid = dt.Rows(rownumber)("GUID").ToString()
                        strmensaje = struser.ToString().Trim() & strdate.ToString().Trim()
                        Dim encoding As ASCIIEncoding = New ASCIIEncoding()
                        Dim textBytes As Byte() = encoding.GetBytes(strmensaje)
                        Dim len As Integer = ASCIIEncoding.[Default].GetByteCount(strnumero.ToString().Trim())
                        Dim keyBytes As Byte() = encoding.GetBytes(strnumero.ToString().Trim())
                        Dim hashBytes As Byte()

                        Using hash As HMACSHA256 = New HMACSHA256(keyBytes)
                            hashBytes = hash.ComputeHash(textBytes)
                        End Using

                        strtoken = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()

                        'Dim Hoy1 As DateTime = DateTime.ParseExact(Fecha, "MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture)
                        'Dim FechaInicial As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()
                        'Dim FechaFinal As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()

                        Dim Hoy1 As String = Fecha ' Convert.ToDateTime(Fecha).ToString("dd/MM/yyyy")
                        Dim FechaInicial As String = Hoy1.ToUpper()
                        Dim FechaFinal As String = Hoy1.ToUpper()


                        'Produccion
                        'Dim url As String = "https://cvdpserver.local/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                        'Desarrollo
                        'Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                        Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString() & "&MECANISMO=" & Mecanismo & "&TipoFecha=" & TipoFecha
                        ' Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString() & "&MECANISMO=BVRD" & "&TipoFecha=REGISTRO"

                        'Dim url As String = "http://api.cevaldom.com/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()

                        ' ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                        ' ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

                        'ByPass SSL Certificate Validation Checking
                        'System.Net.ServicePointManager.ServerCertificateValidationCallback =
                        'Function(se As Object,
                        'cert As System.Security.Cryptography.X509Certificates.X509Certificate,
                        'chain As System.Security.Cryptography.X509Certificates.X509Chain,
                        'sslerror As System.Net.Security.SslPolicyErrors) True

                        'Call web application/web service with HTTPS URL

                        'Restore SSL Certificate Validation Checking
                        'System.Net.ServicePointManager.ServerCertificateValidationCallback = Nothing

                        'ServicePointManager.Expect100Continue = True
                        'Const _Tls12 As SslProtocols = DirectCast(&HC00, SslProtocols)
                        'Const Tls12 As SecurityProtocolType = DirectCast(_Tls12, SecurityProtocolType)
                        'ServicePointManager.SecurityProtocol = Tls12
                        'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3

                        ' Or SecurityProtocolType.Ssl3
                        'ServicePointManager.Expect100Continue = True
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3
                        ' System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3
                        'ServicePointManager.ServerCertificateValidationCallback = Function(snder, cert, chain, [error]) True
                        Dim request As HttpWebRequest = TryCast(WebRequest.Create(url), HttpWebRequest)
                        'Dim request As HttpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
                        request.Credentials = CredentialCache.DefaultCredentials
                        request.Method = "GET"
                        Dim priMethod As MethodInfo = request.Headers.[GetType]().GetMethod("AddWithoutValidate", BindingFlags.Instance Or BindingFlags.NonPublic)
                        priMethod.Invoke(request.Headers, {"user", struser.ToString()})
                        priMethod.Invoke(request.Headers, {"code", strcode.ToString()})
                        Dim mydate As Object() = New Object(1) {}
                        mydate(0) = "date"
                        mydate(1) = strdate
                        priMethod.Invoke(request.Headers, mydate)
                        priMethod.Invoke(request.Headers, {"token", strtoken.ToString()})
                        priMethod.Invoke(request.Headers, {"Accept", "application/json;charset=UTF-8"})
                        priMethod.Invoke(request.Headers, {"Content-Type", "application/xml;charset=UTF-8"})
                        priMethod.Invoke(request.Headers, {"User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36"})

                        'Dim allowUntrustedCertificates As Boolean = False
                        ' Dim oldCallback = ServicePointManager.ServerCertificateValidationCallback
                        'If allowUntrustedCertificates Then
                        '    ServicePointManager.ServerCertificateValidationCallback = (Function(Sender, certification, chain, sslPolicyErrors) True)
                        'End If

                        ''AddHandler System.Net.ServicePointManager.ServerCertificateValidationCallback, Function(se, cert, chain, sslerror) True
                        'ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

                        Dim webResponse As WebResponse = Nothing
                        ' webResponse = CType(request.GetResponse(), HttpWebResponse)
                        Try
                            webResponse = CType(request.GetResponse(), HttpWebResponse)
                            errorCodeDescription = (CType(webResponse, HttpWebResponse)).StatusDescription.ToString()
                        Catch ex3 As WebException
                            'Response.Write("Fallo dentro del TRY: " + ex3.Message.ToString())
                        End Try
                        If webResponse IsNot Nothing Then

                            Using responseStream As Stream = webResponse.GetResponseStream()
                                If responseStream IsNot Nothing AndAlso responseStream IsNot Stream.Null Then
                                    Using streamReader As StreamReader = New StreamReader(responseStream)
                                        Dim responseText As String = streamReader.ReadToEnd()

                                        'Dim jObj As JObject =
                                        'Dim soloPerArray As JArray = jObj("Cuerpo")("SOLOPER")
                                        'Dim table1 = JsonConvert.DeserializeObject(soloPerArray).ToObject(Of DataTable)()
                                        'Dim jObject1 As JObject = New JObject(soloPerArray.Children())
                                        'dtRespuestaCevaldom = jObj("Cuerpo")("ConOperaciones").ToObject(Of DataTable)()

                                        'INICIO
                                        'Datos del Estatus
                                        dtRespuestaCevaldom.Columns.Clear()
                                        dtRespuestaCevaldom.Columns.Add("Estatus", GetType(String))
                                        'Datos de la Negociación
                                        dtRespuestaCevaldom.Columns.Add("NegociacionORIGEN", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionVENDEDOR", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionCOMPRADOR", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionMECANISMO", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionMODALIDAD", GetType(Integer))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionREFERENCIA", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionACORDADA", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionHORA", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionSOLICITUD", GetType(Integer))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionINCUMPLIMIENTO", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionTRN", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionOPERACION", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionVINCULADA", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionESTADO", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionOTCApp", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("NegociacionOBSERVACIONES", GetType(String))

                                        'Datos de la Liquidación
                                        dtRespuestaCevaldom.Columns.Add("ContadoESQUEMA", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("ContadoTIPO", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("ContadoLIQUIDACION", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("ContadoISIN", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("ContadoMONEDA", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("ContadoESTADO", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("ContadoFACIAL", GetType(Decimal))
                                        dtRespuestaCevaldom.Columns.Add("ContadoCANTIDAD", GetType(Integer))
                                        dtRespuestaCevaldom.Columns.Add("ContadoLIMPIO", GetType(Decimal))
                                        dtRespuestaCevaldom.Columns.Add("ContadoSUCIO", GetType(Decimal))
                                        dtRespuestaCevaldom.Columns.Add("ContadoRENDIMIENTO", GetType(Decimal))
                                        dtRespuestaCevaldom.Columns.Add("ContadoIMPORTE", GetType(Decimal))

                                        'Datos del Plazo
                                        dtRespuestaCevaldom.Columns.Add("PlazoDIAS", GetType(Integer))
                                        dtRespuestaCevaldom.Columns.Add("PlazoLIQUIDACION", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("PlazoESTADO", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("PlazoCANTIDAD", GetType(Integer))
                                        dtRespuestaCevaldom.Columns.Add("PlazoLIMPIO", GetType(Decimal))
                                        dtRespuestaCevaldom.Columns.Add("PlazoSUCIO", GetType(Decimal))
                                        dtRespuestaCevaldom.Columns.Add("PlazoRENDIMIENTO", GetType(Decimal))
                                        dtRespuestaCevaldom.Columns.Add("PlazoIMPORTE", GetType(Integer))

                                        'Datos de las cuentas
                                        dtRespuestaCevaldom.Columns.Add("CUENTA_VENDEDOR", GetType(String))
                                        dtRespuestaCevaldom.Columns.Add("CUENTA_COMPRADOR", GetType(String))

                                        'Datos del digito verificador
                                        dtRespuestaCevaldom.Columns.Add("VERIFICADOR", GetType(Integer))

                                        Dim jsonObj As JObject = JObject.Parse(responseText)
                                        Dim soloPerArray As JArray = jsonObj("Cuerpo")("SOLOPER")
                                        Dim Estado As String = ""

                                        ' dtRespuestaCevaldom = jsonObj("Cuerpo")("SOLOPER").ToObject(Of DataTable)()
                                        For Each soloPer As JObject In soloPerArray
                                            Dim row As DataRow = dtRespuestaCevaldom.NewRow()
                                            Dim estatus As String = jsonObj("Estatus").ToString()
                                            Dim negociacion As JObject = soloPer("Negociacion")
                                            Dim liquidacionContado As JObject = soloPer("Liquidacion")("Contado")
                                            Dim liquidacionPlazo As JObject = soloPer("Liquidacion")("Plazo")
                                            Dim cuentasVendedor As JObject = soloPer("Cuentas")("Vendedor")
                                            Dim cuentasComprador As JObject = soloPer("Cuentas")("Comprador")

                                            'Datos del Estatus
                                            row("Estatus") = estatus

                                            'Datos de la Negociación
                                            row("NegociacionORIGEN") = negociacion("ORIGEN")
                                            row("NegociacionVENDEDOR") = negociacion("VENDEDOR")
                                            row("NegociacionCOMPRADOR") = negociacion("COMPRADOR")
                                            row("NegociacionMECANISMO") = negociacion("MECANISMO")
                                            row("NegociacionMODALIDAD") = negociacion("MODALIDAD")
                                            row("NegociacionREFERENCIA") = negociacion("REFERENCIA")
                                            row("NegociacionACORDADA") = negociacion("ACORDADA")
                                            row("NegociacionHORA") = negociacion("HORA")
                                            row("NegociacionSOLICITUD") = negociacion("SOLICITUD")
                                            row("NegociacionINCUMPLIMIENTO") = negociacion("INCUMPLIMIENTO")
                                            row("NegociacionTRN") = negociacion("TRN")
                                            row("NegociacionOPERACION") = negociacion("OPERACION")
                                            row("NegociacionVINCULADA") = negociacion("VINCULADA")
                                            row("NegociacionESTADO") = negociacion("ESTADO")
                                            row("NegociacionOTCApp") = negociacion("OTCApp")
                                            row("NegociacionOBSERVACIONES") = negociacion("OBSERVACIONES")

                                            'Datos de la Liquidacion= spot
                                            row("ContadoESQUEMA") = liquidacionContado("ESQUEMA")
                                            row("ContadoTIPO") = liquidacionContado("TIPO")
                                            row("ContadoLIQUIDACION") = liquidacionContado("LIQUIDACION")
                                            row("ContadoISIN") = liquidacionContado("ISIN")
                                            row("ContadoMONEDA") = liquidacionContado("MONEDA")
                                            row("ContadoESTADO") = liquidacionContado("ESTADO")
                                            row("ContadoFACIAL") = liquidacionContado("FACIAL")
                                            row("ContadoCANTIDAD") = liquidacionContado("CANTIDAD")
                                            row("ContadoLIMPIO") = liquidacionContado("LIMPIO")
                                            row("ContadoSUCIO") = liquidacionContado("SUCIO")
                                            row("ContadoRENDIMIENTO") = liquidacionContado("RENDIMIENTO")
                                            row("ContadoIMPORTE") = liquidacionContado("IMPORTE")

                                            'Datos de la Plazo = Foward
                                            row("PlazoDIAS") = liquidacionPlazo("DIAS")
                                            row("PlazoLIQUIDACION") = liquidacionPlazo("LIQUIDACION")
                                            row("PlazoESTADO") = liquidacionPlazo("ESTADO")
                                            row("PlazoCANTIDAD") = liquidacionPlazo("CANTIDAD")
                                            row("PlazoLIMPIO") = liquidacionPlazo("LIMPIO")
                                            row("PlazoSUCIO") = liquidacionPlazo("SUCIO")
                                            row("PlazoRENDIMIENTO") = liquidacionPlazo("RENDIMIENTO")
                                            row("PlazoIMPORTE") = liquidacionPlazo("IMPORTE")

                                            'Datos de las cuentas
                                            row("CUENTA_VENDEDOR") = cuentasVendedor("CUENTA")
                                            row("CUENTA_COMPRADOR") = cuentasComprador("CUENTA")

                                            'Datos del digito verificador
                                            row("VERIFICADOR") = soloPer("VERIFICADOR")
                                            Estado = row("ContadoESTADO").ToString()

                                            dtRespuestaCevaldom.Rows.Add(row)

                                            EstadoOperacionLiquidacionCevaldom(row("Estatus"),
                                                                           row("NegociacionVENDEDOR"),
                                                                           row("NegociacionCOMPRADOR"),
                                                                           row("NegociacionMECANISMO"),
                                                                           row("NegociacionMODALIDAD"),
                                                                           row("NegociacionREFERENCIA"),
                                                                           row("NegociacionACORDADA"),
                                                                           row("NegociacionSOLICITUD"),
                                                                           row("NegociacionSOLICITUD"),
                                                                           row("NegociacionOPERACION"),
                                                                           row("NegociacionTRN"),
                                                                           row("ContadoLIQUIDACION"),
                                                                           row("PlazoLIQUIDACION"),
                                                                           Estado,  ' CONTADO =Spot / Plazo=Forward
                                                                           row("NegociacionVINCULADA"),
                                                                           row("NegociacionINCUMPLIMIENTO"),
                                                                           row("NegociacionORIGEN"),
                                                                           row("PlazoESTADO"),
                                                                           row("NegociacionOPERACION"))

                                        Next
                                        ' FIN 
                                    End Using
                                End If
                            End Using

                        End If
                    Catch ex2 As WebException
                        Response.Write(ex2.Message.ToString())
                    End Try

                End If
            End If
        End If
    End Sub

    ' Method para generar XML Liquidaciones CEVALDOM
    Protected Sub GenXMLforOperationCEVALDOM()
        If (txtfecha.Value <> 0) Then
            Dim dt As DataTable = New DataTable()
            dt.Columns.Add("NUMERO_OPERACION")
            dt.Columns.Add("ID_CONSECUTIVO_OPERACION")
            dt.Columns.Add("FECHA_TRANSACCION")
            dt.Columns.Add("FECHA_LIQUIDACION")
            dt.Columns.Add("INDICADOR_OPERACION")
            dt.Columns.Add("ID_DEPOSITANTE_COMPRADOR")
            dt.Columns.Add("ID_DEPOSITANTE_VENDEDOR")
            dt.Columns.Add("CUENTA_COMPRADOR", GetType(String))
            dt.Columns.Add("CUENTA_VENDEDOR", GetType(String))
            dt.Columns.Add("ID_MONEDA_EMISION")
            dt.Columns.Add("ID_MONEDA_LIQUIDACION")
            dt.Columns.Add("CODIGO_ISIN")
            dt.Columns.Add("CANTIDAD_TITULOS")
            dt.Columns.Add("PRECIO_PRIMA")
            dt.Columns.Add("TIPO_CAMBIO")
            dt.Columns.Add("IMPORTE_BRUTO")

            Dim ds1 As DataSet = New DataSet()
            Dim tbloperaciones As DataTable
            Dim boConn As Connection.Connection.DBConnection = New Connection.Connection.DBConnection()

            Dim FechaFiltrada1 As String = FechaFiltrada.ToString().Substring(17, 22)
            FechaFiltrada1 = FechaFiltrada1.Replace(" 12:00:00 a.m.", "")
            Dim Sqltext As String = "SELECT  * FROM vConsultaOperacionesCSV where fecha_oper = '" + FechaFiltrada1.ToString() + "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(Sqltext.ToString(), boConn.getConnectionString)

            da.Fill(ds1, "operaciones")
            tbloperaciones = ds1.Tables("operaciones")
            For i = 0 To tbloperaciones.Rows.Count - 1
                Dim dr As DataRow = dt.NewRow()
                'For Each row As DataRow In dv.Table.Rows 
                dr("NUMERO_OPERACION") = tbloperaciones.Rows(i)("num_oper").ToString()
                dr("ID_CONSECUTIVO_OPERACION") = tbloperaciones.Rows(i)("Secuencia_Operacion").ToString()
                dr("FECHA_TRANSACCION") = tbloperaciones.Rows(i)("fecha_oper").ToString()
                dr("FECHA_LIQUIDACION") = tbloperaciones.Rows(i)("fecha_liquid").ToString()
                dr("INDICADOR_OPERACION") = tbloperaciones.Rows(i)("mercado").ToString()
                dr("ID_DEPOSITANTE_COMPRADOR") = tbloperaciones.Rows(i)("pues_comp").ToString()
                dr("ID_DEPOSITANTE_VENDEDOR") = tbloperaciones.Rows(i)("pues_vend").ToString()
                dr("ID_MONEDA_EMISION") = tbloperaciones.Rows(i)("mone_trans").ToString()
                dr("ID_MONEDA_LIQUIDACION") = tbloperaciones.Rows(i)("ID_MONEDA_LIQUIDACION").ToString()
                dr("CODIGO_ISIN") = tbloperaciones.Rows(i)("cod_isin").ToString()
                dr("CANTIDAD_TITULOS") = tbloperaciones.Rows(i)("cant_tit").ToString()
                dr("PRECIO_PRIMA") = tbloperaciones.Rows(i)("precio_limp").ToString()
                dr("TIPO_CAMBIO") = 1
                dr("IMPORTE_BRUTO") = tbloperaciones.Rows(i)("IMPORTE_BRUTO").ToString()
                dt.Rows.Add(dr)
            Next


            Dim ds As New DataSet
            ds.DataSetName = "file"
            ds.Tables.Add(dt)
            ds.Tables(0).TableName = "operbvrd"
            Dim FileName As String

            FileName = "FORMATO_1_CEVALDOM" & txtfecha.Value & ".xml"

            Dim strFullPath As String = Server.MapPath("~/tmp/" + FileName)
            ds.WriteXml(strFullPath)
            Dim strContents As String = Nothing
            Dim objReader As System.IO.StreamReader = Nothing

            objReader = New System.IO.StreamReader(strFullPath, Encoding.UTF8)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Dim attachment As String = "attachment; filename=" & FileName
            Response.ClearContent()
            Response.ContentType = "application/xml; charset=utf-8"
            Response.AddHeader("content-disposition", attachment)
            Response.Write(strContents)
            Response.[End]()
        End If

    End Sub

    Protected Sub CargarInformacionFiltro(cNombreConsultaUsuario As String)
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT idConsulta,Filtro, EstruturaGrid FROM  [vFiltrosConsultas]  where NombreConsultaUsuario='{0}' AND IdUsuario='{1}' AND NombreConsulta='ConsultaOperaciones'", cNombreConsultaUsuario, txtIdUsuario.Text))
        Dim MyRow As DataRow
        Dim cStringFiltro As String = ""
        Dim cSettingGrid As String = ""
        Dim LoadPersister As New GridSettingsPersister(RadGrid1)

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("idConsulta")) Then txtIdConsulta.Text = Trim(MyRow.Item("idConsulta"))
            If Not IsDBNull(MyRow.Item("Filtro")) Then cStringFiltro = Trim(MyRow.Item("Filtro"))
            If Not IsDBNull(MyRow.Item("EstruturaGrid")) Then cSettingGrid = Trim(MyRow.Item("EstruturaGrid"))
        Next
        If cStringFiltro.Trim <> "" Then
            RadToolBar1.Items.Item(5).Text = cNombreConsultaUsuario
            With RadFilter1
                .LoadSettings(cStringFiltro)
                .RecreateControl()
                .FireApplyCommand()
            End With
        End If

        If cSettingGrid.Trim <> "" Then
            LoadPersister.LoadSettings(cSettingGrid)
            RadGrid1.Rebind()
        End If
    End Sub

    Protected Sub LlenarInformacionListaFiltros()
        'Carga cuando inicia la pagina
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [vFiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaOperaciones'", txtIdUsuario.Text))
        Dim MyRow As DataRow
        Dim cStringFiltro As String = ""
        Dim dropDownFiltro As RadToolBarDropDown = New RadToolBarDropDown("Ver Consultas")
        RadToolBar1.Items.Add(dropDownFiltro)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each MyRow In ds.Tables(0).Rows
                If Not IsDBNull(MyRow.Item("NombreConsultaUsuario")) Then cStringFiltro = Trim(MyRow.Item("NombreConsultaUsuario"))
                AgregarBotones(dropDownFiltro, cStringFiltro)
            Next
        End If
    End Sub

    Protected Sub LlenarInformacionListaFiltros1()
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [FiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaOperaciones' ORDER BY idConsulta ASC", txtIdUsuario.Text))
        Dim MyRow As DataRow
        Dim cStringFiltro As String = ""
        Dim dropDownFiltro As RadToolBarDropDown = RadToolBar1.Items.FindItemByText("Ver Consultas")
        dropDownFiltro.Buttons.Clear()

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("NombreConsultaUsuario")) Then cStringFiltro = Trim(MyRow.Item("NombreConsultaUsuario"))
            AgregarBotones(dropDownFiltro, cStringFiltro)
        Next
    End Sub

    Sub AgregarBotones(dropDownFiltro As RadToolBarDropDown, texto As String)
        Dim BotFiltros As RadToolBarButton = New RadToolBarButton(texto, False, "AlignGroup")
        dropDownFiltro.Buttons.Add(BotFiltros)
    End Sub

    Protected Sub RadFilter1_ApplyExpressions(sender As Object, e As RadFilterApplyExpressionsEventArgs) Handles RadFilter1.ApplyExpressions

        Try
            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            Dim provider As New RadFilterSqlQueryProvider()
            provider.ProcessGroup(e.ExpressionRoot)
            cStringWhere = provider.Result.Trim
            FechaFiltrada = cStringWhere

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
            DataRefresh()

        Catch ex As Exception
            Dim error1 As String = ex.InnerException.ToString()
        End Try
    End Sub

    Sub DataRefresh()

        SqlvOperacionesCSV.SelectCommandType = SqlDataSourceCommandType.StoredProcedure

        If cStringWhere.IndexOf("01/01/0001") > 0 Then
            cStringWhere = cStringWhere.Replace("01/01/0001", oper.ConvertirFechaEnAmerican(Today.Date))
        End If
        'Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}
        'Dim Fecha As Date = Date.ParseExact(provider.Result.Trim.Substring(17, 10), format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None)
        'If cStringWhere.Substring(0, 13) = "[fecha_oper]=" Then
        If cStringWhere.Substring(1, 12) = "[fecha_oper]" Then
            ' Dim Fecha1 As String = Provider.Result.Trim.Substring(17, 10)
            'Dim Fecha1 As String = cStringWhere.Trim.Substring(14, 10)
            Dim Fecha1 As String = cStringWhere.Trim.Substring(16, 11)
            'Dim FechaOperacion As String = Fecha1.Trim.Substring(6, 4) & Fecha1.Trim.Substring(0, 2) & Fecha1.Trim.Substring(3, 2)
            Dim FechaOperacion As String = Fecha1.Trim.Substring(7, 4) & Fecha1.Trim.Substring(1, 2) & Fecha1.Trim.Substring(4, 2)
            txtfecha.Value = FechaOperacion & DateTime.Now.ToString("HHmmss")
            ' Fecha = cStringWhere.Substring(16, 11)
            Fecha = Fecha1.Trim.Substring(4, 2) & "/" & Fecha1.Trim.Substring(1, 2) & "/" & Fecha1.Trim.Substring(7, 4)
            ' Fecha = Convert.ToDateTime(cStringWhere.Substring(16, 11)).ToString("dd/MM/yyyy")
            'Else
            '   Fecha = cStringWhere.Substring(17, 10)
            TipoFecha = "REGISTRO"
        End If

        If cStringWhere.Substring(1, 14) = "[fecha_liquid]" Then
            Dim Fecha1 As String = cStringWhere.Trim.Substring(19, 11)
            'Dim FechaOperacion As String = Fecha1.Trim.Substring(7, 4) & Fecha1.Trim.Substring(1, 2) & Fecha1.Trim.Substring(4, 2)
            'txtfecha.Value = FechaOperacion & DateTime.Now.ToString("HHmmss")
            Fecha = Fecha1.Trim.Substring(3, 2) & "/" & Fecha1.Trim.Substring(0, 2) & "/" & Fecha1.Trim.Substring(6, 4)
            TipoFecha = "LIQUIDACION"
        End If

        If cStringWhere.Substring(1, 14) = "[fecha_liquid]" Then
            Dim Fecha1 As String = cStringWhere.Trim.Substring(19, 11)
            'Dim FechaOperacion As String = Fecha1.Trim.Substring(7, 4) & Fecha1.Trim.Substring(1, 2) & Fecha1.Trim.Substring(4, 2)
            'txtfecha.Value = FechaOperacion & DateTime.Now.ToString("HHmmss")
            Fecha = Fecha1.Trim.Substring(3, 2) & "/" & Fecha1.Trim.Substring(0, 2) & "/" & Fecha1.Trim.Substring(6, 4)
            TipoFecha = "LIQUIDACION"
        End If

        cStringWhere = cStringWhere.Replace(" 12:00:00 a. m.", "")
        cStringWhere = cStringWhere.Replace(" 12:00:00 a.m.", "")
        SqlvOperacionesCSV.SelectParameters("SqlWhere").DefaultValue = cStringWhere
        SqlvOperacionesCSV.SelectCommand = "SP_ConsultadeOperaciones"

        ' Consulta estado de operaciones Bursatiles
        EstadosOperacionesWS("BVRD")

        ' Consulta estado de operaciones Bloomberg
        EstadosOperacionesWS("MHRD")

    End Sub

    Protected Sub RadGrid1_GroupsChanging(sender As Object, e As GridGroupsChangingEventArgs) Handles RadGrid1.GroupsChanging
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_ColumnsReorder(sender As Object, e As GridColumnsReorderEventArgs) Handles RadGrid1.ColumnsReorder
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGrid1.PageSizeChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_ExportCellFormatting(sender As Object, e As ExportCellFormattingEventArgs) Handles RadGrid1.ExportCellFormatting


        ' Formato para Valor Total
        If (e.FormattedColumn.UniqueName) = "valor_nom_tot" Then
            e.Cell.Style("mso-number-format") = "#\,##0.00"
        End If


    End Sub

End Class
