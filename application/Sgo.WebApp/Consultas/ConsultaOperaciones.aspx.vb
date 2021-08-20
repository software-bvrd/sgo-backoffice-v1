Imports System.Globalization
Imports System.IO
Imports System.Xml

Imports Telerik.Web.UI
Imports System.Data.SqlClient

Partial Class ConsultaOperaciones
    Inherits Page
    Private oper As New operation
    Private cStringWhere As String = ""
    Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
    Dim StrFiltros As String
    Dim FechaFiltrada

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""
        InjectScriptLabelImprimir.Text = ""

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())

        If Not IsPostBack Then
            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Operaciones", "Consulta de Operaciones", "")
            txtIdUsuario.Text = Session("IdUsuario")
            With RadGrid1
                .Culture = New CultureInfo("es-DO")
                .AlternatingItemStyle.BackColor = Drawing.ColorTranslator.FromHtml("#F1F5FB")
            End With

            ciNewFormat.DateTimeFormat.ShortDatePattern = "MM/dd/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat

            ' Iniciar con la fecha del día 
            Dim FechaOperacion As Date = oper.ExecuteScalar("Select Top(1) fecha_oper from [vConsultaOperacionesCSV] order by fecha_oper desc")
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
                InjectScriptLabelImprimir.Text = "<script>ventanaSecundaria('../Consultas/ConsultaOperaciones.aspx','1000','600')</" + "script>"
            ElseIf e.Item.Value = 1 Then 'Cancelar
                InjectScriptLabel.Text = "<script>CerrarVentana()</" + "script>"
            ElseIf e.Item.Value = 2 Then 'Guardar
                Dim SavePersister As New GridSettingsPersister(RadGrid1)
                Dim cSettingGrid As String = ""

                cSettingGrid = SavePersister.SaveSettings()
                Session("EstruturaGrid") = SavePersister.SaveSettings()
                Session("Filtro") = RadFilter1.SaveSettings()
                Dim MyWindow As New RadWindow
                MyWindow.NavigateUrl = String.Format("NombreConsultaUsuario.aspx?ID={0}&NC=ConsultaOperaciones&U={1}&NCU={2}", txtIdConsulta.Text, txtIdUsuario.Text, txtNombreConsultaUsuario.Text) '& "&F=" & RadFilter1.SaveSettings()
                MyWindow.VisibleOnPageLoad = True
                MyWindow.AutoSize = True
                RadWindowManager1.Windows.Clear()
                RadWindowManager1.Windows.Add(MyWindow)
            ElseIf e.Item.Value = 4 Then 'Exportar excel

                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With

                RadGrid1.MasterTableView.ExportToExcel()

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

                ' Generar Archivo CEVALDOM para la liquidacion de Operaciones
                ' Proyecto SIOPEL Interfaces
                ' Jueves 22-May-2014 2:22 p.m
                ' Autor: Tomas Jimenez

            ElseIf e.Item.Value = 12 Then 'Exportar csv
                RadGrid1.MasterTableView.PageSize = RadGrid1.Items.Count
                With RadFilter1
                    .FireApplyCommand()
                End With
                Call GenXMLforOperationCEVALDOM()

            End If
        Else
            If e.Item.Text <> "" Then
                txtNombreConsultaUsuario.Text = e.Item.Text
                Page.Header.Title = "Consulta de operaciones -> " & e.Item.Text
                CargarInformacionFiltro(e.Item.Text)
            End If
        End If
    End Sub

    ' Method para generar XML Liquidaciones CEVALDOM
    Protected Sub GenXMLforOperationCEVALDOM()
        If (txtfecha.Value <> 0) Then
            Dim dt As DataTable = New DataTable()
            dt.Columns.Add("NUMERO_OPERACION")
            dt.Columns.Add("ID_CONSECUTIVO_OPERACION")
            dt.Columns.Add("FECHA_TRANSACCION")
            dt.Columns.Add("FECHA_LIQUIDACION")
            dt.Columns.Add("INDICADOR_OPERACION")
            dt.Columns.Add("ID_DEPOSITANTE_COMPRADOR")
            dt.Columns.Add("ID_DEPOSITANTE_VENDEDOR")
            dt.Columns.Add("CUENTA_COMPRADOR", GetType(String))
            dt.Columns.Add("CUENTA_VENDEDOR", GetType(String))
            dt.Columns.Add("ID_MONEDA_EMISION")
            dt.Columns.Add("ID_MONEDA_LIQUIDACION")
            dt.Columns.Add("CODIGO_ISIN")
            dt.Columns.Add("CANTIDAD_TITULOS")
            dt.Columns.Add("PRECIO_PRIMA")
            dt.Columns.Add("TIPO_CAMBIO")
            dt.Columns.Add("IMPORTE_BRUTO")

            Dim ds1 As DataSet = New DataSet()
            Dim tbloperaciones As DataTable
            Dim boConn As Connection.Connection.DBConnection = New Connection.Connection.DBConnection()

            Dim FechaFiltrada1 As String = FechaFiltrada.ToString().Substring(17, 22)
            FechaFiltrada1 = FechaFiltrada1.Replace(" 12:00:00 a.m.", "")
            Dim Sqltext As String = "SELECT  * FROM vConsultaOperacionesCSV where fecha_oper = '" + FechaFiltrada1.ToString() + "'"
            Dim da As SqlDataAdapter = New SqlDataAdapter(Sqltext.ToString(), boConn.getConnectionString)

            da.Fill(ds1, "operaciones")
            tbloperaciones = ds1.Tables("operaciones")
            For i = 0 To tbloperaciones.Rows.Count - 1
                Dim dr As DataRow = dt.NewRow()
                'For Each row As DataRow In dv.Table.Rows 
                dr("NUMERO_OPERACION") = tbloperaciones.Rows(i)("num_oper").ToString()
                dr("ID_CONSECUTIVO_OPERACION") = tbloperaciones.Rows(i)("Secuencia_Operacion").ToString()
                dr("FECHA_TRANSACCION") = tbloperaciones.Rows(i)("fecha_oper").ToString()
                dr("FECHA_LIQUIDACION") = tbloperaciones.Rows(i)("fecha_liquid").ToString()
                dr("INDICADOR_OPERACION") = tbloperaciones.Rows(i)("mercado").ToString()
                dr("ID_DEPOSITANTE_COMPRADOR") = tbloperaciones.Rows(i)("pues_comp").ToString()
                dr("ID_DEPOSITANTE_VENDEDOR") = tbloperaciones.Rows(i)("pues_vend").ToString()
                dr("ID_MONEDA_EMISION") = tbloperaciones.Rows(i)("mone_trans").ToString()
                dr("ID_MONEDA_LIQUIDACION") = tbloperaciones.Rows(i)("ID_MONEDA_LIQUIDACION").ToString()
                dr("CODIGO_ISIN") = tbloperaciones.Rows(i)("cod_isin").ToString()
                dr("CANTIDAD_TITULOS") = tbloperaciones.Rows(i)("cant_tit").ToString()
                dr("PRECIO_PRIMA") = tbloperaciones.Rows(i)("precio_limp").ToString()
                dr("TIPO_CAMBIO") = 1
                dr("IMPORTE_BRUTO") = tbloperaciones.Rows(i)("IMPORTE_BRUTO").ToString()
                dt.Rows.Add(dr)
            Next


            Dim ds As New DataSet
            ds.DataSetName = "file"
            ds.Tables.Add(dt)
            ds.Tables(0).TableName = "operbvrd"
            Dim FileName As String

            FileName = "FORMATO_1_CEVALDOM" & txtfecha.Value & ".xml"

            Dim strFullPath As String = Server.MapPath("~/tmp/" + FileName)
            ds.WriteXml(strFullPath)
            Dim strContents As String = Nothing
            Dim objReader As System.IO.StreamReader = Nothing

            objReader = New System.IO.StreamReader(strFullPath, Encoding.UTF8)
            strContents = objReader.ReadToEnd()
            objReader.Close()
            Dim attachment As String = "attachment; filename=" & FileName
            Response.ClearContent()
            Response.ContentType = "application/xml; charset=utf-8"
            Response.AddHeader("content-disposition", attachment)
            Response.Write(strContents)
            Response.[End]()
        End If

    End Sub

    Protected Sub CargarInformacionFiltro(cNombreConsultaUsuario As String)
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT idConsulta,Filtro, EstruturaGrid FROM  [vFiltrosConsultas]  where NombreConsultaUsuario='{0}' AND IdUsuario='{1}' AND NombreConsulta='ConsultaOperaciones'", cNombreConsultaUsuario, txtIdUsuario.Text))
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
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [vFiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaOperaciones'", txtIdUsuario.Text))
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
        Dim ds As DataSet = oper.ExDataSet(String.Format("SELECT NombreConsultaUsuario FROM  [FiltrosConsultas]  where IdUsuario='{0}' AND NombreConsulta='ConsultaOperaciones' ORDER BY idConsulta ASC", txtIdUsuario.Text))
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
            FechaFiltrada = cStringWhere

            ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
            Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
            DataRefresh()

        Catch ex As Exception
            Dim error1 As String = ex.InnerException.ToString()
        End Try
    End Sub

    Sub DataRefresh()
        SqlvOperacionesCSV.SelectCommandType = SqlDataSourceCommandType.StoredProcedure

        If cStringWhere.IndexOf("01/01/0001") > 0 Then
            cStringWhere = cStringWhere.Replace("01/01/0001", oper.ConvertirFechaEnAmerican(Today.Date))
        End If
        'Dim format() = {"dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy"}
        'Dim Fecha As Date = Date.ParseExact(provider.Result.Trim.Substring(17, 10), format, System.Globalization.DateTimeFormatInfo.InvariantInfo, Globalization.DateTimeStyles.None)
        If cStringWhere.Substring(0, 13) = "[fecha_oper]=" Then
            ' Dim Fecha1 As String = Provider.Result.Trim.Substring(17, 10)
            Dim Fecha1 As String = cStringWhere.Trim.Substring(14, 10)
            Dim FechaOperacion As String = Fecha1.Trim.Substring(6, 4) & Fecha1.Trim.Substring(0, 2) & Fecha1.Trim.Substring(3, 2)
            txtfecha.Value = FechaOperacion & DateTime.Now.ToString("HHmmss")
        End If
        cStringWhere = cStringWhere.Replace(" 12:00:00 a.m.", "")
        SqlvOperacionesCSV.SelectParameters("SqlWhere").DefaultValue = cStringWhere
        SqlvOperacionesCSV.SelectCommand = "SP_ConsultadeOperaciones"

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


        ' Formato para Valor Total

        If (e.FormattedColumn.UniqueName) = "valor_nom_tot" Then
            e.Cell.Style("mso-number-format") = "#\,##0.00"
        End If


    End Sub

End Class
