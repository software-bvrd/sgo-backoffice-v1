Imports System.Globalization
Imports System.IO
Imports System.Xml

Imports Telerik.Web.UI
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection
Imports System.Security.Cryptography
Imports System.Net.Security
Imports System.Configuration

Public Class EnvioOperacionesCevaldom
    Inherits System.Web.UI.Page
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
    Public strruta As String = "\\ARP12b\xml\"
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

#Region "ENVIAR OPERACIONES VIA WEBSERVICES"
    Public Shared ReadOnly Property ConectionString As String
        Get
            Return "Data Source=ARP12B;Initial Catalog=SIOPEL_INTERFACE_DB;User ID=developer;Password=admin@123"
        End Get
    End Property

    Public Sub GenerarToken(_strCadena As String, _strNumeroOPeracion As String)

        Dim horaMercado As Integer = -1
        Dim Hoy As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        Dim NombredelDia As String = Hoy.ToString("dddd", New CultureInfo("es-ES")).ToUpper()
        Dim ValidaFindeSemana As Boolean = Dias.Contains(NombredelDia)
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
                        Console.WriteLine("Operacion: " & _strNumeroOPeracion) ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
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



                        Dim dataoperacionmoneymarket As String = _strCadena 'dsoperaciones.Tables(0).Rows(i)("CADENA").ToString() 'poner cadena aqui

                        If dataoperacionmoneymarket <> "" Then
                            ' Ambiente de Pruebas 
                            'Dim url As String = "http://prejbosrv02.cevaldom.local:8080/cevaldom-webservices/negotiation/v1/operationRequest" 'poner s aqui 
                            Dim url As String = ConfigurationManager.AppSettings("CevaldomURLSolOper").ToString()


                            ' Ambiente de PRODUCCION
                            ' Dim url As String = "https://cvdpserver.local/cevaldom-webservices/negotiation/v1/operationRequest" 

                            ' Ambiente de CONTIGENCIA
                            ' Dim url As String = "https://cvdpsecundario.local/cevaldom-webservices/negotiation/v1/operationRequest"

                            Dim request As HttpWebRequest = TryCast(WebRequest.Create(url), HttpWebRequest)
                            ' Dim oldCallback = ServicePointManager.ServerCertificateValidationCallback
                            request.Credentials = CredentialCache.DefaultCredentials
                            request.Method = "POST"
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
                            Catch e As WebException
                                webResponse1 = CType(e.Response, HttpWebResponse)

                                If e.Status = WebExceptionStatus.ProtocolError Then
                                    MarcaOperacionEnviada(Convert.ToInt64(_strNumeroOPeracion)) 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                Else
                                    Console.Write("Error: {0}", e.Status)
                                End If

                                errorCode = CInt(webResponse1.StatusCode)
                                errorCodeDescription = webResponse1.StatusCode.ToString()
                                webResponse = webResponse1
                            End Try

                            Dim strdatefile As String = String.Format("{0:MMddyyyyHHmmss}", strdate)
                            strdatefile = strdate.Replace("/", "")
                            strdatefile = strdatefile.Replace(":", "")
                            strdatefile = strdatefile.Replace(" ", "")

                            Try
                                Dim newguid As String = "_" & System.Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                                Dim responseFile As String = strruta & "NotifiCVD_" & _strNumeroOPeracion & newguid.ToString() 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                DesBloqueoArchivo(responseFile)

                                Using responseStream As Stream = webResponse.GetResponseStream()

                                    If responseStream IsNot Nothing Then

                                        Using streamReader As StreamReader = New StreamReader(responseStream)
                                            Dim responseText As String = streamReader.ReadToEnd()
                                            Dim responseBytes As Byte() = encoding.UTF8.GetBytes(responseText)
                                            File.WriteAllBytes(responseFile, responseBytes)
                                        End Using

                                        Try

                                            If File.Exists(responseFile) Then
                                                NotificacionCevaldom(responseFile, _strNumeroOPeracion, errorCodeDescription.ToString()) ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                            End If

                                        Catch ex As Exception
                                            _strbody = "Webservice Money Market - Error:  " & ex.Message.ToString() & " " & "; creando arhivo respuesta cevaldom de la OPERACION #: " & _strNumeroOPeracion ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                            _strfilename = ""
                                            SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
                                        End Try
                                    End If
                                End Using

                                Deletefile(responseFile)
                            Catch ex As WebException
                                Dim responseFile As String = strruta & "ErrorEnvioOperacionesCevaldom_" & strdatefile.ToString() & ".xml"
                                Dim responseText As String = _strNumeroOPeracion  ' dsoperaciones.Tables(0).Rows(i)("cadena").ToString()
                                Dim responseBytes As Byte() = encoding.UTF8.GetBytes(responseText)
                                File.WriteAllBytes(responseFile, responseBytes)
                                ' dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                                _strbody = "Ha ocurrido un error en el envio de la operación adjunto, <br> <strong> DESCRIPCION ERROR #: " & ex.Message.ToString() & "</strong> <br> NUMERO #:" & _strNumeroOPeracion & "; NOTA: ESCRIBIENDO EL ARCHIVO DE NotificacionCevaldom.XML" & "; DESCRIPCION ERROR: " & errorCodeDescription
                                _strfilename = responseFile
                                SendMail("Error ENVIO WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
                            End Try

                            If errorCode = 201 Then MarcaOperacionEnviada(Convert.ToInt64(_strNumeroOPeracion)) 'dsoperaciones.Tables(0).Rows(i)("NUMERO_OPERACION").ToString()
                        End If

                        i = i + 1
                        ' End While

                    Catch ex As Exception

                        _strbody = "Webservice Money Market - Error:  " & ex.Message.ToString() & " " & "; NOTA: ENVIANDO LA OPERACION #: " & _strNumeroOPeracion & "; PARAMETRO : " & _strCadena & "; CODIGO: " & strcode & "; FECHA: " & strdate & "; TOKEN #: " & strtoken & "; DESCRIPCION ERROR: " & errorCodeDescription
                        _strfilename = ""
                        ' SendMail("Error EJECUCION WS Operaciones - Cevaldom", _strbody, _strfilename.ToString())
                    End Try
                End If



            End If
        End If
    End Sub





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
                    Dim Hoy1 As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
                    Dim FechaInicial As String = Hoy1.ToString("dd/MM/yyyy", New CultureInfo("es-ES")).ToUpper()
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

    Public Function DSenvioOperacionCevaldom(ByVal numoperacion As Integer) As DataSet
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConectionString

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
            Dim strString As String = ConectionString

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
            Dim strString As String = ConectionString

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

    Public Sub NotificacionCevaldom(ByVal filename As String, ByVal numerooperacion As String, ByVal estado As String)
        Dim ds As DataSet = New DataSet()

        Try
            Dim strString As String = ConectionString

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

        Console.WriteLine("CODIGO RANDOM: " & rownumber.ToString())
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
        Console.WriteLine(sortedDT.Rows(0)("CODIGO").ToString())
        Console.WriteLine(sortedDT.Rows(0)("NUMERO").ToString())

        If Lista.Count = 9 Then
            Lista.Clear()
        End If

        Lista.Add(sortedDT.Rows(0)("CODIGO").ToString())

        If Lista.Contains(sortedDT.Rows(0)("CODIGO")) Then
        End If
    End Sub

#End Region

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub

    'columna 23 row(i) tables(23)

    'Dim grid As DataSet = FindControl("RadGrid1_ctl00")
    'Dim div As RadGrid = CType(Page.FindControl("RadGrid1_GridData"), RadGrid)

    'Dim node As RadGrid = RadGrid1
    'Dim grid As RadGrid = Page.FindControl("RadGrid1_ctl00")
    'Public Sub Recorrertabla()

    '    'RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
    '    RadGrid1.MasterTableView.AllowPaging = False
    '    RadGrid1.Rebind()
    '    Dim numero As Integer = RadGrid1.MasterTableView.Items.Count
    '    RadGrid1.MasterTableView.AllowPaging = True
    '    RadGrid1.Rebind()

    '    For i As Integer = 0 To numero - 1 '= RadGrid1.Items.Count   RadGrid1.MasterTableView.PageSize



    '        'OnLoadComplete(Console.Write(" World"))

    '        Debug.WriteLine(numero & " " & i)
    '        'Debug.WriteLine(RadGrid1.Columns.

    '    Next



    '    For Each item As GridDataItem In RadGrid1.Items
    '        Dim cadena As String = item.GetDataKeyValue("CADENA").ToString()
    '        Debug.WriteLine(cadena)
    '        RadGrid1.Rebind()
    '    Next
    'End Sub

    Private Sub ArmaCAdena()

        'Recorre los registros visibles en pantalla para hacer la solicitud de registro de operaciones a Cevaldom
        For Each item In RadGrid1.Items

            Try
                If TypeOf item Is GridDataItem Then

                    Dim dataItem As GridDataItem = TryCast(item, GridDataItem)

                    Dim cellCadena As TableCell = dataItem("CADENA")
                    Dim _strCadena As String = cellCadena.Text


                    Dim cellNumeroOperacion As TableCell = dataItem("numopersgo")
                    Dim _strNumeroOPeracion As String = cellNumeroOperacion.Text
                    'caleb

                    GenerarToken(_strCadena, _strNumeroOPeracion)





                End If
            Catch ex As Exception

            End Try



        Next
        'Consulta el estado de las operaciones del dia indicado en pantalla
        'hola
        EstadosOperacionesWS()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""
        'antonio


        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        If Not IsPostBack Then
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Operaciones Webservices", "Consulta de Operaciones Webservices", "")
            txtIdUsuario.Text = Session("IdUsuario")
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            ' Iniciar con la fecha del día 
            Dim FechaOperacion As Date = oper.ExecuteScalar("Select Top(1) FECHA_FILTRO from SIOPEL_INTERFACE_DB.dbo.vGen_XML_CEVALDOM_MONEYMARKET  order by FECHA_FILTRO desc")
            cStringWhere = String.Format("[FECHA_FILTRO]='{0}'", FechaOperacion)

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            'Filtro por defecto 
            Dim editor As New RadFilterTextFieldEditor()
            RadFilter1.FieldEditors.Add(editor)
            If Not IsPostBack Then
                editor.FieldName = "FECHA OPERACION"
                editor.DataType = GetType(Date)

                Dim expr As New RadFilterEqualToFilterExpression(Of Date)("FECHA_FILTRO")
                Dim Fecha As String = oper.FormatoFechayymmdd(FechaOperacion)
                expr.Value = Fecha
                RadFilter1.RootGroup.Expressions.Add(expr)

                ' Dim exprCorte As New RadFilterEqualToFilterExpression(Of String)("CORTE")
                Dim exprCorte As New RadFilterContainsFilterExpression("CORTE") With
                    {.Value = ""}
                'editor.FieldName = "CORTE"
                'editor.DataType = GetType(String)
                'exprCorte.Value = ""
                RadFilter1.RootGroup.Expressions.Add(exprCorte)

            End If

            txtIdConsulta.Text = 0
            RadFilter1.ApplyButtonText = "Aplicar Filtro"
            LlenarInformacionListaFiltros()
            DataRefresh()
        End If

        If Request.Params("__EVENTTARGET") = "ActualizarFiltrosConsultas" Then
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
            Page.Header.Title = "Consulta de Operaciones Webservices Cevaldom -> " & txtNombreConsultaUsuario.Text
        End If



    End Sub

    Protected Sub CargarInformacionFiltro(cNombreConsultaUsuario As String)
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT idConsulta,Filtro, EstruturaGrid FROM  [vFiltrosConsultas]  where NombreConsultaUsuario='{0}' AND IdUsuario='{1}' AND NombreConsulta='ConsultaOperacionesWS'", cNombreConsultaUsuario, txtIdUsuario.Text))
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
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [vFiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaOperacionesWS'", txtIdUsuario.Text))
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
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [FiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaOperacionesNotificacionesCevaldom' ORDER BY idConsulta ASC", txtIdUsuario.Text))
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

        'Try
        '    ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        '    Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        '    Dim provider As New RadFilterSqlQueryProvider()
        '    provider.ProcessGroup(e.ExpressionRoot)
        '    cStringWhere = provider.Result.Trim
        '    FechaFiltrada = cStringWhere

        '    ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        '    Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        '    DataRefresh()

        '    If Request.Params("__EVENTTARGET") = "ActualizarFiltros" Then
        '        LlenarInformacionListaFiltros1()
        '        If Session("NombreConsultaTemp") <> "" Then
        '            txtNombreConsultaUsuario.Text = Session("NombreConsultaTemp")
        '            CargarInformacionFiltro(Session("NombreConsultaTemp"))
        '            Session.Remove("NombreConsultaTemp")
        '        End If
        '        RadWindowManager1.Windows.Clear()
        '        Exit Sub
        '    End If
        '    If Session("FiltroBorrado") = 1 Then
        '        txtIdConsulta.Text = 0
        '        txtNombreConsultaUsuario.Text = ""
        '        Session.Remove("FiltroBorrado")
        '    End If
        '    If txtNombreConsultaUsuario.Text <> "" Then
        '        Page.Header.Title = "Consulta de Notificaciones Operaciones Cevaldom -> " & txtNombreConsultaUsuario.Text
        '    End If
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

    Protected Sub rgOperacionesWS_GroupsChanging(sender As Object, e As GridGroupsChangingEventArgs) Handles RadGrid1.GroupsChanging
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub rgOperacionesWS_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub rgOperacionesWS_ColumnsReorder(sender As Object, e As GridColumnsReorderEventArgs) Handles RadGrid1.ColumnsReorder
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub rgOperacionesWS_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGrid1.PageSizeChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub rgOperacionesWS_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub


    Sub DataRefresh()
        SqlvOperacionesCSV.SelectCommandType = SqlDataSourceCommandType.StoredProcedure

        If cStringWhere.IndexOf("01/01/0001") > 0 Then
            cStringWhere = cStringWhere.Replace("01/01/0001", oper.ConvertirFechaEnAmerican(Today.Date))
        End If
        'Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}
        'Dim Fecha As Date = Date.ParseExact(provider.Result.Trim.Substring(17, 10), format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None)
        If cStringWhere.Substring(0, 15) = "[FECHA_FILTRO]=" Then
            ' Dim Fecha1 As String = Provider.Result.Trim.Substring(17, 10)
            Dim Fecha1 As String = cStringWhere.Trim.Substring(14, 10)
            Dim FechaOperacion As String = cStringWhere.ToString()  'Fecha1.Trim.Substring(6, 4) & Fecha1.Trim.Substring(0, 2) & Fecha1.Trim.Substring(3, 2)
            txtfecha.Value = FechaOperacion & DateTime.Now.ToString("HHmmss")
        End If
        cStringWhere = cStringWhere.Replace(" 12:00:00 a.m.", "")
        SqlvOperacionesCSV.SelectParameters("SqlWhere").DefaultValue = cStringWhere
        SqlvOperacionesCSV.SelectCommand = "SP_ConsultadeOperacionesWS"
        ' rgOperacionesWS.DataBind()

    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick, RadToolBar2.ButtonClick
        If e.Item.Value <> "" Then
            If e.Item.Value = 0 Then 'Mover
                InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../herramientas/EnvioOperacionesCevaldom.aspx','1000','600')</" + "script>"
            ElseIf e.Item.Value = 1 Then 'Cancelar
                InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
            ElseIf e.Item.Value = 2 Then 'Enviar a Cevaldom

                'Dim SavePersister As New GridSettingsPersister(RadGrid1)
                'Dim cSettingGrid As String = ""

                'cSettingGrid = SavePersister.SaveSettings()
                'Session("EstruturaGrid") = SavePersister.SaveSettings()
                'Session("Filtro") = RadFilter1.SaveSettings()
                'Dim MyWindow As New RadWindow
                'MyWindow.NavigateUrl = String.Format("NombreConsultaUsuario.aspx?ID={0}&NC=EnvioOperacionesCevaldom&U={1}&NCU={2}", txtIdConsulta.Text, txtIdUsuario.Text, txtNombreConsultaUsuario.Text) '& "&F=" & RadFilter1.SaveSettings()
                'MyWindow.VisibleOnPageLoad = True
                'MyWindow.AutoSize = True
                'RadWindowManager1.Windows.Clear()
                'RadWindowManager1.Windows.Add(MyWindow)
                ArmaCAdena()
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
                'Call GenXMLforOperationCEVALDOM()

            End If
        Else
            If e.Item.Text <> "" Then
                txtNombreConsultaUsuario.Text = e.Item.Text
                Page.Header.Title = "Consulta de Envio Operaciones Cevaldom  Webservices -> " & e.Item.Text
                CargarInformacionFiltro(e.Item.Text)
            End If
        End If
    End Sub






End Class