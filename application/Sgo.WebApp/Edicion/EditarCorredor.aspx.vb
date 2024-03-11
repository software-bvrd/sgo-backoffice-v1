Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Upload
Partial Class EditarCorredor

    Inherits System.Web.UI.Page
    Private oper As New operation
    Private Documento As String
    Private RutaDocumento As String
    Private EstadoCorredor As String


    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        If IsPostBack = False Then



            'Limpiar validaciones

            ValidatorNombreCorredor.Enabled = False
            ValidatorCedulaCorredor.Enabled = False



            'Asignacion de valores nuevo, puestobolsaid
            ViewState("EsNuevo") = Request.QueryString("EsNuevo")
            txtCodigoPuestoBolsa.Text = 0 'Cero por defecto
            txtCodigoPuestoBolsaCorredorID.Text = Request.QueryString("PuestoBolsaCorredorID") 'PuestoBolsaCorredorID
            ' Seleccionar TAB inicial 
            RadTabStrip1.SelectedIndex = 0
            RadMultiPage1.SelectedIndex = 0



            If ViewState("EsNuevo") = True Then
                Dim CodigoCorredor As String = ""
                CodigoCorredor = oper.ExecuteScalar("select dbo.CreacionCodigoCorredor()")
                txtCodBVRD.Text = CodigoCorredor


                RadPageView2.Visible = False
                RadPageView3.Visible = False
                RadPageView4.Visible = False

                RadPageView2.Enabled = False
                RadPageView3.Enabled = False
                RadPageView4.Enabled = False

            Else
                If Session("IdPerfil") <> "1" Then
                    txtNombreCorredor.Enabled = False
                End If
                txtCedula.Enabled = False
                txtCodBVRD.Enabled = False

                    RadPageView2.Visible = True
                    RadPageView3.Visible = True
                    RadPageView4.Visible = True

                    RadPageView2.Enabled = True
                    RadPageView3.Enabled = True
                    RadPageView4.Enabled = True

                    ViewState("CodigoPustoBolsa") = "0"

                End If

                'Doble click radgrid
                If Session("Ajax") = True And Not ViewState("EsNuevo") = True Then
                txtCodigoPuestoBolsaCorredorID.Text = Session("Code") 'PuestoBolsaCorredorID
                ViewState("Consulta") = Session("Consulta")
                'txtCodigoPuestoBolsaCorredorID.Text = Session("Code") 'PuestoBolsaCorredorID
            End If

            'Editar corredor
            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call EditarDatosPersonales()
                'Call EditarLicencia()
                'Call EditarDocumento()
                RadToolBar1.Items.Item(0).Enabled = False
            End If

            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount
            RadProgressArea2.ProgressIndicators = RadProgressArea2.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount

            'Licencia
            LicenciaEstado(False)

            txtNombreCorredor.Focus()
            txtNombreCorredor.SelectionOnFocus = SelectionOnFocus.SelectAll

        End If

        If Not IsPostBack Then
            Dim RutaN As String = ""
            Dim FileNameN As String = ""
            '0 para cargar desde una bd
            LeerImagen(0)
        End If

        'Borrar utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            'Borrar()
        End If
        'Boton borrar
        Call BotonBorrar()

        'Verificar si la modalidad es consulta
        ActivarModalidadConsulta()


    End Sub
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick


        Dim nPuestoBolaCorredor As Integer = 0
        Dim cPuestoBolsaCorredor As String = ""


        If e.Item.Value = 0 Then  ' Nuevo
            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0 'Datos personales



                Case 1 'Licencia

                    ViewState("EsNuevo") = True
                    Call LicenciaEstado(True)
                    Call LimpiaLicencia()

                Case 2 'Documentos
                    lblMensajeDocumento.Text = ""
                    ViewState("EsNuevo") = True
                    Call DocumentoEstado(True)
                    Call LimpiaDocumento()
            End Select

        ElseIf e.Item.Value = 1 Then ' Guardar



            Guardado.Text = ""


            ' -----------------------------------------------------
            ' Validar Cedula, solo cuando se este creando nuevo
            ' 2016.10.13
            ' -----------------------------------------------------
            If Me.RadTabStrip1.SelectedIndex = 0 Then
                If ViewState("EsNuevo") = True Then

                    Dim cSql As String = "Select PuestoBolsaCorredorID FROM dbo.PuestoBolsaCorredor WHERE CodBVRD = '" & txtCodBVRD.Text & "'"
                    cPuestoBolsaCorredor = oper.ExecuteScalar(cSql)

                    'If cPuestoBolsaCorredor <> txtCodigoPuestoBolsaCorredorID.Text And cPuestoBolsaCorredor.TrimEnd() <> "" Then
                    If cPuestoBolsaCorredor.TrimEnd() <> "" Then

                        ValidatorCedulaCorredor.ErrorMessage = "Código BVRD ya existe Repetido"
                        ValidatorCedulaCorredor.IsValid = False
                        ValidatorCedulaCorredor.Enabled = True
                        nPuestoBolaCorredor = nPuestoBolaCorredor + 1

                        Notification1.Text = ValidatorCedulaCorredor.ToolTip
                        Notification1.Show()

                        Exit Sub
                    End If

                End If

                RadPageView2.Visible = True
                RadPageView3.Visible = True
                RadPageView4.Visible = True

                RadPageView2.Enabled = True
                RadPageView3.Enabled = True
                RadPageView4.Enabled = True


            End If




            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then 'actualizar

                Select Case Me.RadTabStrip1.SelectedIndex

                    Case 0 'Datos personales

                        Call ActualizarDatosPersonales(txtCodigoPuestoBolsa.Text)
                        Call EditarDatosPersonales()

                    Case 1 'Licencia
                        Call ActualizarLicencia()
                        Call EditarLicencia()
                        Me.RadGridCorredorLicencia.DataBind()
                    Case 2 'Documentos
                        Call ActualizarDocumento()
                        Call EditarDocumento()
                        Me.RadGridDocumento.DataBind()
                End Select

            End If

            If ViewState("EsNuevo") = True Then

                Select Case Me.RadTabStrip1.SelectedIndex
                    Case 0 'Nuevo datos personales



                        Dim cSql As String = "Select PuestoBolsaCorredorID FROM dbo.PuestoBolsaCorredor WHERE CodBVRD = '" & txtCodBVRD.Text & "'"
                        If oper.ExecuteScalar(cSql) <> "" Then

                            ValidatorCedulaCorredor.ErrorMessage = "Código BVRD ya existe Repetido"
                            ValidatorCedulaCorredor.IsValid = False
                            ValidatorCedulaCorredor.Enabled = True
                            nPuestoBolaCorredor = nPuestoBolaCorredor + 1

                            Notification1.Text = ValidatorCedulaCorredor.ToolTip
                            Notification1.Show()


                            Exit Sub

                        Else

                            Call InsertarDatosPersonales(txtCodigoPuestoBolsa.Text)
                            RadToolBar1.Items.Item(0).Enabled = False
                            RadToolBar1.Items.Item(1).Enabled = False
                            RadToolBar1.Items.Item(3).Enabled = True
                            RadToolBar1.Items.Item(4).Enabled = True
                            RadTabStrip1.Tabs(1).Enabled = True
                            RadTabStrip1.Tabs(2).Enabled = True
                            ViewState("EsNuevo") = False

                        End If





                    Case 1 'Nuevo licencia
                        If ValidarLicencia() Then
                            Call InsertarLicencia(txtCodigoPuestoBolsaCorredorID.Text)
                            Call LimpiaLicencia()
                            Call LicenciaEstado(False)
                            Me.RadGridCorredorLicencia.DataBind()
                            Call BotonBorrar()
                        End If
                    Case 2 'Nuevo documento
                        If ValidarDocumento() Then
                            Call InsertarDocumento(txtCodigoPuestoBolsaCorredorID.Text)
                            Call LimpiaDocumento()
                            Call DocumentoEstado(False)
                            Me.RadGridDocumento.DataBind()
                            Call BotonBorrar()
                        End If
                    Case 3 'Cancelar
                        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                        InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
                End Select
            End If

        ElseIf e.Item.Value = 2 Then  ' Borrar
            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0
                Case 1 'Licencia
                    Call BorrarLicencia()
                Case 2 'Documento
                    Call BorrarDocumento()
            End Select

        ElseIf e.Item.Value = 3 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If


    End Sub

