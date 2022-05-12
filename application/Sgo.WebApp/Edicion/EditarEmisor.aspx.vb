Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Upload


Partial Class Edicion_EditarEmisor
    Inherits System.Web.UI.Page
    Private oper As New operation
    Private Documento As String
    Private RutaDocumento As String
    Private CodigoEmisor As New Integer

    ' -----------------------------------------------------------------------------------
    ' Carga Inicial de la página.
    ' -----------------------------------------------------------------------------------

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
                Session("Code") = Nothing
                Session("Ajax") = Nothing
                Codigo.Text = ViewState("Code")
            Else
                ViewState("Code") = Request.QueryString("EmisorID")
                Codigo.Text = ViewState("Code")
            End If

            ' Seleccionar TAB inicial 
            RadTabStrip1.SelectedIndex = 0
            RadMultiPage1.SelectedIndex = 0

            If ViewState("EsNuevo") = True Then
                RadTabStrip1.Tabs(1).Enabled = False
                RadTabStrip1.Tabs(2).Enabled = False
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                CodigoEmisor = Request.QueryString("EmisorID")
                EditarEmisor()
            End If

            With RadGridDocumento
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With


            With RadGridCalificaciones
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

        End If

        'Borrar Serie  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            If BorrarEmisor() Then
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            End If
        End If

        If Not IsPostBack Then
            Dim RutaN As String = ""
            Dim FileNameN As String = ""
            '0 para cargar desde una bd
            LeerImagen(0)

        End If
        If RadTabStrip1.Tabs.Item(0).Enabled = True Then
            RadToolBar1.Items.Item(0).Enabled = False
        Else
            RadToolBar1.Items.Item(0).Enabled = True
        End If
        txtCodEmisorBVRD.Focus()
        txtCodEmisorBVRD.SelectionOnFocus = SelectionOnFocus.SelectAll
    End Sub


    ' -----------------------------------------------------------------------------------
    ' B a r r a   S u p e r i o r
    ' -----------------------------------------------------------------------------------

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick


        If e.Item.Value = 0 Then ' G U A R D A R

            Guardado.Text = ""

            ' -------------------------------------------------------------
            ' Validaciones de los Campos de las diferentes Pantallas
            ' -------------------------------------------------------------
            Select Case Me.RadTabStrip1.SelectedIndex

                Case 0 ' Datos Genrales 

                Case 1 ' Documentos

                Case 2 ' Calificaciones de Riesgo


            End Select


            If ViewState("EsNuevo") = True Then

                Select Case Me.RadTabStrip1.SelectedIndex
                    Case 0
                        InsertarEmisor()
                        'RadTabStrip1.Tabs(0).Enabled = False
                        ViewState("EsNuevo") = False
                        Exit Sub
                    Case 1
                        Dim p As String = Codigo.Text
                        InsertarDocumento(Codigo.Text)
                        LimpiaDocumento()
                        RadGridDocumento.DataBind()

                        RadUpload2.Visible = True
                        BtnSubirLogo.Enabled = True
                        RadProgressArea2.Visible = True

                    Case 2
                        InsertarCalificacionRiesgo(Codigo.Text)
                        LimpiaCalificacionRiesgo()
                        RadGridCalificaciones.DataBind()

                End Select

            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then

                'CodigoEmisor = Request.QueryString("EmisorID")

                Select Case Me.RadTabStrip1.SelectedIndex
                    Case 0
                        Call ActualizaEmisor()
                    Case 1 ' Documentos

                        ActualizaDocumento()
                        LimpiaDocumento()
                        RadGridDocumento.DataBind()
                        RadUpload2.Visible = True
                        BtnSubirLogo.Enabled = True
                        RadProgressArea1.Visible = True

                    Case 2 ' Calificaciones de Riesgo

                        ActualizaCalificacionRiesgo()
                        LimpiaCalificacionRiesgo()
                        RadGridCalificaciones.DataBind()

                End Select

                'ViewState("EsNuevo") = True
                'RadTabStrip1.Tabs(0).Enabled = False

            End If


        ElseIf e.Item.Value = 1 Then  ' C A N C E L A R

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then  ' N U E V O



            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0

                Case 1 ' Documentos

                    LimpiaDocumento()
                    RadGridDocumento.DataBind()
                    RadUpload2.Visible = True
                    BtnSubirLogo.Enabled = True
                    RadProgressArea2.Visible = True
                    ViewState("EsNuevo") = True

                Case 2 ' Calificaciones de Riesgo

                    LimpiaCalificacionRiesgo()
                    RadGridCalificaciones.DataBind()
                    ViewState("EsNuevo") = True


            End Select

        ElseIf e.Item.Value = 3 Then  ' B O R R A R

            Select Case Me.RadTabStrip1.SelectedIndex

                Case 0

                    InjectScriptLabel.Text = "<script>Delete()</" + "script>"

                Case 1 ' Documentos



                Case 2
                    BorrarCalificacionRiesgo()
                    RadGridCalificaciones.DataBind()
            End Select

        End If


    End Sub

