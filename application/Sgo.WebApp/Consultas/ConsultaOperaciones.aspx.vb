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



Partial Class ConsultaOperaciones
    Inherits Page
    Private oper As New operation
    Private cStringWhere As String = ""
    Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
    Dim StrFiltros As String
    Dim FechaFiltrada

    Dim _strCadena As String
    Public strtoken As String = ""
    Public _strbody As String = ""
    Public _strfilename As String = ""
    Private eventId As Integer = 1
    Public strruta As String = "\\arp12b\xml\"
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

    Public Shared ReadOnly Property ConectionString As String
        Get
            Return "Data Source=ADB00;Initial Catalog=SIOPEL_INTERFACE_DB;User ID=developer;Password=admin@123"
        End Get
    End Property

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
                Fecha = oper.FormatoFechayymmdd(FechaOperacion)
                expr.Value = Fecha
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

                ' Generar Archivo CEVALDOM para la liquidacion de Operaciones
                ' Proyecto SIOPEL Interfaces
                ' Jueves 22-May-2014 2:22 p.m
                ' Autor: Tomas Jimenez

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
        Dim server As String = Environment.MachineName.ToString()
        Subject = server & " : " & Subject
        Dim MailClient As SmtpClient = New SmtpClient("bvrd-com-do.mail.protection.outlook.com", 25)
        Dim From As String = "notificaciones@bvrd.com.do"
        Dim [To] As String = "cgomez@bvrd.com.do"
        Dim AuthUsername As String = "notificaciones@bvrd.com.do"
        Dim AuthPassword As String = "Juko6315*f2"
        MailClient.Credentials = New System.Net.NetworkCredential(From, "")
        Dim MailMessage = New MailMessage(From, [To], Subject, Body)
        MailMessage.IsBodyHtml = True

        If (Attachments.ToString() <> "") Then
            MailMessage.Attachments.Add(New Attachment(Attachments))
        End If

        MailClient.Send(MailMessage)
        MailClient.Dispose()
        MailMessage.Dispose()
    End Sub

    Public Sub EstadoOperacionLiquidacionCevaldom(ByVal ESTATUS As String, ByVal VENDEDOR As String, ByVal COMPRADOR As String, ByVal MECANISMO As String, ByVal MODALIDAD As Int64, ByVal REFERENCIA As String, ByVal PACTADA As String, ByVal PROCESO As Int64, ByVal SOLICITUD As Int64, ByVal OPERACION As String, ByVal TRN As String, ByVal CONTADO As String, ByVal PLAZO As String, ByVal ESTADO As String, ByVal VINCULADA As String, ByVal INCUMPLIMIENTO As String, ByVal ORIGEN As String)
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConectionString

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
                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = ESTADO
                    cmd.Parameters.Add("@VINCULADA", SqlDbType.VarChar).Value = VINCULADA
                    cmd.Parameters.Add("@INCUMPLIMIENTO", SqlDbType.VarChar).Value = INCUMPLIMIENTO
                    cmd.Parameters.Add("@ORIGEN", SqlDbType.VarChar).Value = ORIGEN
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

    Public Function DsObtieneCodigo() As DataSet
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConectionString

            Using con As SqlConnection = New SqlConnection(strString)

                Using cmd As SqlCommand = New SqlCommand("P_GEN_CEVALDOM_OPER_CODIGO", con)
                    cmd.CommandType = CommandType.StoredProcedure
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

    Public Function RandomNumber() As Integer
        Dim rownumber As Integer = 0
        Dim ds As DataSet = DsObtieneCodigo()
        rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())

        If Lista.Contains(rownumber) Then
            ds = DsObtieneCodigo()
            rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())

            If rownumber2 = rownumber Then
                ds = DsObtieneCodigo()
                rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())
            End If
        End If

        Lista.Add(rownumber)

        If Lista.Count = 10 Then
            Lista.Clear()
            rownumber2 = 0
            ds = DsObtieneCodigo()
            rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())
        End If

        rownumber2 = rownumber

        If (rownumber2 - 1) = rownumber Then
            rownumber = rownumber + 1

            If rownumber > 9 Then
                ds = DsObtieneCodigo()
                rownumber = Int32.Parse(ds.Tables(0).Rows(0)("codigo").ToString())
            End If

            Lista.Add(rownumber)
        End If

        Console.WriteLine("CODIGO RANDOM: " & rownumber.ToString())
        Return rownumber
    End Function

    'Method para Actualizar estado operaciones
    Public Sub EstadosOperacionesWS()




        Dim horaMercado As Integer = -1
        Dim Hoy As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        Dim NombredelDia As String = Hoy.ToString("dddd", New CultureInfo("es-ES")).ToUpper()
        Dim ValidaFindeSemana As Boolean = Dias.Contains(NombredelDia)
        Dim horaEstado As String = Convert.ToString(DateTime.Now.ToString("HH:mm"))
        Dim ValidaHorarioEstadoLiq As Boolean = HorarioEstadoLiquidacion.Contains(horaEstado.ToString())
        horaMercado = Convert.ToInt16(DateTime.Now.ToString("HH"))
        Console.Write(ValidaHorarioEstadoLiq.ToString())

        If ValidaFindeSemana = False Then

            If horaMercado > HoraMercadoInicial AndAlso horaMercado < HoraMercadoFinal Then
                Dim i As Integer = 0
                Dim dt As DataTable = New DataTable()
                dt.Columns.AddRange(New DataColumn(2) {New DataColumn("CODIGO", GetType(String)), New DataColumn("NUMERO", GetType(String)), New DataColumn("GUID", GetType(Int64))})
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

                Try
                    Dim rownumber As Integer = RandomNumber()
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
                    Dim Hoy1 As DateTime = DateTime.ParseExact(Fecha, "MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture)
                    Dim FechaInicial As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()
                    'Dim FechaInicial As String = Fecha
                    Dim FechaFinal As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()

                    'Produccion
                    'Dim url As String = "https://cvdpserver.local/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                    'Desarrollo
                    Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                    'Dim url As String = "http://prejbosrv02.cevaldom.local:8080/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()

                    Dim request As HttpWebRequest = TryCast(WebRequest.Create(url), HttpWebRequest)
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
                    priMethod.Invoke(request.Headers, {"Accept", "application/xml"})
                    priMethod.Invoke(request.Headers, {"Content-Type", "application/xml"})

                    Using response As WebResponse = request.GetResponse()

                        'poner validacion para cuando estee "none" no haga el while

                        Using stream As Stream = response.GetResponseStream()
                            Dim reader As XmlTextReader = New XmlTextReader(stream)


                            If reader.ReadString() <> "None" Then
                                While reader.Read()
                                    strCadena = ""

                                    If reader.Name <> "" Then


                                        If reader.Name = "ORIGEN" Then
                                            ORIGEN = reader.ReadString()
                                            strCadena = ORIGEN
                                        End If


                                        If reader.Name = "Estatus" Then
                                            ESTATUS = reader.ReadString()
                                            strCadena = ESTATUS
                                        End If

                                        If reader.Name = "VENDEDOR" Then
                                            VENDEDOR = reader.ReadString()
                                            strCadena = VENDEDOR
                                        End If

                                        If reader.Name = "COMPRADOR" Then
                                            COMPRADOR = reader.ReadString()
                                            strCadena = COMPRADOR
                                        End If

                                        If reader.Name = "MECANISMO" Then
                                            MECANISMO = reader.ReadString()
                                            strCadena = MECANISMO
                                        End If

                                        If reader.Name = "MODALIDAD" Then

                                            Try
                                                strCadena = reader.ReadString()

                                                If Not String.IsNullOrEmpty(strCadena) Then
                                                    MODALIDAD = Convert.ToInt64(strCadena)
                                                Else
                                                    MODALIDAD = 0
                                                End If

                                            Finally
                                            End Try
                                        End If

                                        If reader.Name = "REFERENCIA" Then
                                            REFERENCIA = reader.ReadString()
                                            strCadena = REFERENCIA
                                        End If

                                        If reader.Name = "PACTADA" Then
                                            PACTADA = reader.ReadString()
                                            strCadena = PACTADA
                                        End If

                                        If reader.Name = "PROCESO" Then

                                            Try
                                                strCadena = reader.ReadString()

                                                If Not String.IsNullOrEmpty(strCadena) Then
                                                    PROCESO = Convert.ToInt64(strCadena)
                                                Else
                                                    PROCESO = 0
                                                End If

                                            Finally
                                            End Try
                                        End If

                                        If reader.Name = "SOLICITUD" Then

                                            Try
                                                strCadena = reader.ReadString()

                                                If Not String.IsNullOrEmpty(strCadena) Then
                                                    SOLICITUD = Convert.ToInt64(strCadena)
                                                Else
                                                    SOLICITUD = 0
                                                End If

                                            Finally
                                            End Try
                                        End If

                                        If reader.Name = "OPERACION" Then
                                            OPERACION = reader.ReadString()
                                            strCadena = OPERACION
                                        End If

                                        If reader.Name = "TRN" Then
                                            TRN = reader.ReadString()
                                            strCadena = TRN
                                        End If

                                        If reader.Name = "CONTADO" Then
                                            CONTADO = reader.ReadString()
                                            strCadena = CONTADO
                                        End If

                                        If reader.Name = "INCUMPLIMIENTO" Then
                                            INCUMPLIMIENTO = reader.ReadString()
                                            strCadena = INCUMPLIMIENTO
                                        End If

                                        If reader.Name = "VINCULADA" Then
                                            VINCULADA = reader.ReadString()
                                            strCadena = VINCULADA
                                        End If

                                        If reader.Name = "PLAZO" Then
                                            PLAZO = reader.ReadString()
                                            strCadena = PLAZO
                                        End If

                                        If reader.Name = "ESTADO" Then
                                            ESTADO = reader.ReadString()
                                            strCadena = ESTADO
                                            EstadoOperacionLiquidacionCevaldom(ESTATUS, VENDEDOR, COMPRADOR, MECANISMO, MODALIDAD, REFERENCIA, PACTADA, PROCESO, SOLICITUD, OPERACION, TRN, CONTADO, PLAZO, ESTADO, VINCULADA, INCUMPLIMIENTO, ORIGEN)
                                        End If
                                    End If
                                End While
                            End If

                        End Using
                    End Using
                Catch ex As WebException
                    webResponse1 = CType(ex.Response, HttpWebResponse)
                    errorCode = CInt(webResponse1.StatusCode)

                    If errorCode <> 401 AndAlso errorCode <> 404 Then
                        _strbody = "Webservice Money Market - Error:  " & ex.Message.ToString() & " " & "; Consultando el estado de liquidacion de las operaciones "
                        _strfilename = ""
                        SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
                    End If
                End Try
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
        If cStringWhere.Substring(0, 13) = "[fecha_oper]=" Then
            ' Dim Fecha1 As String = Provider.Result.Trim.Substring(17, 10)
            Dim Fecha1 As String = cStringWhere.Trim.Substring(14, 10)
            Dim FechaOperacion As String = Fecha1.Trim.Substring(6, 4) & Fecha1.Trim.Substring(0, 2) & Fecha1.Trim.Substring(3, 2)
            txtfecha.Value = FechaOperacion & DateTime.Now.ToString("HHmmss")
            Fecha = cStringWhere.Substring(14, 10)

        Else
            Fecha = cStringWhere.Substring(17, 10)

        End If
        cStringWhere = cStringWhere.Replace(" 12:00:00 a.m.", "")
        SqlvOperacionesCSV.SelectParameters("SqlWhere").DefaultValue = cStringWhere
        SqlvOperacionesCSV.SelectCommand = "SP_ConsultadeOperaciones"
        EstadosOperacionesWS()
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
