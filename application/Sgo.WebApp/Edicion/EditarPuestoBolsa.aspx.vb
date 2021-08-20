Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports Telerik.Web.UI
Imports Telerik.Web.UI.Upload

Partial Class Formularios_EditarPuestoBolsa
    Inherits System.Web.UI.Page
    Private oper As New operation
    Private Documento As String
    Private RutaDocumento As String
    Private CodigoPuestoBolsa As New Integer

#Region " Inicio del Formulario "

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            ViewState("EsNuevo") = Request.QueryString("EsNuevo")


            RadProgressArea1.ProgressIndicators = RadProgressArea1.ProgressIndicators And Not ProgressIndicators.SelectedFilesCount


            ValidatorNombrePuestoBolsa.Enabled = False
            ValidatorDireccionPuestoBolsa.Enabled = False

            ValidatorNombreDirecctivo.Enabled = False

            ValidatorFechaDocumento.Enabled = False
            ValidatorTipoDocumento.Enabled = False

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
                Session("Code") = Nothing
                Session("Ajax") = Nothing
                Codigo.Text = ViewState("Code")
            Else
                ViewState("Code") = Request.QueryString("PuestoBolsaID")
                Codigo.Text = ViewState("Code")
            End If

            ' Seleccionar TAB inicial 
            RadTabStrip1.SelectedIndex = 0
            RadMultiPage1.SelectedIndex = 0


            If ViewState("EsNuevo") = True Then
                RadTabStrip1.Tabs(1).Visible = False
                RadTabStrip1.Tabs(2).Visible = False
                RadTabStrip1.Tabs(3).Visible = False
                RadTabStrip1.Tabs(4).Visible = False
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If


            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            With RadGridCorredor
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            With RadGridDocumento
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With


            If Not IsPostBack Then
                Dim RutaN As String = ""
                Dim FileNameN As String = ""
                '0 para cargar desde una bd
                LeerImagen(0)

            End If

            txtCodSistema.Focus()
            txtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

        End If
    End Sub
    Protected Overrides Sub OnInit(ByVal e As EventArgs)
        '
        ' CODEGEN: This call is required by the ASP.NET Web Form Designer.
        '

        MyBase.OnInit(e)
    End Sub 'OnInit


#End Region

