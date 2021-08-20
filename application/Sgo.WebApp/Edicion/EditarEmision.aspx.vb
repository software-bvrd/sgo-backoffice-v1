Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Upload


Partial Class Edicion_EditarEmision
    Inherits System.Web.UI.Page
    Private oper As New operation
    Private Documento As String
    Private RutaDocumento As String
    Private CodigoPuestoBolsa As New Integer

    '
    ' Cambiar ruta de documentos a ruta local (Seguridad)
    '


    ' -----------------------------------------------------------------------------------
    ' Carga Inicial de la página.
    ' -----------------------------------------------------------------------------------

#Region " Eventos de la página ..."

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabel.Text = String.Empty
        InjectScriptLabelImprimir.Text = String.Empty

        ' Prevenir Rendering de Pagina
        If IsPostBack = False Then


            ViewState("EsNuevo") = Request.QueryString("EsNuevo")


            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount

            ValidatorCodigoSistema.Enabled = False
            ValidatorDireccionEmision.Enabled = False
            ValidatorFechaAprobacionBVRD.Enabled = False
            ValidatorFechaAprobacionSIV.Enabled = False
            ValidatorMontoTotalDeLaEmision.Enabled = False
            ValidatorMontoTotalDeLaEmision.Enabled = False


            'ValidatorNumeroTramo.IsValid = False
            'ValidatorCantidadSeriesPorTramo.Enabled = False

            ValidatorFechaDocumento.Enabled = False
            ValidatorTipoDocumento.Enabled = False


            ValidatorEmpresaCalificadora.Enabled = False
            ValidatorFechaCalificacionRiesgo.Enabled = False


            ValidatorFechaDocumento.Enabled = False
            ValidatorTipoDocumento.Enabled = False


            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
                Session("Code") = Nothing
                Session("Ajax") = Nothing
                Codigo.Text = ViewState("Code")
            Else
                ViewState("Code") = Request.QueryString("EmisionID")
                Codigo.Text = ViewState("Code")
            End If


            If ViewState("EsNuevo") = True Then

                RadTabStrip1.Tabs(1).Enabled = False
                RadTabStrip1.Tabs(2).Enabled = False
                RadTabStrip1.Tabs(3).Enabled = False
                RadTabStrip1.Tabs(4).Enabled = False

                txtCantidadTramos.Text = 1 'Por Defecto Asignar un Tramo 

            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                'txtCodEmisionBVRD.Enabled = False
                Call Editar()
            End If


            'With RadGridTramo
            '    .Culture = New CultureInfo("es-DO")
            '    .AlternatingItemStyle.BackColor = ColorTranslator.FromHtml("#F1F5FB")
            'End With

            With RadGridSerie
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = ColorTranslator.FromHtml("#F1F5FB")
            End With

            With RadGridDocumento
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = ColorTranslator.FromHtml("#F1F5FB")
            End With

            With RadGridEmisionCalificacionRiesgo
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = ColorTranslator.FromHtml("#F1F5FB")
            End With


            With RadGridEmisionPuestoBolsa
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = ColorTranslator.FromHtml("#F1F5FB")
            End With

            ' Seleccionar TAB inicial 
            RadTabStrip1.SelectedIndex = 0
            RadMultiPage1.SelectedIndex = 0


            If RadTabStrip1.Tabs.Item(0).Enabled = True Then
                RadToolBar1.Items.Item(0).Enabled = False
            Else
                RadToolBar1.Items.Item(0).Enabled = True
            End If

        End If


        ' Editar con el evento doble click del radgrid
        If Request.Params("__EVENTTARGET") = "EditarSerie" Then
            EditarSerie()

        End If
        ' Editar con el evento doble click del radgrid
        'If Request.Params("__EVENTTARGET") = "borrar" Then
        '    BorrarTramo()
        'End If



    End Sub

    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        '
        ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
        '
        InitializeComponent()
        MyBase.OnInit(e)
    End Sub 'OnInit
    Private Sub InitializeComponent()
    End Sub
#End Region

    ' -----------------------------------------------------------------------------------
    ' B a r r a   S u p e r i o r
    ' -----------------------------------------------------------------------------------

