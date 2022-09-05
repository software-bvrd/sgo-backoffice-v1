Imports System.IO
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Upload
Imports System.Globalization
Imports System.Drawing
' --------------------------------------------
' Biblioteca para Manipular Excel
' --------------------------------------------
'Imports ExpertXls.ExcelLib

Partial Class CargaOperaciones
    Inherits Page
    Private oper As New operation
    Private dtable As New DataTable()
    'Private ResultadoValidacion As New DataTable()
    'Private DictionaryRNT As New Dictionary(Of String, Decimal)
    Private row As DataRow

    Private Const FileType As String = "OO"

    ' ------------------------------------------------------------------------
    ' Inicio de la pagina
    ' ------------------------------------------------------------------------
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack = False Then
            RadToolBar1.Items(2).Enabled = False
            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount
            With rgListaArchivosCargados
                .Culture = New CultureInfo("es-DO")
            End With
            LimpiarCampos()

        End If
        SqlDataSource1.SelectCommand = STools.InfoFileSql(FileType)
    End Sub
    ' ------------------------------------------------------------------------
    ' Metodo de Actualizar Barra de Estado
    ' ------------------------------------------------------------------------
    Private Sub LooongMethodWhichUpdatesTheProgressContext(ByVal file As UploadedFile)
        Const total As Integer = 100
        Dim progress As RadProgressContext = RadProgressContext.Current
        Dim i As Integer = 0
        While i < total
            progress.PrimaryTotal = 1
            progress.PrimaryValue = 1
            progress.PrimaryPercent = 100
            progress.SecondaryTotal = total
            progress.SecondaryValue = i
            progress.SecondaryPercent = i
            progress.CurrentOperationText = file.GetName() + " se está procesando..."

            If Not Response.IsClientConnected Then
                Exit While
            End If
            Threading.Thread.Sleep(100)
            i = i + 1
        End While
    End Sub

    ' ------------------------------------------------------------------------
    ' Barra de Botonos superior
    ' ------------------------------------------------------------------------
    Private Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        Try
            If e.Item.Value = 0 Then 'Cargar
                LimpiarCampos()

                If SubidaArchivo() = True Then
                    ImportarArchivoASqlServer()
                    With lblError
                        .Text = ""
                        .Visible = False
                    End With
                End If
            ElseIf e.Item.Value = 1 Then ' Procesar
                LimpiarCampos()
                InsertarDatosATablaOperaciones()
                lblTextoArchivoProcesar.Text = ""
                Call CargarArchivosManualEstado(True)

                With lblTextoArchivoProcesar
                    .Text = ""
                    .Visible = False
                End With

                RadToolBar1.Items(0).Enabled = True
                RadToolBar1.Items(2).Enabled = False

            ElseIf e.Item.Value = 2 Then  ' Cancelar
                LimpiarCampos()
                RadUpload1.Visible = True
                dgVistaPrevia.DataSource = Nothing
                dgVistaPrevia.DataBind()
                dgVistaPrevia.Visible = False
                lblMensaje.Text = String.Empty
                lblResultadoValidacion.Text = String.Empty
                Mensaje.Text = String.Empty
                With lblTextoArchivoProcesar
                    .Text = ""
                    .Visible = False
                End With
                RadToolBar1.Items(0).Enabled = True
                RadToolBar1.Items(2).Enabled = False
                With lblError
                    .Visible = False
                    .Text = " "
                End With
                With lstErrores
                    .Visible = False
                    .Items.Clear()
                End With
                Call CargarArchivosManualEstado(True)
            End If
        Catch ex As Exception
            RadUpload1.Visible = True
            Mensaje.ForeColor = Color.Red
            Mensaje.Text = "Error. " & ex.Message

        End Try
    End Sub

    Private Sub ImportarArchivoASqlServer()
        Try
            ProcesarDTOperaciones(IIf(cboFormatoFecha.Text = "Español", True, False))
            With lblTextoArchivoProcesar
                .ForeColor = Color.Blue
                .Text = "Ya esta disponible para procesar el archivo : " & ViewState("FileName") & " Cantidad de Líneas  :  " & dtable.Rows.Count
                .Visible = True
            End With

            ''Validar información para insertar al BO
            With lblTextoArchivoProcesar
                .ForeColor = Color.Blue
                .Text = "Ya esta disponible para procesar el archivo : " & ViewState("FileName") & " Cantidad de Líneas  :  " & dtable.Rows.Count
                .Visible = True
            End With


            With dgVistaPrevia
                .DataSource = dtable
                .Rebind()
                .Visible = True
            End With
            RadToolBar1.Items(0).Enabled = False
            RadToolBar1.Items(2).Enabled = True
            Call CargarArchivosManualEstado(False)

        Catch ex As Exception
            RadUpload1.Visible = True
            Mensaje.ForeColor = Color.Red
            Mensaje.Text = "Error al leer el archivo. " & ex.Message

        End Try

    End Sub
