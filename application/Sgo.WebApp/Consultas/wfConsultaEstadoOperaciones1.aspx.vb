Imports System.Globalization
Imports System.Net
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json
Imports System.Security.Cryptography
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.IO


Imports System.Xml
Imports Telerik.Web.UI
Imports FluentNHibernate.MappingModel.Collections
Imports System.Data.SqlTypes
Imports System.Windows.Forms.AxHost
Imports System.Net.Mail
Imports Telerik.Web.UI.com.hisoftware.api2
Imports System.Net.Security.SslPolicyErrors
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports Microsoft.Ajax.Utilities
Imports System.Security.Authentication

Public Class WebForm1
    Inherits System.Web.UI.Page
    'Inherits Page
    'Private oper As New operation
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

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function DsObtieneCodigo() As DataSet
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() ' ConectionString

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
            'SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
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
        Fecha = "24/10/2023"
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

                        'Dim Hoy1 As DateTime = DateTime.ParseExact(Fecha, "MM/dd/yyyy", Globalization.CultureInfo.InvariantCulture)
                        'Dim FechaInicial As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()
                        'Dim FechaFinal As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()

                        Dim Hoy1 As String = Fecha ' Convert.ToDateTime(Fecha).ToString("dd/MM/yyyy")
                        Dim FechaInicial As String = Hoy1.ToUpper()
                        Dim FechaFinal As String = Hoy1.ToUpper()


                        'Produccion
                        'Dim url As String = "https://cvdpserver.local/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                        'DesarrolloFechaFinal
                        FechaFinal = "24/10/2023"
                        TipoFecha = "REGISTRO"
                        'Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                        Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString() & "&MECANISMO=BVRD" & "&TipoFecha=" & TipoFecha
                        ' Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString() & "&MECANISMO=BVRD" & "&TipoFecha=REGISTRO"

                        'Dim url As String = "http://api.cevaldom.com/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()

                        ' ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                        ' ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)

                        'ByPass SSL Certificate Validation Checking
                        '                  System.Net.ServicePointManager.ServerCertificateValidationCallback =
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
                        Catch ex3 As WebException
                            Response.Write("Fallo dentro del TRY: " + ex3.Message.ToString())
                        End Try
                        Using responseStream As Stream = webResponse.GetResponseStream()
                            If responseStream IsNot Nothing AndAlso responseStream IsNot Stream.Null Then
                                Using streamReader As StreamReader = New StreamReader(responseStream)
                                    Dim responseText As String = streamReader.ReadToEnd()

                                    ' Dim ds As DataSet = JObject.Parse(responseText)("Estatus").ToObject(Of DataSet)()
                                    ' Dim jObj As JObject = JObject.Parse(responseText)
                                    'dtRespuestaCevaldom = jObj("Cuerpo")("SOLOPER").ToObject(Of DataTable)()

                                    ' dataGridView1.DataSource = dtRespuestaCevaldom
                                    'Application.DoEvents()
                                    'Me.Update() 


                                    ' Define columns based on the JSON structure 
                                    'Datos del Estatus
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
                                    dtRespuestaCevaldom.Columns.Add("ContadoFACIAL", GetType(Integer))
                                    dtRespuestaCevaldom.Columns.Add("ContadoCANTIDAD", GetType(Integer))
                                    dtRespuestaCevaldom.Columns.Add("ContadoLIMPIO", GetType(Decimal))
                                    dtRespuestaCevaldom.Columns.Add("ContadoSUCIO", GetType(Decimal))
                                    dtRespuestaCevaldom.Columns.Add("ContadoRENDIMIENTO", GetType(Decimal))
                                    dtRespuestaCevaldom.Columns.Add("ContadoIMPORTE", GetType(Integer))

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
                                    TextArea1.Value = responseText


                                    Dim soloPerArray As JArray = jsonObj("Cuerpo")("SOLOPER")
                                    'Dim soloPerArray As JArray = jsonObj("Respuesta")
                                    Dim Estado As String = ""

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

                                        'If (TipoFecha = "LIQUIDACION") Then
                                        '    Estado = row("PlazoESTADO").ToString()
                                        'Else
                                        '    Estado = row("ContadoESTADO").ToString()
                                        'End If

                                        Estado = row("ContadoESTADO").ToString()

                                        dtRespuestaCevaldom.Rows.Add(row)
                                        EstadoOperacionLiquidacionCevaldom(row("Estatus"),
                                                                       row("NegociacionVENDEDOR"),
                                                                       row("NegociacionCOMPRADOR"),
                                                                       row("NegociacionMECANISMO"),
                                                                       row("NegociacionMODALIDAD"),
                                                                       row("NegociacionREFERENCIA"),
                                                                       row("NegociacionACORDADA"),
                                                                       row("NegociacionSOLICITUD"), 'row("PROCESO"), 
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
                                        ', TipoFecha
                                    Next
                                    'fin 
                                End Using
                            End If
                        End Using
                    Catch ex2 As WebException
                        Response.Write(ex2.Message.ToString())
                    End Try

                End If
            End If
        End If
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
            'SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
        End Try
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

End Class