#Region " Barra Princiopal ..."

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then ' Guardar


            Guardado.Text = String.Empty

            Select Case Me.RadTabStrip1.SelectedIndex

                Case 0    '' Emision 
                    Dim Emision As Integer = 0

                    If Val(txtCodEnSistema.Text.Length) <= 0 Then
                        ValidatorCodigoSistema.ErrorMessage = " Codigo Sistema."
                        ValidatorCodigoSistema.IsValid = False
                        ValidatorCodigoSistema.Enabled = True
                        Emision = Emision + 1
                    End If
                    If Val(txtDescripcionEmision.Text.Length) <= 0 Then
                        ValidatorDireccionEmision.ErrorMessage = "Descripcion."
                        ValidatorDireccionEmision.IsValid = False
                        ValidatorDireccionEmision.Enabled = True
                        Emision = Emision + 1
                    End If
                    If Val(RadComboBoxEmisorID.SelectedValue) = Nothing Then
                        ValidatorRadComboBoxEmisorID.ErrorMessage = "Emisor."
                        ValidatorRadComboBoxEmisorID.IsValid = False
                        ValidatorRadComboBoxEmisorID.Enabled = True
                        Emision = Emision + 1
                    End If
                    If Val(txtFechaAprobacionBVRD.DbSelectedDate) = Nothing Then
                        ValidatorFechaAprobacionBVRD.ErrorMessage = "Fecha Aprobacion BVRD."
                        ValidatorFechaAprobacionBVRD.IsValid = False
                        ValidatorFechaAprobacionBVRD.Enabled = True
                        Emision = Emision + 1
                    End If

                    If Val(txtFechaAprobacionSIV.DbSelectedDate) = Nothing Then
                        ValidatorFechaAprobacionSIV.ErrorMessage = "Fecha Aprobacion SIV."
                        ValidatorFechaAprobacionSIV.IsValid = False
                        ValidatorFechaAprobacionSIV.Enabled = True
                        Emision = Emision + 1
                    End If

                    If Val(txtMontoTotalDeLaEmision.Text) = Nothing Then
                        ValidatorMontoTotalDeLaEmision.ErrorMessage = "Monto Total Emision."
                        ValidatorMontoTotalDeLaEmision.IsValid = False
                        ValidatorMontoTotalDeLaEmision.Enabled = True
                        Emision = Emision + 1
                    End If


                    If Emision > 0 Then
                        Exit Sub
                    End If

                Case 1   ' Puesto Bolsa
                Case 2   ' Emision Serie


                    'Dim EmisionTramo As Integer = 0
                    'If Val(txtNumeroTramo.Text.Length) <= 0 Then
                    '    ValidatorNumeroTramo.ErrorMessage = "Nombre."
                    '    ValidatorNumeroTramo.IsValid = False
                    '    ValidatorNumeroTramo.Enabled = True

                    '    EmisionTramo = EmisionTramo + 1
                    'End If
                    'If Val(txtCantidadSeriesPorTramo.Text.Length) <= 0 Then
                    '    ValidatorCantidadSeriesPorTramo.ErrorMessage = "Cantidad Series Por Tramo."
                    '    ValidatorCantidadSeriesPorTramo.IsValid = False
                    '    ValidatorCantidadSeriesPorTramo.Enabled = True

                    '    EmisionTramo = EmisionTramo + 1
                    'End If


                    'If EmisionTramo > 0 Then
                    '    Exit Sub
                    'End If



                Case 3
                    Dim Documento As Integer = 0

                    If Val(txtFechaDocumento.DbSelectedDate) = Nothing Then
                        ValidatorFechaDocumento.Enabled = False
                        ValidatorFechaDocumento.IsValid = False
                        ValidatorFechaDocumento.Enabled = True

                        Documento = Documento + 1
                    End If

                    If Val(RadComboBox1.Text.Length) <= 0 Then
                        ValidatorTipoDocumento.ErrorMessage = "Tipo documento"
                        ValidatorTipoDocumento.IsValid = False
                        ValidatorTipoDocumento.Enabled = True
                        Documento = Documento + 1
                    End If

                    If Documento > 0 Then
                        Exit Sub
                    End If


                Case 4 ' EmisorCalificacionRiesgo

                    Dim EmisorCalificacionRiesgo As Integer = 0

                    If Val(RadComboBoxEmpresaCalificadoraID.Text.Length) <= 0 Then
                        ValidatorEmpresaCalificadora.ErrorMessage = "Empresa Calificadora."
                        ValidatorEmpresaCalificadora.IsValid = False
                        ValidatorEmpresaCalificadora.Enabled = True
                        EmisorCalificacionRiesgo = EmisorCalificacionRiesgo + 1
                    End If

                    If Val(txtFechaCalificacionRiesgo.DbSelectedDate) = Nothing Then
                        ValidatorFechaCalificacionRiesgo.ErrorMessage = "Empresa Calificadora."
                        ValidatorFechaCalificacionRiesgo.IsValid = False
                        ValidatorFechaCalificacionRiesgo.Enabled = True
                        EmisorCalificacionRiesgo = EmisorCalificacionRiesgo + 1
                    End If

                    If EmisorCalificacionRiesgo > 0 Then
                        Exit Sub
                    End If

            End Select


            If ViewState("EsNuevo") = True Then ' Ingresar Nuevo Registro

                Select Case Me.RadTabStrip1.SelectedIndex
                    Case 0
                        If RadComboBoxInstrumentoID.SelectedValue <> String.Empty Then

                            If txtCodEmisionBVRD.Text.Length = 0 Or RTrim(txtCodEmisionBVRD.Text) = String.Empty Then
                                Dim CodigoBVRD As String = String.Empty
                                CodigoBVRD = oper.ExecuteScalar("select dbo.CreacionCodigoBVRDEmision ('" & RadComboBoxInstrumentoID.SelectedValue & "','" & oper.FormatoFechayymmdd(txtFechaAprobacionBVRD.DbSelectedDate) & "' )")
                                txtCodEmisionBVRD.Text = CodigoBVRD
                                InsertarSecuencia(RadComboBoxInstrumentoID.SelectedValue, txtCodEmisionBVRD.Text)
                            End If

                            Nuevo()
                            ViewState("EsNuevo") = False
                            Exit Sub
                        Else
                            Guardado.ForeColor = Color.Red
                            Guardado.Text = "Seleccione un instrumento"
                        End If

                    'RadTabStrip1.Tabs(0).Enabled = False
                    Case 1
                        InsertarPuestoBolsa(Me.Codigo.Text)
                        LimpiaPuestoBolsa()
                        RadGridEmisionPuestoBolsa.DataBind()
                    Case 2
                        'If CantidadTramosDisponibles() > 0 Then

                        '    InsertarTramo(Me.Codigo.Text)
                        '    LimpiaTramo()
                        '    RadGridTramo.DataBind()
                        'Else

                        '    InjectScriptLabel.Text = "<script>MensajePopup('No hay mas tramos disponibles para ingresar.')</" + "script>"

                        'End If

                    Case 3
                        InsertarDocumento(Me.Codigo.Text)
                        LimpiaDocumento()
                        RadGridDocumento.DataBind()
                        RadUpload1.Visible = True
                        Button2.Enabled = True
                        RadProgressArea1.Visible = True
                    Case 4
                        InsertarEmisionCalificacionRiesgo(Me.Codigo.Text)
                        LimpiaEmisorCalificacionRiesgo()
                        RadGridEmisionCalificacionRiesgo.DataBind()
                End Select

            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                CodigoPuestoBolsa = Request.QueryString("EmisionID")
                Select Case Me.RadTabStrip1.SelectedIndex
                    Case 0
                        Actualizar()
                    Case 1
                        ActualizarPuestoBolsa()
                        LimpiaPuestoBolsa()
                        RadGridEmisionPuestoBolsa.DataBind()
                    Case 2


                        'ActualizarTramo()
                        'LimpiaTramo()
                        'RadGridTramo.DataBind()
                    Case 3
                        ActualizarDocumento()
                        LimpiaDocumento()
                        RadGridDocumento.DataBind()
                        RadUpload1.Visible = True
                        Button2.Enabled = True
                        RadProgressArea1.Visible = True
                    Case 4
                        ActualizarEmisionCalificacionRiesgo()
                        LimpiaEmisorCalificacionRiesgo()
                        RadGridEmisionCalificacionRiesgo.DataBind()
                End Select


                'ViewState("EsNuevo") = True
                ' RadTabStrip1.Tabs(0).Enabled = False
            End If


        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then  ' Nuevo

            Select Case Me.RadTabStrip1.SelectedIndex

                Case 0

                Case 1
                    LimpiaPuestoBolsa()
                    RadGridEmisionPuestoBolsa.DataBind()
                    ViewState("EsNuevo") = True

                Case 2 'Nueva serie

                    ViewState("Code") = String.Empty 'dataItem("EmisionTramoID").Text

                    ViewState("EmisionID") = oper.ExecuteScalar("Select EmisionID from Emision where CodEmisionBVRD ='" + txtCodEmisionBVRD.Text + "'")

                    Dim MyWindow As New Telerik.Web.UI.RadWindow
                    MyWindow.NavigateUrl = "EditarSeriePOPUP.aspx?EmisionTramoID=" & ViewState("Code") & "&EmisionID=" & ViewState("EmisionID") & "&EsNuevo=" & True
                    MyWindow.VisibleOnPageLoad = True
                    MyWindow.BackColor = Drawing.Color.Blue
                    MyWindow.AutoSize = True
                    RadWindowManager2.Windows.Clear()
                    RadWindowManager2.Windows.Add(MyWindow)


                    'Call LimpiaTramo()
                    'Me.RadGridSeri.DataBind()
                    'ViewState("EsNuevo") = True

                Case 3
                    Call LimpiaDocumento()
                    Me.RadGridDocumento.DataBind()
                    RadUpload1.Visible = True
                    Button2.Enabled = True
                    RadProgressArea1.Visible = True
                    ViewState("EsNuevo") = True
                Case 4
                    LimpiaEmisorCalificacionRiesgo()
                    RadGridEmisionCalificacionRiesgo.DataBind()
                    ViewState("EsNuevo") = True

            End Select

        ElseIf e.Item.Value = 3 Then  ' Borrar

            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0

                    BorrarEmision()

                Case 1 ' Puesto de Bolsa

                    BorrarPuestoBolsa()
                    RadGridEmisionPuestoBolsa.DataBind()

                Case 2 'Borrar tramo
                    Dim CodigoTramo As Integer = ViewState("CodeTramo")
                    If CodigoTramo > 0 Then
                        InjectScriptLabelImprimir.Text = "<script>Delete()</" + "script>"

                    Else
                        InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para editar.')</" + "script>"
                    End If

                Case 3 ' Documentos
                    BorrarDocumento()
                    RadGridDocumento.Rebind()
                Case 4 ' Calificación de Riesgo

                    BorrarCalificacionRiesgo()
                    RadGridEmisionCalificacionRiesgo.DataBind()

            End Select
        End If

    End Sub
#End Region

