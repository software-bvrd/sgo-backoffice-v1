Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Upload
Imports System.Globalization
Imports System.Drawing
Imports OfficeOpenXml

' --------------------------------------------
' Biblioteca para Manipular Excel
' --------------------------------------------
'Imports ExpertXls.ExcelLib

Partial Class CargaLibroDeOrdenes
Inherits System.Web.UI.Page
    Private oper As New operation
    Private dtable As New DataTable()
    Private ResultadoValidacion As New DataTable()
    Private DictionaryRNT As New Dictionary(Of String, Decimal)
    Private row As DataRow

    Private Const FileType As String = "LO"

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
            lstErrores.Visible = False
            cboTipoLibroOrdenes.Enabled = False
            RadToolBar1.Items(2).Enabled = False

            cboTipoLibroOrdenes.Enabled = True
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
                LimpiarCampos()

                If (cboTipoLibroOrdenes.SelectedValue = "LOPI") Then
                    'El ultimo parametro true para validar y false para procesar
                    If Convert.ToString(ViewState("FileExtension")).ToUpper = ".XLSX" Then
                        ProcesarLibroOrdenesLOPI_More2007(IIf(cboFormatoFecha.Text = "Español", True, False), False)
                    Else
                        'Mensaje office 2003
                        ProcesarLibroOrdenesLOPI_More2003(IIf(cboFormatoFecha.Text = "Español", True, False), False)
                    End If
                ElseIf (cboTipoLibroOrdenes.SelectedValue = "LOIG") Then
                    'El ultimo parametro true para validar y false para procesar
                    If Convert.ToString(ViewState("FileExtension")).ToUpper = ".XLSX" Then
                        ProcesarLibroOrdenesLOIG_More2007(IIf(cboFormatoFecha.Text = "Español", True, False), False)
                    Else
                        'Mensaje office 2003
                        ProcesarLibroOrdenesLOIG_More2003(IIf(cboFormatoFecha.Text = "Español", True, False), False)
                    End If
                End If

                chkSobrescribirArchivo.Checked = False
                chkSobrescribirArchivo.Enabled = False

                RadUpload1.Visible = True
                dgVistaPrevia.DataSource = Nothing
                dgVistaPrevia.DataBind()
                dgVistaPrevia.Visible = False
                Call CargarArchivosManualEstado(True)


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

            If (cboTipoLibroOrdenes.SelectedValue = "LOPI") Then
                'El ultimo parametro true para validar y false para procesar
                If Convert.ToString(ViewState("FileExtension")).ToUpper = ".XLSX" Then
                    ProcesarLibroOrdenesLOPI_More2007(IIf(cboFormatoFecha.Text = "Español", True, False), True)
                Else
                    'Mensaje office 2003
                    ProcesarLibroOrdenesLOPI_More2003(IIf(cboFormatoFecha.Text = "Español", True, False), True)
                End If

            ElseIf (cboTipoLibroOrdenes.SelectedValue = "LOIG") Then
                'El ultimo parametro true para validar y false para procesar
                If Convert.ToString(ViewState("FileExtension")).ToUpper = ".XLSX" Then
                    ProcesarLibroOrdenesLOIG_More2007(IIf(cboFormatoFecha.Text = "Español", True, False), True)
                Else
                    'Mensaje office 2003
                    ProcesarLibroOrdenesLOIG_More2003(IIf(cboFormatoFecha.Text = "Español", True, False), True)
                End If
            End If

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
    End Sub

    Sub CargarArchivosManualEstado(ByRef Estado As Boolean)
        If Estado Then
            dgVistaPrevia.Enabled = False
            cboTipoLibroOrdenes.Enabled = True
            lblFormatofecha.Enabled = True
            cboFormatoFecha.Enabled = True
            RadUpload1.Enabled = True
        Else
            dgVistaPrevia.Enabled = True
            cboTipoLibroOrdenes.Enabled = False
            lblFormatofecha.Enabled = False
            cboFormatoFecha.Enabled = False
            RadUpload1.Enabled = False
        End If
    End Sub

    'Sub InsertarInformacionArchivo(pDocumento As String, pLineasValidas As Integer, pLineasNoValidas As Integer)
    '    Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

    '    Try
    '        Dim Sql As String = "INSERT INTO  [ListaArchivosOperaciones] ([Nombre],[Fecha],[LineasValidas],[LineasNoValidas], [FileType]) VALUES (@Nombre,@Fecha,@LineasValidas,@LineasNoValidas,@FileType)"

    '        Cnx.Open()

    '        Dim cmd As New SqlCommand(Sql, Cnx)

    '        cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = pDocumento
    '        cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = Now.ToString()
    '        cmd.Parameters.Add(New SqlParameter("@LineasValidas", SqlDbType.Int)).Value = pLineasValidas
    '        cmd.Parameters.Add(New SqlParameter("@LineasNoValidas", SqlDbType.Int)).Value = pLineasNoValidas
    '        cmd.Parameters.Add(New SqlParameter("@FileType", SqlDbType.NChar)).Value = FileType


    '        cmd.ExecuteNonQuery()

    '    Catch sql_ex As SqlClient.SqlException

    '        If sql_ex.ErrorCode = -2146232060 Then
    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '    Finally
    '        Cnx.Close()

    '    End Try
    'End Sub

    #End Region

    Private Sub OnSqlRowsCopied(ByVal sender As Object, _
    ByVal args As SqlRowsCopiedEventArgs)
        Console.WriteLine("Copied {0} so far...", args.RowsCopied)
    End Sub

    #Region "Eventos combobox"

    Protected Sub cboTipoLibroOrdenes_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cboTipoLibroOrdenes.SelectedIndexChanged
        LimpiarCampos()
    End Sub

    Protected Sub cboFormatoFecha_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles cboFormatoFecha.SelectedIndexChanged
        lblMensaje.Text = ""
        Me.lblError.Text = ""
        lstErrores.Visible = False
    End Sub

    #End Region

    #Region "Libro de ordenes LOPI y LOIG"
    Private Sub ProcesarLibroOrdenesLOPI_More2003(lFormatoBritanico As Boolean, ByVal pValidarLOPI As Boolean)
        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        'Para almacenar todas laas lineas de los libros
        dtable.Columns.Add("PuestoBolsaCodigo", GetType(String))
        dtable.Columns.Add("Fecha", GetType(String))
        dtable.Columns.Add("Bono", GetType(String))
        dtable.Columns.Add("Monto", GetType(String))
        dtable.Columns.Add("CodigoISIN", GetType(String))
        dtable.Columns.Add("Cant_Tit", GetType(String))
        dtable.Columns.Add("Precio", GetType(String))
        dtable.Columns.Add("ValorTransado", GetType(String))
        dtable.Columns.Add("OrdenNo", GetType(String))
        dtable.Columns.Add("FechaLinea", GetType(String))
        dtable.Columns.Add("Hora", GetType(String))
        dtable.Columns.Add("RNT", GetType(String))
        dtable.Columns.Add("NoRegistroLibro", GetType(String))
        dtable.Columns.Add("TipoLibroOrdenes", GetType(String))
        dtable.Columns.Add("TipoBono", GetType(String))
        dtable.Columns.Add("ParcialTotal", GetType(String))
        ' Crear una variable para manejar el formato de la hoja
        Dim workbookFormat As ExpertXls.ExcelLib.ExcelWorkbookFormat = ExpertXls.ExcelLib.ExcelWorkbookFormat.Xls_2003

        ' Buscar el Archivo en la ruta establecida
        Dim testDocFile As String = Nothing
        testDocFile = System.IO.Path.Combine(Server.MapPath("~/tmp/"), ViewState("FileName"))

        ' Abrir una hoja con el formato establecido
        Dim workbook As ExpertXls.ExcelLib.ExcelWorkbook = New ExpertXls.ExcelLib.ExcelWorkbook(testDocFile, "")

        ' Posicionarnos en la Hoja 1
        Dim Hoja As ExpertXls.ExcelLib.ExcelWorksheet = workbook.Worksheets.Item(0)

        'Variables generales
        Dim vPuestoBolsaCodigo As String = String.Empty
        Dim vNombreLibro As String = ViewState("FileName").ToString()
        Dim vFechaLibro As String = String.Empty
        Dim vTipoLibroOrdenes As String = String.Empty
        Dim vCodigoSerie As String = Hoja.Item("A9").FormulaResultText

        'Establecemos los campos de la tabla resultado de la validacion
        ResultadoValidacion.Columns.Add("NombreArchivo", GetType(String))
        ResultadoValidacion.Columns.Add("PuestoBolsaCodigo", GetType(String))
        ResultadoValidacion.Columns.Add("TipoLibroOrdenes", GetType(String))
        ResultadoValidacion.Columns.Add("Fecha", GetType(String))
        ResultadoValidacion.Columns.Add("MontoValido", GetType(Decimal))
        ResultadoValidacion.Columns.Add("LineaNumero", GetType(Integer))
        ResultadoValidacion.Columns.Add("Estado", GetType(String))
        ResultadoValidacion.Columns.Add("Condicion", GetType(String))

        If Hoja.Item("E2").Value.ToString().Trim().Length <= 0 Then
            Throw New Exception("Error la celda E2 esta vacia.")
        ElseIf Hoja.Item("E2").Value <> cboTipoLibroOrdenes.SelectedValue.Trim() Then
            Throw New Exception("El archivo no coincide con el tipo de libro de ordenes seleccionado")
        Else
            vTipoLibroOrdenes = Hoja.Item("E2").Value
        End If

        If Hoja.Item("H5").FormulaResultText.Trim().Length <= 0 Then
            Throw New Exception("El codigo de puesto de bolsa esta vacio. Ver H5")
        Else
            vPuestoBolsaCodigo = Hoja.Item("H5").FormulaResultText
        End If

        'El campo fecha debe ser ingresado manualmente en el formato ddmmaaaa
        If Hoja.Item("E4").IsFormula Then
            Throw New Exception("El valor de la celda E4 NO debe ser resultado de una formula. Por favor digite el valor.")
        Else
            'Validamos que sea una fecha correcta
            Dim dateTime As Date
            If Not Date.TryParse(Hoja.Item("E4").Value, dateTime) Then
                Throw New Exception("Fecha incorrecta en celda E4.")
            Else
                vFechaLibro = oper.ConvertirCadenaFechaEnISO(Hoja.Item("E4").Value, cboFormatoFecha.Text)
            End If
        End If

        'Validar repeticion archivo
        If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) PuestoBolsaCodigo FROM [dbo].[Subasta] WHERE PuestoBolsaCodigo ='" + vPuestoBolsaCodigo + "' AND CONVERT(VARCHAR(10),[Fecha],121)='" & vFechaLibro & "' AND TipoLibroOrdenes='" & vTipoLibroOrdenes & "' AND Bono='" & vCodigoSerie & "') BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 1 Then
            chkSobrescribirArchivo.Enabled = True
            If chkSobrescribirArchivo.Checked = False And pValidarLOPI = False Then
                Throw New Exception("Debe seleccionar Sobrescribir archivo libro de ordenes para guadar un archivo que ya existe en el sistema.")
            ElseIf chkSobrescribirArchivo.Checked = True And pValidarLOPI = False Then
                If Not SobrescribirLibroOrdenes(vPuestoBolsaCodigo, vFechaLibro, vTipoLibroOrdenes, vCodigoSerie) Then
                    Throw New Exception("Error al sobrescribir el libro de ordenes.")
                Else
                    chkSobrescribirArchivo.Checked = False
                    chkSobrescribirArchivo.Enabled = False
                End If
            ElseIf chkSobrescribirArchivo.Checked = False Then
                Mensaje.ForeColor = Color.Red
                Mensaje.Text = "El archivo con el puesto de bolsa " & vPuestoBolsaCodigo & ", fecha " & Hoja.Item("E4").Value.ToString() & ", tipo libro ordenes " & vTipoLibroOrdenes & " y emisión " & vCodigoSerie & " ya existe."
                Mensaje.Text += "<br><span style='color:Blue'> Puede sobrescribir la información seleccionando la opción: Sobrescribir archivo libro de ordenes.</span>"
            End If
        End If

        If pValidarLOPI Then
            oper.ExecuteNonQuery("truncate table tmpValidarSubasta")
        End If


        If cboTipoBono.SelectedValue = "Emision" Then
            ' Determinar  limite minimo y limite maximo
            ViewState("Moneda") = oper.ExecuteScalar("SELECT Moneda FROM [dbo].[vConsultaEmisiones] WHERE Nemotecnico ='" + vCodigoSerie + "'")
            If ViewState("Moneda").ToString().Trim().Length <= 0 Then
                Throw New Exception("Na hay moneda registrada.")
            End If

            Dim Sql As String = "SELECT InversionMinima,InversionMaxima FROM [dbo].[vEmisionSerie] WHERE CodigoSerie ='" + vCodigoSerie + "'"
            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            Dim dt As DataTable = New DataTable
            dt.Load(cmd.ExecuteReader())
            If dt.Rows.Count > 0 Then
                ViewState("LimiteMinimo") = dt.Rows(0).Item("InversionMinima")
                ViewState("LimiteMaximo") = dt.Rows(0).Item("InversionMaxima")

            End If
            If ViewState("LimiteMinimo").ToString().Trim().Length <= 0 Then
                Throw New Exception("Na hay límite mínimo registrado.")
            End If
            If ViewState("LimiteMaximo").ToString().Trim().Length <= 0 Then
                Throw New Exception("Na hay límite máximo registrado.")
            End If

        End If

        Dim LineasGuardadas As Integer = 0
        Dim LineasNoGuardadas As Integer = 0

        Dim vContador As Integer = 1
        For i As Integer = 9 To Hoja.UsedRangeRows.Count
            If Hoja.Item("A" & i.ToString()).FormulaResultText <> "" Then
                Dim vBono As String = String.Empty
                Dim vMonto As Decimal = 0.0
                Dim vNotaMonto As String = String.Empty
                Dim vCant_Tit As Integer = 0.0
                Dim vPrecio As Decimal = 0.0
                Dim vValorTransado As Decimal = 0.0
                Dim vOrdenNo As Integer = 0
                Dim vFechaLinea As String = String.Empty
                Dim vHora As String = String.Empty
                Dim vRNT As String = String.Empty
                Dim vNoRegistroLibro As String = String.Empty
                Dim vTipoBono As String = String.Empty
                Dim vParcialTotal As String = String.Empty

                'Bono
                vBono = Hoja.Item("A" & i.ToString()).FormulaResultText

                'Monto
                If Hoja.Item("B" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. No requiere formula en celda B" & i.ToString())
                ElseIf Hoja.Item("B" & i.ToString()).NumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda B" & i.ToString())
                Else
                    vMonto = Hoja.Item("B" & i.ToString()).NumberValue
                End If

                'Nota Monto
                If Not Hoja.Item("C" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda C" & i.ToString())
                Else
                    vNotaMonto = Hoja.Item("C" & i.ToString()).FormulaResultText
                End If

                'Cantidad Titulos
                If Not Hoja.Item("D" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda D" & i.ToString())
                ElseIf Hoja.Item("D" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda D" & i.ToString())
                Else
                    vCant_Tit = Hoja.Item("D" & i.ToString()).FormulaResultNumberValue
                End If

                'Precio
                If Not Hoja.Item("E" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda E" & i.ToString())
                ElseIf Hoja.Item("E" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda E" & i.ToString())
                Else
                    vPrecio = Hoja.Item("E" & i.ToString()).FormulaResultNumberValue
                End If

                'Valor transado
                If Not Hoja.Item("F" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda F" & i.ToString())
                ElseIf Hoja.Item("F" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda F" & i.ToString())
                Else
                    vValorTransado = Hoja.Item("F" & i.ToString()).FormulaResultNumberValue
                End If

                'Orden numero
                If Not Hoja.Item("G" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda G" & i.ToString())
                ElseIf Hoja.Item("G" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda G" & i.ToString())
                Else
                    vOrdenNo = Hoja.Item("G" & i.ToString()).FormulaResultNumberValue
                End If

                'Fecha linea
                If Not Hoja.Item("H" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda H" & i.ToString())
                Else
                    'Validamos que sea una fecha correcta
                    Dim dateTime1 As Date
                    If Not Date.TryParse(Hoja.Item("H" & i.ToString()).FormulaResultValue, dateTime1) Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda H" & i.ToString())
                    Else
                        vFechaLinea = oper.ConvertirCadenaFechaEnISO(Hoja.Item("H" & i.ToString()).FormulaResultValue, cboFormatoFecha.Text)
                    End If
                End If
                'Hora
                Try
                    'Dim vHora1 As DateTime = Hoja.Item("I" & i.ToString()).DateTimeValue

                    If Hoja.Item("I" & i.ToString()).Value.ToString().Length > 0 Then
                        Dim Fecha1 As DateTime = DateTime.Parse(Hoja.Item("I" & i.ToString()).Value)
                        vHora = Fecha1.ToString("hh:mm:ss tt")
                    Else
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Valor Esta vacia la celda I" & i.ToString() & "Favor digitar  =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())
                    End If
                Catch ex As Exception
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error.Valor Incorrecto en la celda I" & i.ToString() & "Favor digitar  =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())

                End Try

                'Rnt
                If Hoja.Item("J" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. No requiere formula en celda J" & i.ToString())
                ElseIf Hoja.Item("J" & i.ToString()).Value.ToString().Trim().Length <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. La celda J" & i.ToString() & " esta vacia.")
                Else
                    vRNT = Hoja.Item("J" & i.ToString()).Value
                End If
                'Registro libro
                vNoRegistroLibro = Hoja.Item("K" & i.ToString()).Value
                'Tipo bono emision o programa emisiones
                vTipoBono = cboTipoBono.SelectedValue()

                'Parcial o total
                If Hoja.Item("L" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. No requiere formula en celda L" & i.ToString())
                ElseIf Hoja.Item("L" & i.ToString()).Value.ToString().Trim().Length <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. La celda L" & i.ToString() & " esta vacia.")
                Else
                    vParcialTotal = Hoja.Item("L" & i.ToString()).Value
                End If

                Dim dtablaOrden As New DataTable()
                dtablaOrden.Columns.Add("PuestoBolsaCodigo", GetType(String))
                dtablaOrden.Columns.Add("Fecha", GetType(String))
                dtablaOrden.Columns.Add("Bono", GetType(String))
                dtablaOrden.Columns.Add("Monto", GetType(String))
                dtablaOrden.Columns.Add("CodigoISIN", GetType(String))
                dtablaOrden.Columns.Add("Cant_Tit", GetType(String))
                dtablaOrden.Columns.Add("Precio", GetType(String))
                dtablaOrden.Columns.Add("ValorTransado", GetType(String))
                dtablaOrden.Columns.Add("OrdenNo", GetType(String))
                dtablaOrden.Columns.Add("FechaLinea", GetType(String))
                dtablaOrden.Columns.Add("Hora", GetType(String))
                dtablaOrden.Columns.Add("RNT", GetType(String))
                dtablaOrden.Columns.Add("NoRegistroLibro", GetType(String))
                dtablaOrden.Columns.Add("TipoLibroOrdenes", GetType(String))
                dtablaOrden.Columns.Add("TipoBono", GetType(String))
                dtablaOrden.Columns.Add("ParcialTotal", GetType(String))
                dtablaOrden.Rows.Add(Hoja.Item("H5").FormulaResultText,
                                     Hoja.Item("E4").DateTimeValue,
                                     Hoja.Item("A" & i.ToString()).FormulaResultText,
                                     Hoja.Item("B" & i.ToString()).NumberValue,
                                     Hoja.Item("C" & i.ToString()).FormulaResultText,
                                     Hoja.Item("D" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("E" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("F" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("G" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("H" & i.ToString()).FormulaResultDateTimeValue,
                                     vHora,
                                     Hoja.Item("J" & i.ToString()).Value,
                                     Hoja.Item("K" & i.ToString()).Value,
                                     Hoja.Item("E2").Value,
                                     cboTipoBono.SelectedValue(),
                                     Hoja.Item("L" & i.ToString()).Value)
                dtable.Rows.Add(Hoja.Item("H5").FormulaResultText,
                                Hoja.Item("E4").DateTimeValue,
                                Hoja.Item("A" & i.ToString()).FormulaResultText,
                                Hoja.Item("B" & i.ToString()).NumberValue,
                                Hoja.Item("C" & i.ToString()).FormulaResultText,
                                Hoja.Item("D" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("E" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("F" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("G" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("H" & i.ToString()).FormulaResultDateTimeValue,
                                vHora,
                                Hoja.Item("J" & i.ToString()).Value,
                                Hoja.Item("K" & i.ToString()).Value,
                                Hoja.Item("E2").Value,
                                cboTipoBono.SelectedValue(),
                                Hoja.Item("L" & i.ToString()).Value)
                'Retorno mayor que cero existe error
                If RegistrarOrdenLOPI(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, vContador, dtablaOrden, pValidarLOPI) Then
                    'Error
                    LineasGuardadas += 1
                Else
                    LineasNoGuardadas += 1
                End If
                vContador = vContador + 1
            End If
        Next

        If LineasGuardadas > 0 And pValidarLOPI = False Then
            STools.InsertarInformacionArchivo(ViewState("FileName"), LineasGuardadas, LineasNoGuardadas, FileType)
            rgListaArchivosCargados.Rebind()
        End If

        'Mostramos el resultado de la validación
        lblResultadoValidacion.Text = String.Empty
        lblResultadoValidacion.ForeColor = Color.Blue

        If LineasNoGuardadas = 0 Then
            If pValidarLOPI Then
                'Si es validar
                lblResultadoValidacion.Text = "Se ha validado con éxito el archivo : " & vNombreLibro
                'lblResultadoValidacion.Text += "</br> Cantidad de líneas válidas para guardar:  " & (vContador - 1)
            Else
                lblResultadoValidacion.Text = "Se cargo con éxito el archivo : " & vNombreLibro & "</br> Cantidad de líneas guardadas:  " & (vContador - 1)
            End If
            lblResultadoValidacion.Text += "</br></br> Mensaje validación:</br> "
        Else
            If pValidarLOPI Then
                'Si es validar
                lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro
                'lblResultadoValidacion.Text += " </br>Líneas válidas para guardar  " & LineasGuardadas.ToString & " de un total de " & (vContador - 1) & ".</span>"
            Else
                lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro & " Se guardaron  " & LineasGuardadas.ToString & " líneas de un total de " & (vContador - 1) & ".</span>"
            End If
            lblResultadoValidacion.Text += "</br></br> Mensaje validación: </br>"
        End If

        For Each rvRow In ResultadoValidacion.Rows
            If rvRow("Estado").ToString() = "X" Then
                lblResultadoValidacion.Text += "<span style='color:Red'>Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "</span><br>"

            Else
                lblResultadoValidacion.Text += "Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "<br>"
            End If
        Next

        'Mostramos la moneda en pantalla
        lblTipoMoneda.Text = "Tipo Moneda: " + ViewState("Moneda").ToString()

        'Mostramos los limites en pantalla
        If cboTipoLibroOrdenes.SelectedValue = "LOPI" Then
            lblLimiteInversionMinimo.Text = "Límite de Inversión mínimo PI: " + ViewState("LimiteMinimo").ToString()
            lblLimiteInversionMaximo.Text = "Límite de Inversión máximo: PI: " + ViewState("LimiteMaximo").ToString()
        End If

    End Sub

    Private Sub ProcesarLibroOrdenesLOPI_More2007(lFormatoBritanico As Boolean, ByVal pValidarLOPI As Boolean)
        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        'Para almacenar todas laas lineas de los libros
        dtable.Columns.Add("PuestoBolsaCodigo", GetType(String))
        dtable.Columns.Add("Fecha", GetType(String))
        dtable.Columns.Add("Bono", GetType(String))
        dtable.Columns.Add("Monto", GetType(Decimal))
        dtable.Columns.Add("CodigoISIN", GetType(String))
        dtable.Columns.Add("Cant_Tit", GetType(Integer))
        dtable.Columns.Add("Precio", GetType(Decimal))
        dtable.Columns.Add("ValorTransado", GetType(Decimal))
        dtable.Columns.Add("OrdenNo", GetType(Integer))
        dtable.Columns.Add("FechaLinea", GetType(String))
        dtable.Columns.Add("Hora", GetType(String))
        dtable.Columns.Add("RNT", GetType(String))
        dtable.Columns.Add("NoRegistroLibro", GetType(String))
        dtable.Columns.Add("TipoLibroOrdenes", GetType(String))
        dtable.Columns.Add("TipoBono", GetType(String))
        dtable.Columns.Add("ParcialTotal", GetType(String))

        'Establecemos los campos de la tabla resultado de la validacion
        ResultadoValidacion.Columns.Add("NombreArchivo", GetType(String))
        ResultadoValidacion.Columns.Add("PuestoBolsaCodigo", GetType(String))
        ResultadoValidacion.Columns.Add("TipoLibroOrdenes", GetType(String))
        ResultadoValidacion.Columns.Add("Fecha", GetType(String))
        ResultadoValidacion.Columns.Add("MontoValido", GetType(Decimal))
        ResultadoValidacion.Columns.Add("LineaNumero", GetType(Integer))
        ResultadoValidacion.Columns.Add("Estado", GetType(String))
        ResultadoValidacion.Columns.Add("Condicion", GetType(String))
        Dim testDocFile As String = Nothing
        testDocFile = System.IO.Path.Combine(Server.MapPath("~/tmp/"), ViewState("FileName"))

        Dim workBook As FileInfo = New FileInfo(testDocFile)
        Using excel = New ExcelPackage(workBook)
            Dim ws As ExcelWorksheet = excel.Workbook.Worksheets.First()

            'Variables generales
            Dim vPuestoBolsaCodigo As String = String.Empty
            Dim vNombreLibro As String = ViewState("FileName").ToString()
            Dim vFechaLibro As String = String.Empty
            Dim vTipoLibroOrdenes As String = String.Empty
            Dim vCodigoSerie As String = String.Empty

            Dim p As String = ws.Cells("D9").Formula
            Dim p1 As String = ws.Cells("E4").Formula
            'Bono
            If ws.Cells("A9").Formula.Length <= 0 Then
                ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                             1, "X", "Error. Requiere formula en celda A9")
            ElseIf ws.Cells("A9").Text.Trim().Length <= 0 Then
                ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                             1, "X", "Error. Esta vacia la celda A9")
            Else
                vCodigoSerie = ws.Cells("A9").Value
            End If

            If ws.Cells("E2").Text.Trim().Length <= 0 Then
                Throw New Exception("Error la celda E2 esta vacia.")
            ElseIf ws.Cells("E2").Value <> cboTipoLibroOrdenes.SelectedValue.Trim() Then
                Throw New Exception("El archivo no coincide con el tipo de libro de ordenes seleccionado")
            Else
                vTipoLibroOrdenes = ws.Cells("E2").Value
            End If

            If ws.Cells("H5").Text.Trim().Length <= 0 Then
                Throw New Exception("El codigo de puesto de bolsa esta vacio. Ver H5")
            Else
                vPuestoBolsaCodigo = ws.Cells("H5").Value
            End If

            'El campo fecha debe ser ingresado manualmente en el formato ddmmaaaa
            If ws.Cells("E4").Formula.Length > 0 Then
                Throw New Exception("El valor de la celda E4 NO debe ser resultado de una formula. Por favor digite el valor.")
            Else
                'Validamos que sea una fecha correcta
                Dim dateTime As Date
                If Not Date.TryParse(ws.Cells("E4").Text, dateTime) Then
                    Throw New Exception("Fecha incorrecta en celda E4.")
                Else
                    vFechaLibro = ws.Cells("E4").Text 'oper.ConvertirCadenaFechaEnISO(ws.Cells("E4").Value, cboFormatoFecha.Text)
                End If
            End If

            'Validar repeticion archivo
            If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) PuestoBolsaCodigo FROM [dbo].[Subasta] WHERE PuestoBolsaCodigo ='" + vPuestoBolsaCodigo + "' AND CONVERT(VARCHAR(10),[Fecha],121)='" & vFechaLibro & "' AND TipoLibroOrdenes='" & vTipoLibroOrdenes & "' AND Bono='" & vCodigoSerie & "') BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 1 Then
                chkSobrescribirArchivo.Enabled = True
                If chkSobrescribirArchivo.Checked = False And pValidarLOPI = False Then
                    Throw New Exception("Debe seleccionar Sobrescribir archivo libro de ordenes para guadar un archivo que ya existe en el sistema.")
                ElseIf chkSobrescribirArchivo.Checked = True And pValidarLOPI = False Then
                    If Not SobrescribirLibroOrdenes(vPuestoBolsaCodigo, vFechaLibro, vTipoLibroOrdenes, vCodigoSerie) Then
                        Throw New Exception("Error al sobrescribir el libro de ordenes.")
                    Else
                        chkSobrescribirArchivo.Checked = False
                        chkSobrescribirArchivo.Enabled = False
                    End If
                ElseIf chkSobrescribirArchivo.Checked = False Then
                    Mensaje.ForeColor = Color.Red
                    Mensaje.Text = "El archivo con el puesto de bolsa " & vPuestoBolsaCodigo & ", fecha " & ws.Cells("E4").Value.ToString() & ", tipo libro ordenes " & vTipoLibroOrdenes & " y emisión " & vCodigoSerie & " ya existe."
                    Mensaje.Text += "<br><span style='color:Blue'> Puede sobrescribir la información seleccionando la opción: Sobrescribir archivo libro de ordenes.</span>"
                End If
            End If

            If pValidarLOPI Then
                oper.ExecuteNonQuery("truncate table tmpValidarSubasta")
            End If


            If cboTipoBono.SelectedValue = "Emision" Then
                ' Determinar  limite minimo y limite maximo
                ViewState("Moneda") = oper.ExecuteScalar("SELECT Moneda FROM [dbo].[vConsultaEmisiones] WHERE Nemotecnico ='" + vCodigoSerie + "'")
                If ViewState("Moneda").ToString().Trim().Length <= 0 Then
                    Throw New Exception("Na hay moneda registrada.")
                End If

                Dim Sql As String = "SELECT InversionMinima,InversionMaxima FROM [dbo].[vEmisionSerie] WHERE CodigoSerie ='" + vCodigoSerie + "'"
                Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                Cnx.Open()
                Dim cmd As New SqlCommand(Sql, Cnx)

                Dim dt As DataTable = New DataTable
                dt.Load(cmd.ExecuteReader())
                If dt.Rows.Count > 0 Then
                    ViewState("LimiteMinimo") = dt.Rows(0).Item("InversionMinima")
                    ViewState("LimiteMaximo") = dt.Rows(0).Item("InversionMaxima")

                End If
                If ViewState("LimiteMinimo").ToString().Trim().Length <= 0 Then
                    Throw New Exception("Na hay límite mínimo registrado.")
                End If
                If ViewState("LimiteMaximo").ToString().Trim().Length <= 0 Then
                    Throw New Exception("Na hay límite máximo registrado.")
                End If

            End If

            Dim LineasGuardadas As Integer = 0
            Dim LineasNoGuardadas As Integer = 0
            Dim vContador As Integer = 1

            Dim InicioLinea As Integer = 9
            Dim FilasNoVacias As Integer = GetLastUsedRow(ws, InicioLinea)

            For i As Integer = 9 To FilasNoVacias
                If ws.Cells("A" & i.ToString()).Value <> "" Then
                    Dim vBono As String = String.Empty
                    Dim vMonto As Decimal = 0.0
                    Dim vNotaMonto As String = String.Empty
                    Dim vCant_Tit As Integer = 0.0
                    Dim vPrecio As Decimal = 0.0
                    Dim vValorTransado As Decimal = 0.0
                    Dim vOrdenNo As Integer = 0
                    Dim vFechaLinea As String = String.Empty
                    Dim vHora As String = String.Empty
                    Dim vRNT As String = String.Empty
                    Dim vNoRegistroLibro As String = String.Empty
                    Dim vTipoBono As String = String.Empty
                    Dim vParcialTotal As String = String.Empty

                    'Bono
                    vBono = ws.Cells("A" & i.ToString()).Value

                    'Monto
                    If ws.Cells("B" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda B" & i.ToString())
                    ElseIf ws.Cells("B" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda B" & i.ToString())
                    ElseIf Val(ws.Cells("B" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en la celda B" & i.ToString())
                    Else
                        vMonto = ws.Cells("B" & i.ToString()).Text
                    End If

                    'Nota Monto
                    If ws.Cells("C" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda C" & i.ToString())
                    Else
                        vNotaMonto = ws.Cells("C" & i.ToString()).Value
                    End If

                    'Cantidad Titulos 
                    If ws.Cells("D" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda D" & i.ToString())
                    ElseIf ws.Cells("D" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda D" & i.ToString())
                    ElseIf Val(ws.Cells("D" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda D" & i.ToString())
                    Else
                        vCant_Tit = ws.Cells("D" & i.ToString()).Value
                    End If

                    'Precio
                    If ws.Cells("E" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda E" & i.ToString())
                    ElseIf ws.Cells("E" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda E" & i.ToString())
                    ElseIf Val(ws.Cells("E" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda E" & i.ToString())
                    Else
                        vPrecio = ws.Cells("E" & i.ToString()).Value
                    End If

                    'Valor transado
                    If ws.Cells("F" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda F" & i.ToString())
                    ElseIf ws.Cells("F" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Esta vacia la celda F" & i.ToString())
                    ElseIf ws.Cells("F" & i.ToString()).Value <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda F" & i.ToString())
                    Else
                        vValorTransado = ws.Cells("F" & i.ToString()).Value
                    End If

                    'Orden numero
                    If ws.Cells("G" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda G" & i.ToString())
                    ElseIf ws.Cells("G" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda G" & i.ToString())
                    ElseIf Val(ws.Cells("G" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda G" & i.ToString())
                    Else
                        vOrdenNo = ws.Cells("G" & i.ToString()).Value
                    End If

                    'Fecha linea
                    If ws.Cells("H" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda H" & i.ToString())
                    Else
                        'Validamos que sea una fecha correcta
                        Dim dateTime1 As Date
                        If Not Date.TryParse(ws.Cells("H" & i.ToString()).Value, dateTime1) Then
                            ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                         vContador.ToString, "X", "Error. Valor incorrecto en celda H" & i.ToString())
                        Else
                            vFechaLinea = ws.Cells("H" & i.ToString()).Value 'oper.ConvertirCadenaFechaEnISO(ws.Cells("H" & i.ToString()).FormulaResultValue, cboFormatoFecha.Text)
                        End If
                    End If
                    'Hora

                    If ws.Cells("I" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Requiere formula. Favor digitar =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())
                    End If
                    Try
                        If Convert.ToDecimal(ws.Cells("I" & i.ToString()).Value) > 0 Then
                            Dim Fecha1 As DateTime = DateTime.FromOADate(Convert.ToDouble(ws.Cells("I" & i.ToString()).Value))
                            vHora = Fecha1.ToString("hh:mm:ss tt")
                        End If
                    Catch ex As Exception
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Valor Incorrecto en la celda I" & i.ToString() & "Favor digitar  =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())

                    End Try

                    'Rnt
                    If ws.Cells("J" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda J" & i.ToString())
                    ElseIf ws.Cells("J" & i.ToString()).Text.ToString().Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. La celda J" & i.ToString() & " esta vacia.")
                    Else
                        vRNT = ws.Cells("J" & i.ToString()).Text
                    End If
                    'Registro libro

                    If ws.Cells("K" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda L" & i.ToString())
                    ElseIf ws.Cells("K" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda L" & i.ToString())
                    Else
                        vNoRegistroLibro = ws.Cells("K" & i.ToString()).Text
                    End If

                    'Tipo bono emision o programa emisiones
                    vTipoBono = cboTipoBono.SelectedValue()
                    'Parcial o total
                    If ws.Cells("L" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda L" & i.ToString())
                    ElseIf ws.Cells("L" & i.ToString()).Text.ToString().Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. La celda L" & i.ToString() & " esta vacia.")
                    Else
                        vParcialTotal = ws.Cells("L" & i.ToString()).Text
                    End If

                    Dim dtablaOrden As New DataTable()
                    dtablaOrden.Columns.Add("PuestoBolsaCodigo", GetType(String))
                    dtablaOrden.Columns.Add("Fecha", GetType(String))
                    dtablaOrden.Columns.Add("Bono", GetType(String))
                    dtablaOrden.Columns.Add("Monto", GetType(Decimal))
                    dtablaOrden.Columns.Add("CodigoISIN", GetType(String))
                    dtablaOrden.Columns.Add("Cant_Tit", GetType(Integer))
                    dtablaOrden.Columns.Add("Precio", GetType(Decimal))
                    dtablaOrden.Columns.Add("ValorTransado", GetType(Decimal))
                    dtablaOrden.Columns.Add("OrdenNo", GetType(Integer))
                    dtablaOrden.Columns.Add("FechaLinea", GetType(String))
                    dtablaOrden.Columns.Add("Hora", GetType(String))
                    dtablaOrden.Columns.Add("RNT", GetType(String))
                    dtablaOrden.Columns.Add("NoRegistroLibro", GetType(String))
                    dtablaOrden.Columns.Add("TipoLibroOrdenes", GetType(String))
                    dtablaOrden.Columns.Add("TipoBono", GetType(String))
                    dtablaOrden.Columns.Add("ParcialTotal", GetType(String))

                    dtablaOrden.Rows.Add(ws.Cells("H5").Value,
                                         ws.Cells("E4").Value,
                                         ws.Cells("A" & i.ToString()).Value,
                                         ws.Cells("B" & i.ToString()).Text,
                                         ws.Cells("C" & i.ToString()).Value,
                                         ws.Cells("D" & i.ToString()).Value,
                                         ws.Cells("E" & i.ToString()).Value,
                                         ws.Cells("F" & i.ToString()).Value,
                                         ws.Cells("G" & i.ToString()).Value,
                                         ws.Cells("H" & i.ToString()).Value,
                                         vHora,
                                         ws.Cells("J" & i.ToString()).Text,
                                         ws.Cells("K" & i.ToString()).Text,
                                         ws.Cells("E2").Value,
                                         cboTipoBono.SelectedValue(),
                                         ws.Cells("L" & i.ToString()).Text)

                    dtable.Rows.Add(ws.Cells("H5").Value,
                                    ws.Cells("E4").Value,
                                    ws.Cells("A" & i.ToString()).Value,
                                    ws.Cells("B" & i.ToString()).Text,
                                    ws.Cells("C" & i.ToString()).Value,
                                    ws.Cells("D" & i.ToString()).Value,
                                    ws.Cells("E" & i.ToString()).Value,
                                    ws.Cells("F" & i.ToString()).Value,
                                    ws.Cells("G" & i.ToString()).Value,
                                    ws.Cells("H" & i.ToString()).Value,
                                    vHora,
                                    ws.Cells("J" & i.ToString()).Text,
                                    ws.Cells("K" & i.ToString()).Text,
                                    ws.Cells("E2").Value,
                                    cboTipoBono.SelectedValue(),
                                    ws.Cells("L" & i.ToString()).Text)
                    'Retorno mayor que cero existe error
                    If RegistrarOrdenLOPI(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, vContador, dtablaOrden, pValidarLOPI) Then
                        'Error
                        LineasGuardadas += 1
                    Else
                        LineasNoGuardadas += 1
                    End If
                    vContador = vContador + 1
                Else
                    Exit For
                End If
            Next

            If LineasGuardadas > 0 And pValidarLOPI = False Then
                STools.InsertarInformacionArchivo(ViewState("FileName"), LineasGuardadas, LineasNoGuardadas, FileType)
                rgListaArchivosCargados.Rebind()
            End If

            'Mostramos el resultado de la validación
            lblResultadoValidacion.Text = String.Empty
            lblResultadoValidacion.ForeColor = Color.Blue

            If LineasNoGuardadas = 0 Then
                If pValidarLOPI Then
                    'Si es validar
                    lblResultadoValidacion.Text = "Se ha validado con éxito el archivo : " & vNombreLibro
                    'lblResultadoValidacion.Text += "</br> Cantidad de líneas válidas para guardar:  " & (vContador - 1)
                Else
                    lblResultadoValidacion.Text = "Se cargo con éxito el archivo : " & vNombreLibro & "</br> Cantidad de líneas guardadas:  " & (vContador - 1)
                End If
                lblResultadoValidacion.Text += "</br></br> Mensaje validación:</br> "
            Else
                If pValidarLOPI Then
                    'Si es validar
                    lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro
                    'lblResultadoValidacion.Text += " </br>Líneas válidas para guardar  " & LineasGuardadas.ToString & " de un total de " & (vContador - 1) & ".</span>"
                Else
                    lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro & " Se guardaron  " & LineasGuardadas.ToString & " líneas de un total de " & (vContador - 1) & ".</span>"
                End If
                lblResultadoValidacion.Text += "</br></br> Mensaje validación: </br>"
            End If

            For Each rvRow In ResultadoValidacion.Rows
                If rvRow("Estado").ToString() = "X" Then
                    lblResultadoValidacion.Text += "<span style='color:Red'>Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "</span><br>"

                Else
                    lblResultadoValidacion.Text += "Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "<br>"
                End If
            Next

            'Mostramos la moneda en pantalla 
            lblTipoMoneda.Text = "Tipo Moneda: " + ViewState("Moneda").ToString()

            'Mostramos los limites en pantalla
            If cboTipoLibroOrdenes.SelectedValue = "LOPI" Then
                lblLimiteInversionMinimo.Text = "Límite de Inversión mínimo PI: " + ViewState("LimiteMinimo").ToString()
                lblLimiteInversionMaximo.Text = "Límite de Inversión máximo: PI: " + ViewState("LimiteMaximo").ToString()
            End If
        End Using

    End Sub

    Function RegistrarOrdenLOPI(ByVal pNombreLibro, ByVal pPuestoBolsaCodigo, ByVal pTipoLibroOrdenes, ByVal pFechaLibro, ByVal pLineaNumero, ByVal pdtablaOrden, ByVal pValidarLOPI) As Boolean
        Dim vRetorno As Boolean = False
        Dim stringFechaHora As String = ""
        Dim vMontoValido As Decimal = 0.0

        Dim Sql As String = ""
        If (pValidarLOPI) Then
            Sql = "INSERT INTO tmpValidarSubasta ([PuestoBolsaCodigo] ,[Fecha] ,[Bono] ,[Monto] ,[CodigoISIN] ,[Cant_Tit] ,[Precio] ,[ValorTransado] ,[OrdenNo] ,[FechaLinea] ,[Hora] ,[RNT] ,[NoRegistroLibro],[Estado],[Condicion],[TipoLibroOrdenes],[TipoBono], [ParcialTotal],[MontoValido]) VALUES (@PuestoBolsaCodigo, @Fecha,@Bono,@Monto,@CodigoISIN,@Cant_Tit,@Precio,@ValorTransado,@OrdenNo,@FechaLinea,@Hora,@RNT,@NoRegistroLibro,@Estado,@Condicion,@TipoLibroOrdenes, @TipoBono, @ParcialTotal,@MontoValido)"

        Else
            Sql = "INSERT INTO [Subasta] ([PuestoBolsaCodigo] ,[Fecha] ,[Bono] ,[Monto] ,[CodigoISIN] ,[Cant_Tit] ,[Precio] ,[ValorTransado] ,[OrdenNo] ,[FechaLinea] ,[Hora] ,[RNT] ,[NoRegistroLibro],[Estado],[Condicion],[TipoLibroOrdenes],[TipoBono], [ParcialTotal],[MontoValido]) VALUES (@PuestoBolsaCodigo, @Fecha,@Bono,@Monto,@CodigoISIN,@Cant_Tit,@Precio,@ValorTransado,@OrdenNo,@FechaLinea,@Hora,@RNT,@NoRegistroLibro,@Estado,@Condicion,@TipoLibroOrdenes, @TipoBono, @ParcialTotal,@MontoValido)"

        End If

        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            For Each dRow In pdtablaOrden.Rows
                Try
                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCodigo", SqlDbType.Char)).Value = dRow(0)
                    If Not IsDBNull(dRow.Item(1)) Then
                        stringFechaHora = dRow.Item(1)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add(New SqlParameter("@Bono", SqlDbType.Char)).Value = dRow(2)
                    cmd.Parameters.Add(New SqlParameter("@Monto", SqlDbType.Decimal)).Value = Val(dRow(3))
                    vMontoValido = Val(dRow(3))
                    cmd.Parameters.Add(New SqlParameter("@CodigoISIN", SqlDbType.Char)).Value = IIf(dRow.Item(4) = "Monto Validado", "", dRow.Item(4))
                    cmd.Parameters.Add(New SqlParameter("@Cant_Tit", SqlDbType.Decimal)).Value = Val(dRow(5))
                    cmd.Parameters.Add(New SqlParameter("@Precio", SqlDbType.Decimal)).Value = Val(dRow(6))
                    cmd.Parameters.Add(New SqlParameter("@ValorTransado", SqlDbType.Decimal)).Value = Val(dRow(7))
                    cmd.Parameters.Add(New SqlParameter("@OrdenNo", SqlDbType.Decimal)).Value = Val(dRow(8))

                    If Not IsDBNull(dRow.Item(9)) Then
                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(9), cboFormatoFecha.Text)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add(New SqlParameter("@Hora", SqlDbType.Char)).Value = dRow(10)
                    cmd.Parameters.Add(New SqlParameter("@RNT", SqlDbType.Char)).Value = dRow(11)
                    cmd.Parameters.Add(New SqlParameter("@NoRegistroLibro", SqlDbType.Char)).Value = dRow(12)

                    'Validamos el monto
                    Dim vRetornoLimiteMontoRNT As ArrayList = ValidarLimiteMontoLOPI(cboTipoLibroOrdenes.SelectedValue, cboTipoBono.SelectedValue, dRow(2), dRow(11), dRow(3), dRow(15), pValidarLOPI)
                    cmd.Parameters.Add(New SqlParameter("@Estado", SqlDbType.Char)).Value = vRetornoLimiteMontoRNT(0)
                    cmd.Parameters.Add(New SqlParameter("@Condicion", SqlDbType.Char)).Value = vRetornoLimiteMontoRNT(1)
                    vMontoValido = vRetornoLimiteMontoRNT(2)
                    'Guardamos el mensaje de retorno
                    ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                                 vMontoValido.ToString, pLineaNumero.ToString, vRetornoLimiteMontoRNT(0).ToString(), vRetornoLimiteMontoRNT(1).ToString)

                    cmd.Parameters.Add(New SqlParameter("@TipoLibroOrdenes", SqlDbType.Char)).Value = cboTipoLibroOrdenes.SelectedValue
                    cmd.Parameters.Add(New SqlParameter("@TipoBono", SqlDbType.Char)).Value = cboTipoBono.SelectedValue
                    cmd.Parameters.Add(New SqlParameter("@ParcialTotal", SqlDbType.Char)).Value = dRow(15)
                    cmd.Parameters.Add(New SqlParameter("@MontoValido", SqlDbType.Decimal)).Value = vMontoValido

                    Dim csql As String = oper.CovertirComandoATexto(cmd)
                    vRetorno = True
                    cmd.ExecuteNonQuery()
                Catch sql_ex As SqlClient.SqlException
                    ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                                 vMontoValido.ToString, pLineaNumero.ToString, "X", "Error Sql registro no guardado. " & sql_ex.Message)
                Catch ex As Exception
                    ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                                 vMontoValido.ToString, pLineaNumero.ToString, "X", "Registro no guardado. " & ex.Message)
                End Try

            Next

        Catch ex As Exception
            ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                         vMontoValido.ToString, pLineaNumero.ToString, "X", "Error al intentar guardar el registro. " & ex.Message)
        End Try
        Return vRetorno
    End Function

    Function ValidarLimiteMontoLOPI(ByVal pTipoLibroOrdenes, ByVal pTipoBono, ByVal pBono, ByVal pRNT, ByVal pMonto, ByVal pParcialTotal, ByVal pValidarLOPI) As ArrayList
        Dim Resultado As New ArrayList

        If pMonto > CInt(ViewState("LimiteMaximo")) Or pMonto < CInt(ViewState("LimiteMinimo")) Then
            Resultado.Add("X")
            Resultado.Add("No válido. Fuera de límite de inversión permitido.")
            Resultado.Add(Val(0))
        Else
            'Verificamos si la accion es validar o insertar para calcular el monto total por RNT desde el dictionario si es validar o desde la base de datos si es insertar
            Dim vTotal As Decimal = oper.ExecuteScalar("SELECT ISNULL(SUM(MontoValido),0) FROM dbo.Subasta WHERE TipoLibroOrdenes='" & pTipoLibroOrdenes & "' AND TipoBono='" & pTipoBono & "' AND Bono='" & pBono & "' AND RNT='" & pRNT & "' ")

            Dim vTotalValidarRNT As Decimal = 0.0
            'Verificamos si la accion es validar o insertar para sumara el monto al rnt en caso de haber mas de un mismo rnt por documento

            If (pValidarLOPI) Then
                vTotalValidarRNT = oper.ExecuteScalar("SELECT ISNULL(SUM(MontoValido),0) FROM dbo.tmpValidarSubasta WHERE TipoLibroOrdenes='" & pTipoLibroOrdenes & "' AND TipoBono='" & pTipoBono & "' AND Bono='" & pBono & "' AND RNT='" & pRNT & "' ")

                vTotal = vTotal + vTotalValidarRNT
            End If

            If vTotal < Val(ViewState("LimiteMaximo")) Then
                If (Val(ViewState("LimiteMaximo")) - vTotal) < Val(ViewState("LimiteMinimo")) Then
                    Resultado.Add("X")
                    Resultado.Add("No válido. La diferencia para completar el límite máximo por RNT es menor que el límite mínimo.")
                    Resultado.Add(0)
                Else
                    If (Val(ViewState("LimiteMaximo")) - vTotal) >= pMonto Then
                        Resultado.Add("V")
                        Resultado.Add("Válido") '1 Válido
                        Resultado.Add(pMonto)
                    ElseIf (Val(ViewState("LimiteMaximo")) - vTotal) < pMonto Then
                        If pParcialTotal = "T" Then
                            Resultado.Add("X")
                            Resultado.Add("No válido. El monto excede el límite permitido por RNT")
                            Resultado.Add(Val(0))
                        ElseIf (Val(ViewState("LimiteMaximo")) - vTotal) >= Val(ViewState("LimiteMinimo")) And pParcialTotal = "P" Then
                            Resultado.Add("V")
                            Resultado.Add("Válido. Se ha tomado el " & (Val(ViewState("LimiteMaximo")) - vTotal).ToString() & " del " & pMonto & " demandado.")
                            Resultado.Add(Val(ViewState("LimiteMaximo")) - vTotal)
                        End If
                    End If
                End If
            ElseIf vTotal >= Val(ViewState("LimiteMaximo")) Then
                Resultado.Add("X")
                Resultado.Add("No válido. El monto permitido por RNT ya está completo.")
                Resultado.Add(Val(0))
            End If
        End If
        Return Resultado
    End Function

    Private Sub ProcesarLibroOrdenesLOIG_More2003(lFormatoBritanico As Boolean, ByVal pValidarLOIG As Boolean)
        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        'Para almacenar todas laas lineas de los libros
        dtable.Columns.Add("PuestoBolsaCodigo", GetType(String))
        dtable.Columns.Add("Fecha", GetType(String))
        dtable.Columns.Add("Bono", GetType(String))
        dtable.Columns.Add("Monto", GetType(String))
        dtable.Columns.Add("CodigoISIN", GetType(String))
        dtable.Columns.Add("Cant_Tit", GetType(String))
        dtable.Columns.Add("Precio", GetType(String))
        dtable.Columns.Add("ValorTransado", GetType(String))
        dtable.Columns.Add("OrdenNo", GetType(String))
        dtable.Columns.Add("FechaLinea", GetType(String))
        dtable.Columns.Add("Hora", GetType(String))
        dtable.Columns.Add("RNT", GetType(String))
        dtable.Columns.Add("NoRegistroLibro", GetType(String))
        dtable.Columns.Add("TipoLibroOrdenes", GetType(String))
        dtable.Columns.Add("TipoBono", GetType(String))
        dtable.Columns.Add("ParcialTotal", GetType(String))
        dtable.Columns.Add("OrdenPropiaTerceros", GetType(String))
        ' Crear una variable para manejar el formato de la hoja
        Dim workbookFormat As ExpertXls.ExcelLib.ExcelWorkbookFormat = ExpertXls.ExcelLib.ExcelWorkbookFormat.Xls_2003

        ' Buscar el Archivo en la ruta establecida
        Dim testDocFile As String = Nothing
        testDocFile = System.IO.Path.Combine(Server.MapPath("~/tmp/"), ViewState("FileName"))

        ' Abrir una hoja con el formato establecido
        Dim workbook As ExpertXls.ExcelLib.ExcelWorkbook = New ExpertXls.ExcelLib.ExcelWorkbook(testDocFile, "")

        ' Posicionarnos en la Hoja 1
        Dim Hoja As ExpertXls.ExcelLib.ExcelWorksheet = workbook.Worksheets.Item(0)

        'Variables generales
        Dim vPuestoBolsaCodigo As String = String.Empty
        Dim vNombreLibro As String = ViewState("FileName").ToString()
        Dim vFechaLibro As String = String.Empty
        Dim vTipoLibroOrdenes As String = String.Empty
        Dim vCodigoSerie As String = Hoja.Item("A9").FormulaResultText

        'Establecemos los campos de la tabla resultado de la validacion
        ResultadoValidacion.Columns.Add("NombreArchivo", GetType(String))
        ResultadoValidacion.Columns.Add("PuestoBolsaCodigo", GetType(String))
        ResultadoValidacion.Columns.Add("TipoLibroOrdenes", GetType(String))
        ResultadoValidacion.Columns.Add("Fecha", GetType(String))
        ResultadoValidacion.Columns.Add("MontoValido", GetType(Decimal))
        ResultadoValidacion.Columns.Add("LineaNumero", GetType(Integer))
        ResultadoValidacion.Columns.Add("Estado", GetType(String))
        ResultadoValidacion.Columns.Add("Condicion", GetType(String))

        If Hoja.Item("E2").Value.ToString().Trim().Length <= 0 Then
            Throw New Exception("Error la celda E2 esta vacia.")
        ElseIf Hoja.Item("E2").Value <> cboTipoLibroOrdenes.SelectedValue.Trim() Then
            Throw New Exception("El archivo no coincide con el tipo de libro de ordenes seleccionado")
        Else
            vTipoLibroOrdenes = Hoja.Item("E2").Value
        End If

        If Hoja.Item("H5").FormulaResultText.Trim().Length <= 0 Then
            Throw New Exception("El codigo de puesto de bolsa esta vacio. Ver H5")
        Else
            vPuestoBolsaCodigo = Hoja.Item("H5").FormulaResultText
        End If

        'El campo fecha debe ser ingresado manualmente en el formato ddmmaaaa
        If Hoja.Item("E4").IsFormula Then
            Throw New Exception("El valor de la celda E4 NO debe ser resultado de una formula. Por favor digite el valor.")
        Else
            'Validamos que sea una fecha correcta
            Dim dateTime As Date
            If Not Date.TryParse(Hoja.Item("E4").Value, dateTime) Then
                Throw New Exception("Fecha incorrecta en celda E4.")
            Else
                vFechaLibro = oper.ConvertirCadenaFechaEnISO(Hoja.Item("E4").Value, cboFormatoFecha.Text)
            End If
        End If

        'Validar repeticion archivo
        If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) PuestoBolsaCodigo FROM [dbo].[Subasta] WHERE PuestoBolsaCodigo ='" + vPuestoBolsaCodigo + "' AND CONVERT(VARCHAR(10),[Fecha],121)='" & vFechaLibro & "' AND TipoLibroOrdenes='" & vTipoLibroOrdenes & "' AND Bono='" & vCodigoSerie & "') BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 1 Then
            chkSobrescribirArchivo.Enabled = True
            If chkSobrescribirArchivo.Checked = False And pValidarLOIG = False Then
                Throw New Exception("Debe seleccionar Sobrescribir archivo libro de ordenes para guadar un archivo que ya existe en el sistema.")
            ElseIf chkSobrescribirArchivo.Checked = True And pValidarLOIG = False Then
                If Not SobrescribirLibroOrdenes(vPuestoBolsaCodigo, vFechaLibro, vTipoLibroOrdenes, vCodigoSerie) Then
                    Throw New Exception("Error al sobrescribir el libro de ordenes.")
                Else
                    chkSobrescribirArchivo.Checked = False
                    chkSobrescribirArchivo.Enabled = False
                End If
            ElseIf chkSobrescribirArchivo.Checked = False Then
                Mensaje.ForeColor = Color.Red
                Mensaje.Text = "El archivo con el puesto de bolsa " & vPuestoBolsaCodigo & ", fecha " & Hoja.Item("E4").Value.ToString() & ", tipo libro ordenes " & vTipoLibroOrdenes & " y emisión " & vCodigoSerie & " ya existe."
                Mensaje.Text += "<br><span style='color:Blue'> Puede sobrescribir la información seleccionando la opción: Sobrescribir archivo libro de ordenes.</span>"
            End If
        End If

        If pValidarLOIG Then
            oper.ExecuteNonQuery("truncate table tmpValidarSubasta")
        End If

        If cboTipoBono.SelectedValue = "Emision" Then
            ' Determinar la tasa, moneda,fechainiciocolocacion y limite maximo
            ViewState("Tasa") = oper.ExecuteScalar("SELECT Tasa FROM [dbo].[vEmisionSerie] WHERE CodigoSerie ='" + vCodigoSerie + "'")
            ViewState("Moneda") = oper.ExecuteScalar("SELECT Moneda FROM [dbo].[vConsultaEmisiones] WHERE Nemotecnico ='" + vCodigoSerie + "'")

            If cboTipoLibroOrdenes.SelectedValue.Trim() = "LOIG" Then
                Dim Sql As String = "SELECT TOP(1) ValorNominalUnitarioSerie,InversionMaximaIG,FechaInicioColocacion AS FechaInicio,dateadd(day,ISNULL(DiasInversionMaximaIG,0)-1,FechaInicioColocacion) AS FechaFinal  FROM [dbo].[vConsultaEmisiones] WHERE Nemotecnico ='" + vCodigoSerie + "' AND ISNULL(DiasInversionMaximaIG,0)>0 AND FechaInicioColocacion<= CONVERT(DATETIME,  '" & vFechaLibro & "', 102)  AND DATEADD(DAY,ISNULL(DiasInversionMaximaIG,0)-1,FechaInicioColocacion) >=CONVERT(DATETIME,  '" & vFechaLibro & "', 102) "
                Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                Cnx.Open()
                Dim cmd As New SqlCommand(Sql, Cnx)

                Dim dt As DataTable = New DataTable
                dt.Load(cmd.ExecuteReader())
                If dt.Rows.Count > 0 Then
                    ViewState("LimiteMinimoValorUnitarioNominal") = dt.Rows(0).Item("ValorNominalUnitarioSerie")
                    ViewState("LimiteMaximoIG") = dt.Rows(0).Item("InversionMaximaIG")
                Else
                    ViewState("NoValidarLimiteInversionLOIG") = 1
                    Mensaje.ForeColor = Color.Blue
                    Mensaje.Text += "<br>Nota: no hay limites registrados para LOIG"
                End If

            End If

            If ViewState("Tasa").ToString().Trim().Length <= 0 Then
                Throw New Exception("Na hay tasa registrada.")
            End If
            If ViewState("Moneda").ToString().Trim().Length <= 0 Then
                Throw New Exception("Na hay moneda registrada.")
            End If
        End If

        Dim LineasGuardadas As Integer = 0
        Dim LineasNoGuardadas As Integer = 0

        Dim vContador As Integer = 1
        For i As Integer = 9 To Hoja.UsedRangeRows.Count
            If Hoja.Item("A" & i.ToString()).FormulaResultText <> "" Then
                Dim vBono As String = String.Empty
                Dim vMonto As Decimal = 0.0
                Dim vNotaMonto As String = String.Empty
                Dim vCant_Tit As Integer = 0.0
                Dim vPrecio As Decimal = 0.0
                Dim vValorTransado As Decimal = 0.0
                Dim vOrdenNo As Integer = 0
                Dim vFechaLinea As String = String.Empty
                Dim vHora As String = String.Empty
                Dim vRNT As String = String.Empty
                Dim vNoRegistroLibro As String = String.Empty
                Dim vTipoBono As String = String.Empty
                Dim vParcialTotal As String = String.Empty
                Dim vOrdenPropiaTerceros As String = String.Empty

                'Bono
                vBono = Hoja.Item("A" & i.ToString()).FormulaResultText

                'Monto
                If Hoja.Item("B" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. No requiere formula en celda B" & i.ToString())
                ElseIf Hoja.Item("B" & i.ToString()).NumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda B" & i.ToString())
                Else
                    vMonto = Hoja.Item("B" & i.ToString()).NumberValue
                End If

                'Nota Monto
                If Not Hoja.Item("C" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda C" & i.ToString())
                Else
                    vNotaMonto = Hoja.Item("C" & i.ToString()).FormulaResultText
                End If

                'Cantidad Titulos
                If Not Hoja.Item("D" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda D" & i.ToString())
                ElseIf Hoja.Item("D" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda D" & i.ToString())
                Else
                    vCant_Tit = Hoja.Item("D" & i.ToString()).FormulaResultNumberValue
                End If

                'Precio
                If Not Hoja.Item("E" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda E" & i.ToString())
                ElseIf Hoja.Item("E" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda E" & i.ToString())
                Else
                    vPrecio = Hoja.Item("E" & i.ToString()).FormulaResultNumberValue
                End If

                'Valor transado
                If Not Hoja.Item("F" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda F" & i.ToString())
                ElseIf Hoja.Item("F" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda F" & i.ToString())
                Else
                    vValorTransado = Hoja.Item("F" & i.ToString()).FormulaResultNumberValue
                End If

                'Orden numero
                If Not Hoja.Item("G" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda G" & i.ToString())
                ElseIf Hoja.Item("G" & i.ToString()).FormulaResultNumberValue <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Valor incorrecto en celda G" & i.ToString())
                Else
                    vOrdenNo = Hoja.Item("G" & i.ToString()).FormulaResultNumberValue
                End If

                'Fecha linea
                If Not Hoja.Item("H" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. Requiere formula en celda H" & i.ToString())
                Else
                    'Validamos que sea una fecha correcta
                    Dim dateTime1 As Date
                    If Not Date.TryParse(Hoja.Item("H" & i.ToString()).FormulaResultValue, dateTime1) Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda H" & i.ToString())
                    Else
                        vFechaLinea = oper.ConvertirCadenaFechaEnISO(Hoja.Item("H" & i.ToString()).FormulaResultValue, cboFormatoFecha.Text)
                    End If
                End If
                'Hora
                Try
                    If Hoja.Item("I" & i.ToString()).Value.ToString().Length > 0 Then
                        Dim Fecha1 As DateTime = DateTime.Parse(Hoja.Item("I" & i.ToString()).Value)
                        vHora = Fecha1.ToString("hh:mm:ss tt")
                    Else
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Valor Esta vacia la celda I" & i.ToString() & "Favor digitar  =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())
                    End If
                Catch ex As Exception
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error.Valor Incorrecto en la celda I" & i.ToString() & "Favor digitar  =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())

                End Try
                'Rnt
                If Hoja.Item("J" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. No requiere formula en celda J" & i.ToString())
                ElseIf Hoja.Item("J" & i.ToString()).Value.ToString().Trim().Length <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. La celda J" & i.ToString() & " esta vacia.")
                Else
                    vRNT = Hoja.Item("J" & i.ToString()).Value
                End If
                'Registro libro
                vNoRegistroLibro = Hoja.Item("K" & i.ToString()).Value
                'Tipo bono emision o programa emisiones
                vTipoBono = cboTipoBono.SelectedValue()
                'Parcial o total
                If Hoja.Item("L" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. No requiere formula en celda L" & i.ToString())
                ElseIf Hoja.Item("L" & i.ToString()).Value.ToString().Trim().Length <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. La celda L" & i.ToString() & " esta vacia.")
                Else
                    vParcialTotal = Hoja.Item("L" & i.ToString()).Value
                End If
                'Orden Propia Terceros
                If Hoja.Item("M" & i.ToString()).IsFormula Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. No requiere formula en celda M" & i.ToString())
                ElseIf Hoja.Item("M" & i.ToString()).Value.ToString().Trim().Length <= 0 Then
                    ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                 vContador.ToString, "X", "Error. La celda M" & i.ToString() & " esta vacia.")
                Else
                    vOrdenPropiaTerceros = Hoja.Item("M" & i.ToString()).Value
                End If

                Dim dtablaOrden As New DataTable()
                dtablaOrden.Columns.Add("PuestoBolsaCodigo", GetType(String))
                dtablaOrden.Columns.Add("Fecha", GetType(String))
                dtablaOrden.Columns.Add("Bono", GetType(String))
                dtablaOrden.Columns.Add("Monto", GetType(String))
                dtablaOrden.Columns.Add("CodigoISIN", GetType(String))
                dtablaOrden.Columns.Add("Cant_Tit", GetType(String))
                dtablaOrden.Columns.Add("Precio", GetType(String))
                dtablaOrden.Columns.Add("ValorTransado", GetType(String))
                dtablaOrden.Columns.Add("OrdenNo", GetType(String))
                dtablaOrden.Columns.Add("FechaLinea", GetType(String))
                dtablaOrden.Columns.Add("Hora", GetType(String))
                dtablaOrden.Columns.Add("RNT", GetType(String))
                dtablaOrden.Columns.Add("NoRegistroLibro", GetType(String))
                dtablaOrden.Columns.Add("TipoLibroOrdenes", GetType(String))
                dtablaOrden.Columns.Add("TipoBono", GetType(String))
                dtablaOrden.Columns.Add("ParcialTotal", GetType(String))
                dtablaOrden.Columns.Add("OrdenPropiaTerceros", GetType(String))

                dtablaOrden.Rows.Add(Hoja.Item("H5").FormulaResultText,
                                     Hoja.Item("E4").DateTimeValue,
                                     Hoja.Item("A" & i.ToString()).FormulaResultText,
                                     Hoja.Item("B" & i.ToString()).NumberValue,
                                     Hoja.Item("C" & i.ToString()).FormulaResultText,
                                     Hoja.Item("D" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("E" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("F" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("G" & i.ToString()).FormulaResultNumberValue,
                                     Hoja.Item("H" & i.ToString()).FormulaResultDateTimeValue,
                                     vHora,
                                     Hoja.Item("J" & i.ToString()).Value,
                                     Hoja.Item("K" & i.ToString()).Value,
                                     Hoja.Item("E2").Value,
                                     cboTipoBono.SelectedValue(),
                                     Hoja.Item("L" & i.ToString()).Value,
                                     Hoja.Item("M" & i.ToString()).Value)

                dtable.Rows.Add(Hoja.Item("H5").FormulaResultText,
                                Hoja.Item("E4").DateTimeValue,
                                Hoja.Item("A" & i.ToString()).FormulaResultText,
                                Hoja.Item("B" & i.ToString()).NumberValue,
                                Hoja.Item("C" & i.ToString()).FormulaResultText,
                                Hoja.Item("D" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("E" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("F" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("G" & i.ToString()).FormulaResultNumberValue,
                                Hoja.Item("H" & i.ToString()).FormulaResultDateTimeValue,
                                vHora,
                                Hoja.Item("J" & i.ToString()).Value,
                                Hoja.Item("K" & i.ToString()).Value,
                                Hoja.Item("E2").Value,
                                cboTipoBono.SelectedValue(),
                                Hoja.Item("L" & i.ToString()).Value,
                                Hoja.Item("M" & i.ToString()).Value)
                'Retorno mayor que cero existe error
                If RegistrarOrdenLOIG(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, vContador, dtablaOrden, pValidarLOIG) Then
                    'Error
                    LineasGuardadas += 1
                Else
                    LineasNoGuardadas += 1
                End If
                vContador = vContador + 1
            End If
        Next

        If LineasGuardadas > 0 And pValidarLOIG = False Then

            STools.InsertarInformacionArchivo(ViewState("FileName"), LineasGuardadas, LineasNoGuardadas, FileType)
            rgListaArchivosCargados.Rebind()
        End If

        'Mostramos el resultado de la validación
        lblResultadoValidacion.Text = String.Empty
        lblResultadoValidacion.ForeColor = Color.Blue

        If LineasNoGuardadas = 0 Then
            If pValidarLOIG Then
                'Si es validar
                lblResultadoValidacion.Text = "Se ha validado con éxito el archivo : " & vNombreLibro
                'lblResultadoValidacion.Text += "</br> Cantidad de líneas válidas para guardar:  " & (vContador - 1)
            Else
                lblResultadoValidacion.Text = "Se cargo con éxito el archivo : " & vNombreLibro & "</br> Cantidad de líneas guardadas:  " & (vContador - 1)
            End If
            lblResultadoValidacion.Text += "</br></br> Mensaje validación:</br> "
        Else
            If pValidarLOIG Then
                'Si es validar
                lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro
                'lblResultadoValidacion.Text += " </br>Líneas válidas para guardar  " & LineasGuardadas.ToString & " de un total de " & (vContador - 1) & ".</span>"
            Else
                lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro & " Se guardaron  " & LineasGuardadas.ToString & " líneas de un total de " & (vContador - 1) & ".</span>"
            End If
            lblResultadoValidacion.Text += "</br></br> Mensaje validación: </br>"
        End If

        For Each rvRow In ResultadoValidacion.Rows
            If rvRow("Estado").ToString() = "X" Then
                lblResultadoValidacion.Text += "<span style='color:Red'>Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "</span><br>"

            Else
                lblResultadoValidacion.Text += "Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "<br>"
            End If
        Next

        'Mostramos la moneda en pantalla
        lblTipoMoneda.Text = "Tipo Moneda: " + ViewState("Moneda").ToString()

        'Mostramos los limites en pantalla
        If cboTipoLibroOrdenes.SelectedValue = "LOIG" Then
            If (ViewState("NoValidarLimiteInversionLOIG") = 0) Then
                lblLimiteInversionMinimo.Text = " "
                lblLimiteInversionMaximo.Text = "Límite de Inversión máximo: IG: " + ViewState("LimiteMaximoIG").ToString()
            End If

        End If
    End Sub

    Private Sub ProcesarLibroOrdenesLOIG_More2007(lFormatoBritanico As Boolean, ByVal pValidarLOIG As Boolean)
        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        'Para almacenar todas laas lineas de los libros
        dtable.Columns.Add("PuestoBolsaCodigo", GetType(String))
        dtable.Columns.Add("Fecha", GetType(String))
        dtable.Columns.Add("Bono", GetType(String))
        dtable.Columns.Add("Monto", GetType(Decimal))
        dtable.Columns.Add("CodigoISIN", GetType(String))
        dtable.Columns.Add("Cant_Tit", GetType(Integer))
        dtable.Columns.Add("Precio", GetType(Decimal))
        dtable.Columns.Add("ValorTransado", GetType(Decimal))
        dtable.Columns.Add("OrdenNo", GetType(Integer))
        dtable.Columns.Add("FechaLinea", GetType(String))
        dtable.Columns.Add("Hora", GetType(String))
        dtable.Columns.Add("RNT", GetType(String))
        dtable.Columns.Add("NoRegistroLibro", GetType(String))
        dtable.Columns.Add("TipoLibroOrdenes", GetType(String))
        dtable.Columns.Add("TipoBono", GetType(String))
        dtable.Columns.Add("ParcialTotal", GetType(String))
        dtable.Columns.Add("OrdenPropiaTerceros", GetType(String))

        'Establecemos los campos de la tabla resultado de la validacion
        ResultadoValidacion.Columns.Add("NombreArchivo", GetType(String))
        ResultadoValidacion.Columns.Add("PuestoBolsaCodigo", GetType(String))
        ResultadoValidacion.Columns.Add("TipoLibroOrdenes", GetType(String))
        ResultadoValidacion.Columns.Add("Fecha", GetType(String))
        ResultadoValidacion.Columns.Add("MontoValido", GetType(Decimal))
        ResultadoValidacion.Columns.Add("LineaNumero", GetType(Integer))
        ResultadoValidacion.Columns.Add("Estado", GetType(String))
        ResultadoValidacion.Columns.Add("Condicion", GetType(String))

        Dim testDocFile As String = Nothing
        testDocFile = System.IO.Path.Combine(Server.MapPath("~/tmp/"), ViewState("FileName"))

        Dim workBook As FileInfo = New FileInfo(testDocFile)
        Using excel = New ExcelPackage(workBook)
            Dim ws As ExcelWorksheet = excel.Workbook.Worksheets.First()

            'Variables generales
            Dim vPuestoBolsaCodigo As String = String.Empty
            Dim vNombreLibro As String = ViewState("FileName").ToString()
            Dim vFechaLibro As String = String.Empty
            Dim vTipoLibroOrdenes As String = String.Empty
            Dim vCodigoSerie As String = String.Empty

            'Bono
            If ws.Cells("A9").Formula.Length <= 0 Then
                ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                             1, "X", "Error. Requiere formula en celda A9")
            ElseIf ws.Cells("A9").Text.Trim().Length <= 0 Then
                ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                             1, "X", "Error. Esta vacia la celda A9")
            Else
                vCodigoSerie = ws.Cells("A9").Value
            End If

            If ws.Cells("E2").Text.Trim().Length <= 0 Then
                Throw New Exception("Error la celda E2 esta vacia.")
            ElseIf ws.Cells("E2").Value <> cboTipoLibroOrdenes.SelectedValue.Trim() Then
                Throw New Exception("El archivo no coincide con el tipo de libro de ordenes seleccionado")
            Else
                vTipoLibroOrdenes = ws.Cells("E2").Value
            End If

            If ws.Cells("H5").Text.Trim().Length <= 0 Then
                Throw New Exception("El codigo de puesto de bolsa esta vacio. Ver H5")
            Else
                vPuestoBolsaCodigo = ws.Cells("H5").Value
            End If

            'El campo fecha debe ser ingresado manualmente en el formato ddmmaaaa
            If ws.Cells("E4").Formula.Length > 0 Then
                Throw New Exception("El valor de la celda E4 NO debe ser resultado de una formula. Por favor digite el valor.")
            Else
                'Validamos que sea una fecha correcta
                Dim dateTime As Date
                If Not Date.TryParse(ws.Cells("E4").Text, dateTime) Then
                    Throw New Exception("Fecha incorrecta en celda E4.")
                Else
                    vFechaLibro = ws.Cells("E4").Text 'oper.ConvertirCadenaFechaEnISO(ws.Cells("E4").Value, cboFormatoFecha.Text)
                End If
            End If

            'Validar repeticion archivo
            If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) PuestoBolsaCodigo FROM [dbo].[Subasta] WHERE PuestoBolsaCodigo ='" + vPuestoBolsaCodigo + "' AND CONVERT(VARCHAR(10),[Fecha],121)='" & vFechaLibro & "' AND TipoLibroOrdenes='" & vTipoLibroOrdenes & "' AND Bono='" & vCodigoSerie & "') BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 1 Then
                chkSobrescribirArchivo.Enabled = True
                If chkSobrescribirArchivo.Checked = False And pValidarLOIG = False Then
                    Throw New Exception("Debe seleccionar Sobrescribir archivo libro de ordenes para guadar un archivo que ya existe en el sistema.")
                ElseIf chkSobrescribirArchivo.Checked = True And pValidarLOIG = False Then
                    If Not SobrescribirLibroOrdenes(vPuestoBolsaCodigo, vFechaLibro, vTipoLibroOrdenes, vCodigoSerie) Then
                        Throw New Exception("Error al sobrescribir el libro de ordenes.")
                    Else
                        chkSobrescribirArchivo.Checked = False
                        chkSobrescribirArchivo.Enabled = False
                    End If
                ElseIf chkSobrescribirArchivo.Checked = False Then
                    Mensaje.ForeColor = Color.Red
                    Mensaje.Text = "El archivo con el puesto de bolsa " & vPuestoBolsaCodigo & ", fecha " & ws.Cells("E4").Value.ToString() & ", tipo libro ordenes " & vTipoLibroOrdenes & " y emisión " & vCodigoSerie & " ya existe."
                    Mensaje.Text += "<br><span style='color:Blue'> Puede sobrescribir la información seleccionando la opción: Sobrescribir archivo libro de ordenes.</span>"
                End If
            End If

            If pValidarLOIG Then
                oper.ExecuteNonQuery("truncate table tmpValidarSubasta")
            End If

            If cboTipoBono.SelectedValue = "Emision" Then
                ' Determinar la tasa, moneda,fechainiciocolocacion y limite maximo
                ViewState("Tasa") = oper.ExecuteScalar("SELECT Tasa FROM [dbo].[vEmisionSerie] WHERE CodigoSerie ='" + vCodigoSerie + "'")
                ViewState("Moneda") = oper.ExecuteScalar("SELECT Moneda FROM [dbo].[vConsultaEmisiones] WHERE Nemotecnico ='" + vCodigoSerie + "'")

                If cboTipoLibroOrdenes.SelectedValue.Trim() = "LOIG" Then
                    Dim Sql As String = "SELECT TOP(1) ValorNominalUnitarioSerie,InversionMaximaIG,FechaInicioColocacion AS FechaInicio,dateadd(day,ISNULL(DiasInversionMaximaIG,0)-1,FechaInicioColocacion) AS FechaFinal  FROM [dbo].[vConsultaEmisiones] WHERE Nemotecnico ='" + vCodigoSerie + "' AND ISNULL(DiasInversionMaximaIG,0)>0 AND FechaInicioColocacion<= CONVERT(DATETIME,  '" & vFechaLibro & "', 102)  AND DATEADD(DAY,ISNULL(DiasInversionMaximaIG,0)-1,FechaInicioColocacion) >=CONVERT(DATETIME,  '" & vFechaLibro & "', 102) "
                    Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                    Cnx.Open()
                    Dim cmd As New SqlCommand(Sql, Cnx)

                    Dim dt As DataTable = New DataTable
                    dt.Load(cmd.ExecuteReader())
                    If dt.Rows.Count > 0 Then
                        ViewState("LimiteMinimoValorUnitarioNominal") = dt.Rows(0).Item("ValorNominalUnitarioSerie")
                        ViewState("LimiteMaximoIG") = dt.Rows(0).Item("InversionMaximaIG")
                    Else
                        ViewState("NoValidarLimiteInversionLOIG") = 1
                        Mensaje.ForeColor = Color.Blue
                        Mensaje.Text += "<br>Nota: no hay limites registrados para LOIG"
                    End If

                End If

                If ViewState("Tasa").ToString().Trim().Length <= 0 Then
                    Throw New Exception("Na hay tasa registrada.")
                End If
                If ViewState("Moneda").ToString().Trim().Length <= 0 Then
                    Throw New Exception("Na hay moneda registrada.")
                End If
            End If

            Dim LineasGuardadas As Integer = 0
            Dim LineasNoGuardadas As Integer = 0

            Dim vContador As Integer = 1

            Dim InicioLinea As Integer = 9
            Dim FilasNoVacias As Integer = GetLastUsedRow(ws, InicioLinea)

            For i As Integer = 9 To FilasNoVacias
                If ws.Cells("A" & i.ToString()).Value <> "" Then
                    Dim vBono As String = String.Empty
                    Dim vMonto As Decimal = 0.0
                    Dim vNotaMonto As String = String.Empty
                    Dim vCant_Tit As Integer = 0.0
                    Dim vPrecio As Decimal = 0.0
                    Dim vValorTransado As Decimal = 0.0
                    Dim vOrdenNo As Integer = 0
                    Dim vFechaLinea As String = String.Empty
                    Dim vHora As String = String.Empty
                    Dim vRNT As String = String.Empty
                    Dim vNoRegistroLibro As String = String.Empty
                    Dim vTipoBono As String = String.Empty
                    Dim vParcialTotal As String = String.Empty
                    Dim vOrdenPropiaTerceros As String = String.Empty

                    'Bono
                    vBono = ws.Cells("A" & i.ToString()).Value

                    'Monto
                    If ws.Cells("B" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda B" & i.ToString())
                    ElseIf ws.Cells("B" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda B" & i.ToString())
                    ElseIf Val(ws.Cells("B" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en la celda B" & i.ToString())
                    Else
                        vMonto = ws.Cells("B" & i.ToString()).Text
                    End If

                    'Nota Monto
                    If ws.Cells("C" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda C" & i.ToString())
                    Else
                        vNotaMonto = ws.Cells("C" & i.ToString()).Value
                    End If

                    'Cantidad Titulos 
                    If ws.Cells("D" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda D" & i.ToString())
                    ElseIf ws.Cells("D" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda D" & i.ToString())
                    ElseIf Val(ws.Cells("D" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda D" & i.ToString())
                    Else
                        vCant_Tit = ws.Cells("D" & i.ToString()).Value
                    End If

                    'Precio
                    If ws.Cells("E" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda E" & i.ToString())
                    ElseIf ws.Cells("E" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda E" & i.ToString())
                    ElseIf Val(ws.Cells("E" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda E" & i.ToString())
                    Else
                        vPrecio = ws.Cells("E" & i.ToString()).Value
                    End If

                    'Valor transado
                    If ws.Cells("F" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda F" & i.ToString())
                    ElseIf ws.Cells("F" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Esta vacia la celda F" & i.ToString())
                    ElseIf ws.Cells("F" & i.ToString()).Value <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda F" & i.ToString())
                    Else
                        vValorTransado = ws.Cells("F" & i.ToString()).Value
                    End If

                    'Orden numero
                    If ws.Cells("G" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda G" & i.ToString())
                    ElseIf ws.Cells("G" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda G" & i.ToString())
                    ElseIf Val(ws.Cells("G" & i.ToString()).Value) <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Valor incorrecto en celda G" & i.ToString())
                    Else
                        vOrdenNo = ws.Cells("G" & i.ToString()).Value
                    End If

                    'Fecha linea
                    If ws.Cells("H" & i.ToString()).Formula.Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Requiere formula en celda H" & i.ToString())
                    Else
                        'Validamos que sea una fecha correcta
                        Dim dateTime1 As Date
                        If Not Date.TryParse(ws.Cells("H" & i.ToString()).Value, dateTime1) Then
                            ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                         vContador.ToString, "X", "Error. Valor incorrecto en celda H" & i.ToString())
                        Else
                            vFechaLinea = ws.Cells("H" & i.ToString()).Value 'oper.ConvertirCadenaFechaEnISO(ws.Cells("H" & i.ToString()).FormulaResultValue, cboFormatoFecha.Text)
                        End If
                    End If
                    'Hora

                    If ws.Cells("I" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Requiere formula. Favor digitar =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())
                    ElseIf ws.Cells("I" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda I" & i.ToString())
                    End If

                    Try
                        If Convert.ToDecimal(ws.Cells("I" & i.ToString()).Value) > 0 Then
                            Dim Fecha1 As DateTime = DateTime.FromOADate(Convert.ToDouble(ws.Cells("I" & i.ToString()).Value))
                            vHora = Fecha1.ToString("hh:mm:ss tt")
                        End If
                    Catch ex As Exception
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error.Valor Incorrecto en la celda I" & i.ToString() & "Favor digitar  =Ahora() y luego presionar F9. Valor incorrecto en celda I" & i.ToString())
                    End Try

                    'Rnt
                    If ws.Cells("J" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda J" & i.ToString())
                    ElseIf ws.Cells("J" & i.ToString()).Text.ToString().Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. La celda J" & i.ToString() & " esta vacia.")
                    Else
                        vRNT = ws.Cells("J" & i.ToString()).Text
                    End If
                    'Registro libro

                    If ws.Cells("K" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda K" & i.ToString())
                    ElseIf ws.Cells("K" & i.ToString()).Text.Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. Esta vacia la celda K" & i.ToString())
                    Else
                        vNoRegistroLibro = ws.Cells("K" & i.ToString()).Text
                    End If

                    'Tipo bono emision o programa emisiones
                    vTipoBono = cboTipoBono.SelectedValue()
                    'Parcial o total
                    If ws.Cells("L" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda L" & i.ToString())
                    ElseIf ws.Cells("L" & i.ToString()).Text.ToString().Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. La celda L" & i.ToString() & " esta vacia.")
                    Else
                        vParcialTotal = ws.Cells("L" & i.ToString()).Text
                    End If
                    'Orden Propia Terceros
                    If ws.Cells("M" & i.ToString()).Formula.Length > 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. No requiere formula en celda M" & i.ToString())
                    ElseIf ws.Cells("M" & i.ToString()).Text.ToString().Trim().Length <= 0 Then
                        ResultadoValidacion.Rows.Add(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, 0,
                                                     vContador.ToString, "X", "Error. La celda M" & i.ToString() & " esta vacia.")
                    Else
                        vOrdenPropiaTerceros = ws.Cells("M" & i.ToString()).Text
                    End If

                    Dim dtablaOrden As New DataTable()
                    dtablaOrden.Columns.Add("PuestoBolsaCodigo", GetType(String))
                    dtablaOrden.Columns.Add("Fecha", GetType(String))
                    dtablaOrden.Columns.Add("Bono", GetType(String))
                    dtablaOrden.Columns.Add("Monto", GetType(Decimal))
                    dtablaOrden.Columns.Add("CodigoISIN", GetType(String))
                    dtablaOrden.Columns.Add("Cant_Tit", GetType(Integer))
                    dtablaOrden.Columns.Add("Precio", GetType(Decimal))
                    dtablaOrden.Columns.Add("ValorTransado", GetType(Decimal))
                    dtablaOrden.Columns.Add("OrdenNo", GetType(Integer))
                    dtablaOrden.Columns.Add("FechaLinea", GetType(String))
                    dtablaOrden.Columns.Add("Hora", GetType(String))
                    dtablaOrden.Columns.Add("RNT", GetType(String))
                    dtablaOrden.Columns.Add("NoRegistroLibro", GetType(String))
                    dtablaOrden.Columns.Add("TipoLibroOrdenes", GetType(String))
                    dtablaOrden.Columns.Add("TipoBono", GetType(String))
                    dtablaOrden.Columns.Add("ParcialTotal", GetType(String))
                    dtablaOrden.Columns.Add("OrdenPropiaTerceros", GetType(String))

                    dtablaOrden.Rows.Add(ws.Cells("H5").Value,
                                         ws.Cells("E4").Value,
                                         ws.Cells("A" & i.ToString()).Value,
                                         ws.Cells("B" & i.ToString()).Text,
                                         ws.Cells("C" & i.ToString()).Value,
                                         ws.Cells("D" & i.ToString()).Value,
                                         ws.Cells("E" & i.ToString()).Value,
                                         ws.Cells("F" & i.ToString()).Value,
                                         ws.Cells("G" & i.ToString()).Value,
                                         ws.Cells("H" & i.ToString()).Value,
                                         vHora,
                                         ws.Cells("J" & i.ToString()).Text,
                                         ws.Cells("K" & i.ToString()).Text,
                                         ws.Cells("E2").Value,
                                         cboTipoBono.SelectedValue(),
                                         ws.Cells("L" & i.ToString()).Text,
                                         ws.Cells("M" & i.ToString()).Text)

                    dtable.Rows.Add(ws.Cells("H5").Value,
                                    ws.Cells("E4").Value,
                                    ws.Cells("A" & i.ToString()).Value,
                                    ws.Cells("B" & i.ToString()).Text,
                                    ws.Cells("C" & i.ToString()).Value,
                                    ws.Cells("D" & i.ToString()).Value,
                                    ws.Cells("E" & i.ToString()).Value,
                                    ws.Cells("F" & i.ToString()).Value,
                                    ws.Cells("G" & i.ToString()).Value,
                                    ws.Cells("H" & i.ToString()).Value,
                                    vHora,
                                    ws.Cells("J" & i.ToString()).Text,
                                    ws.Cells("K" & i.ToString()).Text,
                                    ws.Cells("E2").Value,
                                    cboTipoBono.SelectedValue(),
                                    ws.Cells("L" & i.ToString()).Text,
                                    ws.Cells("M" & i.ToString()).Text)
                    'Retorno mayor que cero existe error
                    If RegistrarOrdenLOIG(vNombreLibro, vPuestoBolsaCodigo, vTipoLibroOrdenes, vFechaLibro, vContador, dtablaOrden, pValidarLOIG) Then
                        'Error
                        LineasGuardadas += 1
                    Else
                        LineasNoGuardadas += 1
                    End If
                    vContador = vContador + 1
                Else
                    Exit For
                End If
            Next

            If LineasGuardadas > 0 And pValidarLOIG = False Then
                STools.InsertarInformacionArchivo(ViewState("FileName"), LineasGuardadas, LineasNoGuardadas, FileType)

                rgListaArchivosCargados.Rebind()
            End If

            'Mostramos el resultado de la validación
            lblResultadoValidacion.Text = String.Empty
            lblResultadoValidacion.ForeColor = Color.Blue

            If LineasNoGuardadas = 0 Then
                If pValidarLOIG Then
                    'Si es validar
                    lblResultadoValidacion.Text = "Se ha validado con éxito el archivo : " & vNombreLibro
                    lblResultadoValidacion.Text += "</br> Cantidad de líneas posiblemente válidas para guardar:  " & (vContador - 1)
                Else
                    lblResultadoValidacion.Text = "Se cargo con éxito el archivo : " & vNombreLibro & "</br> Cantidad de líneas guardadas:  " & (vContador - 1)
                End If
                lblResultadoValidacion.Text += "</br></br> Mensaje validación:</br> "
            Else
                If pValidarLOIG Then
                    'Si es validar
                    lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro
                    lblResultadoValidacion.Text += " </br>Líneas posiblemente válidas para guardar  " & LineasGuardadas.ToString & " de un total de " & (vContador - 1) & ".</span>"
                Else
                    lblResultadoValidacion.Text = "<span style ='color:green'>Se proceso el archivo: " & vNombreLibro & " Se guardaron  " & LineasGuardadas.ToString & " líneas de un total de " & (vContador - 1) & ".</span>"
                End If
                lblResultadoValidacion.Text += "</br></br> Mensaje validación: </br>"
            End If

            For Each rvRow In ResultadoValidacion.Rows
                If rvRow("Estado").ToString() = "X" Then
                    lblResultadoValidacion.Text += "<span style='color:Red'>Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "</span><br>"

                Else
                    lblResultadoValidacion.Text += "Línea No. " + rvRow("LineaNumero").ToString + ", Monto Válido: " + rvRow("MontoValido").ToString + ", Condición: " + rvRow("Condicion").ToString + "<br>"
                End If
            Next

            'Mostramos la moneda en pantalla 
            lblTipoMoneda.Text = "Tipo Moneda: " + ViewState("Moneda").ToString()

            'Mostramos los limites en pantalla
            If cboTipoLibroOrdenes.SelectedValue = "LOIG" Then
                If (ViewState("NoValidarLimiteInversionLOIG") = 0) Then
                    lblLimiteInversionMinimo.Text = " "
                    lblLimiteInversionMaximo.Text = "Límite de Inversión máximo: IG: " + ViewState("LimiteMaximoIG").ToString()
                End If

            End If

        End Using

    End Sub
    Function RegistrarOrdenLOIG(ByVal pNombreLibro, ByVal pPuestoBolsaCodigo, ByVal pTipoLibroOrdenes, ByVal pFechaLibro, ByVal pLineaNumero, ByVal pdtablaOrden, ByVal pValidarLOIG) As Boolean
        Dim vRetorno As Boolean = False
        Dim stringFechaHora As String = ""
        Dim vMontoValido As Decimal = 0.0

        Dim Sql As String = ""
        If (pValidarLOIG) Then
            Sql = "INSERT INTO [tmpValidarSubasta] ([PuestoBolsaCodigo] ,[Fecha] ,[Bono] ,[Monto] ,[CodigoISIN] ,[Cant_Tit] ,[Precio] ,[ValorTransado] ,[OrdenNo] ,[FechaLinea] ,[Hora] ,[RNT] ,[NoRegistroLibro],[Estado],[Condicion],[TipoLibroOrdenes],[TipoBono], [ParcialTotal],[MontoValido],[OrdenPropiaTerceros]) VALUES (@PuestoBolsaCodigo, @Fecha,@Bono,@Monto,@CodigoISIN,@Cant_Tit,@Precio,@ValorTransado,@OrdenNo,@FechaLinea,@Hora,@RNT,@NoRegistroLibro,@Estado,@Condicion,@TipoLibroOrdenes, @TipoBono, @ParcialTotal,@MontoValido,@OrdenPropiaTerceros)"
        Else
            Sql = "INSERT INTO [Subasta] ([PuestoBolsaCodigo] ,[Fecha] ,[Bono] ,[Monto] ,[CodigoISIN] ,[Cant_Tit] ,[Precio] ,[ValorTransado] ,[OrdenNo] ,[FechaLinea] ,[Hora] ,[RNT] ,[NoRegistroLibro],[Estado],[Condicion],[TipoLibroOrdenes],[TipoBono], [ParcialTotal],[MontoValido],[OrdenPropiaTerceros]) VALUES (@PuestoBolsaCodigo, @Fecha,@Bono,@Monto,@CodigoISIN,@Cant_Tit,@Precio,@ValorTransado,@OrdenNo,@FechaLinea,@Hora,@RNT,@NoRegistroLibro,@Estado,@Condicion,@TipoLibroOrdenes, @TipoBono, @ParcialTotal,@MontoValido,@OrdenPropiaTerceros)"
        End If

        Dim ciNewFormat As New CultureInfo(CultureInfo.InvariantCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            For Each dRow In pdtablaOrden.Rows
                Try

                    cmd.Parameters.Clear()
                    cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCodigo", SqlDbType.Char)).Value = dRow(0)
                    If Not IsDBNull(dRow.Item(1)) Then
                        stringFechaHora = dRow.Item(1)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add(New SqlParameter("@Bono", SqlDbType.Char)).Value = dRow(2)
                    cmd.Parameters.Add(New SqlParameter("@Monto", SqlDbType.Decimal)).Value = Val(dRow(3))
                    vMontoValido = Val(dRow(3))
                    cmd.Parameters.Add(New SqlParameter("@CodigoISIN", SqlDbType.Char)).Value = IIf(dRow.Item(4) = "Monto Validado", "", dRow.Item(4))
                    cmd.Parameters.Add(New SqlParameter("@Cant_Tit", SqlDbType.Decimal)).Value = Val(dRow(5))
                    cmd.Parameters.Add(New SqlParameter("@Precio", SqlDbType.Decimal)).Value = Val(dRow(6))
                    cmd.Parameters.Add(New SqlParameter("@ValorTransado", SqlDbType.Decimal)).Value = Val(dRow(7))
                    cmd.Parameters.Add(New SqlParameter("@OrdenNo", SqlDbType.Decimal)).Value = Val(dRow(8))

                    If Not IsDBNull(dRow.Item(9)) Then
                        stringFechaHora = oper.ConvertirCadenaFechaEnISO(dRow.Item(9), cboFormatoFecha.Text)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = stringFechaHora
                        Catch ex As Exception
                            cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = DBNull.Value
                        End Try
                    Else
                        cmd.Parameters.Add(New SqlParameter("@FechaLinea", SqlDbType.DateTime)).Value = DBNull.Value
                    End If

                    cmd.Parameters.Add(New SqlParameter("@Hora", SqlDbType.Char)).Value = dRow(10)

                    cmd.Parameters.Add(New SqlParameter("@RNT", SqlDbType.Char)).Value = dRow(11)
                    cmd.Parameters.Add(New SqlParameter("@NoRegistroLibro", SqlDbType.Char)).Value = dRow(12)

                    Dim vCondicion As String = String.Empty

                    Dim vRetornoMontoTransado As ArrayList = ValidarMontoTransado(Val(dRow(3)), Val(dRow(7)))
                    If vRetornoMontoTransado(0) = "X" Then
                        vCondicion = vRetornoMontoTransado(1).ToString()
                        'Guardamos el mensaje de retorno del monto transado
                        ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                                     vMontoValido.ToString, pLineaNumero.ToString, vRetornoMontoTransado(0).ToString(), vRetornoMontoTransado(1).ToString)
                    End If

                    Dim vFecha As DateTime = DateTime.Parse(stringFechaHora)
                    Dim vRetornoLimiteMontoLOIG As ArrayList = ValidarLimiteMontoLOIG(cboTipoLibroOrdenes.SelectedValue, cboTipoBono.SelectedValue, dRow(2), dRow(11), dRow(3), dRow(15), vFecha, pValidarLOIG)
                    cmd.Parameters.Add(New SqlParameter("@Estado", SqlDbType.Char)).Value = vRetornoLimiteMontoLOIG(0)
                    cmd.Parameters.Add(New SqlParameter("@Condicion", SqlDbType.Char)).Value = vRetornoLimiteMontoLOIG(1).ToString() & " " & vCondicion
                    vMontoValido = Convert.ToDecimal(vRetornoLimiteMontoLOIG(2))
                    'Guardamos el mensaje de retorno de ValidarLimiteMontoLOIG
                    ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                                 vMontoValido.ToString, pLineaNumero.ToString, vRetornoLimiteMontoLOIG(0).ToString(), vRetornoLimiteMontoLOIG(1).ToString)
                    cmd.Parameters.Add(New SqlParameter("@TipoLibroOrdenes", SqlDbType.Char)).Value = cboTipoLibroOrdenes.SelectedValue
                    cmd.Parameters.Add(New SqlParameter("@TipoBono", SqlDbType.Char)).Value = cboTipoBono.SelectedValue
                    cmd.Parameters.Add(New SqlParameter("@ParcialTotal", SqlDbType.Char)).Value = dRow(15)
                    cmd.Parameters.Add(New SqlParameter("@MontoValido", SqlDbType.Decimal)).Value = vMontoValido
                    cmd.Parameters.Add(New SqlParameter("@OrdenPropiaTerceros", SqlDbType.Char)).Value = dRow(16)

                    Dim csql As String = oper.CovertirComandoATexto(cmd)
                    vRetorno = True
                    cmd.ExecuteNonQuery()
                Catch sql_ex As SqlClient.SqlException
                    ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                                 vMontoValido.ToString, pLineaNumero.ToString, "X", "Error Sql registro no guardado. " & sql_ex.Message)
                Catch ex As Exception
                    ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                                 vMontoValido.ToString, pLineaNumero.ToString, "X", "Registro no guardado. " & ex.Message)
                End Try

            Next
        Catch ex As Exception
            ResultadoValidacion.Rows.Add(pNombreLibro, pPuestoBolsaCodigo, pTipoLibroOrdenes, pFechaLibro,
                                         vMontoValido.ToString, pLineaNumero.ToString, "X", "Error al intentar guardar el registro. " & ex.Message)
        End Try
        Return vRetorno
    End Function

    Function ValidarLimiteMontoLOIG(ByVal pTipoLibroOrdenes, ByVal pTipoBono, ByVal pBono, ByVal pRNT, ByVal pMonto, ByVal pParcialTotal, ByVal pFechaOrden, ByRef pValidarLOIG) As ArrayList
        Dim Resultado As New ArrayList
        Dim vTotalRNT As Decimal = 0.0
        Dim vMontoEmision As Decimal = 0.0
        Dim vMontoAdjudicadoTotal As Decimal = 0.0
        Dim vTotalRNTSql As String = oper.ExecuteScalar("SELECT ISNULL(SUM(MontoValido),0) FROM dbo.Subasta WHERE TipoLibroOrdenes='" & pTipoLibroOrdenes & "' AND TipoBono='" & pTipoBono & "' AND Bono='" & pBono & "' AND RNT='" & pRNT & "' ")

        Dim vMontoAdjudicadoTotals As String = oper.ExecuteScalar("SELECT  SUM(valor_nom_tot) FROM dbo.OperacionesCSV WHERE nemo_ins='" + pBono + "' AND Mercado ='23'")
        Dim vMontoEmisionSql As String = Convert.ToDecimal(oper.ExecuteScalar("SELECT ValorUnitarioNominal FROM [dbo].[vEmisionSerie] WHERE CodigoSerie ='" + pBono + "'"))

        If vTotalRNTSql.Trim().Length > 0 Then
            vTotalRNT = Convert.ToDecimal(Val(vTotalRNTSql))
        End If
        Dim vTotalValidarRNT As Decimal = 0.0
        'Verificamos si la accion es validar o insertar para sumara el monto al rnt en caso de haber mas de un mismo rnt por documento

        If (pValidarLOIG) Then
            vTotalValidarRNT = oper.ExecuteScalar("SELECT ISNULL(SUM(MontoValido),0) FROM dbo.tmpValidarSubasta WHERE TipoLibroOrdenes='" & pTipoLibroOrdenes & "' AND TipoBono='" & pTipoBono & "' AND Bono='" & pBono & "' AND RNT='" & pRNT & "' ")

            vTotalRNT = vTotalRNT + vTotalValidarRNT
        End If

        If vMontoAdjudicadoTotals.Trim().Length >= 0 Then
            vMontoAdjudicadoTotal = Convert.ToDecimal(Val(vMontoAdjudicadoTotals))
        End If
        If vMontoEmisionSql.Trim().Length > 0 Then
            vMontoEmision = Convert.ToDecimal(Val(vMontoEmisionSql))
        End If
        vMontoEmision = vMontoEmision - vMontoAdjudicadoTotal


        If (ViewState("NoValidarLimiteInversionLOIG") = 0) Then
            If vTotalRNT < Val(ViewState("LimiteMaximoIG")) Then
                If (Val(ViewState("LimiteMaximoIG")) - vTotalRNT) < Val(ViewState("LimiteMinimoValorUnitarioNominal")) Then
                    Resultado.Add("X")
                    Resultado.Add("No válido. La diferencia para completar el límite máximo por RNT es menor que el límite mínimo.")
                    Resultado.Add(0)
                Else
                    If (Val(ViewState("LimiteMaximoIG")) - vTotalRNT) >= pMonto Then
                        Resultado.Add("V")
                        Resultado.Add("Válido") '1 Válido
                        Resultado.Add(pMonto)
                    ElseIf (Val(ViewState("LimiteMaximoIG")) - vTotalRNT) < pMonto Then
                        If pParcialTotal = "T" Then
                            Resultado.Add("X")
                            Resultado.Add("No válido. El monto excede el límite permitido por RNT")
                            Resultado.Add(Val(0))
                        ElseIf (Val(ViewState("LimiteMaximoIG")) - vTotalRNT) >= Val(ViewState("LimiteMinimoValorUnitarioNominal")) And pParcialTotal = "P" Then
                            Resultado.Add("V")
                            Resultado.Add("Válido. Se ha tomado el " & (Val(ViewState("LimiteMaximoIG")) - vTotalRNT).ToString() & " del " & pMonto & " demandado.")
                            Resultado.Add(Val(ViewState("LimiteMaximoIG")) - vTotalRNT)
                        End If
                    End If
                End If
            ElseIf vTotalRNT >= Val(ViewState("LimiteMaximoIG")) Then
                Resultado.Add("X")
                Resultado.Add("No válido. El monto permitido por RNT ya está completo.")
                Resultado.Add(Val(0))
            End If
        ElseIf vTotalRNT < vMontoEmision Then
            If (vMontoEmision - vTotalRNT) >= pMonto Then
                Resultado.Add("V")
                Resultado.Add("Válido") '1 Válido
                Resultado.Add(pMonto)
            ElseIf (vMontoEmision - vTotalRNT) < pMonto Then
                If pParcialTotal = "T" Then
                    Resultado.Add("X")
                    Resultado.Add("No válido. El monto excede el límite permitido por RNT")
                    Resultado.Add(Val(0))
                ElseIf pParcialTotal = "P" Then
                    Resultado.Add("V")
                    Resultado.Add("Válido. Se ha tomado el " & (vMontoEmision - vTotalRNT).ToString() & " del " & pMonto & " demandado.")
                    Resultado.Add(vMontoEmision - vTotalRNT)
                End If
            End If

        ElseIf vTotalRNT >= vMontoEmision Then
            Resultado.Add("X")
            Resultado.Add("No válido. El monto permitido por RNT ya está completo.")
            Resultado.Add(Val(0))
        End If
        Return Resultado
    End Function

    Function ValidarDuplicado(ByVal pRNT As String, ByVal pBono As String) As String
        Dim Resultado As String = String.Empty
        Dim Sql As String = ""
        Dim SqlRnt As String = ""

        If cboTipoBono.SelectedValue = "ProgramaEmisiones" Then
            SqlRnt = "IF EXISTS (SELECT RNT FROM dbo.Subasta WHERE Bono='" + pBono + "' AND RNT='" + pRNT + "') BEGIN SELECT '1' END ELSE BEGIN SELECT '0'	END "
        ElseIf cboTipoBono.SelectedValue = "Emision" Then
            SqlRnt = "IF EXISTS (SELECT RNT FROM dbo.Subasta WHERE Bono='" + pBono + "' AND RNT='" + pRNT + "') BEGIN SELECT '1' END ELSE BEGIN SELECT '0'	END "
        End If

        'Validar RNT
        Dim ResRnt As Integer = oper.ExecuteScalar(SqlRnt)
        If ResRnt > 0 Then
            Resultado = "RNT duplicado"
        End If
        Return Resultado
    End Function

    Function ValidarMontoTransado(ByVal pMonto, ByVal pMontoTransado) As ArrayList
        Dim Resultado As New ArrayList

        Dim vTasa As Decimal = Convert.ToDecimal(ViewState("Tasa")) / 100
        Dim vMontoTransado As Decimal = Math.Round(((pMonto * vTasa) / 365 + pMonto), 2)
        'Validar RNT

        If vMontoTransado <> Math.Round(pMontoTransado, 2) Then
            Resultado.Add("X")
            Resultado.Add("Verificar. El valor transado no es correcto.")
            Resultado.Add(Val(pMonto))
        Else
            Resultado.Add("V")
            Resultado.Add("Válido.")
            Resultado.Add(Val(pMonto))
        End If
        Return Resultado
    End Function

    Function SobrescribirLibroOrdenes(ByVal pPuestoBolsa, ByVal pFechaLibro, ByVal pTipoLibroOrdenes, ByVal pCodigoSerie) As Boolean
        Dim vRetorno As Boolean = False
        Try
            Dim cmd As New SqlCommand
            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            cmd.CommandText = "PA_SobrescribirLibroOrdenes"

            cmd.CommandType = CommandType.StoredProcedure

            Dim paramfi As System.Data.SqlClient.SqlParameter
            paramfi = New System.Data.SqlClient.SqlParameter()
            paramfi.ParameterName = "@pPuestoBolsa"
            paramfi.SqlDbType = SqlDbType.Char
            paramfi.Value = pPuestoBolsa
            cmd.Parameters.Add(paramfi)

            Dim paramff As System.Data.SqlClient.SqlParameter
            paramff = New System.Data.SqlClient.SqlParameter()
            paramff.ParameterName = "@pFechaLibro"
            paramff.SqlDbType = SqlDbType.Date
            paramff.Value = pFechaLibro
            cmd.Parameters.Add(paramff)

            Dim paramEm As System.Data.SqlClient.SqlParameter
            paramEm = New System.Data.SqlClient.SqlParameter()
            paramEm.ParameterName = "@pTipoLibroOrdenes"
            paramEm.SqlDbType = SqlDbType.Char
            paramEm.Value = pTipoLibroOrdenes
            cmd.Parameters.Add(paramEm)

            Dim paramSerie As System.Data.SqlClient.SqlParameter
            paramSerie = New System.Data.SqlClient.SqlParameter()
            paramSerie.ParameterName = "@pEmision"
            paramSerie.SqlDbType = SqlDbType.Char
            paramSerie.Value = pCodigoSerie
            cmd.Parameters.Add(paramSerie)

            Cnx.Open()

            cmd.Connection = Cnx
            cmd.ExecuteScalar()
            vRetorno = True
        Catch ex As Exception
            vRetorno = False
        End Try
        Return vRetorno
    End Function

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

    #End Region
End Class
