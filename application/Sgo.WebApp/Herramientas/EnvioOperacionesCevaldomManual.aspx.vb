Imports System.Globalization
Imports System.IO
Imports System.Xml

Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Net.Security
Imports System.Configuration
Imports Ninject
Imports Newtonsoft.Json
Imports NHibernate
Imports System.Xml.Serialization
Imports Newtonsoft.Json.Linq
Imports System.Threading
Imports System.Drawing

Public Class EnvioOperacionesCevaldomManual

    Inherits System.Web.UI.Page
    Private oper As New operation
    'Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
    'Dim StrFiltros As String
    Dim FechaFiltrada
    Dim _strCadena As String
    Public strtoken As String = ""
    Public _strbody As String = ""
    Public _strfilename As String = ""
    Private eventId As Integer = 1
    'Public strruta As String = "\\adb03\xmlWebservices\"
    Private Lista As ArrayList = New ArrayList()

    'Public strruta As String = ConfigurationManager.AppSettings("strruta").ToString() '"\\arp22b\xml\"
    'Private Dias As String() = New String(1) {"SÁBADO", "DOMINGO"}
    'Private HorarioEstadoLiquidacion As String() = New String(8) {"09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00"}
    'Private struser As String = "BVRDADM"

    Private rownumber2 As Integer = 0
    Private strdate As String = ""
    Private strcode As String = ""
    Private strnumero As String = ""
    Private strmensaje As String = ""
    Private strguid As String = ""
    Private webResponse1 As HttpWebResponse = Nothing
    Private errorCode As Integer = 0
    Private errorCodeDescription As String = ""
    Private point As String = ""
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
    Private HoraMercadoFinal As Integer = 24
    'Private dtable As New DataTable()
    Private _STRDESCRIPCION As String
    Dim dtRespuestaCevaldom = New DataTable()
    Dim _strNumeroOPeracion As String
    Dim strcadenanueva As String

    ' para Deserealizar la cadena 
    Public Class NegociacionEnvio
        Public Property ORIGEN As String
        Public Property VENDEDOR As String
        Public Property COMPRADOR As String
        Public Property MECANISMO As String
        Public Property MODALIDAD As String
        Public Property REFERENCIA As String
        Public Property ACORDADA As String
        Public Property HORA As String
        Public Property OBSERVACIONES As String
    End Class

    Public Class ContadoEnvio
        Public Property LIQUIDACION As String
        Public Property ISIN As String
        Public Property CANTIDAD As String
        Public Property FACIAL As String
        Public Property LIMPIO As Decimal
        Public Property SUCIO As Decimal
        Public Property RENDIMIENTO As Decimal
        Public Property IMPORTE As Decimal
    End Class

    Public Class PlazoEnvio
        Public Property DIAS As Integer
        Public Property LIMPIO As Decimal
        Public Property SUCIO As Decimal
        Public Property RENDIMIENTO As Decimal
        Public Property IMPORTE As Decimal
    End Class

    Public Class LiquidacionEnvio
        Public Property Contado As ContadoEnvio
        Public Property Plazo As PlazoEnvio
    End Class

    Public Class operacionEnvio
        Public Property Negociacion As NegociacionEnvio
        Public Property Liquidacion As LiquidacionEnvio
        Public Property VERIFICADOR As Integer
    End Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtxmloperacion.InnerText = Session("cadena")
            _strCadena = Session("cadena")
            _strNumeroOPeracion = Session("IdoperacionManual")
            lblNoOperacion.Text = lblNoOperacion.Text + _strNumeroOPeracion
        Else
            _strCadena = txtxmloperacion.InnerText
            '_strNumeroOPeracion = Session("IdoperacionManual")
            ReGenerarCadena(_strCadena)
        End If
    End Sub