#Region "Operaciones con Emisión"
    Sub Nuevo()

        Dim csql As String = String.Empty

        If ViewState("EsNuevo") = True Then

            '--------------------------------------------Emision -------------------------------------------------------------------------
            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            Try

                Dim Sql As String = "INSERT INTO [Emision] ([CodEmisionBVRD] " &
               ",[CodEnSistema] " &
               ",[EmisorID] " &
               ",[Descripcion] " &
               ",[CantidadTramos] " &
               ",[FechaAprobacionBVRD] " &
               ",[FechaAprobacionSIV] " &
               ",[TipoAmortizacionCapitalID] " &
               ",[FinalidadDeLaEmision] " &
               ",[SubirAOP] " &
               ",[GarantiaProgramaEmision] " &
               ",[FechaFinalColocacion] " &
               ",[CalcularComision] " &
               ",[MontoTotalDeLaEmision] " &
               ",[MontoOfertadoAlPublico] " &
               ",[ValorNominal] " &
               ",[BaseLiquidacionID] " &
               ",[Estatus] " &
               ",[Nota1] " &
               ",[Nota2] " &
               ",[TipoDeEmisionID] " &
               ",[InstrumentoID] " &
               ",[TipoMonedaID] " &
               ",[FormaColocacionID],[TipoNegociacionID], [TipoInstrumentoID],[ContemplaRedencion],[ContemplaRedencionFecha],[AplicarComisionEnBaseTramosVigentes]) VALUES(@CodEmisionBVRD " &
               ",@CodEnSistema " &
               ",@EmisorID " &
               ",@Descripcion " &
               ",@CantidadTramos " &
               ",@FechaAprobacionBVRD " &
               ",@FechaAprobacionSIV " &
               ",@TipoAmortizacionCapitalID " &
               ",@FinalidadDeLaEmision " &
               ",@SubirAOP " &
               ",@GarantiaProgramaEmision " &
               ",@FechaFinalColocacion" &
               ",@CalcularComision" &
               ",@MontoTotalDeLaEmision " &
               ",@MontoOfertadoAlPublico " &
               ",@ValorNominal " &
               ",@BaseLiquidacionID " &
               ",@Estatus " &
               ",@Nota1 " &
               ",@Nota2 " &
               ",@TipoDeEmisionID " &
               ",@InstrumentoID " &
               ",@TipoMonedaID " &
               ",@FormaColocacionID " &
                ",@TipoNegociacionID " &
               ",@TipoInstrumentoID,@ContemplaRedencion,@ContemplaRedencionFecha,@AplicarComisionEnBaseTramosVigentes) "


                Cnx.Open()
                Dim cmd As New SqlCommand(Sql, Cnx)


                cmd.Parameters.Add(New SqlParameter("@CodEmisionBVRD", SqlDbType.NChar)).Value = IIf(Me.txtCodEmisionBVRD.Text.Length > 0, Me.txtCodEmisionBVRD.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@CodEnSistema", SqlDbType.NChar)).Value = IIf(Me.txtCodEnSistema.Text.Length > 0, Me.txtCodEnSistema.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxEmisorID.Text.Length > 0, Me.RadComboBoxEmisorID.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NChar)).Value = IIf(Me.txtDescripcionEmision.Text.Length > 0, Me.txtDescripcionEmision.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@CantidadTramos", SqlDbType.Int)).Value = IIf(Me.txtCantidadTramos.Text.Length > 0, Me.txtCantidadTramos.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@FechaAprobacionBVRD", SqlDbType.Date)).Value = IIf(Me.txtFechaAprobacionBVRD.DbSelectedDate.ToString.Length > 0, Me.txtFechaAprobacionBVRD.DbSelectedDate, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@FechaAprobacionSIV", SqlDbType.Date)).Value = IIf(Me.txtFechaAprobacionSIV.DbSelectedDate.ToString.Length > 0, Me.txtFechaAprobacionSIV.DbSelectedDate, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@TipoAmortizacionCapitalID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoAmortizacionCapitalID.Text.Length > 0, Me.RadComboBoxTipoAmortizacionCapitalID.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@FinalidadDeLaEmision", SqlDbType.NVarChar)).Value = IIf(Me.txtFinalidadDeLaEmision.Text.Length > 0, Me.txtFinalidadDeLaEmision.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@SubirAOP", SqlDbType.NChar)).Value = IIf(Me.RadComboBoxSubirAOP.Text.Length > 0, Me.RadComboBoxSubirAOP.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@GarantiaProgramaEmision", SqlDbType.NVarChar)).Value = IIf(Me.txtGarantiaProgramaEmision.Text.Length > 0, Me.txtGarantiaProgramaEmision.Text, DBNull.Value)




                If Me.rdpFechaFinalColocacion.DbSelectedDate <> Nothing Then
                    cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = IIf(Me.rdpFechaFinalColocacion.DbSelectedDate.ToString.Length > 0, Me.rdpFechaFinalColocacion.DbSelectedDate, DBNull.Value)
                Else
                    cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = DBNull.Value
                End If






                cmd.Parameters.Add(New SqlParameter("@CalcularComision", SqlDbType.NChar)).Value = Me.cbCalcularComision.Checked

                ' 2016.12.13
                cmd.Parameters.Add(New SqlParameter("@AplicarComisionEnBaseTramosVigentes", SqlDbType.NChar)).Value = Me.cbAplicarComisionEnBaseTramosVigentes.Checked


                cmd.Parameters.Add(New SqlParameter("@MontoTotalDeLaEmision", SqlDbType.Money)).Value = IIf(Me.txtMontoTotalDeLaEmision.Text.Length > 0, Me.txtMontoTotalDeLaEmision.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@MontoOfertadoAlPublico", SqlDbType.Money)).Value = IIf(Me.txtMontoOfertadoAlPublico.Text.Length > 0, Me.txtMontoOfertadoAlPublico.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@ValorNominal", SqlDbType.Money)).Value = IIf(Me.txtValorNominal.Text.Length > 0, Me.txtValorNominal.Text, DBNull.Value)

                cmd.Parameters.Add(New SqlParameter("@BaseLiquidacionID", SqlDbType.Int)).Value = IIf(Me.RadcomboBoxBaseLiquidacion.Text.Length > 0, Me.RadcomboBoxBaseLiquidacion.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Estatus", SqlDbType.NChar)).Value = IIf(Me.RadComboBoxEstatus.Text.Length > 0, Me.RadComboBoxEstatus.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Nota1", SqlDbType.NVarChar)).Value = IIf(Me.txtNota1.Text.Length > 0, Me.txtNota1.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Nota2", SqlDbType.NVarChar)).Value = IIf(Me.txtNota2.Text.Length > 0, Me.txtNota2.Text, DBNull.Value)

                cmd.Parameters.Add(New SqlParameter("@TipoDeEmisionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoDeEmisionID.Text.Length > 0, Me.RadComboBoxTipoDeEmisionID.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@InstrumentoID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxInstrumentoID.Text.Length > 0, Me.RadComboBoxInstrumentoID.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@TipoMonedaID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoMonedaID.Text.Length > 0, Me.RadComboBoxTipoMonedaID.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@FormaColocacionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxFormaColocacionID.Text.Length > 0, Me.RadComboBoxFormaColocacionID.SelectedValue, DBNull.Value)

                cmd.Parameters.Add(New SqlParameter("@TipoInstrumentoID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoInstrumentoID.Text.Length > 0, Me.RadComboBoxTipoInstrumentoID.SelectedValue, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@TipoNegociacionID", SqlDbType.Int)).Value = IIf(Me.rcbTipoNegMercadoSecundario.Text.Length > 0, Me.rcbTipoNegMercadoSecundario.SelectedValue, DBNull.Value)


                cmd.Parameters.Add(New SqlParameter("@ContemplaRedencion", SqlDbType.NChar)).Value = Me.cbContemplaRedencion.Checked

                If Me.txtFechaContemplaRedencion.DbSelectedDate <> Nothing Then
                    cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = IIf(Me.txtFechaContemplaRedencion.DbSelectedDate.ToString.Length > 0, Me.txtFechaContemplaRedencion.DbSelectedDate, DBNull.Value)
                Else
                    cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = DBNull.Value
                End If

                cmd.ExecuteNonQuery()


                csql = oper.CovertirComandoATexto(cmd)
                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisión", "EditarEmision", csql)


                RadTabStrip1.Tabs(1).Enabled = True
                RadTabStrip1.Tabs(2).Enabled = True
                RadTabStrip1.Tabs(3).Enabled = True
                RadTabStrip1.Tabs(4).Enabled = True

                ViewState("EsNuevo") = True


                Codigo.Text = oper.ExecuteScalar("select IDENT_CURRENT('Emision')")   'CodigoEmision 
                Guardado.ForeColor = Color.Blue
                Guardado.Text = "Guardado con éxito"

                Notification1.Text = "Guardado con éxito!"
                Notification1.Show()


            Catch sql_ex As SqlClient.SqlException

                If sql_ex.ErrorCode = -2146232060 Then
                    ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
                    ValidatorFechaAprobacionBVRD.IsValid = False
                    Exit Sub
                End If

            Catch ex As Exception
                Guardado.Text = ex.Message.Trim

            Finally
                Cnx.Close()
            End Try



        End If
    End Sub
    Sub Actualizar()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try

            Dim Sql As String = "Update [Emision] SET [CodEmisionBVRD] = @CodEmisionBVRD" &
               ",[CodEnSistema]= @CodEnSistema  " &
               ",[EmisorID] = @EmisorID" &
               ",[Descripcion] = @Descripcion" &
               ",[CantidadTramos] = @CantidadTramos" &
               ",[FechaAprobacionBVRD] = @FechaAprobacionBVRD" &
               ",[FechaAprobacionSIV] = @FechaAprobacionSIV" &
               ",[TipoAmortizacionCapitalID] = @TipoAmortizacionCapitalID" &
               ",[FinalidadDeLaEmision] = @FinalidadDeLaEmision" &
               ",[SubirAOP] = @SubirAOP" &
               ",[GarantiaProgramaEmision] = @GarantiaProgramaEmision" &
               ",[FechaFinalColocacion] = @FechaFinalColocacion" &
               ",[CalcularComision] = @CalcularComision" &
               ",[MontoTotalDeLaEmision] = @MontoTotalDeLaEmision" &
               ",[MontoOfertadoAlPublico] = @MontoOfertadoAlPublico" &
               ",[ValorNominal] = @ValorNominal" &
               ",[BaseLiquidacionID] = @BaseLiquidacionID" &
               ",[Estatus] = @Estatus" &
               ",[Nota1] = @Nota1" &
               ",[Nota2] = @Nota2" &
               ",[TipoDeEmisionID] = @TipoDeEmisionID" &
               ",[InstrumentoID] = @InstrumentoID" &
               ",[TipoMonedaID] = @TipoMonedaID" &
               ",[FormaColocacionID] = @FormaColocacionID" &
               ",[TipoNegociacionID] = @TipoNegociacionID" &
               ",[TipoInstrumentoID] = @TipoInstrumentoID" &
               ",[ContemplaRedencion]=@ContemplaRedencion" &
               ",[ContemplaRedencionFecha]=@ContemplaRedencionFecha" &
               ",[AplicarComisionEnBaseTramosVigentes]=@AplicarComisionEnBaseTramosVigentes" &
               " where EmisionID = @EmisionID  "

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = Codigo.Text

            cmd.Parameters.Add(New SqlParameter("@CodEmisionBVRD", SqlDbType.NChar)).Value = IIf(Me.txtCodEmisionBVRD.Text.Length > 0, Me.txtCodEmisionBVRD.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodEnSistema", SqlDbType.NChar)).Value = IIf(Me.txtCodEnSistema.Text.Length > 0, Me.txtCodEnSistema.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxEmisorID.Text.Length > 0, Me.RadComboBoxEmisorID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.NChar)).Value = IIf(Me.txtDescripcionEmision.Text.Length > 0, Me.txtDescripcionEmision.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CantidadTramos", SqlDbType.Int)).Value = IIf(Me.txtCantidadTramos.Text.Length > 0, Me.txtCantidadTramos.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FechaAprobacionBVRD", SqlDbType.Date)).Value = IIf(Me.txtFechaAprobacionBVRD.DbSelectedDate.ToString.Length > 0, Me.txtFechaAprobacionBVRD.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FechaAprobacionSIV", SqlDbType.Date)).Value = IIf(Me.txtFechaAprobacionSIV.DbSelectedDate.ToString.Length > 0, Me.txtFechaAprobacionSIV.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoAmortizacionCapitalID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoAmortizacionCapitalID.Text.Length > 0, Me.RadComboBoxTipoAmortizacionCapitalID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FinalidadDeLaEmision", SqlDbType.NVarChar)).Value = IIf(Me.txtFinalidadDeLaEmision.Text.Length > 0, Me.txtFinalidadDeLaEmision.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@SubirAOP", SqlDbType.NChar)).Value = IIf(Me.RadComboBoxSubirAOP.Text.Length > 0, Me.RadComboBoxSubirAOP.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@GarantiaProgramaEmision", SqlDbType.NVarChar)).Value = IIf(Me.txtGarantiaProgramaEmision.Text.Length > 0, Me.txtGarantiaProgramaEmision.Text, DBNull.Value)




            If Me.rdpFechaFinalColocacion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = IIf(Me.rdpFechaFinalColocacion.DbSelectedDate.ToString.Length > 0, Me.rdpFechaFinalColocacion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = DBNull.Value
            End If




            cmd.Parameters.Add(New SqlParameter("@CalcularComision", SqlDbType.NChar)).Value = Me.cbCalcularComision.Checked

            ' 2016.12.13
            cmd.Parameters.Add(New SqlParameter("@AplicarComisionEnBaseTramosVigentes", SqlDbType.NChar)).Value = Me.cbAplicarComisionEnBaseTramosVigentes.Checked


            cmd.Parameters.Add(New SqlParameter("@MontoTotalDeLaEmision", SqlDbType.Money)).Value = IIf(Me.txtMontoTotalDeLaEmision.Text.Length > 0, Me.txtMontoTotalDeLaEmision.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@MontoOfertadoAlPublico", SqlDbType.Money)).Value = IIf(Me.txtMontoOfertadoAlPublico.Text.Length > 0, Me.txtMontoOfertadoAlPublico.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ValorNominal", SqlDbType.Money)).Value = IIf(Me.txtValorNominal.Text.Length > 0, Me.txtValorNominal.Text, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@BaseLiquidacionID", SqlDbType.Int)).Value = IIf(Me.RadcomboBoxBaseLiquidacion.Text.Length > 0, Me.RadcomboBoxBaseLiquidacion.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Estatus", SqlDbType.NChar)).Value = IIf(Me.RadComboBoxEstatus.Text.Length > 0, Me.RadComboBoxEstatus.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota1", SqlDbType.NVarChar)).Value = IIf(Me.txtNota1.Text.Length > 0, Me.txtNota1.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota2", SqlDbType.NVarChar)).Value = IIf(Me.txtNota2.Text.Length > 0, Me.txtNota2.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@TipoDeEmisionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoDeEmisionID.Text.Length > 0, Me.RadComboBoxTipoDeEmisionID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@InstrumentoID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxInstrumentoID.Text.Length > 0, Me.RadComboBoxInstrumentoID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoMonedaID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoMonedaID.Text.Length > 0, Me.RadComboBoxTipoMonedaID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FormaColocacionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxFormaColocacionID.Text.Length > 0, Me.RadComboBoxFormaColocacionID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoInstrumentoID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoInstrumentoID.Text.Length > 0, Me.RadComboBoxTipoInstrumentoID.SelectedValue, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@TipoNegociacionID", SqlDbType.Int)).Value = IIf(Me.rcbTipoNegMercadoSecundario.Text.Length > 0, Me.rcbTipoNegMercadoSecundario.SelectedValue, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@ContemplaRedencion", SqlDbType.Bit)).Value = Me.cbContemplaRedencion.Checked

            If Me.txtFechaContemplaRedencion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = IIf(Me.txtFechaContemplaRedencion.DbSelectedDate.ToString.Length > 0, Me.txtFechaContemplaRedencion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisión", "EditarEmision", csql)

            Guardado.ForeColor = Color.Blue
            Guardado.Text = "Actualizado con éxito"

            Notification1.Text = "Actualizado con éxito!"
            Notification1.Show()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try


    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vEmisionTab]  where EmisionID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            '--------------------------------------------Puesto Bolsa -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("CodEmisionBVRD")) Then Me.txtCodEmisionBVRD.Text = Trim(MyRow.Item("CodEmisionBVRD"))
            If Not IsDBNull(MyRow.Item("CodEnSistema")) Then Me.txtCodEnSistema.Text = Trim(MyRow.Item("CodEnSistema"))
            If Not IsDBNull(MyRow.Item("EmisorID")) Then Me.RadComboBoxEmisorID.SelectedValue = Trim(MyRow.Item("EmisorID"))
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcionEmision.Text = Trim(MyRow.Item("Descripcion"))
            If Not IsDBNull(MyRow.Item("CantidadTramos")) Then Me.txtCantidadTramos.Text = Trim(MyRow.Item("CantidadTramos"))
            If Not IsDBNull(MyRow.Item("FechaAprobacionBVRD")) Then Me.txtFechaAprobacionBVRD.DbSelectedDate = Trim(MyRow.Item("FechaAprobacionBVRD"))
            If Not IsDBNull(MyRow.Item("FechaAprobacionSIV")) Then Me.txtFechaAprobacionSIV.DbSelectedDate = Trim(MyRow.Item("FechaAprobacionSIV"))
            If Not IsDBNull(MyRow.Item("TipoAmortizacionCapitalID")) Then Me.RadComboBoxTipoAmortizacionCapitalID.SelectedValue = Trim(MyRow.Item("TipoAmortizacionCapitalID"))
            If Not IsDBNull(MyRow.Item("FinalidadDeLaEmision")) Then Me.txtFinalidadDeLaEmision.Text = Trim(MyRow.Item("FinalidadDeLaEmision"))
            If Not IsDBNull(MyRow.Item("FechaFinalColocacion")) Then Me.rdpFechaFinalColocacion.DbSelectedDate = Trim(MyRow.Item("FechaFinalColocacion"))
            If Not IsDBNull(MyRow.Item("CalcularComision")) Then Me.cbCalcularComision.Checked = Trim(MyRow.Item("CalcularComision"))

            ' 2016.12.13
            If Not IsDBNull(MyRow.Item("AplicarComisionEnBaseTramosVigentes")) Then Me.cbAplicarComisionEnBaseTramosVigentes.Checked = Trim(MyRow.Item("AplicarComisionEnBaseTramosVigentes"))


            If Not IsDBNull(MyRow.Item("SubirAOP")) Then
                Me.RadComboBoxSubirAOP.SelectedValue = Trim(MyRow.Item("SubirAOP"))
            Else
                Me.RadComboBoxSubirAOP.SelectedValue = "N"
            End If

            If Not IsDBNull(MyRow.Item("GarantiaProgramaEmision")) Then Me.txtGarantiaProgramaEmision.Text = Trim(MyRow.Item("GarantiaProgramaEmision"))

            If Not IsDBNull(MyRow.Item("MontoTotalDeLaEmision")) Then Me.txtMontoTotalDeLaEmision.Text = Trim(MyRow.Item("MontoTotalDeLaEmision"))
            If Not IsDBNull(MyRow.Item("MontoOfertadoAlPublico")) Then Me.txtMontoOfertadoAlPublico.Text = Trim(MyRow.Item("MontoOfertadoAlPublico"))

            If Not IsDBNull(MyRow.Item("ValorNominal")) Then Me.txtValorNominal.Text = Trim(MyRow.Item("ValorNominal"))
            If Not IsDBNull(MyRow.Item("BaseLiquidacionID")) Then Me.RadcomboBoxBaseLiquidacion.SelectedValue = Trim(MyRow.Item("BaseLiquidacionID"))

            If Not IsDBNull(MyRow.Item("Estatus")) Then Me.RadComboBoxEstatus.SelectedValue = Trim(MyRow.Item("Estatus"))
            If Not IsDBNull(MyRow.Item("Nota1")) Then Me.txtNota1.Text = Trim(MyRow.Item("Nota1"))
            If Not IsDBNull(MyRow.Item("Nota2")) Then Me.txtNota2.Text = Trim(MyRow.Item("Nota2"))


            If Not IsDBNull(MyRow.Item("TipoDeEmisionID")) Then Me.RadComboBoxTipoDeEmisionID.SelectedValue = Trim(MyRow.Item("TipoDeEmisionID"))
            If Not IsDBNull(MyRow.Item("InstrumentoID")) Then Me.RadComboBoxInstrumentoID.SelectedValue = Trim(MyRow.Item("InstrumentoID"))
            If Not IsDBNull(MyRow.Item("TipoMonedaID")) Then Me.RadComboBoxTipoMonedaID.SelectedValue = Trim(MyRow.Item("TipoMonedaID"))


            If Not IsDBNull(MyRow.Item("FormaColocacionID")) Then Me.RadComboBoxFormaColocacionID.SelectedValue = Trim(MyRow.Item("FormaColocacionID"))
            If Not IsDBNull(MyRow.Item("TipoInstrumentoID")) Then Me.RadComboBoxTipoInstrumentoID.SelectedValue = Trim(MyRow.Item("TipoInstrumentoID"))
            If Not IsDBNull(MyRow.Item("TipoNegociacionID")) Then Me.rcbTipoNegMercadoSecundario.SelectedValue = Trim(MyRow.Item("TipoNegociacionID"))
            If Not IsDBNull(MyRow.Item("ContemplaRedencion")) Then Me.cbContemplaRedencion.Checked = Trim(MyRow.Item("ContemplaRedencion"))
            If Not IsDBNull(MyRow.Item("ContemplaRedencionFecha")) Then Me.txtFechaContemplaRedencion.DbSelectedDate = Trim(MyRow.Item("ContemplaRedencionFecha"))

        Next

        ' -----------------------------------------------------
        ' 2016.10.20 
        ' Verificar si se han colocado series y poner el valor
        ' -----------------------------------------------------
        Dim vMontoOfertadoAlPublico As Decimal = 0


        Try
            ' Verificar contra las operaciones si se a negociado la serie...
            'Dim sql As String = "SELECT isnull(SUM(es.ValorUnitarioNominal),0) FROM EmisionSerie es " _
            '        & " JOIN dbo.EmisionTramo et" _
            '        & " ON et.EmisionTramoID = es.EmisionTramoID " _
            '        & " WHERE es.Serie " _
            '        & " IN " _
            '        & " ( " _
            '        & "	SELECT DISTINCT o.nemo_ins  FROM dbo.Operacionescsv o    " _
            '        & " ) AND et.EmisionID =  '" & CInt(ViewState("Code")) & "'"


            ' Comparar con la Fecha Inicio de Colocación
            Dim sql As String = "SELECT isnull(SUM(es.ValorUnitarioNominal),0) FROM EmisionSerie es" _
            & " JOIN	dbo.EmisionTramo et" _
            & " ON  et.EmisionTramoID = es.EmisionTramoID  " _
            & " WHERE  et.EmisionID = '" & CInt(ViewState("Code")) & "' AND es.FechaInicioColocacion < GETDATE() "


            vMontoOfertadoAlPublico = oper.ExecuteScalar(sql)
            txtMontoOfertadoAlPublico.Text = vMontoOfertadoAlPublico.ToString()


            ' -------------------------------------------------------------------------------
            ' Verificar si el usuario actual tiene permiso para editar los campos
            ' Nota : La opción de menú para el Programa de Emisiones es 30
            ' -------------------------------------------------------------------------------

            Dim cSQLOpciones As String = "Select count(*) from dbo.OpcionesEditables where IdUsuario = '" & Session("IdUsuario") & "' And IdOpcionesMenu = 30"
            Dim Edita As Int32 = Convert.ToInt32(oper.ExecuteScalar(cSQLOpciones))

            If Edita = 0 Then


                ' Deshabilitar Datos importantes
                With Me.txtMontoTotalDeLaEmision
                    .Enabled = False
                    .Font.Bold = True
                End With

                With Me.txtMontoOfertadoAlPublico
                    .Enabled = False
                    .Font.Bold = True
                End With

                With Me.txtValorNominal
                    .Enabled = False
                    .Font.Bold = True
                End With

                With Me.RadcomboBoxBaseLiquidacion
                    .Enabled = False
                    .Font.Bold = True
                End With

                With Me.RadComboBoxTipoDeEmisionID
                    .Enabled = False
                    .Font.Bold = True
                End With

                With Me.RadComboBoxInstrumentoID
                    .Enabled = False
                    .Font.Bold = True
                End With
                With Me.RadComboBoxTipoMonedaID
                    .Enabled = False
                    .Font.Bold = True
                End With

                With Me.RadComboBoxFormaColocacionID
                    .Enabled = False
                    .Font.Bold = True
                End With
                With Me.RadComboBoxTipoInstrumentoID
                    .Enabled = False
                    .Font.Bold = True
                End With

                With Me.rcbTipoNegMercadoSecundario
                    .Enabled = False
                    .Font.Bold = True
                End With

            End If



        Catch
            Throw
        End Try


    End Sub
    Sub BorrarEmision()
        Dim ID As Integer = Codigo.Text

        'oper.ExecuteNonQuery("delete from dbo.EmisionDocumento  where EmisionID='" & ID & "'")
        'oper.ExecuteNonQuery("delete from dbo.EmisionCalificacionRiesgo  where EmisionID='" & ID & "'")
        'oper.ExecuteNonQuery("delete from dbo.EmisionPuestoBolsa  where EmisionID='" & ID & "'")


        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

    End Sub
    Sub InsertarSecuencia(pInstrumentoID As Integer, pCodigoBVRD As String)
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "Update [Instrumento] SET [Secuencia] = @Secuencia where InstrumentoID = @InstrumentoID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@InstrumentoID", SqlDbType.BigInt)).Value = pInstrumentoID
            cmd.Parameters.Add(New SqlParameter("@Secuencia", SqlDbType.Int)).Value = CInt(Right(RTrim(pCodigoBVRD), 3))

            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try


    End Sub