#Region "Metodos personalizados"
    ' ------------------------------------------------------------------------
    ' Metodo de subir archivos y Actualizar Barra de Estado
    ' ------------------------------------------------------------------------
    Function SubidaArchivo() As Boolean
        If RadUpload1.UploadedFiles.Count > 0 Then
            Try
                For Each validFile As UploadedFile In RadUpload1.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)

                    Dim targetFolder As String = Server.MapPath("~/tmp/")
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    ViewState("FileExtension") = validFile.GetExtension()
                    RadUpload1.Visible = False
                    Return True
                Next

            Catch ex As Exception
                Mensaje.ForeColor = Color.Red
                Mensaje.Text = ex.Message
                Return False
            End Try
        Else
            Return False
        End If

        Return False

    End Function
    Sub LimpiarCampos()
        Mensaje.Text = String.Empty
        lblMensaje.Text = String.Empty
        lblTipoMoneda.Text = String.Empty
        lblError.Text = String.Empty

        lstErrores.Visible = False
        RadToolBar1.Items(2).Enabled = False

        txtLineaInicio.Text = CStr(1)
    End Sub
    Sub CargarArchivosManualEstado(ByRef Estado As Boolean)
        If Estado Then
            dgVistaPrevia.Enabled = False
            lblFormatofecha.Enabled = True
            cboFormatoFecha.Enabled = True
            lblLinea.Enabled = True
            txtLineaInicio.Enabled = True
            RadUpload1.Enabled = True
        Else
            dgVistaPrevia.Enabled = True
            lblFormatofecha.Enabled = False
            cboFormatoFecha.Enabled = False
            lblLinea.Enabled = False
            txtLineaInicio.Enabled = False
            RadUpload1.Enabled = False
        End If
    End Sub

#End Region