#Region "ENVIAR OPERACIONES VIA WEBSERVICES"
    'Public Shared ReadOnly Property ConectionString As String
    '    Get
    '        Return "Data Source=ADB00;Initial Catalog=SIOPEL_INTERFACE_DB;User ID=developer;Password=admin@123"
    '    End Get
    'End Property

    Public Sub GenerarToken(ByVal sender As Object, ByVal e1 As EventArgs)
        lblMensaje.Text = "MENSAJE:"
        txtxmlMensaje.InnerText = ""
        Dim horaMercado As Integer = -1
        Dim Hoy As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        Dim NombredelDia As String = Hoy.ToString("dddd", New CultureInfo("es-ES")).ToUpper()
        Dim ValidaFindeSemana As Boolean = oper.Dias.Contains(NombredelDia)
        horaMercado = Convert.ToInt16(DateTime.Now.ToString("HH"))
        If ValidaFindeSemana = False Then
            If horaMercado > HoraMercadoInicial AndAlso horaMercado < HoraMercadoFinal Then
                ' Dim dsoperaciones As DataSet = DsCuentaOperaciones()
                Dim i As Integer = 0
                'If dsoperaciones.Tables(0).Rows.Count > 0 Then
                If _strNumeroOPeracion <> "" Then
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
                        ' While i <= dsoperaciones.Tables(0).Rows.Count - 1
                        Dim rownumber As Integer = RandomNumber()
                        ' Console.WriteLine("Operacion: " & _strNumeroOPeracion) ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                        strdate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")
                        strcode = dt.Rows(rownumber)("CODIGO").ToString()
                        strnumero = dt.Rows(rownumber)("NUMERO").ToString()
                        strguid = dt.Rows(rownumber)("GUID").ToString()
                        strmensaje = oper.struser.ToString().Trim() & strdate.ToString().Trim()
                        Dim encoding As ASCIIEncoding = New ASCIIEncoding()
                        Dim textBytes As Byte() = encoding.GetBytes(strmensaje)
                        Dim len As Integer = ASCIIEncoding.[Default].GetByteCount(strnumero.ToString().Trim())
                        Dim keyBytes As Byte() = encoding.GetBytes(strnumero.ToString().Trim())
                        Dim hashBytes As Byte()

                        Using hash As HMACSHA256 = New HMACSHA256(keyBytes)
                            hashBytes = hash.ComputeHash(textBytes)
                        End Using

                        strtoken = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()

                        Dim dataoperacionmoneymarket As String = _strCadena 'dsoperaciones.Tables(0).Rows(i)("CADENA").ToString() 'poner cadena aqui

                        If dataoperacionmoneymarket <> "" Then
                            ' Ambiente de Pruebas 
                            'Dim url As String = "http://prejbosrv02.cevaldom.local:8080/cevaldom-webservices/negotiation/v1/operationRequest" 'poner s aqui 
                            Dim url As String = ConfigurationManager.AppSettings("CevaldomURLSolOper").ToString()
                            'Dim url As String = "https://api.cevaldom.com/pre-webservices/negotiation/v1/operationRequest"

                            ' Ambiente de PRODUCCION
                            ' Dim url As String = "https://cvdpserver.local/cevaldom-webservices/negotiation/v1/operationRequest" 

                            ' Ambiente de CONTIGENCIA
                            ' Dim url As String = "https://cvdpsecundario.local/cevaldom-webservices/negotiation/v1/operationRequest"

                            'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls13 Or SecurityProtocolType.Ssl3

                            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls12 Or SecurityProtocolType.Ssl3


                            Dim request As HttpWebRequest = TryCast(WebRequest.Create(url), HttpWebRequest)

                            'Dim oldCallback = ServicePointManager.ServerCertificateValidationCallback
                            request.Credentials = CredentialCache.DefaultCredentials
                            request.Method = "POST"
                            Dim priMethod As MethodInfo = request.Headers.[GetType]().GetMethod("AddWithoutValidate", BindingFlags.Instance Or BindingFlags.NonPublic)
                            priMethod.Invoke(request.Headers, {"user", oper.struser.ToString()})
                            priMethod.Invoke(request.Headers, {"code", strcode.ToString()})
                            Dim mydate As Object() = New Object(1) {}
                            mydate(0) = "date"
                            mydate(1) = strdate
                            priMethod.Invoke(request.Headers, mydate)
                            priMethod.Invoke(request.Headers, {"token", strtoken.ToString()})
                            priMethod.Invoke(request.Headers, {"Accept", "application/xml"})
                            priMethod.Invoke(request.Headers, {"Content-Type", "application/xml"})
                            priMethod.Invoke(request.Headers, {"User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36"})

                            Dim dataStream As Byte() = encoding.UTF8.GetBytes(dataoperacionmoneymarket.ToString())
                            Dim newStream As Stream = request.GetRequestStream()
                            newStream.Write(dataStream, 0, dataStream.Length)
                            newStream.Close()

                            Dim webResponse As WebResponse '= Nothing
                            'Dim se As Object
                            'Dim certa As X509Certificates
                            'Dim ssla As SslPolicyErrors
                            'Dim chaina As X509Certificates.X509Chain
                            'AddHandler ServicePointManager.ServerCertificateValidationCallback, Function(se, cert, chain, sslerror) True
                            'If True Then
                            '    ServicePointManager.ServerCertificateValidationCallback += (Dim se As System.Object, Dim cert As System , Dim chain As System.Security.Cryptography.X509Certificates.X509Chain, Dim sslerror AS System.Net.Security.SslPolicyErrors) >= {}
                            'End If

                            'Dim allowUntrustedCertificates As Boolean = False 'squitada

                            'If allowUntrustedCertificates Then
                            '    ServicePointManager.ServerCertificateValidationCallback = (Function(Sender, certification, chain, sslPolicyErrors) True)
                            'End If
                            'ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                            ' ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType)
                            'ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

                            'System.Net.ServicePointManager.ServerCertificateValidationCallback =
                            '  Function(se As Object,
                            '  cert As System.Security.Cryptography.X509Certificates.X509Certificate,
                            '  chain As System.Security.Cryptography.X509Certificates.X509Chain,
                            '  sslerror As System.Net.Security.SslPolicyErrors) True

                            ' ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf AcceptAllCertifications)
                            ' ServicePointManager.ServerCertificateValidationCallback =

                            Try
                                webResponse = request.GetResponse()
                                errorCodeDescription = (CType(webResponse, HttpWebResponse)).StatusDescription.ToString()
                                MarcaOperacionEnviada(Convert.ToInt64(_strNumeroOPeracion)) 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                errorCode = 1
                                point = "1. "
                                'LLenarEstado(_strNumeroOPeracion, errorCodeDescription, "")
                                lblMensaje.Text = "MENSAJE: OPERACION #: " + _strNumeroOPeracion + ", ENVIADA SEGUN ESTADO : " + errorCodeDescription
                                txtxmlMensaje.InnerText = lblMensaje.Text
                            Catch e As WebException
                                webResponse1 = CType(e.Response, HttpWebResponse)
                                point = "2. "

                                ' If e.Status = WebExceptionStatus.ProtocolError Then
                                'Marca el campo de estado en la tabla de operaciones para que no vuelva a ser enviada 0 = no enviada y 1 = enviada
                                ' MarcaOperacionEnviada(Convert.ToInt64(_strNumeroOPeracion)) 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                'Else
                                ' Console.Write("Error: {0}", e.Status)
                                ' End If

                                errorCode = CInt(webResponse1.StatusCode)
                                errorCodeDescription = webResponse1.StatusCode.ToString()
                                'webResponse = webResponse1

                                ' Escribo la notificacion del error que devolvio cevaldom
                                Dim newguid As String = "_" & System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                                Dim responseFile1 As String = oper.strruta & "NotifiCVD_" & _strNumeroOPeracion & newguid.ToString() 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                _STRDESCRIPCION = ""
                                Dim rownum As Int64

                                Using responseStream1 As Stream = webResponse1.GetResponseStream()
                                    If responseStream1 IsNot Nothing Then
                                        Using streamReader1 As StreamReader = New StreamReader(responseStream1)
                                            Dim responseText1 As String = streamReader1.ReadToEnd()
                                            Dim responseBytes1 As Byte() = encoding.UTF8.GetBytes(responseText1)
                                            File.WriteAllBytes(responseFile1, responseBytes1)
                                            Dim reader As XmlReader = XmlReader.Create(New StringReader(responseText1))
                                            If reader.ReadString() <> "None" Or reader.ReadString() <> "" Then
                                                While reader.Read()
                                                    If (reader.ReadString() <> "") Then
                                                        If reader.Name = "DESCRIPCION" Then
                                                            _STRDESCRIPCION = _STRDESCRIPCION + "" + Chr(13) + reader.ReadString()
                                                        End If
                                                        If reader.Name = "Errores" Then
                                                            _STRDESCRIPCION = _STRDESCRIPCION + "" + Chr(13) + reader.ReadString()
                                                        End If
                                                        If reader.Name = "Error" Then
                                                            _STRDESCRIPCION = _STRDESCRIPCION + "" + Chr(13) + reader.ReadString()
                                                        End If
                                                        If reader.Name = "Estatus" Then
                                                            _STRDESCRIPCION = _STRDESCRIPCION + "" + Chr(13) + reader.ReadString()
                                                        End If
                                                    Else
                                                        txtxmlMensaje.InnerText = responseText1
                                                    End If
                                                End While
                                            End If
                                        End Using
                                    End If
                                    If File.Exists(responseFile1) Then
                                        'Coloca el estado devuelto por CEVALDOM en el request en operaciones CSV
                                        NotificacionCevaldom(responseFile1, _strNumeroOPeracion, errorCodeDescription.ToString()) ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                    End If
                                End Using

                                'LLenarEstado(_strNumeroOPeracion, errorCodeDescription, _STRDESCRIPCION)
                                ' InjectScriptLabelImprimir.Text = "<script>MensajePopup('" + "La operación # " + _strNumeroOPeracion + " falló " + point + errorCodeDescription + "')</" + "script>"
                                txtxmlMensaje.InnerText = _STRDESCRIPCION
                                lblMensaje.Text = "LA OPERACION # " + _strNumeroOPeracion + " FALLO, DEBIDO A  : " + errorCodeDescription
                            End Try

                            Dim strdatefile As String = String.Format("{0:MMddyyyyHHmmss}", strdate)
                            strdatefile = strdate.Replace("/", "")
                            strdatefile = strdatefile.Replace(":", "")
                            strdatefile = strdatefile.Replace(" ", "")

                            Try
                                Dim newguid As String = "_" & System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                                Dim responseFile As String = oper.strruta & "NotifiCVD_" & _strNumeroOPeracion & newguid.ToString() 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                DesBloqueoArchivo(responseFile)
                                If webResponse1 IsNot Nothing Then
                                    Using responseStream As Stream = webResponse1.GetResponseStream()
                                        If responseStream IsNot Nothing And responseStream.CanRead = True Then

                                            Using streamReader As StreamReader = New StreamReader(responseStream)
                                                Dim responseText As String = streamReader.ReadToEnd()
                                                Dim responseBytes As Byte() = encoding.UTF8.GetBytes(responseText)
                                                File.WriteAllBytes(responseFile, responseBytes)
                                            End Using

                                            Try

                                                If File.Exists(responseFile) Then
                                                    'Coloca el estado devuelto por CEVALDOM en el request en operaciones CSV
                                                    NotificacionCevaldom(responseFile, _strNumeroOPeracion, errorCodeDescription.ToString()) ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()

                                                End If

                                            Catch ex As Exception
                                                _strbody = "Webservice Money Market - Error:  " & ex.Message.ToString() & " " & "; creando arhivo respuesta cevaldom de la OPERACION #: " & _strNumeroOPeracion ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                                _strfilename = ""
                                                SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
                                            End Try
                                        End If
                                    End Using
                                End If

                                Deletefile(responseFile)

                            Catch ex As WebException
                                Dim responseFile As String = oper.strruta & "ErrorEnvioOperacionesCevaldom_" & strdatefile.ToString() & ".xml"
                                Dim responseText As String = _strNumeroOPeracion  ' dsoperaciones.Tables(0).Rows(i)("cadena").ToString()
                                Dim responseBytes As Byte() = encoding.UTF8.GetBytes(responseText)
                                File.WriteAllBytes(responseFile, responseBytes)
                                ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                _strbody = "Ha ocurrido un error en el envio de la operación adjunto, <br> <strong> DESCRIPCION ERROR #: " & ex.Message.ToString() & "</strong> <br> NUMERO #:" & _strNumeroOPeracion & "; NOTA: ESCRIBIENDO EL ARCHIVO DE NotificacionCevaldom.XML" & "; DESCRIPCION ERROR: " & errorCodeDescription
                                lblMensaje.Text = "HA OCURRIDO UN ERROR #: " & ex.Message.ToString() & "EN LA  OPERACION #:" & _strNumeroOPeracion
                                _strfilename = responseFile
                                SendMail("Error ENVIO WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
                            End Try

                            If errorCode = 201 Then MarcaOperacionEnviada(Convert.ToInt64(_strNumeroOPeracion)) 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                        End If

                        i = i + 1
                        ' End While

                    Catch ex As Exception
                        _strbody = "Webservice Money Market - Error:  " & ex.Message.ToString() & " " & "; NOTA: ENVIANDO LA OPERACION #: " & _strNumeroOPeracion & "; PARAMETRO : " & _strCadena & "; CODIGO: " & strcode & "; FECHA: " & strdate & "; TOKEN #: " & strtoken & "; DESCRIPCION ERROR: " & errorCodeDescription
                        lblMensaje.Text = "HA OCURRIDO UN ERROR #: " & ex.Message.ToString() & " EN LA  OPERACION #:" & _strNumeroOPeracion
                        _strfilename = ""
                        'SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
                    End Try
                End If

            End If
            ' InjectScriptLabelImprimir.Text = "<script>MensajePopup('" + "La operación # " + _strNumeroOPeracion + " falló " + point + errorCodeDescription + "')</" + "script>"
        End If
    End Sub

    Public Sub EstadosOperacionesWS()
        Dim horaMercado As Integer = -1
        Dim Hoy As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        Dim NombredelDia As String = Hoy.ToString("dddd", New CultureInfo("es-ES")).ToUpper()
        Dim ValidaFindeSemana As Boolean = oper.Dias.Contains(NombredelDia)
        Dim horaEstado As String = Convert.ToString(DateTime.Now.ToString("HH:mm"))
        Dim ValidaHorarioEstadoLiq As Boolean = oper.HorarioEstadoLiquidacion.Contains(horaEstado.ToString())
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
                    strmensaje = oper.struser.ToString().Trim() & strdate.ToString().Trim()
                    Dim encoding As ASCIIEncoding = New ASCIIEncoding()
                    Dim textBytes As Byte() = encoding.GetBytes(strmensaje)
                    Dim len As Integer = ASCIIEncoding.[Default].GetByteCount(strnumero.ToString().Trim())
                    Dim keyBytes As Byte() = encoding.GetBytes(strnumero.ToString().Trim())
                    Dim hashBytes As Byte()

                    Using hash As HMACSHA256 = New HMACSHA256(keyBytes)
                        hashBytes = hash.ComputeHash(textBytes)
                    End Using

                    strtoken = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                    Dim Hoy1 As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    Dim FechaInicial As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()
                    Dim FechaFinal As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()
                    'Produccion
                    'Dim url As String = "https://cvdpserver.local/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                    'Desarrollo
                    ' Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                    Dim url As String = ConfigurationManager.AppSettings("CevaldomURLEstado").ToString() & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString() & "&MECANISMO=BVRD" & "&TipoFecha=REGISTRO"

                    'Dim url As String = "http://prejbosrv02.cevaldom.local:8080/cevaldom-webservices/negotiation/v1/getOperationRequest?FechaInicial=" & FechaInicial.ToString() & "&FechaFinal=" & FechaFinal.ToString()
                    Dim request As HttpWebRequest = TryCast(WebRequest.Create(url), HttpWebRequest)
                    request.Credentials = CredentialCache.DefaultCredentials
                    request.Method = "GET"
                    Dim priMethod As MethodInfo = request.Headers.[GetType]().GetMethod("AddWithoutValidate", BindingFlags.Instance Or BindingFlags.NonPublic)
                    priMethod.Invoke(request.Headers, {"user", oper.struser.ToString()})
                    priMethod.Invoke(request.Headers, {"code", strcode.ToString()})
                    Dim mydate As Object() = New Object(1) {}
                    mydate(0) = "date"
                    mydate(1) = strdate
                    priMethod.Invoke(request.Headers, mydate)
                    priMethod.Invoke(request.Headers, {"token", strtoken.ToString()})
                    priMethod.Invoke(request.Headers, {"Accept", "application/json"})
                    priMethod.Invoke(request.Headers, {"Content-Type", "application/xml"})
                    priMethod.Invoke(request.Headers, {"User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36"})


                    'inicio 
                    Dim webResponse As WebResponse = Nothing
                    ' webResponse = CType(request.GetResponse(), HttpWebResponse)
                    webResponse = CType(request.GetResponse(), HttpWebResponse)
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
                            End Using
                        End If
                    End Using

                    'fin 
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



    Public Function DSenvioOperacionCevaldom(ByVal numoperacion As Integer) As DataSet
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() '  ConectionString

            Using con As SqlConnection = New SqlConnection(strString)

                Using cmd As SqlCommand = New SqlCommand("P_GEN_CEVALDOM_OPER_WS_MONEYMARKET", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    con.Open()
                    Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
                    adp.Fill(ds)
                End Using
            End Using

            Return ds
        Catch
            Return ds
        End Try
    End Function

    Public Sub MarcaOperacionEnviada(ByVal numoperacion As Int64)
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() ' ConectionString

            Using con As SqlConnection = New SqlConnection(strString)

                Using cmd As SqlCommand = New SqlCommand("P_GEN_CEVALDOM_OPER_WS_MM_MARCAENVIADA", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    con.Open()
                    cmd.Parameters.Add("@NUMERO_OPERACION", SqlDbType.Decimal).Value = numoperacion
                    Dim result As Integer = cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            _strbody = "Webservice Money Market - Error:  " & ex.Message.ToString() & " " & "; MARCANDO LA OPERACION #: " & numoperacion.ToString()
            _strfilename = ""
            SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
        End Try
    End Sub

    Public Function DsCuentaOperaciones() As DataSet
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() ' ConectionString

            Using con As SqlConnection = New SqlConnection(strString)

                Using cmd As SqlCommand = New SqlCommand("P_GEN_CEVALDOM_OPER_CUENTA_MM", con)
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
            SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
            Return ds
        End Try
    End Function

    Public Sub SendMail(ByVal Subject As String, ByVal Body As String, ByVal Attachments As String)
        'Dim server As String = Environment.MachineName.ToString()
        'Subject = server & " : " & Subject
        'Dim MailClient As SmtpClient = New SmtpClient(ConfigurationManager.AppSettings("MailClient").ToString(), ConfigurationManager.AppSettings("Port").ToString())
        'Dim From As String = ConfigurationManager.AppSettings("From").ToString()
        'Dim [To] As String = ConfigurationManager.AppSettings("To").ToString()
        'Dim AuthUsername As String = ConfigurationManager.AppSettings("AuthUsername").ToString()
        'Dim AuthPassword As String = ConfigurationManager.AppSettings("AuthPassword").ToString()
        'MailClient.Credentials = New System.Net.NetworkCredential(From, "")
        'Dim MailMessage = New MailMessage(From, [To], Subject, Body)
        'MailMessage.IsBodyHtml = True

        'If (Attachments.ToString() <> "") Then
        '    MailMessage.Attachments.Add(New Attachment(Attachments))
        'End If

        'MailClient.Send(MailMessage)
        'MailClient.Dispose()
        'MailMessage.Dispose()
    End Sub

    Public Sub Deletefile(ByVal filename As String)
        If filename.ToString() <> "" Then
            File.Delete(filename)
        End If
    End Sub

    Public Sub DesBloqueoArchivo(ByVal filename As String)
        'Dim lstProcs As List(Of Process) = New List(Of Process)()
        'lstProcs = ProcessHandler.WhoIsLocking(filename)

        'For Each p As Process In lstProcs

        '    If p.MachineName.ToUpper() = "SEP12B" OrElse p.MachineName.ToUpper() = "APL" OrElse p.MachineName.ToUpper() = "." Then
        '        ProcessHandler.localProcessKill(p.ProcessName)
        '    Else
        '        ProcessHandler.remoteProcessKill(p.MachineName, txtUserName, txtPassword, p.ProcessName)
        '    End If
        'Next
    End Sub

    'Public Sub LLenarEstado(ByVal numerooperacion As String, ByVal Estado As String, ByVal Descripcion As String)
    '    dtable.Rows.Add(numerooperacion, Estado, Descripcion)
    'End Sub

    Public Sub NotificacionCevaldom(ByVal filename As String, ByVal numerooperacion As String, ByVal estado As String)
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() ' ConectionString

            Using con As SqlConnection = New SqlConnection(strString)

                Using cmd As SqlCommand = New SqlCommand("P_SUBE_XML_RESPUESTA_OPERACIONESMM_CEVALDOM", con)
                    cmd.CommandType = CommandType.StoredProcedure
                    con.Open()
                    cmd.Parameters.Add("@archivo", SqlDbType.VarChar).Value = filename
                    cmd.Parameters.Add("@ESTADO", SqlDbType.VarChar).Value = estado
                    cmd.Parameters.Add("@numerooperacion", SqlDbType.VarChar).Value = numerooperacion
                    Dim result As Integer = cmd.ExecuteNonQuery()
                    con.Dispose()

                    If File.Exists(filename) Then
                        Using file = System.IO.File.OpenText(filename)
                            file.Close()
                        End Using
                    End If
                End Using
            End Using

        Catch ex As Exception
            _strbody = "Webservice Money Market - Error: " & ex.Message.ToString() & " " & "; NOTA: SUBIENDO LA RESPUESTA DE CEVALDOM a la operacion # " & numerooperacion
            _strfilename = ""
            SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
        End Try
    End Sub

    Public Sub EstadoOperacionLiquidacionCevaldom(ByVal ESTATUS As String, ByVal VENDEDOR As String, ByVal COMPRADOR As String, ByVal MECANISMO As String, ByVal MODALIDAD As Int64, ByVal REFERENCIA As String, ByVal PACTADA As String, ByVal PROCESO As Int64, ByVal SOLICITUD As Int64, ByVal OPERACION As String, ByVal TRN As String, ByVal CONTADO As String, ByVal PLAZO As String, ByVal ESTADO As String, ByVal VINCULADA As String, ByVal INCUMPLIMIENTO As String, ByVal ORIGEN As String, ESTADOPLAZO As String, OPERACIONPLAZO As String)
        Dim ds As DataSet = New DataSet()

        Try

            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() ' ConfigurationManager.AppSettings("CN").ToString() ' ConectionString

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

        ' Console.WriteLine("CODIGO RANDOM: " & rownumber.ToString())
        Return rownumber
    End Function

    Public Sub aleatorio()
        Dim dt As DataTable = New DataTable()
        dt.Columns.AddRange(New DataColumn(2) {New DataColumn("CODIGO", GetType(String)), New DataColumn("NUMERO", GetType(String)), New DataColumn("GUID", GetType(Int64))})
        Dim Lista As ArrayList = New ArrayList()
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
        Dim rnd As Random = New Random()
        Dim i As Integer = 0

        For Each row As DataRow In dt.Rows
            row("GUID") = rnd.[Next](1, 1000000)
            i = i + 1
        Next

        Dim dv As DataView = dt.DefaultView
        dv.Sort = "GUID"
        Dim sortedDT As DataTable = dv.ToTable()
        ' Console.WriteLine(sortedDT.Rows(0)("CODIGO").ToString())
        ' Console.WriteLine(sortedDT.Rows(0)("NUMERO").ToString())

        If Lista.Count = 9 Then
            Lista.Clear()
        End If

        Lista.Add(sortedDT.Rows(0)("CODIGO").ToString())

        If Lista.Contains(sortedDT.Rows(0)("CODIGO")) Then
        End If
    End Sub

    Private Sub ArmaCAdena(ByVal sender As Object, ByVal e1 As EventArgs)
        If (txtxmloperacion.InnerHtml <> "") Then

            With lblMensaje
                .ForeColor = Color.Blue
                .Text = "Se estan procesando la opperación"
                .Visible = True
            End With


            Try
                GenerarToken(sender, e1)

            Catch ex As Exception
            End Try

            'Consulta el estado de las operaciones del dia indicado en pantalla
            With lblMensaje
                .ForeColor = Color.Blue
                .Text = "CONSULTANDO LA OPERACION EN CEVALDOM, ESPERE" ' & dtable.Rows.Count
                .Visible = True
            End With
            EstadosOperacionesWS()
            With lblMensaje
                .ForeColor = Color.Blue
                .Text = "FUE PROCESADA LA OPERACION, Verifique "
                .Visible = True
            End With
        End If
    End Sub
    Public Function ReGenerarCadena(ByVal Strcadena As String) ' As String
        Dim CANTIDADoFACIAL As String
        Dim _digitoRegenerado As String
        Strcadena = Strcadena
        _STRDESCRIPCION = ""
        If (Strcadena <> "") Then
            Dim rootAttribute As New XmlRootAttribute("SOLOPER")
            Dim serializer As New XmlSerializer(GetType(operacionEnvio), rootAttribute)
            Dim namespaces As New XmlSerializerNamespaces()
            namespaces.Add("", "")

            Using reader As New StringReader(Strcadena)
                Dim soloPer As operacionEnvio = DirectCast(serializer.Deserialize(reader), operacionEnvio)
                ' Console.WriteLine("ORIGEN: " & soloPer.Negociacion.ORIGEN)
                ' Console.WriteLine("VENDEDOR: " & soloPer.Negociacion.VENDEDOR)
                If (soloPer.Liquidacion.Contado.CANTIDAD = Nothing) Then
                    soloPer.Liquidacion.Contado.CANTIDAD = ""
                    CANTIDADoFACIAL = "<FACIAL>" + soloPer.Liquidacion.Contado.FACIAL.ToString() + "</FACIAL>"
                End If

                If (soloPer.Liquidacion.Contado.FACIAL = Nothing) Then
                    soloPer.Liquidacion.Contado.FACIAL = ""
                     CANTIDADoFACIAL = "<CANTIDAD>" + soloPer.Liquidacion.Contado.CANTIDAD.ToString() + "</CANTIDAD>"
                End If


                _STRDESCRIPCION = _STRDESCRIPCION + soloPer.Negociacion.ORIGEN.ToString() + soloPer.Negociacion.VENDEDOR.ToString() + soloPer.Negociacion.COMPRADOR.ToString() + soloPer.Negociacion.MECANISMO.ToString() + soloPer.Negociacion.MODALIDAD.ToString() + soloPer.Negociacion.REFERENCIA.ToString() + soloPer.Negociacion.ACORDADA.ToString() + soloPer.Negociacion.HORA.ToString() + soloPer.Negociacion.OBSERVACIONES.ToString() +
                    soloPer.Liquidacion.Contado.LIQUIDACION.ToString() + soloPer.Liquidacion.Contado.ISIN.ToString() + soloPer.Liquidacion.Contado.CANTIDAD.ToString() + soloPer.Liquidacion.Contado.FACIAL.ToString() + soloPer.Liquidacion.Contado.LIMPIO.ToString() + soloPer.Liquidacion.Contado.SUCIO.ToString() + soloPer.Liquidacion.Contado.RENDIMIENTO.ToString() + soloPer.Liquidacion.Contado.IMPORTE.ToString() +
                    soloPer.Liquidacion.Plazo.DIAS.ToString() + soloPer.Liquidacion.Plazo.LIMPIO.ToString() + soloPer.Liquidacion.Plazo.SUCIO.ToString() + soloPer.Liquidacion.Plazo.RENDIMIENTO.ToString() + soloPer.Liquidacion.Plazo.IMPORTE.ToString()
                ' Consulto el digito verificado desde la funcion de la base de datos 
                _digitoRegenerado = DsObtieneDigito(_STRDESCRIPCION)

                'reconstruyo la cadena con el nuevo digito consultado.
                strcadenanueva = "<SOLOPER><Negociacion>
                <ORIGEN>" + soloPer.Negociacion.ORIGEN.ToString() + "</ORIGEN>
                <VENDEDOR>" + soloPer.Negociacion.VENDEDOR.ToString() + "</VENDEDOR>
                <COMPRADOR>" + soloPer.Negociacion.COMPRADOR.ToString() + "</COMPRADOR>
                <MECANISMO>" + soloPer.Negociacion.MECANISMO.ToString() + "</MECANISMO>
                <MODALIDAD>" + soloPer.Negociacion.MODALIDAD.ToString() + "</MODALIDAD>
                <REFERENCIA>" + soloPer.Negociacion.REFERENCIA.ToString() + "</REFERENCIA>
                <ACORDADA>" + soloPer.Negociacion.ACORDADA.ToString() + "</ACORDADA>
                <HORA>" + soloPer.Negociacion.HORA.ToString() + "</HORA>
                <OBSERVACIONES>" + soloPer.Negociacion.OBSERVACIONES.ToString() + "</OBSERVACIONES>
                </Negociacion>
                <Liquidacion>
                    <Contado>
                        <LIQUIDACION>" + soloPer.Liquidacion.Contado.LIQUIDACION.ToString() + "</LIQUIDACION>
                        <ISIN>" + soloPer.Liquidacion.Contado.ISIN.ToString() + "</ISIN> " + Chr(13) +
                        CANTIDADoFACIAL + Chr(13) +
                        "<LIMPIO>" + soloPer.Liquidacion.Contado.LIMPIO.ToString() + "</LIMPIO>
                        <SUCIO>" + soloPer.Liquidacion.Contado.SUCIO.ToString() + "</SUCIO>
                        <RENDIMIENTO>" + soloPer.Liquidacion.Contado.RENDIMIENTO.ToString() + "</RENDIMIENTO>
                        <IMPORTE>" + soloPer.Liquidacion.Contado.IMPORTE.ToString() + "</IMPORTE>
                    </Contado>
                    <Plazo>
                        <DIAS>" + soloPer.Liquidacion.Plazo.DIAS.ToString() + "</DIAS>
                        <LIMPIO>" + soloPer.Liquidacion.Plazo.LIMPIO.ToString() + "</LIMPIO>
                        <SUCIO>" + soloPer.Liquidacion.Plazo.SUCIO.ToString() + "</SUCIO>
                        <RENDIMIENTO>" + soloPer.Liquidacion.Plazo.RENDIMIENTO.ToString() + "</RENDIMIENTO>
                        <IMPORTE>" + soloPer.Liquidacion.Plazo.IMPORTE.ToString() + "</IMPORTE>
                    </Plazo>
                </Liquidacion>
                <VERIFICADOR>" + _digitoRegenerado.ToString() + "</VERIFICADOR></SOLOPER> "
                txtxmloperacion.InnerHtml = strcadenanueva
                _strCadena = strcadenanueva
                _strNumeroOPeracion = soloPer.Negociacion.REFERENCIA.ToString()
            End Using
        End If
        'End Using
        'End If

        'Return _STRDESCRIPCION
    End Function

    Public Function DsObtieneDigito(ByVal Cadena As String) As String
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConfigurationManager.ConnectionStrings("CNINTERFACE").ToString() ' ConectionString
            Using con As SqlConnection = New SqlConnection(strString)
                Using cmd As SqlCommand = New SqlCommand("select CONVERT(VARCHAR(8000), [dbo].[fn_DigitoVerificadorCevaldom]('" + Cadena + "' )) as digito", con)
                    cmd.CommandType = CommandType.Text
                    con.Open()
                    Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
                    adp.Fill(ds)
                End Using
            End Using

            Return ds.Tables(0).Rows(0)("Digito").ToString()
        Catch ex As Exception
            _strbody = "Webservice Money Market - Error: " & ex.Message.ToString() & " " & "; NOTA:  CONSULTANDO LA BASE DE DATOS "
            ' SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
            Return "Digito no generado, verifique la clave "
        End Try
    End Function

#End Region
End Class