#End Region

#Region "Operaciones con Tramos y Series"
    'Sub InsertarTramo(ByVal CodigoEmision As String)

    '    Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
    '    Dim csql As String = String.Empty

    '    Try
    '        Dim Sql As String = "INSERT INTO EmisionTramo ([EmisionID] " &
    '        ",[NumeroTramo] " &
    '        ",[CantidadSeriesPorTramo] " &
    '        ",[FechaInicioColocacion] " &
    '        ",[FechaDeEmision] " &
    '        ",[FechaPlanVencimiento] " &
    '        ") VALUES (@EmisionID " &
    '        ",@NumeroTramo " &
    '        ",@CantidadSeriesPorTramo " &
    '        ",@FechaInicioColocacion " &
    '        ",@FechaDeEmision " &
    '        ",@FechaPlanVencimiento " &
    '        " ) "

    '        Cnx.Open()
    '        Dim cmd As New SqlCommand(Sql, Cnx)

    '        cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = CodigoEmision
    '        cmd.Parameters.Add(New SqlParameter("@NumeroTramo", SqlDbType.Int)).Value = IIf(Me.txtNumeroTramo.Text.Length > 0, Me.txtNumeroTramo.Text, DBNull.Value)
    '        cmd.Parameters.Add(New SqlParameter("@CantidadSeriesPorTramo", SqlDbType.Int)).Value = IIf(Me.txtCantidadSeriesPorTramo.Text.Length > 0, Me.txtCantidadSeriesPorTramo.Text, DBNull.Value)


    '        If Me.txtFechaInicioColocacion.DbSelectedDate <> Nothing Then
    '            cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = IIf(Me.txtFechaInicioColocacion.DbSelectedDate.ToString.Length > 0, Me.txtFechaInicioColocacion.DbSelectedDate, DBNull.Value)
    '        Else
    '            cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = DBNull.Value
    '        End If

    '        If Me.txtFechaDeEmision.DbSelectedDate <> Nothing Then
    '            cmd.Parameters.Add(New SqlParameter("@FechaDeEmision", SqlDbType.Date)).Value = IIf(Me.txtFechaDeEmision.DbSelectedDate.ToString.Length > 0, Me.txtFechaDeEmision.DbSelectedDate, DBNull.Value)
    '        Else
    '            cmd.Parameters.Add(New SqlParameter("@FechaDeEmision", SqlDbType.Date)).Value = DBNull.Value
    '        End If

    '        If Me.txtFechaPlanVencimiento.DbSelectedDate <> Nothing Then
    '            cmd.Parameters.Add(New SqlParameter("@FechaPlanVencimiento", SqlDbType.Date)).Value = IIf(Me.txtFechaPlanVencimiento.DbSelectedDate.ToString.Length > 0, Me.txtFechaPlanVencimiento.DbSelectedDate, DBNull.Value)
    '        Else
    '            cmd.Parameters.Add(New SqlParameter("@FechaPlanVencimiento", SqlDbType.Date)).Value = DBNull.Value
    '        End If


    '        cmd.ExecuteNonQuery()

    '        csql = oper.CovertirComandoATexto(cmd)
    '        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Tramo", "EditarEmision", csql)


    '    Catch sql_ex As SqlClient.SqlException

    '        If sql_ex.ErrorCode = -2146232060 Then
    '            ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
    '            ValidatorFechaAprobacionBVRD.IsValid = False
    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '    Finally
    '        Cnx.Close()
    '    End Try
    'End Sub


    'Sub EditarTramo()
    '    Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vEmisionTramo]  where  EmisionTramoID ='" & CInt(ViewState("CodeTramo")) & "'")
    '    Dim MyRow As DataRow
    '    For Each MyRow In ds.Tables(0).Rows

    '        If Not IsDBNull(MyRow.Item("NumeroTramo")) Then Me.txtNumeroTramo.Text = Trim(MyRow.Item("NumeroTramo")) Else Me.txtNumeroTramo.Text = String.Empty
    '        If Not IsDBNull(MyRow.Item("CantidadSeriesPorTramo")) Then Me.txtCantidadSeriesPorTramo.Text = Trim(MyRow.Item("CantidadSeriesPorTramo")) Else Me.txtCantidadSeriesPorTramo.Text = String.Empty
    '        If Not IsDBNull(MyRow.Item("FechaInicioColocacion")) Then Me.txtFechaInicioColocacion.DbSelectedDate = Trim(MyRow.Item("FechaInicioColocacion")) Else Me.txtFechaInicioColocacion.DbSelectedDate = String.Empty
    '        If Not IsDBNull(MyRow.Item("FechaDeEmision")) Then Me.txtFechaDeEmision.DbSelectedDate = Trim(MyRow.Item("FechaDeEmision")) Else Me.txtFechaDeEmision.DbSelectedDate = String.Empty
    '        If Not IsDBNull(MyRow.Item("FechaPlanVencimiento")) Then Me.txtFechaPlanVencimiento.DbSelectedDate = Trim(MyRow.Item("FechaPlanVencimiento")) Else Me.txtFechaPlanVencimiento.DbSelectedDate = String.Empty
    '        If Not IsDBNull(MyRow.Item("EmisionTramoID")) Then Me.EmisionTramoID.Text = Trim(MyRow.Item("EmisionTramoID")) Else Me.EmisionTramoID.Text = String.Empty
    '    Next
    'End Sub

    'Sub ActualizarTramo()

    '    Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
    '    Dim csql As String = String.Empty

    '    Try

    '        Dim Sql As String = " Update [EmisionTramo] set [NumeroTramo] = @NumeroTramo " &
    '       ",[CantidadSeriesPorTramo] = @CantidadSeriesPorTramo" &
    '       "  where  [EmisionTramoID]=@EmisionTramoID"

    '        Cnx.Open()
    '        Dim cmd As New SqlCommand(Sql, Cnx)


    '        cmd.Parameters.Add(New SqlParameter("@EmisionTramoID", SqlDbType.BigInt)).Value = ViewState("CodeTramo")
    '        cmd.Parameters.Add(New SqlParameter("@NumeroTramo", SqlDbType.Int)).Value = IIf(Me.txtNumeroTramo.Text.Length > 0, Me.txtNumeroTramo.Text, DBNull.Value)
    '        cmd.Parameters.Add(New SqlParameter("@CantidadSeriesPorTramo", SqlDbType.Int)).Value = IIf(Me.txtCantidadSeriesPorTramo.Text.Length > 0, Me.txtCantidadSeriesPorTramo.Text, DBNull.Value)

    '        cmd.ExecuteNonQuery()

    '        csql = oper.CovertirComandoATexto(cmd)
    '        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Tramo", "EditarEmision", csql)

    '    Catch sql_ex As SqlClient.SqlException

    '        If sql_ex.ErrorCode = -2146232060 Then
    '            ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no pudo ser actualizado."
    '            ValidatorFechaAprobacionBVRD.IsValid = False

    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '    Finally
    '        Cnx.Close()

    '    End Try
    'End Sub
    'Sub BorrarTramo()
    '    Dim ID As Integer = ViewState("CodeTramo")
    '    Dim VerificarAsociado As String = String.Empty
    '    VerificarAsociado = oper.ExecuteScalar("select Count(*) from EmisionSerie where EmisionTramoID ='" & ViewState("CodeTramo") & "'")
    '    VerificarAsociado = IIf(VerificarAsociado = String.Empty, "0", VerificarAsociado)

    '    If Integer.Parse(VerificarAsociado) > 0 Then
    '        InjectScriptLabel.Text = "<script>MensajePopup('No se puede borrar este tramo, tiene serires asociadas.')</" + "script>"

    '    Else
    '        Dim cSql As String = "delete from dbo.EmisionTramo where EmisionTramoID='" & ID & "'"
    '        oper.ExecuteNonQuery(cSql)
    '        InjectScriptLabelImprimir.Text = "<script>alert('Registro borrado exitosamente.')</" + "script>"
    '        RadGridTramo.Rebind()

    '        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Tramo", "EditarEmision", cSql)
    '    End If

    'End Sub
    'Sub LimpiaTramo()
    '    Me.txtNumeroTramo.Text = String.Empty
    '    Me.txtCantidadSeriesPorTramo.Text = String.Empty
    '    Me.txtFechaInicioColocacion.DbSelectedDate = String.Empty
    '    Me.txtFechaDeEmision.DbSelectedDate = String.Empty
    '    Me.txtFechaPlanVencimiento.DbSelectedDate = String.Empty
    '    Me.txtFechaRealVencimiento.DbSelectedDate = String.Empty
    'End Sub


    Sub EditarSerie()
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridSerie.SelectedItems
            ViewState("CodeEdit") = dataItem("EmisionSerieID").Text

            Dim MyWindow As New Telerik.Web.UI.RadWindow
            MyWindow.NavigateUrl = "EditarSeriePOPUP.aspx?EmisionSerieID=" & ViewState("CodeEdit") & "&EsNuevo=" & False
            MyWindow.VisibleOnPageLoad = True
            MyWindow.BackColor = Drawing.Color.Blue
            MyWindow.AutoSize = True
            RadWindowManager2.Windows.Clear()
            RadWindowManager2.Windows.Add(MyWindow)

        Next
    End Sub
    Function CantidadTramosDisponibles() As Integer
        Dim nRetorna As Integer = 0

        Dim cSql As String = "select CantidadTramos - isnull(TRA.Conteo,0)  from Emision " +
                                      "left outer join" +
                                      "(Select EmisionID, isnull(COUNT( EmisionTramoID ),0) as Conteo" +
                                      "        from EmisionTramo " +
                                      "group by EmisionID" +
                                      ") TRA on Emision.EmisionID = TRA.EmisionID" +
                                      "        where Emision.EmisionID = " + Me.Codigo.Text

        nRetorna = oper.ExecuteScalar(cSql)


        Return nRetorna
    End Function
    Function CantidadSeriesDisponibles() As Integer
        Dim nRetorna As Integer = 0
        Dim CodigoTramo As Integer = ViewState("CodeTramo")

        Dim cSql As String = "SELECT CantidadSeriesPorTramo - isnull(conteo,0) " +
        "FROM EmisionTramo " +
        "LEFT OUTER JOIN ( Select EmisionTramoID, isnull(COUNT(EmisionTramoID), 0) as conteo from EmisionSerie GROUP BY EmisionSerie.EmisionTramoID	) EMI " +
        "ON EmisionTramo.EmisionTramoID = EMI.EmisionTramoID " +
        "WHERE EmisionTramo.EmisionTramoID = " + CodigoTramo.ToString()


        nRetorna = oper.ExecuteScalar(cSql)

        Return nRetorna


    End Function