#Region "Operaciones"
    ' Operaciones
    Private Sub ProcesarDTOperaciones(lFormatoBritanico As Boolean)
        Try
            Dim targetFolder As String = Server.MapPath("~/tmp/")
            Dim line As String = Nothing
            Dim i As Integer = 0
            Dim j As Integer = 0
            Using sr As StreamReader = File.OpenText(targetFolder & ViewState("FileName"))

                Do While j < txtLineaInicio.Text
                    line = sr.ReadLine()
                    j += 1
                Loop
                ' ------------------------------------------------------------------------
                ' Buscar y Eliminar comas dentro de dobles comillas
                ' ------------------------------------------------------------------------
                line = line.Replace("""", "|")
                Do While line IsNot Nothing
                    line = oper.LimpiarComasdeCadena(line)
                    Dim data() As String = line.Split(","c)
                    If data.Length > 0 Then
                        If i = 0 Then
                            For Each item In data
                                dtable.Columns.Add(New DataColumn())
                            Next item
                            i += 1
                        End If
                        row = dtable.NewRow()
                        row.ItemArray = data
                        dtable.Rows.Add(row)
                    End If

                    line = sr.ReadLine()
                    line = line.Replace("""", "|")
                Loop
            End Using
        Catch ex As Exception
        End Try
    End Sub
    Private Sub InsertarDatosATablaOperaciones()
        Dim stringFechaHora As String = ""
        Dim strindatetime As String = ""
        ProcesarDTOperaciones(IIf(cboFormatoFecha.Text = "Español", True, False))


        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try

            Dim dRow As DataRow
            Dim cStringSQL As String = ""
            Dim LineasConError As Integer = 0
            Dim LineasSinError As Integer = 0
            Dim cSqlIndiceConversionLiquidacion As String = ""
            Dim vIndiceConversionLiquidacion As String = ""
            Dim vValorDividirVTTasa As Decimal = 0

            Dim Sql As String = "INSERT INTO [OperacionesCSV]" &
                                 "([fecha_oper]" &
                                 ",[num_oper]" &
                                 ",[hora_oper]" &
                                 ",[nemo_ins]" &
                                 ",[cod_isin]" &
                                 ",[usuario]" &
                                 ",[fecha_emi]" &
                                 ",[fecha_venc]" &
                                 ",[dias_acum]" &
                                 ",[dias_alvenci]" &
                                 ",[valor_nom_unit]" &
                                 ",[cant_tit]" &
                                 ",[valor_nom_tot]" &
                                 ",[interes_acum]" &
                                 ",[precio_limp]" &
                                 ",[valor_tran]" &
                                 ",[yield]" &
                                 ",[fecha_liquid]" &
                                 ",[mone_trans]" &
                                 ",[pues_comp]" &
                                 ",[pues_vend]" &
                                 ",[descrip_instru]" &
                                 ",[mercado]" &
                                 ",[tasa_interes]" &
                                 ",[tipo_interes]" &
                                 ",[periodicidad]" &
                                 ",[sector]" &
                                 ",[status_trans]" &
                                 ",[nemo_emisor]" &
                                 ",[descrip_emisor]" &
                                 ",[AplicaParaPrecio]" &
                                 ",[VTTasa])" &
                              "VALUES" &
                                 "(@fecha_oper" &
                                 ",@num_oper" &
                                 ",@hora_oper" &
                                 ",@nemo_ins" &
                                 ",@cod_isin" &
                                 ",@usuario" &
                                 ",@fecha_emi" &
                                 ",@fecha_venc" &
                                 ",@dias_acum" &
                                 ",@dias_alvenci" &
                                 ",@valor_nom_unit" &
                                 ",@cant_tit" &
                                 ",@valor_nom_tot" &
                                 ",@interes_acum" &
                                 ",@precio_limp" &
                                 ",@valor_tran" &
                                 ",@yield" &
                                 ",@fecha_liquid" &
                                 ",@mone_trans" &
                                 ",@pues_comp" &
                                 ",@pues_vend" &
                                 ",@descrip_instru" &
                                 ",@mercado" &
                                 ",@tasa_interes" &
                                 ",@tipo_interes" &
                                 ",@periodicidad" &
                                 ",@sector" &
                                 ",@status_trans" &
                                 ",@nemo_emisor" &
                                 ",@descrip_emisor" &
                                 ",@AplicaParaPrecio" &
                                 ",@VTTasa )"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            lstErrores.Items.Clear()


            For Each dRow In dtable.Rows


                Try


                    If cboFormatoFecha.Text = "Español" Then
                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(0), cboFormatoFecha.Text)
                    End If

                    ' -----------------------------------------------------------------------------------------
                    ' Verificar si la Emision tiene un Indice de conversion 
                    ' -----------------------------------------------------------------------------------------
                    cSqlIndiceConversionLiquidacion = String.Format("Select IndiceConversionLiquidacion from EmisionSerie where CodigoSerie = '{0}'", dRow.Item(3))
                    vIndiceConversionLiquidacion = oper.ExecuteScalar(cSqlIndiceConversionLiquidacion)

                    If vIndiceConversionLiquidacion <> "0" Then

                        Dim ds As DataSet = oper.ExDataSet(String.Format("Select * FROM  [MonedasHistoricoTasas]  where Fecha='{0}' and TipoMonedaID = 2", stringFechaHora))

                        Dim MyRow As DataRow
                        For Each MyRow In ds.Tables(0).Rows

                            Select Case vIndiceConversionLiquidacion
                                Case "1" ' TasaCompra
                                    vValorDividirVTTasa = Convert.ToDecimal(Trim(MyRow.Item("TasaCompra")))
                                Case "2" ' TasaVenta
                                    vValorDividirVTTasa = Convert.ToDecimal(Trim(MyRow.Item("TasaVenta")))
                                Case "3" ' TIPP
                                    vValorDividirVTTasa = Convert.ToDecimal(Trim(MyRow.Item("TIPP")))
                                Case "4" ' TPCV10
                                    vValorDividirVTTasa = Convert.ToDecimal(Trim(MyRow.Item("TPCV10")))
                                Case "5" ' TPCV01
                                    vValorDividirVTTasa = Convert.ToDecimal(Trim(MyRow.Item("TPCV01")))
                            End Select

                        Next


                        ds = Nothing
                        MyRow = Nothing

                    End If




                    cmd.Parameters.Clear()



                    cmd.Parameters.Add(New SqlParameter("@fecha_oper", SqlDbType.Date)).Value = stringFechaHora
                    cmd.Parameters.Add(New SqlParameter("@num_oper", SqlDbType.VarChar)).Value = dRow.Item(1)


                    strindatetime = UCase(dRow.Item(2))
                    strindatetime = strindatetime.Replace(".", "")
                    cmd.Parameters.Add(New SqlParameter("@hora_oper", SqlDbType.DateTime)).Value = strindatetime
                    If dRow.Item(3).ToString.Trim() = "" Then
                        Dim Ds As DataSet = oper.ExDataSet("SELECT dbo.GetNemotecnico('" + dRow.Item(4).ToString() + "') as Nemotecnico")
                        If Ds.Tables(0).Rows.Count > 0 Then
                            cmd.Parameters.Add(New SqlParameter("@nemo_ins", SqlDbType.VarChar)).Value = Ds.Tables(0).Rows(0)("Nemotecnico")
                        End If
                    Else
                        cmd.Parameters.Add(New SqlParameter("@nemo_ins", SqlDbType.VarChar)).Value = dRow.Item(3)
                    End If

                    If dRow.Item(4).ToString.Trim() = "" Then
                        Dim Ds As DataSet = oper.ExDataSet("SELECT dbo.GetCodigoISIN('" + dRow.Item(3).ToString() + "') as CodigoISIN")
                        If Ds.Tables(0).Rows.Count > 0 Then
                            cmd.Parameters.Add(New SqlParameter("@cod_isin", SqlDbType.VarChar)).Value = Ds.Tables(0).Rows(0)("CodigoISIN")
                        End If
                    Else
                        cmd.Parameters.Add(New SqlParameter("@cod_isin", SqlDbType.VarChar)).Value = dRow.Item(4)
                    End If

                    cmd.Parameters.Add(New SqlParameter("@usuario", SqlDbType.VarChar)).Value = dRow.Item(5)

                    If cboFormatoFecha.Text = "Español" Then
                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(6), cboFormatoFecha.Text)
                    End If

                    cmd.Parameters.Add(New SqlParameter("@fecha_emi", SqlDbType.Date)).Value = stringFechaHora

                    If cboFormatoFecha.Text = "Español" Then
                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(7), cboFormatoFecha.Text)
                    End If

                    cmd.Parameters.Add(New SqlParameter("@fecha_venc", SqlDbType.Date)).Value = stringFechaHora

                    cmd.Parameters.Add(New SqlParameter("@dias_acum", SqlDbType.Decimal)).Value = dRow.Item(8)

                    cmd.Parameters.Add(New SqlParameter("@dias_alvenci", SqlDbType.Decimal)).Value = dRow.Item(9)
                    cmd.Parameters.Add(New SqlParameter("@valor_nom_unit", SqlDbType.Decimal)).Value = dRow.Item(10)
                    cmd.Parameters.Add(New SqlParameter("@cant_tit", SqlDbType.Decimal)).Value = dRow.Item(11)
                    cmd.Parameters.Add(New SqlParameter("@valor_nom_tot", SqlDbType.Decimal)).Value = dRow.Item(12)
                    cmd.Parameters.Add(New SqlParameter("@interes_acum", SqlDbType.Decimal)).Value = dRow.Item(13)

                    cmd.Parameters.Add(New SqlParameter("@precio_limp", SqlDbType.Decimal)).Value = dRow.Item(14)
                    cmd.Parameters.Add(New SqlParameter("@valor_tran", SqlDbType.Decimal)).Value = dRow.Item(15)
                    cmd.Parameters.Add(New SqlParameter("@yield", SqlDbType.Decimal)).Value = dRow.Item(16)

                    If cboFormatoFecha.Text = "Español" Then
                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(17), cboFormatoFecha.Text)
                    End If
                    cmd.Parameters.Add(New SqlParameter("@fecha_liquid", SqlDbType.Date)).Value = stringFechaHora

                    cmd.Parameters.Add(New SqlParameter("@mone_trans", SqlDbType.VarChar)).Value = dRow.Item(18)
                    cmd.Parameters.Add(New SqlParameter("@pues_comp", SqlDbType.VarChar)).Value = dRow.Item(19)
                    If dRow.Item(19).ToString.Trim() = "" Then
                        LineasConError += 1
                        lstErrores.Visible = True
                        lstErrores.Items.Add("(" + LineasConError.ToString() + ") - " + "Error: Puesto Comprador Vacio")
                    End If
                    cmd.Parameters.Add(New SqlParameter("@pues_vend", SqlDbType.VarChar)).Value = dRow.Item(20)
                    If dRow.Item(20).ToString.Trim() = "" Then
                        LineasConError += 1
                        lstErrores.Visible = True
                        lstErrores.Items.Add("(" + LineasConError.ToString() + ") - " + "Error: Puesto Vendedor Vacio")
                    End If
                    cmd.Parameters.Add(New SqlParameter("@descrip_instru", SqlDbType.VarChar)).Value = dRow.Item(21)
                    cmd.Parameters.Add(New SqlParameter("@mercado", SqlDbType.VarChar)).Value = dRow.Item(22)

                    cmd.Parameters.Add(New SqlParameter("@tasa_interes", SqlDbType.Decimal)).Value = dRow.Item(23)
                    cmd.Parameters.Add(New SqlParameter("@tipo_interes", SqlDbType.VarChar)).Value = dRow.Item(24)

                    cmd.Parameters.Add(New SqlParameter("@periodicidad", SqlDbType.VarChar)).Value = dRow.Item(25)
                    cmd.Parameters.Add(New SqlParameter("@sector", SqlDbType.VarChar)).Value = dRow.Item(26)
                    cmd.Parameters.Add(New SqlParameter("@status_trans", SqlDbType.VarChar)).Value = dRow.Item(27)

                    cmd.Parameters.Add(New SqlParameter("@nemo_emisor", SqlDbType.VarChar)).Value = dRow.Item(28)
                    cmd.Parameters.Add(New SqlParameter("@descrip_emisor", SqlDbType.VarChar)).Value = dRow.Item(29)

                    cmd.Parameters.Add(New SqlParameter("@AplicaParaPrecio", SqlDbType.Bit)).Value = 1
                    If vValorDividirVTTasa > 0 Then
                        cmd.Parameters.Add(New SqlParameter("@VTTasa", SqlDbType.Decimal)).Value = Convert.ToDecimal(dRow.Item(15)) / vValorDividirVTTasa
                    Else
                        cmd.Parameters.Add(New SqlParameter("@VTTasa", SqlDbType.Decimal)).Value = 0

                    End If


                    cmd.ExecuteNonQuery()
                    If dRow.Item(19).ToString.Trim() <> "" Then
                        If dRow.Item(20).ToString.Trim() <> "" Then
                            LineasSinError += 1
                        End If
                    End If


                Catch sql_ex As SqlClient.SqlException
                    LineasConError += 1
                    lblMensaje.Text = sql_ex.ToString()
                    lblMensaje.ForeColor = Color.Red

                    'Dim ListItems As New RadListBoxItem(cStringSQL)
                    lstErrores.Visible = True
                    lstErrores.Items.Add("(" + LineasConError.ToString() + ") - " + lblMensaje.Text)
                Catch ex As Exception

                    'add code for debug upload operation daily
                    lblMensaje.Text = ex.ToString()
                    lblMensaje.ForeColor = Color.Red


                    Dim ListItems As New RadListBoxItem("(" + LineasConError.ToString() + ") - " + cStringSQL)
                    lstErrores.Visible = True
                    lstErrores.Items.Add(ListItems)
                    LineasConError += 1

                Finally
                End Try
            Next
            STools.InsertarInformacionArchivo(ViewState("FileName"), LineasSinError, LineasConError, FileType)
            rgListaArchivosCargados.Rebind()

        Catch ex As Exception
            lblMensaje.Text = ex.ToString()
            lblMensaje.ForeColor = Color.Red
        Finally
            Cnx.Close()
        End Try
    End Sub