#Region " Barra de Herramientas "

    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 2 Then  ' Nuevo

            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0

                Case 1
                    'Call ActualizarDirectivo()
                    Call LimpiaDirectivo()
                    Me.RadGrid1.DataBind()
                    ViewState("EsNuevo") = True
                Case 2 'Datos personales


                    'Dim MyWindow As New Telerik.Web.UI.RadWindow
                    'MyWindow.NavigateUrl = "EditarPuestoBolsaCorredor.aspx?PuestoBolsaID=" & ViewState("Code") & "&EsNuevo=" & True
                    'MyWindow.VisibleOnPageLoad = True
                    'MyWindow.AutoSize = True
                    'MyWindow.InitialBehaviors = WindowBehaviors.Maximize
                    'RadWindowManager1.Windows.Clear()
                    'RadWindowManager1.Windows.Add(MyWindow)

                Case 3
                    'Call ActualizarDocumento()
                    Call LimpiaDocumento()
                    Me.RadGridDocumento.DataBind()
                    RadUpload1.Visible = True
                    Button2.Enabled = True
                    RadProgressArea1.Visible = True
                    ViewState("EsNuevo") = True

                Case 4 ' Códigos Participantes

                    Call LimpiaCodigoParticipantes()
                    Me.RadGridCodigoParticipantes.DataBind()
                    ViewState("EsNuevo") = True

                Case 5 ' Mecanismos de Negociación

                    Call LimpiaMecanismosNegociacion()
                    RadGridMecanismosNegociacion.DataBind()
                    ViewState("EsNuevo") = True


            End Select


        ElseIf e.Item.Value = 0 Then ' Guardar
            Guardado.Text = ""

            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0
                    Dim PuestoBolsa As Integer = 0

                    If Val(txtNombre.Text.Length) <= 0 Then
                        ValidatorNombrePuestoBolsa.ErrorMessage = "Nombre."
                        ValidatorNombrePuestoBolsa.IsValid = False
                        ValidatorNombrePuestoBolsa.Enabled = True
                        PuestoBolsa = PuestoBolsa + 1
                    End If
                    If Val(txtDireccion.Text.Length) <= 0 Then
                        ValidatorDireccionPuestoBolsa.ErrorMessage = "Direccion."
                        ValidatorDireccionPuestoBolsa.IsValid = False
                        ValidatorDireccionPuestoBolsa.Enabled = True
                        PuestoBolsa = PuestoBolsa + 1
                    End If


                    If Val(cbTipoParticipante.SelectedValue) = Nothing Then
                        ValidatorTipoParticipante.ErrorMessage = "Seleccione una opción."
                        ValidatorTipoParticipante.IsValid = False
                        ValidatorTipoParticipante.Enabled = True
                        PuestoBolsa = PuestoBolsa + 1
                    End If
                    If ViewState("EsNuevo") = True Then
                        Call ValidaExisteCodigo()
                    End If

                    'If ViewState("PuestoBolsaCodigo") = Me.txtCodSistema.Text Then
                    '    Me.Guardado.Text = "Código existe en el sistema"
                    '    PuestoBolsa = PuestoBolsa + 1
                    'End If

                    If PuestoBolsa > 0 Then
                        Exit Sub
                    End If

                Case 1

                    Dim Directivo As Integer = 0
                    If Val(txtNombreDirectivo.Text.Length) <= 0 Then
                        ValidatorNombreDirecctivo.ErrorMessage = "Nombre."
                        ValidatorNombreDirecctivo.IsValid = False
                        ValidatorNombreDirecctivo.Enabled = True
                        Directivo = Directivo + 1
                    End If


                    If Directivo > 0 Then
                        Exit Sub
                    End If

                Case 2 ' Corredor

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


                Case 4  ' Códigos Participantes 

                    If Val(txtCodigoParticipante.Text.Length) <= 0 Then
                        Exit Sub
                    End If

                Case 5  ' Mecanismos de Negociacion 



            End Select

            If ViewState("EsNuevo") = True Then


                Select Case Me.RadTabStrip1.SelectedIndex
                    Case 0
                        Call Nuevo()
                        RadTabStrip1.Tabs(0).Enabled = False

                    Case 1
                        Call InsertarDirectivo(Me.Codigo.Text)
                        Call LimpiaDirectivo()
                        Me.RadGrid1.DataBind()
                    Case 2

                    Case 3
                        Call InsertarDocumento(Me.Codigo.Text)
                        Call LimpiaDocumento()
                        Me.RadGridDocumento.DataBind()

                        RadUpload1.Visible = True
                        Button2.Enabled = True
                        RadProgressArea1.Visible = True
                    Case 4

                        Call InsertarCodigoParticipantes(Me.Codigo.Text)
                        Call LimpiaCodigoParticipantes()
                        Me.RadGridCodigoParticipantes.DataBind()

                    Case 5

                        Call InsertarMecanismosNegociacion(Me.Codigo.Text)
                        Call LimpiaMecanismosNegociacion()
                        RadGridMecanismosNegociacion.DataBind()

                End Select

            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                CodigoPuestoBolsa = Request.QueryString("PuestoBolsaID")
                Select Case Me.RadTabStrip1.SelectedIndex
                    Case 0
                        Call Actualizar()
                    Case 1
                        Call ActualizarDirectivo()
                        Call LimpiaDirectivo()
                        RadGrid1.DataBind()
                    Case 2

                    Case 3
                        Call ActualizarDocumento()
                        Call LimpiaDocumento()
                        RadGridDocumento.DataBind()
                        RadUpload1.Visible = True
                        Button2.Enabled = True
                        RadProgressArea1.Visible = True
                    Case 4
                        Call ActualizarCodigoParticipantes()
                        Call LimpiaCodigoParticipantes()
                        RadGridCodigoParticipantes.DataBind()
                    Case 5
                        Call ActualizarMecanismosNegociacion()
                        Call LimpiaMecanismosNegociacion()
                        RadGridMecanismosNegociacion.DataBind()
                End Select

                ViewState("EsNuevo") = True
                RadTabStrip1.Tabs(0).Enabled = False
            End If


        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 3 Then  ' Borrar
            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0

                Case 1
                    If ViewState("CodeDirectivo") <> Nothing Then
                        BorrarCorredor(ViewState("CodeDirectivo"))
                        Me.RadGrid1.DataBind()
                        ClearDirectivosInput()

                    End If
                    Me.RadTabStrip1.SelectedIndex = -1

                Case 2


                    'RadGridCorredor.DataBind()

                Case 3

                Case 4


            End Select

        ElseIf e.Item.Value = 4 Then

            Dim ds As DataSet = oper.ExDataSet("SELECT [PuestoBolsaID],[PuestoBolsaCodigo],[PuestoBolsaCodigoOrden],[Nombre],[Direccion],[Telefono],[Email],[FechaConstitucion],[Web],[Rnc],[NoRegistroBV],[NoRegistroSIV],[RepresentanteLegal],[CapitalSuscritoPagado],[Presidente],[Descripcion] as TipoParticipante FROM  [vPuestoBolsa]  where PuestoBolsaID='" & CInt(ViewState("Code")) & "'")

            Dim response As HttpResponse = HttpContext.Current.Response

            'Clean response object
            response.Clear()
            response.Charset = ""

            'Set response header
            response.ContentType = "application/vnd.ms-excel"
            response.AddHeader("Content-Disposition", "attachment;filename=""" & "PuestoBolsa.xls" & """")

            'Create StringWriter and use to create CSV
            Using sw As New StringWriter()
                Using htw As New HtmlTextWriter(sw)
                    'Instantiate DataGrid
                    Dim dg As New System.Web.UI.WebControls.DataGrid
                    dg.DataSource = ds.Tables(0)
                    dg.DataBind()
                    dg.RenderControl(htw)
                    response.Write(sw.ToString())
                    response.[End]()
                End Using
            End Using

        ElseIf e.Item.Value = 5 Then 'Mover corredor
            Select Case Me.RadTabStrip1.SelectedIndex
                Case 0
                Case 2 'Corredor
                    ViewState("SeleccionadoCorredor") = 0
                    For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridCorredor.SelectedItems
                        ViewState("PuestoBolsaCorredorID") = dataItem("PuestoBolsaCorredorID").Text
                        ViewState("SeleccionadoCorredor") = 1
                    Next
                    If ViewState("SeleccionadoCorredor") = 1 Then
                        Dim MyWindow As New Telerik.Web.UI.RadWindow
                        MyWindow.NavigateUrl = "MoverCorredorPuestoBolsa.aspx?PuestoBolsaCorredorID=" & ViewState("PuestoBolsaCorredorID") & "&PuestoBolsaID=" & ViewState("Code")
                        MyWindow.VisibleOnPageLoad = True
                        MyWindow.AutoSize = True
                        MyWindow.InitialBehaviors = WindowBehaviors.Maximize
                        MyWindow.VisibleStatusbar = False
                        RadWindowManager1.Windows.Clear()
                        RadWindowManager1.Windows.Add(MyWindow)
                    Else
                        MensajeCorredor.ForeColor = Color.Red
                        MensajeCorredor.Text = "Seleccione un corredor para cambiar de puesto de bolsa."

                        'InjectScriptLabel.Text = "<script>MensajePopup('Seleccione una registro para editar.')</" + "script>"


                    End If
                Case 3
                Case 4
            End Select



        End If

    End Sub

#End Region

#Region " Paginación "

    Protected Sub RadTabStrip1_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStrip1.TabClick

        ValidatorNombrePuestoBolsa.Enabled = False
        ValidatorDireccionPuestoBolsa.Enabled = False

        ValidatorNombreDirecctivo.Enabled = False
        ValidatorFechaDocumento.Enabled = False
        ValidatorTipoDocumento.Enabled = False

        Select Case Me.RadTabStrip1.SelectedIndex
            Case 0
                ViewState("EsNuevo") = False
                RadToolBar1.Items.Item(2).Enabled = True
                RadToolBar1.Items.Item(8).Enabled = False
            Case 1
                ViewState("EsNuevo") = True
                RadToolBar1.Items.Item(2).Enabled = True
                RadToolBar1.Items.Item(8).Enabled = False
            Case 2
                ViewState("EsNuevo") = True
                RadToolBar1.Items.Item(2).Enabled = False
                RadToolBar1.Items.Item(8).Enabled = True
            Case 3
                ViewState("EsNuevo") = True
                RadToolBar1.Items.Item(2).Enabled = True
                RadToolBar1.Items.Item(8).Enabled = False
            Case 4
                ViewState("EsNuevo") = True
                RadToolBar1.Items.Item(2).Enabled = True
                RadToolBar1.Items.Item(8).Enabled = False
            Case 5
                ViewState("EsNuevo") = True
                RadToolBar1.Items.Item(2).Enabled = True
                RadToolBar1.Items.Item(8).Enabled = False


        End Select
    End Sub

#End Region


    ' -----------------------------------------------------------
    ' Puesto de Bolsa Datos Generales ...
    ' -----------------------------------------------------------

#Region " Puesto Bolsa "
    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            Dim Check As String
            Check = CheckBox1.Checked


            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            Try

                Documento = ViewState("FileName")
                RutaDocumento = Path.GetTempPath() + Documento


                Dim Sql As String = "INSERT INTO  [PuestoBolsa] ([PuestoBolsaCodigo],[PuestoBolsaCodigoOrden],[Nombre],[Direccion],[Telefono],[Email],[Web],[Rnc],[NoRegistroBV],[NoRegistroSIV] " &
                                                   ",[RepresentanteLegal],[Presidente],[FechaConstitucion] ,[CapitalSuscritoPagado],[Logo],[TipoParticipanteID],[ClasificacionParticipanteID],[Activo],[Nota],[CodigoSiopel]) VALUES(" &
                                                   " @PuestoBolsaCodigo,@PuestoBolsaCodigoOrden,@Nombre,@Direccion,@Telefono,@Email,@Web,@Rnc,@NoRegistroBV,@NoRegistroSIV " &
                                                   ",@RepresentanteLegal,@Presidente,@FechaConstitucion,@CapitalSuscritoPagado,@Logo,@TipoParticipanteID,@ClasificacionParticipanteID,@Activo,@Nota,@CodigoSiopel) "




                Cnx.Open()
                Dim cmd As New SqlCommand(Sql, Cnx)


                cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCodigo", SqlDbType.VarChar)).Value = IIf(txtCodSistema.Text.Length > 0, txtCodSistema.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCodigoOrden", SqlDbType.VarChar)).Value = IIf(txtPuestoBolsaCodigoOrden.Text.Length > 0, txtPuestoBolsaCodigoOrden.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(txtNombre.Text.Length > 0, txtNombre.Text, DBNull.Value)

                cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(txtDireccion.Text.Length > 0, txtDireccion.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(txtTelefono.Text.Length > 0, txtTelefono.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(txtEmail.Text.Length > 0, txtEmail.Text, DBNull.Value)

                cmd.Parameters.Add(New SqlParameter("@Web", SqlDbType.VarChar)).Value = IIf(txtWeb.Text.Length > 0, txtWeb.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Rnc", SqlDbType.VarChar)).Value = IIf(txtRNC.Text.Length > 0, txtRNC.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@NoRegistroBV", SqlDbType.VarChar)).Value = IIf(txtNoRegistroBV.Text.Length > 0, txtNoRegistroBV.Text, DBNull.Value)


                cmd.Parameters.Add(New SqlParameter("@NoRegistroSIV", SqlDbType.VarChar)).Value = IIf(txtNoRegistroSIV.Text.Length > 0, txtNoRegistroSIV.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@RepresentanteLegal", SqlDbType.VarChar)).Value = IIf(txtRepresentanteLegal.Text.Length > 0, txtRepresentanteLegal.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@Presidente", SqlDbType.VarChar)).Value = IIf(txtPresidente.Text.Length > 0, txtPresidente.Text, DBNull.Value)



                If Me.txtFechaConstitucion.DbSelectedDate <> Nothing Then
                    cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = IIf(Me.txtFechaConstitucion.DbSelectedDate.ToString.Length > 0, Me.txtFechaConstitucion.DbSelectedDate, DBNull.Value)
                Else
                    cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = DBNull.Value
                End If

                cmd.Parameters.Add(New SqlParameter("@CapitalSuscritoPagado", SqlDbType.Money)).Value = IIf(Me.txtCapitalSuscritoPagado.Text.Length > 0, Me.txtCapitalSuscritoPagado.Text, DBNull.Value)


                If RutaDocumento <> Nothing And Documento <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
                Else
                    cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = DBNull.Value
                End If
                cmd.Parameters.Add(New SqlParameter("@TipoParticipanteID", SqlDbType.Int)).Value = cbTipoParticipante.SelectedValue

                If cbClasificacionParticipante.SelectedValue <> "" Then
                    cmd.Parameters.Add(New SqlParameter("@ClasificacionParticipanteID", SqlDbType.Int)).Value = cbClasificacionParticipante.SelectedValue
                Else
                    cmd.Parameters.Add(New SqlParameter("@ClasificacionParticipanteID", SqlDbType.Int)).Value = DBNull.Value
                End If

                cmd.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = Check

                cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(txtNota.Text.Length > 0, txtNota.Text, DBNull.Value)
                cmd.Parameters.Add(New SqlParameter("@CodigoSiopel", SqlDbType.VarChar)).Value = IIf(txtCodigoSiopel.Text.Length > 0, txtCodigoSiopel.Text, DBNull.Value)

                cmd.ExecuteNonQuery()


                RadTabStrip1.Tabs(1).Visible = True
                RadTabStrip1.Tabs(2).Visible = True
                RadTabStrip1.Tabs(3).Visible = True


                ViewState("EsNuevo") = True

                Codigo.Text = oper.ExecuteScalar("select IDENT_CURRENT('PuestoBolsa')")   'CodigoPuestoBolsa 



            Catch sql_ex As SqlClient.SqlException

                If sql_ex.ErrorCode = -2146232060 Then
                    Exit Sub
                End If

            Catch ex As Exception
            Finally


                Guardado.Text = "Guardado con éxito"
                Cnx.Close()
            End Try




        End If
    End Sub
    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vPuestoBolsa]  where PuestoBolsaID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            '--------------------------------------------Puesto Bolsa -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("PuestoBolsaCodigo")) Then Me.txtCodSistema.Text = Trim(MyRow.Item("PuestoBolsaCodigo"))
            If Not IsDBNull(MyRow.Item("PuestoBolsaCodigoOrden")) Then Me.txtPuestoBolsaCodigoOrden.Text = Trim(MyRow.Item("PuestoBolsaCodigoOrden"))
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("Direccion")) Then Me.txtDireccion.Text = Trim(MyRow.Item("Direccion"))
            If Not IsDBNull(MyRow.Item("Telefono")) Then Me.txtTelefono.Text = Trim(MyRow.Item("Telefono"))
            If Not IsDBNull(MyRow.Item("Email")) Then Me.txtEmail.Text = Trim(MyRow.Item("Email"))
            If Not IsDBNull(MyRow.Item("Web")) Then Me.txtWeb.Text = Trim(MyRow.Item("Web"))
            If Not IsDBNull(MyRow.Item("Rnc")) Then Me.txtRNC.Text = Trim(MyRow.Item("Rnc"))
            If Not IsDBNull(MyRow.Item("NoRegistroBV")) Then Me.txtNoRegistroBV.Text = Trim(MyRow.Item("NoRegistroBV"))
            If Not IsDBNull(MyRow.Item("NoRegistroSIV")) Then Me.txtNoRegistroSIV.Text = Trim(MyRow.Item("NoRegistroSIV"))
            If Not IsDBNull(MyRow.Item("RepresentanteLegal")) Then Me.txtRepresentanteLegal.Text = Trim(MyRow.Item("RepresentanteLegal"))
            If Not IsDBNull(MyRow.Item("Presidente")) Then Me.txtPresidente.Text = Trim(MyRow.Item("Presidente"))
            If Not IsDBNull(MyRow.Item("FechaConstitucion")) Then Me.txtFechaConstitucion.DbSelectedDate = Trim(MyRow.Item("FechaConstitucion"))
            If Not IsDBNull(MyRow.Item("CapitalSuscritoPagado")) Then Me.txtCapitalSuscritoPagado.Text = Trim(MyRow.Item("CapitalSuscritoPagado"))
            If Not IsDBNull(MyRow.Item("TipoParticipanteID")) Then Me.cbTipoParticipante.SelectedValue = Trim(MyRow.Item("TipoParticipanteID"))
            If Not IsDBNull(MyRow.Item("ClasificacionParticipanteID")) Then Me.cbClasificacionParticipante.SelectedValue = Trim(MyRow.Item("ClasificacionParticipanteID"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))


            If Not IsDBNull(MyRow.Item("Nota")) Then Me.txtNota.Text = Trim(MyRow.Item("Nota"))
            If Not IsDBNull(MyRow.Item("CodigoSiopel")) Then Me.txtCodigoSiopel.Text = Trim(MyRow.Item("CodigoSiopel"))
        Next
    End Sub
    Sub Actualizar()

        Dim Check As String
        Dim CheckDirectivo As String

        Check = CheckBox1.Checked
        CheckDirectivo = CheckBoxDirectivo.Checked



        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento
            Dim Sql As String
            If RutaDocumento <> Nothing And Documento <> "" Then
                Sql = "Update [PuestoBolsa] set [PuestoBolsaCodigo] = @PuestoBolsaCodigo ,[PuestoBolsaCodigoOrden]=@PuestoBolsaCodigoOrden," &
                               "[Nombre]= @Nombre, [Direccion]=@Direccion,[Telefono]=@Telefono,[Email]=@Email,[Web]=@Web," &
                               "[Rnc]=@Rnc,[NoRegistroBV]=@NoRegistroBV,[NoRegistroSIV]=@NoRegistroSIV" &
                               ",[RepresentanteLegal]=@RepresentanteLegal,[Presidente]=@Presidente,[FechaConstitucion]=@FechaConstitucion," &
                               "[CapitalSuscritoPagado] =@CapitalSuscritoPagado,[TipoParticipanteID]=@TipoParticipanteID,[ClasificacionParticipanteID]=@ClasificacionParticipanteID,[Activo]=@Activo,[logo]=@logo,[Nota]=@Nota, [CodigoSiopel]=@CodigoSiopel where PuestoBolsaID=@PuestoBolsaID"
            Else
                Sql = "Update [PuestoBolsa] set [PuestoBolsaCodigo] = @PuestoBolsaCodigo ,[PuestoBolsaCodigoOrden]=@PuestoBolsaCodigoOrden," &
                               "[Nombre]= @Nombre, [Direccion]=@Direccion,[Telefono]=@Telefono,[Email]=@Email,[Web]=@Web," &
                               "[Rnc]=@Rnc,[NoRegistroBV]=@NoRegistroBV,[NoRegistroSIV]=@NoRegistroSIV" &
                               ",[RepresentanteLegal]=@RepresentanteLegal,[Presidente]=@Presidente,[FechaConstitucion]=@FechaConstitucion," &
                               "[CapitalSuscritoPagado] =@CapitalSuscritoPagado,[TipoParticipanteID]=@TipoParticipanteID,[ClasificacionParticipanteID]=@ClasificacionParticipanteID,[Activo]=@Activo,[Nota]=@Nota, [CodigoSiopel]=@CodigoSiopel where PuestoBolsaID=@PuestoBolsaID"
            End If
            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = IIf(CInt(ViewState("Code")) > 0, CInt(ViewState("Code")), DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCodigo", SqlDbType.VarChar)).Value = IIf(txtCodSistema.Text.Length > 0, txtCodSistema.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaCodigoOrden", SqlDbType.VarChar)).Value = IIf(txtPuestoBolsaCodigoOrden.Text.Length > 0, txtPuestoBolsaCodigoOrden.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(txtNombre.Text.Length > 0, txtNombre.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(txtDireccion.Text.Length > 0, txtDireccion.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(txtTelefono.Text.Length > 0, txtTelefono.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(txtEmail.Text.Length > 0, txtEmail.Text, DBNull.Value)

            cmd.Parameters.Add(New SqlParameter("@Web", SqlDbType.VarChar)).Value = IIf(txtWeb.Text.Length > 0, txtWeb.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Rnc", SqlDbType.VarChar)).Value = IIf(txtRNC.Text.Length > 0, txtRNC.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@NoRegistroBV", SqlDbType.VarChar)).Value = IIf(txtNoRegistroBV.Text.Length > 0, txtNoRegistroBV.Text, DBNull.Value)


            cmd.Parameters.Add(New SqlParameter("@NoRegistroSIV", SqlDbType.VarChar)).Value = IIf(txtNoRegistroSIV.Text.Length > 0, txtNoRegistroSIV.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@RepresentanteLegal", SqlDbType.VarChar)).Value = IIf(txtRepresentanteLegal.Text.Length > 0, txtRepresentanteLegal.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Presidente", SqlDbType.VarChar)).Value = IIf(txtPresidente.Text.Length > 0, txtPresidente.Text, DBNull.Value)



            If Me.txtFechaConstitucion.DbSelectedDate <> Nothing Then
                cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = IIf(Me.txtFechaConstitucion.DbSelectedDate.ToString.Length > 0, Me.txtFechaConstitucion.DbSelectedDate, DBNull.Value)
            Else
                cmd.Parameters.Add(New SqlParameter("@FechaConstitucion", SqlDbType.Date)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@CapitalSuscritoPagado", SqlDbType.Money)).Value = IIf(Me.txtCapitalSuscritoPagado.Text.Length > 0, Me.txtCapitalSuscritoPagado.Text, DBNull.Value)


            If RutaDocumento <> Nothing And Documento <> "" Then
                cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            Else
                cmd.Parameters.Add(New SqlParameter("@Logo", SqlDbType.VarBinary)).Value = DBNull.Value
            End If

            cmd.Parameters.Add(New SqlParameter("@TipoParticipanteID", SqlDbType.Int)).Value = cbTipoParticipante.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@ClasificacionParticipanteID", SqlDbType.Int)).Value = cbClasificacionParticipante.SelectedValue
            cmd.Parameters.Add(New SqlParameter("@Activo", SqlDbType.Bit)).Value = Check

            cmd.Parameters.Add(New SqlParameter("@Nota", SqlDbType.VarChar)).Value = IIf(txtNota.Text.Length > 0, txtNota.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@CodigoSiopel", SqlDbType.VarChar)).Value = IIf(txtCodigoSiopel.Text.Length > 0, txtCodigoSiopel.Text, DBNull.Value)


            cmd.ExecuteNonQuery()


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally


            Guardado.Text = "Guardado con éxito"
            Cnx.Close()
        End Try


    End Sub
    Sub ValidaExisteCodigo()
        On Error Resume Next
        Dim ds1 As DataSet = oper.ExDataSet("SELECT * FROM PuestoBolsa where PuestoBolsaCodigo = '" & Me.txtCodSistema.Text & "' And nombre <> '" & txtNombre.Text & "'")

        If ds1.Tables(0).Rows.Count > 0 Then

            Dim MyRow1 As DataRow

            For Each MyRow1 In ds1.Tables(0).Rows

                ViewState("PuestoBolsaCodigo") = Trim(MyRow1.Item("PuestoBolsaCodigo"))

            Next
        End If

    End Sub
#End Region


    ' -----------------------------------------------------------
    ' Información de Directivos ...
    ' -----------------------------------------------------------

#Region " Directivos "
    Sub InsertarDirectivo(ByVal CodigoPuestoBolsa As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO  [PuestoBolsaDirectivo] ([PuestoBolsaID] ,[Nombre],[Direccion],[Telefono],[Email],[Puesto],[Encargado]) VALUES (@PuestoBolsaID ,@Nombre,@Direccion,@Telefono,@Email,@Puesto,@Encargado)"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            Dim CheckDirectivo As String
            CheckDirectivo = CheckBoxDirectivo.Checked

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = CodigoPuestoBolsa
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreDirectivo.Text.Length > 0, Me.txtNombreDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccionDirectivo.Text.Length > 0, Me.txtDireccionDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoDirectivo.Text.Length > 0, Me.txtTelefonoDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmailDirectivo.Text.Length > 0, Me.txtEmailDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Puesto", SqlDbType.VarChar)).Value = IIf(Me.txtPuestoDirectivo.Text.Length > 0, Me.txtPuestoDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Encargado", SqlDbType.Bit)).Value = CheckDirectivo
            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorNombrePuestoBolsa.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
                ValidatorNombrePuestoBolsa.IsValid = False
                Exit Sub
            End If

        Catch ex As Exception

        Finally
            Cnx.Close()
        End Try
    End Sub
    Sub ActualizarDirectivo()

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "Update PuestoBolsaDirectivo set  [Nombre]=@Nombre,[Direccion]=@Direccion,[Telefono]=@Telefono,[Email]=@Email ,[Puesto]=@Puesto ,[Encargado]=@Encargado where  [PuestoBolsaDirectivoID]=@PuestoBolsaDirectivoID"


            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            Dim CheckDirectivo As String
            CheckDirectivo = CheckBoxDirectivo.Checked

            'cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = CodigoPuestoBolsa
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaDirectivoID", SqlDbType.BigInt)).Value = ViewState("CodeDirectivo")
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = IIf(Me.txtNombreDirectivo.Text.Length > 0, Me.txtNombreDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Direccion", SqlDbType.VarChar)).Value = IIf(Me.txtDireccionDirectivo.Text.Length > 0, Me.txtDireccionDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Telefono", SqlDbType.VarChar)).Value = IIf(Me.txtTelefonoDirectivo.Text.Length > 0, Me.txtTelefonoDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Email", SqlDbType.VarChar)).Value = IIf(Me.txtEmailDirectivo.Text.Length > 0, Me.txtEmailDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Puesto", SqlDbType.VarChar)).Value = IIf(Me.txtPuestoDirectivo.Text.Length > 0, Me.txtPuestoDirectivo.Text, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Encargado", SqlDbType.Bit)).Value = CheckDirectivo
            cmd.ExecuteNonQuery()


        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorNombreDirecctivo.ErrorMessage = "Registro no pudo ser actualizado."
                ValidatorNombreDirecctivo.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()

        End Try
    End Sub
    Sub EditarDirectivo()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vPuestoBolsaDirectivos]  where  PuestoBolsaDirectivoID ='" & CInt(ViewState("CodeDirectivo")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            '--------------------------------------------Directivo -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.txtNombreDirectivo.Text = Trim(MyRow.Item("Nombre")) Else Me.txtNombreDirectivo.Text = ""
            If Not IsDBNull(MyRow.Item("Direccion")) Then Me.txtDireccionDirectivo.Text = Trim(MyRow.Item("Direccion")) Else Me.txtDireccionDirectivo.Text = ""
            If Not IsDBNull(MyRow.Item("Telefono")) Then Me.txtTelefonoDirectivo.Text = Trim(MyRow.Item("Telefono")) Else Me.txtTelefonoDirectivo.Text = ""
            If Not IsDBNull(MyRow.Item("Email")) Then Me.txtEmailDirectivo.Text = Trim(MyRow.Item("Email")) Else Me.txtEmailDirectivo.Text = ""
            If Not IsDBNull(MyRow.Item("Puesto")) Then Me.txtPuestoDirectivo.Text = Trim(MyRow.Item("Puesto")) Else Me.txtPuestoDirectivo.Text = ""
            If Not IsDBNull(MyRow.Item("Encargado")) Then Me.CheckBoxDirectivo.Checked = Trim(MyRow.Item("Encargado")) Else Me.CheckBoxDirectivo.Checked = False

        Next
    End Sub
    Sub LimpiaDirectivo()
        Me.txtNombreDirectivo.Text = ""
        Me.txtDireccionDirectivo.Text = ""
        Me.txtTelefonoDirectivo.Text = ""
        Me.txtEmailDirectivo.Text = ""
        Me.txtPuestoDirectivo.Text = ""
        Me.CheckBoxDirectivo.Checked = False
    End Sub

    Protected Sub RadGrid1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrid1.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGrid1.SelectedItems(0)
        Dim ID = dataitem("PuestoBolsaDirectivoID").Text
        ViewState("CodeDirectivo") = ID
        ViewState("EsNuevo") = False
        Call EditarDirectivo()
    End Sub

    Private Sub ClearDirectivosInput()
        Me.txtNombreDirectivo.Text = ""

        Me.txtDireccionDirectivo.Text = ""
        Me.txtTelefonoDirectivo.Text = ""
        Me.txtEmailDirectivo.Text = ""
        Me.txtPuestoDirectivo.Text = ""

    End Sub

    Private Sub BorrarCorredor(PuestoBolsaDirectivoID As Integer)
        Try
            Dim cSql As String = "delete from dbo.PUESTOBOLSADIRECTIVO  where PuestoBolsaDirectivoID='" & PuestoBolsaDirectivoID.ToString & "'"

            oper.ExecuteNonQuery(cSql)

            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Borrar Corredor", "EditarPuestoBolsa", cSql)


            lblMsgInfoDirectivos.Text = "Registro borrado exitosamente."

        Catch ex As Exception

            Throw ex

        End Try

    End Sub


#End Region


    ' -----------------------------------------------------------
    ' Información de Documentos ...
    ' -----------------------------------------------------------

#Region " Documentos "
    Sub InsertarDocumento(ByVal CodigoPuestoBolsa As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO  [PuestoBolsaDocumento] ([PuestoBolsaID] ,[Fecha],[Nombre],[Adjunto],[TipoDocumentoID],[Descripcion]) VALUES (@PuestoBolsaID ,@Fecha,@Nombre,@Adjunto,@TipoDocumentoID,@Descripcion)"

            Cnx.Open()


            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = CodigoPuestoBolsa
            'cmd.Parameters.Add(New SqlParameter("@PuestoBolsaDocumentoID", SqlDbType.BigInt)).Value = ViewState("CodeDocumento")
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = Documento
            cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento)
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcion.Text.Length > 0, Me.txtDescripcion.Text, DBNull.Value)

            cmd.ExecuteNonQuery()

            DeleteFiles(Documento)

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then

                ValidatorTipoDocumento.ErrorMessage = "Registro no puede ser insertado porque el Id ya existe en el Sistema."
                ValidatorTipoDocumento.IsValid = False

                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
            'Response.Redirect("EsperaAlcaldia.aspx?Fecha=" & RadDateFecha.DbSelectedDate.ToString)
        End Try
    End Sub
    Sub ActualizarDocumento()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            'Call prc_ConvertFileToBinary()


            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento


            Dim Sql As String = "Update PuestoBolsaDocumento set  [Fecha]=@Fecha,[Nombre]=@Nombre,[Adjunto]=@Adjunto,[TipoDocumentoID]=@TipoDocumentoID,Descripcion=@Descripcion  where  [PuestoBolsaDocumentoID]=@PuestoBolsaDocumentoID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            'cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = CodigoPuestoBolsa
            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaDocumentoID", SqlDbType.BigInt)).Value = ViewState("CodeDocumento")
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.Date)).Value = IIf(Me.txtFechaDocumento.DbSelectedDate.ToString.Length > 0, Me.txtFechaDocumento.DbSelectedDate, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = Documento
            cmd.Parameters.Add(New SqlParameter("@Adjunto", SqlDbType.VarBinary)).Value = ConvierteBinario(RutaDocumento) '' ConvierteBinario("C:\XP\Factura_Nelly.pdf") 'DBNull.Value
            cmd.Parameters.Add(New SqlParameter("@TipoDocumentoID", SqlDbType.VarChar)).Value = IIf(Me.RadComboBox1.Text.Length > 0, Me.RadComboBox1.SelectedValue, DBNull.Value)
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtDescripcion.Text.Length > 0, Me.txtDescripcion.Text, DBNull.Value)
            cmd.ExecuteNonQuery()

            DeleteFiles(Documento)

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                ValidatorTipoDocumento.ErrorMessage = "Registro no pudo ser actualizado."
                ValidatorTipoDocumento.IsValid = False
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()
            'Response.Redirect("EsperaAlcaldia.aspx?Fecha=" & RadDateFecha.DbSelectedDate.ToString)
        End Try
    End Sub
    Sub EditarDocumento()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vPuestoBolsaDocumentos]  where  PuestoBolsaDocumentoID ='" & CInt(ViewState("CodeDocumento")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows


            '----------------------------------------------Documento -------------------------------------------------------------------------
            If Not IsDBNull(MyRow.Item("PuestoBolsaDocumentoID")) Then Me.txtPuestoBolsaDocumentoID.Text = Trim(MyRow.Item("PuestoBolsaDocumentoID"))
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFechaDocumento.DbSelectedDate = Trim(MyRow.Item("Fecha"))
            'If Not IsDBNull(MyRow.Item("Nnombre")) Then Me.txtNombreDocumento.Text = Trim(MyRow.Item("Nnombre"))
            'If Not IsDBNull(MyRow.Item("Adjunto")) Then Me.FileUpload1.FindControl = Trim(MyRow.Item("Adjunto"))
            If Not IsDBNull(MyRow.Item("TipoDocumentoID")) Then Me.RadComboBox1.SelectedValue = Trim(MyRow.Item("TipoDocumentoID"))
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcion.Text = Trim(MyRow.Item("Descripcion"))



        Next
    End Sub
    Sub LimpiaDocumento()
        Me.txtFechaDocumento.DbSelectedDate = ""
        Me.RadComboBox1.SelectedValue = 0
        Me.RadComboBox1.Text = ""
        Me.txtDescripcion.Text = ""

    End Sub
    Protected Sub RadGridDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDocumento.SelectedIndexChanged
        Dim dataitem As GridDataItem = RadGridDocumento.SelectedItems(0)
        Dim ID = dataitem("PuestoBolsaDocumentoID").Text
        ViewState("CodeDocumento") = ID
        ViewState("EsNuevo") = False
        RadUpload1.Visible = True
        Call EditarDocumento()
    End Sub
    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridDocumento.SelectedItems
            ViewState("DocumentoID") = dataItem("PuestoBolsaDocumentoID").Text
            ViewState("DocumentoNombre") = Trim(dataItem("NombreDocumento").Text)
            DeleteFiles(ViewState("DocumentoNombre"))
            LeerBinario(ViewState("DocumentoID"), Path.GetTempPath(), ViewState("DocumentoNombre"))
        Next
    End Sub

#End Region


    ' -----------------------------------------------------------
    ' Información de Código Participante ...
    ' -----------------------------------------------------------
#Region " Códigos Participantes "

    Sub LimpiaCodigoParticipantes()
        Me.txtCodigoParticipante.Text = ""
    End Sub

    Protected Sub RadGridCodigoParticipantes_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDocumento.SelectedIndexChanged, RadGridCodigoParticipantes.SelectedIndexChanged
        Try
            Dim dataitem As GridDataItem = RadGridCodigoParticipantes.SelectedItems(0)
            Dim ID = dataitem("CodigosParticipanteID").Text
            ViewState("CodeCodigosParticipante") = ID
            ViewState("EsNuevo") = False
            Call EditarCodigoParticipantes()
        Catch ex As Exception

        End Try

    End Sub

    Sub InsertarCodigoParticipantes(ByVal CodigoPuestoBolsa As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO  [CodigosParticipante] ([PuestoBolsaID] ,[Descripcion]) VALUES (@PuestoBolsaID ,@Descripcion)"

            Cnx.Open()


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = CodigoPuestoBolsa
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoParticipante.Text.Length > 0, Me.txtCodigoParticipante.Text, DBNull.Value)

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

    Sub ActualizarCodigoParticipantes()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try

            Dim Sql As String = "Update CodigosParticipante SET [Descripcion]=@Descripcion  where  [CodigosParticipanteID]=@CodigosParticipanteID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@CodigosParticipanteID", SqlDbType.BigInt)).Value = ViewState("CodeCodigosParticipante")
            cmd.Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = IIf(Me.txtCodigoParticipante.Text.Length > 0, Me.txtCodigoParticipante.Text, DBNull.Value)

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

    Sub EditarCodigoParticipantes()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vPuestoBolsaCodigosParticipante]  where  CodigosParticipanteID ='" & CInt(ViewState("CodeCodigosParticipante")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("CodigosParticipanteID")) Then Me.txtCodigoParticipanteID.Text = Trim(MyRow.Item("CodigosParticipanteID"))
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtCodigoParticipante.Text = Trim(MyRow.Item("Descripcion"))

        Next
    End Sub


#End Region



    ' -----------------------------------------------------------
    ' Información de Mecanismos Negociacion ...
    ' -----------------------------------------------------------
#Region " Mecanismos Negociacion "

    Sub LimpiaMecanismosNegociacion()

        cbMecanismosNegociacion.ClearSelection()
        cbMecanismosNegociacion.Text = ""
        cbClasificacionParticipanteMecanismos.ClearSelection()
        cbClasificacionParticipanteMecanismos.Text = ""

    End Sub

    Protected Sub RadGridMecanismosNegociacion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridMecanismosNegociacion.SelectedIndexChanged
        Try
            Dim dataitem As GridDataItem = RadGridMecanismosNegociacion.SelectedItems(0)
            Dim ID = dataitem("PuestoBolsaMecanismosNegociacionID").Text
            ViewState("MecanismosNegociacion") = ID
            ViewState("EsNuevo") = False
            Call EditarMecanismosNegociacion()
        Catch ex As Exception

        End Try

    End Sub

    Sub InsertarMecanismosNegociacion(ByVal CodigoPuestoBolsa As String)

        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO  [PuestoBolsaMecanismosNegociacion] ([PuestoBolsaID] ,[MecanismosNegociacionID],[ClasificacionParticipanteID]) VALUES (@PuestoBolsaID ,@MecanismosNegociacionID,@ClasificacionParticipanteID)"

            Cnx.Open()


            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaID", SqlDbType.BigInt)).Value = CodigoPuestoBolsa

            If cbMecanismosNegociacion.SelectedValue <> "" Then
                cmd.Parameters.Add(New SqlParameter("@MecanismosNegociacionID", SqlDbType.Int)).Value = cbMecanismosNegociacion.SelectedValue
            Else
                cmd.Parameters.Add(New SqlParameter("@MecanismosNegociacionID", SqlDbType.Int)).Value = DBNull.Value
            End If

            If cbClasificacionParticipante.SelectedValue <> "" Then
                cmd.Parameters.Add(New SqlParameter("@ClasificacionParticipanteID", SqlDbType.Int)).Value = cbClasificacionParticipanteMecanismos.SelectedValue
            Else
                cmd.Parameters.Add(New SqlParameter("@ClasificacionParticipanteID", SqlDbType.Int)).Value = DBNull.Value
            End If


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

    Sub ActualizarMecanismosNegociacion()
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try

            Dim Sql As String = "Update PuestoBolsaMecanismosNegociacion SET [MecanismosNegociacionID]=@MecanismosNegociacionID,ClasificacionParticipanteID=@ClasificacionParticipanteID  where  [PuestoBolsaMecanismosNegociacionID]=@PuestoBolsaMecanismosNegociacionID"

            Cnx.Open()
            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@PuestoBolsaMecanismosNegociacionID", SqlDbType.BigInt)).Value = ViewState("MecanismosNegociacion")

            If cbMecanismosNegociacion.SelectedValue <> "" Then
                cmd.Parameters.Add(New SqlParameter("@MecanismosNegociacionID", SqlDbType.Int)).Value = cbMecanismosNegociacion.SelectedValue
            Else
                cmd.Parameters.Add(New SqlParameter("@MecanismosNegociacionID", SqlDbType.Int)).Value = DBNull.Value
            End If

            If cbClasificacionParticipante.SelectedValue <> "" Then
                cmd.Parameters.Add(New SqlParameter("@ClasificacionParticipanteID", SqlDbType.Int)).Value = cbClasificacionParticipanteMecanismos.SelectedValue
            Else
                cmd.Parameters.Add(New SqlParameter("@ClasificacionParticipanteID", SqlDbType.Int)).Value = DBNull.Value
            End If


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

    Sub EditarMecanismosNegociacion()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [vPuestoBolsaMecanismosNegociacion]  where  PuestoBolsaMecanismosNegociacionID ='" & CInt(ViewState("MecanismosNegociacion")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows

            If Not IsDBNull(MyRow.Item("PuestoBolsaMecanismosNegociacionID")) Then Me.txtCodigoParticipanteID.Text = Trim(MyRow.Item("PuestoBolsaMecanismosNegociacionID"))

            If Not IsDBNull(MyRow.Item("MecanismosNegociacionID")) Then cbMecanismosNegociacion.SelectedValue = Trim(MyRow.Item("MecanismosNegociacionID"))
            If Not IsDBNull(MyRow.Item("ClasificacionParticipanteID")) Then cbClasificacionParticipanteMecanismos.SelectedValue = Trim(MyRow.Item("ClasificacionParticipanteID"))

        Next
    End Sub


#End Region


    ' -----------------------------------------------------------
    ' Funciones Generales ...
    ' -----------------------------------------------------------

#Region " Funciones Generales "
    Sub LeerImagen(Metodo As Integer)

        If Metodo = 1 Then '1 Para cargar la imagen desde la carpeta temp
            Documento = ViewState("FileName")
            RutaDocumento = Path.GetTempPath() + Documento
            ImagenPuestoBolsa.DataValue = ConvierteBinario(RutaDocumento)
            ImagenPuestoBolsa.Visible = True
        Else '0 para cargar imagen desde bd
            Try
                ImagenPuestoBolsa.Visible = True
                Using Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

                    Dim SQL As String = "SELECT Logo FROM PuestoBolsa WHERE PuestoBolsaID = " & CInt(ViewState("Code")) & ""
                    Dim myCommand As New SqlCommand(SQL, Cnx)

                    Cnx.Open()
                    Dim myReader As SqlDataReader = myCommand.ExecuteReader()

                    If myReader.Read() Then
                        ImagenPuestoBolsa.DataValue = DirectCast(myReader("Logo"), Byte())
                    End If

                    myReader.Close()
                    Cnx.Close()
                End Using
            Catch ex As Exception
                ImagenPuestoBolsa.Visible = False
                MensajeLogo.ForeColor = Color.Blue
                MensajeLogo.Text = "Este Puesto de Bolsa no tiene logo."

            End Try
        End If


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
    Sub LeerBinario(ByVal DocumentoID As Integer, ByVal DocumentoRuta As String, ByVal DocumentoNombre As String)
        Try

            Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

            Dim Sql As String = "Select Adjunto,nombre From PuestoBolsaDocumento Where PuestoBolsaDocumentoID ='" & DocumentoID & "'"



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
            oFileStream = New FileStream(DocumentoRuta + DocumentoNombre, FileMode.CreateNew, FileAccess.Write)
            oFileStream.Write(aBytDocumento, 0, aBytDocumento.Length)
            oFileStream.Close()

            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("content-disposition", "attachment; filename=" + DocumentoNombre)
            Response.TransmitFile(DocumentoRuta + DocumentoNombre)

        Catch Exp As Exception
            'MessageBox.Show(Exp.Message, "xxx", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Function SubidaArchivo() As Boolean

        If RadUpload1.UploadedFiles.Count > 0 Then
            Try

                For Each validFile As UploadedFile In RadUpload1.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = Path.GetTempPath()
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
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SubidaArchivo() = True Then

            Try
                Dim targetFolder As String = Path.GetTempPath()

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
                        '  copy.ColumnMappings.Add(9, 9)
                        'copy.ColumnMappings.Add(10, 10)
                        'copy.ColumnMappings.Add(11, 11)
                        copy.DestinationTableName = "Activos"
                        copy.WriteToServer(dt)
                    End Using
                End Using

                'Transsacciones
                'Dim UserName As String = IIf(User.Identity.IsAuthenticated, User.Identity.Name, DBNull.Value)
                'oper.ExecuteNonQuery(" INSERT INTO [TransaccionesInventario]            ([IdActivo]            ,[IdTipoTransacion]            ,[Cantidad]            ,[IdUsuario]            ,[Nota])  SELECT     IdActivo, 1 AS Tipo, 1 as Cantidad,'" & UserName & "' as Usuario,'Carga Masiva' as Nota FROM         dbo.Activos WHERE     (NOT (IdActivo IN (SELECT     IdActivo FROM          dbo.TransaccionesInventario))) ")



            Catch ex As Exception
                'Label40.Visible = True
                'Label40.Text = ex.Message

            End Try
        End If

    End Sub
    Protected Sub BtnSubirLogo_Click(sender As Object, e As EventArgs) Handles BtnSubirLogo.Click
        If SubidaArchivoLogo() = True Then

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
    Function SubidaArchivoLogo() As Boolean

        If RadUpload2.UploadedFiles.Count > 0 Then
            Try

                For Each validFile As UploadedFile In RadUpload2.UploadedFiles
                    LooongMethodWhichUpdatesTheProgressContext(validFile)
                    Dim targetFolder As String = Path.GetTempPath()
                    validFile.SaveAs(System.IO.Path.Combine(targetFolder, validFile.GetName()), True)
                    ViewState("FileName") = validFile.GetName()
                    BtnSubirLogo.Enabled = False
                    RadUpload2.Visible = False
                    RadProgressArea2.Visible = False
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
    Protected Sub RadAjaxManager1_AjaxRequest(sender As Object, e As AjaxRequestEventArgs) Handles RadAjaxManager1.AjaxRequest
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGrid1.SelectedItems
            Session("Code") = dataItem("PuestoBolsaDirectivoID").Text
            Session("Ajax") = True
        Next
        For Each dataItem As Telerik.Web.UI.GridDataItem In RadGridCorredor.SelectedItems
            Session("Code") = dataItem("PuestoBolsaCorredorID").Text
            Session("Ajax") = True
        Next
        Session("Consulta") = ""

    End Sub


#End Region





End Class