#Region " Datos Generales Emisor"

    ' ----------------------------------------------------------------------------------
    ' Operaciones con Emisor ( Datos Generales )
    ' ----------------------------------------------------------------------------------
    Sub EditarEmisor()

        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Emisor]  where EmisorID='" & Codigo.Text & "'")
        Dim MyRow As DataRow


        For Each MyRow In ds.Tables(0).Rows

            '--------------------------------------------  E m i s o r  ---------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("CodEmisorBVRD")) Then Me.txtCodEmisorBVRD.Text = Trim(MyRow.Item("CodEmisorBVRD"))
            If Not IsDBNull(MyRow.Item("NombreEmisor")) Then Me.txtNombreEmisor.Text = Trim(MyRow.Item("NombreEmisor"))
            If Not IsDBNull(MyRow.Item("CodEnSistema")) Then Me.txtCodEnSistema.Text = Trim(MyRow.Item("CodEnSistema"))

            If Not IsDBNull(MyRow.Item("CodigoCorto")) Then Me.txtCodigoCorto.Text = Trim(MyRow.Item("CodigoCorto"))

            If Not IsDBNull(MyRow.Item("RNC")) Then Me.txtRNC.Text = Trim(MyRow.Item("RNC"))
            If Not IsDBNull(MyRow.Item("Direccion")) Then Me.txtDireccion.Text = Trim(MyRow.Item("Direccion"))
            If Not IsDBNull(MyRow.Item("NombreEdificio")) Then Me.txtNombreEdificio.Text = Trim(MyRow.Item("NombreEdificio"))

            If Not IsDBNull(MyRow.Item("CasaAptoNo")) Then Me.txtCasaAptoNo.Text = Trim(MyRow.Item("CasaAptoNo"))

            If Not IsDBNull(MyRow.Item("Piso")) Then Me.txtPiso.Text = Trim(MyRow.Item("Piso"))

            If Not IsDBNull(MyRow.Item("PaisID")) Then Me.RadComboBoxPais.SelectedValue = Trim(MyRow.Item("PaisID"))
            If Not IsDBNull(MyRow.Item("CiudadID")) Then Me.RadComboBoxCiudad.SelectedValue = Trim(MyRow.Item("CiudadID"))

            If Not IsDBNull(MyRow.Item("Telefono")) Then Me.txtTelefonoEmisor.Text = Trim(MyRow.Item("Telefono"))
            If Not IsDBNull(MyRow.Item("RegistroSIV")) Then Me.txtNoRegistroSIV.Text = Trim(MyRow.Item("RegistroSIV"))

            If Not IsDBNull(MyRow.Item("Email")) Then Me.txtEmail.Text = Trim(MyRow.Item("Email"))
            If Not IsDBNull(MyRow.Item("PaginaWeb")) Then Me.txtWeb.Text = Trim(MyRow.Item("PaginaWeb"))


            If Not IsDBNull(MyRow.Item("FechaConstitucion")) Then Me.txtFechaConstitucion.DbSelectedDate = Trim(MyRow.Item("FechaConstitucion"))

            If Not IsDBNull(MyRow.Item("PresidentedelaEmpresa")) Then Me.txtPresidente.Text = Trim(MyRow.Item("PresidentedelaEmpresa"))

            If Not IsDBNull(MyRow.Item("FechaIngresoComoEmisor")) Then Me.txtFechaIngreso.DbSelectedDate = Trim(MyRow.Item("FechaIngresoComoEmisor"))
            If Not IsDBNull(MyRow.Item("TipoEmisorID")) Then Me.RadComboBoxTipoEmisor.SelectedValue = Trim(MyRow.Item("TipoEmisorID"))
            If Not IsDBNull(MyRow.Item("TipoEntidadID")) Then Me.RadComboBoxTipoEntidad.SelectedValue = Trim(MyRow.Item("TipoEntidadID"))
            If Not IsDBNull(MyRow.Item("Estatus")) Then Me.RadComboBoxEstatus.SelectedValue = Trim(MyRow.Item("Estatus"))

            If Not IsDBNull(MyRow.Item("CapitalSuscritoPagado")) Then Me.txtCapitalSuscritoPagado.Text = Trim(MyRow.Item("CapitalSuscritoPagado"))

            If Not IsDBNull(MyRow.Item("Estatus")) Then Me.RadComboBoxEstatus.Text = Trim(MyRow.Item("Estatus"))
            If Not IsDBNull(MyRow.Item("TipoEmisorID")) Then Me.RadComboBoxTipoEmisor.SelectedValue = Trim(MyRow.Item("TipoEmisorID"))
            'If Not IsDBNull(MyRow.Item("TipoEntidadID")) Then Me.RadComboBoxTipoEntidad.SelectedValue = Trim(MyRow.Item("TipoEntidadID"))

            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcionEmisor.Text = Trim(MyRow.Item("Descripcion"))


            If Not IsDBNull(MyRow.Item("SectorID")) Then Me.RadComboBoxActividadEconomica.SelectedValue = Trim(MyRow.Item("SectorID"))
            If Not IsDBNull(MyRow.Item("ActividadEconomicaID")) Then Me.RadComboBoxSector.SelectedValue = Trim(MyRow.Item("ActividadEconomicaID"))
            If Not IsDBNull(MyRow.Item("CodigoSIMVEntidad")) Then Me.txtCodigoSIMVEntidad.Text = Trim(MyRow.Item("CodigoSIMVEntidad"))
            If Not IsDBNull(MyRow.Item("CodigoSIMVFondo")) Then Me.txtCodigoSIMVFondo.Text = Trim(MyRow.Item("CodigoSIMVFondo"))


        Next


    End Sub

    Sub InsertarEmisor()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 

        Try
            Dim Sql As String = "INSERT INTO [Emisor] ([CodEmisorBVRD] ,[NombreEmisor] ,[CodEnSistema],[CodigoCorto] ,[RNC] ,[Direccion] ,[NombreEdificio],[CasaAptoNo],[Piso],[PaisID],[CiudadID],[Telefono],[RegistroSIV] ,[PaginaWeb],[FechaConstitucion] ,[PresidentedelaEmpresa],[CapitalSuscritoPagado],[FechaIngresoComoEmisor] ,[SubirLogo],[Estatus],[TipoEmisorID],[TipoEntidadID],[Descripcion],[SectorID],[ActividadEconomicaID],[CodigoSIMVEntidad],[CodigoSIMVFondo]) VALUES (@CodEmisorBVRD ,@NombreEmisor ,@CodEnSistema, @CodigoCorto ,@RNC ,@Direccion ,@NombreEdificio,@CasaAptoNo,@Piso,@PaisID,@CiudadID,@Telefono,@RegistroSIV,@PaginaWeb,@FechaConstitucion ,@PresidentedelaEmpresa,@CapitalSuscritoPagado,@FechaIngresoComoEmisor ,@SubirLogo,@Estatus,@TipoEmisorID, @TipoEntidadID, @Descripcion,@SectorID,@ActividadEconomicaID,@CodigoSIMVEntidad,@CodigoSIMVFondo)"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            Documento = ViewState("FileName")
            RutaDocumento = DirectorioTemporal + Documento

            cmd.Parameters.Add(New SqlParameter("@CodEmisorBVRD", SqlDbType.VarChar)).Value = IIf(Me.txtCodEmisorBVRD.Text.Length > 0, Me.txtCodEmisorBVRD.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NombreEmisor", SqlDbType.VarChar)).Value = IIf(Me.txtNombreEmisor.Text.Length > 0, Me.txtNombreEmisor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodEnSistema", SqlDbType.VarChar)).Value = IIf(Me.txtCodEnSistema.Text.Length > 0, Me.txtCodEnSistema.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@CodigoCorto", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoCorto.Text.Length > 0, Me.txtCodigoCorto.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@RNC", SqlDbType.VarChar)).Value = IIf(Me.txtRNC.Text.Length > 0, Me.txtRNC.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccion.Text.Length > 0, Me.txtDireccion.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NombreEdificio", SqlDbType.VarChar)).Value = IIf(Me.txtNombreEdificio.Text.Length > 0, Me.txtNombreEdificio.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CasaAptoNo", SqlDbType.VarChar)).Value = IIf(Me.txtCasaAptoNo.Text.Length > 0, Me.txtCasaAptoNo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Piso", SqlDbType.VarChar)).Value = IIf(Me.txtPiso.Text.Length > 0, Me.txtPiso.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PaisID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxPais.Text.Length > 0, Me.RadComboBoxPais.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CiudadID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxCiudad.Text.Length > 0, Me.RadComboBoxCiudad.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoEmisor.Text.Length > 0, Me.txtTelefonoEmisor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RegistroSIV", SqlDbType.VarChar)).Value = IIf(Me.txtNoRegistroSIV.Text.Length > 0, Me.txtNoRegistroSIV.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmail.Text.Length > 0, Me.txtEmail.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PaginaWeb", SqlDbType.VarChar)).Value = IIf(Me.txtWeb.Text.Length > 0, Me.txtWeb.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PresidentedelaEmpresa", SqlDbType.VarChar)).Value = IIf(Me.txtPresidente.Text.Length > 0, Me.txtPresidente.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CapitalSuscritoPagado", SqlDbType.Money)).Value = IIf(Me.txtCapitalSuscritoPagado.Text.Length > 0, Me.txtCapitalSuscritoPagado.Text, DBNull.Value)


            If Me.txtFechaConstitucion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = IIf(Me.txtFechaConstitucion.DbSelectedDate.ToString.Length > 0, Me.txtFechaConstitucion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.txtFechaIngreso.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaIngresoComoEmisor", SqlDbType.Date)).Value = IIf(Me.txtFechaIngreso.DbSelectedDate.ToString.Length > 0, Me.txtFechaIngreso.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaIngresoComoEmisor", SqlDbType.Date)).Value = DBNull.Value
            End If


            ' -------------------------------------------------------------
            ' 2016.07.05 : Validar que el logo se sube correctamente
            ' -------------------------------------------------------------
            If RutaDocumento <> Nothing And Documento <> "" Then
                Try
                    If RutaDocumento <> Nothing And Documento <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@SubirLogo", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                    Else
                        cmd.Parameters.Add(New SqlParameter("@SubirLogo", SqlDbType.VarBinary)).Value = DBNull.Value
                    End If
                Catch ex As Exception
                    cmd.Parameters.Add(New SqlParameter("@SubirLogo", SqlDbType.VarBinary)).Value = DBNull.Value
                End Try
            Else
                cmd.Parameters.Add(New SqlParameter("@SubirLogo", SqlDbType.VarBinary)).Value = DBNull.Value
            End If


            cmd.Parameters.Add(New SqlParameter("@Estatus", SqlDbType.VarChar)).Value = IIf(Me.RadComboBoxEstatus.Text.Length > 0, Me.RadComboBoxEstatus.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoEmisorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoEmisor.Text.Length > 0, Me.RadComboBoxTipoEmisor.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoEntidadID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoEntidad.Text.Length > 0, Me.RadComboBoxTipoEntidad.SelectedValue, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcionEmisor.Text.Length > 0, Me.txtDescripcionEmisor.Text, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@SectorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxActividadEconomica.Text.Length > 0, Me.RadComboBoxActividadEconomica.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ActividadEconomicaID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxSector.Text.Length > 0, Me.RadComboBoxSector.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoSIMVEntidad", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoSIMVEntidad.Text.Length > 0, Me.txtCodigoSIMVEntidad.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoSIMVFondo", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoSIMVFondo.Text.Length > 0, Me.txtCodigoSIMVFondo.Text, DBNull.Value)


            cmd.ExecuteNonQuery()
            Codigo.Text = oper.ExecuteScalar("select IDENT_CURRENT('Emisor')")   'CodigoEmisor 

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisor", "EditarEmisor", csql)



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally

            RadTabStrip1.Tabs(1).Enabled = True
            RadTabStrip1.Tabs(2).Enabled = True
            Guardado.ForeColor = Color.Blue
            Guardado.Text = "Guardado con éxito"

            Notification1.Text = "Guardado con éxito!"
            Notification1.Show()

            Cnx.Close()
        End Try

    End Sub

    Sub ActualizaEmisor()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro


        Try

            Documento = ViewState("FileName")
            RutaDocumento = DirectorioTemporal + Documento 'Server.MapPath("~/tmp/")
            Dim Sql As String
            If RutaDocumento <> Nothing And Documento <> "" Then
                Sql = "UPDATE  [Emisor] SET " &
                                "[CodEmisorBVRD] = @CodEmisorBVRD" &
                                ",[NombreEmisor] = @NombreEmisor" &
                                ",[CodEnSistema] = @CodEnSistema" &
                                ",[CodigoCorto] = @CodigoCorto" &
                                ",[RNC] = @RNC" &
                                ",[Direccion] = @Direccion " &
                                ",[NombreEdificio] = @NombreEdificio" &
                                ",[CasaAptoNo] = @CasaAptoNo" &
                                ",[Piso] = @Piso" &
                                ",[PaisID] = @PaisID" &
                                ",[CiudadID] = @CiudadID" &
                                ",[Telefono] = @Telefono" &
                                ",[RegistroSIV] = @RegistroSIV" &
                                ",[Email] = @Email" &
                                ",[PaginaWeb] = @PaginaWeb" &
                                ",[FechaConstitucion] = @FechaConstitucion" &
                                ",[PresidentedelaEmpresa] = @PresidentedelaEmpresa" &
                                ",[CapitalSuscritoPagado] = @CapitalSuscritoPagado" &
                                ",[FechaIngresoComoEmisor] = @FechaIngresoComoEmisor" &
                                ",[SubirLogo] = @SubirLogo" &
                                ",[Estatus] = @Estatus" &
                                ",[TipoEmisorID] = @TipoEmisorID" &
                                ",[TipoEntidadID] = @TipoEntidadID" &
                                ",[Descripcion] = @Descripcion" &
                                ",[SectorID] = @SectorID" &
                                ",[ActividadEconomicaID] = @ActividadEconomicaID" &
                                ",[CodigoSIMVEntidad] = @CodigoSIMVEntidad" &
                                ",[CodigoSIMVFondo] = @CodigoSIMVFondo" &
                                " WHERE EmisorID = @EmisorID"
            Else
                Sql = "UPDATE  [Emisor] SET " &
                                "[CodEmisorBVRD] = @CodEmisorBVRD" &
                                ",[NombreEmisor] = @NombreEmisor" &
                                ",[CodEnSistema] = @CodEnSistema" &
                                ",[CodigoCorto] = @CodigoCorto" &
                                ",[RNC] = @RNC" &
                                ",[Direccion] = @Direccion " &
                                ",[NombreEdificio] = @NombreEdificio" &
                                ",[CasaAptoNo] = @CasaAptoNo" &
                                ",[Piso] = @Piso" &
                                ",[PaisID] = @PaisID" &
                                ",[CiudadID] = @CiudadID" &
                                ",[Telefono] = @Telefono" &
                                ",[RegistroSIV] = @RegistroSIV" &
                                ",[Email] = @Email" &
                                ",[PaginaWeb] = @PaginaWeb" &
                                ",[FechaConstitucion] = @FechaConstitucion" &
                                ",[PresidentedelaEmpresa] = @PresidentedelaEmpresa" &
                                ",[CapitalSuscritoPagado] = @CapitalSuscritoPagado" &
                                ",[FechaIngresoComoEmisor] = @FechaIngresoComoEmisor" &
                                ",[Estatus] = @Estatus" &
                                ",[TipoEmisorID] = @TipoEmisorID" &
                                ",[TipoEntidadID] = @TipoEntidadID" &
                                ",[Descripcion] = @Descripcion" &
                                ",[SectorID] = @SectorID" &
                                ",[ActividadEconomicaID] = @ActividadEconomicaID" &
                                ",[CodigoSIMVEntidad] = @CodigoSIMVEntidad" &
                                ",[CodigoSIMVFondo] = @CodigoSIMVFondo" &
                                " WHERE EmisorID = @EmisorID"
            End If


            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.BigInt)).Value = IIf(Codigo.Text.Length > 0, Codigo.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@CodEmisorBVRD", SqlDbType.VarChar)).Value = IIf(Me.txtCodEmisorBVRD.Text.Length > 0, Me.txtCodEmisorBVRD.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NombreEmisor", SqlDbType.VarChar)).Value = IIf(Me.txtNombreEmisor.Text.Length > 0, Me.txtNombreEmisor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodEnSistema", SqlDbType.VarChar)).Value = IIf(Me.txtCodEnSistema.Text.Length > 0, Me.txtCodEnSistema.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoCorto", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoCorto.Text.Length > 0, Me.txtCodigoCorto.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RNC", SqlDbType.VarChar)).Value = IIf(Me.txtRNC.Text.Length > 0, Me.txtRNC.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccion.Text.Length > 0, Me.txtDireccion.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NombreEdificio", SqlDbType.VarChar)).Value = IIf(Me.txtNombreEdificio.Text.Length > 0, Me.txtNombreEdificio.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CasaAptoNo", SqlDbType.VarChar)).Value = IIf(Me.txtCasaAptoNo.Text.Length > 0, Me.txtCasaAptoNo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Piso", SqlDbType.VarChar)).Value = IIf(Me.txtPiso.Text.Length > 0, Me.txtPiso.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PaisID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxPais.Text.Length > 0, Me.RadComboBoxPais.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CiudadID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxCiudad.Text.Length > 0, Me.RadComboBoxCiudad.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoEmisor.Text.Length > 0, Me.txtTelefonoEmisor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RegistroSIV", SqlDbType.VarChar)).Value = IIf(Me.txtNoRegistroSIV.Text.Length > 0, Me.txtNoRegistroSIV.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmail.Text.Length > 0, Me.txtEmail.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PaginaWeb", SqlDbType.VarChar)).Value = IIf(Me.txtWeb.Text.Length > 0, Me.txtWeb.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PresidentedelaEmpresa", SqlDbType.VarChar)).Value = IIf(Me.txtPresidente.Text.Length > 0, Me.txtPresidente.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CapitalSuscritoPagado", SqlDbType.Money)).Value = IIf(Me.txtCapitalSuscritoPagado.Text.Length > 0, Me.txtCapitalSuscritoPagado.Text, DBNull.Value)



            If Me.txtFechaConstitucion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = IIf(Me.txtFechaConstitucion.DbSelectedDate.ToString.Length > 0, Me.txtFechaConstitucion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = DBNull.Value
            End If

            If Me.txtFechaIngreso.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaIngresoComoEmisor", SqlDbType.Date)).Value = IIf(Me.txtFechaIngreso.DbSelectedDate.ToString.Length > 0, Me.txtFechaIngreso.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaIngresoComoEmisor", SqlDbType.Date)).Value = DBNull.Value
            End If

            Try
                If RutaDocumento <> Nothing And Documento <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@SubirLogo", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                Else
                    cmd.Parameters.Add(New SqlParameter("@SubirLogo", SqlDbType.VarBinary)).Value = DBNull.Value
                End If
            Catch ex As Exception
                cmd.Parameters.Add(New SqlParameter("@SubirLogo", SqlDbType.VarBinary)).Value = DBNull.Value
            End Try



            cmd.Parameters.Add(New SqlParameter("@Estatus", SqlDbType.VarChar)).Value = IIf(Me.RadComboBoxEstatus.Text.Length > 0, Me.RadComboBoxEstatus.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoEmisorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoEmisor.Text.Length > 0, Me.RadComboBoxTipoEmisor.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoEntidadID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoEntidad.Text.Length > 0, Me.RadComboBoxTipoEntidad.SelectedValue, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcionEmisor.Text.Length > 0, Me.txtDescripcionEmisor.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@SectorID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxActividadEconomica.Text.Length > 0, Me.RadComboBoxActividadEconomica.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@ActividadEconomicaID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxSector.Text.Length > 0, Me.RadComboBoxSector.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoSIMVEntidad", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoSIMVEntidad.Text.Length > 0, Me.txtCodigoSIMVEntidad.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoSIMVFondo", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoSIMVFondo.Text.Length > 0, Me.txtCodigoSIMVFondo.Text, DBNull.Value)
            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisor", "EditarEmisor", csql)



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Guardado.ForeColor = Color.Blue
            Guardado.Text = "Actualizado con éxito"

            Notification1.Text = "Actualizado con éxito!"
            Notification1.Show()

            LeerImagen(0)
            Cnx.Close()
        End Try

    End Sub

    Sub LimpiaEmisor()

        txtCodEmisorBVRD.Text = ""
        txtNombreEmisor.Text = ""
        txtCodEnSistema.Text = ""
        txtCodigoCorto.Text = ""
        txtRNC.Text = ""
        txtDireccion.Text = ""
        txtNombreEdificio.Text = ""
        txtCasaAptoNo.Text = ""
        txtPiso.Text = ""
        txtTelefonoEmisor.Text = ""
        txtNoRegistroSIV.Text = ""
        txtEmail.Text = ""
        txtWeb.Text = ""
        txtFechaConstitucion.SelectedDate = Today.Date
        txtPresidente.Text = ""
        txtCapitalSuscritoPagado.Text = ""
        txtFechaIngreso.SelectedDate = Today.Date
        txtDescripcionEmisor.Text = ""

        With RadComboBoxPais
            .Text = ""
            .ClearSelection()
        End With

        With RadComboBoxCiudad
            .Text = ""
            .ClearSelection()
        End With

        With RadComboBoxTipoEmisor
            .Text = ""
            .ClearSelection()
        End With

        'With RadComboBoxTipoEntidad
        '    .Text = ""
        '    .ClearSelection()
        'End With

        With RadComboBoxSector
            .Text = ""
            .ClearSelection()
        End With

        With RadComboBoxActividadEconomica
            .Text = ""
            .ClearSelection()
        End With

    End Sub

    Sub LeerBinario(ByVal DocumentoID As Integer, ByVal DocumentoRuta As String, ByVal DocumentoNombre As String)
        Try

            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            Dim Sql As String = "Select Adjunto, Nombre From EmisorDocumento Where EmisorDocumentoID ='" & DocumentoID & "'"

            Dim aBytDocumento() As Byte = Nothing
            Dim oFileStream As FileStream

            Using loComando As New SqlCommand(Sql, Cnx)
                Cnx.Open()
                Using drDocumentos As SqlDataReader = loComando.ExecuteReader(CommandBehavior.SingleRow)
                    If drDocumentos.Read() Then
                        aBytDocumento = CType(drDocumentos("Adjunto"), Byte())
                        DocumentoNombre = drDocumentos("Nombre").ToString().Replace(" ", "")
                    End If

                End Using
            End Using

            DeleteFiles(DocumentoNombre)

            oFileStream = New FileStream(DocumentoRuta + DocumentoNombre, FileMode.CreateNew, FileAccess.Write)
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
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 

        If RadUpload1.UploadedFiles.Count > 0 Then
            Try
                For Each validFile As UploadedFile In RadUpload1.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = DirectorioTemporal 'Server.MapPath("~/tmp/")
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    BtnSubirLogo.Enabled = False
                    RadUpload1.Visible = False
                    RadProgressArea1.Visible = False
                    'El numero 1 es cuando se carga la imagen desde un path
                    LeerImagen(1)
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

    Sub LeerImagen(Metodo As Integer)
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 

        If Metodo = 1 Then '1 Para cargar la imagen desde la carpeta temp
            Documento = ViewState("FileName")
            RutaDocumento = DirectorioTemporal + Documento
            ImagenEmisor.DataValue = ConvierteBinario(RutaDocumento)
            ImagenEmisor.Visible = True
        Else '0 para cargar imagen desde bd
            Try
                ImagenEmisor.Visible = True
                Using Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

                    Dim SQL As String = "SELECT SubirLogo FROM Emisor WHERE EmisorID = " & CInt(ViewState("Code")) & ""
                    Dim myCommand As New SqlCommand(SQL, Cnx)

                    Cnx.Open()
                    Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                    If myReader.Read() Then
                        ImagenEmisor.DataValue = DirectCast(myReader("SubirLogo"), Byte())
                    End If

                    myReader.Close()
                    Cnx.Close()
                End Using
            Catch ex As Exception
                ImagenEmisor.Visible = False
                MensajeLogo.ForeColor = Color.Blue
                MensajeLogo.Text = "Este emisor no tiene foto."

            End Try
        End If


    End Sub

    Function BorrarEmisor() As Boolean

        Dim ID = CInt(ViewState("Code"))
        Dim cCantidadEmisiones As String = ""
        Dim csql As String = ""

        cCantidadEmisiones = oper.ExecuteScalar("select count(*) as conteo from Emision where EmisorID ='" & ViewState("Code") & "' group by EmisionID")
        cCantidadEmisiones = IIf(cCantidadEmisiones = "", "0", cCantidadEmisiones)

        If Integer.Parse(cCantidadEmisiones) > 0 Then

            InjectScriptLabel.Text = "<script>alert('No se puede borrar este Emisor, ya tiene Emisiones asociadas')</" + "script>"
            Return False
        Else


            If ID > 0 Then
                Try

                    csql = "delete from dbo.EmisorDocumento where EmisorID='" & ID & "'"
                    oper.ExecuteNonQuery(csql)
                    oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisor", "EditarEmisor", csql)

                    csql = "delete from dbo.EmisorCalificacionRiesgo where EmisorID='" & ID & "'"
                    oper.ExecuteNonQuery(csql)
                    oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisor", "EditarEmisor", csql)

                    csql = "delete from dbo.Emisor where EmisorID='" & ID & "'"
                    oper.ExecuteNonQuery(csql)
                    oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisor", "EditarEmisor", csql)


                    InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                    InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                    Return True
                Catch ex As Exception
                    InjectScriptLabel.Text = "<script>alert('No se puede borrar este Nemotécnico, ya que esta asociado a otras entradas')</" + "script>"
                End Try

            End If

        End If

        Return True

    End Function

    ' -----------------------------------------------------------------------
    ' Actualizar el combo de Ciudad, con el pais seleccionado
    ' !!! Importante !!!!
    ' Al combo pais ( Padre ) AutoPostBack=True, CausesValidation = False
    ' -----------------------------------------------------------------------
    Protected Sub RadComboBoxPais_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxPais.SelectedIndexChanged
        RadComboBoxCiudad.DataBind()
    End Sub