#End Region
    'Ordenes en firme

    Function ProcesarDTOperacionesEnFirme(lFormatoBritanico As Boolean) As DataTable
        Dim dt As New DataTable()
        Try
            Dim targetFolder As String = Server.MapPath("~/tmp/")
            Dim line As String = Nothing
            Dim i As Integer = 0
            Dim j As Integer = 0

            Using sr As StreamReader = File.OpenText(targetFolder & ViewState("FileName"))
                Do While j < txtLineaInicio.Text
                    line = sr.ReadLine()
                    j += 1
                Loop
                ' ------------------------------------------------------------------------
                ' Buscar y Eliminar comas dentro de dobles comillas
                ' ------------------------------------------------------------------------
                line = line.Replace("""", "|")
                Do While line IsNot Nothing
                    line = oper.LimpiarComasdeCadena(line)
                    Dim data() As String = line.Split(","c)
                    If data.Length > 0 Then
                        If i = 0 Then
                            For Each item In data
                                dt.Columns.Add(New DataColumn())
                            Next item
                            i += 1
                        End If
                        row = dt.NewRow()
                        row.ItemArray = data
                        dt.Rows.Add(row)
                    End If

                    line = sr.ReadLine()
                    If line.Replace(",", "").Length < 1 Then
                        line = Nothing
                    End If
                    line = line.Replace("""", "|")
                Loop

            End Using

        Catch ex As Exception

        End Try
        Return dt
    End Function

    Private Sub OnSqlRowsCopied(ByVal sender As Object,
        ByVal args As SqlRowsCopiedEventArgs)
        Console.WriteLine("Copied {0} so far...", args.RowsCopied)
    End Sub
#Region "Eventos combobox"
    Protected Sub cboFormatoFecha_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cboFormatoFecha.SelectedIndexChanged
        lblMensaje.Text = ""
        Me.lblError.Text = ""
        lstErrores.Visible = False
    End Sub
#End Region

#Region "Subasta"
    'Private Sub InsertarDatosATablaLibrodeOrdenes()
    '    Dim stringFechaHora As String = ""
    '    'Dim Sql As String = "INSERT INTO [Subasta] ([PuestoBolsaCodigo] ,[Fecha] ,[Bono] ,[Monto] ,[CodigoISIN] ,[Cant_Tit] ,[Precio] ,[ValorTransado] ,[OrdenNo] ,[FechaLinea] ,[Hora] ,[RTN] ,[NoRegistroLibro],[Estado],[Condicion]) VALUES (@PuestoBolsaCodigo, @Fecha,@Bono,@Monto,@CodigoISIN,@Cant_Tit,@Precio,@ValorTransado,@OrdenNo,@FechaLinea,@Hora,@RTN,@NoRegistroLibro,@Estado,@Condicion)"


    '    Dim Sql As String = ""

    '    Sql = "INSERT INTO [Subasta] ([PuestoBolsaCodigo] ,[Fecha] ,[Bono] ,[Monto] ,[CodigoISIN] ,[Cant_Tit] ,[Precio] ,[ValorTransado] ,[OrdenNo] ,[FechaLinea] ,[Hora] ,[RTN] ,[NoRegistroLibro],[Estado],[Condicion],[TipoLibroOrdenes]) VALUES (@PuestoBolsaCodigo, @Fecha,@Bono,@Monto,@CodigoISIN,@Cant_Tit,@Precio,@ValorTransado,@OrdenNo,@FechaLinea,@Hora,@RTN,@NoRegistroLibro,@Estado,@Condicion,@TipoLibroOrdenes)"


    '    ProcesarDTOSubastas(IIf(cboFormatoFecha.Text = "Español", True, False))

    '    Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
    '    ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
    '    System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    '    Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

    '    Dim LineasSinError As Integer = 0
    '    Dim LineasConError As Integer = 0
    '    Dim Contador As Integer = 0
    '    Dim cEstado As String = "V"

    '    Dim EsError As Boolean = False

    '    Dim SqlExiste As String = ""

    '    Try

    '        Cnx.Open()
    '        Dim cmd As New SqlCommand(Sql, Cnx)
    '        Dim NumerosLineasError As New ArrayList

    '        For Each dRow In dtable.Rows

    '            Try

    '                EsError = False

    '                cmd.Parameters.Clear()

    '                cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCodigo", SqlDbType.Char)).Value = dRow(0)



    '                If Not IsDBNull(dRow.Item(1)) Then

    '                    stringFechaHora = dRow.Item(1) 'oper.ConvertirCadenaFechaEnISO(dRow.Item(1), cboFormatoFecha.Text)

    '                    Try
    '                        cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = stringFechaHora
    '                    Catch ex As Exception
    '                        cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DBNull.Value
    '                    End Try

    '                Else
    '                    cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DBNull.Value
    '                End If

    '                cmd.Parameters.Add(New SqlParameter("@Bono", SqlDbType.Char)).Value = dRow(2)

    '                cmd.Parameters.Add(New SqlParameter("@Monto", SqlDbType.Decimal)).Value = Val(dRow(3))
    '                cmd.Parameters.Add(New SqlParameter("@CodigoISIN", SqlDbType.Char)).Value = IIf(dRow.Item(4) = "Monto Validado", "", dRow.Item(4))


    '                cmd.Parameters.Add(New SqlParameter("@Cant_Tit", SqlDbType.Decimal)).Value = Val(dRow(5))
    '                cmd.Parameters.Add(New SqlParameter("@Precio", SqlDbType.Decimal)).Value = Val(dRow(6))
    '                cmd.Parameters.Add(New SqlParameter("@ValorTransado", SqlDbType.Decimal)).Value = Val(dRow(7))
    '                cmd.Parameters.Add(New SqlParameter("@OrdenNo", SqlDbType.Decimal)).Value = Val(dRow(8))



    '                If Not IsDBNull(dRow.Item(9)) Then

    '                    stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(9), cboFormatoFecha.Text)
    '                    'dRow.Item(9) 
    '                    Try
    '                        cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = stringFechaHora
    '                    Catch ex As Exception
    '                        cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = DBNull.Value
    '                    End Try

    '                Else
    '                    cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = DBNull.Value
    '                End If


    '                cmd.Parameters.Add(New SqlParameter("@Hora", SqlDbType.Char)).Value = Mid(dRow(10), 11, 14)
    '                cmd.Parameters.Add(New SqlParameter("@RTN", SqlDbType.Char)).Value = dRow(11)
    '                cmd.Parameters.Add(New SqlParameter("@NoRegistroLibro", SqlDbType.Char)).Value = dRow(12)




    '                Dim csql As String = oper.CovertirComandoATexto(cmd)

    '                If Val(dRow(3)) < 1000 Or Val(dRow(3)) > 500000 Then
    '                    cmd.Parameters.Add(New SqlParameter("@Estado", SqlDbType.Char)).Value = "X"
    '                    cmd.Parameters.Add(New SqlParameter("@Condicion", SqlDbType.Char)).Value = "Fuera de rango de demanda"

    '                    LineasSinError += 1
    '                    EsError = True

    '                End If


    '                If EsError = False Then
    '                    ' Verificar si existe
    '                    stringFechaHora = dRow.Item(1)

    '                    SqlExiste = "SELECT COUNT(*) FROM dbo.Subasta WHERE PuestoBolsaCodigo='" + dRow(0) + "' and RTN='" + dRow(11) + "' and  Fecha = '" + stringFechaHora.Trim + "'"


    '                    Dim Res As Integer = oper.ExecuteScalar(SqlExiste)
    '                    If Res > 0 Then

    '                        LineasConError += 1

    '                        cmd.Parameters.Add(New SqlParameter("@Estado", SqlDbType.Char)).Value = "X"
    '                        cmd.Parameters.Add(New SqlParameter("@Condicion", SqlDbType.Char)).Value = "Registro duplicado"

    '                        EsError = True

    '                        NumerosLineasError.Add("</br>Dato duplicado en la línea :" + Contador.ToString + " RNT :" + dRow(11))

    '                    End If
    '                End If

    '                If EsError = False Then
    '                    cmd.Parameters.Add(New SqlParameter("@Estado", SqlDbType.Char)).Value = "V"
    '                    cmd.Parameters.Add(New SqlParameter("@Condicion", SqlDbType.Char)).Value = "Válido"
    '                End If

    '                cmd.Parameters.Add(New SqlParameter("@TipoLibroOrdenes", SqlDbType.Char)).Value = cboTipoLibroOrdenes.SelectedValue



    '                Contador = Contador + 1

    '                cmd.ExecuteNonQuery()


    '            Catch sql_ex As SqlClient.SqlException

    '                LineasConError += 1

    '                If sql_ex.Number = 2601 Then
    '                    NumerosLineasError.Add("</br>Dato duplicado en la línea :" + Contador.ToString + " RNT :" + dRow(11))
    '                End If



    '            Catch ex As Exception

    '                lstErrores.Visible = True
    '                LineasConError += 1
    '                NumerosLineasError.Add(Contador.ToString)
    '                With lblError
    '                    .Visible = True
    '                    .ForeColor = Color.Red
    '                    .Text = "Error al Procesar el Archivo, lineas con error : " & LineasConError.ToString
    '                End With

    '            Finally

    '            End Try
    '        Next


    '        InsertarInformacionArchivo(ViewState("FileName"), LineasSinError, LineasConError)
    '        rgListaArchivosCargados.Rebind()

    '        If LineasConError = 0 Then
    '            With lblError
    '                .Visible = False
    '                .Text = ""
    '            End With
    '            lstErrores.Visible = False

    '            With lblError
    '                .ForeColor = Color.Blue
    '                .Text = "Cargado con exito archivo : " & ViewState("FileName") & "</br> Cantidad de Líneas  :  " & Contador & " de " & dtable.Rows.Count

    '                .Visible = True
    '            End With
    '        Else
    '            Dim num As String
    '            Dim cadena As String = ""
    '            For Each num In NumerosLineasError
    '                cadena = cadena + num & ", "
    '            Next
    '            With lblError
    '                .ForeColor = Color.Red
    '                .Text = " No fué posible cargar todas las líneas del archivo : " & ViewState("FileName") & "</br> Hay " & LineasConError.ToString & " Líneas con error. Error en los números de línea:" & cadena
    '                .Visible = True
    '            End With
    '        End If



    '    Catch ex As Exception

    '    End Try

    'End Sub
    'Function ProcesarDTOSubastas(lFormatoBritanico As Boolean) As DataTable
    '    Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
    '    ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
    '    System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    '    ' Crear una variable para manejar el formato de la hoja
    '    Dim workbookFormat As ExcelWorkbookFormat = ExcelWorkbookFormat.Xls_2003

    '    ' Buscar el Archivo en la ruta establecida
    '    Dim testDocFile As String = Nothing
    '    testDocFile = System.IO.Path.Combine(Server.MapPath("~/tmp/"), ViewState("FileName"))

    '    ' Abrir una hoja con el formato establecido
    '    Dim workbook As ExcelWorkbook = New ExcelWorkbook(testDocFile, "")

    '    ' Posicionarnos en la Hoja 1
    '    Dim Hoja As ExcelWorksheet = workbook.Worksheets.Item(0)

    '    dtable.Columns.Add("PuestoBolsaCodigo", GetType(String))
    '    dtable.Columns.Add("Fecha", GetType(String))
    '    dtable.Columns.Add("Bono", GetType(String))
    '    dtable.Columns.Add("Monto", GetType(String))
    '    dtable.Columns.Add("CodigoISIN", GetType(String))
    '    dtable.Columns.Add("Cant_Tit", GetType(String))
    '    dtable.Columns.Add("Precio", GetType(String))
    '    dtable.Columns.Add("ValorTransado", GetType(String))
    '    dtable.Columns.Add("OrdenNo", GetType(String))
    '    dtable.Columns.Add("FechaLinea", GetType(String))
    '    dtable.Columns.Add("Hora", GetType(String))
    '    dtable.Columns.Add("RTN", GetType(String))
    '    dtable.Columns.Add("NoRegistroLibro", GetType(String))

    '    Try
    '        For i As Integer = 9 To Hoja.UsedRangeRows.Count
    '            If Hoja.Item("A" & i.ToString()).FormulaResultText <> "" Then
    '                dtable.Rows.Add(Hoja.Item("H5").FormulaResultText,
    '                            Hoja.Item("E4").DateTimeValue,
    '                            Hoja.Item("A" & i.ToString()).FormulaResultText,
    '                            Hoja.Item("B" & i.ToString()).NumberValue,
    '                            Hoja.Item("C" & i.ToString()).FormulaResultText,
    '                            Hoja.Item("D" & i.ToString()).FormulaResultNumberValue,
    '                            Hoja.Item("E" & i.ToString()).FormulaResultNumberValue,
    '                            Hoja.Item("F" & i.ToString()).FormulaResultNumberValue,
    '                            Hoja.Item("G" & i.ToString()).FormulaResultNumberValue,
    '                            Hoja.Item("H" & i.ToString()).FormulaResultDateTimeValue,
    '                            Hoja.Item("I" & i.ToString()).Value,
    '                            Hoja.Item("J" & i.ToString()).Value,
    '                            Hoja.Item("K" & i.ToString()).Value)

    '                ' FormulaResultNumberValue ( D,E,F,G)


    '            End If
    '        Next

    '        ValidarSubasta()

    '    Catch ex As Exception

    '    End Try

    '    Return dtable

    'End Function
    'Private Sub ValidarSubasta()
    '    Dim LineasSinError As Integer = 0
    '    Dim LineasConError As Integer = 0
    '    Dim Contador As Integer = 1
    '    Dim NumerosLineasError As New ArrayList

    '    Dim stringFechaHora As String

    '    Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
    '    Cnx.Open()


    '    For Each dRow In dtable.Rows

    '        Try

    '            stringFechaHora = dRow.Item(1)

    '            'Dim Sql As String = "SELECT COUNT(*) FROM dbo.Subasta WHERE PuestoBolsaCodigo='" + dRow(0) + "' and RTN='" + dRow(11) + "' and  Fecha = '" + stringFechaHora.Trim + "'"


    '            'Dim Res As Integer = oper.ExecuteScalar(Sql)
    '            'If Res > 0 Then
    '            '    LineasConError += 1
    '            '    NumerosLineasError.Add("La línea No. " + Contador.ToString + " ya existe")
    '            'End If


    '            ' Determinar Moneda 
    '            Dim Sql As String = ""

    '            If cboTipoLibroOrdenes.SelectedValue = "Emision" Then
    '                Sql = "SELECT top 1 Moneda FROM dbo.vConsultaEmisiones WHERE CodEmisionBVRD ='" + dRow(2) + "'"

    '            ElseIf cboTipoLibroOrdenes.SelectedValue = "Nemotecnico" Then
    '                Sql = "SELECT top 1 Moneda FROM dbo.vConsultaEmisiones WHERE Nemotecnico ='" + dRow(2) + "'"

    '            End If


    '            Dim cMoneda As String = oper.ExecuteScalar(Sql)

    '            If cMoneda = "" Then
    '                cMoneda = "DOP"
    '            End If

    '            Dim a As String = dRow(3)

    '            If cMoneda = "DOP" Then
    '                If Val(dRow(3)) > CInt(txtLimiteMaximoDOP.Text) Then
    '                    LineasConError += 1
    '                    NumerosLineasError.Add("La línea No. " + Contador.ToString + " excede el monto permitido en DOP")
    '                End If
    '                If Val(dRow(3)) < CInt(txtLimiteMinimoDOP.Text) Then
    '                    LineasConError += 1
    '                    NumerosLineasError.Add("La línea No. " + Contador.ToString + " contiene un monto menor que el monto mínimo de inversión en DOP")
    '                End If

    '            ElseIf cMoneda = "USD" Then
    '                If Val(dRow(3)) > CInt(txtLimiteMaximoUSD.Text) Then
    '                    LineasConError += 1
    '                    NumerosLineasError.Add("La línea No. " + Contador.ToString + " excede el monto permitido en USD")
    '                End If

    '                If Val(dRow(3)) < CInt(txtLimiteMinimoUSD.Text) Then
    '                    LineasConError += 1
    '                    NumerosLineasError.Add("La línea No. " + Contador.ToString + " contiene un monto menor que el monto mínimo de inversión en USD")
    '                End If

    '            End If

    '        Catch sql_ex As SqlClient.SqlException

    '        Catch ex As Exception
    '            Throw ex

    '        Finally

    '        End Try

    '        Contador = Contador + 1

    '    Next

    '    Dim num As String
    '    Dim cadena As String = ""
    '    For Each num In NumerosLineasError
    '        cadena = cadena + num & ", "
    '    Next
    '    lblMensaje.Text = ""
    '    lblMensaje.ForeColor = Color.Red
    '    lblMensaje.Text = cadena

    'End Sub
#End Region

End Class