#End Region

#Region "Operaciones con Documento "
    Sub EditarDocumento()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vEmisionDocumento]  where  EmisionDocumentoID ='" & CInt(ViewState("CodeDocumento")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            '----------------------------------------------Documento -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFechaDocumento.DbSelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("TipoDocumentoID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("TipoDocumentoID"))
            If Not IsDBNull(MyRow.Item("nombre")) Then Me.txtNombreDoc.Text = Trim(MyRow.Item("nombre"))

        Next
    End Sub
    Sub InsertarDocumento(ByVal CodigoEmision As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try
            Dim Sql As String = "INSERT INTO  [EmisionDocumento] ([EmisionID] ,[Fecha],[nombre],[Adjunto],[TipoDocumentoID],[Archivo]) VALUES (@EmisionID ,@Fecha,@nombre,@Adjunto,@TipoDocumentoID,@Archivo)"

            Cnx.Open()

            Documento = ViewState("FileName")
            RutaDocumento = My.Computer.FileSystem.SpecialDirectories.Temp + "\" + Documento
            'RutaDocumento =  Server.MapPath("~/tmp/") + Documento


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = CodigoEmision
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Archivo", SqlDbType.VarChar)).Value = Documento
            cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreDoc.Text.Length > 0, Me.txtNombreDoc.Text, DBNull.Value)

            cmd.ExecuteNonQuery()

            DeleteFiles(Documento)

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisión Documento", "EditarEmision", csql)

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
                ValidatorFechaAprobacionBVRD.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try
    End Sub
    Sub ActualizarDocumento()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try

            '' Documento = ViewState("FileName")
            ''RutaDocumento = Server.MapPath("~/tmp/") + Documento


            Dim Sql As String = "Update EmisionDocumento set  [Fecha]=@Fecha,[nombre]=@nombre,[TipoDocumentoID]=@TipoDocumentoID  where  [EmisionDocumentoID]=@EmisionDocumentoID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionDocumentoID", SqlDbType.BigInt)).Value = ViewState("CodeDocumento")
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            ''cmd.Parameters.Add(New SqlParameter("@Archivo", SqlDbType.VarChar)).Value = Documento
            '' cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento) '' ConvierteBinario("C:\XP\Factura_Nelly.pdf") 'DBNull.Value
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreDoc.Text.Length > 0, Me.txtNombreDoc.Text, DBNull.Value)
            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisión Documento", "EditarEmision", csql)



            ''DeleteFiles()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no pudo ser actualizado."
                ValidatorFechaAprobacionBVRD.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try
    End Sub
    Sub BorrarDocumento()

        Dim dataitem As GridDataItem = RadGridDocumento.SelectedItems(0)
        Dim ID = dataitem("EmisionDocumentoID").Text
        Dim cSql As String = "delete from dbo.EmisionDocumento  where EmisionDocumentoID='" & ID & "'"
        oper.ExecuteNonQuery(cSql)
        LimpiaDocumento()

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisión Documento", "EditarEmision", cSql)

    End Sub
    Sub LimpiaDocumento()
        Me.txtFechaDocumento.DbSelectedDate = String.Empty
        Me.RadComboBox1.SelectedValue = 0
        Me.RadComboBox1.Text = String.Empty
        Me.txtNombreDoc.Text = String.Empty
    End Sub