#Region "Datos Personales"

    Sub LimpiaDatosPersonales()
        Me.txtNombreCorredor.Text = ""
        Me.txtDireccionCorredor.Text = ""
        Me.txtTelefonoCorredor.Text = ""
        Me.txtEmailCorredor.Text = ""

        Me.txtCedula.Text = ""
        Me.txtTelefonoCasa.Text = ""
        Me.txtTelefonoCelular.Text = ""
        Me.txtEmailPersonal.Text = ""
        Me.txtNota.Text = ""

        '2016.02.25
        Me.txtDireccion2.Text = ""

        If ViewState("EsNuevo") = False Then

            Me.txtNombreCorredor.Enabled = False
            Me.txtCedula.Enabled = False
            Me.txtCodBVRD.Enabled = False

        Else

            Me.txtNombreCorredor.Enabled = True
            Me.txtCedula.Enabled = True
            Me.txtCodBVRD.Enabled = True

        End If

    End Sub
    Sub InsertarDatosPersonales(ByVal CodigoPuestoBolsa As String)
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim cSql As String = ""

        Try
            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento

            Dim Sql As String = "INSERT INTO  [PuestoBolsaCorredor] ([PuestoBolsaID] ,[Nombre],[Direccion],[Telefono],[Email],[Activo],[Foto],[Cedula],[TelefonoCasa],[TelefonoCelular],[EmailPersonal],[Nota],[CodBVRD],[CodBLUUID],[Direccion2]) VALUES" &
                                " (@PuestoBolsaID ,@Nombre,@Direccion,@Telefono,@Email,@Activo,@Foto,@Cedula,@TelefonoCasa,@TelefonoCelular,@EmailPersonal,@Nota,@CodBVRD,@CodBLUUID,@Direccion2)"
            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            Dim CheckCorredor As String
            CheckCorredor = CheckBoxCorredor.Checked


            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = IIf(Me.cbPuestoBolsaId.Text <> "  Sin puesto de bolsa", Me.cbPuestoBolsaId.SelectedValue, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreCorredor.Text.Length > 0, Me.txtNombreCorredor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccionCorredor.Text.Length > 0, Me.txtDireccionCorredor.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoCorredor.Text.Length > 0, Me.txtTelefonoCorredor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmailCorredor.Text.Length > 0, Me.txtEmailCorredor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = CheckCorredor

            ' -------------------------------------------------------------
            ' 2016.07.26 : Validar que el logo se sube correctamente
            ' -------------------------------------------------------------
            If RutaDocumento <> Nothing And Documento <> "" Then
                Try
                    If RutaDocumento <> Nothing And Documento <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = DBNull.Value
                    End If
                Catch ex As Exception
                    cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = DBNull.Value
                End Try
            Else
                cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@Cedula", SqlDbType.VarChar)).Value = IIf(Me.txtCedula.Text.Length > 0, Me.txtCedula.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TelefonoCasa", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoCasa.Text.Length > 0, Me.txtTelefonoCasa.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TelefonoCelular", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoCelular.Text.Length > 0, Me.txtTelefonoCelular.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@EmailPersonal", SqlDbType.VarChar)).Value = IIf(Me.txtEmailPersonal.Text.Length > 0, Me.txtEmailPersonal.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNota.Text.Length > 0, Me.txtNota.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@CodBVRD", SqlDbType.VarChar)).Value = IIf(Me.txtCodBVRD.Text.Length > 0, Me.txtCodBVRD.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodBLUUID", SqlDbType.VarChar)).Value = IIf(Me.txtCodBLUUID.Text.Length > 0, Me.txtCodBLUUID.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Direccion2", SqlDbType.VarChar)).Value = IIf(Me.txtDireccion2.Text.Length > 0, Me.txtDireccion2.Text, DBNull.Value)

            cmd.ExecuteNonQuery()

            Dim vPuestoBolsaCorredorID As String

            vPuestoBolsaCorredorID = oper.ExecuteScalar("select IDENT_CURRENT('PuestoBolsaCorredor')")
            txtCodigoPuestoBolsaCorredorID.Text = vPuestoBolsaCorredorID

            ' Insertar el Histórico (Creador un trigger)
            'InsertarHistoricoCorredor( vPuestoBolsaCorredorID,  CodigoPuestoBolsa )


            cSql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Puesto Bolsa Corredor (Datos Personales)", "EditarCorredor", cSql)


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Guardado.ForeColor = Drawing.Color.Red
                Guardado.Text = "Error SQL al procesar la solicitud. La sesión ha caducado."
                Exit Sub
            End If

        Catch ex As Exception
        Finally

            ' Validar Historial
            'Dim sqlValidar As String = "select PuestoBolsaCorredorID from HistorialCorredor where PuestoBolsaCorredorID = IDENT_CURRENT('PuestoBolsaCorredor')"
            'Dim vPuestoBolsaCorredorID As String = oper.ExecuteScalar( sqlValidar)

            'If vPuestoBolsaCorredorID.Trim().Length = 0 Then
            '    ' Insertar el Histórico
            '    InsertarHistoricoCorredor(vPuestoBolsaCorredorID, CodigoPuestoBolsa)
            'End If

            Guardado.ForeColor = Color.Blue
            Guardado.Text = "Guardado con éxito"
            Cnx.Close()



        End Try

    End Sub
    Sub ActualizarDatosPersonales(ByVal CodigoPuestoBolsa As String)
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim cSql As String = ""

        Try
            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento
            Cnx.Open()
            Dim Sql As String

            If RutaDocumento <> Nothing And Documento <> "" Then
                Sql = "Update PuestoBolsaCorredor set  [Nombre]=@Nombre,[Direccion]=@Direccion,[Telefono]=@Telefono," &
                                                                "[Email]=@Email ,[Activo]=@Activo, [Foto]=@Foto," &
                                                                "[Cedula]=@Cedula,[TelefonoCasa]=@TelefonoCasa,[TelefonoCelular]=@TelefonoCelular,[EmailPersonal]=@EmailPersonal,[Nota]=@Nota," &
                                                                "[CodBVRD]=@CodBVRD,[CodBLUUID]=@CodBLUUID," &
                                                                "[Direccion2]=@Direccion2," &
                                                                "[PuestoBolsaID]=@PuestoBolsaID" &
                                                                " where  [PuestoBolsaCorredorID]=@PuestoBolsaCorredorID"
            Else
                Sql = "Update PuestoBolsaCorredor set  [Nombre]=@Nombre,[Direccion]=@Direccion,[Telefono]=@Telefono," &
                                                                 "[Email]=@Email ,[Activo]=@Activo," &
                                                                "[Cedula]=@Cedula,[TelefonoCasa]=@TelefonoCasa,[TelefonoCelular]=@TelefonoCelular,[EmailPersonal]=@EmailPersonal,[Nota]=@Nota," &
                                                                "[CodBVRD]=@CodBVRD,[CodBLUUID]=@CodBLUUID," &
                                                                "[Direccion2]=@Direccion2," &
                                                                "[PuestoBolsaID]=@PuestoBolsaID" &
                                                                " where  [PuestoBolsaCorredorID]=@PuestoBolsaCorredorID"
            End If

            Dim cmd As New SqlCommand(Sql, Cnx)

            Dim CheckCorredor As String
            CheckCorredor = CheckBoxCorredor.Checked
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorID", SqlDbType.BigInt)).Value = txtCodigoPuestoBolsaCorredorID.Text
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreCorredor.Text.Length > 0, Me.txtNombreCorredor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccionCorredor.Text.Length > 0, Me.txtDireccionCorredor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoCorredor.Text.Length > 0, Me.txtTelefonoCorredor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmailCorredor.Text.Length > 0, Me.txtEmailCorredor.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = CheckCorredor

            ' -------------------------------------------------------------
            ' 2016.07.26 : Validar que el logo se sube correctamente
            ' -------------------------------------------------------------
            If RutaDocumento <> Nothing And Documento <> "" Then
                Try
                    If RutaDocumento <> Nothing And Documento <> "" Then
                        cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                    Else
                        cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = DBNull.Value
                    End If
                Catch ex As Exception
                    cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = DBNull.Value
                End Try
            Else
                cmd.Parameters.Add(New SqlParameter("@Foto", SqlDbType.VarBinary)).Value = DBNull.Value
            End If


            cmd.Parameters.Add(New SqlParameter("@Cedula", SqlDbType.VarChar)).Value = IIf(Me.txtCedula.Text.Length > 0, Me.txtCedula.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TelefonoCasa", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoCasa.Text.Length > 0, Me.txtTelefonoCasa.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@TelefonoCelular", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoCelular.Text.Length > 0, Me.txtTelefonoCelular.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@EmailPersonal", SqlDbType.VarChar)).Value = IIf(Me.txtEmailPersonal.Text.Length > 0, Me.txtEmailPersonal.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNota.Text.Length > 0, Me.txtNota.Text, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@CodBVRD", SqlDbType.VarChar)).Value = IIf(Me.txtCodBVRD.Text.Length > 0, Me.txtCodBVRD.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodBLUUID", SqlDbType.VarChar)).Value = IIf(Me.txtCodBLUUID.Text.Length > 0, Me.txtCodBLUUID.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Direccion2", SqlDbType.VarChar)).Value = IIf(Me.txtDireccion2.Text.Length > 0, Me.txtDireccion2.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = IIf(Me.cbPuestoBolsaId.Text <> "  Sin puesto de bolsa", Me.cbPuestoBolsaId.SelectedValue, DBNull.Value)

            cmd.ExecuteNonQuery()


            cSql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Puesto Bolsa Corredor (Datos Personales)", "EditarCorredor", cSql)



            ' Actualizar Historial si el Estado Activo cambia
            ' 2016.10.13
            '
            If EstadoCorredor <> "" Or ViewState("CodigoPustoBolsa") <> Me.cbPuestoBolsaId.SelectedValue.ToString() Then



                Dim cSQLBuscarID As String = "Select PuestoBolsaID FROM dbo.PuestoBolsaCorredor WHERE PuestoBolsaCorredorID='" & txtCodigoPuestoBolsaCorredorID.Text & "'"
                txtCodigoPuestoBolsa.Text = oper.ExecuteScalar(cSQLBuscarID)

                Dim vSqlCorredor As String = "INSERT INTO  [HistorialCorredor] ([FechaMovimiento] ,[PuestoBolsaCorredorID] ,[PuestoBolsaID] ,[NuevoPuestoBolsaID] ,[Movimiento] ,[Nota],[UsuarioID] ) VALUES(@FechaMovimiento,@PuestoBolsaCorredorID,@PuestoBolsaID,@NuevoPuestoBolsaID,@Movimiento,@Nota,@UsuarioID) "
                Dim cmd1 As New SqlCommand(vSqlCorredor, Cnx)
                cmd1.Parameters.Add(New SqlParameter("@FechaMovimiento", SqlDbType.DateTime)).Value = DateAndTime.Now()
                cmd1.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorID", SqlDbType.Int)).Value = txtCodigoPuestoBolsaCorredorID.Text
                cmd1.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.Int)).Value = txtCodigoPuestoBolsa.Text
                cmd1.Parameters.Add(New SqlParameter("@NuevoPuestoBolsaID", SqlDbType.Int)).Value = txtCodigoPuestoBolsa.Text
                If ViewState("CodigoPustoBolsa") <> Me.cbPuestoBolsaId.SelectedValue.ToString() Then
                    cmd1.Parameters.Add(New SqlParameter("@Movimiento", SqlDbType.VarChar)).Value = "T"
                Else
                    cmd1.Parameters.Add(New SqlParameter("@Movimiento", SqlDbType.VarChar)).Value = "C"
                End If
                cmd1.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = "Cambio de Estado :" + EstadoCorredor
                cmd1.Parameters.Add(New SqlParameter("@UsuarioID", SqlDbType.Int)).Value = IIf(Session("IdUsuario").ToString.Length > 0, Session("IdUsuario"), DBNull.Value)
                cmd1.ExecuteNonQuery()

            End If




        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception
        Finally

            Guardado.ForeColor = Color.Blue
            Guardado.Text = "Actualizado con éxito"
            Cnx.Close()

        End Try
    End Sub
    Sub EditarDatosPersonales()
        Dim ds As DataSet = oper.ExDataSet("SELECT *  FROM  [vPuestoBolsaCorredor]  where  PuestoBolsaCorredorID ='" & txtCodigoPuestoBolsaCorredorID.Text & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombreCorredor.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Direccion")) Then Me.txtDireccionCorredor.Text = Trim(MyRow.Item("Direccion"))
            If Not IsDBNull(MyRow.Item("Telefono")) Then Me.txtTelefonoCorredor.Text = Trim(MyRow.Item("Telefono"))
            If Not IsDBNull(MyRow.Item("Email")) Then Me.txtEmailCorredor.Text = Trim(MyRow.Item("Email"))

            If Not IsDBNull(MyRow.Item("PuestoBolsaID")) Then Me.cbPuestoBolsaId.SelectedValue = Trim(MyRow.Item("PuestoBolsaID"))

            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBoxCorredor.Checked = Trim(MyRow.Item("Activo"))

            If Not IsDBNull(MyRow.Item("Cedula")) Then Me.txtCedula.Text = Trim(MyRow.Item("Cedula"))
            If Not IsDBNull(MyRow.Item("TelefonoCasa")) Then Me.txtTelefonoCasa.Text = Trim(MyRow.Item("TelefonoCasa"))
            If Not IsDBNull(MyRow.Item("TelefonoCelular")) Then Me.txtTelefonoCelular.Text = Trim(MyRow.Item("TelefonoCelular"))
            If Not IsDBNull(MyRow.Item("EmailPersonal")) Then Me.txtEmailPersonal.Text = Trim(MyRow.Item("EmailPersonal"))
            If Not IsDBNull(MyRow.Item("Nota")) Then Me.txtNota.Text = Trim(MyRow.Item("Nota"))

            If Not IsDBNull(MyRow.Item("CodBVRD")) Then Me.txtCodBVRD.Text = Trim(MyRow.Item("CodBVRD"))
            If Not IsDBNull(MyRow.Item("CodBLUUID")) Then Me.txtCodBLUUID.Text = Trim(MyRow.Item("CodBLUUID"))

            If Not IsDBNull(MyRow.Item("Direccion2")) Then Me.txtDireccion2.Text = Trim(MyRow.Item("Direccion2"))

            ViewState("CodigoPustoBolsa") = Trim(MyRow.Item("PuestoBolsaID"))

        Next
        Dim RutaN As String = ""
        Dim FileNameN As String = ""
        '0 para cargar desde una bd
        LeerImagen(0)




    End Sub

#End Region

#Region "Licencia"
    Sub LimpiaLicencia()
        Me.txtLicencia.Text = ""
        Me.txtLicenciaSIV.Text = ""
        Me.txtFechaInicioLicencia.DbSelectedDate = ""
        Me.txtFechaVenceLicencia.DbSelectedDate = ""
        Me.txtFechaInicioLicenciaSIV.DbSelectedDate = ""
        Me.txtFechaVenceLicenciaSIV.DbSelectedDate = ""
        Me.txtNotaLicencia.Text = ""





    End Sub
    Sub InsertarLicencia(ByVal CodigoPuestoBolsaCorredorID As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim cSql As String = ""

        Try
            Dim Sql As String = "INSERT INTO  [PuestoBolsaCorredorLicencia] ([PuestoBolsaCorredorID], [Licencia],[LicenciaSIV],[FechaLicencia],[FechaLicenciaVence],[FechaLicenciaSIV],[FechaLicenciaSIVVence],[Nota]) VALUES" &
                                " (@PuestoBolsaCorredorID,@licencia,@LicenciaSIV,@FechaLicencia,@FechaLicenciaVence,@FechaLicenciaSIV,@FechaLicenciaSIVVence,@Nota)"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            Dim CheckCorredor As String
            CheckCorredor = CheckBoxCorredor.Checked

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorID", SqlDbType.Int)).Value = IIf(CInt(CodigoPuestoBolsaCorredorID) > 0, CInt(CodigoPuestoBolsaCorredorID), DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Licencia", SqlDbType.VarChar)).Value = IIf(Me.txtLicencia.Text.Length > 0, Me.txtLicencia.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@LicenciaSIV", SqlDbType.VarChar)).Value = IIf(Me.txtLicenciaSIV.Text.Length > 0, Me.txtLicenciaSIV.Text, DBNull.Value)


            If txtFechaInicioLicencia.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicencia", SqlDbType.Date)).Value = IIf(Me.txtFechaInicioLicencia.DbSelectedDate.ToString.Length > 0, Me.txtFechaInicioLicencia.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicencia", SqlDbType.Date)).Value = DBNull.Value
            End If

            If txtFechaVenceLicencia.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaVence", SqlDbType.Date)).Value = IIf(Me.txtFechaVenceLicencia.DbSelectedDate.ToString.Length > 0, Me.txtFechaVenceLicencia.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaVence", SqlDbType.Date)).Value = DBNull.Value
            End If

            If txtFechaInicioLicenciaSIV.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIV", SqlDbType.Date)).Value = IIf(Me.txtFechaInicioLicenciaSIV.DbSelectedDate.ToString.Length > 0, Me.txtFechaInicioLicenciaSIV.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIV", SqlDbType.Date)).Value = DBNull.Value
            End If

            If txtFechaVenceLicenciaSIV.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIVVence", SqlDbType.Date)).Value = IIf(Me.txtFechaVenceLicenciaSIV.DbSelectedDate.ToString.Length > 0, Me.txtFechaVenceLicenciaSIV.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIVVence", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNotaLicencia.Text.Length > 0, Me.txtNotaLicencia.Text, DBNull.Value)


            cmd.ExecuteNonQuery()
            txtCodigoPuestoBolsaCorredorLicenciaID.Text = oper.ExecuteScalar("select IDENT_CURRENT('PuestoBolsaCorredorLicencia')")


            cSql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Insertar Puesto Bolsa Corredor (Datos Licencia)", "EditarCorredor", cSql)



        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                lblMensajeLicencia.Text = "Registro no puede ser insertado porque el Id ya existe en el Sistema."

                Exit Sub
            End If

        Catch ex As Exception
        Finally

            lblMensajeLicencia.ForeColor = Color.Blue
            lblMensajeLicencia.Text = "Guardado con éxito"
            Cnx.Close()

        End Try
    End Sub
    Sub ActualizarLicencia()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        Dim cSql As String = ""


        Try
            Dim Sql As String = "Update PuestoBolsaCorredorLicencia set  [PuestoBolsaCorredorID]=@PuestoBolsaCorredorID, [Licencia]=@Licencia, " &
                                                                 "[FechaLicencia]=@FechaLicencia,[LicenciaSIV]=@LicenciaSIV,[FechaLicenciaSIV]=@FechaLicenciaSIV," &
                                                                 "[FechaLicenciaVence]=@FechaLicenciaVence, [FechaLicenciaSIVVence]=@FechaLicenciaSIVVence, Nota=@Nota" &
                                                                 " where  [PuestoBolsaCorredorLicenciaID]=@PuestoBolsaCorredorLicenciaID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)



            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorLicenciaID", SqlDbType.BigInt)).Value = CInt(ViewState("PuestoBolsaCorredorLicenciaID"))
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorID", SqlDbType.BigInt)).Value = CInt(txtCodigoPuestoBolsaCorredorID.Text)
            cmd.Parameters.Add(New SqlParameter("@Licencia", SqlDbType.VarChar)).Value = IIf(Me.txtLicencia.Text.Length > 0, Me.txtLicencia.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@LicenciaSIV", SqlDbType.VarChar)).Value = IIf(Me.txtLicenciaSIV.Text.Length > 0, Me.txtLicenciaSIV.Text, DBNull.Value)

            If txtFechaInicioLicencia.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicencia", SqlDbType.Date)).Value = IIf(Me.txtFechaInicioLicencia.DbSelectedDate.ToString.Length > 0, Me.txtFechaInicioLicencia.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicencia", SqlDbType.Date)).Value = DBNull.Value
            End If

            If txtFechaVenceLicencia.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaVence", SqlDbType.Date)).Value = IIf(Me.txtFechaVenceLicencia.DbSelectedDate.ToString.Length > 0, Me.txtFechaVenceLicencia.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaVence", SqlDbType.Date)).Value = DBNull.Value
            End If

            If txtFechaInicioLicenciaSIV.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIV", SqlDbType.Date)).Value = IIf(Me.txtFechaInicioLicenciaSIV.DbSelectedDate.ToString.Length > 0, Me.txtFechaInicioLicenciaSIV.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIV", SqlDbType.Date)).Value = DBNull.Value
            End If

            If txtFechaVenceLicenciaSIV.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIVVence", SqlDbType.Date)).Value = IIf(Me.txtFechaVenceLicenciaSIV.DbSelectedDate.ToString.Length > 0, Me.txtFechaVenceLicenciaSIV.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaLicenciaSIVVence", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(Me.txtNotaLicencia.Text.Length > 0, Me.txtNotaLicencia.Text, DBNull.Value)


            cmd.ExecuteNonQuery()


            cSql = oper.CovertirComandoATexto(cmd)
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Actualizar Puesto Bolsa Corredor (Datos Licencia)", "EditarCorredor", cSql)




        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            lblMensajeLicencia.ForeColor = Color.Blue
            lblMensajeLicencia.Text = "Actualizado con éxito"
            Cnx.Close()

        End Try
    End Sub
    Sub EditarLicencia()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [PuestoBolsaCorredorLicencia]  where  PuestoBolsaCorredorLicenciaID ='" & ViewState("PuestoBolsaCorredorLicenciaID") & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Licencia")) Then Me.txtLicencia.Text = Trim(MyRow.Item("Licencia"))
            If Not IsDBNull(MyRow.Item("LicenciaSIV")) Then Me.txtLicenciaSIV.Text = Trim(MyRow.Item("LicenciaSIV"))
            If Not IsDBNull(MyRow.Item("FechaLicencia")) Then txtFechaInicioLicencia.DbSelectedDate = Trim(MyRow.Item("FechaLicencia"))
            If Not IsDBNull(MyRow.Item("FechaLicenciaVence")) Then txtFechaVenceLicencia.DbSelectedDate = Trim(MyRow.Item("FechaLicenciaVence"))
            If Not IsDBNull(MyRow.Item("FechaLicenciaSIV")) Then txtFechaInicioLicenciaSIV.DbSelectedDate = Trim(MyRow.Item("FechaLicenciaSIV"))
            If Not IsDBNull(MyRow.Item("FechaLicenciaSIVVence")) Then txtFechaVenceLicenciaSIV.DbSelectedDate = Trim(MyRow.Item("FechaLicenciaSIVVence"))
            If Not IsDBNull(MyRow.Item("Nota")) Then Me.txtNotaLicencia.Text = Trim(MyRow.Item("Nota")) Else Me.txtNotaLicencia.Text = ""


        Next


    End Sub
    Sub BorrarLicencia()
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridCorredorLicencia.SelectedItems
            ViewState("IDL") = dataItem("PuestoBolsaCorredorLicenciaID").Text
        Next

        If ViewState("IDL") <> "" Then
            Dim cSql As String = "DELETE FROM dbo.PuestoBolsaCorredorLicencia WHERE PuestoBolsaCorredorLicenciaID='" & ViewState("IDL") & "'"
            If oper.ExecuteNonQuery(cSql) Then
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                RadGridCorredorLicencia.DataBind()

                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Puesto Bolsa Corredor (Datos Licencia)", "EditarCorredor", cSql)



            Else
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Error al borrar el registro.')</" + "script>"

            End If
        Else
            InjectScriptLabelImprimir.Text = "<script>MensajePopup('Seleccione un registro para borrar.')</" + "script>"
        End If
    End Sub
    Sub LicenciaEstado(ByVal Estado As Boolean)
        If Estado Then
            txtLicencia.Enabled = True
            txtLicenciaSIV.Enabled = True
            'txtCodBLUUID.Enabled = True 
            txtFechaInicioLicencia.Enabled = True
            txtFechaVenceLicencia.Enabled = True
            txtFechaInicioLicenciaSIV.Enabled = True
            txtFechaVenceLicenciaSIV.Enabled = True
            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0 'Datos personales
                Case 1 'Licencia
                    RadToolBar1.Items.Item(0).Enabled = False
                    RadToolBar1.Items.Item(2).Enabled = True
                Case 2 'Documentos
            End Select
        Else
            txtLicencia.Enabled = False
            txtLicenciaSIV.Enabled = False
            'txtCodBLUUID.Enabled = False
            txtFechaInicioLicencia.Enabled = False
            txtFechaVenceLicencia.Enabled = False
            txtFechaInicioLicenciaSIV.Enabled = False
            txtFechaVenceLicenciaSIV.Enabled = False
            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0 'Datos personales
                Case 1 'Licencia
                    RadToolBar1.Items.Item(0).Enabled = True
                    RadToolBar1.Items.Item(2).Enabled = False
                Case 2 'Documentos
            End Select
        End If
    End Sub
    Function ValidarLicencia() As Boolean
        If txtLicencia.Text = "" And txtLicenciaSIV.Text = "" Then
            lblMensajeLicencia.ForeColor = Color.Red
            lblMensajeLicencia.Text = "Debe ingresar una licencia BVRD o SIV."
            Return False
        Else
            lblMensajeLicencia.Text = ""
            Return True
        End If


        'If Not txtLicencia.Text <> "" Then
        '    lblMensajeLicencia.ForeColor = Color.Red
        '    lblMensajeLicencia.Text = "Ingrese una licencia."
        '    Return False
        'ElseIf Not txtLicenciaSIV.Text <> "" Then
        '    lblMensajeLicencia.ForeColor = Color.Red
        '    lblMensajeLicencia.Text = "Ingrese una licenciaSIV."
        '    Return False
        'ElseIf txtFechaInicioLicencia.IsEmpty Then
        '    lblMensajeLicencia.ForeColor = Color.Red
        '    lblMensajeLicencia.Text = "Ingrese una fecha de inicio de licencia."
        '    Return False
        'ElseIf txtFechaVenceLicencia.IsEmpty Then
        '    lblMensajeLicencia.ForeColor = Color.Red
        '    lblMensajeLicencia.Text = "Ingrese una fecha de vencimiento de licencia."
        '    Return False
        'ElseIf txtFechaInicioLicenciaSIV.IsEmpty Then
        '    lblMensajeLicencia.ForeColor = Color.Red
        '    lblMensajeLicencia.Text = "Ingrese una fecha de inicio de licenciaSIV."
        '    Return False
        'ElseIf txtFechaVenceLicenciaSIV.IsEmpty Then
        '    lblMensajeLicencia.ForeColor = Color.Red
        '    lblMensajeLicencia.Text = "Ingrese una fecha de vencimiento de licenciaSIV."
        '    Return False
        'Else
        '    lblMensajeLicencia.Text = ""
        '    Return True
        'End If

    End Function
    Protected Sub RadGridCorredorLicencia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridCorredorLicencia.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridCorredorLicencia.SelectedItems(0)
        Dim ID = dataitem("PuestoBolsaCorredorLicenciaID").Text
        ViewState("PuestoBolsaCorredorLicenciaID") = ID
        ViewState("EsNuevo") = False
        Call EditarLicencia()
        Call LicenciaEstado(True)
        RadToolBar1.Items.Item(0).Enabled = True
        Call BotonBorrar()

        ActivarModalidadConsulta()

    End Sub

