Partial Class OperacionesTransadasMercadoBursatilPrimarioSecundario
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim GraphGroup1 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim ColorPalette1 As Telerik.Reporting.Drawing.ColorPalette = New Telerik.Reporting.Drawing.ColorPalette()
        Dim GraphTitle1 As Telerik.Reporting.GraphTitle = New Telerik.Reporting.GraphTitle()
        Dim NumericalScale1 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim NumericalScaleCrossAxisPosition1 As Telerik.Reporting.NumericalScaleCrossAxisPosition = New Telerik.Reporting.NumericalScaleCrossAxisPosition()
        Dim CategoryScale1 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim ColorPalette2 As Telerik.Reporting.Drawing.ColorPalette = New Telerik.Reporting.Drawing.ColorPalette()
        Dim GraphGroup2 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim GraphGroup3 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim ColorPalette3 As Telerik.Reporting.Drawing.ColorPalette = New Telerik.Reporting.Drawing.ColorPalette()
        Dim CategoryScale2 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale2 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim NumericalScaleCrossAxisPosition2 As Telerik.Reporting.NumericalScaleCrossAxisPosition = New Telerik.Reporting.NumericalScaleCrossAxisPosition()
        Dim GraphGroup4 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperacionesTransadasMercadoBursatilPrimarioSecundario))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.GroupFooterSection1 = New Telerik.Reporting.GroupFooterSection()
        Me.Graph1 = New Telerik.Reporting.Graph()
        Me.CartesianCoordinateSystem1 = New Telerik.Reporting.CartesianCoordinateSystem()
        Me.GraphAxis1 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis2 = New Telerik.Reporting.GraphAxis()
        Me.SqlAcumuladoMesMercado = New Telerik.Reporting.SqlDataSource()
        Me.BarSeries1 = New Telerik.Reporting.BarSeries()
        Me.GroupHeaderSection1 = New Telerik.Reporting.GroupHeaderSection()
        Me.Graph2 = New Telerik.Reporting.Graph()
        Me.CartesianCoordinateSystem2 = New Telerik.Reporting.CartesianCoordinateSystem()
        Me.GraphAxis4 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis3 = New Telerik.Reporting.GraphAxis()
        Me.SqlOperacionesMercadoBursatilPrimarioSecundario = New Telerik.Reporting.SqlDataSource()
        Me.LineSeries1 = New Telerik.Reporting.LineSeries()
        Me.LineSeries2 = New Telerik.Reporting.LineSeries()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.TextBox101 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.SqlBoletin = New Telerik.Reporting.SqlDataSource()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.Table8 = New Telerik.Reporting.Table()
        Me.TextBox90 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'GroupFooterSection1
        '
        Me.GroupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(4.1354160308837891R)
        Me.GroupFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Graph1})
        Me.GroupFooterSection1.Name = "GroupFooterSection1"
        '
        'Graph1
        '
        GraphGroup1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.Nombre"))
        GraphGroup1.Name = "nombreGroup1"
        GraphGroup1.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.Nombre", Telerik.Reporting.SortDirection.Asc))
        Me.Graph1.CategoryGroups.Add(GraphGroup1)
        Me.Graph1.ColorPalette = ColorPalette1
        Me.Graph1.CoordinateSystems.Add(Me.CartesianCoordinateSystem1)
        Me.Graph1.DataSource = Me.SqlAcumuladoMesMercado
        Me.Graph1.Legend.Position = Telerik.Reporting.GraphItemPosition.TopCenter
        Me.Graph1.Legend.Style.Font.Name = "Arial Narrow"
        Me.Graph1.Legend.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.Graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929R), Telerik.Reporting.Drawing.Unit.Inch(0.0R))
        Me.Graph1.Name = "Graph1"
        Me.Graph1.NoDataStyle.Visible = True
        Me.Graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph1.PlotAreaStyle.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph1.Series.Add(Me.BarSeries1)
        Me.Graph1.SeriesGroups.Add(GraphGroup2)
        Me.Graph1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.3000006675720215R), Telerik.Reporting.Drawing.Unit.Inch(2.6997642517089844R))
        Me.Graph1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(50.0R)
        Me.Graph1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        GraphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter
        GraphTitle1.Style.Color = System.Drawing.Color.Black
        GraphTitle1.Style.Font.Name = "Arial Narrow"
        GraphTitle1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(13.0R)
        GraphTitle1.Style.LineColor = System.Drawing.Color.LightGray
        GraphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        GraphTitle1.Text = "Acumulado del Mes por Mercado"
        Me.Graph1.Titles.Add(GraphTitle1)
        '
        'CartesianCoordinateSystem1
        '
        Me.CartesianCoordinateSystem1.Name = "CartesianCoordinateSystem1"
        Me.CartesianCoordinateSystem1.XAxis = Me.GraphAxis1
        Me.CartesianCoordinateSystem1.YAxis = Me.GraphAxis2
        '
        'GraphAxis1
        '
        Me.GraphAxis1.LabelAngle = -30
        Me.GraphAxis1.LabelFormat = "{0:N2}"
        Me.GraphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MajorGridLineStyle.Visible = False
        Me.GraphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MinorGridLineStyle.Visible = False
        Me.GraphAxis1.Name = "GraphAxis1"
        NumericalScaleCrossAxisPosition1.Position = Telerik.Reporting.GraphScaleCrossAxisPosition.[Auto]
        NumericalScaleCrossAxisPosition1.Value = 0.0R
        NumericalScale1.CrossAxisPositions.Add(NumericalScaleCrossAxisPosition1)
        Me.GraphAxis1.Scale = NumericalScale1
        Me.GraphAxis1.Style.Font.Name = "Arial Narrow"
        Me.GraphAxis1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        '
        'GraphAxis2
        '
        Me.GraphAxis2.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis2.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis2.MajorGridLineStyle.Visible = False
        Me.GraphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis2.MinorGridLineStyle.Visible = False
        Me.GraphAxis2.Name = "GraphAxis2"
        Me.GraphAxis2.Scale = CategoryScale1
        Me.GraphAxis2.Style.Font.Name = "Arial Narrow"
        Me.GraphAxis2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        Me.GraphAxis2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        '
        'SqlAcumuladoMesMercado
        '
        Me.SqlAcumuladoMesMercado.ConnectionString = "CN"
        Me.SqlAcumuladoMesMercado.Name = "SqlAcumuladoMesMercado"
        Me.SqlAcumuladoMesMercado.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value")})
        Me.SqlAcumuladoMesMercado.SelectCommand = "dbo.SP_AcumuladoMesMercado"
        Me.SqlAcumuladoMesMercado.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'BarSeries1
        '
        Me.BarSeries1.CategoryGroup = GraphGroup1
        ColorPalette2.Colors.Add(System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer)))
        ColorPalette2.Colors.Add(System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer)))
        Me.BarSeries1.ColorPalette = ColorPalette2
        Me.BarSeries1.CoordinateSystem = Me.CartesianCoordinateSystem1
        Me.BarSeries1.DataPointLabel = "=(Fields.TotalMercado)"
        Me.BarSeries1.DataPointLabelFormat = "{0:N2}"
        Me.BarSeries1.DataPointLabelStyle.Font.Name = "Arial Narrow"
        Me.BarSeries1.DataPointLabelStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.BarSeries1.DataPointLabelStyle.Font.Underline = False
        Me.BarSeries1.DataPointLabelStyle.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.BarSeries1.DataPointLabelStyle.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.BarSeries1.DataPointLabelStyle.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.BarSeries1.DataPointLabelStyle.Visible = True
        Me.BarSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.BarSeries1.DataPointStyle.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.BarSeries1.DataPointStyle.Visible = True
        Me.BarSeries1.LegendItem.Value = "=Fields.Nombre"
        Me.BarSeries1.LegendItem.Format = ""
        GraphGroup2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.Nombre"))
        GraphGroup2.Name = "nombreGroup2"
        GraphGroup2.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.Nombre", Telerik.Reporting.SortDirection.Asc))
        Me.BarSeries1.SeriesGroup = GraphGroup2
        Me.BarSeries1.X = "=(Fields.TotalMercado)"
        '
        'GroupHeaderSection1
        '
        Me.GroupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(3.7000391483306885R)
        Me.GroupHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Graph2})
        Me.GroupHeaderSection1.Name = "GroupHeaderSection1"
        '
        'Graph2
        '
        GraphGroup3.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.DiaOperacion"))
        GraphGroup3.Name = "diaOperacionGroup1"
        GraphGroup3.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.DiaOperacion", Telerik.Reporting.SortDirection.Asc))
        Me.Graph2.CategoryGroups.Add(GraphGroup3)
        ColorPalette3.Colors.Add(System.Drawing.Color.FromArgb(CType(CType(79, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(189, Byte), Integer)))
        ColorPalette3.Colors.Add(System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(77, Byte), Integer)))
        Me.Graph2.ColorPalette = ColorPalette3
        Me.Graph2.CoordinateSystems.Add(Me.CartesianCoordinateSystem2)
        Me.Graph2.DataSource = Me.SqlOperacionesMercadoBursatilPrimarioSecundario
        Me.Graph2.Legend.Position = Telerik.Reporting.GraphItemPosition.TopCenter
        Me.Graph2.Legend.Style.Font.Name = "Arial Narrow"
        Me.Graph2.Legend.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.Graph2.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph2.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929R), Telerik.Reporting.Drawing.Unit.Inch(0.0R))
        Me.Graph2.Name = "Graph2"
        Me.Graph2.NoDataStyle.Visible = True
        Me.Graph2.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph2.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph2.Series.Add(Me.LineSeries1)
        Me.Graph2.Series.Add(Me.LineSeries2)
        Me.Graph2.SeriesGroups.Add(GraphGroup4)
        Me.Graph2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.3000006675720215R), Telerik.Reporting.Drawing.Unit.Inch(3.7000391483306885R))
        Me.Graph2.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph2.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        '
        'CartesianCoordinateSystem2
        '
        Me.CartesianCoordinateSystem2.Name = "CartesianCoordinateSystem2"
        Me.CartesianCoordinateSystem2.XAxis = Me.GraphAxis4
        Me.CartesianCoordinateSystem2.YAxis = Me.GraphAxis3
        '
        'GraphAxis4
        '
        Me.GraphAxis4.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis4.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis4.MajorGridLineStyle.Visible = False
        Me.GraphAxis4.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis4.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis4.MinorGridLineStyle.Visible = False
        Me.GraphAxis4.Name = "GraphAxis4"
        Me.GraphAxis4.Scale = CategoryScale2
        Me.GraphAxis4.Style.Font.Name = "Arial Narrow"
        Me.GraphAxis4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        '
        'GraphAxis3
        '
        Me.GraphAxis3.LabelFormat = "{0:N2}"
        Me.GraphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis3.MajorGridLineStyle.Visible = False
        Me.GraphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis3.MinorGridLineStyle.Visible = False
        Me.GraphAxis3.Name = "GraphAxis3"
        NumericalScaleCrossAxisPosition2.Position = Telerik.Reporting.GraphScaleCrossAxisPosition.[Auto]
        NumericalScaleCrossAxisPosition2.Value = 0.0R
        NumericalScale2.CrossAxisPositions.Add(NumericalScaleCrossAxisPosition2)
        Me.GraphAxis3.Scale = NumericalScale2
        Me.GraphAxis3.Style.Font.Name = "Arial Narrow"
        Me.GraphAxis3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        Me.GraphAxis3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896R)
        '
        'SqlOperacionesMercadoBursatilPrimarioSecundario
        '
        Me.SqlOperacionesMercadoBursatilPrimarioSecundario.ConnectionString = "CN"
        Me.SqlOperacionesMercadoBursatilPrimarioSecundario.Name = "SqlOperacionesMercadoBursatilPrimarioSecundario"
        Me.SqlOperacionesMercadoBursatilPrimarioSecundario.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value")})
        Me.SqlOperacionesMercadoBursatilPrimarioSecundario.SelectCommand = "dbo.SP_OperacionesTransadasMercadoBursatilPrimarioSecundario"
        Me.SqlOperacionesMercadoBursatilPrimarioSecundario.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'LineSeries1
        '
        Me.LineSeries1.CategoryGroup = GraphGroup3
        Me.LineSeries1.CoordinateSystem = Me.CartesianCoordinateSystem2
        Me.LineSeries1.DataPointLabel = "=(Fields.MercadoPrimario)"
        Me.LineSeries1.DataPointLabelStyle.Visible = False
        Me.LineSeries1.DataPointStyle.Visible = False
        Me.LineSeries1.LegendItem.Value = "Mercado Primario"
        Me.LineSeries1.LegendItem.Format = ""
        Me.LineSeries1.LineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(2.0R)
        Me.LineSeries1.MarkerMaxSize = Telerik.Reporting.Drawing.Unit.Pixel(50.0R)
        Me.LineSeries1.MarkerMinSize = Telerik.Reporting.Drawing.Unit.Pixel(5.0R)
        Me.LineSeries1.MarkerSize = Telerik.Reporting.Drawing.Unit.Pixel(5.0R)
        Me.LineSeries1.Name = "LineSeries1"
        GraphGroup4.Name = "seriesGroup1"
        Me.LineSeries1.SeriesGroup = GraphGroup4
        Me.LineSeries1.Size = Nothing
        Me.LineSeries1.Y = "=(Fields.MercadoPrimario)"
        '
        'LineSeries2
        '
        Me.LineSeries2.CategoryGroup = GraphGroup3
        Me.LineSeries2.CoordinateSystem = Me.CartesianCoordinateSystem2
        Me.LineSeries2.DataPointLabel = "= Fields.MercadoSecundario"
        Me.LineSeries2.DataPointLabelStyle.Visible = False
        Me.LineSeries2.DataPointStyle.Font.Name = "Arial Narrow"
        Me.LineSeries2.DataPointStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.LineSeries2.DataPointStyle.Visible = False
        Me.LineSeries2.LegendItem.Value = "Mercado Secundario"
        Me.LineSeries2.LegendItem.Format = ""
        Me.LineSeries2.LineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(2.0R)
        Me.LineSeries2.MarkerMaxSize = Telerik.Reporting.Drawing.Unit.Pixel(50.0R)
        Me.LineSeries2.MarkerMinSize = Telerik.Reporting.Drawing.Unit.Pixel(5.0R)
        Me.LineSeries2.MarkerSize = Telerik.Reporting.Drawing.Unit.Pixel(5.0R)
        Me.LineSeries2.SeriesGroup = GraphGroup4
        Me.LineSeries2.Size = Nothing
        Me.LineSeries2.Y = "= Fields.MercadoSecundario"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2000001668930054R), Telerik.Reporting.Drawing.Unit.Inch(0.64803498983383179R))
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.5000004768371582R), Telerik.Reporting.Drawing.Unit.Inch(0.54791665077209473R))
        Me.TextBox11.Style.Color = Drawing.Color.Black
        Me.TextBox11.Style.Font.Bold = True
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox11.Value = "Operaciones Transadas en el Mercado Bursátil " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Primario y Secundario"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8000006675720215R), Telerik.Reporting.Drawing.Unit.Inch(0.64803498983383179R))
        Me.PictureBox1.MimeType = "image/png"
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0999599695205688R), Telerik.Reporting.Drawing.Unit.Inch(0.547916829586029R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox1.Value = CType(resources.GetObject("PictureBox1.Value"), Object)
        '
        'TextBox101
        '
        Me.TextBox101.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.704166054725647R), Telerik.Reporting.Drawing.Unit.Inch(1.1960304975509644R))
        Me.TextBox101.Name = "TextBox101"
        Me.TextBox101.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.2791275978088379R), Telerik.Reporting.Drawing.Unit.Inch(0.19999991357326508R))
        Me.TextBox101.Style.BorderColor.Default = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox101.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox101.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.0R)
        Me.TextBox101.Style.Color = System.Drawing.Color.Black
        Me.TextBox101.Style.Font.Bold = True
        Me.TextBox101.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox101.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox101.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox101.TextWrap = False
        Me.TextBox101.Value = "{ConvertirFechas.FormatdateAsMonthName(Parameters.FechaOperacion.Value)} {CStr(CI" & _
    "nt(ConvertirFechas.FormatdateYear(Parameters.FechaOperacion.Value)))}"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.7041664123535156R), Telerik.Reporting.Drawing.Unit.Inch(1.3961092233657837R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.2791275978088379R), Telerik.Reporting.Drawing.Unit.Inch(0.19992107152938843R))
        Me.TextBox1.Style.BorderColor.Default = Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TextBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox1.Style.Color = Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.TextWrap = False
        Me.TextBox1.Value = "Valor en RD$"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.detail.Name = "detail"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.19999949634075165R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0R), Telerik.Reporting.Drawing.Unit.Inch(0.0R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.9000003337860107R), Telerik.Reporting.Drawing.Unit.Inch(0.19999949634075165R))
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'SqlBoletin
        '
        Me.SqlBoletin.ConnectionString = "CN"
        Me.SqlBoletin.Name = "SqlBoletin"
        Me.SqlBoletin.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value")})
        Me.SqlBoletin.SelectCommand = "dbo.SP_BuscarBoletinFecha"
        Me.SqlBoletin.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.5960303544998169R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox11, Me.TextBox101, Me.TextBox1, Me.PictureBox1, Me.Table8})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'Table8
        '
        Me.Table8.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R)))
        Me.Table8.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.39145845174789429R)))
        Me.Table8.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.393147349357605R)))
        Me.Table8.Body.SetCellContent(1, 0, Me.TextBox90)
        Me.Table8.Body.SetCellContent(0, 0, Me.TextBox3)
        Me.Table8.ColumnGroups.Add(TableGroup1)
        Me.Table8.DataSource = Me.SqlBoletin
        Me.Table8.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox90, Me.TextBox3})
        Me.Table8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5375332832336426R), Telerik.Reporting.Drawing.Unit.Inch(0.000039339065551757813R))
        Me.Table8.Name = "Table8"
        TableGroup3.Name = "Group2"
        TableGroup4.Name = "Group1"
        TableGroup2.ChildGroups.Add(TableGroup3)
        TableGroup2.ChildGroups.Add(TableGroup4)
        TableGroup2.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup2.Name = "DetailGroup"
        Me.Table8.RowGroups.Add(TableGroup2)
        Me.Table8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Cm(0.78460568189620972R))
        '
        'TextBox90
        '
        Me.TextBox90.Format = "{0:#.}"
        Me.TextBox90.Name = "TextBox90"
        Me.TextBox90.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Inch(0.15478239953517914R))
        Me.TextBox90.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox90.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox90.Value = "Rueda No. {Fields.Secuencial}"
        '
        'TextBox3
        '
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Cm(0.39145839214324951R))
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.StyleName = ""
        Me.TextBox3.Value = "BD {Fields.BD}"
        '
        'OperacionesTransadasMercadoBursatilPrimarioSecundario
        '
        Group1.GroupFooter = Me.GroupFooterSection1
        Group1.GroupHeader = Me.GroupHeaderSection1
        Group1.Name = "Group1"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.GroupHeaderSection1, Me.GroupFooterSection1, Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "OperacionesTransadasMercadoBursatilPrimarioSecundario"
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaOperacion"
        ReportParameter1.Text = "Fecha Operación"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "= Today()"
        ReportParameter1.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(8.0R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox101 As Telerik.Reporting.TextBox
    Friend WithEvents Group1 As Telerik.Reporting.Group
    Friend WithEvents GroupFooterSection1 As Telerik.Reporting.GroupFooterSection
    Friend WithEvents GroupHeaderSection1 As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents SqlOperacionesMercadoBursatilPrimarioSecundario As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents SqlAcumuladoMesMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlBoletin As Telerik.Reporting.SqlDataSource
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents Table8 As Telerik.Reporting.Table
    Friend WithEvents TextBox90 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents Graph1 As Telerik.Reporting.Graph
    Friend WithEvents CartesianCoordinateSystem1 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents GraphAxis1 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis2 As Telerik.Reporting.GraphAxis
    Friend WithEvents BarSeries1 As Telerik.Reporting.BarSeries
    Friend WithEvents Graph2 As Telerik.Reporting.Graph
    Friend WithEvents CartesianCoordinateSystem2 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents GraphAxis4 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis3 As Telerik.Reporting.GraphAxis
    Friend WithEvents LineSeries1 As Telerik.Reporting.LineSeries
    Friend WithEvents LineSeries2 As Telerik.Reporting.LineSeries
End Class