#End Region

#Region " Datos del Documento "

    ' -----------------------------------------------------
    ' Operaciones con documentos
    ' -----------------------------------------------------
    Sub InsertarDocumento(ByVal CodigoEmisor As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 


        Try
            Dim Sql As String = "INSERT INTO  [EmisorDocumento] ([EmisorID] ,[Fecha],[Nombre],[Adjunto],[TipoDocumentoID],[Descripcion]) VALUES (@EmisorID ,@Fecha,@Nombre,@Adjunto,@TipoDocumentoID,@Descripcion)"

            Cnx.Open()

            'Call prc_ConvertFileToBinary()
            Documento = ViewState("FileName")
            RutaDocumento = DirectorioTemporal + Documento 'Server.MapPath("~/tmp/")


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.BigInt)).Value = CodigoEmisor
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = Documento
            cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBoxDocumentos.Text.Length > 0, Me.RadComboBoxDocumentos.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcion.Text.Length > 0, Me.txtDescripcion.Text, DBNull.Value)

            cmd.ExecuteNonQuery()

            DeleteFiles(Documento)

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisor Documento", "EditarEmisor", csql)


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try


    End Sub
    Sub ActualizaDocumento()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 

        Try

            Documento = ViewState("FileName")
            RutaDocumento = DirectorioTemporal + Documento


            Dim Sql As String = "Update EmisorDocumento set  [Fecha]=@Fecha,[Nombre]=@Nombre,[Adjunto]=@Adjunto,[TipoDocumentoID]=@TipoDocumentoID,Descripcion=@Descripcion  where  [EmisorDocumentoID]=@EmisorDocumentoID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisorDocumentoID", SqlDbType.BigInt)).Value = ViewState("CodeDocumento")
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = Documento
            cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBoxDocumentos.Text.Length > 0, Me.RadComboBoxDocumentos.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcion.Text.Length > 0, Me.txtDescripcion.Text, DBNull.Value)
            cmd.ExecuteNonQuery()

            DeleteFiles(Documento)


            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisor Documento", "EditarEmisor", csql)


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()

        End Try
    End Sub
    Sub LimpiaDocumento()
        Me.txtFechaDocumento.DbSelectedDate = ""
        Me.RadComboBoxDocumentos.SelectedValue = 0
        Me.RadComboBoxDocumentos.Text = ""
        Me.txtDescripcion.Text = ""
    End Sub

    Protected Sub RadGridDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDocumento.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridDocumento.SelectedItems(0)
        Dim ID = dataitem("EmisorDocumentoID").Text
        ViewState("CodeDocumento") = ID
        ViewState("EsNuevo") = False
        RadUpload2.Visible = True
        EditarDocumento()
    End Sub

    Sub EditarDocumento()

        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vEmisorDocumentos]  where  EmisorDocumentoID ='" & CInt(ViewState("CodeDocumento")) & "'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows
            '----------------------------------------------Documento -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFechaDocumento.DbSelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("TipoDocumentoID")) Then Me.RadComboBoxDocumentos.SelectedValue = Trim(MyRow.Item("TipoDocumentoID"))
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcion.Text = Trim(MyRow.Item("Descripcion"))
        Next


    End Sub

    ' -----------------------------------------------------------------------
    ' Boton subir documentos del Emisor
    ' -----------------------------------------------------------------------

    Protected Sub Button2_Click(sender As Object, e As System.EventArgs) Handles Button2.Click

        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 


        If SubidaArchivoDocumentos() = True Then
            Try
                Dim targetFolder As String = DirectorioTemporal

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

            Catch ex As Exception
            End Try
        End If

    End Sub
    Function SubidaArchivoDocumentos() As Boolean
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 


        If RadUpload2.UploadedFiles.Count > 0 Then
            Try
                For Each validFile As UploadedFile In RadUpload2.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = DirectorioTemporal
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    RadUpload2.Visible = False
                    RadProgressArea2.Visible = False
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