#End Region

#Region "Operaciones con Calificaciones de Riesgo "
    Sub EditarCodeEmisionCalificacionRiesgo()
        Dim p As Integer = CInt(ViewState("CodeEmisionCalificacionRiesgo"))
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vEmisionCalificacionRiesgo]  where  EmisionCalificacionRiesgoID ='" & CInt(ViewState("CodeEmisionCalificacionRiesgo")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("EmpresaCalificadoraID")) Then Me.RadComboBoxEmpresaCalificadoraID.SelectedValue = Trim(MyRow.Item("EmpresaCalificadoraID"))
            If Not IsDBNull(MyRow.Item("RangoCalificacionID")) Then Me.RadComboBoxRangoCalificacion.SelectedValue = Trim(MyRow.Item("RangoCalificacionID"))
            If Not IsDBNull(MyRow.Item("TipoCalificacionRiesgoID")) Then Me.RadComboBoxTipoCalificacionRiesgo.SelectedValue = Trim(MyRow.Item("TipoCalificacionRiesgoID"))
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFechaCalificacionRiesgo.DbSelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("Nota")) Then Me.txtNota.Text = Trim(MyRow.Item("Nota")) Else Me.txtNota.Text = String.Empty
        Next
    End Sub
    Sub InsertarEmisionCalificacionRiesgo(ByVal CodeEmisionCalificacionRiesgo As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try

            Dim Sql As String = "INSERT INTO  [EmisionCalificacionRiesgo] ([EmisionID] " &
           ",[EmpresaCalificadoraID]" &
           ",[Fecha]" &
           ",[TipoCalificacionRiesgoID]" &
           ",[Nota],[RangoCalificacionID]) VALUES(@EmisionID " &
           ",@EmpresaCalificadoraID" &
           ",@Fecha " &
           ",@TipoCalificacionRiesgoID " &
           ",@Nota" &
           ",@RangoCalificacionID)"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = CodeEmisionCalificacionRiesgo
            cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmpresaCalificadoraID.Text.Length > 0, Me.RadComboBoxEmpresaCalificadoraID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaCalificacionRiesgo.DbSelectedDate.ToString.Length > 0, Me.txtFechaCalificacionRiesgo.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoCalificacionRiesgoID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoCalificacionRiesgo.Text.Length > 0, Me.RadComboBoxTipoCalificacionRiesgo.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNota.Text.Length > 0, Me.txtNota.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RangoCalificacionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxRangoCalificacion.Text.Length > 0, Me.RadComboBoxRangoCalificacion.SelectedValue, DBNull.Value)

            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisión CalificacionRiesgo", "EditarEmision", csql)

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
                ValidatorFechaAprobacionBVRD.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try
    End Sub
    Sub ActualizarEmisionCalificacionRiesgo()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try

            Dim Sql As String = "Update [EmisionCalificacionRiesgo] set [EmpresaCalificadoraID] = @EmpresaCalificadoraID" &
                    ",[Fecha] = @Fecha" &
                    ",[TipoCalificacionRiesgoID] = @TipoCalificacionRiesgoID " &
                     ",[Nota] = @Nota, [RangoCalificacionID]=@RangoCalificacionID where [EmisionCalificacionRiesgoID]= @EmisionCalificacionRiesgoID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionCalificacionRiesgoID", SqlDbType.BigInt)).Value = ViewState("CodeEmisionCalificacionRiesgo")
            cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmpresaCalificadoraID.Text.Length > 0, Me.RadComboBoxEmpresaCalificadoraID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaCalificacionRiesgo.DbSelectedDate.ToString.Length > 0, Me.txtFechaCalificacionRiesgo.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoCalificacionRiesgoID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxTipoCalificacionRiesgo.Text.Length > 0, Me.RadComboBoxTipoCalificacionRiesgo.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNota.Text.Length > 0, Me.txtNota.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RangoCalificacionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxRangoCalificacion.Text.Length > 0, Me.RadComboBoxRangoCalificacion.SelectedValue, DBNull.Value)

            cmd.ExecuteNonQuery()
            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisión CalificacionRiesgo", "EditarEmision", csql)


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no pudo ser actualizado."
                ValidatorFechaAprobacionBVRD.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()

        End Try
    End Sub
    Sub LimpiaEmisorCalificacionRiesgo()

        Me.txtFechaCalificacionRiesgo.DbSelectedDate = String.Empty
        Me.txtNota.Text = String.Empty

        With RadComboBoxEmpresaCalificadoraID
            .Text = String.Empty
            .ClearSelection()
        End With

        With RadComboBoxTipoCalificacionRiesgo
            .Text = String.Empty
            .ClearSelection()
        End With

        With RadComboBoxRangoCalificacion
            .Text = String.Empty
            .ClearSelection()
        End With



    End Sub
    Sub BorrarCalificacionRiesgo()

        Dim dataitem As GridDataItem = RadGridEmisionCalificacionRiesgo.SelectedItems(0)
        Dim ID = dataitem("EmisionCalificacionRiesgoID").Text
        Dim csql As String = "delete from dbo.EmisionCalificacionRiesgo  where EmisionCalificacionRiesgoID='" & ID & "'"
        oper.ExecuteNonQuery(csql)
        LimpiaEmisorCalificacionRiesgo()

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisión CalificacionRiesgo", "EditarEmision", csql)
    End Sub


