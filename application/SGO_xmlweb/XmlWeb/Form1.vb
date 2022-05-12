Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Net.Mail
Imports System.Xml.Serialization
Imports Chilkat
Imports Chilkat_v9_5_0
Imports WinSCP


Public Class Form1
    Private oper As New Operation
    Private mydocpath As String = ""
    Private cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
    Private cnx2 As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
    'Private cnx As SqlConnection = New SqlConnection("Data Source=ADB03;Initial Catalog=WEB;Persist Security Info=True;User ID=appuser;Password=admin@123")
    'Private cnx2 As SqlConnection = New SqlConnection("Data Source=ADB03;Initial Catalog=WEB;Persist Security Info=True;User ID=appuser;Password=admin@123")
    Private cNombreArchivoXml As String = ""
    Private cNombreArchivoDisco As String = ""
    Private cNombreCarpeta As String = ""

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Asignar Parámetro a variable de la pantalla.
        ' cNombreArchivoXml = "PreciosPionners"
        ' cNombreArchivoXml = "instrumentos"
    End Sub

    Public Sub New(ByVal cArchivoXml As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Asignar Parámetro a variable de la pantalla.
        'MsgBox("primero " & cArchivoXml.Trim)
        cNombreArchivoXml = cArchivoXml.Trim
        'cNombreArchivoXml = "xmlposturas"

        ' TRABAJANDO 
        'Dim oLine As Form1 = New Form1(cArchivoXml.Trim)
        ' MsgBox(cNombreArchivoXml)
        'Console.WriteLine(cArchivoXml)
        'Debug.Print("Hello World!")
        'Dim txtFile As String = ""
        'Dim txtReaderFile As String
        'cnx2.Open()
        'txtReaderFile = "HOLA  " & cNombreArchivoXml.ToString
        'Dim oSW As New StreamWriter("D:\ERROR2.txt", False)
        'oSW.WriteLine(txtReaderFile)
        'oSW.Flush()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim currentTime As DateTime = DateTime.Now
        ' currentTime = currentTime.AddDays(-1) 
        cNombreCarpeta = currentTime.Date.ToString("yyyyMMdd") & DateAndTime.TimeOfDay.ToString("HHmmss")
        cnx.Open()
        btnGenerar_Click(sender, e)
        cnx.Close()
        Application.Exit()
    End Sub


    Private Sub btnGenerar_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerar.Click
        VerificarRutaLocal()
        EnviarArchivo()
        'EnviarArchivoSFTP()

    End Sub

    Private Sub GenerarArchivoXml(cStoreProcedure As String)
        Dim xmlFile As String = ""
        Dim cmd As New SqlCommand
        Dim xmlreaderFile As XmlReader
        cnx2.Close()
        cnx2.Open()
        cmd.CommandText = cStoreProcedure.Trim
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cnx2
        xmlreaderFile = cmd.ExecuteXmlReader()

        Using xmlWriter As XmlWriter = XmlWriter.Create(mydocpath + "\" + cNombreArchivoDisco.Trim + ".xml")
            xmlWriter.WriteNode(xmlreaderFile, False)
        End Using

        cnx2.Close()

        xmlreaderFile.Close()

    End Sub

    Private Sub GenerarArchivoTxt(cStoreProcedure As String)

        Dim txtFile As String = ""
        Dim cmd As New SqlCommand
        Dim txtReaderFile As SqlDataReader

        cnx2.Close()
        cnx2.Open()

        cmd.CommandText = cStoreProcedure.Trim
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Connection = cnx2

        txtReaderFile = cmd.ExecuteReader()

        If txtReaderFile.HasRows Then

            '   txtReaderFile.Read()

            Dim oSW As New StreamWriter(mydocpath + "\" + cNombreArchivoDisco.Trim + ".txt", False)

            Do While txtReaderFile.Read

                oSW.WriteLine(txtReaderFile.GetValue(0))
                oSW.Flush()

            Loop

            cnx2.Close()
        End If

        txtReaderFile.Close()
    End Sub
    ''' <summary>
    '''  Enviar a SFT
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnviarAsftp()
        Dim sftp As New Chilkat.SFtp()
        Dim success As Boolean
        'success = sftp.UnlockComponent("SSH12345678_50EDBA2D8O2Z")
        success = sftp.UnlockComponent("IE45JdSSH_ThDX1D6F0knX")


        If (success <> True) Then
            MsgBox(sftp.LastErrorText)
            Exit Sub
        End If

        sftp.ConnectTimeoutMs = 5000
        sftp.IdleTimeoutMs = 10000

        Dim port As Long
        Dim hostname As String
        hostname = "ftp.bvrd.com.do"
        port = 21
        success = sftp.Connect(hostname, port)
        If (success <> True) Then
            MsgBox(sftp.LastErrorText)
            Exit Sub
        End If

        success = sftp.AuthenticatePw("usuarioxml@bvrd.com.do", "Entrar_XML_034")
        If (success <> True) Then
            MsgBox(sftp.LastErrorText)
            Exit Sub
        End If

        success = sftp.InitializeSftp()
        If (success <> True) Then
            MsgBox(sftp.LastErrorText)
            Exit Sub
        End If

        Dim handle As String
        handle = sftp.OpenFile(mydocpath + "\Instrumento.xml", "writeOnly", "createTruncate")
        If (handle = vbNullString) Then
            MsgBox(sftp.LastErrorText)
            Exit Sub
        End If

        success = sftp.UploadFile(handle, "Instrumento.xml")
        If (success <> True) Then
            MsgBox(sftp.LastErrorText)
            Exit Sub
        End If

        success = sftp.CloseHandle(handle)
        If (success <> True) Then
            MsgBox(sftp.LastErrorText)
            Exit Sub
        End If

    End Sub

    ''' <summary>
    ''' Enviar a FTP : Todos los archivos de una carpeta 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnviarArchivo()
        Dim ftp As New Chilkat.Ftp2()
        ' ftp.Port = 21
        ftp.Passive = True
        Dim success As Boolean
        Dim command As SqlCommand = New SqlCommand("Select * from vArchivo where NombreArchivo = '" & cNombreArchivoXml.Trim & "';", cnx)
        'Dim command As SqlCommand = New SqlCommand("Select * from vArchivo where NombreArchivo = 'xmlemisiones';", cnx)
        Dim cmdArchivoLog As SqlCommand = New SqlCommand()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim cExtencionArchivo As String = ""
        Dim cRutaLocal As String = ""
        Dim cListadeEmail As String = ""

        If reader.HasRows Then

            reader.Read()

            'Archivo en Disco
            cNombreArchivoDisco = reader.GetValue(8)

            'Lista de Emails
            cListadeEmail = reader.GetValue(9)


            ' Generamos Archivo
            If Not IsDBNull(reader.GetValue(6)) Then

                Select Case Trim(reader.GetValue(7))

                    Case "XML"
                        GenerarArchivoXml(Trim(reader.GetValue(6)))
                        cExtencionArchivo = ".xml"
                    Case "TXT"
                        GenerarArchivoTxt(Trim(reader.GetValue(6)))
                        cExtencionArchivo = ".txt"
                End Select

            End If

            cRutaLocal = Trim(reader.GetValue(1))

            ' Ruta Libre

            If cRutaLocal <> "" Then ' Ruta local 

                If Trim(reader.GetValue(1)) <> "" Then

                    My.Computer.FileSystem.CopyFile(mydocpath + "\" + cNombreArchivoDisco + cExtencionArchivo, Trim(reader.GetValue(1)) + "\" + cNombreArchivoDisco + cExtencionArchivo, True)
                End If
            End If


            ' FTP

            If Trim(reader.GetValue(2)) <> "" Then ' Enviar FTP

                ' success = ftp.UnlockComponent("FTP212345678_6D53B640jA1J")
                success = ftp.UnlockComponent("uKADIIFTP_4K8X10Sj7ynL")

                If (success <> True) Then
                    Exit Sub
                End If

                If Trim(reader.GetValue(2)) <> "" Then

                    'TODO: Investigar como llamar el valor con el total de la columna

                    ftp.Hostname = Trim(reader.GetValue(2))   '"ftp.bvrd.com.do"
                    ftp.Username = Trim(reader.GetValue(3))   '"usuarioxml@bvrd.com.do"
                    ftp.Password = Trim(reader.GetValue(4))   '"Entrar_XML_034"

                    'Conectar al Servidor Remoto FTP
                    If Trim(reader.GetValue(11)) = "FTP" Then
                        success = ftp.Connect()
                        If (success <> True) Then
                            Exit Sub
                        End If

                        'Cambiar la ruta a la carpeta destino
                        If Not IsDBNull(reader.GetValue(5)) Then
                            If Trim(reader.GetValue(5)) <> "" Then
                                success = ftp.ChangeRemoteDir(Trim(reader.GetValue(5)))
                                If (success <> True) Then
                                    Exit Sub
                                End If
                            End If
                        End If

                        Dim numFilesUploaded As Long
                        ' MessageBox.Show(mydocpath + "\" + "*" + cExtencionArchivo)
                        numFilesUploaded = ftp.MPutFiles(mydocpath + "\" + "*" + cExtencionArchivo)
                        'MessageBox.Show(numFilesUploaded.ToString())
                        If (numFilesUploaded < 0) Then
                            MsgBox(ftp.LastErrorText)
                            Exit Sub
                        Else
                            If (reader.GetValue(0).ToString().Trim() <> "") Then
                                cnx2.Open()
                                cmdArchivoLog.CommandText = "SP_GenerarArchivosLOG '" + reader.GetValue(0) + "'"
                                cmdArchivoLog.CommandType = CommandType.Text
                                cmdArchivoLog.Connection = cnx2
                                cmdArchivoLog.ExecuteNonQuery()
                                cnx2.Close()
                            End If
                            ftp.Disconnect()
                        End If
                    End If ' If Trim(reader.GetValue(4)) = "FTP" Then

                    'Conectar al Servidor Remoto SFTP
                    If Trim(reader.GetValue(11)) = "SFTP" Then
                        ' success = ftp.Connect()

                        ' Set up session options
                        Dim sessionOptions As New SessionOptions
                        With sessionOptions
                            .Protocol = Protocol.Sftp
                            .SshHostKeyPolicy = True
                            .HostName = Trim(reader.GetValue(2))
                            .UserName = Trim(reader.GetValue(3))
                            .Password = Trim(reader.GetValue(4))
                            .SshHostKeyFingerprint = "ssh-rsa 1024 9roThNnt9C8vowuRctrUVR5krDi7JKa9NlNNuD4X448="
                        End With

                        Using session As New Session
                            ' Connect 
                            Dim transferOptions As New TransferOptions
                            transferOptions.TransferMode = TransferMode.Binary
                            transferOptions.ResumeSupport.State = TransferResumeSupportState.Off

                            Dim transferResult As TransferOperationResult
                            session.Open(sessionOptions)
                            ' session.PutFiles(mydocpath + "\" + "*" + cExtencionArchivo, "/")
                            transferResult = session.PutFiles(mydocpath + "\" + "*" + cExtencionArchivo, "/", False, transferOptions)

                            'transferResult.Check()

                            'For Each transfer As TransferEventArgs In transferResult.Transfers
                            '    Dim finalName As String = transfer.Destination.Replace(".filepart", "")
                            '    session.MoveFile(transfer.Destination, finalName)
                            'Next


                        End Using

                        If (reader.GetValue(0).ToString().Trim() <> "") Then
                            cnx2.Open()
                            cmdArchivoLog.CommandText = "SP_GenerarArchivosLOG '" + reader.GetValue(0) + "'"
                            cmdArchivoLog.CommandType = CommandType.Text
                            cmdArchivoLog.Connection = cnx2
                            cmdArchivoLog.ExecuteNonQuery()
                            cnx2.Close()
                        End If
                        'ftp.Disconnect()
                    End If  'If Trim(reader.GetValue(4)) = "FTP" Then


                End If
            ' EMAIL
            If cListadeEmail.Trim <> "" Then
                EnviarEmail("BVRD : Envío de Archivo", "Adjunto Archivo generado", cListadeEmail.Trim, Trim(reader.GetValue(1)) + "\" + cNombreArchivoDisco + cExtencionArchivo)
            End If

        End If
        End If

        reader.Close()
    End Sub

    Private Sub EnviarArchivoSFTP()
        Dim ftp As New Chilkat.SFtp()
        'Dim ftp As New Chilkat_v9_5_0.ChilkatSFtp.;

        ' ftp.Port = 21
        ' ftp.Passive = True
        Dim success As Boolean
        Dim command As SqlCommand = New SqlCommand("Select * from vArchivo where NombreArchivo = 'xmlemisiones';",
          cnx)
        Dim cmdArchivoLog As SqlCommand = New SqlCommand()

        Dim reader As SqlDataReader = command.ExecuteReader()

        Dim cExtencionArchivo As String = ""
        Dim cRutaLocal As String = ""
        Dim cListadeEmail As String = ""

        If reader.HasRows Then

            reader.Read()

            'Archivo en Disco
            cNombreArchivoDisco = reader.GetValue(8)

            'Lista de Emails
            cListadeEmail = reader.GetValue(9)


            ' Generamos Archivo
            If Not IsDBNull(reader.GetValue(6)) Then

                Select Case Trim(reader.GetValue(7))

                    Case "XML"
                        GenerarArchivoXml(Trim(reader.GetValue(6)))
                        cExtencionArchivo = ".xml"
                    Case "TXT"
                        GenerarArchivoTxt(Trim(reader.GetValue(6)))
                        cExtencionArchivo = ".txt"
                End Select

            End If

            cRutaLocal = Trim(reader.GetValue(1))

            ' Ruta Libre

            If cRutaLocal <> "" Then ' Ruta local 

                If Trim(reader.GetValue(1)) <> "" Then

                    My.Computer.FileSystem.CopyFile(mydocpath + "\" + cNombreArchivoDisco + cExtencionArchivo, Trim(reader.GetValue(1)) + "\" + cNombreArchivoDisco + cExtencionArchivo, True)
                End If
            End If


            ' FTP

            If Trim(reader.GetValue(2)) <> "" Then ' Enviar FTP

                'success = ftp.UnlockComponent("FTP212345678_6D53B640jA1J")
                'success = ftp.UnlockComponent("uKADIIFTP_4K8X10Sj7ynL")
                success = ftp.UnlockComponent("IE45JdSSH_ThDX1D6F0knX")


                If (success <> True) Then
                    Exit Sub
                End If

                If Trim(reader.GetValue(2)) <> "" Then

                    'TODO: Investigar como llamar el valor con el total de la columna

                    Dim Hostname As String = Trim(reader.GetValue(2))   '"ftp.bvrd.com.do"
                    Dim Username As String = Trim(reader.GetValue(3))   '"usuarioxml@bvrd.com.do"
                    Dim Password As String = Trim(reader.GetValue(4))   '"Entrar_XML_034"
                    Dim Port As String = 22

                    'Conectar al Servidor Remoto
                    success = ftp.Connect(Hostname.ToString(), Port.ToString())
                    If (success <> True) Then
                        Exit Sub
                    End If

                    'Autentificación al Servidor Remoto
                    success = ftp.AuthenticatePw(Username.ToString(), Password.ToString())
                    If (success <> True) Then
                        Exit Sub
                    End If

                    '  After authenticating, the SFTP subsystem must be initialized:
                    success = ftp.InitializeSftp()
                    If (success <> True) Then
                        Exit Sub
                    End If

                    'Cambiar la ruta a la carpeta destino
                    'If Not IsDBNull(reader.GetValue(5)) Then
                    '    If Trim(reader.GetValue(5)) <> "" Then
                    '        success = ftp.ChangeRemoteDir(Trim(reader.GetValue(5)))
                    '        If (success <> True) Then
                    '            Exit Sub
                    '        End If
                    '    End If
                    'End If

                    Dim numFilesUploaded As Long
                    ' MessageBox.Show(mydocpath + "\" + "*" + cExtencionArchivo)
                    'numFilesUploaded = ftp.MPutFiles(mydocpath + "\" + "*" + cExtencionArchivo)
                    numFilesUploaded = ftp.UploadFile("", mydocpath + "\" + "*" + cExtencionArchivo)
                    'MessageBox.Show(numFilesUploaded.ToString())
                    If (numFilesUploaded < 0) Then
                        MsgBox(ftp.LastErrorText)
                        Exit Sub
                    Else
                        If (reader.GetValue(0).ToString().Trim() <> "") Then
                            cnx2.Open()
                            cmdArchivoLog.CommandText = "SP_GenerarArchivosLOG '" + reader.GetValue(0) + "'"
                            cmdArchivoLog.CommandType = CommandType.Text
                            cmdArchivoLog.Connection = cnx2
                            cmdArchivoLog.ExecuteNonQuery()
                            cnx2.Close()
                        End If
                        ftp.Disconnect()
                    End If
                End If
                ' EMAIL
                If cListadeEmail.Trim <> "" Then
                    EnviarEmail("BVRD : Envío de Archivo", "Adjunto Archivo generado", cListadeEmail.Trim, Trim(reader.GetValue(1)) + "\" + cNombreArchivoDisco + cExtencionArchivo)
                End If

            End If
        End If

        reader.Close()
    End Sub

    Protected Overrides Sub Finalize()
        cnx.Close()
        MyBase.Finalize()
    End Sub
    Private Sub VerificarRutaLocal()

        If Not My.Computer.FileSystem.DirectoryExists(oper.App_Path + "\ArchivosXML") Then
            My.Computer.FileSystem.CreateDirectory(oper.App_Path + "\ArchivosXML")
        End If

        If Not My.Computer.FileSystem.DirectoryExists(oper.App_Path + "\ArchivosXML" + cNombreCarpeta.Trim) Then
            My.Computer.FileSystem.CreateDirectory(oper.App_Path + "\ArchivosXML\" + cNombreCarpeta.Trim)
        End If

        mydocpath = oper.App_Path.Substring(0, Len(oper.App_Path) - 1) + "\ArchivosXML\" + cNombreCarpeta.Trim
    End Sub
    Private Sub EnviarEmail(pAsunto As String, pCuerpo As String, pEnviarA As String, pArchivo As String)
        Dim mail As New MailMessage()

        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Configuracion]")
        Dim myRow As DataRow
        Dim cEmail As String = ""
        Dim cUsuario As String = ""
        Dim cPass As String = ""
        Dim cServidor As String = ""
        Dim cPuerto As String = ""
        Dim cEmailDestino As String = ""
        Dim cEmailConSSL As Boolean = False

        For Each myRow In ds.Tables(0).Rows

            If Not IsDBNull(myRow.Item("Email")) Then cEmail = Trim(myRow.Item("Email"))
            If Not IsDBNull(myRow.Item("Usuario")) Then cUsuario = Trim(myRow.Item("Usuario"))

            If Not IsDBNull(myRow.Item("Pass")) Then cPass = Trim(myRow.Item("Pass"))
            If Not IsDBNull(myRow.Item("Servidor")) Then cServidor = Trim(myRow.Item("Servidor"))
            If Not IsDBNull(myRow.Item("Puerto")) Then cPuerto = Trim(myRow.Item("Puerto"))
            If Not IsDBNull(myRow.Item("EmailDestino")) Then cEmailDestino = Trim(myRow.Item("EmailDestino"))

            If Not IsDBNull(myRow.Item("EmailConSSL")) Then cEmailConSSL = Trim(myRow.Item("EmailConSSL"))
        Next

        Dim smtpServer As New SmtpClient(cServidor)

        mail.From = New MailAddress(cEmail)
        mail.[To].Add(pEnviarA)
        mail.Subject = pAsunto
        mail.Body = pCuerpo

        Dim att As New Attachment(pArchivo)
        mail.Attachments.Add(att)

        smtpServer.Port = cPuerto
        smtpServer.Credentials = New System.Net.NetworkCredential(cUsuario, cPass)
        smtpServer.EnableSsl = cEmailConSSL
        Try
            smtpServer.Send(mail)
        Catch ex As Exception
            Application.Exit()
        End Try

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim dsOperacionesSIV As New DataSet

        dsOperacionesSIV = oper.ExDataSet("select  * from OperacionesSIV")

        If Not dsOperacionesSIV Is Nothing Then

            Dim objBvvrd As New BvrdType

            Dim objTransaccion As transaccion
            Dim transaccionesList As New List(Of transaccion)

            For Each myRow In dsOperacionesSIV.Tables(0).Rows

                objTransaccion = New transaccion

                '  objTransaccion.cant_valor_nominal = 5
                If Not IsDBNull(myRow.Item("cant_valor_nominal")) Then objTransaccion.cant_valor_nominal = Trim(myRow.Item("cant_valor_nominal"))

                '   objTransaccion.cod_isin = "test"
                If Not IsDBNull(myRow.Item("cod_isin")) Then objTransaccion.cod_isin = Trim(myRow.Item("cod_isin"))

                objTransaccion.rnc_puesto = "001211"
                If Not IsDBNull(myRow.Item("rnc_puesto")) Then objTransaccion.rnc_puesto = Trim(myRow.Item("rnc_puesto"))

                ' objTransaccion.rnc_emisor = "00321"
                If Not IsDBNull(myRow.Item("rnc_emisor")) Then objTransaccion.rnc_emisor = Trim(myRow.Item("rnc_emisor"))

                '  objTransaccion.cod_siv_emision = "dsdsfd"
                If Not IsDBNull(myRow.Item("cod_siv_emision")) Then objTransaccion.cod_siv_emision = Trim(myRow.Item("cod_siv_emision"))

                '   objTransaccion.cod_isin = "2222"
                If Not IsDBNull(myRow.Item("cod_isin")) Then objTransaccion.cod_isin = Trim(myRow.Item("cod_isin"))

                '   objTransaccion.serie = "3444"
                If Not IsDBNull(myRow.Item("serie")) Then objTransaccion.serie = Trim(myRow.Item("serie"))

                '  objTransaccion.cod_moneda = "5555"
                If Not IsDBNull(myRow.Item("cod_moneda")) Then objTransaccion.cod_moneda = Trim(myRow.Item("cod_moneda"))

                '  objTransaccion.num_operacion = "5555"
                If Not IsDBNull(myRow.Item("num_operacion")) Then objTransaccion.num_operacion = Trim(myRow.Item("num_operacion"))

                objTransaccion.tasas = New tipotasa()

                ' objTransaccion.tasas.tasa_int_facial = 2
                If Not IsDBNull(myRow.Item("tasa_int_facial")) Then objTransaccion.tasas.tasa_int_facial = Trim(myRow.Item("tasa_int_facial"))

                ' objTransaccion.tasas.tasa_int_rendimiento = 4
                If Not IsDBNull(myRow.Item("tasa_int_rendimiento")) Then objTransaccion.tasas.tasa_int_rendimiento = Trim(myRow.Item("tasa_int_rendimiento"))

                objTransaccion.fechas = New tipofecha()

                If Not IsDBNull(myRow.Item("fecha_valor")) Then objTransaccion.fechas.fecha_valor = Trim(myRow.Item("fecha_valor"))

                ''   objTransaccion.fechas.fecha_venc_mutuo = Date.Now
                If Not IsDBNull(myRow.Item("fecha_venc_mutuo")) Then objTransaccion.fechas.fecha_venc_mutuo = Trim(myRow.Item("fecha_venc_mutuo"))

                '   objTransaccion.unidad_valor_nominal = 1
                If Not IsDBNull(myRow.Item("unidad_valor_nominal")) Then objTransaccion.unidad_valor_nominal = Trim(myRow.Item("unidad_valor_nominal"))

                '   objTransaccion.valor_nominal = 1
                If Not IsDBNull(myRow.Item("valor_nominal")) Then objTransaccion.valor_nominal = Trim(myRow.Item("valor_nominal"))

                ' objTransaccion.cant_valor_nominal = 1
                If Not IsDBNull(myRow.Item("cant_valor_nominal")) Then objTransaccion.cant_valor_nominal = Trim(myRow.Item("cant_valor_nominal"))

                '  objTransaccion.precio_mercado = 1
                If Not IsDBNull(myRow.Item("precio_mercado")) Then objTransaccion.precio_mercado = Trim(myRow.Item("precio_mercado"))

                ' objTransaccion.valor_mercado = 23
                If Not IsDBNull(myRow.Item("valor_mercado")) Then objTransaccion.valor_mercado = Trim(myRow.Item("valor_mercado"))

                Select Case myRow.Item("clasif_operacion")
                    Case "ND"
                        objTransaccion.clasif_operacion = clasifoperacion.ND
                    Case "PRP"
                        objTransaccion.clasif_operacion = clasifoperacion.PRP
                    Case "REQ"
                        objTransaccion.clasif_operacion = clasifoperacion.REQ
                End Select
                objTransaccion.clasif_operacionSpecified = True

                '   objTransaccion.tipo_transaccion = tipotransaccion.CPR

                Select Case myRow.Item("tipo_transaccion")
                    Case "CPR"
                        objTransaccion.tipo_transaccion = tipotransaccion.CPR
                    Case "VNT"
                        objTransaccion.tipo_transaccion = tipotransaccion.VNT
                    Case "MNT"
                        objTransaccion.tipo_transaccion = tipotransaccion.MNT
                    Case "MTR"
                        objTransaccion.tipo_transaccion = tipotransaccion.MTR
                    Case "OTR"
                        objTransaccion.tipo_transaccion = tipotransaccion.OTR
                End Select

                objTransaccion.tipo_transaccionSpecified = True

                '       objTransaccion.tipo_contrato() = tipocontrato.DIVHE
                If Not IsDBNull(myRow.Item("tipo_contrato")) Then

                    Select Case myRow.Item("tipo_contrato")
                        Case "SPT"
                            objTransaccion.tipo_contrato = tipocontrato.SPT
                        Case "FRW"
                            objTransaccion.tipo_contrato = tipocontrato.FRW
                        Case "MTO"
                            objTransaccion.tipo_contrato = tipocontrato.MTO
                        Case "HEREN"
                            objTransaccion.tipo_contrato = tipocontrato.HEREN
                        Case "DIVHE"
                            objTransaccion.tipo_contrato = tipocontrato.DIVHE
                        Case "SPSCC"
                            objTransaccion.tipo_contrato = tipocontrato.SPSCC
                        Case "DONAC"
                            objTransaccion.tipo_contrato = tipocontrato.DONAC
                        Case "DIVPP"
                            objTransaccion.tipo_contrato = tipocontrato.DIVPP
                        Case "FUSES"
                            objTransaccion.tipo_contrato = tipocontrato.FUSES
                        Case "FUNFM"
                            objTransaccion.tipo_contrato = tipocontrato.FUNFM
                        Case "EFCDP"
                            objTransaccion.tipo_contrato = tipocontrato.EFCDP
                        Case "MNDLJ"
                            objTransaccion.tipo_contrato = tipocontrato.MNDLJ
                        Case "TRCOP"
                            objTransaccion.tipo_contrato = tipocontrato.TRCOP

                    End Select
                    objTransaccion.tipo_contratoSpecified = True
                End If

                '   objTransaccion.tipo_mercado() = tipomercado.PRI
                If Not IsDBNull(myRow.Item("tipo_mercado")) Then
                    Select Case myRow.Item("tipo_mercado")
                        Case "PRI"
                            objTransaccion.tipo_mercado = tipomercado.PRI
                        Case "SEC"
                            objTransaccion.tipo_mercado = tipomercado.SEC
                    End Select
                    objTransaccion.tipo_mercadoSpecified = True
                End If

                If Not IsDBNull(myRow.Item("tipo_operacion")) Then
                    Select Case myRow.Item("tipo_operacion")
                        Case "CTER"

                            objTransaccion.tipo_operacion = tipooperacion.CTER
                        Case "CPROP"
                            objTransaccion.tipo_operacion = tipooperacion.CPROP
                    End Select
                    objTransaccion.tipo_operacionSpecified = True
                End If

                transaccionesList.Add(objTransaccion)
            Next

            objBvvrd.fecha = Date.Now
            objBvvrd.transaccion = transaccionesList.ToArray
            objBvvrd.rnc = "101-87151-2"
            objBvvrd.version = "1"

            Dim serializer As New XmlSerializer(objBvvrd.GetType)

            Dim stream As New StreamWriter("C:\jeanc\test.xml")

            Using stream

                serializer.Serialize(stream, objBvvrd)

            End Using
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        EnviarEmail("Prueba 1", "cuerpo de prueba 1", "mcastillo@bvrd.com.do", "C:\temp\prueba.xls")
        'pAsunto As String, pCuerpo As String, pEnviarA As String, pArchivo As String
    End Sub


End Class