#End Region

#Region " Documento"
    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If SubirDocumento() = True Then

            Try
                Dim targetFolder As String = Path.GetTempPath()

                Dim dt As New DataTable()
                Dim line As String = Nothing
                Dim i As Integer = 0

                ' Activar Area de progreso..::..
                RadProgressArea2.Visible = True
                RadProgressArea2.Enabled = True


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


                'Using cn As New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
                '    cn.Open()
                '    Using copy As New SqlBulkCopy(cn)
                '        copy.ColumnMappings.Add(0, 0)
                '        copy.ColumnMappings.Add(1, 1)
                '        copy.ColumnMappings.Add(2, 2)
                '        copy.ColumnMappings.Add(3, 3)
                '        copy.ColumnMappings.Add(4, 4)
                '        copy.ColumnMappings.Add(5, 5)
                '        copy.ColumnMappings.Add(6, 6)
                '        copy.ColumnMappings.Add(7, 7)
                '        copy.ColumnMappings.Add(8, 8)
                '        copy.DestinationTableName = "Activos"
                '        copy.WriteToServer(dt)
                '    End Using
                'End Using



            Catch ex As Exception
                'Label40.Visible = True
                'Label40.Text = ex.Message

            End Try
        End If
    End Sub
    Function SubirDocumento() As Boolean

        RadUpload2.Enabled = True
        RadUpload2.Visible = True

        If RadUpload2.UploadedFiles.Count > 0 Then
            Try
                RadProgressArea2.Visible = True

                For Each validFile As UploadedFile In RadUpload2.UploadedFiles

                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = Path.GetTempPath()
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    Button2.Enabled = False
                    RadUpload2.Enabled = False
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
    Sub InsertarDocumento(ByVal CodigoPuestoBolsaCorredor As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO  [PuestoBolsaCorredorDocumento] ([PuestoBolsaCorredorID] ,[Fecha],[Nombre],[Adjunto],[TipoDocumentoID],[Descripcion]) VALUES (@PuestoBolsaCorredorID ,@Fecha,@Nombre,@Adjunto,@TipoDocumentoID,@Descripcion)"

            Cnx.Open()


            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorID", SqlDbType.BigInt)).Value = CodigoPuestoBolsaCorredor
            'cmd.Parameters.Add(New SqlParameter("@PuestoBolsaDocumentoID", SqlDbType.BigInt)).Value = ViewState("CodeDocumento")
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = Documento
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcion.Text.Length > 0, Me.txtDescripcion.Text, DBNull.Value)

            Try

                If RutaDocumento <> Nothing And Documento <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                Else
                    cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = DBNull.Value
                End If

            Catch ex As Exception
                cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = DBNull.Value
            End Try


            cmd.ExecuteNonQuery()

            If RutaDocumento <> Nothing And Documento <> "" Then
                DeleteFiles(Documento)
            End If

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                lblMensajeDocumento.ForeColor = Color.Red
                lblMensajeDocumento.Text = "Revise la información en los campos."

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            lblMensajeDocumento.ForeColor = Color.Blue
            lblMensajeDocumento.Text = "Guardado con éxito"
            Cnx.Close()

        End Try
    End Sub
    Sub ActualizarDocumento()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim n As Integer = CInt(ViewState("CodePuestoBolsaCorredorDocumentoID"))
            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento

            Dim Sql As String
            If RutaDocumento <> Nothing And Documento <> "" Then
                Sql = "Update PuestoBolsaCorredorDocumento set  [Fecha]=@Fecha,[Nombre]=@Nombre,[Adjunto]=@Adjunto,[TipoDocumentoID]=@TipoDocumentoID,Descripcion=@Descripcion  where  [PuestoBolsaCorredorDocumentoID]=@PuestoBolsaCorredorDocumentoID"
            Else
                Sql = "Update PuestoBolsaCorredorDocumento set  [Fecha]=@Fecha,[TipoDocumentoID]=@TipoDocumentoID,Descripcion=@Descripcion  where  [PuestoBolsaCorredorDocumentoID]=@PuestoBolsaCorredorDocumentoID"
            End If
            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            'cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = CodigoPuestoBolsa
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorDocumentoID", SqlDbType.BigInt)).Value = CInt(ViewState("CodePuestoBolsaCorredorDocumentoID"))
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(Documento > 0, Documento, DBNull.Value) 'Ojo no es igual que insertar
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcion.Text.Length > 0, Me.txtDescripcion.Text, DBNull.Value)

            If RutaDocumento <> Nothing And Documento <> "" Then
                cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            Else
                cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = DBNull.Value
            End If

            cmd.ExecuteNonQuery()
            If RutaDocumento <> Nothing And Documento <> "" Then
                DeleteFiles(Documento)
            End If
        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                lblMensajeDocumento.ForeColor = Color.Red
                lblMensajeDocumento.Text = "Registro no pudo ser actualizado."

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            lblMensajeDocumento.ForeColor = Color.Blue
            lblMensajeDocumento.Text = "Actualizado con éxito"
            Cnx.Close()
        End Try
    End Sub
    Sub EditarDocumento()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vPuestoBolsaCorredorDocumento]  where  PuestoBolsaCorredorDocumentoID ='" & CInt(ViewState("CodePuestoBolsaCorredorDocumentoID")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows


            '----------------------------------------------Documento -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFechaDocumento.DbSelectedDate = Trim(MyRow.Item("Fecha"))
            'If Not IsDBNull(MyRow.Item("Nnombre")) Then Me.txtNombreDocumento.Text = Trim(MyRow.Item("Nnombre"))
            'If Not IsDBNull(MyRow.Item("Adjunto")) Then Me.FileUpload1.FindControl = Trim(MyRow.Item("Adjunto"))
            If Not IsDBNull(MyRow.Item("TipoDocumentoID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("TipoDocumentoID"))
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcion.Text = Trim(MyRow.Item("Descripcion"))



        Next

        ActivarModalidadConsulta()

    End Sub
    Sub LimpiaDocumento()
        Me.txtFechaDocumento.DbSelectedDate = ""
        Me.RadComboBox1.SelectedValue = 0
        Me.RadComboBox1.Text = ""
        Me.txtDescripcion.Text = ""

    End Sub
    Sub DocumentoEstado(ByVal Estado As Boolean)
        If Estado Then
            Me.txtFechaDocumento.Enabled = True
            Me.RadComboBox1.Enabled = True
            Me.RadComboBox1.Enabled = True
            Me.txtDescripcion.Enabled = True
            Me.RadUpload2.Enabled = True
            Me.Button2.Enabled = True

            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0 'Datos personales
                Case 1 'Licencia
                Case 2 'Documentos
                    RadToolBar1.Items.Item(0).Enabled = False
                    RadToolBar1.Items.Item(2).Enabled = True

            End Select

        Else
            Me.txtFechaDocumento.Enabled = False
            Me.RadComboBox1.Enabled = False
            Me.RadComboBox1.Enabled = False
            Me.txtDescripcion.Enabled = False
            Me.RadUpload2.Enabled = False
            Me.Button2.Enabled = False
            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0 'Datos personales
                Case 1 'Licencia
                Case 2 'Documentos
                    RadToolBar1.Items.Item(0).Enabled = True
                    RadToolBar1.Items.Item(2).Enabled = False

            End Select
        End If
    End Sub
    Sub BorrarDocumento()
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridDocumento.SelectedItems
            ViewState("ID") = dataItem("PuestoBolsaCorredorDocumentoID").Text
        Next

        If ViewState("ID") <> "" Then
            If oper.ExecuteNonQuery("DELETE FROM dbo.PuestoBolsaCorredorDocumento WHERE PuestoBolsaCorredorDocumentoID='" & ViewState("ID") & "'") Then
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                RadGridDocumento.DataBind()

            Else
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Error al borrar el registro.')</" + "script>"

            End If
        Else
            InjectScriptLabelImprimir.Text = "<script>MensajePopup('Seleccione un registro para borrar.')</" + "script>"
        End If
    End Sub
    Function ValidarDocumento() As Boolean
        If Me.txtFechaDocumento.IsEmpty Then
            lblMensajeDocumento.ForeColor = Color.Red
            lblMensajeDocumento.Text = "Ingrese una fecha para el documento."
            Return False
        Else
            lblMensajeDocumento.Text = ""
            Return True
        End If

    End Function
    Protected Sub RadGridDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDocumento.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridDocumento.SelectedItems(0)
        Dim ID As Integer = dataitem("PuestoBolsaCorredorDocumentoID").Text
        ViewState("CodePuestoBolsaCorredorDocumentoID") = ID
        ViewState("EsNuevo") = False
        Call EditarDocumento()
        Call DocumentoEstado(True)
        RadToolBar1.Items.Item(0).Enabled = True
        lblMensajeDocumento.Text = ""
        Call BotonBorrar()

        ActivarModalidadConsulta()

    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridDocumento.SelectedItems
            ViewState("DocumentoID") = dataItem("PuestoBolsaCorredorDocumentoID").Text
            ViewState("DocumentoNombre") = Trim(dataItem("NombreDocumento").Text)

            DeleteFiles(ViewState("DocumentoNombre"))

            LeerDocumentoBinario(ViewState("DocumentoID"), Path.GetTempPath(), ViewState("DocumentoNombre"))

        Next
    End Sub
    Sub LeerDocumentoBinario(ByVal DocumentoID As Integer, ByVal DocumentoRuta As String, ByVal DocumentoNombre As String)
        Try

            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            Dim Sql As String = "Select Adjunto,nombre From PuestoBolsaCorredorDocumento Where PuestoBolsaCorredorDocumentoID ='" & DocumentoID & "'"

            Dim aBytDocumento() As Byte = Nothing
            Dim oFileStream As FileStream
            Using loComando As New SqlCommand(Sql, Cnx)
                Cnx.Open()
                Using drDocumentos As SqlDataReader = loComando.ExecuteReader(CommandBehavior.SingleRow)
                    If drDocumentos.Read() Then
                        aBytDocumento = CType(drDocumentos("Adjunto"), Byte())
                        DocumentoNombre = drDocumentos("nombre").ToString().Replace(" ", "")
                    End If
                End Using
            End Using

            ' -------------------------------------------------------
            ' Borrar Archivo
            ' -------------------------------------------------------
            IO.File.Delete(DocumentoRuta + DocumentoNombre)

            oFileStream = New FileStream(DocumentoRuta + DocumentoNombre, FileMode.CreateNew, FileAccess.Write)
            oFileStream.Write(aBytDocumento, 0, aBytDocumento.Length)
            oFileStream.Close()

            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("content-disposition", "attachment; filename=" + DocumentoNombre)
            Response.TransmitFile(DocumentoRuta + DocumentoNombre)



        Catch Exp As Exception
            MessageBox.Show(Exp.Message, "xxx", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

#End Region

#Region "Funciones logo"
    Sub LeerImagen(Metodo As Integer)

        If Metodo = 1 Then '1 Para cargar la imagen desde la carpeta temp

            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento
            FotoCorredor.DataValue = ConvierteBinario(RutaDocumento)
            FotoCorredor.Visible = True

        Else '0 para cargar imagen desde bd
            Try
                FotoCorredor.Visible = True
                Using Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

                    Dim SQL As String = "SELECT Foto FROM PuestoBolsaCorredor WHERE PuestoBolsaCorredorID = " & CInt(txtCodigoPuestoBolsaCorredorID.Text) & ""
                    Dim myCommand As New SqlCommand(SQL, Cnx)

                    Cnx.Open()
                    Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                    If myReader.Read() Then
                        FotoCorredor.DataValue = DirectCast(myReader("Foto"), Byte())
                    End If

                    myReader.Close()
                    Cnx.Close()
                End Using
            Catch ex As Exception
                FotoCorredor.Visible = False
                MensajeLogo.ForeColor = Color.Blue
                MensajeLogo.Text = "No tiene foto."

            End Try
        End If


    End Sub
    Function SubidaArchivo() As Boolean
        If RadUpload1.UploadedFiles.Count > 0 Then
            Try
                Guardado.Visible = True
                Guardado.ForeColor = Color.Blue
                Guardado.Text = "Cargando Imagen ..."

                For Each validFile As UploadedFile In RadUpload1.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)

                    ' Guardar imagen en una carpeta
                    Dim targetFolder As String = Path.GetTempPath()
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)

                    ViewState("FileName") = validFile.GetName()
                    BtnSubirLogo.Enabled = False
                    RadUpload1.Visible = False
                    RadProgressArea1.Visible = False

                    Guardado.Visible = False
                    Guardado.Text = ""
                    'El numero 1 es cuando se carga la imagen desde un path
                    LeerImagen(1)
                    Return True
                Next
            Catch ex As Exception
                Guardado.Visible = False
                Guardado.Text = ""
                Return False
            End Try
        Else

            Return False
        End If

        Return True

    End Function
    Protected Sub BtnSubirLogo_Click(sender As Object, e As EventArgs) Handles BtnSubirLogo.Click
        If SubidaArchivo() = True Then
            Try
                Dim targetFolder As String = Path.GetTempPath()
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
#End Region

#Region "Funciones generales"
    Private Sub DeleteFiles(cDocumento As String)
        Dim targetFolder As String = Path.GetTempPath()
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

            progress.CurrentOperationText = file.GetName() + " se está procesando..."
            If Not Response.IsClientConnected Then
                Exit While
            End If
            System.Threading.Thread.Sleep(100)
            i = i + 1
        End While
    End Sub
    Public Function ConvierteBinario(ByVal Path As String) As Byte()
        Dim sPath As String
        sPath = Path
        Dim Ruta As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim Binario(CInt(Ruta.Length)) As Byte
        Ruta.Read(Binario, 0, CInt(Ruta.Length))
        Ruta.Close()
        Return Binario
    End Function
    Sub BotonBorrar()
        Select Case Me.RadTabStrip1.SelectedIndex
            Case 0 'Datos personales
            Case 1 'Licencia
                Dim CountRows As Integer = RadGridCorredorLicencia.Items.Count
                If CountRows <= 0 Then
                    RadToolBar1.Items.Item(4).Enabled = False
                Else
                    RadToolBar1.Items.Item(4).Enabled = True
                End If
            Case 2 'Documentos
                Dim CountRows As Integer = RadGridDocumento.Items.Count
                If CountRows <= 0 Then
                    RadToolBar1.Items.Item(4).Enabled = False
                Else
                    RadToolBar1.Items.Item(4).Enabled = True
                End If
        End Select
    End Sub
    Protected Sub RadTabStrip1_TabClick(sender As Object, e As RadTabStripEventArgs) Handles RadTabStrip1.TabClick
        Select Case Me.RadTabStrip1.SelectedIndex
            Case 0 'Datos Generales
                RadToolBar1.Enabled = True
                RadToolBar1.Items.Item(0).Enabled = False
                RadToolBar1.Items.Item(2).Enabled = True
            Case 1 'Licencia
                RadToolBar1.Enabled = True
                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(2).Enabled = False
                LimpiaLicencia()
                LicenciaEstado(False)
            Case 2 'Documentos
                RadToolBar1.Enabled = True
                RadToolBar1.Items.Item(0).Enabled = True
                RadToolBar1.Items.Item(2).Enabled = False
                LimpiaDocumento()
                DocumentoEstado(False)
            Case 3
                RadToolBar1.Enabled = False

        End Select

        ActivarModalidadConsulta()

    End Sub
#End Region

#Region "Operaciones Grid de las Pantallas "

    Protected Sub RadGridCorredorLicencia_Unload(sender As Object, e As EventArgs) Handles RadGridCorredorLicencia.Unload
        Call BotonBorrar()
    End Sub
    Protected Sub RadGridDocumento_Unload(sender As Object, e As EventArgs) Handles RadGridDocumento.Unload
        Call BotonBorrar()
    End Sub
    Protected Sub RadGridCorredorLicencia_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridCorredorLicencia.ItemDataBound
        'Is it a GridDataItem
        If (TypeOf (e.Item) Is GridDataItem) Then
            'Get the instance of the right type
            Dim dataBoundItem As GridDataItem = e.Item
            'Check the formatting condition

            If dataBoundItem("FechaLicenciaSIVVence").Text <> "&nbsp;" Then
                If (dataBoundItem("FechaLicenciaSIVVence").Text <= Today) Then
                    dataBoundItem("FechaLicenciaSIVVence").ForeColor = Color.Red
                    dataBoundItem("FechaLicenciaSIVVence").Font.Bold = True
                    'Customize more...

                End If
            End If
            If dataBoundItem("FechaLicenciaVence").Text <> "&nbsp;" Then
                If (dataBoundItem("FechaLicenciaVence").Text <= Today) Then
                    dataBoundItem("FechaLicenciaVence").ForeColor = Color.Red
                    dataBoundItem("FechaLicenciaVence").Font.Bold = True
                    'Customize more...
                End If
            End If
        End If
    End Sub

#End Region

#Region "Modalidad de Consulta"

    Private Sub ActivarModalidadConsulta()


        If ViewState("Consulta") = "Consulta" Then
            RadToolBar1.Items.Item(0).Enabled = False
            RadToolBar1.Items.Item(1).Enabled = False
            RadToolBar1.Items.Item(2).Enabled = False
            RadToolBar1.Items.Item(3).Enabled = False
            RadToolBar1.Items.Item(4).Enabled = False

            RadUpload1.Visible = False
            BtnSubirLogo.Visible = False
            lblFoto.Visible = False

            RadUpload2.Visible = False
            Button2.Visible = False
            Label33.Visible = False

        End If



    End Sub

    Protected Sub CheckBoxCorredor_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCorredor.CheckedChanged

        If CheckBoxCorredor.Checked Then
            EstadoCorredor = "Inactivo a Activo"
        Else
            EstadoCorredor = "Activo a Inactivo"
        End If



    End Sub


#End Region


#Region "Historico PuestoBolsa Corredor"

    Private Sub InsertarHistoricoCorredor(ByVal vPuestoBolsaCorredorID As String, ByVal CodigoPuestoBolsa As String)

        Try
            If vPuestoBolsaCorredorID.Trim().Length > 0 Then

                Dim Cnxx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

                Cnxx.Open()

                Dim SqlHistorialCorredor As String = "INSERT INTO  [HistorialCorredor] ([FechaMovimiento] ,[PuestoBolsaCorredorID] ,[PuestoBolsaID] ,[NuevoPuestoBolsaID] ,[Movimiento] ,[Nota],[UsuarioID] ) VALUES(@FechaMovimiento,@PuestoBolsaCorredorID,@PuestoBolsaID,@NuevoPuestoBolsaID,@Movimiento,@Nota,@UsuarioID) "
                Dim cmd1 As New SqlCommand(SqlHistorialCorredor, Cnxx)
                cmd1.Parameters.Add(New SqlParameter("@FechaMovimiento", SqlDbType.DateTime)).Value = DateAndTime.Now()
                cmd1.Parameters.Add(New SqlParameter("@PuestoBolsaCorredorID", SqlDbType.Int)).Value = vPuestoBolsaCorredorID
                cmd1.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.Int)).Value = CodigoPuestoBolsa
                cmd1.Parameters.Add(New SqlParameter("@NuevoPuestoBolsaID", SqlDbType.Int)).Value = CodigoPuestoBolsa
                cmd1.Parameters.Add(New SqlParameter("@Movimiento", SqlDbType.VarChar)).Value = "C"
                cmd1.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = "Creado"
                cmd1.Parameters.Add(New SqlParameter("@UsuarioID", SqlDbType.Int)).Value = IIf(Session("IdUsuario").ToString.Length > 0, Session("IdUsuario"), DBNull.Value)
                cmd1.ExecuteNonQuery()

            End If

        Catch ex As Exception
        Finally


        End Try

    End Sub

#End Region



End Class
