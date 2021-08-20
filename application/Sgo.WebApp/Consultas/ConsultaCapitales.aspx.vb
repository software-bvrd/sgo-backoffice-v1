Imports System.Globalization
Imports Telerik.Web.UI

Partial Class ConsultaCapitales
    Inherits Page
    Private oper As New operation
    Private cStringWhere As String = ""
    Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        If Not IsPostBack Then
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Capitales", "Consulta de Capitales", "")
            txtIdUsuario.Text = Session("IdUsuario")
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            ' Iniciar con la fecha del día 
            Dim FechaOperacion As Date = oper.ExecuteScalar("Select Top(1) fecha_oper from [vConsultaCapitales] order by fecha_oper desc")
            cStringWhere = String.Format("[fecha_oper]='{0}'", FechaOperacion)

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            'Filtro por defecto 
            Dim editor As New RadFilterTextFieldEditor()
            RadFilter1.FieldEditors.Add(editor)
            If Not IsPostBack Then
                editor.FieldName = "Fecha operación"
                editor.DataType = GetType(Date)

                Dim expr As New RadFilterEqualToFilterExpression(Of Date)("fecha_oper")

                Dim Fecha As String = oper.FormatoFechayymmdd(FechaOperacion)
                expr.Value = Fecha
                RadFilter1.RootGroup.Expressions.Add(expr)
            End If

            txtIdConsulta.Text = 0

            RadFilter1.ApplyButtonText = "Aplicar Filtro"
            LlenarInformacionListaFiltros()
            DataRefresh()

        End If

        If Request.Params("__EVENTTARGET") = "ActualizarFiltros" Then
            LlenarInformacionListaFiltros1()
            If Session("NombreConsultaTemp") <> "" Then
                txtNombreConsultaUsuario.Text = Session("NombreConsultaTemp")
                CargarInformacionFiltro(Session("NombreConsultaTemp"))
                Session.Remove("NombreConsultaTemp")
            End If
            RadWindowManager1.Windows.Clear()
            Exit Sub

        End If
        If Session("FiltroBorrado") = 1 Then
            txtIdConsulta.Text = 0
            txtNombreConsultaUsuario.Text = ""
            Session.Remove("FiltroBorrado")
        End If
        If txtNombreConsultaUsuario.Text <> "" Then
            Page.Header.Title = "Consulta de operaciones -> " & txtNombreConsultaUsuario.Text
        End If


    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBar1.ButtonClick, RadToolBar2.ButtonClick

        If e.Item.Value <> "" Then

            If e.Item.Value = 0 Then 'Mover

                InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Consultas/ConsultaCapitales.aspx','1000','600')</" + "script>"

            ElseIf e.Item.Value = 1 Then 'Cancelar
                InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"

            ElseIf e.Item.Value = 2 Then 'Guardar
                Dim SavePersister As New GridSettingsPersister(RadGrid1)
                Dim cSettingGrid As String = ""

                cSettingGrid = SavePersister.SaveSettings()
                Session("EstruturaGrid") = SavePersister.SaveSettings()
                Session("Filtro") = RadFilter1.SaveSettings()
                Dim MyWindow As New RadWindow
                MyWindow.NavigateUrl = String.Format("NombreConsultaUsuario.aspx?ID={0}&NC=ConsultaCapitales&U={1}&NCU={2}", txtIdConsulta.Text, txtIdUsuario.Text, txtNombreConsultaUsuario.Text) '& "&F=" & RadFilter1.SaveSettings()
                MyWindow.VisibleOnPageLoad = True
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            ElseIf e.Item.Value = 4 Then 'Exportar excel

                ciNewFormat.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd"
                Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With
                RadGrid1.MasterTableView.ExportToExcel()

                ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
                Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat


            ElseIf e.Item.Value = 5 Then 'Exportar pdf
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With
                RadGrid1.MasterTableView.ExportToPdf()
            ElseIf e.Item.Value = 6 Then 'Exportar csv
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With
                RadGrid1.MasterTableView.ExportToCSV()

            End If
        Else

            If e.Item.Text <> "" Then
                txtNombreConsultaUsuario.Text = e.Item.Text
                Page.Header.Title = "Consulta de capitales -> " & e.Item.Text
                CargarInformacionFiltro(e.Item.Text)
            End If

        End If

    End Sub
    Protected Sub CargarInformacionFiltro(cNombreConsultaUsuario As String)

        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT idConsulta,Filtro, EstruturaGrid FROM  [vFiltrosConsultas]  where NombreConsultaUsuario='{0}' AND IdUsuario='{1}' AND NombreConsulta='ConsultaCapitales'", cNombreConsultaUsuario, txtIdUsuario.Text))
        Dim MyRow As DataRow
        Dim cStringFiltro As String = ""
        Dim cSettingGrid As String = ""
        Dim LoadPersister As New GridSettingsPersister(RadGrid1)

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("idConsulta")) Then txtIdConsulta.Text = Trim(MyRow.Item("idConsulta"))
            If Not IsDBNull(MyRow.Item("Filtro")) Then cStringFiltro = Trim(MyRow.Item("Filtro"))
            If Not IsDBNull(MyRow.Item("EstruturaGrid")) Then cSettingGrid = Trim(MyRow.Item("EstruturaGrid"))
        Next

        If cStringFiltro.Trim <> "" Then
            RadToolBar1.Items.Item(5).Text = cNombreConsultaUsuario

            With RadFilter1
                .LoadSettings(cStringFiltro)
                .RecreateControl()
                .FireApplyCommand()
            End With
        End If

        If cSettingGrid.Trim <> "" Then
            LoadPersister.LoadSettings(cSettingGrid)
            RadGrid1.Rebind()
        End If
    End Sub

    Protected Sub LlenarInformacionListaFiltros()
        'Carga cuando inicia la pagina

        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [vFiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaCapitales'", txtIdUsuario.Text))
        Dim MyRow As DataRow
        Dim cStringFiltro As String = ""


        Dim dropDownFiltro As RadToolBarDropDown = New RadToolBarDropDown("Ver Consultas")
        RadToolBar1.Items.Add(dropDownFiltro)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each MyRow In ds.Tables(0).Rows
                If Not IsDBNull(MyRow.Item("NombreConsultaUsuario")) Then cStringFiltro = Trim(MyRow.Item("NombreConsultaUsuario"))
                AgregarBotones(dropDownFiltro, cStringFiltro)
            Next
        End If

    End Sub
    Protected Sub LlenarInformacionListaFiltros1()

        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [FiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaCapitales' ORDER BY idConsulta ASC", txtIdUsuario.Text))
        Dim MyRow As DataRow
        Dim cStringFiltro As String = ""


        Dim dropDownFiltro As RadToolBarDropDown = RadToolBar1.Items.FindItemByText("Ver Consultas")
        dropDownFiltro.Buttons.Clear()

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("NombreConsultaUsuario")) Then cStringFiltro = Trim(MyRow.Item("NombreConsultaUsuario"))
            AgregarBotones(dropDownFiltro, cStringFiltro)
        Next

    End Sub
    Sub AgregarBotones(dropDownFiltro As RadToolBarDropDown, texto As String)
        Dim BotFiltros As RadToolBarButton = New RadToolBarButton(texto, False, "AlignGroup")
        dropDownFiltro.Buttons.Add(BotFiltros)
    End Sub

    Protected Sub RadFilter1_ApplyExpressions(sender As Object, e As RadFilterApplyExpressionsEventArgs) Handles RadFilter1.ApplyExpressions
        Try
            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            Dim provider As New RadFilterSqlQueryProvider()
            provider.ProcessGroup(e.ExpressionRoot)

            cStringWhere = provider.Result.Trim
            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
            DataRefresh()

        Catch ex As Exception

        End Try

    End Sub
    Sub DataRefresh()
        SqlvConsultaCapitales.SelectCommandType = SqlDataSourceCommandType.StoredProcedure

        If cStringWhere.IndexOf("01/01/0001") > 0 Then
            cStringWhere = cStringWhere.Replace("01/01/0001", oper.ConvertirFechaEnAmerican(Today.Date))
        End If

        cStringWhere = cStringWhere.Replace(" 12:00:00 a.m.", "")

        SqlvConsultaCapitales.SelectParameters("SqlWhere").DefaultValue = cStringWhere
        SqlvConsultaCapitales.SelectCommand = "DBO.SP_ConsultaCapitales"
    End Sub
    Protected Sub RadGrid1_GroupsChanging(sender As Object, e As GridGroupsChangingEventArgs) Handles RadGrid1.GroupsChanging
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGrid1.SortCommand
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_ColumnsReorder(sender As Object, e As GridColumnsReorderEventArgs) Handles RadGrid1.ColumnsReorder
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub


    Protected Sub RadGrid1_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGrid1.PageSizeChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub

    Protected Sub RadGrid1_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGrid1.PageIndexChanged
        With RadFilter1
            .FireApplyCommand()
        End With
    End Sub


    Protected Sub RadGrid1_ExportCellFormatting(sender As Object, e As ExportCellFormattingEventArgs) Handles RadGrid1.ExportCellFormatting

        If (e.FormattedColumn.UniqueName) = "fecha_oper" Then
            e.Cell.Style("mso-number-format") = "mm\/dd\/yy"

        End If

    End Sub
End Class