#End Region

#Region " Calificación de Riesgo "
    ' -----------------------------------------------------
    ' Operaciones con Calificaciones de Riesgo...
    ' -----------------------------------------------------
    Sub InsertarCalificacionRiesgo(ByVal CodigoEmisor As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Try

            Dim Sql As String = "INSERT INTO  [EmisorCalificacionRiesgo] ([EmisorID],[EmpresaCalificadoraID],[Fecha],[TipoCalificacionRiesgoID],[Nota],[RangoCalificacionID]) VALUES (@EmisorID,@EmpresaCalificadoraID,@Fecha,@TipoCalificacionRiesgoID,@Nota,@RangoCalificacionID)"

            Cnx.Open()


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.BigInt)).Value = CodigoEmisor
            cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmpresaCalificadora.Text.Length > 0, Me.RadComboBoxEmpresaCalificadora.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaCalificacion.DbSelectedDate.ToString.Length > 0, Me.txtFechaCalificacion.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoCalificacionRiesgoID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoCalificacion.Text.Length > 0, Me.RadComboBoxTipoCalificacion.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNotasCalificacion.Text.Length > 0, Me.txtNotasCalificacion.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RangoCalificacionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxRangoCalificacion.Text.Length > 0, Me.RadComboBoxRangoCalificacion.SelectedValue, DBNull.Value)



            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Emisor CalificacionRiesgo", "EditarEmisor", csql)


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
        End Try


    End Sub

    Sub ActualizaCalificacionRiesgo()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim csql As String = ""

        Try


            Dim Sql As String = "Update [EmisorCalificacionRiesgo] set  [EmisorID]=@EmisorID,[EmpresaCalificadoraID]=@EmpresaCalificadoraID,[Fecha]=@Fecha,[TipoCalificacionRiesgoID]=@TipoCalificacionRiesgoID,[Nota]=@Nota, [RangoCalificacionID]=@RangoCalificacionID  where  [EmisorCalificacionRiesgoID]=@EmisorCalificacionRiesgoID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@EmisorCalificacionRiesgoID", SqlDbType.BigInt)).Value = ViewState("CodCalificacion")

            cmd.Parameters.Add(New SqlParameter("@EmisorID", SqlDbType.BigInt)).Value = CodigoEmisor
            cmd.Parameters.Add(New SqlParameter("@EmpresaCalificadoraID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxEmpresaCalificadora.Text.Length > 0, Me.RadComboBoxEmpresaCalificadora.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaCalificacion.DbSelectedDate.ToString.Length > 0, Me.txtFechaCalificacion.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TipoCalificacionRiesgoID", SqlDbType.BigInt)).Value = IIf(Me.RadComboBoxTipoCalificacion.Text.Length > 0, Me.RadComboBoxTipoCalificacion.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNotasCalificacion.Text.Length > 0, Me.txtNotasCalificacion.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RangoCalificacionID", SqlDbType.Int)).Value = IIf(Me.RadComboBoxRangoCalificacion.Text.Length > 0, Me.RadComboBoxRangoCalificacion.SelectedValue, DBNull.Value)


            cmd.ExecuteNonQuery()

            csql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Emisor CalificacionRiesgo", "EditarEmisor", csql)


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception

        Finally
            Cnx.Close()

        End Try


    End Sub

    Sub LimpiaCalificacionRiesgo()

        txtFechaCalificacion.DbSelectedDate = DBNull.Value
        txtNotasCalificacion.Text = ""

        With RadComboBoxEmpresaCalificadora
            .Text = ""
            .ClearSelection()
        End With

        With RadComboBoxTipoCalificacion
            .Text = ""
            .ClearSelection()
        End With

        With RadComboBoxRangoCalificacion
            .Text = ""
            .ClearSelection()
        End With

    End Sub

    Sub EditarCalificacionRiesgo()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [EmisorCalificacionRiesgo]  where  EmisorCalificacionRiesgoID ='" & CInt(ViewState("CodCalificacion")) & "'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows
            '----------------------------------------------Calificacion Riesgo -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFechaCalificacion.DbSelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("Nota")) Then Me.txtNotasCalificacion.Text = Trim(MyRow.Item("Nota"))
            If Not IsDBNull(MyRow.Item("EmpresaCalificadoraID")) Then Me.RadComboBoxEmpresaCalificadora.SelectedValue = Trim(MyRow.Item("EmpresaCalificadoraID"))
            If Not IsDBNull(MyRow.Item("TipoCalificacionRiesgoID")) Then Me.RadComboBoxTipoCalificacion.SelectedValue = Trim(MyRow.Item("TipoCalificacionRiesgoID"))
            If Not IsDBNull(MyRow.Item("RangoCalificacionID")) Then Me.RadComboBoxRangoCalificacion.SelectedValue = Trim(MyRow.Item("RangoCalificacionID"))
        Next


    End Sub

    Protected Sub RadGridCalificaciones_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridCalificaciones.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridCalificaciones.SelectedItems(0)
        Dim ID = dataitem("EmisorCalificacionRiesgoID").Text
        ViewState("CodCalificacion") = ID
        ViewState("EsNuevo") = False
        EditarCalificacionRiesgo()
    End Sub

    Sub BorrarCalificacionRiesgo()

        Dim dataitem As GridDataItem = RadGridCalificaciones.SelectedItems(0)
        Dim ID = dataitem("EmisorCalificacionRiesgoID").Text
        Dim csql As String = "delete from dbo.EmisorCalificacionRiesgo  where EmisorCalificacionRiesgoID='" & ID & "'"
        oper.ExecuteNonQuery(csql)
        LimpiaCalificacionRiesgo()
        lblInfoCalificacionRiesgo.Text = "Registro Eliminado Satisfactoriamente."
        oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Emisión CalificacionRiesgo", "EditarEmision", csql)
    End Sub



#End Region


#Region "Procedimientos Generales "
    Protected Sub SubirLogo_Click(sender As Object, e As EventArgs) Handles BtnSubirLogo.Click
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 

        If SubidaArchivo() = True Then

            Try
                Dim targetFolder As String = DirectorioTemporal
                Dim dt As New DataTable()
                Dim line As String = Nothing
                Dim i As Integer = 0

                MensajeLogo.Text = ""

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

            Catch ex As Exception

            End Try
        End If

    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim DirectorioTemporal As String = Path.GetTempPath() 'Temporal de Windows es seguro 

        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridDocumento.SelectedItems
            ViewState("DocumentoID") = dataItem("EmisorDocumentoID").Text
            ViewState("DocumentoNombre") = Trim(dataItem("Nombre").Text)

            DeleteFiles(ViewState("DocumentoNombre"))

            LeerBinario(ViewState("DocumentoID"), DirectorioTemporal, ViewState("DocumentoNombre"))
        Next
    End Sub


#Region " Manejo de Archivos ..."
    ' -----------------------------------------------------------------------
    ' Procedimientos para Manejos de Archivos
    ' -----------------------------------------------------------------------

    Public Function ConvierteBinario(ByVal Path As String) As Byte()
        Dim sPath As String
        sPath = Path
        Dim Ruta As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim Binario(CInt(Ruta.Length)) As Byte
        Ruta.Read(Binario, 0, CInt(Ruta.Length))
        Ruta.Close()
        Return Binario
    End Function
    Private Sub DeleteFiles(cDocumento As String)
        Dim targetFolder As String = Path.GetTempPath() ' Server.MapPath("~/tmp/")
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

    ' ---------------------------------------------------------------------------------
    ' Seleccionar las pestañas de documentos y Califiación de Riesgo
    ' ---------------------------------------------------------------------------------

    Protected Sub RadTabStrip1_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick

        If e.Tab.Index = 1 Or e.Tab.Index = 2 Then
            ViewState("EsNuevo") = True
            Guardado.Text = ""
        Else
            ViewState("EsNuevo") = False
        End If
        If e.Tab.Index = 0 Then
            RadToolBar1.Items.Item(0).Enabled = False
        Else
            RadToolBar1.Items.Item(0).Enabled = True
        End If
        If Me.RadTabStrip1.SelectedIndex = 3 Then
            RadGridEmisionesLOG.Rebind()

        End If
    End Sub

#End Region

#End Region

End Class
