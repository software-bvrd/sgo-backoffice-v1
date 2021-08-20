Imports System.Data
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Public Class EditarOperacionesValoresEnFirme
    Inherits System.Web.UI.Page

    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("ID")
            End If


            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            Else
                txtFecha.DbSelectedDate = Today.Date


                Try
                    ' ---------------------------------------------------------
                    ' Buscar Numero de Opreciones
                    ' ---------------------------------------------------------
                    Dim nNumeroOperacion As Int64 = oper.GetSecuence("OperacionesValoresEnFirme", "NumeroOfertaVenta", Nothing)

                    txtNumeroOfertaVenta.Text = nNumeroOperacion.ToString("00000000")
                    txtNumeroOfertaCompra.Text = nNumeroOperacion.ToString("00000000")
                Catch
                    Throw
                End Try



            End If


            Try

                ' ---------------------------------------------------------------------------
                ' Seleccionar rueda por defecto
                ' ---------------------------------------------------------------------------
                RadComboRueda.SelectedValue = Convert.ToInt32(oper.ExecuteScalar("Select RuedaID from Rueda where Nombre = 'FIRME'"))

            Catch
                Throw
            End Try


            Session("Guardado") = "NO"

            RadComboBoxEmisorID.Focus()

        End If


    End Sub

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar


            RequiredFieldEmisor.Enabled = False
            RequiredFieldEmision.Enabled = False
            RequiredFieldEmisionSerie.Enabled = False

            RequiredFieldCantidadTitulos.Enabled = False
            RequiredFieldValorTransado.Enabled = False
            RequiredFieldPrecio.Enabled = False

            RequiredFieldFecha.Enabled = False

            RequiredFieldMoneda.Enabled = False
            RequiredFieldPuestoComprador.Enabled = False


            ' ------------------------------------------------------------------
            ' Hacer validaciones
            ' ------------------------------------------------------------------
            Dim ValidarOperacionesValoresEnFirme As Integer = 0


            ' 0.0 Validar Emisor / Programa de Emisión / Emisión 


            If Val(RadComboBoxEmisorID.Text.Length) <= 0 Then
                RequiredFieldEmisor.ErrorMessage = "Debe seleccionar Emisor."
                RequiredFieldEmisor.IsValid = False
                RequiredFieldEmisor.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1
            End If

            If Val(RadComboBoxEmisionID.Text.Length) <= 0 Then
                RequiredFieldEmision.ErrorMessage = "Debe seleccionar Programa Emisión."
                RequiredFieldEmision.IsValid = False
                RequiredFieldEmision.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1
            End If

            If Val(RadComboBoxEmisionSerie.Text.Length) <= 0 Then
                RequiredFieldEmisionSerie.ErrorMessage = "Debe seleccionar Emisión."
                RequiredFieldEmisionSerie.IsValid = False
                RequiredFieldEmisionSerie.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1
            End If



            ' 1.0 Validar : Cantidad Títulos
            '

            If Val(txtCantidadTitulos.Text.Length) <= 0 Or txtCantidadTitulos.Text = "0" Then
                RequiredFieldCantidadTitulos.ErrorMessage = "Cantidad Títulos"
                RequiredFieldCantidadTitulos.IsValid = False
                RequiredFieldCantidadTitulos.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1

            End If

            '
            ' 2.0 Validar : Fecha  
            '

            If Val(txtFecha.DbSelectedDate.ToString.Length) <= 0 Then
                RequiredFieldFecha.ErrorMessage = "Fecha Incorrecta"
                RequiredFieldFecha.IsValid = False
                RequiredFieldFecha.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1
            End If


            ' 3.0 Validar : Valor Transado
            '

            If Val(txtValorTransado.Text.Length) <= 0 Or txtValorTransado.Text = "0" Or txtValorTransado.Text = "" Then
                RequiredFieldValorTransado.ErrorMessage = "Valor Transado"
                RequiredFieldValorTransado.IsValid = False
                RequiredFieldValorTransado.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1

            End If


            ' 4.0 Validar : Precio
            '

            If Val(txtPrecio.Text.Length) <= 0 Or txtPrecio.Text = "0" Or txtPrecio.Text = "" Then
                RequiredFieldPrecio.ErrorMessage = "Precio"
                RequiredFieldPrecio.IsValid = False
                RequiredFieldPrecio.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1
            End If




            ' 5.0 Validar Moneda


            If Val(RadComboMoneda.Text.Length) <= 0 Then
                RequiredFieldMoneda.ErrorMessage = "Debe seleccionar Moneda."
                RequiredFieldMoneda.IsValid = False
                RequiredFieldMoneda.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1
            End If


            If Val(RadComboPuestoBolsaComprador.Text.Length) <= 0 Then
                RequiredFieldPuestoComprador.ErrorMessage = "Debe seleccionar Puesto Bolsa."
                RequiredFieldPuestoComprador.IsValid = False
                RequiredFieldPuestoComprador.Enabled = True
                ValidarOperacionesValoresEnFirme = ValidarOperacionesValoresEnFirme + 1
            End If


            ' Las validaciones no pasaron correctamente.
            If ValidarOperacionesValoresEnFirme > 0 Then
                Exit Sub
            End If

            '
            ' Deshabilitar botón de guardar
            '
            e.Item.Enabled = False


            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            if Session("Guardado") = "SI"

                InjectScriptLabel.Text = "<script>MensajeGuardar('Registro Guardado Exitosamente... ')</" + "script>"
                'InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                'InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            Else
                InjectScriptLabel.Text = "<script>MensajeGuardar('ERROR al Guardar la Información... ')</" + "script>"

            End If

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Sub Nuevo()

        If ViewState("EsNuevo") = True Then

            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
            Dim cSql As String = ""


            cSql =
                    "INSERT INTO [dbo].[OperacionesValoresEnFirme]" &
                    "           ([fecha_oper]" &
                    "           ,[num_oper]" &
                    "           ,[hora_oper]" &
                    "           ,[nemo_ins]" &
                    "           ,[cod_isin]" &
                    "           ,[usuario]" &
                    "           ,[fecha_emi]" &
                    "           ,[fecha_venc]" &
                    "           ,[dias_acum]" &
                    "           ,[dias_alvenci]" &
                    "           ,[valor_nom_unit]" &
                    "           ,[cant_tit]" &
                    "           ,[valor_nom_tot]" &
                    "           ,[interes_acum]" &
                    "           ,[precio_limp]" &
                    "           ,[valor_tran]" &
                    "           ,[yield]" &
                    "           ,[fecha_liquid]" &
                    "           ,[mone_trans]" &
                    "           ,[pues_comp]" &
                    "           ,[pues_vend]" &
                    "           ,[descrip_instru]" &
                    "           ,[mercado]" &
                    "           ,[tasa_interes]" &
                    "           ,[tipo_interes]" &
                    "           ,[periodicidad]" &
                    "           ,[sector]" &
                    "           ,[status_trans]" &
                    "           ,[nemo_emisor]" &
                    "           ,[descrip_emisor]" &
                    "           ,[AplicaParaPrecio]" &
                    "           ,[TipoNegociacion]" &
                    "           ,[pues_comp_siopel]" &
                    "           ,[pues_vend_siopel]" &
                    "           ,[Especie]" &
                    "           ,[CodRueda]" &
                    "           ,[clave]" &
                    "           ,[NumeroOfertaVenta]" &
                    "           ,[NumeroOfertaCompra]" &
                    "           ,[Origen]" &
                    "           ,[Destino]" &
                    "           ,[pata]" &
                    "           ,[PlazoOperacionfutura]" &
                    "           ,[IDOperacionVinculada]" &
                    "           ,[PrecioReferencia]" &
                    "           ,[EmisionID] " &
                    "           ,[EmisorID]" &
                    "           ,[EmisionSerieID]" &
                    "           ,[PuestoBolsaCompradorID]" &
                    "           ,[PuestoBolsaVendedorID]" &
                    "           ,[TipoMonedaID]" &
                    "           ,[MercadoID]" &
                    "           ,[RuedaID])" &
                    "     VALUES" &
                    "           (@fecha_oper" &
                    "           ,@num_oper" &
                    "           ,@hora_oper" &
                    "           ,@nemo_ins" &
                    "           ,@cod_isin" &
                    "           ,@usuario" &
                    "           ,@fecha_emi" &
                    "           ,@fecha_venc" &
                    "           ,@dias_acum" &
                    "           ,@dias_alvenci" &
                    "           ,@valor_nom_unit" &
                    "           ,@cant_tit" &
                    "           ,@valor_nom_tot" &
                    "           ,@interes_acum" &
                    "           ,@precio_limp" &
                    "           ,@valor_tran" &
                    "           ,@yield" &
                    "           ,@fecha_liquid" &
                    "           ,@mone_trans" &
                    "           ,@pues_comp" &
                    "           ,@pues_vend" &
                    "           ,@descrip_instru" &
                    "           ,@mercado" &
                    "           ,@tasa_interes" &
                    "           ,@tipo_interes" &
                    "           ,@periodicidad" &
                    "           ,@sector" &
                    "           ,@status_trans" &
                    "           ,@nemo_emisor" &
                    "           ,@descrip_emisor" &
                    "           ,@AplicaParaPrecio" &
                    "           ,@TipoNegociacion" &
                    "           ,@pues_comp_siopel" &
                    "           ,@pues_vend_siopel" &
                    "           ,@Especie" &
                    "           ,@CodRueda" &
                    "           ,@clave" &
                    "           ,@NumeroOfertaVenta" &
                    "           ,@NumeroOfertaCompra" &
                    "           ,@Origen" &
                    "           ,@Destino" &
                    "           ,@pata" &
                    "           ,@PlazoOperacionfutura" &
                    "           ,@IDOperacionVinculada" &
                    "           ,@PrecioReferencia" &
                    "           ,@EmisionID" &
                    "           ,@EmisorID" &
                    "           ,@EmisionSerieID" &
                    "           ,@PuestoBolsaCompradorID" &
                    "           ,@PuestoBolsaVendedorID" &
                    "           ,@TipoMonedaID" &
                    "           ,@MercadoID" &
                    "           ,@RuedaID)"


            Try

                ' Numero de Operación 
                Dim nNumeroOperacion As Int64 = oper.GetSecuence("OperacionesValoresEnFirme", "num_oper", Nothing)


                ' -------------------------------------------------------------------------------
                ' Buscar en EmisionSerie : Los datos relacionados a esta entidad
                ' vEmisionSerie
                ' -------------------------------------------------------------------------------
                Dim cSqlConsultaEmisionSerie As String = "Select * from vEmisionSerieOperacionesEnFirme where EmisionSerieID = " + Me.RadComboBoxEmisionSerie.SelectedValue

                Dim DatosSerie As DataSet = oper.ExDataSet(cSqlConsultaEmisionSerie)
                Dim TablaSerie As DataTable = DatosSerie.Tables(0)


                Cnx.Open()
                Dim cmd As New SqlCommand(cSql, Cnx)

                ' ------------------------------------------------------------------------------------------
                ' Fecha Operación
                ' ------------------------------------------------------------------------------------------ 
                If Me.txtFecha.DbSelectedDate <> Nothing Then
                    cmd.Parameters.Add(New SqlParameter("@fecha_oper", SqlDbType.Date)).Value = IIf(Me.txtFecha.DbSelectedDate.ToString.Length > 0, Me.txtFecha.DbSelectedDate, DBNull.Value)
                Else
                    cmd.Parameters.Add(New SqlParameter("@fecha_oper", SqlDbType.Date)).Value = DBNull.Value
                End If

                ' No. Oparación
                cmd.Parameters.Add(New SqlParameter("@num_oper", SqlDbType.NChar)).Value = nNumeroOperacion.ToString().TrimEnd()

                ' Hora Operación
                cmd.Parameters.Add(New SqlParameter("@hora_oper", SqlDbType.DateTime)).Value = DateTime.Now.TimeOfDay().ToString()

                ' Usuario 
                cmd.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NChar)).Value = "0"



                ' ------------------------------------------------------------------
                ' Datos desde EmisionSerie
                ' ------------------------------------------------------------------

                cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisionID.Text.Length > 0, Me.RadComboBoxEmisionSerie.SelectedValue, 1)



                If TablaSerie.Rows.Count > 0

                    For Each Fila As DataRow In TablaSerie.Rows


                        ' Código de la Serie
                        cmd.Parameters.Add(New SqlParameter("@nemo_ins", SqlDbType.NChar)).Value = Fila("CodigoSerie").ToString().TrimEnd()


                        ' Código ISIN
                        cmd.Parameters.Add(New SqlParameter("@cod_isin", SqlDbType.NChar)).Value = Fila("CodigoISIN").ToString().Substring(0, 13)

                        ' Fecha Emisión
                        If Me.txtFecha.DbSelectedDate <> Nothing Then
                            cmd.Parameters.Add(New SqlParameter("@fecha_emi", SqlDbType.Date)).Value = Fila("FechaEmision")
                        Else
                            cmd.Parameters.Add(New SqlParameter("@fecha_emi", SqlDbType.Date)).Value = DBNull.Value
                        End If

                        ' Fecha Vencimiento
                        If Me.txtFecha.DbSelectedDate <> Nothing Then
                            cmd.Parameters.Add(New SqlParameter("@fecha_venc", SqlDbType.Date)).Value = Fila("FechaVencimiento")
                        Else
                            cmd.Parameters.Add(New SqlParameter("@fecha_venc", SqlDbType.Date)).Value = DBNull.Value
                        End If


                        ' Dias Acumulados (Verificar Calculo)
                        cmd.Parameters.Add(New SqlParameter("@dias_acum", SqlDbType.BigInt)).Value = 0

                        ' Dias Al Vencimiento (Calculado)
                        Try
                            cmd.Parameters.Add(New SqlParameter("@dias_alvenci", SqlDbType.BigInt)).Value = DateDiff(DateInterval.Day, txtFecha.DbSelectedDate, Convert.ToDateTime(Fila("FechaVencimiento")))
                        Catch
                            cmd.Parameters.Add(New SqlParameter("@dias_alvenci", SqlDbType.BigInt)).Value = 0
                        End Try


                        ' Cantidad Títulos 
                        cmd.Parameters.Add(New SqlParameter("@cant_tit", SqlDbType.BigInt)).Value = IIf(txtCantidadTitulos.Text.Length > 0, Me.txtCantidadTitulos.Text, 0)



                        ' Valor Nominal Unitario
                        cmd.Parameters.Add(New SqlParameter("@valor_nom_unit", SqlDbType.Money)).Value = Fila("ValorUnitarioNominal")
                        ' Cantidad de Títulos
                        cmd.Parameters.Add(New SqlParameter("@CantidadTitulos", SqlDbType.BigInt)).Value = IIf(Me.txtCantidadTitulos.Text.ToString.Length > 0, Me.txtCantidadTitulos.Text, 0)
                        ' Valor Nominal Total
                        cmd.Parameters.Add(New SqlParameter("@valor_nom_tot", SqlDbType.Money)).Value = Convert.ToDecimal(Fila("ValorUnitarioNominal")) * IIf(Me.txtCantidadTitulos.Text.ToString.Length > 0, Me.txtCantidadTitulos.Text, 0)
                        ' Interes Acumulado
                        cmd.Parameters.Add(New SqlParameter("@interes_acum", SqlDbType.BigInt)).Value = 0
                        ' Precio Limpio
                        cmd.Parameters.Add(New SqlParameter("@precio_limp", SqlDbType.Decimal)).Value = IIf(Me.txtPrecio.Text.ToString.Length > 0, Me.txtPrecio.Text, 0)
                        ' Valor Transado
                        cmd.Parameters.Add(New SqlParameter("@valor_tran", SqlDbType.Decimal)).Value = IIf(Me.txtValorTransado.Text.ToString.Length > 0, Me.txtValorTransado.Text, 0)
                        ' Yield
                        cmd.Parameters.Add(New SqlParameter("@yield", SqlDbType.Decimal)).Value = 0

                        ' Fecha Liquidación
                        If Me.txtFecha.DbSelectedDate <> Nothing Then
                            cmd.Parameters.Add(New SqlParameter("@fecha_liquid", SqlDbType.Date)).Value = Fila("FechaLiquidacion")
                        Else
                            cmd.Parameters.Add(New SqlParameter("@fecha_liquid", SqlDbType.Date)).Value = DBNull.Value
                        End If

                        ' Descripción Instrumento
                        cmd.Parameters.Add(New SqlParameter("@descrip_instru", SqlDbType.NChar)).Value = Fila("NombreInstrumento")

                        ' Tasa Interes
                        cmd.Parameters.Add(New SqlParameter("@tasa_interes", SqlDbType.Decimal)).Value = Fila("Tasa")

                        ' Tipo Interes
                        cmd.Parameters.Add(New SqlParameter("@tipo_interes", SqlDbType.NChar)).Value = "FIXED"

                        ' Periodicida
                        cmd.Parameters.Add(New SqlParameter("@periodicidad", SqlDbType.NChar)).Value = Fila("EquivalenteAnual").ToString()

                        ' sector
                        cmd.Parameters.Add(New SqlParameter("@sector", SqlDbType.NChar)).Value = Fila("TipoEmisor")
                        ' nemo_emisor
                        cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisorID.Text.Length > 0, Me.RadComboBoxEmisorID.SelectedValue, 1)
                        cmd.Parameters.Add(New SqlParameter("@nemo_emisor", SqlDbType.NChar)).Value = Fila("CodEmisorBVRD").ToString().Substring(0, 10)
                        ' descrip_emisor
                        cmd.Parameters.Add(New SqlParameter("@descrip_emisor", SqlDbType.NChar)).Value = Fila("NombreEmisor")

                    Next

                    ' Moneda 
                    cmd.Parameters.Add(New SqlParameter("@TipoMonedaID", SqlDbType.BigInt)).Value = IIf(Me.RadComboMoneda.Text.Length > 0, Me.RadComboMoneda.SelectedValue, 1)

                    Try
                        cmd.Parameters.Add(New SqlParameter("@mone_trans", SqlDbType.NChar)).Value = oper.ExecuteScalar("Select Simbolo from TipoMoneda where TipoMonedaID = " + Me.RadComboMoneda.SelectedValue.ToString())
                    Catch
                        cmd.Parameters.Add(New SqlParameter("@mone_trans", SqlDbType.NChar)).Value = ""
                    End Try


                    ' Puesto Comprador
                    cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCompradorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboPuestoBolsaComprador.Text.Length > 0, Me.RadComboPuestoBolsaComprador.SelectedValue, 1)

                    Try
                        cmd.Parameters.Add(New SqlParameter("@pues_comp", SqlDbType.NChar)).Value = oper.ExecuteScalar("select PuestoBolsaCodigo from PuestoBolsa where PuestoBolsaID = " + Me.RadComboPuestoBolsaComprador.SelectedValue.ToString())
                    Catch
                        cmd.Parameters.Add(New SqlParameter("@pues_comp", SqlDbType.NChar)).Value = ""
                    End Try


                    ' Puesto Vendedor
                    cmd.Parameters.Add(New SqlParameter("@PuestoBolsaVendedorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboPuestoBolsaVendedor.Text.Length > 0, Me.RadComboPuestoBolsaVendedor.SelectedValue, 1)

                    Try
                        cmd.Parameters.Add(New SqlParameter("@pues_vend", SqlDbType.NChar)).Value = oper.ExecuteScalar("select PuestoBolsaCodigo from PuestoBolsa where PuestoBolsaID = " + Me.RadComboPuestoBolsaVendedor.SelectedValue.ToString())
                    Catch
                        cmd.Parameters.Add(New SqlParameter("@pues_vend", SqlDbType.NChar)).Value = ""
                    End Try


                    
                    ' Mercado
                    cmd.Parameters.Add(New SqlParameter("@MercadoID", SqlDbType.BigInt)).Value = IIf(Me.RadComboMercado.Text.Length > 0, Me.RadComboMercado.SelectedValue, 1)

                    Try
                        cmd.Parameters.Add(New SqlParameter("@mercado", SqlDbType.NChar)).Value = oper.ExecuteScalar("Select CodigoMercado from Mercado where MercadoID = " + Me.RadComboMercado.SelectedValue.ToString())
                    Catch
                        cmd.Parameters.Add(New SqlParameter("@mercado", SqlDbType.NChar)).Value = ""
                    End Try



                    ' status_trans
                    cmd.Parameters.Add(New SqlParameter("@status_trans", SqlDbType.NChar)).Value = "Aceptada"


                    'AplicaParaPrecio
                    cmd.Parameters.Add(New SqlParameter("@AplicaParaPrecio", SqlDbType.Bit)).Value = 1
                    'TipoNegociacion
                    cmd.Parameters.Add(New SqlParameter("@TipoNegociacion", SqlDbType.NChar)).Value = ""
                    'pues_comp_siopel
                    cmd.Parameters.Add(New SqlParameter("@pues_comp_siopel", SqlDbType.NChar)).Value = ""
                    'pues_vend_siopel
                    cmd.Parameters.Add(New SqlParameter("@pues_vend_siopel", SqlDbType.NChar)).Value = ""
                    'Especie
                    cmd.Parameters.Add(New SqlParameter("@Especie", SqlDbType.NChar)).Value = ""

                    'CodRueda
                    cmd.Parameters.Add(New SqlParameter("@RuedaID", SqlDbType.BigInt)).Value = IIf(Me.RadComboRueda.Text.Length > 0, Me.RadComboRueda.SelectedValue, 1)
                    cmd.Parameters.Add(New SqlParameter("@CodRueda", SqlDbType.NChar)).Value = "FIRM"

                    'clave
                    cmd.Parameters.Add(New SqlParameter("@clave", SqlDbType.NChar)).Value = ""

                    'NumeroOfertaVenta
                    cmd.Parameters.Add(New SqlParameter("@NumeroOfertaVenta", SqlDbType.NChar)).Value = txtNumeroOfertaVenta.Text
                    'NumeroOfertaCompra
                    cmd.Parameters.Add(New SqlParameter("@NumeroOfertaCompra", SqlDbType.NChar)).Value = txtNumeroOfertaCompra.Text

                    'Origen
                    cmd.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NChar)).Value = IIf(Me.RadComboOrigen.Text.Length > 0, Me.RadComboOrigen.SelectedValue, "")
                    'Destino
                    cmd.Parameters.Add(New SqlParameter("@Destino", SqlDbType.NChar)).Value = IIf(Me.RadComboDestino.Text.Length > 0, Me.RadComboDestino.SelectedValue, "")

                    'pata
                    cmd.Parameters.Add(New SqlParameter("@pata", SqlDbType.NChar)).Value = "0"

                    'PlazoOperacionfutura
                    cmd.Parameters.Add(New SqlParameter("@PlazoOperacionfutura", SqlDbType.NChar)).Value = DBNull.Value

                    'IDOperacionVinculada
                    cmd.Parameters.Add(New SqlParameter("@IDOperacionVinculada", SqlDbType.Decimal)).Value = 0

                    'PrecioReferencia
                    cmd.Parameters.Add(New SqlParameter("@PrecioReferencia", SqlDbType.Decimal)).Value = 0

                    ' ID Emision
                    cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisionID.Text.Length > 0, Me.RadComboBoxEmisionID.SelectedValue, 1)





                End If



                cmd.ExecuteNonQuery()

                cSql = oper.CovertirComandoATexto(cmd)

                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Operaciones Valores En Firme", "EditarOperacionesValoresEnFirme", cSql)

                Session("Guardado") = "SI"


            Catch sql_ex As SqlClient.SqlException

                If sql_ex.ErrorCode = -2146232060 Then
                    Session("Guardado") = "NO"
                    Exit Sub
                End If

            Catch ex As Exception
                Session("Guardado") = "NO"
            Finally


                Cnx.Close()

            End Try
        End If



    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [OperacionesValoresEnFirme]  where IdOperacion='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow

        Try
            For Each MyRow In ds.Tables(0).Rows

                If Not IsDBNull(MyRow.Item("EmisionID")) Then Me.RadComboBoxEmisionID.SelectedValue = Trim(MyRow.Item("EmisionID"))
                If Not IsDBNull(MyRow.Item("EmisorID")) Then Me.RadComboBoxEmisorID.SelectedValue = Trim(MyRow.Item("EmisorID"))
                If Not IsDBNull(MyRow.Item("EmisionSerieID")) Then Me.RadComboBoxEmisionSerie.SelectedValue = Trim(MyRow.Item("EmisionSerieID"))

                If Not IsDBNull(MyRow.Item("cod_isin")) Then Me.txtISIN.Text = Trim(MyRow.Item("cod_isin")) Else Me.txtISIN.Text = ""



                If Not IsDBNull(MyRow.Item("fecha_oper")) Then Me.txtFecha.DbSelectedDate = Trim(MyRow.Item("fecha_oper")) Else Me.txtFecha.DbSelectedDate = ""


                If Not IsDBNull(MyRow.Item("cant_tit")) Then Me.txtCantidadTitulos.Text = Trim(MyRow.Item("cant_tit")) Else Me.txtCantidadTitulos.Text = ""
                If Not IsDBNull(MyRow.Item("valor_tran")) Then Me.txtValorTransado.Text = Trim(MyRow.Item("valor_tran")) Else Me.txtValorTransado.Text = ""
                If Not IsDBNull(MyRow.Item("precio_limp")) Then Me.txtPrecio.Text = Trim(MyRow.Item("precio_limp")) Else Me.txtPrecio.Text = ""


                If Not IsDBNull(MyRow.Item("TipoMonedaID")) Then Me.RadComboMoneda.SelectedValue = Trim(MyRow.Item("TipoMonedaID"))
                If Not IsDBNull(MyRow.Item("MercadoID")) Then Me.RadComboMercado.SelectedValue = Trim(MyRow.Item("MercadoID"))
                If Not IsDBNull(MyRow.Item("RuedaID")) Then Me.RadComboRueda.SelectedValue = Trim(MyRow.Item("RuedaID"))

                If Not IsDBNull(MyRow.Item("PuestoBolsaCompradorID")) Then Me.RadComboPuestoBolsaComprador.SelectedValue = Trim(MyRow.Item("PuestoBolsaCompradorID"))
                If Not IsDBNull(MyRow.Item("PuestoBolsaVendedorID")) Then Me.RadComboPuestoBolsaVendedor.SelectedValue = Trim(MyRow.Item("PuestoBolsaVendedorID"))

                If Not IsDBNull(MyRow.Item("NumeroOfertaCompra")) Then Me.txtNumeroOfertaCompra.Text = Trim(MyRow.Item("NumeroOfertaCompra")) Else Me.txtNumeroOfertaCompra.Text = ""
                If Not IsDBNull(MyRow.Item("NumeroOfertaVenta")) Then Me.txtNumeroOfertaVenta.Text = Trim(MyRow.Item("NumeroOfertaVenta")) Else Me.txtNumeroOfertaVenta.Text = ""

                If Not IsDBNull(MyRow.Item("Origen")) Then Me.RadComboOrigen.SelectedValue = Trim(MyRow.Item("Origen"))
                If Not IsDBNull(MyRow.Item("Destino")) Then Me.RadComboDestino.SelectedValue = Trim(MyRow.Item("Destino"))


            Next

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
        End Try

    End Sub
    Sub Actualizar()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())


        Dim cSql As String = "UPDATE [dbo].[OperacionesValoresEnFirme]" &
                    "   SET [fecha_oper] = @fecha_oper" &
                    "      ,[nemo_ins] = @nemo_ins" &
                    "      ,[cod_isin] = @cod_isin" &
                    "      ,[usuario] = @usuario" &
                    "      ,[fecha_emi] = @fecha_emi" &
                    "      ,[fecha_venc] = @fecha_venc" &
                    "      ,[dias_acum] = @dias_acum" &
                    "      ,[dias_alvenci] = @dias_alvenci" &
                    "      ,[valor_nom_unit] = @valor_nom_unit" &
                    "      ,[cant_tit] = @cant_tit" &
                    "      ,[valor_nom_tot] = @valor_nom_tot" &
                    "      ,[interes_acum] = @interes_acum" &
                    "      ,[precio_limp] = @precio_limp" &
                    "      ,[valor_tran] = @valor_tran" &
                    "      ,[yield] = @yield" &
                    "      ,[fecha_liquid] = @fecha_liquid" &
                    "      ,[mone_trans] = @mone_trans" &
                    "      ,[pues_comp] = @pues_comp" &
                    "      ,[pues_vend] = @pues_vend" &
                    "      ,[descrip_instru] = @descrip_instru" &
                    "      ,[mercado] = @mercado" &
                    "      ,[tasa_interes] = @tasa_interes" &
                    "      ,[tipo_interes] = @tipo_interes" &
                    "      ,[periodicidad] = @periodicidad" &
                    "      ,[sector] = @sector" &
                    "      ,[status_trans] = @status_trans" &
                    "      ,[nemo_emisor] = @nemo_emisor" &
                    "      ,[descrip_emisor] = @descrip_emisor" &
                    "      ,[AplicaParaPrecio] = @AplicaParaPrecio" &
                    "      ,[TipoNegociacion] = @TipoNegociacion" &
                    "      ,[pues_comp_siopel] = @pues_comp_siopel" &
                    "      ,[pues_vend_siopel] = @pues_vend_siopel" &
                    "      ,[Especie] = @Especie" &
                    "      ,[CodRueda] = @CodRueda" &
                    "      ,[clave] = @clave" &
                    "      ,[NumeroOfertaVenta] = @NumeroOfertaVenta" &
                    "      ,[NumeroOfertaCompra] = @NumeroOfertaCompra" &
                    "      ,[Origen] = @Origen" &
                    "      ,[Destino] = @Destino" &
                    "      ,[pata] = @pata" &
                    "      ,[PlazoOperacionfutura] = @PlazoOperacionfutura" &
                    "      ,[IDOperacionVinculada] = @IDOperacionVinculada" &
                    "      ,[PrecioReferencia] = @PrecioReferencia" &
                    "      ,[EmisionID] = @EmisionID" &
                    "      ,[EmisorID] = @EmisorID" &
                    "      ,[EmisionSerieID] = @EmisionSerieID" &
                    "      ,[PuestoBolsaCompradorID] = @PuestoBolsaCompradorID" &
                    "      ,[PuestoBolsaVendedorID] = @PuestoBolsaVendedorID" &
                    "      ,[TipoMonedaID] = @TipoMonedaID" &
                    "      ,[MercadoID] = @MercadoID" &
                    "      ,[RuedaID] = @RuedaID" &
                    " WHERE [IdOperacion] = @IdOperacion  "


        Try


            ' -------------------------------------------------------------------------------
            ' Buscar en EmisionSerie : Los datos relacionados a esta entidad
            ' vEmisionSerie
            ' -------------------------------------------------------------------------------
            Dim cSqlConsultaEmisionSerie As String = "Select * from vEmisionSerieOperacionesEnFirme where EmisionSerieID = " + Me.RadComboBoxEmisionSerie.SelectedValue

            Dim DatosSerie As DataSet = oper.ExDataSet(cSqlConsultaEmisionSerie)
            Dim TablaSerie As DataTable = DatosSerie.Tables(0)


            Cnx.Open()
            Dim cmd As New SqlCommand(cSql, Cnx)

            ' ------------------------------------------------------------------------------------------
            ' Fecha Operación
            ' ------------------------------------------------------------------------------------------ 
            If Me.txtFecha.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@fecha_oper", SqlDbType.Date)).Value = IIf(Me.txtFecha.DbSelectedDate.ToString.Length > 0, Me.txtFecha.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@fecha_oper", SqlDbType.Date)).Value = DBNull.Value
            End If


            ' Usuario 
            cmd.Parameters.Add(New SqlParameter("@usuario", SqlDbType.NChar)).Value = "0"

            ' ------------------------------------------------------------------
            ' Datos desde EmisionSerie
            ' ------------------------------------------------------------------

            cmd.Parameters.Add(New SqlParameter("@EmisionSerieID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisionID.Text.Length > 0, Me.RadComboBoxEmisionSerie.SelectedValue, 1)


            If TablaSerie.Rows.Count > 0

                For Each Fila As DataRow In TablaSerie.Rows


                    ' Código de la Serie
                    cmd.Parameters.Add(New SqlParameter("@nemo_ins", SqlDbType.NChar)).Value = Fila("CodigoSerie").ToString().TrimEnd()


                    ' Código ISIN
                    cmd.Parameters.Add(New SqlParameter("@cod_isin", SqlDbType.NChar)).Value = Fila("CodigoISIN").ToString().Substring(0, 13)

                    ' Fecha Emisión
                    If Me.txtFecha.DbSelectedDate <> Nothing Then
                        cmd.Parameters.Add(New SqlParameter("@fecha_emi", SqlDbType.Date)).Value = Fila("FechaEmision")
                    Else
                        cmd.Parameters.Add(New SqlParameter("@fecha_emi", SqlDbType.Date)).Value = DBNull.Value
                    End If

                    ' Fecha Vencimiento
                    If Me.txtFecha.DbSelectedDate <> Nothing Then
                        cmd.Parameters.Add(New SqlParameter("@fecha_venc", SqlDbType.Date)).Value = Fila("FechaVencimiento")
                    Else
                        cmd.Parameters.Add(New SqlParameter("@fecha_venc", SqlDbType.Date)).Value = DBNull.Value
                    End If


                    ' Dias Acumulados (Verificar Calculo)
                    cmd.Parameters.Add(New SqlParameter("@dias_acum", SqlDbType.BigInt)).Value = 0

                    ' Dias Al Vencimiento (Calculado)
                    Try
                        cmd.Parameters.Add(New SqlParameter("@dias_alvenci", SqlDbType.BigInt)).Value = DateDiff(DateInterval.Day, txtFecha.DbSelectedDate, Convert.ToDateTime(Fila("FechaVencimiento")))
                    Catch
                        cmd.Parameters.Add(New SqlParameter("@dias_alvenci", SqlDbType.BigInt)).Value = 0
                    End Try


                    ' Cantidad Títulos 
                    cmd.Parameters.Add(New SqlParameter("@cant_tit", SqlDbType.BigInt)).Value = IIf(Me.txtCantidadTitulos.Text.Length > 0, Me.txtCantidadTitulos.Text, 0)



                    ' Valor Nominal Unitario
                    cmd.Parameters.Add(New SqlParameter("@valor_nom_unit", SqlDbType.Money)).Value = Fila("ValorUnitarioNominal")
                    ' Cantidad de Títulos
                    cmd.Parameters.Add(New SqlParameter("@CantidadTitulos", SqlDbType.BigInt)).Value = IIf(Me.txtCantidadTitulos.Text.ToString.Length > 0, Me.txtCantidadTitulos.Text, 0)
                    ' Valor Nominal Total
                    cmd.Parameters.Add(New SqlParameter("@valor_nom_tot", SqlDbType.Money)).Value = Convert.ToDecimal(Fila("ValorUnitarioNominal")) * IIf(Me.txtCantidadTitulos.Text.ToString.Length > 0, Me.txtCantidadTitulos.Text, 0)
                    ' Interes Acumulado
                    cmd.Parameters.Add(New SqlParameter("@interes_acum", SqlDbType.BigInt)).Value = 0
                    ' Precio Limpio
                    cmd.Parameters.Add(New SqlParameter("@precio_limp", SqlDbType.Decimal)).Value = IIf(Me.txtPrecio.Text.ToString.Length > 0, Me.txtPrecio.Text, 0)
                    ' Valor Transado
                    cmd.Parameters.Add(New SqlParameter("@valor_tran", SqlDbType.Decimal)).Value = IIf(Me.txtValorTransado.Text.ToString.Length > 0, Me.txtValorTransado.Text, 0)
                    ' Yield
                    cmd.Parameters.Add(New SqlParameter("@yield", SqlDbType.Decimal)).Value = 0

                    ' Fecha Liquidación
                    If Me.txtFecha.DbSelectedDate <> Nothing Then
                        cmd.Parameters.Add(New SqlParameter("@fecha_liquid", SqlDbType.Date)).Value = Fila("FechaLiquidacion")
                    Else
                        cmd.Parameters.Add(New SqlParameter("@fecha_liquid", SqlDbType.Date)).Value = DBNull.Value
                    End If

                    ' Descripción Instrumento
                    cmd.Parameters.Add(New SqlParameter("@descrip_instru", SqlDbType.NChar)).Value = Fila("NombreInstrumento")

                    ' Tasa Interes
                    cmd.Parameters.Add(New SqlParameter("@tasa_interes", SqlDbType.Decimal)).Value = Fila("Tasa")

                    ' Tipo Interes
                    cmd.Parameters.Add(New SqlParameter("@tipo_interes", SqlDbType.NChar)).Value = "FIXED"

                    ' Periodicida
                    cmd.Parameters.Add(New SqlParameter("@periodicidad", SqlDbType.NChar)).Value = Fila("EquivalenteAnual").ToString()

                    ' sector
                    cmd.Parameters.Add(New SqlParameter("@sector", SqlDbType.NChar)).Value = Fila("TipoEmisor")
                    ' nemo_emisor
                    cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisorID.Text.Length > 0, Me.RadComboBoxEmisorID.SelectedValue, 1)
                    cmd.Parameters.Add(New SqlParameter("@nemo_emisor", SqlDbType.NChar)).Value = Fila("CodEmisorBVRD").ToString().Substring(0, 10)
                    ' descrip_emisor
                    cmd.Parameters.Add(New SqlParameter("@descrip_emisor", SqlDbType.NChar)).Value = Fila("NombreEmisor")

                Next

                ' Moneda 
                cmd.Parameters.Add(New SqlParameter("@TipoMonedaID", SqlDbType.BigInt)).Value = IIf(Me.RadComboMoneda.Text.Length > 0, Me.RadComboMoneda.SelectedValue, 1)

                Try
                    cmd.Parameters.Add(New SqlParameter("@mone_trans", SqlDbType.NChar)).Value = oper.ExecuteScalar("Select Simbolo from TipoMoneda where TipoMonedaID = " + Me.RadComboMoneda.SelectedValue.ToString())
                Catch
                    cmd.Parameters.Add(New SqlParameter("@mone_trans", SqlDbType.NChar)).Value = ""
                End Try


                ' Puesto Comprador
                cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCompradorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboPuestoBolsaComprador.Text.Length > 0, Me.RadComboPuestoBolsaComprador.SelectedValue, 1)

                Try
                    cmd.Parameters.Add(New SqlParameter("@pues_comp", SqlDbType.NChar)).Value = oper.ExecuteScalar("select PuestoBolsaCodigo from PuestoBolsa where PuestoBolsaID = " + Me.RadComboPuestoBolsaComprador.SelectedValue.ToString())
                Catch
                    cmd.Parameters.Add(New SqlParameter("@pues_comp", SqlDbType.NChar)).Value = ""
                End Try


                ' Puesto Vendedor
                cmd.Parameters.Add(New SqlParameter("@PuestoBolsaVendedorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboPuestoBolsaVendedor.Text.Length > 0, Me.RadComboPuestoBolsaVendedor.SelectedValue, 1)

                Try
                    cmd.Parameters.Add(New SqlParameter("@pues_vend", SqlDbType.NChar)).Value = oper.ExecuteScalar("select PuestoBolsaCodigo from PuestoBolsa where PuestoBolsaID = " + Me.RadComboPuestoBolsaVendedor.SelectedValue.ToString())
                Catch
                    cmd.Parameters.Add(New SqlParameter("@pues_vend", SqlDbType.NChar)).Value = ""
                End Try



                ' Mercado
                cmd.Parameters.Add(New SqlParameter("@MercadoID", SqlDbType.BigInt)).Value = IIf(Me.RadComboMercado.Text.Length > 0, Me.RadComboMercado.SelectedValue, 1)

                Try
                    cmd.Parameters.Add(New SqlParameter("@mercado", SqlDbType.NChar)).Value = oper.ExecuteScalar("Select CodigoMercado from Mercado where MercadoID = " + Me.RadComboMercado.SelectedValue.ToString())
                Catch
                    cmd.Parameters.Add(New SqlParameter("@mercado", SqlDbType.NChar)).Value = ""
                End Try

                ' status_trans
                cmd.Parameters.Add(New SqlParameter("@status_trans", SqlDbType.NChar)).Value = "Aceptada"


                'AplicaParaPrecio
                cmd.Parameters.Add(New SqlParameter("@AplicaParaPrecio", SqlDbType.Bit)).Value = 1
                'TipoNegociacion
                cmd.Parameters.Add(New SqlParameter("@TipoNegociacion", SqlDbType.NChar)).Value = ""
                'pues_comp_siopel
                cmd.Parameters.Add(New SqlParameter("@pues_comp_siopel", SqlDbType.NChar)).Value = ""
                'pues_vend_siopel
                cmd.Parameters.Add(New SqlParameter("@pues_vend_siopel", SqlDbType.NChar)).Value = ""
                'Especie
                cmd.Parameters.Add(New SqlParameter("@Especie", SqlDbType.NChar)).Value = ""

                'CodRueda
                cmd.Parameters.Add(New SqlParameter("@RuedaID", SqlDbType.BigInt)).Value = IIf(Me.RadComboRueda.Text.Length > 0, Me.RadComboRueda.SelectedValue, 1)
                cmd.Parameters.Add(New SqlParameter("@CodRueda", SqlDbType.NChar)).Value = "FIRM"

                'clave
                cmd.Parameters.Add(New SqlParameter("@clave", SqlDbType.NChar)).Value = ""

                'NumeroOfertaVenta
                cmd.Parameters.Add(New SqlParameter("@NumeroOfertaVenta", SqlDbType.NChar)).Value = txtNumeroOfertaVenta.Text
                'NumeroOfertaCompra
                cmd.Parameters.Add(New SqlParameter("@NumeroOfertaCompra", SqlDbType.NChar)).Value = txtNumeroOfertaCompra.Text

                'Origen
                cmd.Parameters.Add(New SqlParameter("@Origen", SqlDbType.NChar)).Value = IIf(Me.RadComboOrigen.Text.Length > 0, Me.RadComboOrigen.SelectedValue, "")
                'Destino
                cmd.Parameters.Add(New SqlParameter("@Destino", SqlDbType.NChar)).Value = IIf(Me.RadComboDestino.Text.Length > 0, Me.RadComboDestino.SelectedValue, "")

                'pata
                cmd.Parameters.Add(New SqlParameter("@pata", SqlDbType.NChar)).Value = "0"

                'PlazoOperacionfutura
                cmd.Parameters.Add(New SqlParameter("@PlazoOperacionfutura", SqlDbType.NChar)).Value = DBNull.Value

                'IDOperacionVinculada
                cmd.Parameters.Add(New SqlParameter("@IDOperacionVinculada", SqlDbType.Decimal)).Value = 0

                'PrecioReferencia
                cmd.Parameters.Add(New SqlParameter("@PrecioReferencia", SqlDbType.Decimal)).Value = 0

                ' ID Emision
                cmd.Parameters.Add(New SqlParameter("@EmisionID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmisionID.Text.Length > 0, Me.RadComboBoxEmisionID.SelectedValue, 1)


                cmd.Parameters.Add(New SqlParameter("@IdOperacion", SqlDbType.BigInt)).Value = CInt(ViewState("Code"))

            End If



            cmd.ExecuteNonQuery()

            cSql = oper.CovertirComandoATexto(cmd)


            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualzar Operaciones Valores En Firme", "EditarOperacionesValoresEnFirme", cSql)

            Session("Guardado") = "SI"


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Session("Guardado") = "NO"
                Exit Sub
            End If

        Catch ex As Exception
            Session("Guardado") = "NO"
        Finally


            Cnx.Close()

        End Try


        ViewState("EsNuevo") = False
    End Sub

    Protected Sub RadComboPuestoBolsaComprador_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboPuestoBolsaComprador.SelectedIndexChanged

        RadComboPuestoBolsaVendedor.SelectedValue = RadComboPuestoBolsaComprador.SelectedValue


    End Sub

    Protected Sub RadComboBoxEmisionSerie_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxEmisionSerie.SelectedIndexChanged

        Dim cSqlConsultaEmisionSerie As String = "Select * from vEmisionSerieOperacionesEnFirme where EmisionSerieID = " + Me.RadComboBoxEmisionSerie.SelectedValue

        Dim DatosSerie As DataSet = oper.ExDataSet(cSqlConsultaEmisionSerie)
        Dim TablaSerie As DataTable = DatosSerie.Tables(0)

        txtISIN.Text = ""

        If TablaSerie.Rows.Count > 0

            For Each Fila As DataRow In TablaSerie.Rows
                txtISIN.Text = Fila("CodigoISIN").ToString().TrimEnd()

            Next

        End If

    End Sub


End Class