#End Region

#Region "Puesto Bolsa Emisión"
    Sub EditarPuestoBolsa()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vEmisionPuestoBolsa]  where  EmisionPuestoBolsaID ='" & CInt(ViewState("CodePuestoBolsa")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            '----------------------------------------------Puesto de Bolsa-------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("PuestoBolsaID")) Then Me.RadComboBoxPuestoBolsaID.SelectedValue = Trim(MyRow.Item("PuestoBolsaID"))
            If Not IsDBNull(MyRow.Item("Nota")) Then txtNotaPuestoBolsa.Text = Trim(MyRow.Item("Nota"))
        Next
    End Sub
    Sub InsertarPuestoBolsa(ByVal CodigoEmision As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try
            Dim Sql As String = "INSERT INTO  [EmisionPuestoBolsa] ([EmisionID],[PuestoBolsaID],[Nota]) VALUES (@EmisionID ,@PuestoBolsaID,@Nota)"

            Cnx.Open()

            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = CodigoEmision
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBoxPuestoBolsaID.Text.Length > 0, Me.RadComboBoxPuestoBolsaID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNotaPuestoBolsa.Text.Length > 0, Me.txtNotaPuestoBolsa.Text, DBNull.Value)

            cmd.ExecuteNonQuery()


            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisión PuestoBolsa", "EditarEmision", csql)



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
                ValidatorFechaAprobacionBVRD.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try


    End Sub
    Sub ActualizarPuestoBolsa()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try

            Dim Sql As String = "Update [EmisionPuestoBolsa] set [PuestoBolsaID] = @PuestoBolsaID" &
                                ",[Nota] = @Nota where [EmisionPuestoBolsaID]= @EmisionPuestoBolsaID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionPuestoBolsaID", SqlDbType.BigInt)).Value = ViewState("CodePuestoBolsa")
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxPuestoBolsaID.Text.Length > 0, Me.RadComboBoxPuestoBolsaID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.NChar)).Value = IIf(Me.txtNotaPuestoBolsa.Text.Length > 0, Me.txtNotaPuestoBolsa.Text, DBNull.Value)

            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisión PuestoBolsa", "EditarEmision", csql)


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorFechaAprobacionBVRD.ErrorMessage = "Registro no pudo ser actualizado."
                ValidatorFechaAprobacionBVRD.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()

        End Try
    End Sub
    Sub BorrarPuestoBolsa()

        Dim dataitem As GridDataItem = RadGridEmisionPuestoBolsa.SelectedItems(0)
        Dim ID = dataitem("EmisionPuestoBolsaID").Text
        Dim csql As String = "delete from dbo.EmisionPuestoBolsa  where EmisionPuestoBolsaID='" & ID & "'"
        oper.ExecuteNonQuery(csql)

        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisión PuestoBolsa", "EditarEmision", csql)

    End Sub
    Sub LimpiaPuestoBolsa()

        With RadComboBoxPuestoBolsaID
            .Text = String.Empty
            .ClearSelection()
        End With

        Me.txtNotaPuestoBolsa.Text = String.Empty
    End Sub
#End Region


