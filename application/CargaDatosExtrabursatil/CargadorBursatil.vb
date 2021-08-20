Imports System.Xml
Imports System.IO
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Globalization

Public Class CargadorBursatil
    Private oper As New operation
    Private cNombreArchivoXML As String = ""

    Dim mail As Mailer = New Mailer()

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Asignar Parámetro a variable de la pantalla.
        'cNombreArchivoXML = "SIV"
        cNombreArchivoXML = "CEVALDOM"

    End Sub

    Public Sub New(ByVal cArchivoXML As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Asignar Parámetro a variable de la pantalla.
        cNombreArchivoXML = cArchivoXML.Trim

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cNombreArchivoXML = "CEVALDOM" Then
            CargarArchivoCEVALDOM()
        ElseIf cNombreArchivoXML = "SIV" Then
            CargarArchivoSIV()
        End If


    End Sub

    '----------------------------------------------------------------------
    '- Carga de datos Archivo CEVALDOM
    '----------------------------------------------------------------------
    Private Sub CargarArchivoCEVALDOM()
        Dim xmldoc As XmlDocument = New XmlDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim cRutaArchivoXML As String = ""
        Dim cRutaArchivoXML_Destino As String = ""
        Dim CadenaFecha As String = ""
        Dim cRutaArchivoXML_Archivo As String = ""
        Dim cRutaArchivoXML_Archivo_Destino As String = ""
        Dim nTotalArchivosEncabezado As Integer = 0
        Dim nTotalArchivosDetalle As Integer = 0
        Dim strBody As String = ""

        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Configuracion] where Archivo = 'CEVALDOM'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("CarpetaCarga")) Then cRutaArchivoXML = Trim(MyRow.Item("CarpetaCarga"))
            If Not IsDBNull(MyRow.Item("CarpetaCopia")) Then cRutaArchivoXML_Destino = Trim(MyRow.Item("CarpetaCopia"))
        Next

        Dim Files As String(), File As String
        '-------------------------------------------------------
        'Leyendo los archivos de la carpeta 
        '-------------------------------------------------------
        If Not Directory.Exists(cRutaArchivoXML) Then Exit Sub
        Files = IO.Directory.GetFiles(cRutaArchivoXML, "*.xml")

        If Files.Count = 0 Then
            EnviameUnCorreo("Carga Archivo: CEVALDOM XML", "No hay archivos XML en la carpeta configurada.", "CEVALDOM")

        End If

        For Each File In Files

            '-------------------------------------------------------
            'Lee el nombre del fichero sin su extension 
            '-------------------------------------------------------
            If File.Trim <> "" Then
                cRutaArchivoXML_Archivo = File
                cRutaArchivoXML_Archivo_Destino = cRutaArchivoXML_Destino & IO.Path.GetFileName(File)

                'Dim fs As New FileStream(cRutaArchivoXML_Archivo, FileMode.Open, FileAccess.Read)

                Dim fs As New StreamReader(cRutaArchivoXML_Archivo, True)

                Dim UniqueID As Integer = 0
                Dim ID_RegistroDetalle As String = ""

                Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                Cnx.Open()

                Try
                    xmldoc.Load(fs)
                    ' -----------------------------------------------------------------------------
                    ' Encabezado
                    ' -----------------------------------------------------------------------------
                    xmlnode = xmldoc.GetElementsByTagName("Encabezado")

                    For i = 0 To xmlnode.Count - 1
                        xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                        Dim Sql As String = "INSERT INTO [VectorPreciosEncabezado] ([Fecha_hora_carga],[ID_bach_carga],[Usuario],[ArchivoCargado],[INSTITUCION_EMISORA],[FECHA_HORA],[FECHA_DESDE],[FECHA_HASTA],[OPERACIONES_LIQUIDADAS],[OPERACIONES_PENDIENTES],[PC]) VALUES (@Fecha_hora_carga,@ID_bach_carga,@Usuario,@ArchivoCargado,@INSTITUCION_EMISORA,@FECHA_HORA,@FECHA_DESDE,@FECHA_HASTA,@OPERACIONES_LIQUIDADAS,@OPERACIONES_PENDIENTES,@PC)"
                        Dim Sql2 As String = "Select @@Identity"
                        Dim cmd As New SqlCommand(Sql, Cnx)
                        Dim now As DateTime = DateTime.Now

                        cmd.Parameters.Add(New SqlParameter("@Fecha_hora_carga", SqlDbType.DateTime)).Value = now.ToString() 'DateTime.Today
                        cmd.Parameters.Add(New SqlParameter("@ID_bach_carga", SqlDbType.VarChar)).Value = ""
                        cmd.Parameters.Add(New SqlParameter("@Usuario", SqlDbType.VarChar)).Value = My.User.Name
                        cmd.Parameters.Add(New SqlParameter("@PC", SqlDbType.VarChar)).Value = My.Computer.Name.ToUpper
                        cmd.Parameters.Add(New SqlParameter("@ArchivoCargado", SqlDbType.VarChar)).Value = cRutaArchivoXML_Archivo.Trim
                        CadenaFecha = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                        CadenaFecha = oper.ConvertirCadenaFechaEnAmerican(CadenaFecha.Substring(0, 10)) & " " & CadenaFecha.Substring(11, 11)
                        cmd.Parameters.Add(New SqlParameter("@FECHA_HORA", SqlDbType.DateTime)).Value = DateTime.Parse(CadenaFecha)
                        cmd.Parameters.Add(New SqlParameter("@INSTITUCION_EMISORA", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                        CadenaFecha = oper.ConvertirCadenaFechaEnAmerican(xmlnode(i).ChildNodes.Item(2).InnerText.Trim())
                        cmd.Parameters.Add(New SqlParameter("@FECHA_DESDE", SqlDbType.Date)).Value = Date.Parse(CadenaFecha)
                        CadenaFecha = oper.ConvertirCadenaFechaEnAmerican(xmlnode(i).ChildNodes.Item(3).InnerText.Trim())
                        cmd.Parameters.Add(New SqlParameter("@FECHA_HASTA", SqlDbType.Date)).Value = Date.Parse(CadenaFecha)
                        cmd.Parameters.Add(New SqlParameter("@OPERACIONES_LIQUIDADAS", SqlDbType.Int)).Value = xmlnode(i).ChildNodes.Item(4).InnerText.Trim()
                        cmd.Parameters.Add(New SqlParameter("@OPERACIONES_PENDIENTES", SqlDbType.Int)).Value = xmlnode(i).ChildNodes.Item(5).InnerText.Trim()
                        nTotalArchivosEncabezado = nTotalArchivosEncabezado + 1

                        cmd.ExecuteNonQuery()
                        cmd.CommandText = Sql2
                        UniqueID = cmd.ExecuteScalar()

                    Next

                    ' -----------------------------------------------------------------------------
                    ' Detalle
                    ' -----------------------------------------------------------------------------
                    xmlnode = xmldoc.GetElementsByTagName("Operacion")
                    For i = 0 To xmlnode.Count - 1
                        xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                        Dim Sql As String = "INSERT INTO [VectorPreciosDetalle] ([ID_Operacion],[ID_REGISTRO],[FECHA_REGISTRO],[HORA_REGISTRO],[FECHA_LIQUIDACION],[NEMOTECNICO_EMISION],[CODIGO_ISIN],[TIPO_INSTRUMENTO],[EMISOR],[FECHA_EMISION],[FECHA_VENCIMIENTO],[CANTIDAD_VALORES],[VALOR_NOMINAL],[VALOR_NOMINAL_TOTAL], [VALOR_TRANSADO],[MONEDA_TRANSACCION]) VALUES " &
                                                                               "(@ID_Operacion,@ID_REGISTRO,@FECHA_REGISTRO,@HORA_REGISTRO,@FECHA_LIQUIDACION,@NEMOTECNICO_EMISION,@CODIGO_ISIN,@TIPO_INSTRUMENTO,@EMISOR,@FECHA_EMISION,@FECHA_VENCIMIENTO,@CANTIDAD_VALORES,@VALOR_NOMINAL,@VALOR_NOMINAL_TOTAL,@VALOR_TRANSADO,@MONEDA_TRANSACCION)"

                        Dim Sql2 As String = "Select ID_REGISTRO from [VectorPreciosDetalle] where ID_REGISTRO='" & xmlnode(i).ChildNodes.Item(0).InnerText.Trim() & "'"
                        Dim cmd As New SqlCommand(Sql, Cnx)
                        Dim cmd2 As New SqlCommand(Sql2, Cnx)

                        ID_RegistroDetalle = cmd2.ExecuteScalar()

                        If ID_RegistroDetalle = "" Or ID_RegistroDetalle = Nothing Then
                            cmd.Parameters.Add(New SqlParameter("@ID_Operacion", SqlDbType.Int)).Value = UniqueID
                            cmd.Parameters.Add(New SqlParameter("@ID_REGISTRO", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                            CadenaFecha = oper.ConvertirCadenaFechaEnAmerican(xmlnode(i).ChildNodes.Item(1).InnerText.Trim())
                            cmd.Parameters.Add(New SqlParameter("@FECHA_REGISTRO", SqlDbType.DateTime)).Value = DateTime.Parse(CadenaFecha)
                            cmd.Parameters.Add(New SqlParameter("@HORA_REGISTRO", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(2).InnerText.Trim()
                            CadenaFecha = oper.ConvertirCadenaFechaEnAmerican(xmlnode(i).ChildNodes.Item(3).InnerText.Trim())
                            cmd.Parameters.Add(New SqlParameter("@FECHA_LIQUIDACION", SqlDbType.Date)).Value = Date.Parse(CadenaFecha)
                            cmd.Parameters.Add(New SqlParameter("@NEMOTECNICO_EMISION", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(4).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@CODIGO_ISIN", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(5).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@TIPO_INSTRUMENTO", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(6).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@EMISOR", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(7).InnerText.Trim()
                            CadenaFecha = oper.ConvertirCadenaFechaEnAmerican(xmlnode(i).ChildNodes.Item(8).InnerText.Trim())
                            cmd.Parameters.Add(New SqlParameter("@FECHA_EMISION", SqlDbType.Date)).Value = Date.Parse(CadenaFecha)
                            CadenaFecha = oper.ConvertirCadenaFechaEnAmerican(xmlnode(i).ChildNodes.Item(9).InnerText.Trim())
                            cmd.Parameters.Add(New SqlParameter("@FECHA_VENCIMIENTO", SqlDbType.Date)).Value = Date.Parse(CadenaFecha)
                            cmd.Parameters.Add(New SqlParameter("@CANTIDAD_VALORES", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(10).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@VALOR_NOMINAL", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(11).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@VALOR_NOMINAL_TOTAL", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(12).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@VALOR_TRANSADO", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(13).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@MONEDA_TRANSACCION", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(14).InnerText.Trim()

                            cmd.ExecuteNonQuery()
                            'If i = 865 Then
                            '    MsgBox("hola")
                            'End If
                            nTotalArchivosDetalle += 1

                        End If
                    Next

                    fs.Close()
                    IO.File.Copy(cRutaArchivoXML_Archivo, cRutaArchivoXML_Archivo_Destino, True)
                    My.Computer.FileSystem.DeleteFile(cRutaArchivoXML_Archivo)

                Catch ex As Exception
                    EnviameUnCorreo("Carga Archivo: CEVALDOM XML (ERROR) ", ex.Message.Trim, "CEVALDOM")

                Finally
                    strBody = "Archivo " & cRutaArchivoXML_Archivo & vbCrLf
                    strBody += " Cargado Correctamente. "
                    strBody += " Encabezado : " & nTotalArchivosEncabezado.ToString.Trim & vbCrLf
                    strBody += " Detalle : " & nTotalArchivosDetalle.ToString.Trim

                    EnviameUnCorreo("Carga Archivo: CEVALDOM XML", strBody, "CEVALDOM")
                    Cnx.Close()

                End Try

            End If

        Next
    End Sub

    '----------------------------------------------------------------------
    '- Carga de datos Archivo SIV
    '----------------------------------------------------------------------
    Private Sub CargarArchivoSIV()
        Dim xmldoc As XmlDocument = New XmlDocument()
        Dim xmlnode As XmlNodeList
        Dim i As Integer
        Dim cRutaArchivoXML As String = ""
        Dim cRutaArchivoXML_Destino As String = ""
        Dim CadenaFecha As String = ""
        Dim cRutaArchivoXML_Archivo As String = ""
        Dim cRutaArchivoXML_Archivo_Destino As String = ""
        Dim nTotalArchivosEncabezado As Integer = 0
        Dim nTotalArchivosDetalle As Integer = 0
        Dim nTotalArchivosDetalleRepetidos As Integer = 0
        Dim strBody As String = ""
        Dim cSQL As String = ""
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Configuracion] where Archivo = 'SIV'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("CarpetaCarga")) Then cRutaArchivoXML = Trim(MyRow.Item("CarpetaCarga"))
            If Not IsDBNull(MyRow.Item("CarpetaCopia")) Then cRutaArchivoXML_Destino = Trim(MyRow.Item("CarpetaCopia"))
        Next

        Dim Files As String(), File As String
        '-------------------------------------------------------
        'Leyendo los archivos de la carpeta 
        '-------------------------------------------------------

        If Not Directory.Exists(cRutaArchivoXML) Then Exit Sub
        Files = IO.Directory.GetFiles(cRutaArchivoXML, "*.xml")

        If Files.Count = 0 Then
            EnviameUnCorreo("Carga Archivo: SIV XML", "No hay archivos XML en la carpeta configurada.", "SIV")
        End If

        For Each File In Files
            '-------------------------------------------------------
            'Lee el nombre del fichero sin su extension 
            '-------------------------------------------------------
            If File.Trim <> "" Then
                cRutaArchivoXML_Archivo = File
                cRutaArchivoXML_Archivo_Destino = cRutaArchivoXML_Destino & IO.Path.GetFileName(File)
                Dim fs As New StreamReader(cRutaArchivoXML_Archivo, True)
                Dim UniqueID As Integer = 0
                Dim ID_RegistroDetalle As String = ""
                Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                Cnx.Open()

                Try
                    xmldoc.Load(fs)
                    ' -----------------------------------------------------------------------------
                    ' Encabezado
                    ' -----------------------------------------------------------------------------

                    Dim SqlE As String = "INSERT INTO [Extrabursatil].[dbo].[SIVVectoresEncabezado]" &
                                            "([Fecha_hora_carga]" &
                                            ",[ID_bach_carga]" &
                                            ",[Usuario]" &
                                            ",[Pc]" &
                                            ",[ArchivoCargado])" &
                                            " VALUES " &
                                            "(@Fecha_hora_carga" &
                                            ",@ID_bach_carga" &
                                            ",@Usuario" &
                                            ",@Pc" &
                                            ",@ArchivoCargado)"

                    Dim Sql2E As String = "Select @@Identity"

                    Dim cmdE As New SqlCommand(SqlE, Cnx)
                    Dim now As DateTime = DateTime.Now

                    With cmdE
                        .Parameters.Add(New SqlParameter("@Fecha_hora_carga", SqlDbType.DateTime)).Value = now.ToString()
                        .Parameters.Add(New SqlParameter("@ID_bach_carga", SqlDbType.VarChar)).Value = ""
                        .Parameters.Add(New SqlParameter("@Usuario", SqlDbType.VarChar)).Value = My.User.Name
                        .Parameters.Add(New SqlParameter("@PC", SqlDbType.VarChar)).Value = My.Computer.Name.ToUpper
                        .Parameters.Add(New SqlParameter("@ArchivoCargado", SqlDbType.VarChar)).Value = cRutaArchivoXML_Archivo.Trim
                        .ExecuteNonQuery()
                        .CommandText = Sql2E
                        UniqueID = .ExecuteScalar()
                        nTotalArchivosEncabezado = nTotalArchivosEncabezado + 1

                    End With
                    ' -----------------------------------------------------------------------------
                    ' Detalle
                    ' -----------------------------------------------------------------------------
                    xmlnode = xmldoc.GetElementsByTagName("operacion")
                    For i = 0 To xmlnode.Count - 1
                        xmlnode(i).ChildNodes.Item(0).InnerText.Trim()

                        Dim Sql As String = "INSERT INTO [Extrabursatil].[dbo].[SIVVectoresDetalle]" &
                                                      " ([ID_Operacion] " &
                                                      " ,[RncPuestoDeBolsa] " &
                                                      " ,[RncEmisor] " &
                                                      " ,[Emisor]" &
                                                      " ,[fechaEnvio]" &
                                                      " ,[fechaValor]" &
                                                      " ,[fechaVecMutuo]" &
                                                      " ,[codEmision]" &
                                                      " ,[codigoIsin]" &
                                                      " ,[Serie]" &
                                                      " ,[moneda]" &
                                                      " ,[numOperacion]" &
                                                      " ,[tipoTransaccion]" &
                                                      " ,[tipoContrato]" &
                                                      " ,[tipoMercado]" &
                                                      " ,[tipoNegociacion]" &
                                                      " ,[tasaIntFacial]" &
                                                      " ,[tasaRend]" &
                                                      " ,[unidadValorNominal]" &
                                                      " ,[ValorNominal]" &
                                                      " ,[cantValorNominal]" &
                                                      " ,[precioNegociado]" &
                                                      " ,[valorNegociado])" &
                                                      " VALUES(" &
                                                      " @ID_Operacion" &
                                                      ",@RncPuestoDeBolsa" &
                                                      ",@RncEmisor" &
                                                      ",@Emisor" &
                                                      ",@fechaEnvio" &
                                                      ",@fechaValor" &
                                                      ",@fechaVecMutuo" &
                                                      ",@codEmision" &
                                                      ",@codigoIsin" &
                                                      ",@Serie" &
                                                      ",@moneda" &
                                                      ",@numOperacion" &
                                                      ",@tipoTransaccion" &
                                                      ",@tipoContrato" &
                                                      ",@tipoMercado" &
                                                      ",@tipoNegociacion" &
                                                      ",@tasaIntFacial" &
                                                      ",@tasaRend" &
                                                      ",@unidadValorNominal" &
                                                      ",@ValorNominal" &
                                                      ",@cantValorNominal" &
                                                      ",@precioNegociado" &
                                                      ",@valorNegociado)"

                        Dim Sql2 As String = "Select numOperacion from [SIVVectoresDetalle] where numOperacion='" & xmlnode(i).ChildNodes.Item(9).InnerText.Trim() & "'"
                        Dim cmd As New SqlCommand(Sql, Cnx)
                        Dim cmd2 As New SqlCommand(Sql2, Cnx)
                        ID_RegistroDetalle = cmd2.ExecuteScalar()

                        If True Then
                            cmd.Parameters.Add(New SqlParameter("@ID_Operacion", SqlDbType.Int)).Value = UniqueID
                            cmd.Parameters.Add(New SqlParameter("@RncPuestoDeBolsa", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@RncEmisor", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@Emisor", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()
                            CadenaFecha = oper.ConvertirCadenaFechaEnISO(xmlnode(i).ChildNodes.Item(3).InnerText.Trim(), "Español")
                            cmd.Parameters.Add(New SqlParameter("@fechaEnvio", SqlDbType.DateTime)).Value = DateTime.Parse(CadenaFecha)

                            Try
                                CadenaFecha = oper.ConvertirCadenaFechaEnISO(xmlnode(i).ChildNodes.Item(4).InnerText.Trim(), "Español")
                                cmd.Parameters.Add(New SqlParameter("@fechaValor", SqlDbType.DateTime)).Value = Date.Parse(CadenaFecha)

                            Catch ex As Exception
                                cmd.Parameters.Add(New SqlParameter("@fechaValor", SqlDbType.DateTime)).Value = DBNull.Value

                            End Try

                            If xmlnode(i).ChildNodes.Item(4).InnerText.Trim() <> "ND" And xmlnode(i).ChildNodes.Item(5).InnerText.Trim() <> "null" Then
                                CadenaFecha = oper.ConvertirCadenaFechaEnISO(xmlnode(i).ChildNodes.Item(5).InnerText.Trim(), "Español")
                                cmd.Parameters.Add(New SqlParameter("@fechaVecMutuo", SqlDbType.DateTime)).Value = Date.Parse(CadenaFecha)

                            Else
                                cmd.Parameters.Add(New SqlParameter("@fechaVecMutuo", SqlDbType.DateTime)).Value = DBNull.Value

                            End If

                            cmd.Parameters.Add(New SqlParameter("@codEmision", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(6).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@codigoIsin", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(7).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@Serie", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(8).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@moneda", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(9).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@numOperacion", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(10).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@tipoTransaccion", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(11).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@tipoContrato", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(12).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@tipoMercado", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(13).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@tipoNegociacion", SqlDbType.VarChar)).Value = xmlnode(i).ChildNodes.Item(14).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@tasaIntFacial", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(15).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@tasaRend", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(16).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@unidadValorNominal", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(17).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@ValorNominal", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(18).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@cantValorNominal", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(19).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@precioNegociado", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(20).InnerText.Trim()
                            cmd.Parameters.Add(New SqlParameter("@valorNegociado", SqlDbType.Money)).Value = xmlnode(i).ChildNodes.Item(21).InnerText.Trim()
                            cmd.ExecuteNonQuery()
                            nTotalArchivosDetalle += 1

                        Else
                            nTotalArchivosDetalleRepetidos += 1

                        End If
                    Next

                    fs.Close()
                    IO.File.Copy(cRutaArchivoXML_Archivo, cRutaArchivoXML_Archivo_Destino, True)
                    My.Computer.FileSystem.DeleteFile(cRutaArchivoXML_Archivo)

                Catch ex As Exception
                    EnviameUnCorreo("Carga Archivo: SIV XML (ERROR) Registro :" + i.ToString(), ex.Message.Trim, "SIV")

                Finally
                    strBody = "Archivo " & cRutaArchivoXML_Archivo & vbCrLf
                    strBody += " Cargado Correctamente. "
                    strBody += " Encabezado : " & nTotalArchivosEncabezado.ToString.Trim & vbCrLf
                    strBody += " Detalle : " & nTotalArchivosDetalle.ToString.Trim
                    EnviameUnCorreo("Carga Archivo: SIV XML", strBody, "SIV")
                    Cnx.Close()

                End Try
            End If
        Next
    End Sub

    Private Sub EnviameUnCorreo(cAsunto As String, cMensaje As String, cArchivo As String)
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Configuracion]")
        Dim MyRow As DataRow
        Dim cEmail As String = ""
        Dim cUsuario As String = ""
        Dim cPass As String = ""
        Dim cServidor As String = ""
        Dim cPuerto As String = ""
        Dim cEmailDestino As String = ""

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Email")) Then cEmail = Trim(MyRow.Item("Email"))
            If Not IsDBNull(MyRow.Item("Usuario")) Then cUsuario = Trim(MyRow.Item("Usuario"))
            If Not IsDBNull(MyRow.Item("Pass")) Then cPass = Trim(MyRow.Item("Pass"))
            If Not IsDBNull(MyRow.Item("Servidor")) Then cServidor = Trim(MyRow.Item("Servidor"))
            If Not IsDBNull(MyRow.Item("Puerto")) Then cPuerto = Trim(MyRow.Item("Puerto"))
            If Not IsDBNull(MyRow.Item("EmailDestino")) Then cEmailDestino = Trim(MyRow.Item("EmailDestino"))

        Next
        Try
            mail.SendMail(cEmail,
                             cEmailDestino,
                             cAsunto.Trim,
                             cMensaje.Trim,
                             cServidor.Trim,
                             True,
                             Int(cPuerto.Trim),
                             Nothing,
                             cUsuario.Trim,
                             cPass.Trim)

        Catch ex As Exception
            mail.SendMail("Error en generación archivo SIV - CEVALDOM",
                           "Ha ocurrido una excepción en la generación del archivo",
                           True)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Button1_Click(sender, e)
        Application.Exit()

    End Sub

End Class
