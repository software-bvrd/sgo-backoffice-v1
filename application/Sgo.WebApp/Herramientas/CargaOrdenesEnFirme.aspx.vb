Imports OfficeOpenXml
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Upload

' --------------------------------------------
' Biblioteca para Manipular Excel
' --------------------------------------------
'Imports ExpertXls.ExcelLib

Partial Class CargaOrdenesEnFirme
    Inherits System.Web.UI.Page
    Private oper As New operation
    Private dtable As New DataTable()
    Private row As DataRow
    Private LineasConErrorSB As Integer

    Private Const FileType As String = "OF"
    Private lExisteArchivoDelDia As Boolean = False



    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

    End Sub

    ' ------------------------------------------------------------------------
    ' Inicio de la pagina
    ' ------------------------------------------------------------------------
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            RadToolBar1.Items(2).Enabled = False
            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount
            With rgListaArchivosCargados
                .Culture = New CultureInfo("es-DO")
            End With

            LimpiarCampos()
        End If
        Me.SqlDataSource1.SelectCommand = STools.InfoFileSql(FileType)
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
            System.Threading.Thread.Sleep(100)
            i = i + 1
        End While
    End Sub

    ' ------------------------------------------------------------------------
    ' Barra de Botonos superior
    ' ------------------------------------------------------------------------
    Private Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
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

                ' inhabilitar Botón Procesar 
                RadToolBar1.Items(2).Enabled = False



                Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                Dim csql As String = "Select count(*) from OrdenesEnFirmeTemporal where CodRueda= 'BL' and cast(Createdate as date) = '" & DateTime.Now.ToString("yyyy-MM-dd") & "'"

                If oper.ExecuteScalar(csql) = "0" Then

                    LimpiarCampos()
                    InsertarDatosATablaOrdenesEnFirme()

                    lblTextoArchivoProcesar.Text = ""
                    Call CargarArchivosManualEstado(True)

                    With lblTextoArchivoProcesar
                        .Text = ""
                        .Visible = False
                    End With

                    RadToolBar1.Items(0).Enabled = True
                    RadToolBar1.Items(2).Enabled = False

                Else


                    Mensaje.ForeColor = Color.Red
                    Mensaje.Text = "Ya existe un archivo cargado para ese día, Verifique."

                End If

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

            LineasConErrorSB = 0

            ProcesarDTOperaciones(IIf(cboFormatoFecha.Text = "Español", True, False))

            ' Ordenar la tabla
            dtable.DefaultView.Sort = "Error DESC"

            Dim grdexp As New GridSortExpression()
            grdexp.FieldName = "Error"
            grdexp.SetSortOrder(GridSortOrder.Descending)



            With dgVistaPrevia
                .DataSource = dtable
                .Rebind()
                .MasterTableView.SortExpressions.Add(grdexp)
                .MasterTableView.Rebind()
                .Visible = True
            End With


            With lblTextoArchivoProcesar
                .ForeColor = Color.Blue
                .Text = "Ya esta disponible para procesar el archivo : " & ViewState("FileName") & " Cantidad de Líneas  :  " & dtable.Rows.Count & " Líneas con Error : " & (LineasConErrorSB / 2).ToString()
                .Visible = True
            End With



            If LineasConErrorSB = 0 Then
                RadToolBar1.Items(0).Enabled = False
                RadToolBar1.Items(2).Enabled = True
                Call CargarArchivosManualEstado(False)
            End If



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

        txtLineaInicio.Text = CStr(2)

        lExisteArchivoDelDia = False

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
                'If txtLineaInicio.Text = j Then
                '    line = sr.ReadLine()
                'Else
                Do While j < txtLineaInicio.Text
                    line = sr.ReadLine()
                    j += 1
                Loop
                'End If
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

                            dtable.Columns.Add(New DataColumn("Error"))

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
    Private Sub InsertarDatosATablaOrdenesEnFirme()
        Dim stringFechaHora As String = ""
        Dim stringDecimal As String = ""
        Dim dtof As DataTable = ProcesarDTOperacionesEnFirme(IIf(cboFormatoFecha.Text = "Español", True, False))
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""
        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Try
            Dim dRow As DataRow
            Dim cStringSQL As String = ""
            Dim LineasConError As Integer = 0
            Dim LineasSinError As Integer = 0
            Dim NumerosLineasError As New ArrayList
            Dim NumeroLinea As Integer = CInt(txtLineaInicio.Text)

            ' Para evaluar los códigos de participante que no existen
            Dim cEBNDSeller As String = ""
            Dim cEBNDBuyer As String = ""

            ' Para evalar Código Local e ISIN
            Dim cNemotecnico As String = ""
            Dim cIsin As String = ""



            Dim Sql As String = "INSERT INTO [OrdenesEnFirmeTemporal]" &
                            "([Type]" &
                            ",[OrderState]" &
                            ",[BlockStatus]" &
                            ",[Side]" &
                            ",[Local]" &
                            ",[ISIN]" &
                            ",[Curency]" &
                            ",[IssueDt]" &
                            ",[MatDt]" &
                            ",[MinInc]" &
                            ",[CouponDec]" &
                            ",[TradeDt]" &
                            ",[Time]" &
                            ",[Quiantity]" &
                            ",[Price]" &
                            ",[Yield]" &
                            ",[SetDt]" &
                            ",[Updated]" &
                            ",[LastupdTime]" &
                            ",[AccInt]" &
                            ",[Net]" &
                            ",[Brkr#]" &
                            ",[UserName]" &
                            ",[EBNDSeller]" &
                            ",[EBNDBuyer]" &
                            ",[AccDays]" &
                            ",[Seq#]" &
                            ",[EBONDmarket]" &
                            ",[OrdDur]" &
                            ",[CodRueda])" &
                        "VALUES" &
                            "(@Type" &
                            ",@OrderState" &
                            ",@BlockStatus" &
                            ",@Side" &
                            ",@Local" &
                            ",@ISIN" &
                            ",@Curency" &
                            ",@IssueDt" &
                            ",@MatDt" &
                            ",@MinInc" &
                            ",@CouponDec" &
                            ",@TradeDt" &
                            ",@Time" &
                            ",@Quiantity" &
                            ",@Price" &
                            ",@Yield" &
                            ",@SetDt" &
                            ",@Updated" &
                            ",@LastupdTime" &
                            ",@AccInt" &
                            ",@Net" &
                            ",@Brkr#" &
                            ",@UserName" &
                            ",@EBNDSeller" &
                            ",@EBNDBuyer" &
                            ",@AccDays" &
                            ",@Seq#" &
                            ",@EBONDmarket" &
                            ",@OrdDur" &
                            ",@CodRueda)"


            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)
            lstErrores.Items.Clear()

            For Each dRow In dtof.Rows
                Try
                    cmd.Parameters.Clear()

                    '--------------------------------------------------------------------------------------------------------
                    ' Evaluar Posibles Errores en el Archivo...
                    '--------------------------------------------------------------------------------------------------------

                    ' Evaluar Código Local e ISIN
                    '________________________________________________________________________________________________________



                    If RTrim(dRow.Item(3)) = "" Then
                        LineasConError += 1
                        NumerosLineasError.Add(NumeroLinea)
                        Continue For
                    Else

                        cNemotecnico = oper.ExecuteScalar("Select CodigoSerie from EmisionSerie where CodigoSerie ='" + RTrim(dRow.Item(3)) + "'")
                        If (cNemotecnico.TrimEnd() = "") Then
                            LineasConError += 1
                            NumerosLineasError.Add(NumeroLinea)
                            Continue For
                        End If
                    End If


                    If RTrim(dRow.Item(4)) = "" Then
                        LineasConError += 1
                        NumerosLineasError.Add(NumeroLinea)
                        Continue For
                    Else
                        cIsin = oper.ExecuteScalar("Select CodigoISIN from EmisionSerie where CodigoISIN ='" + RTrim(dRow.Item(4)) + "'")
                        If (cIsin.TrimEnd() = "") Then
                            LineasConError += 1
                            NumerosLineasError.Add(NumeroLinea)
                            Continue For
                        End If

                    End If


                    ' Evaluar Código de Participantes
                    '________________________________________________________________________________________________________
                    If RTrim(dRow.Item(22)) <> "" And RTrim(dRow.Item(22)) <> "&nbsp;" Then
                        cEBNDSeller = oper.ExecuteScalar("Select descripcion from codigosparticipante where descripcion ='" + RTrim(dRow.Item(22)) + "'")
                        If (cEBNDSeller.TrimEnd() = "") Then
                            LineasConError += 1
                            NumerosLineasError.Add(NumeroLinea)
                            Continue For
                        End If
                    End If

                    If RTrim(dRow.Item(23)) <> "" And RTrim(dRow.Item(23)) <> "&nbsp;" Then
                        cEBNDBuyer = oper.ExecuteScalar("Select descripcion from codigosparticipante where descripcion ='" + RTrim(dRow.Item(23)) + "'")

                        If (cEBNDBuyer.TrimEnd() = "") Then
                            LineasConError += 1
                            NumerosLineasError.Add(NumeroLinea)
                            Continue For
                        End If

                    End If

                    '--------------------------------------------------------------------------------------------------------


                    cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.VarChar)).Value = DBNull.Value 'dRow.Item(0)
                    cmd.Parameters.Add(New SqlParameter("@OrderState", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(dRow.Item(0)), dRow.Item(0), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@BlockStatus", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(dRow.Item(1)), dRow.Item(1), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@Side", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(dRow.Item(2)), dRow.Item(2), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@Local", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(dRow.Item(3)), dRow.Item(3), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@ISIN", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(dRow.Item(4)), dRow.Item(4), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@Curency", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(dRow.Item(5)), dRow.Item(5), DBNull.Value)

                    'IssueDT
                    If dRow.Item(6) <> "" Then

                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(6), cboFormatoFecha.Text)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@IssueDt", SqlDbType.Date)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@IssueDt", SqlDbType.Date)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@IssueDt", SqlDbType.Date)).Value = DBNull.Value
                    End If

                    'MatDt
                    If dRow.Item(7) <> "" Then

                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(7), cboFormatoFecha.Text)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@MatDt", SqlDbType.Date)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@MatDt", SqlDbType.Date)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@MatDt", SqlDbType.Date)).Value = DBNull.Value
                    End If

                    'MinInc
                    If dRow.Item(8) <> "" Then
                        stringDecimal = dRow.Item(8)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@MinInc", SqlDbType.Decimal)).Value = stringDecimal
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@MinInc", SqlDbType.Decimal)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@MinInc", SqlDbType.Decimal)).Value = DBNull.Value
                    End If

                    'CouponDec
                    If dRow.Item(9) <> "" Then
                        stringDecimal = dRow.Item(9)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@CouponDec", SqlDbType.Decimal)).Value = stringDecimal
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@CouponDec", SqlDbType.Decimal)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@CouponDec", SqlDbType.Decimal)).Value = DBNull.Value
                    End If


                    'Trade - Date
                    If dRow.Item(10) <> "" Then

                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(10), cboFormatoFecha.Text)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@TradeDt", SqlDbType.Date)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@TradeDt", SqlDbType.Date)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@TradeDt", SqlDbType.Date)).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add(New SqlParameter("@Time", SqlDbType.Time)).Value = IIf(Not IsDBNull(dRow.Item(11)), dRow.Item(11), DBNull.Value)


                    cmd.Parameters.Add(New SqlParameter("@Quiantity", SqlDbType.Decimal)).Value = IIf(Not IsDBNull(dRow.Item(12)), dRow.Item(12), DBNull.Value)

                    cmd.Parameters.Add(New SqlParameter("@Price", SqlDbType.Decimal)).Value = IIf(Not IsDBNull(dRow.Item(13)), dRow.Item(13), DBNull.Value)

                    cmd.Parameters.Add(New SqlParameter("@Yield", SqlDbType.Decimal)).Value = IIf(Not IsDBNull(dRow.Item(14)), dRow.Item(14), DBNull.Value)

                    If Not IsDBNull(dRow.Item(15)) Then
                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(15), cboFormatoFecha.Text)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@SetDt", SqlDbType.Date)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@SetDt", SqlDbType.Date)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@SetDt", SqlDbType.Date)).Value = DBNull.Value
                    End If

                    If Not IsDBNull(dRow.Item(16)) Then

                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(16), cboFormatoFecha.Text)

                        Try
                            cmd.Parameters.Add(New SqlParameter("@Updated", SqlDbType.DateTime)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@Updated", SqlDbType.DateTime)).Value = DBNull.Value
                        End Try

                    Else
                        cmd.Parameters.Add(New SqlParameter("@Updated", SqlDbType.DateTime)).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add(New SqlParameter("@LastupdTime", SqlDbType.Time)).Value = IIf(Not IsDBNull(dRow.Item(17)), dRow.Item(17), DBNull.Value)

                    cmd.Parameters.Add(New SqlParameter("@AccInt", SqlDbType.Decimal)).Value = IIf(Not IsDBNull(dRow.Item(18)), dRow.Item(18), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@Net", SqlDbType.Decimal)).Value = IIf(Not IsDBNull(dRow.Item(19)), dRow.Item(19), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@Brkr#", SqlDbType.Decimal)).Value = IIf(Not IsDBNull(dRow.Item(20)), dRow.Item(20), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(dRow.Item(21)), dRow.Item(21), DBNull.Value)


                    cmd.Parameters.Add(New SqlParameter("@EBNDSeller", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(RTrim(dRow.Item(22))), dRow.Item(22), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@EBNDBuyer", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(RTrim(dRow.Item(23))), dRow.Item(23), DBNull.Value)

                    cmd.Parameters.Add(New SqlParameter("@AccDays", SqlDbType.VarChar)).Value = IIf(Not IsDBNull(RTrim(dRow.Item(24))), dRow.Item(24), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@Seq#", SqlDbType.Int)).Value = IIf(Not IsDBNull(dRow.Item(25)), dRow.Item(25), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@EBONDmarket", SqlDbType.Int)).Value = IIf(Not IsDBNull(dRow.Item(26)), dRow.Item(26), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@OrdDur", SqlDbType.Time)).Value = IIf(Not IsDBNull(dRow.Item(27)), dRow.Item(27), DBNull.Value)
                    cmd.Parameters.Add(New SqlParameter("@CodRueda", SqlDbType.VarChar)).Value = "BL"


                    csql = oper.CovertirComandoATexto(cmd)

                    cmd.ExecuteNonQuery()
                    LineasSinError += 1
                    NumeroLinea = NumeroLinea + 1

                Catch sql_ex As SqlClient.SqlException

                    LineasConError += 1
                    NumerosLineasError.Add(NumeroLinea)

                Catch ex As Exception

                    NumerosLineasError.Add(NumeroLinea)
                    Dim ListItems As New RadListBoxItem(cStringSQL)
                    lstErrores.Visible = True
                    lstErrores.Items.Add(ListItems)
                    LineasConError += 1

                    Dim num As Integer
                    Dim cadena As String = ""
                    For Each num In NumerosLineasError
                        cadena = cadena + num & ", "
                    Next


                    With lblError
                        .Visible = True
                        .ForeColor = Color.Red
                        .Text = "Error al Procesar el Archivo, lineas con error : " & LineasConError.ToString & ". Líneas con error. Error en los números de línea:" & cadena
                    End With

                Finally
                End Try

            Next

            STools.InsertarInformacionArchivo(ViewState("FileName"), LineasSinError, LineasConError, FileType)

            rgListaArchivosCargados.Rebind()

            If LineasConError = 0 Then
                With lblError
                    .Visible = False
                    .Text = ""
                End With
                lstErrores.Visible = False
                With lblError
                    .ForeColor = Color.Blue
                    .Text = "Cargado con exito archivo : " & ViewState("FileName") & " Cantidad de Líneas  :  " & dtof.Rows.Count
                    .Visible = True
                End With
            Else
                Dim num As Integer
                Dim cadena As String = ""
                For Each num In NumerosLineasError
                    cadena = cadena + num & ", "
                Next
                With lblError
                    .ForeColor = Color.Red
                    .Text = " No fué posible cargar todas las líneas del archivo : " & ViewState("FileName") & " Hay " & LineasConError.ToString & " Líneas con error. Error en los números de línea:" & cadena
                    .Visible = True
                End With
            End If

        Catch ex As Exception
            With lblError
                .ForeColor = Color.Red
                .Text = " No fué posible cargar todas las líneas del archivo : " & ViewState("FileName")
                .Visible = True
            End With
        Finally
            Cnx.Close()
        End Try


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


    Function GetLastUsedRow(sheet As ExcelWorksheet, pInicioLinea As Integer) As Integer
        Dim row = sheet.Dimension.[End].Row

        While row >= 1
            Dim range = sheet.Cells(row, 1, row, sheet.Dimension.[End].Column)
            If range.Any(Function(c) Not String.IsNullOrEmpty(c.Text)) Then
                Exit While
            End If
            row -= 1
        End While
        'Lineas validas desde la columna A1 del excell
        Return (row - pInicioLinea)
    End Function

    ''' <summary>
    ''' Marcar y Poner de color Rojo las lineas con Error
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub dgVistaPrevia_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles dgVistaPrevia.ItemDataBound

        ' Column23 y Column24 son los campos de comprador y vendedor
        Dim cEBNDSeller As String = ""
        Dim cEBNDBuyer As String = ""

        Dim cNemotecnico As String = ""
        Dim cIsin As String = ""


        If TypeOf e.Item Is GridDataItem Then

            Dim dataItem As GridDataItem = e.Item

            If dataItem("Column23").Text.TrimEnd() <> "" And dataItem("Column23").Text.TrimEnd() <> "&nbsp;" Then
                cEBNDSeller = oper.ExecuteScalar("Select descripcion from codigosparticipante where descripcion ='" + dataItem("Column23").Text.TrimEnd() + "'")
                If (cEBNDSeller.TrimEnd() = "") Then
                    dataItem.ForeColor = Color.Red
                    LineasConErrorSB = LineasConErrorSB + 1
                    dataItem("Error").Text = "X"
                End If
            End If

            If dataItem("Column24").Text.TrimEnd() <> "" And dataItem("Column24").Text.TrimEnd() <> "&nbsp;" Then
                cEBNDBuyer = oper.ExecuteScalar("Select descripcion from codigosparticipante where descripcion ='" + dataItem("Column24").Text.TrimEnd() + "'")

                If (cEBNDBuyer.TrimEnd() = "") Then
                    dataItem.ForeColor = Color.Red
                    LineasConErrorSB = LineasConErrorSB + 1
                    dataItem("Error").Text = "X"
                End If

            End If

            If dataItem("Column4").Text.TrimEnd() = "" Then
                dataItem.ForeColor = Color.Red
                LineasConErrorSB = LineasConErrorSB + 1
                dataItem("Error").Text = "X"
            Else

                cNemotecnico = oper.ExecuteScalar("Select CodigoSerie from EmisionSerie where CodigoSerie ='" + dataItem("Column4").Text.TrimEnd() + "'")
                If (cNemotecnico.TrimEnd() = "") Then
                    dataItem.ForeColor = Color.Red
                    LineasConErrorSB = LineasConErrorSB + 1
                    dataItem("Error").Text = "X"
                End If
            End If


            If dataItem("Column5").Text.TrimEnd() = "" Then
                dataItem.ForeColor = Color.Red
                LineasConErrorSB = LineasConErrorSB + 1
                dataItem("Error").Text = "X"
            Else
                cIsin = oper.ExecuteScalar("Select CodigoISIN from EmisionSerie where CodigoISIN ='" + dataItem("Column5").Text.TrimEnd() + "'")
                If (cIsin.TrimEnd() = "") Then
                    dataItem.ForeColor = Color.Red
                    LineasConErrorSB = LineasConErrorSB + 1
                    dataItem("Error").Text = "X"
                End If

            End If







        End If



    End Sub
End Class