#Region "Barra de Herramientas ..."
    Protected Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick


        ValidatorCodigoSistema.Enabled = False
        ValidatorDireccionEmision.Enabled = False
        ValidatorFechaAprobacionBVRD.Enabled = False

        'ValidatorNumeroTramo.Enabled = False
        'ValidatorCantidadSeriesPorTramo.Enabled = False

        ValidatorEmpresaCalificadora.Enabled = False
        ValidatorFechaCalificacionRiesgo.Enabled = False

        ValidatorFechaDocumento.Enabled = False
        ValidatorTipoDocumento.Enabled = False

        Select Case Me.RadTabStrip1.SelectedIndex
            Case 0
                ViewState("EsNuevo") = False
            Case 1
                ViewState("EsNuevo") = True
            Case 2
                ViewState("EsNuevo") = True
            Case 3
                ViewState("EsNuevo") = True
            Case 4
                ViewState("EsNuevo") = True
        End Select

        If e.Tab.Index = 0 Then
            RadToolBar1.Items.Item(0).Enabled = False
        ElseIf e.Tab.Index = 2 Then 'Series
            RadToolBar1.Items.Item(0).Enabled = True
            RadToolBar1.Items.Item(2).Enabled = False
            RadToolBar1.Items.Item(3).Enabled = False
            RadToolBar1.Items.Item(5).Enabled = False
        Else
            RadToolBar1.Items.Item(0).Enabled = True
            RadToolBar1.Items.Item(2).Enabled = True
            RadToolBar1.Items.Item(3).Enabled = True
            RadToolBar1.Items.Item(5).Enabled = True
        End If

    End Sub
#End Region

#Region "Manejo de Archivos ..."
    Public Function ConvierteBinario(ByVal Path As String) As Byte()
        Dim sPath As String
        sPath = Path
        Dim Ruta As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim Binario(CInt(Ruta.Length)) As Byte
        Ruta.Read(Binario, 0, CInt(Ruta.Length))
        Ruta.Close()
        Return Binario
    End Function

    Sub LeerBinario(ByVal DocumentoID As Integer, ByVal DocumentoRuta As String, ByVal DocumentoNombre As String)
        Try

            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
            Dim Sql As String = "Select Adjunto,Archivo From EmisionDocumento Where EmisionDocumentoID ='" & DocumentoID & "'"

            Dim aBytDocumento() As Byte = Nothing
            Dim oFileStream As FileStream

            Using loComando As New SqlCommand(Sql, Cnx)
                Cnx.Open()
                Using drDocumentos As SqlDataReader = loComando.ExecuteReader(CommandBehavior.SingleRow)
                    If drDocumentos.Read() Then
                        aBytDocumento = CType(drDocumentos("Adjunto"), Byte())
                        DocumentoNombre = drDocumentos("Archivo").ToString().Replace(" ", String.Empty)
                    End If
                End Using
            End Using

            'Borrar archivo si existe
            DeleteFiles(DocumentoNombre)

            oFileStream = New FileStream(DocumentoRuta + "\" + DocumentoNombre, FileMode.CreateNew, FileAccess.Write)
            oFileStream.Write(aBytDocumento, 0, aBytDocumento.Length)
            oFileStream.Close()


            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("content-disposition", "attachment; filename=" + DocumentoNombre)
            Response.TransmitFile(DocumentoRuta + DocumentoNombre)

        Catch Exp As Exception
        End Try

    End Sub

    Function SubidaArchivo() As Boolean
        If RadUpload1.UploadedFiles.Count > 0 Then
            Try

                For Each validFile As UploadedFile In RadUpload1.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\" ' Server.MapPath("~/tmp/")
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    Button2.Enabled = False
                    RadUpload1.Visible = False
                    RadProgressArea1.Visible = False
                    Return True
                Next

            Catch ex As Exception
                Return False
            End Try
        Else
            Return False
        End If

        Return True

    End Function

    Private Sub DeleteFiles(cDocumento As String)
        Dim targetFolder As String = My.Computer.FileSystem.SpecialDirectories.Temp   ' Server.MapPath("~/tmp/")  
        Dim targetDir As New DirectoryInfo(targetFolder)
        Try
            For Each file As FileInfo In targetDir.GetFiles()
                If (file.Attributes And FileAttributes.[ReadOnly]) = 0 Then
                    If file.Name = cDocumento Then
                        Try
                            file.Delete()
                            Exit For
                        Catch e As IOException
                            Throw
                        End Try
                    End If

                End If
            Next
        Catch generatedExceptionName As IOException
            Throw
        End Try
    End Sub
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

            progress.CurrentOperationText = file.GetName() + " is being processed..."
            If Not Response.IsClientConnected Then
                Exit While
            End If
            System.Threading.Thread.Sleep(100)
            i = i + 1
        End While
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridDocumento.SelectedItems
            ViewState("DocumentoID") = dataItem("EmisionDocumentoID").Text
            ViewState("DocumentoNombre") = Trim(dataItem("NombreDocumento").Text)

            DeleteFiles(ViewState("DocumentoNombre"))


            'LeerBinario(ViewState("DocumentoID"), Server.MapPath("~/tmp/"), ViewState("DocumentoNombre"))

            LeerBinario(ViewState("DocumentoID"), My.Computer.FileSystem.SpecialDirectories.Temp + "\", ViewState("DocumentoNombre"))

        Next
    End Sub

#End Region

#Region "RadGrids ..."

    ' ----------------------------------------------------------------------------------
    ' Cuando se Selecciona la fila del Grid 
    ' ----------------------------------------------------------------------------------

    'Protected Sub RadGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridTramo.SelectedIndexChanged
    '    Dim dataitem As GridDataItem = RadGridTramo.SelectedItems(0)
    '    Dim ID = dataitem("EmisionTramoID").Text
    '    ViewState("CodeTramo") = ID
    '    ViewState("EsNuevo") = False
    '    Call EditarTramo()
    '    RadGridSerie.DataBind()
    'End Sub

    Protected Sub RadGridCorredor_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridEmisionCalificacionRiesgo.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridEmisionCalificacionRiesgo.SelectedItems(0)
        Dim ID = dataitem("EmisionCalificacionRiesgoID").Text
        ViewState("CodeEmisionCalificacionRiesgo") = ID
        ViewState("EsNuevo") = False
        Call EditarCodeEmisionCalificacionRiesgo()
    End Sub

    Protected Sub RadGridDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDocumento.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridDocumento.SelectedItems(0)
        Dim ID = dataitem("EmisionDocumentoID ").Text
        ViewState("CodeDocumento") = ID
        ViewState("EsNuevo") = False
        RadUpload1.Visible = True
        Call EditarDocumento()
    End Sub

    Protected Sub RadGridEmisionPuestoBolsa_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadGridEmisionPuestoBolsa.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridEmisionPuestoBolsa.SelectedItems(0)
        Dim ID = dataitem("EmisionPuestoBolsaID ").Text
        ViewState("CodePuestoBolsa") = ID
        ViewState("EsNuevo") = False
        EditarPuestoBolsa()
    End Sub

#End Region

#Region "Link Buttoms ..."



    ' ----------------------------------------------------------------------------------
    ' Clic de los link buttoms 
    ' ----------------------------------------------------------------------------------
    'Insertar nuevas series
    'Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridTramo.SelectedItems


    '        If CantidadSeriesDisponibles() > 0 Then

    '            ViewState("Code") = dataItem("EmisionTramoID").Text
    '            ViewState("EmisionID") = dataItem("EmisionID").Text

    '            Dim MyWindow As New Telerik.Web.UI.RadWindow
    '            MyWindow.NavigateUrl = "EditarSeriePOPUP.aspx?EmisionTramoID=" & ViewState("Code") & "&EmisionID=" & ViewState("EmisionID") & "&EsNuevo=" & True
    '            MyWindow.VisibleOnPageLoad = True
    '            MyWindow.BackColor = Drawing.Color.Blue
    '            MyWindow.AutoSize = True
    '            RadWindowManager2.Windows.Clear()
    '            RadWindowManager2.Windows.Add(MyWindow)
    '        Else

    '            InjectScriptLabel.Text = "<script>MensajePopup('No hay mas series disponibles para ingresar.')</" + "script>"

    '        End If

    '    Next
    'End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        EditarSerie()
    End Sub


    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SubidaArchivo() = True Then

            Try
                Dim targetFolder As String = My.Computer.FileSystem.SpecialDirectories.Temp '  Server.MapPath("~/tmp/")

                Dim dt As New DataTable()
                Dim line As String = Nothing
                Dim i As Integer = 0

                Using sr As StreamReader = File.OpenText(targetFolder & ViewState("FileName"))
                    line = sr.ReadLine()
                    Do While line IsNot Nothing
                        Dim data() As String = line.Split(","c)
                        If data.Length > 0 Then
                            If i = 0 Then
                                For Each item In data
                                    dt.Columns.Add(New DataColumn())
                                Next item
                                i += 1
                            End If
                            Dim row As DataRow = dt.NewRow()
                            row.ItemArray = data

                            dt.Rows.Add(row)
                        End If

                        line = sr.ReadLine()
                    Loop
                End Using

                Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                    cn.Open()
                    Using copy As New SqlBulkCopy(cn)
                        copy.ColumnMappings.Add(0, 0)
                        copy.ColumnMappings.Add(1, 1)
                        copy.ColumnMappings.Add(2, 2)
                        copy.ColumnMappings.Add(3, 3)
                        copy.ColumnMappings.Add(4, 4)
                        copy.ColumnMappings.Add(5, 5)
                        copy.ColumnMappings.Add(6, 6)
                        copy.ColumnMappings.Add(7, 7)
                        copy.ColumnMappings.Add(8, 8)
                        copy.DestinationTableName = "Activos"
                        copy.WriteToServer(dt)
                    End Using
                End Using


            Catch ex As Exception

            End Try
        End If

    End Sub

#End Region







End Class
