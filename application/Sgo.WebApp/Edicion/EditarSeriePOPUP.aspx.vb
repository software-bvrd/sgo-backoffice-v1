Imports Ninject
Imports Sgo.DataAccess.Infrastructure
Imports Sgo.Model.Entities
Imports System.Data.SqlClient
Imports System.Globalization
Imports Telerik.Web.UI
Imports System.IO

Partial Class Edicion_EditarSeriePOPUP
    Inherits PageBase
    Private oper As New operation
    Private Documento As String
    Private RutaDocumento As String

    <Inject()>
    Property TipoLiquidacionRepo As IRepository(Of Tipoliquidacion)

    <Inject()>
    Property DiaFestivoRepo As IRepository(Of Diafestivo)
    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")   

            Dim pro As String = Session("Code")
            ViewState("CodeEmision") = Session("Code")
            ViewState("EmisionID") = Request.QueryString("EmisionID")

            If ViewState("EsNuevo") = True Then
                ViewState("Code") = Request.QueryString("EmisionTramoID")
                RadToolBar1.Items.Item(2).Enabled = False

                '-----------------------------------------------------------------------------------
                'Página de Incrementos, Redencion, Amortización, Titularizado Inhabilitada (Nuevo)
                '-----------------------------------------------------------------------------------
                Pagina2.Enabled = False
                Pagina3.Enabled = False
                Pagina4.Enabled = False
                Pagina5.Enabled = False

                '--- Tasa de Interes, Spread ---
                txtTasa.Text = "0"
                txtSpread.Text = "0"

                ' melvinhoy Call EditarSerie()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then

                ViewState("CodeEdit") = Request.QueryString("EmisionSerieID")

                Dim cSQLOpciones As String = "Select count(*) from dbo.OpcionesEditables where IdUsuario = '" & Session("IdUsuario") & "' And IdOpcionesMenu = 30"
                Dim Edita As Int32 = Convert.ToInt32(oper.ExecuteScalar(cSQLOpciones))

                If Edita = 0 Then
                    ' BolEditarSerie = False
                    Session("EditarSerie") = 0
                    CodigoSerie.Enabled = False
                    Serie.Enabled = False
                    Call EditarSerie()
                Else
                    Session("EditarSerie") = 1
                    CodigoSerie.Enabled = True
                    Serie.Enabled = True
                    Call EditarSerie()
                End If


                '-------------------------------------------------------------------------
                'Página de Incrementos Inhabilitada (Cuando la Emision No Cumple)
                '-------------------------------------------------------------------------
                Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                    Dim lCodigoSerie As String = String.Empty
                    Dim strSql As String = "SELECT count(Emision.EmisionID) as EmisionID " &
                                       " FROM Emision INNER JOIN " &
                                       " EmisionTramo ON Emision.EmisionID = EmisionTramo.EmisionID INNER JOIN " &
                                       " EmisionSerie ON EmisionTramo.EmisionTramoID = EmisionSerie.EmisionTramoID " &
                                       " WHERE (Emision.TipoInstrumentoID IN (37, 41)) and EmisionSerieID = " & Request.QueryString("EmisionSerieID")
                    Cnx.Open()

                    lCodigoSerie = oper.ExecuteScalar(strSql)
                    If lCodigoSerie = "0" Then
                        Pagina2.Enabled = False
                        ViewState("PuedeEditarMonto") = False
                    Else
                        Pagina2.Enabled = True
                        ViewState("PuedeEditarMonto") = True
                    End If

                    Cnx.Close()


                    Call EditarSerie()

                End If

                ' -------------------------------------------------
                ' Para Habilitar o no el boton nuevo
                ' -------------------------------------------------
                If RadTabStrip1.Tabs.Item(0).Enabled = True Then
                RadToolBar1.Items.Item(0).Enabled = False
                RadToolBar1.Items.Item(0).Visible = False

            ElseIf RadTabStrip1.Tabs.Item(1).Enabled = True Then
                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(0).Visible = True

            ElseIf RadTabStrip1.Tabs.Item(2).Enabled = True Then
                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(0).Visible = True

            ElseIf RadTabStrip1.Tabs.Item(3).Enabled = True Then
                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(0).Visible = True

            ElseIf RadTabStrip1.Tabs.Item(4).Enabled = True Then
                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(0).Visible = True

            End If


            Serie.Focus()

        End If

        Try

            'Borrar Serie  utilizando la confirmacion del usuario
            If Request.Params("__EVENTTARGET") = "borrar" Then
                BorrarSerie()
            End If

            If ViewState("CodeDocumento") > 0 And Val(txtMonto.Text) > 0 Then

                If Request.Params("__EVENTTARGET") = "borrarincremento" Then
                    BorrarSerieIncremento()
                End If

            End If

        Catch ex As Exception
            Throw
        End Try

        InjectScriptLabel.Text = String.Empty
        InjectScriptLabelIncrem.Text = String.Empty


    End Sub

    ''' <summary>
    ''' Validar que código de la serie Exista en otro programa de Emisiones
    ''' </summary>
    Sub ValidaExisteCodigo()
        On Error Resume Next
        Dim ds1 As DataSet = oper.ExDataSet("SELECT * FROM EmisionSerie where CodigoSerie = '" & Me.CodigoSerie.Text & "' ")

        If ds1.Tables(0).Rows.Count > 0 Then
            Dim MyRow1 As DataRow
            For Each MyRow1 In ds1.Tables(0).Rows
                ViewState("CodigoSerie") = Trim(MyRow1.Item("CodigoSerie"))
            Next
        End If

    End Sub

    Sub ValidaExisteCodigoID()
        On Error Resume Next
        Dim ds1 As DataSet = oper.ExDataSet("SELECT * FROM EmisionSerie where CodigoSerie  ='" & Me.CodigoSerie.Text & "' and EmisionSerieID <> '" & ViewState("CodeEdit") & "' ")

        If ds1.Tables(0).Rows.Count > 0 Then

            Dim MyRow1 As DataRow

            For Each MyRow1 In ds1.Tables(0).Rows

                ViewState("CodigoSerie") = Trim(MyRow1.Item("CodigoSerie"))
                ViewState("vEmisionSerieID") = Trim(MyRow1.Item("EmisionSerieID"))
            Next
        End If

    End Sub



#Region "Datos Generales"

    ''' <summary>
    ''' Buscar información de la Emisión y presentarlo en pantalla
    ''' </summary>
    Sub EditarSerie()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vEmisionSerie]  where  EmisionSerieID ='" & CInt(ViewState("CodeEdit")) & "'")
        Dim MyRow As DataRow


        If ds.Tables(0).Rows.Count > 0 Then
            For Each MyRow In ds.Tables(0).Rows

                '--------------------------------------------Directivo -------------------------------------------------------------------------
                If Not IsDBNull(MyRow.Item("Serie")) Then Me.Serie.Text = Trim(MyRow.Item("Serie")) Else Me.Serie.Text = String.Empty
                If Not IsDBNull(MyRow.Item("CodigoSerie")) Then Me.CodigoSerie.Text = Trim(MyRow.Item("CodigoSerie")) Else Me.CodigoSerie.Text = String.Empty
                If Not IsDBNull(MyRow.Item("idTipotasa")) Then Me.RadComboBoxIdTipotasa.SelectedValue = Trim(MyRow.Item("idTipotasa"))


                If Not IsDBNull(MyRow.Item("CodigoISIN")) Then Me.CodigoISIN.Text = Trim(MyRow.Item("CodigoISIN")) Else Me.CodigoISIN.Text = String.Empty

                If Not IsDBNull(MyRow.Item("FechaEmision")) Then Me.FechaEmision.DbSelectedDate = Trim(MyRow.Item("FechaEmision")) Else Me.FechaEmision.DbSelectedDate = String.Empty
                If Not IsDBNull(MyRow.Item("FechaVencimiento")) Then Me.FechaVencimiento.DbSelectedDate = Trim(MyRow.Item("FechaVencimiento")) Else Me.FechaVencimiento.DbSelectedDate = String.Empty
                If Not IsDBNull(MyRow.Item("FechaLiquidacion")) Then Me.FechaLiquidacion.DbSelectedDate = Trim(MyRow.Item("FechaLiquidacion")) Else Me.FechaLiquidacion.DbSelectedDate = String.Empty


                If Not IsDBNull(MyRow.Item("TipoLiquidacionID")) Then Me.RadComboBoxTipoLiquidacionID.SelectedValue = Trim(MyRow.Item("TipoLiquidacionID"))
                If Not IsDBNull(MyRow.Item("TipoPeriodoID")) Then Me.RadComboBoxTipoPeriodoID.SelectedValue = Trim(MyRow.Item("TipoPeriodoID"))


                If Not IsDBNull(MyRow.Item("ValorUnitarioNominal")) Then Me.ValorUnitarioNominal.Text = Trim(MyRow.Item("ValorUnitarioNominal")) Else Me.ValorUnitarioNominal.Text = String.Empty
                If Not IsDBNull(MyRow.Item("ValorNominalUnitarioSerie")) Then Me.txtValorNominalUnitarioSerie.Text = Trim(MyRow.Item("ValorNominalUnitarioSerie")) Else Me.txtValorNominalUnitarioSerie.Text = String.Empty
                If Not IsDBNull(MyRow.Item("CantidadTitulos")) Then Me.txtCantidadTitulos.Text = Trim(MyRow.Item("CantidadTitulos")) Else Me.txtCantidadTitulos.Text = String.Empty
                If Not IsDBNull(MyRow.Item("InversionMinima")) Then Me.InversionMinima.Text = Trim(MyRow.Item("InversionMinima")) Else Me.InversionMinima.Text = String.Empty
                If Not IsDBNull(MyRow.Item("InversionMaxima")) Then Me.InversionMaxima.Text = Trim(MyRow.Item("InversionMaxima")) Else Me.InversionMaxima.Text = String.Empty


                ' Redencion (Pasa a una Tabla) Quitar 
                If Not IsDBNull(MyRow.Item("FechaRedencion")) Then Me.FechaRedencion.DbSelectedDate = Trim(MyRow.Item("FechaRedencion")) Else Me.FechaRedencion.DbSelectedDate = String.Empty
                If Not IsDBNull(MyRow.Item("ValorRedencion")) Then Me.ValorRedencion.Text = String.Empty
                If Not IsDBNull(MyRow.Item("NotaRedencion")) Then Me.txtNotaRedencion.Text = String.Empty


                If Not IsDBNull(MyRow.Item("Tasa")) Then Me.txtTasa.Text = Trim(MyRow.Item("Tasa")) Else Me.txtTasa.Text = String.Empty

                If txtTasa.Text = String.Empty Then
                    txtTasa.Enabled = False
                End If

                If Not IsDBNull(MyRow.Item("BaseLiquidacionID")) Then Me.RadcomboBoxBaseLiquidacion.SelectedValue = Trim(MyRow.Item("BaseLiquidacionID"))

                If Not IsDBNull(MyRow.Item("FechaInicioColocacion")) Then Me.FechaInicioColocacion.DbSelectedDate = Trim(MyRow.Item("FechaInicioColocacion")) Else Me.FechaInicioColocacion.DbSelectedDate = String.Empty
                If Not IsDBNull(MyRow.Item("FechaFinalColocacion")) Then Me.FechaFinalColocacion.DbSelectedDate = Trim(MyRow.Item("FechaFinalColocacion")) Else Me.FechaFinalColocacion.DbSelectedDate = String.Empty

                If Not IsDBNull(MyRow.Item("Spread")) Then Me.txtSpread.Text = Trim(MyRow.Item("Spread")) Else Me.txtSpread.Text = String.Empty

                If txtSpread.Text = String.Empty Then
                    txtSpread.Enabled = False
                End If

                '-- 2014.05.07

                If Not IsDBNull(MyRow.Item("InversionMaximaIG")) Then Me.InversionMaximaIG.Text = Trim(MyRow.Item("InversionMaximaIG")) Else Me.InversionMaxima.Text = String.Empty
                If Not IsDBNull(MyRow.Item("DiasInversionMaximaIG")) Then Me.RadComboBoxDiasInversionMaximaIG.SelectedValue = Trim(MyRow.Item("DiasInversionMaximaIG"))

                '-- 2015.12.29

                If Not IsDBNull(MyRow.Item("FechaInicioColocacionIP")) Then Me.FechaInicioColocacionIP.DbSelectedDate = Trim(MyRow.Item("FechaInicioColocacionIP")) Else Me.FechaInicioColocacionIP.DbSelectedDate = String.Empty
                If Not IsDBNull(MyRow.Item("FechaFinalColocacionIP")) Then Me.FechaFinalColocacionIP.DbSelectedDate = Trim(MyRow.Item("FechaFinalColocacionIP")) Else Me.FechaFinalColocacionIP.DbSelectedDate = String.Empty

                If Not IsDBNull(MyRow.Item("FechaInicioColocacionIG")) Then Me.FechaInicioColocacionIG.DbSelectedDate = Trim(MyRow.Item("FechaInicioColocacionIG")) Else Me.FechaInicioColocacionIG.DbSelectedDate = String.Empty
                If Not IsDBNull(MyRow.Item("FechaFinalColocacionIG")) Then Me.FechaFinalColocacionIG.DbSelectedDate = Trim(MyRow.Item("FechaFinalColocacionIG")) Else Me.FechaFinalColocacionIG.DbSelectedDate = String.Empty


                '-- 2016.05.31

                If Not IsDBNull(MyRow.Item("TipoAmortizacionCapitalID")) Then Me.RadComboBoxTipoAmortizacionCapitalID.SelectedValue = Trim(MyRow.Item("TipoAmortizacionCapitalID"))
                If Not IsDBNull(MyRow.Item("NotaTipoAmortizacionCapital")) Then Me.txtNotaTipoAmortizacionCapital.Text = Trim(MyRow.Item("NotaTipoAmortizacionCapital")) Else Me.txtNotaTipoAmortizacionCapital.Text = String.Empty

                '-- 2017.01.10

                If Not IsDBNull(MyRow.Item("MontoBaseParaComision")) Then Me.MontoBaseParaComision.Text = Trim(MyRow.Item("MontoBaseParaComision")) Else Me.MontoBaseParaComision.Text = String.Empty
                If Not IsDBNull(MyRow.Item("FechaMontoBase")) Then Me.FechaMontoBase.DbSelectedDate = Trim(MyRow.Item("FechaMontoBase")) Else Me.FechaMontoBase.DbSelectedDate = String.Empty

                '-- 2018.01.21
                If Not IsDBNull(MyRow.Item("Estatus")) Then Me.cbEstatus.SelectedValue = Trim(MyRow.Item("Estatus"))

                '-- 2018.03.09
                If Not IsDBNull(MyRow.Item("IndiceConversionLiquidacion")) Then Me.cbIndiceConversionLiquidacion.SelectedValue = Trim(MyRow.Item("IndiceConversionLiquidacion"))

                '-- 2019.03.20 MELVIN CASTILLO
                If Not IsDBNull(MyRow.Item("ContemplaRedencion")) Then Me.cbContemplaRedencion.Checked = Trim(MyRow.Item("ContemplaRedencion"))
                If Not IsDBNull(MyRow.Item("ContemplaRedencionFecha")) Then Me.txtFechaContemplaRedencion.DbSelectedDate = Trim(MyRow.Item("ContemplaRedencionFecha"))



            Next

        Else
            Me.Serie.Text = String.Empty
            Me.CodigoSerie.Text = String.Empty
            'Me.RadComboBoxIdTipotasa.SelectedValue = String.Empty
            Me.CodigoISIN.Text = String.Empty
            'Me.FechaEmision.DbSelectedDate = String.Empty
            'Me.FechaVencimiento.DbSelectedDate = String.Empty
            'Me.FechaLiquidacion.DbSelectedDate = String.Empty
            'Me.RadComboBoxTipoLiquidacionID.SelectedValue = String.Empty
            'Me.RadComboBoxTipoPeriodoID.SelectedValue = String.Empty
            Me.ValorUnitarioNominal.Text = String.Empty
            Me.txtValorNominalUnitarioSerie.Text = String.Empty
            Me.txtCantidadTitulos.Text = String.Empty
            Me.InversionMinima.Text = String.Empty
            Me.InversionMaxima.Text = String.Empty
            ' Redencion (Pasa a una Tabla) Quitar 
            'Me.FechaRedencion.DbSelectedDate = String.Empty
            Me.ValorRedencion.Text = String.Empty
            Me.txtNotaRedencion.Text = String.Empty
            Me.txtTasa.Text = String.Empty

            If txtTasa.Text = String.Empty Then
                txtTasa.Enabled = False
            End If
            'Me.RadcomboBoxBaseLiquidacion.SelectedValue = String.Empty
            'Me.FechaInicioColocacion.DbSelectedDate = String.Empty
            'Me.FechaFinalColocacion.DbSelectedDate = String.Empty
            Me.txtSpread.Text = String.Empty

            If txtSpread.Text = String.Empty Then
                txtSpread.Enabled = False
            End If

            Me.InversionMaxima.Text = String.Empty
            'Me.RadComboBoxDiasInversionMaximaIG.SelectedValue = String.Empty
            'Me.FechaInicioColocacionIP.DbSelectedDate = String.Empty
            'Me.FechaFinalColocacionIP.DbSelectedDate = String.Empty
            'Me.FechaInicioColocacionIG.DbSelectedDate = String.Empty
            'Me.FechaFinalColocacionIG.DbSelectedDate = String.Empty
            'Me.RadComboBoxTipoAmortizacionCapitalID.SelectedValue = String.Empty
            Me.txtNotaTipoAmortizacionCapital.Text = String.Empty
            Me.MontoBaseParaComision.Text = String.Empty
            'Me.FechaMontoBase.DbSelectedDate = String.Empty
            'Me.cbEstatus.SelectedValue = 1
            'Me.cbIndiceConversionLiquidacion.SelectedValue = String.Empty
            'Me.cbContemplaRedencion.Checked = String.Empty
            'Me.txtFechaContemplaRedencion.DbSelectedDate = String.Empty

        End If

    End Sub
    Sub InsertarSerie(ByVal CodigoEmisionTramo As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim cSql As String = String.Empty


        ' -----------------------------------------------------------------------------------------
        ' Determinar si existe un tramo para la emision o Crear 1
        ' -----------------------------------------------------------------------------------------
        cSql = "Select EmisionTramoID from EmisionTramo where EmisionID = " + ViewState("EmisionID")
        Dim cCodigoTramo As String = oper.ExecuteScalar(cSql)

        If cCodigoTramo = String.Empty Then
            InsertarTramo()
        End If

        cCodigoTramo = oper.ExecuteScalar(cSql)


        Try
            Dim Sql As String = "INSERT INTO EmisionSerie ([EmisionTramoID] " &
           ",[Serie]" &
           ",[CodigoSerie]" &
           ",[idTipotasa]" &
           ",[CodigoISIN]" &
           ",[FechaEmision]" &
           ",[FechaVencimiento]" &
           ",[FechaLiquidacion]" &
           ",[TipoLiquidacionID]" &
           ",[ValorUnitarioNominal]" &
           ",[ValorNominalUnitarioSerie]" &
           ",[CantidadTitulos]" &
           ",[InversionMinima]" &
           ",[tasa]" &
           ",[InversionMaxima]" &
           ",[TipoPeriodoID]" &
           ",[FechaInicioColocacion]" &
           ",[FechaFinalColocacion]" &
           ",[BaseLiquidacionID]" &
           ",[Spread]" &
           ",[FechaRedencion]" &
           ",[ValorRedencion]" &
           ",[NotaRedencion]" &
           ",[InversionMaximaIG]" &
           ",[DiasInversionMaximaIG]" &
           ",[FechaInicioColocacionIP]" &
           ",[FechaFinalColocacionIP]" &
           ",[FechaInicioColocacionIG]" &
           ",[FechaFinalColocacionIG]" &
           ",[TipoAmortizacionCapitalID]" &
           ",[NotaTipoAmortizacionCapital]" &
           ",[MontoBaseParaComision]" &
           ",[FechaMontoBase]" &
           ",[Estatus]" &
           ",[IndiceConversionLiquidacion]" &
           ",[ContemplaRedencion]" &
           ",[ContemplaRedencionFecha]" &
           ")  VALUES (@EmisionTramoID " &
           " ,@Serie" &
           " ,@CodigoSerie" &
           " ,@idTipotasa" &
           " ,@CodigoISIN" &
           " ,@FechaEmision" &
           " ,@FechaVencimiento" &
           " ,@FechaLiquidacion" &
           " ,@TipoLiquidacionID" &
           " ,@ValorUnitarioNominal" &
           " ,@ValorNominalUnitarioSerie" &
           " ,@CantidadTitulos" &
           " ,@InversionMinima" &
           " ,@tasa" &
           " ,@InversionMaxima" &
           " ,@TipoPeriodoID" &
           " ,@FechaInicioColocacion" &
           " ,@FechaFinalColocacion" &
           " ,@BaseLiquidacionID" &
           " ,@Spread" &
           " ,@FechaRedencion" &
           " ,@ValorRedencion" &
           " ,@NotaRedencion" &
           " ,@InversionMaximaIG" &
           " ,@DiasInversionMaximaIG" &
           " ,@FechaInicioColocacionIP" &
           " ,@FechaFinalColocacionIP" &
           " ,@FechaInicioColocacionIG" &
           " ,@FechaFinalColocacionIG" &
           " ,@TipoAmortizacionCapitalID" &
           " ,@NotaTipoAmortizacionCapital" &
           " ,@MontoBaseParaComision" &
           " ,@FechaMontoBase" &
           " ,@Estatus" &
           " ,@IndiceConversionLiquidacion" &
           " ,@ContemplaRedencion" &
           " ,@ContemplaRedencionFecha" &
           ")"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionTramoID", SqlDbType.BigInt)).Value = cCodigoTramo
            cmd.Parameters.Add(New SqlParameter("@Serie", SqlDbType.NChar)).Value = IIf(Me.Serie.Text.Length > 0, Me.Serie.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoSerie", SqlDbType.NChar)).Value = IIf(Me.CodigoSerie.Text.Length > 0, Me.CodigoSerie.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@idTipotasa", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxIdTipotasa.Text.Length > 0, Me.RadComboBoxIdTipotasa.SelectedValue, 1)

            cmd.Parameters.Add(New SqlParameter("@CodigoISIN", SqlDbType.NChar)).Value = IIf(Me.CodigoISIN.Text.ToString.Length > 0, Me.CodigoISIN.Text, DBNull.Value)

            If Me.FechaEmision.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaEmision", SqlDbType.Date)).Value = IIf(Me.FechaEmision.DbSelectedDate.ToString.Length > 0, Me.FechaEmision.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaEmision", SqlDbType.Date)).Value = DBNull.Value
            End If


            If Me.FechaVencimiento.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaVencimiento", SqlDbType.Date)).Value = IIf(Me.FechaVencimiento.DbSelectedDate.ToString.Length > 0, Me.FechaVencimiento.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaVencimiento", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaLiquidacion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLiquidacion", SqlDbType.Date)).Value = IIf(Me.FechaLiquidacion.DbSelectedDate.ToString.Length > 0, Me.FechaLiquidacion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLiquidacion", SqlDbType.Date)).Value = Today.Date
            End If

            If Me.FechaRedencion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaRedencion", SqlDbType.Date)).Value = IIf(Me.FechaRedencion.DbSelectedDate.ToString.Length > 0, Me.FechaRedencion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaRedencion", SqlDbType.Date)).Value = DBNull.Value
            End If


            cmd.Parameters.Add(New SqlParameter("@TipoLiquidacionID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoLiquidacionID.Text.Length > 0, Me.RadComboBoxTipoLiquidacionID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoPeriodoID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoPeriodoID.Text.Length > 0, Me.RadComboBoxTipoPeriodoID.SelectedValue, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@ValorUnitarioNominal", SqlDbType.Money)).Value = IIf(Me.ValorUnitarioNominal.Text.ToString.Length > 0, Me.ValorUnitarioNominal.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@ValorNominalUnitarioSerie", SqlDbType.Money)).Value = IIf(Me.txtValorNominalUnitarioSerie.Text.ToString.Length > 0, Me.txtValorNominalUnitarioSerie.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@CantidadTitulos", SqlDbType.BigInt)).Value = IIf(Me.txtCantidadTitulos.Text.ToString.Length > 0, Me.txtCantidadTitulos.Text, 0)

            cmd.Parameters.Add(New SqlParameter("@InversionMinima", SqlDbType.Money)).Value = IIf(Me.InversionMinima.Text.ToString.Length > 0, Me.InversionMinima.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@InversionMaxima", SqlDbType.Money)).Value = IIf(Me.InversionMaxima.Text.ToString.Length > 0, Me.InversionMaxima.Text, 0)

            cmd.Parameters.Add(New SqlParameter("@Tasa", SqlDbType.Decimal)).Value = IIf(Me.txtTasa.Text.ToString.Length > 0, Me.txtTasa.Text, 0)

            ' cmd.Parameters.Add(New SqlParameter("@ValorRedencion", SqlDbType.Money)).Value = IIf(Me.ValorRedencion.Text.ToString.Length > 0, Me.ValorRedencion.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@ValorRedencion", SqlDbType.Money)).Value = IIf(Me.ValorRedencion.Text.ToString.Length > 0, Me.ValorRedencion.Text, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@NotaRedencion", SqlDbType.VarChar)).Value = IIf(Me.txtNotaRedencion.Text.ToString.Length > 0, Me.txtNotaRedencion.Text, DBNull.Value)


            If Me.FechaInicioColocacion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacion.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaFinalColocacion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacion.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = DBNull.Value
            End If


            cmd.Parameters.Add(New SqlParameter("@BaseLiquidacionID", SqlDbType.BigInt)).Value = IIf(Me.RadcomboBoxBaseLiquidacion.Text.Length > 0, Me.RadcomboBoxBaseLiquidacion.SelectedValue, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Spread", SqlDbType.Decimal)).Value = IIf(Me.txtSpread.Text.ToString.Length > 0, Me.txtSpread.Text, 0)


            cmd.Parameters.Add(New SqlParameter("@InversionMaximaIG", SqlDbType.Money)).Value = IIf(Me.InversionMaximaIG.Text.ToString.Length > 0, Me.InversionMaximaIG.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@DiasInversionMaximaIG", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxDiasInversionMaximaIG.Text.Length > 0, Me.RadComboBoxDiasInversionMaximaIG.SelectedValue, DBNull.Value)

            ' Fecha Inicio y Final de Inversionistas

            If Me.FechaInicioColocacionIP.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIP", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacionIP.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacionIP.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIP", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaFinalColocacionIP.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIP", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacionIP.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacionIP.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIP", SqlDbType.Date)).Value = DBNull.Value
            End If


            If Me.FechaInicioColocacionIG.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIG", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacionIG.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacionIG.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIG", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaFinalColocacionIG.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIG", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacionIG.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacionIG.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIG", SqlDbType.Date)).Value = DBNull.Value
            End If

            ' 2016.05.31
            cmd.Parameters.Add(New SqlParameter("@TipoAmortizacionCapitalID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoAmortizacionCapitalID.Text.Length > 0, Me.RadComboBoxTipoAmortizacionCapitalID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NotaTipoAmortizacionCapital", SqlDbType.VarChar)).Value = IIf(Me.txtNotaTipoAmortizacionCapital.Text.ToString.Length > 0, Me.txtNotaTipoAmortizacionCapital.Text, String.Empty)

            ' 2017.01.07
            cmd.Parameters.Add(New SqlParameter("@MontoBaseParaComision", SqlDbType.Money)).Value = IIf(Me.MontoBaseParaComision.Text.ToString.Length > 0, Me.MontoBaseParaComision.Text, 0)

            If Me.FechaMontoBase.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaMontoBase", SqlDbType.Date)).Value = IIf(Me.FechaMontoBase.DbSelectedDate.ToString.Length > 0, Me.FechaMontoBase.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaMontoBase", SqlDbType.Date)).Value = DBNull.Value
            End If
            ' 2018.01.21
            cmd.Parameters.Add(New SqlParameter("@Estatus", SqlDbType.VarChar)).Value = IIf(Me.cbEstatus.Text.Length > 0, Me.cbEstatus.SelectedValue, DBNull.Value)

            ' 2018.03.09
            cmd.Parameters.Add(New SqlParameter("@IndiceConversionLiquidacion", SqlDbType.BigInt)).Value = IIf(Me.cbIndiceConversionLiquidacion.Text.Length > 0, Me.cbIndiceConversionLiquidacion.SelectedValue, 0)

            ' 2019.03.20 MELVIN CASTILLO
            cmd.Parameters.Add(New SqlParameter("@ContemplaRedencion", SqlDbType.NChar)).Value = Me.cbContemplaRedencion.Checked

            If Me.txtFechaContemplaRedencion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = IIf(Me.txtFechaContemplaRedencion.DbSelectedDate.ToString.Length > 0, Me.txtFechaContemplaRedencion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = DBNull.Value
            End If


            cmd.ExecuteNonQuery()


            cSql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisión Serie", "EditarEmision", cSql)
            Response.Write("<script>window.open ('https://apms.bvrd.local/reportes/Comisiones/ReporteComisionNuevoEmisor.aspx','_blank');</script>")

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorSerie.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
                ValidatorSerie.IsValid = False
                Exit Sub
            End If

        Catch ex As Exception

        Finally
            Notification1.Text = "Guardado con éxito!"
            Notification1.Show()

            Cnx.Close()

        End Try
    End Sub
    Sub ActualizarSerie()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim cSql As String = String.Empty
        Try

            Dim Sql As String = " Update [EmisionSerie] set " &
             "[Serie] = @Serie " &
             ",[CodigoSerie] = @CodigoSerie" &
             ",[idTipotasa] = @idTipotasa" &
             ",[CodigoISIN] = @CodigoISIN" &
             ",[FechaEmision] = @FechaEmision" &
             ",[FechaVencimiento] = @FechaVencimiento" &
             ",[FechaLiquidacion] = @FechaLiquidacion" &
             ",[TipoLiquidacionID] = @TipoLiquidacionID" &
             ",[TipoPeriodoID] = @TipoPeriodoID" &
             ",[ValorUnitarioNominal] = @ValorUnitarioNominal" &
             ",[ValorNominalUnitarioSerie] = @ValorNominalUnitarioSerie" &
             ",[CantidadTitulos] = @CantidadTitulos" &
             ",[InversionMinima] = @InversionMinima,[InversionMaxima] = @InversionMaxima" &
             ",[Tasa] = @Tasa" &
             ",[FechaInicioColocacion]=@FechaInicioColocacion" &
             ",[FechaFinalColocacion]=@FechaFinalColocacion" &
             ",[BaseLiquidacionID]=@BaseLiquidacionID" &
             ",[Spread]=@Spread" &
             ",[FechaRedencion]=@FechaRedencion" &
             ",[ValorRedencion]=@ValorRedencion" &
             ",[NotaRedencion]=@NotaRedencion" &
             ",[InversionMaximaIG]=@InversionMaximaIG" &
             ",[DiasInversionMaximaIG]=@DiasInversionMaximaIG" &
             ",[FechaInicioColocacionIP]=@FechaInicioColocacionIP" &
             ",[FechaFinalColocacionIP]=@FechaFinalColocacionIP" &
             ",[FechaInicioColocacionIG]=@FechaInicioColocacionIG" &
             ",[FechaFinalColocacionIG]=@FechaFinalColocacionIG" &
             ",[TipoAmortizacionCapitalID]=@TipoAmortizacionCapitalID" &
             ",[NotaTipoAmortizacionCapital]=@NotaTipoAmortizacionCapital" &
             ",[MontoBaseParaComision]=@MontoBaseParaComision" &
             ",[FechaMontoBase]=@FechaMontoBase" &
             ",[Estatus]=@Estatus" &
             ",[IndiceConversionLiquidacion]=@IndiceConversionLiquidacion" &
             ",[ContemplaRedencion]=@ContemplaRedencion" &
             ",[ContemplaRedencionFecha]=@ContemplaRedencionFecha" &
             "  where  [EmisionSerieID]=@EmisionSerieID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = ViewState("CodeEdit")
            cmd.Parameters.Add(New SqlParameter("@Serie", SqlDbType.NChar)).Value = IIf(Me.Serie.Text.Length > 0, Me.Serie.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoSerie", SqlDbType.NChar)).Value = IIf(Me.CodigoSerie.Text.Length > 0, Me.CodigoSerie.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@idTipotasa", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxIdTipotasa.Text.Length > 0, Me.RadComboBoxIdTipotasa.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoISIN", SqlDbType.NChar)).Value = IIf(Me.CodigoISIN.Text.ToString.Length > 0, Me.CodigoISIN.Text, DBNull.Value)

            If Me.FechaEmision.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaEmision", SqlDbType.Date)).Value = IIf(Me.FechaEmision.DbSelectedDate.ToString.Length > 0, Me.FechaEmision.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaEmision", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaVencimiento.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaVencimiento", SqlDbType.Date)).Value = IIf(Me.FechaVencimiento.DbSelectedDate.ToString.Length > 0, Me.FechaVencimiento.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaVencimiento", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaLiquidacion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLiquidacion", SqlDbType.Date)).Value = IIf(Me.FechaLiquidacion.DbSelectedDate.ToString.Length > 0, Me.FechaLiquidacion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLiquidacion", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@ValorRedencion", SqlDbType.Money)).Value = IIf(Me.ValorRedencion.Text.ToString.Length > 0, Me.ValorRedencion.Text, 0)


            cmd.Parameters.Add(New SqlParameter("@NotaRedencion", SqlDbType.VarChar)).Value = IIf(Me.txtNotaRedencion.Text.ToString.Length > 0, Me.txtNotaRedencion.Text, DBNull.Value)


            If Me.FechaRedencion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaRedencion", SqlDbType.Date)).Value = IIf(Me.FechaRedencion.DbSelectedDate.ToString.Length > 0, Me.FechaRedencion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaRedencion", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@TipoLiquidacionID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoLiquidacionID.Text.Length > 0, Me.RadComboBoxTipoLiquidacionID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoPeriodoID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoPeriodoID.Text.Length > 0, Me.RadComboBoxTipoPeriodoID.SelectedValue, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@ValorUnitarioNominal", SqlDbType.Money)).Value = IIf(Me.ValorUnitarioNominal.Text.ToString.Length > 0, Me.ValorUnitarioNominal.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ValorNominalUnitarioSerie", SqlDbType.Money)).Value = IIf(Me.txtValorNominalUnitarioSerie.Text.ToString.Length > 0, Me.txtValorNominalUnitarioSerie.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@CantidadTitulos", SqlDbType.BigInt)).Value = IIf(Me.txtCantidadTitulos.Text.ToString.Length > 0, Me.txtCantidadTitulos.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@InversionMinima", SqlDbType.Money)).Value = IIf(Me.InversionMinima.Text.ToString.Length > 0, Me.InversionMinima.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@InversionMaxima", SqlDbType.Money)).Value = IIf(Me.InversionMaxima.Text.ToString.Length > 0, Me.InversionMaxima.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Tasa", SqlDbType.Decimal)).Value = IIf(Me.txtTasa.Text.ToString.Length > 0, Me.txtTasa.Text, 0)


            If Me.FechaInicioColocacion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacion.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaFinalColocacion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacion.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@BaseLiquidacionID", SqlDbType.BigInt)).Value = IIf(Me.RadcomboBoxBaseLiquidacion.Text.Length > 0, Me.RadcomboBoxBaseLiquidacion.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Spread", SqlDbType.Decimal)).Value = IIf(Me.txtSpread.Text.ToString.Length > 0, Me.txtSpread.Text, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@InversionMaximaIG", SqlDbType.Money)).Value = IIf(Me.InversionMaximaIG.Text.ToString.Length > 0, Me.InversionMaximaIG.Text, 0)
            cmd.Parameters.Add(New SqlParameter("@DiasInversionMaximaIG", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxDiasInversionMaximaIG.Text.Length > 0, Me.RadComboBoxDiasInversionMaximaIG.SelectedValue, DBNull.Value)


            ' Fecha Inicio y Final de Inversionistas

            If Me.FechaInicioColocacionIP.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIP", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacionIP.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacionIP.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIP", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaFinalColocacionIP.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIP", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacionIP.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacionIP.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIP", SqlDbType.Date)).Value = DBNull.Value
            End If


            If Me.FechaInicioColocacionIG.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIG", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacionIG.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacionIG.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacionIG", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaFinalColocacionIG.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIG", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacionIG.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacionIG.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacionIG", SqlDbType.Date)).Value = DBNull.Value
            End If

            ' 2016.05.31
            cmd.Parameters.Add(New SqlParameter("@TipoAmortizacionCapitalID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoAmortizacionCapitalID.Text.Length > 0, Me.RadComboBoxTipoAmortizacionCapitalID.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NotaTipoAmortizacionCapital", SqlDbType.VarChar)).Value = IIf(Me.txtNotaTipoAmortizacionCapital.Text.ToString.Length > 0, Me.txtNotaTipoAmortizacionCapital.Text, DBNull.Value)

            ' 2017.01.07
            cmd.Parameters.Add(New SqlParameter("@MontoBaseParaComision", SqlDbType.Money)).Value = IIf(Me.MontoBaseParaComision.Text.ToString.Length > 0, Me.MontoBaseParaComision.Text, 0)

            If Me.FechaMontoBase.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaMontoBase", SqlDbType.Date)).Value = IIf(Me.FechaMontoBase.DbSelectedDate.ToString.Length > 0, Me.FechaMontoBase.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaMontoBase", SqlDbType.Date)).Value = DBNull.Value
            End If

            ' 2018.01.21
            cmd.Parameters.Add(New SqlParameter("@Estatus", SqlDbType.VarChar)).Value = IIf(Me.cbEstatus.Text.Length > 0, Me.cbEstatus.SelectedValue, DBNull.Value)

            ' 2018.03.09
            cmd.Parameters.Add(New SqlParameter("@IndiceConversionLiquidacion", SqlDbType.BigInt)).Value = IIf(Me.cbIndiceConversionLiquidacion.Text.Length > 0, Me.cbIndiceConversionLiquidacion.SelectedValue, 0)

            ' 2019.03.20 MELVIN CASTILLO
            cmd.Parameters.Add(New SqlParameter("@ContemplaRedencion", SqlDbType.Bit)).Value = Me.cbContemplaRedencion.Checked

            If Me.txtFechaContemplaRedencion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = IIf(Me.txtFechaContemplaRedencion.DbSelectedDate.ToString.Length > 0, Me.txtFechaContemplaRedencion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@ContemplaRedencionFecha", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.ExecuteNonQuery()

            cSql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisión Serie", "EditarEmision", cSql)



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorSerie.ErrorMessage = "Registro no pudo ser actualizado."
                ValidatorSerie.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally

            Notification1.Text = "Actualizado con éxito!"
            Notification1.Show()

            Cnx.Close()

        End Try
    End Sub
    Sub BorrarSerie()


        Dim ID = ViewState("CodeEdit")
        Dim cSql As String = String.Empty

        If ID > 0 Then

            cSql = "delete from dbo.EmisionSerie where EmisionSerieID='" & ID & "'"

            If oper.ExecuteNonQuery(cSql) Then

                ' Borrar incrementos de montos realizados a la Emisión (Serie)
                cSql = "delete from dbo.EmisionSerieMonto where EmisionSerieID='" & ID & "'"
                oper.ExecuteNonQuery(cSql)


                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisión Serie", "EditarEmision", cSql)


            Else

                InjectScriptLabel.Text = "<script>alert('No se puede borrar este Nemotécnico, ya que esta asociado a otras entradas')</" + "script>"

            End If
        End If

    End Sub

    Protected Sub RadComboBoxIdTipotasa_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxIdTipotasa.SelectedIndexChanged

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim cAtributoTipoTasa As String = String.Empty

        Cnx.Open()

        If RadComboBoxIdTipotasa.Text.Length > 0 Then

            Dim strSql As String =
            "SELECT [Atributo] " &
            "  FROM [dbo].[TipoTasa] " &
            "  where idTipotasa =  " & RadComboBoxIdTipotasa.SelectedValue

            cAtributoTipoTasa = oper.ExecuteScalar(strSql)

            If cAtributoTipoTasa = "F" Then

                txtTasa.Enabled = True
                txtSpread.Enabled = False

            Else

                Dim a As Boolean = ViewState("EsNuevo")

                If ViewState("EsNuevo") Then
                    txtTasa.Enabled = True
                    txtSpread.Enabled = False
                Else
                    txtTasa.Enabled = False
                    txtSpread.Enabled = True
                End If

            End If

        Else

        End If

        Cnx.Close()

    End Sub
    Protected Sub Serie_TextChanged(sender As Object, e As EventArgs) Handles Serie.TextChanged

        Dim CodSerie As String = String.Empty
        Dim cSql As String = "select dbo.CreacionCodigoBVRDSerie ('" & ViewState("EmisionID") & "','" & ViewState("Code") & "','" & Serie.Text & "','" + oper.ConvertirFechaEnISO(FechaVencimiento.DbSelectedDate) + "' )"
        CodSerie = oper.ExecuteScalar(cSql)
        CodigoSerie.Text = CodSerie

    End Sub
    Protected Sub txtValorNominalUnitarioSerie_TextChanged(sender As Object, e As EventArgs) Handles txtValorNominalUnitarioSerie.TextChanged

        If IsNumeric(txtValorNominalUnitarioSerie.Text) Then

            If Val(txtValorNominalUnitarioSerie.Text) > 0 Then
                txtCantidadTitulos.Text = Math.Abs(Val(ValorUnitarioNominal.Text) / Val(txtValorNominalUnitarioSerie.Text))
            End If

        End If

    End Sub
    Protected Sub RadComboBoxTipoLiquidacionID_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxTipoLiquidacionID.SelectedIndexChanged
        Dim TipoLiquidacionID As Integer

        TipoLiquidacionID = RadComboBoxTipoLiquidacionID.SelectedValue

        Dim objTipoLiquidacion As Tipoliquidacion

        objTipoLiquidacion = TipoLiquidacionRepo.FindBy(Function(x) x.Tipoliquidacionid = TipoLiquidacionID)

        If Not objTipoLiquidacion Is Nothing Then
            Dim fecha As Date
            Dim dias As Integer

            If FechaEmision.SelectedDate Is Nothing Then
                txtMensajeSerie.Text = "Debe especificar una fecha de emisión para calcular la fecha de liquidación."
            Else
                txtMensajeSerie.Text = String.Empty

                fecha = FechaEmision.SelectedDate

                dias = objTipoLiquidacion.Dias

                fecha = CalculateBusinessDaysFromInputDate(fecha, dias)

                ' fecha = CalculateBusinessDaysFromInputDate(fecha, GetDiasFestivosEntreFechas(FechaEmision.SelectedDate, fecha))

                If ValidaFechaCaeDiaFestivo(fecha) Then
                    fecha = CalculateBusinessDaysFromInputDate(fecha, 1)
                End If

                FechaLiquidacion.SelectedDate = fecha
            End If


        End If
    End Sub
    Protected Sub ActualizarNemo_Click(sender As Object, e As EventArgs) Handles ActualizarNemo.Click
        Serie_TextChanged(sender, e)
    End Sub


#End Region


#Region "Incrementos (Montos) a la Emisión"

    Sub EditarMontoSerie()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  vEmisionSerieMonto  where  EmisionSerieMontoID ='" & CInt(ViewState("CodeDocumento")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("Monto")) Then Me.txtMonto.Text = Trim(MyRow.Item("Monto"))
            If Not IsDBNull(MyRow.Item("FechaInicioColocacion")) Then Me.FechaInicioColocacionMonto.DbSelectedDate = Trim(MyRow.Item("FechaInicioColocacion"))
            If Not IsDBNull(MyRow.Item("FechaFinalColocacion")) Then Me.FechaFinalColocacionMonto.DbSelectedDate = Trim(MyRow.Item("FechaFinalColocacion"))
            If Not IsDBNull(MyRow.Item("FechaVencimiento")) Then Me.FechaVencimientoMonto.DbSelectedDate = Trim(MyRow.Item("FechaVencimiento"))

            If Not IsDBNull(MyRow.Item("CantidadCuotas")) Then Me.txtCantidadCuotas.Text = Trim(MyRow.Item("CantidadCuotas"))
            If Not IsDBNull(MyRow.Item("Precio")) Then Me.txtPrecio.Text = Trim(MyRow.Item("Precio"))



        Next
    End Sub

    Sub InsertarMontoSerie()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty
        Dim lCodigoSerie As String = String.Empty



        Dim strSql As String =
          "SELECT EmisionSerieID " &
          "  FROM [dbo].[EmisionSerie] " &
          "  where CodigoISIN = '" & Me.CodigoISIN.Text & "'"


        Try
            Dim Sql As String = "INSERT INTO  [EmisionSerieMonto] ([EmisionSerieID],[Monto],[FechaInicioColocacion],[FechaFinalColocacion],[FechaVencimiento],[CantidadCuotas],[Precio]) VALUES (@EmisionSerieID, @Monto ,@FechaInicioColocacion, @FechaFinalColocacion,@FechaVencimiento,@CantidadCuotas,@Precio)"

            Cnx.Open()

            lCodigoSerie = oper.ExecuteScalar(strSql)

            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = lCodigoSerie
            cmd.Parameters.Add(New SqlParameter("@Monto", SqlDbType.Decimal)).Value = txtMonto.Text
            cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacionMonto.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacionMonto.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacionMonto.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacionMonto.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@FechaVencimiento", SqlDbType.Date)).Value = IIf(Me.FechaVencimientoMonto.DbSelectedDate.ToString.Length > 0, Me.FechaVencimientoMonto.DbSelectedDate, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@CantidadCuotas", SqlDbType.Decimal)).Value = txtCantidadCuotas.Text
            cmd.Parameters.Add(New SqlParameter("@Precio", SqlDbType.Decimal)).Value = txtPrecio.Text


            cmd.ExecuteNonQuery()
            Response.Write("<script>window.open ('https://apms.bvrd.local/reportes/Comisiones/ReporteComisionNuevoEmisor.aspx','_blank');</script>")
        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            LimpiarMontoSerie()
            Cnx.Close()
        End Try

    End Sub

    Sub ActualizarMontoSerie()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty
        If Session("EditarSerie") = 0 Then
            Try

                Dim Sql As String = "Update EmisionSerieMonto set [Monto]=@Monto,[FechaInicioColocacion]=@FechaInicioColocacion,[FechaFinalColocacion]=@FechaFinalColocacion, [CantidadCuotas]=@CantidadCuotas, [Precio] = @Precio  where  [EmisionSerieMontoID]=@EmisionSerieMontoID"
                Cnx.Open()

                Dim cmd As New SqlCommand(Sql, Cnx)
                cmd.Parameters.Add(New SqlParameter("@EmisionSerieMontoID", SqlDbType.BigInt)).Value = ViewState("CodeDocumento")
                cmd.Parameters.Add(New SqlParameter("@Monto", SqlDbType.Decimal)).Value = txtMonto.Text
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacionMonto.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacionMonto.DbSelectedDate, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@FechaFinalColocacion", SqlDbType.Date)).Value = IIf(Me.FechaFinalColocacionMonto.DbSelectedDate.ToString.Length > 0, Me.FechaFinalColocacionMonto.DbSelectedDate, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@FechaVencimiento", SqlDbType.Date)).Value = IIf(Me.FechaVencimientoMonto.DbSelectedDate.ToString.Length > 0, Me.FechaVencimientoMonto.DbSelectedDate, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@CantidadCuotas", SqlDbType.Decimal)).Value = txtCantidadCuotas.Text
                cmd.Parameters.Add(New SqlParameter("@Precio", SqlDbType.Decimal)).Value = txtPrecio.Text


                cmd.ExecuteNonQuery()

            Catch sql_ex As SqlClient.SqlException

                If sql_ex.ErrorCode = -2146232060 Then
                    Exit Sub
                End If

            Catch ex As Exception
            Finally
                LimpiarMontoSerie()
                Cnx.Close()
            End Try
        End If
        If Session("EditarSerie") = "1" Then
            Try

                Dim Sql As String = "Update EmisionSerie set [Serie]=@Serie, [CodigoSerie]=@CodigoSerie where  [EmisionSerieID]=@EmisionSerieID"
                Cnx.Open()

                Dim cmd As New SqlCommand(Sql, Cnx)
                ViewState("CodeEdit") = Request.QueryString("EmisionSerieID")
                cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.NChar)).Value = IIf(ViewState("CodeEdit").Length > 0, ViewState("CodeEdit"), DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Serie", SqlDbType.NChar)).Value = IIf(Me.Serie.Text.Length > 0, Me.Serie.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@CodigoSerie", SqlDbType.NChar)).Value = IIf(Me.CodigoSerie.Text.Length > 0, Me.CodigoSerie.Text, DBNull.Value)
                cmd.ExecuteNonQuery()

            Catch sql_ex As SqlClient.SqlException

                If sql_ex.ErrorCode = -2146232060 Then
                    Exit Sub
                End If

            Catch ex As Exception
            Finally
                ' LimpiarMontoSerie()
                Cnx.Close()
            End Try
        End If







    End Sub

    Sub LimpiarMontoSerie()

        Me.txtMonto.Text = String.Empty
        Me.FechaInicioColocacionMonto.DbSelectedDate = String.Empty
        Me.FechaFinalColocacionMonto.DbSelectedDate = String.Empty
        Me.FechaVencimientoMonto.DbSelectedDate = String.Empty
        Me.txtCantidadCuotas.Text = String.Empty
        Me.txtPrecio.Text = String.Empty


    End Sub

    Protected Sub txtCantidadCuotas_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadCuotas.TextChanged

        If Val(txtCantidadCuotas.Text) > 0 And Val(txtPrecio.Text) > 0 Then
            txtMonto.Text = (Val(txtCantidadCuotas.Text) * Val(txtPrecio.Text)).ToString()
        Else
            txtMonto.Text = "0"
        End If

    End Sub

    Protected Sub txtPrecio_TextChanged(sender As Object, e As EventArgs) Handles txtPrecio.TextChanged

        If Val(txtCantidadCuotas.Text) > 0 And Val(txtPrecio.Text) > 0 Then
            txtMonto.Text = (Val(txtCantidadCuotas.Text) * Val(txtPrecio.Text)).ToString()
        Else
            txtMonto.Text = "0"
        End If



    End Sub


    ''' <summary>
    ''' Procedimiento de Borrar los incrementos.
    ''' </summary>
    Sub BorrarSerieIncremento()
        Dim cSql = String.Empty
        If ViewState("CodeDocumento") > 0 And Val(txtMonto.Text) > 0 Then

            cSql = "delete from dbo.EmisionSerieMonto where EmisionSerieMontoID='" & CInt(ViewState("CodeDocumento")) & "'"
            oper.ExecuteNonQuery(cSql)

            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Incremento Serie", "EditarEmision", cSql)

            LimpiarMontoSerie()

            With RadGridIncrementoMonto
                .Rebind()
                .Focus()
            End With


        End If

    End Sub

#End Region


#Region "Redenciones de la Emisión"

    Sub EditarRedencionSerie()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  vEmisionSerieRedencion  where  EmisionSerieRedencionID ='" & CInt(ViewState("CodeDocumentoRedencion")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("ValorRedencion")) Then Me.txtValorRedencion.Text = Trim(MyRow.Item("ValorRedencion"))
            If Not IsDBNull(MyRow.Item("FechaRedencion")) Then Me.txtFechaRedencion.DbSelectedDate = Trim(MyRow.Item("FechaRedencion"))

            If Not IsDBNull(MyRow.Item("DiasSinRedencion")) Then Me.txtDiasSinRedencion.Text = Trim(MyRow.Item("DiasSinRedencion"))
            If Not IsDBNull(MyRow.Item("DiasConRedencion")) Then Me.txtDiasConRedencion.Text = Trim(MyRow.Item("DiasConRedencion"))
            If Not IsDBNull(MyRow.Item("MontoDespuesRedencion")) Then Me.txtMontoDespuesRedencion.Text = Trim(MyRow.Item("MontoDespuesRedencion"))


            If Not IsDBNull(MyRow.Item("NotaRedencion")) Then Me.txtNotaRedencion.Text = Trim(MyRow.Item("NotaRedencion"))

        Next
    End Sub

    Sub InsertarRedencionSerie()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty
        Dim lCodigoSerie As String = String.Empty



        Dim strSql As String =
          "SELECT EmisionSerieID " &
          "  FROM [dbo].[EmisionSerie] " &
          "  where CodigoISIN = '" & Me.CodigoISIN.Text & "'"


        Try
            Dim Sql As String = "INSERT INTO  [EmisionSerieRedencion] ([EmisionSerieID], [FechaRedencion], [NotaRedencion], [ValorRedencion], [DiasSinRedencion], [DiasConRedencion], [MontoDespuesRedencion]) VALUES (@EmisionSerieID, @FechaRedencion ,@NotaRedencion, @ValorRedencion, @DiasSinRedencion, @DiasConRedencion, @MontoDespuesRedencion )"

            Cnx.Open()

            lCodigoSerie = oper.ExecuteScalar(strSql)

            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = lCodigoSerie
            cmd.Parameters.Add(New SqlParameter("@FechaRedencion", SqlDbType.Date)).Value = IIf(txtFechaRedencion.DbSelectedDate.ToString.Length > 0, txtFechaRedencion.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NotaRedencion", SqlDbType.Text)).Value = txtNotaRedencion.Text
            cmd.Parameters.Add(New SqlParameter("@ValorRedencion", SqlDbType.Decimal)).Value = txtValorRedencion.Text

            cmd.Parameters.Add(New SqlParameter("@DiasSinRedencion", SqlDbType.BigInt)).Value = txtDiasSinRedencion.Text
            cmd.Parameters.Add(New SqlParameter("@DiasConRedencion", SqlDbType.BigInt)).Value = txtDiasConRedencion.Text
            cmd.Parameters.Add(New SqlParameter("@MontoDespuesRedencion", SqlDbType.Decimal)).Value = txtMontoDespuesRedencion.Text



            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            LimpiarRedencionSerie()
            Cnx.Close()
        End Try

    End Sub

    Sub ActualizarRedencionSerie()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try
            Dim Sql As String = "Update EmisionSerieRedencion set [ValorRedencion]=@ValorRedencion,[FechaRedencion]=@FechaRedencion,[NotaRedencion]=@NotaRedencion,[DiasSinRedencion]=@DiasSinRedencion,[DiasConRedencion]=@DiasConRedencion,[MontoDespuesRedencion]=@MontoDespuesRedencion  where  [EmisionSerieRedencionID]=@EmisionSerieRedencionID"

            Cnx.Open()


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieRedencionID", SqlDbType.BigInt)).Value = ViewState("CodeDocumentoRedencion")
            cmd.Parameters.Add(New SqlParameter("@ValorRedencion", SqlDbType.Decimal)).Value = Convert.ToDecimal(IIf(txtValorRedencion.Text = String.Empty, "0", txtValorRedencion.Text))
            cmd.Parameters.Add(New SqlParameter("@FechaRedencion", SqlDbType.Date)).Value = IIf(Me.txtFechaRedencion.DbSelectedDate.ToString.Length > 0, txtFechaRedencion.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NotaRedencion", SqlDbType.VarChar)).Value = txtNotaRedencion.Text

            cmd.Parameters.Add(New SqlParameter("@DiasSinRedencion", SqlDbType.BigInt)).Value = txtDiasSinRedencion.Text
            cmd.Parameters.Add(New SqlParameter("@DiasConRedencion", SqlDbType.BigInt)).Value = txtDiasConRedencion.Text
            cmd.Parameters.Add(New SqlParameter("@MontoDespuesRedencion", SqlDbType.Decimal)).Value = txtMontoDespuesRedencion.Text



            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            LimpiarRedencionSerie()
            Cnx.Close()
        End Try


    End Sub

    Sub LimpiarRedencionSerie()

        txtValorRedencion.Text = String.Empty
        txtFechaRedencion.DbSelectedDate = String.Empty

        txtDiasSinRedencion.Text = String.Empty
        txtDiasConRedencion.Text = String.Empty
        txtMontoDespuesRedencion.Text = String.Empty

        txtNotaRedencion.Text = String.Empty

    End Sub

    Protected Sub txtValorRedencion_TextChanged(sender As Object, e As EventArgs) Handles txtValorRedencion.TextChanged
        Dim cSql As String = String.Empty
        Dim cSqlMontoAnterior As String = String.Empty
        Dim nDiasEnelMes As Int32 = 0
        Dim nValorBaseParaDescontar As Decimal = 0
        Dim cResultado As String = String.Empty
        Dim lCodigoSerie As String = String.Empty
        Dim cTotalvalor_nom_tot As String = String.Empty

        Dim strSql As String =
          "SELECT EmisionSerieID " &
          "  FROM [dbo].[EmisionSerie] " &
          "  where CodigoISIN = '" & Me.CodigoISIN.Text & "'"

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat


        Try


            lCodigoSerie = oper.ExecuteScalar(strSql)

            ' --------------------------------------------------------------------------------
            ' Calcular dias En el mes
            '---------------------------------------------------------------------------------
            nDiasEnelMes = System.DateTime.DaysInMonth(txtFechaRedencion.SelectedDate.Value.Year, txtFechaRedencion.SelectedDate.Value.Month)

            txtDiasSinRedencion.Text = txtFechaRedencion.SelectedDate.Value.Day
            txtDiasConRedencion.Text = nDiasEnelMes - txtFechaRedencion.SelectedDate.Value.Day


            ' --------------------------------------------------------------------------------
            ' Calcular Monto despues de Redencion
            ' --------------------------------------------------------------------------------
            ' 1. Determinar si es el primer ingreso

            cSql = String.Format("SELECT TOP 1 ROW_NUMBER() OVER(ORDER BY FechaRedencion ASC) AS Posicion 
                from EmisionSerieRedencion where EmisionSerieID = '{0}' and  FechaRedencion < '{1}'
                order by FechaRedencion desc", lCodigoSerie, txtFechaRedencion.SelectedDate.Value)

            cResultado = oper.ExecuteScalar(cSql)

            If cResultado = String.Empty Then
                cResultado = "0"
            End If

            Dim nPosicion As Int32 = Convert.ToInt32(cResultado)

            If nPosicion = 0 Then

                cSql = String.Format("select sum(valor_nom_tot) from operacionescsv where nemo_ins = '{0}' and mercado = '23'", CodigoSerie.Text)

                cTotalvalor_nom_tot = oper.ExecuteScalar(cSql)
                If cTotalvalor_nom_tot = String.Empty Then
                    cTotalvalor_nom_tot = "0"
                End If

                nValorBaseParaDescontar = cTotalvalor_nom_tot

            Else
                nValorBaseParaDescontar = 0
            End If

            ' 2. Determinar cual el su predecesor 
            If nValorBaseParaDescontar = 0 Then

                cSqlMontoAnterior = String.Format("SELECT top 1 MontoDespuesRedencion
                from EmisionSerieRedencion where EmisionSerieID = '{0}' and  FechaRedencion < '{1}'
                order by FechaRedencion desc", lCodigoSerie, txtFechaRedencion.SelectedDate.Value)

                cResultado = oper.ExecuteScalar(cSqlMontoAnterior)
                nValorBaseParaDescontar = Convert.ToDecimal(cResultado)
            End If

            ' 3. Determinar el Monto

            txtMontoDespuesRedencion.Text = (nValorBaseParaDescontar - Convert.ToDecimal(txtValorRedencion.Text))

        Catch ex As Exception

        End Try


        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub

#End Region


#Region "Amortizaciones de la Emisión"

    Sub EditarAmortizacionSerie()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  vEmisionSerieAmortizacion  where  EmisionSerieAmortizacionID ='" & CInt(ViewState("CodeDocumentoAmortizacion")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("ValorAmortizacion")) Then Me.txtValorAmortizacion.Text = Trim(MyRow.Item("ValorAmortizacion"))
            If Not IsDBNull(MyRow.Item("FechaAmortizacion")) Then Me.txtFechaAmortizacion.DbSelectedDate = Trim(MyRow.Item("FechaAmortizacion"))

            If Not IsDBNull(MyRow.Item("DiasSinAmortizacion")) Then Me.txtDiasSinAmortizacion.Text = Trim(MyRow.Item("DiasSinAmortizacion"))
            If Not IsDBNull(MyRow.Item("DiasConAmortizacion")) Then Me.txtDiasConAmortizacion.Text = Trim(MyRow.Item("DiasConAmortizacion"))
            If Not IsDBNull(MyRow.Item("MontoDespuesAmortizacion")) Then Me.txtMontoDespuesAmortizacion.Text = Trim(MyRow.Item("MontoDespuesAmortizacion"))

            If Not IsDBNull(MyRow.Item("NotaAmortizacion")) Then Me.txtNotaAmortizacion.Text = Trim(MyRow.Item("NotaAmortizacion"))

        Next
    End Sub

    Sub InsertarAmortizacionSerie()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty
        Dim lCodigoSerie As String = String.Empty

        Dim strSql As String =
          "SELECT EmisionSerieID " &
          "  FROM [dbo].[EmisionSerie] " &
          "  where CodigoISIN = '" & Me.CodigoISIN.Text & "'"


        Try
            Dim Sql As String = "INSERT INTO  [EmisionSerieAmortizacion] ([EmisionSerieID], [FechaAmortizacion], [NotaAmortizacion], [ValorAmortizacion],[DiasSinAmortizacion],[DiasConAmortizacion],[MontoDespuesAmortizacion]) VALUES (@EmisionSerieID, @FechaAmortizacion ,@NotaAmortizacion, @ValorAmortizacion,@DiasSinAmortizacion,@DiasConAmortizacion,@MontoDespuesAmortizacion)"

            Cnx.Open()

            lCodigoSerie = oper.ExecuteScalar(strSql)

            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = lCodigoSerie
            cmd.Parameters.Add(New SqlParameter("@FechaAmortizacion", SqlDbType.Date)).Value = IIf(txtFechaAmortizacion.DbSelectedDate.ToString.Length > 0, txtFechaAmortizacion.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NotaAmortizacion", SqlDbType.Text)).Value = txtNotaAmortizacion.Text
            cmd.Parameters.Add(New SqlParameter("@ValorAmortizacion", SqlDbType.Decimal)).Value = txtValorAmortizacion.Text

            cmd.Parameters.Add(New SqlParameter("@DiasSinAmortizacion", SqlDbType.BigInt)).Value = txtDiasSinAmortizacion.Text
            cmd.Parameters.Add(New SqlParameter("@DiasConAmortizacion", SqlDbType.BigInt)).Value = txtDiasConAmortizacion.Text
            cmd.Parameters.Add(New SqlParameter("@MontoDespuesAmortizacion", SqlDbType.Decimal)).Value = txtMontoDespuesAmortizacion.Text


            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            LimpiarAmortizacionSerie()
            Cnx.Close()
        End Try

    End Sub

    Sub ActualizarAmortizacionSerie()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try
            Dim Sql As String = "Update EmisionSerieAmortizacion set [ValorAmortizacion]=@ValorAmortizacion,[FechaAmortizacion]=@FechaAmortizacion,[NotaAmortizacion]=@NotaAmortizacion,[DiasSinAmortizacion]=@DiasSinAmortizacion,[DiasConAmortizacion]=@DiasConAmortizacion,[MontoDespuesAmortizacion]=@MontoDespuesAmortizacion where [EmisionSerieAmortizacionID]=@EmisionSerieAmortizacionID"

            Cnx.Open()


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieAmortizacionID", SqlDbType.BigInt)).Value = ViewState("CodeDocumentoAmortizacion")
            cmd.Parameters.Add(New SqlParameter("@ValorAmortizacion", SqlDbType.Decimal)).Value = txtValorAmortizacion.Text
            cmd.Parameters.Add(New SqlParameter("@FechaAmortizacion", SqlDbType.Date)).Value = IIf(Me.txtFechaAmortizacion.DbSelectedDate.ToString.Length > 0, txtFechaAmortizacion.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NotaAmortizacion", SqlDbType.VarChar)).Value = txtNotaAmortizacion.Text

            cmd.Parameters.Add(New SqlParameter("@DiasSinAmortizacion", SqlDbType.BigInt)).Value = txtDiasSinAmortizacion.Text
            cmd.Parameters.Add(New SqlParameter("@DiasConAmortizacion", SqlDbType.BigInt)).Value = txtDiasConAmortizacion.Text
            cmd.Parameters.Add(New SqlParameter("@MontoDespuesAmortizacion", SqlDbType.Decimal)).Value = txtMontoDespuesAmortizacion.Text


            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            LimpiarAmortizacionSerie()
            Cnx.Close()
        End Try


    End Sub

    Sub LimpiarAmortizacionSerie()

        txtFechaAmortizacion.DbSelectedDate = String.Empty
        txtValorAmortizacion.Text = String.Empty
        txtDiasSinAmortizacion.Text = String.Empty
        txtDiasConAmortizacion.Text = String.Empty
        txtMontoDespuesAmortizacion.Text = String.Empty
        txtNotaAmortizacion.Text = String.Empty

    End Sub

    Protected Sub txtValorAmortizacion_TextChanged(sender As Object, e As EventArgs) Handles txtValorAmortizacion.TextChanged
        Dim cSql As String = String.Empty
        Dim cSqlMontoAnterior As String = String.Empty
        Dim nDiasEnelMes As Int32 = 0
        Dim nValorBaseParaDescontar As Decimal = 0
        Dim cResultado As String = String.Empty
        Dim lCodigoSerie As String = String.Empty
        Dim cTotalvalor_nom_tot As String = String.Empty

        Dim strSql As String =
          "SELECT EmisionSerieID " &
          "  FROM [dbo].[EmisionSerie] " &
          "  where CodigoISIN = '" & Me.CodigoISIN.Text & "'"

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat


        Try


            lCodigoSerie = oper.ExecuteScalar(strSql)

            ' --------------------------------------------------------------------------------
            ' Calcular dias En el mes
            '---------------------------------------------------------------------------------
            nDiasEnelMes = System.DateTime.DaysInMonth(txtFechaAmortizacion.SelectedDate.Value.Year, txtFechaAmortizacion.SelectedDate.Value.Month)

            txtDiasSinAmortizacion.Text = txtFechaAmortizacion.SelectedDate.Value.Day
            txtDiasConAmortizacion.Text = nDiasEnelMes - txtFechaAmortizacion.SelectedDate.Value.Day


            ' --------------------------------------------------------------------------------
            ' Calcular Monto despues de amortizacion 
            ' --------------------------------------------------------------------------------
            ' 1. Determinar si es el primer ingreso

            cSql = String.Format("SELECT TOP 1 ROW_NUMBER() OVER(ORDER BY FechaAmortizacion ASC) AS Posicion 
                from EmisionSerieAmortizacion where EmisionSerieID = '{0}' and  FechaAmortizacion < '{1}'
                order by FechaAmortizacion desc", lCodigoSerie, txtFechaAmortizacion.SelectedDate.Value)

            cResultado = oper.ExecuteScalar(cSql)

            If cResultado = String.Empty Then
                cResultado = "0"
            End If

            Dim nPosicion As Int32 = Convert.ToInt32(cResultado)

            If nPosicion = 0 Then

                cSql = String.Format("select sum(valor_nom_tot) from operacionescsv where nemo_ins = '{0}' and mercado = '23'", CodigoSerie.Text)

                cTotalvalor_nom_tot = oper.ExecuteScalar(cSql)
                If cTotalvalor_nom_tot = String.Empty Then
                    cTotalvalor_nom_tot = "0"
                End If

                nValorBaseParaDescontar = cTotalvalor_nom_tot

            Else
                nValorBaseParaDescontar = 0
            End If

            ' 2. Determinar cual el su predecesor 
            If nValorBaseParaDescontar = 0 Then

                cSqlMontoAnterior = String.Format("SELECT top 1 MontoDespuesAmortizacion
                from EmisionSerieAmortizacion where EmisionSerieID = '{0}' and  FechaAmortizacion < '{1}'
                order by FechaAmortizacion desc", lCodigoSerie, txtFechaAmortizacion.SelectedDate.Value)

                cResultado = oper.ExecuteScalar(cSqlMontoAnterior)
                nValorBaseParaDescontar = Convert.ToDecimal(cResultado)
            End If

            ' 3. Determinar el Monto

            txtMontoDespuesAmortizacion.Text = (nValorBaseParaDescontar - Convert.ToDecimal(txtValorAmortizacion.Text))

        Catch ex As Exception

        End Try


        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat



    End Sub


#End Region



#Region "Titularizado de la Emisión"

    Sub EditarTitularizadoSerie()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  vEmisionSerieTitularizado  where  EmisionSerieTitularizadoID ='" & CInt(ViewState("CodeDocumentoTitularizado")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows


            If Not IsDBNull(MyRow.Item("ValorTitularizado")) Then Me.txtValorTitularizado.Text = Trim(MyRow.Item("ValorTitularizado"))
            If Not IsDBNull(MyRow.Item("FechaTitularizado")) Then Me.txtFechaTitularizado.DbSelectedDate = Trim(MyRow.Item("FechaTitularizado"))
            If Not IsDBNull(MyRow.Item("NotaTitularizado")) Then Me.txtNotaTitularizado.Text = Trim(MyRow.Item("NotaTitularizado"))

            ' ------------------------------------------------------------------------------------------
            ' Datos del documento adjunto
            ' ------------------------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("nombre")) Then Me.txtNombreDoc.Text = Trim(MyRow.Item("nombre"))




        Next
    End Sub

    Sub InsertarTitularizadoSerie()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty
        Dim lCodigoSerie As String = String.Empty



        Dim strSql As String =
          "SELECT EmisionSerieID " &
          "  FROM [dbo].[EmisionSerie] " &
          "  where CodigoISIN = '" & Me.CodigoISIN.Text & "'"


        Try
            Dim Sql As String = "INSERT INTO [EmisionSerieTitularizado] 
                                  ([EmisionSerieID], 
                                   [FechaTitularizado], 
                                   [ValorTitularizado],
                                   [NotaTitularizado], 
                                   [nombre],
                                   [Adjunto],
                                   [Archivo],
                                   [Creacion]
                                   ) VALUES 
                                  (@EmisionSerieID, 
                                   @FechaTitularizado,
                                   @ValorTitularizado,
                                   @NotaTitularizado, 
                                   @nombre,
                                   @Adjunto,
                                   @Archivo,
                                   @Creacion
                                   )"

            Cnx.Open()

            lCodigoSerie = oper.ExecuteScalar(strSql)


            Documento = ViewState("FileName")
            RutaDocumento = My.Computer.FileSystem.SpecialDirectories.Temp + "\" + Documento


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = lCodigoSerie
            cmd.Parameters.Add(New SqlParameter("@FechaTitularizado", SqlDbType.Date)).Value = IIf(txtFechaTitularizado.DbSelectedDate.ToString.Length > 0, txtFechaTitularizado.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ValorTitularizado", SqlDbType.Decimal)).Value = txtValorTitularizado.Text
            cmd.Parameters.Add(New SqlParameter("@NotaTitularizado", SqlDbType.Text)).Value = txtNotaTitularizado.Text

            cmd.Parameters.Add(New SqlParameter("@nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreDoc.Text.Length > 0, Me.txtNombreDoc.Text, DBNull.Value)


            ' Manejo de Documentos
            If Documento IsNot Nothing Then
                cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                cmd.Parameters.Add(New SqlParameter("@Archivo", SqlDbType.VarChar)).Value = Documento
            Else
                cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = DBNull.Value
                cmd.Parameters.Add(New SqlParameter("@Archivo", SqlDbType.VarChar)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@Creacion", SqlDbType.DateTime)).Value = Today.Date

            cmd.ExecuteNonQuery()

            DeleteFiles(Documento)

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            LimpiarTitularizadoSerie()
            Cnx.Close()
        End Try

    End Sub

    Sub ActualizarTitularizadoSerie()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try
            Dim Sql As String = "Update EmisionSerieTitularizado
                                  set [ValorTitularizado]=@ValorTitularizado,
                                      [FechaTitularizado]=@FechaTitularizado,
                                      [NotaTitularizado]=@NotaTitularizado,
                                      [Archivo]=@Archivo,
                                      [Adjunto]=@Adjunto,
                                      [nombre]=@nombre 
                                    where  [EmisionSerieTitularizadoID]=@EmisionSerieTitularizadoID"

            Cnx.Open()

            Documento = ViewState("FileName")
            RutaDocumento = My.Computer.FileSystem.SpecialDirectories.Temp + "\" + Documento


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieTitularizadoID", SqlDbType.BigInt)).Value = ViewState("CodeDocumentoTitularizado")
            cmd.Parameters.Add(New SqlParameter("@ValorTitularizado", SqlDbType.Decimal)).Value = Convert.ToDecimal(IIf(txtValorTitularizado.Text = String.Empty, "0", txtValorTitularizado.Text))
            cmd.Parameters.Add(New SqlParameter("@FechaTitularizado", SqlDbType.Date)).Value = IIf(Me.txtFechaTitularizado.DbSelectedDate.ToString.Length > 0, txtFechaTitularizado.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NotaTitularizado", SqlDbType.VarChar)).Value = txtNotaTitularizado.Text


            ' Manejo de Documentos
            If Documento IsNot Nothing Then
                cmd.Parameters.Add(New SqlParameter("@Archivo", SqlDbType.VarChar)).Value = Documento
                cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            Else
                cmd.Parameters.Add(New SqlParameter("@Archivo", SqlDbType.VarChar)).Value = DBNull.Value
                cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreDoc.Text.Length > 0, Me.txtNombreDoc.Text, DBNull.Value)


            cmd.ExecuteNonQuery()

            DeleteFiles(Documento)

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            LimpiarTitularizadoSerie()
            Cnx.Close()
        End Try


    End Sub

    Sub LimpiarTitularizadoSerie()

        txtValorTitularizado.Text = String.Empty
        txtFechaTitularizado.DbSelectedDate = String.Empty
        txtNotaTitularizado.Text = String.Empty

        txtNombreDoc.Text = String.Empty


    End Sub

#End Region


#Region "RadGrids ..."

    ' ----------------------------------------------------------------------------------
    ' Cuando se Selecciona la fila del Grid 
    ' ----------------------------------------------------------------------------------
    'Incrementos 
    Protected Sub RadGridIncrementoMonto_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridIncrementoMonto.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridIncrementoMonto.SelectedItems(0)
        Dim ID = dataitem("EmisionSerieMontoID").Text
        ViewState("CodeDocumento") = ID
        ViewState("EsNuevo") = False
        Call EditarMontoSerie()
        RadGridIncrementoMonto.DataBind()
    End Sub

    ' ------------------------------------------------------------------------------------------------------------
    'Redenciones 
    ' ------------------------------------------------------------------------------------------------------------
    Protected Sub RadGridEmisionSerieRedencion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridEmisionSerieRedencion.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridEmisionSerieRedencion.SelectedItems(0)
        Dim ID = dataitem("EmisionSerieRedencionID").Text
        ViewState("CodeDocumentoRedencion") = ID
        ViewState("EsNuevoRedencion") = False
        Call EditarRedencionSerie()
        RadGridEmisionSerieRedencion.DataBind()
    End Sub

    ' ------------------------------------------------------------------------------------------------------------
    'Amortizaciones 
    ' ------------------------------------------------------------------------------------------------------------
    Protected Sub RadGridAmortizaciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridAmortizaciones.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridAmortizaciones.SelectedItems(0)
        Dim ID = dataitem("EmisionSerieAmortizacionID").Text
        ViewState("CodeDocumentoAmortizacion") = ID
        ViewState("EsNuevoAmortizacion") = False
        Call EditarAmortizacionSerie()
        RadGridAmortizaciones.DataBind()
    End Sub


    ' ------------------------------------------------------------------------------------------------------------
    ' Titularizado
    ' ------------------------------------------------------------------------------------------------------------
    Protected Sub RadGridEmisionSerieTitularizado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridEmisionSerieTitularizado.SelectedIndexChanged
        Try
            Dim dataitem As GridDataItem = RadGridEmisionSerieTitularizado.SelectedItems(0)
            Dim ID = dataitem("EmisionSerieTitularizadoID").Text
            ViewState("CodeDocumentoTitularizado") = ID
            ViewState("EsNuevoTitularizado") = False

            RadUpload1.Visible = True ' Activar el cargador de archivos

            Call EditarTitularizadoSerie()
            'RadGridEmisionSerieTitularizado.DataBind()



        Catch ex As Exception

        End Try

    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridEmisionSerieTitularizado.SelectedItems

                ViewState("DocumentoID") = dataItem("EmisionSerieTitularizadoID").Text
                ViewState("DocumentoNombre") = Trim(dataItem("Nombre").Text)

                DeleteFiles(ViewState("DocumentoNombre"))
                LeerBinario(ViewState("DocumentoID"), My.Computer.FileSystem.SpecialDirectories.Temp + "\", ViewState("DocumentoNombre"))

            Next
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SubidaArchivo() = True Then

            Try
                Dim targetFolder As String = My.Computer.FileSystem.SpecialDirectories.Temp

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
            Dim Sql As String = "Select Adjunto,Archivo From EmisionSerieTitularizado Where EmisionSerieTitularizadoID ='" & DocumentoID & "'"

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


#End Region

#Region " Pestañas y Barra de Herramientas ..."

    ''' <summary>
    ''' Evento : Cuando seleccionamos las diferentes pestañas de la Emisión 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick


        Select Case Me.RadTabStrip1.SelectedIndex

            Case 0 ' Habilitar todos los botones, en el caso de que sea la Emisión

                ViewState("EsNuevo") = False

                RadToolBar1.Items.Item(0).Enabled = False
                RadToolBar1.Items.Item(0).Visible = False

                RadToolBar1.Items.Item(1).Enabled = True
                RadToolBar1.Items.Item(1).Visible = True

                RadToolBar1.Items.Item(2).Enabled = True
                RadToolBar1.Items.Item(2).Visible = True

                RadToolBar1.Items.Item(3).Enabled = True
                RadToolBar1.Items.Item(3).Visible = True

            Case 1 ' Inhabilitar los botones de la parte del incremento de montos

                ViewState("EsNuevo") = True


                If ViewState("PuedeEditarMonto") = False Then

                    RadToolBar1.Items.Item(0).Enabled = False
                    RadToolBar1.Items.Item(0).Visible = False
                    RadToolBar1.Items.Item(1).Enabled = False
                    RadToolBar1.Items.Item(1).Visible = False
                    RadGridIncrementoMonto.Enabled = False

                Else

                    RadToolBar1.Items.Item(0).Enabled = True
                    RadToolBar1.Items.Item(0).Visible = True

                    RadToolBar1.Items.Item(1).Enabled = True
                    RadToolBar1.Items.Item(1).Visible = True

                    RadGridIncrementoMonto.Enabled = True

                End If


                RadToolBar1.Items.Item(3).Enabled = True
                RadToolBar1.Items.Item(3).Visible = True

            Case 2 ' Redenciones Verificar cuando aplican 

                ViewState("EsNuevoRedencion") = True

                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(0).Visible = True

                RadToolBar1.Items.Item(1).Enabled = True
                RadToolBar1.Items.Item(1).Visible = True

                txtFechaRedencion.Enabled = True
                txtValorRedencion.Enabled = True
                txtNotaRedencion.Enabled = True

                RadGridEmisionSerieRedencion.Enabled = True

            Case 3 ' Amortización

                ViewState("EsNuevoAmortizacion") = True

                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(0).Visible = True

                RadToolBar1.Items.Item(1).Enabled = True
                RadToolBar1.Items.Item(1).Visible = True

                txtFechaAmortizacion.Enabled = True
                txtValorAmortizacion.Enabled = True
                txtDiasSinAmortizacion.Enabled = False
                txtDiasConAmortizacion.Enabled = False
                txtMontoDespuesAmortizacion.Enabled = False
                txtNotaAmortizacion.Enabled = True

                RadGridAmortizaciones.Enabled = True

            Case 4 ' Titularizado

                ViewState("EsNuevoTitularizado") = True

                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(0).Visible = True

                RadToolBar1.Items.Item(1).Enabled = True
                RadToolBar1.Items.Item(1).Visible = True

                txtFechaTitularizado.Enabled = True
                txtValorTitularizado.Enabled = True
                txtNotaTitularizado.Enabled = True

                RadGridEmisionSerieTitularizado.Enabled = True



        End Select

    End Sub

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick


        If e.Item.Value = 0 Then ' Guardar


            Select Case Me.RadTabStrip1.SelectedIndex

                Case 0 ' Guardar Emision Serie 


                    Dim EmisionSerie As Integer = 0

                    ' Validaciones a la Hora de Guardar la información...

                    ' 1.0 Validar : Texto escrito en la serie (Emisión)
                    '

                    If Val(Serie.Text.Length) <= 0 Then
                        ValidatorSerie.ErrorMessage = "Serie"
                        ValidatorSerie.IsValid = False
                        ValidatorSerie.Enabled = True
                        EmisionSerie = EmisionSerie + 1

                    End If

                    '
                    ' 2.0 Validar : Fecha liquidación 
                    '

                    If Val(FechaLiquidacion.DbSelectedDate.ToString.Length) <= 0 Then
                        ValidatorFechaLiquidacion.ErrorMessage = "Fecha Liquidación"
                        ValidatorFechaLiquidacion.IsValid = False
                        ValidatorFechaLiquidacion.Enabled = True
                        EmisionSerie = EmisionSerie + 1
                    End If

                    '
                    ' 3.0 Validar : Texto valor tasa   
                    '               2016.07.28 Validar solo cuando sea Tasa fija
                    '

                    If String.IsNullOrEmpty(txtTasa.Text) Or Val(txtTasa.Text) = 0 And
                       (RadComboBoxIdTipotasa.Text.ToUpper().TrimEnd() = "TASA FIJA") Then

                        ValidatorTasa.ErrorMessage = "Tasa"
                        ValidatorTasa.IsValid = False
                        ValidatorTasa.Enabled = True
                        EmisionSerie = EmisionSerie + 1

                        Notification1.Text = ValidatorTasa.ToolTip
                        Notification1.Show()


                    End If



                    ' Las validaciones no pasaron correctamente.
                    If EmisionSerie > 0 Then
                        Exit Sub
                    End If



                    'If ViewState("EsNuevo") = True Then
                    '    Call ValidaExisteCodigo()
                    '    If ViewState("CodigoSerie") = Me.CodigoSerie.Text Then
                    '        Me.Guardado.Text = "Código de Serie existe en el sistema"
                    '        EmisionSerie = EmisionSerie + 1
                    '    End If
                    '    If EmisionSerie > 0 Then
                    '        Exit Sub
                    '    End If
                    'Else
                    '    Call ValidaExisteCodigoID()
                    '    If ViewState("CodigoSerie") = Me.CodigoSerie.Text And ViewState("vEmisionSerieID") <> ViewState("CodeEdit") Then
                    '        Me.Guardado.Text = "Código de Serie existe en el sistema"
                    '        EmisionSerie = EmisionSerie + 1
                    '    End If
                    '    If EmisionSerie > 0 Then
                    '        Exit Sub
                    '    End If
                    'End If


                    If ViewState("EsNuevo") = True Then

                        Call InsertarSerie(ViewState("Code"))
                        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

                    End If

                    If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then

                        Call ActualizarSerie()
                        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

                    End If

                Case 1 ' Guardar incremento...


                    If ViewState("EsNuevo") = True Then

                        InsertarMontoSerie()
                        RadGridIncrementoMonto.Rebind()

                    End If

                    If ViewState("EsNuevo") = False Then

                        ActualizarMontoSerie()
                        RadGridIncrementoMonto.Rebind()

                    End If



                Case 2 ' Guardar Redención...

                    If ViewState("EsNuevoRedencion") = True Then

                        InsertarRedencionSerie()
                        RadGridEmisionSerieRedencion.Rebind()

                    End If

                    If ViewState("EsNuevoRedencion") = False Then

                        ActualizarRedencionSerie()
                        RadGridEmisionSerieRedencion.Rebind()

                    End If


                Case 3 ' Amortización 

                    If ViewState("EsNuevoAmortizacion") = True Then

                        InsertarAmortizacionSerie()
                        RadGridAmortizaciones.Rebind()

                    End If

                    If ViewState("EsNuevoAmortizacion") = False Then

                        ActualizarAmortizacionSerie()
                        RadGridAmortizaciones.Rebind()

                    End If

                Case 4 ' Titularizado

                    If ViewState("EsNuevoTitularizado") = True Then

                        InsertarTitularizadoSerie()
                        RadGridEmisionSerieTitularizado.Rebind()

                    End If

                    If ViewState("EsNuevoTitularizado") = False Then

                        ActualizarTitularizadoSerie()
                        RadGridEmisionSerieTitularizado.Rebind()

                    End If


            End Select


        ElseIf e.Item.Value = 2 Then

            Select Case Me.RadTabStrip1.SelectedIndex

                Case 0

                    InjectScriptLabel.Text = "<script>Delete()</" + "script>"
                    'BorrarSerie()
                Case 1

                    InjectScriptLabelIncrem.Text = "<script>DeleteIncremento()</" + "script>"
            End Select


        ElseIf e.Item.Value = 1 Then
            ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 3 Then  ' Botón nuevo 

            Select Case Me.RadTabStrip1.SelectedIndex
                Case 1
                    LimpiarMontoSerie()
                    ViewState("EsNuevo") = True
                Case 2
                    LimpiarRedencionSerie()
                    ViewState("EsNuevoRedencion") = True
                Case 3
                    LimpiarAmortizacionSerie()

                    ViewState("CodeDocumentoAmortizacion") = 0
                    ViewState("EsNuevoAmortizacion") = True

                Case 4

                    RadProgressArea1.Visible = True
                    ViewState("EsNuevoTitularizada") = True

            End Select


        End If

    End Sub


#End Region

#Region "Funciones Generales"

    Public Function GetDiasFestivosEntreFechas(startDate As Date, endDate As Date) As Integer

        Dim intCantidadDias As Integer = 0

        Dim query = UofWork.CurrentSession.QueryOver(Of Diafestivo)().WhereRestrictionOn(Function(x) x.Fecha).IsBetween(startDate).And(endDate).List()

        If Not query Is Nothing Then
            intCantidadDias = query.Count()
        End If
        Return intCantidadDias

    End Function
    Public Function ValidaFechaCaeDiaFestivo(fecha As Date) As Boolean
        Dim caeDiaFeriado As Boolean = False
        Dim objDiafestivo As Diafestivo
        objDiafestivo = DiaFestivoRepo.FindBy(Function(x) x.Fecha = fecha)

        If (Not objDiafestivo Is Nothing) Then
            If (objDiafestivo.CodigoMercado Is Nothing) Then
                caeDiaFeriado = True
            End If
        End If

        Return caeDiaFeriado
    End Function
    Public Function CalculateBusinessDaysFromInputDate(ByVal StartDate As Date, ByVal NumberOfBusinessDays As Integer) As Date
        'Knock the start date down one day if it is on a weekend.
        If StartDate.DayOfWeek = DayOfWeek.Saturday Or StartDate.DayOfWeek =
        DayOfWeek.Sunday Then
            NumberOfBusinessDays -= 1
        End If

        For index = 1 To NumberOfBusinessDays
            Select Case StartDate.DayOfWeek
                Case DayOfWeek.Sunday
                    StartDate = StartDate.AddDays(2)
                Case DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday,
                    DayOfWeek.Thursday, DayOfWeek.Friday
                    StartDate = StartDate.AddDays(1)
                Case DayOfWeek.Saturday
                    StartDate = StartDate.AddDays(3)

            End Select

        Next

        'check to see if the end date is on a weekend.
        'If so move it ahead to Monday.
        'You could also bump it back to the Friday before if you desired to. 
        'Just change the code to -2 and -1.
        If StartDate.DayOfWeek = DayOfWeek.Saturday Then
            StartDate = StartDate.AddDays(2)
        ElseIf StartDate.DayOfWeek = DayOfWeek.Sunday Then
            StartDate = StartDate.AddDays(1)
        End If

        Return StartDate

    End Function

#End Region

#Region "Operaciones con Tramos"

    ''' <summary>
    ''' Insertar tramo cuando no existe un tramo para el programa de Emisión
    ''' </summary>
    Sub InsertarTramo()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = String.Empty

        Try
            Dim Sql As String = "INSERT INTO EmisionTramo ([EmisionID] " &
            ",[NumeroTramo] " &
            ",[CantidadSeriesPorTramo] " &
            ",[FechaInicioColocacion] " &
            ",[FechaDeEmision] " &
            ",[FechaPlanVencimiento] " &
            ") VALUES (@EmisionID " &
            ",@NumeroTramo " &
            ",@CantidadSeriesPorTramo " &
            ",@FechaInicioColocacion " &
            ",@FechaDeEmision " &
            ",@FechaPlanVencimiento " &
            " ) "

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = ViewState("EmisionID")
            cmd.Parameters.Add(New SqlParameter("@NumeroTramo", SqlDbType.Int)).Value = 1
            cmd.Parameters.Add(New SqlParameter("@CantidadSeriesPorTramo", SqlDbType.Int)).Value = 9

            If Me.FechaInicioColocacionIP.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = IIf(Me.FechaInicioColocacionIP.DbSelectedDate.ToString.Length > 0, Me.FechaInicioColocacionIP.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaInicioColocacion", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.FechaEmision.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaDeEmision", SqlDbType.Date)).Value = IIf(Me.FechaEmision.DbSelectedDate.ToString.Length > 0, Me.FechaEmision.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaDeEmision", SqlDbType.Date)).Value = DBNull.Value
            End If


            If Me.FechaVencimiento.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaPlanVencimiento", SqlDbType.Date)).Value = IIf(Me.FechaVencimiento.DbSelectedDate.ToString.Length > 0, Me.FechaVencimiento.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaPlanVencimiento", SqlDbType.Date)).Value = DBNull.Value
            End If


            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException


        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try
    End Sub






#End Region



End Class
