Partial Class OperacionesRentaFijaEmisorInstrumentoMercadoSecundario
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim GraphGroup1 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim CategoryScale1 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale1 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim GraphGroup2 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup5 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup6 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup7 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperacionesRentaFijaEmisorInstrumentoMercadoSecundario))
        Dim TableGroup8 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup9 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup10 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup11 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.GroupFooterSection1 = New Telerik.Reporting.GroupFooterSection()
        Me.Graph1 = New Telerik.Reporting.Graph()
        Me.CartesianCoordinateSystem1 = New Telerik.Reporting.CartesianCoordinateSystem()
        Me.GraphAxis2 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis1 = New Telerik.Reporting.GraphAxis()
        Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia = New Telerik.Reporting.SqlDataSource()
        Me.BarSeries1 = New Telerik.Reporting.BarSeries()
        Me.GroupHeaderSection1 = New Telerik.Reporting.GroupHeaderSection()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.TextBox58 = New Telerik.Reporting.TextBox()
        Me.titleTextBox = New Telerik.Reporting.TextBox()
        Me.Table8 = New Telerik.Reporting.Table()
        Me.TextBox90 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.SqlBoletin = New Telerik.Reporting.SqlDataSource()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox1
        '
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0108957290649414R), Telerik.Reporting.Drawing.Unit.Inch(0.38750001788139343R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Arial Narrow"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.StyleName = "Normal.TableHeader"
        Me.TextBox1.Value = "Instrumento"
        '
        'TextBox10
        '
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4781498908996582R), Telerik.Reporting.Drawing.Unit.Inch(0.18749998509883881R))
        Me.TextBox10.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox10.Style.Font.Bold = True
        Me.TextBox10.Style.Font.Name = "Arial Narrow"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.StyleName = ""
        Me.TextBox10.Value = "Total en DOP"
        '
        'TextBox11
        '
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79577130079269409R), Telerik.Reporting.Drawing.Unit.Inch(0.1875R))
        Me.TextBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox11.Style.Font.Bold = True
        Me.TextBox11.Style.Font.Name = "Arial Narrow"
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox11.StyleName = ""
        Me.TextBox11.Value = "% DOP"
        '
        'TextBox12
        '
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2088581323623657R), Telerik.Reporting.Drawing.Unit.Inch(0.18749998509883881R))
        Me.TextBox12.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox12.Style.Font.Bold = True
        Me.TextBox12.Style.Font.Name = "Arial Narrow"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.StyleName = ""
        Me.TextBox12.Value = "USD"
        '
        'TextBox2
        '
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.482778787612915R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Arial Narrow"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Normal.TableHeader"
        Me.TextBox2.Value = "Montos Transados"
        '
        'GroupFooterSection1
        '
        Me.GroupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(3.5895838737487793R)
        Me.GroupFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Graph1})
        Me.GroupFooterSection1.Name = "GroupFooterSection1"
        '
        'Graph1
        '
        GraphGroup1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.descrip_instru"))
        GraphGroup1.Name = "descrip_instruGroup1"
        GraphGroup1.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.ValorTransadoEquivalentePesos", Telerik.Reporting.SortDirection.Desc))
        Me.Graph1.CategoryGroups.Add(GraphGroup1)
        Me.Graph1.CoordinateSystems.Add(Me.CartesianCoordinateSystem1)
        Me.Graph1.DataSource = Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia
        Me.Graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph1.Legend.Style.Visible = False
        Me.Graph1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263R), Telerik.Reporting.Drawing.Unit.Inch(0.089583501219749451R))
        Me.Graph1.Name = "Graph1"
        Me.Graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph1.Series.Add(Me.BarSeries1)
        Me.Graph1.SeriesGroups.Add(GraphGroup2)
        Me.Graph1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1999998092651367R), Telerik.Reporting.Drawing.Unit.Inch(3.5R))
        Me.Graph1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        '
        'CartesianCoordinateSystem1
        '
        Me.CartesianCoordinateSystem1.Name = "CartesianCoordinateSystem1"
        Me.CartesianCoordinateSystem1.XAxis = Me.GraphAxis2
        Me.CartesianCoordinateSystem1.YAxis = Me.GraphAxis1
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
        CategoryScale1.SpacingSlotCount = 1.0R
        Me.GraphAxis2.Scale = CategoryScale1
        Me.GraphAxis2.Style.Font.Name = "Arial Narrow"
        Me.GraphAxis2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(4.0R)
        '
        'GraphAxis1
        '
        Me.GraphAxis1.LabelFormat = "{0:N2}"
        Me.GraphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MajorGridLineStyle.Visible = False
        Me.GraphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MinorGridLineStyle.Visible = False
        Me.GraphAxis1.Name = "GraphAxis1"
        'NumericalScale1.CrossAxisValue = 0.0R
        NumericalScale1.SpacingSlotCount = 1.0R
        Me.GraphAxis1.Scale = NumericalScale1
        Me.GraphAxis1.Style.Font.Name = "Arial Narrow"
        Me.GraphAxis1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        '
        'SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia
        '
        Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia.ConnectionString = "CN"
        Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia.Name = "SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia"
        Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Mercado", System.Data.DbType.AnsiString, "15")})
        Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia.SelectCommand = "dbo.SP_OperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia"
        Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'BarSeries1
        '
        Me.BarSeries1.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Overlapped
        Me.BarSeries1.CategoryGroup = GraphGroup1
        Me.BarSeries1.CoordinateSystem = Me.CartesianCoordinateSystem1
        Me.BarSeries1.DataPointLabel = "=(Fields.ValorTransadoEquivalentePesos)"
        Me.BarSeries1.DataPointLabelFormat = "{0:N2}"
        Me.BarSeries1.DataPointLabelStyle.Font.Name = "Arial Narrow"
        Me.BarSeries1.DataPointLabelStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.BarSeries1.DataPointLabelStyle.Visible = True
        Me.BarSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.BarSeries1.DataPointStyle.Visible = True
        Me.BarSeries1.LegendItem.Value = "=Fields.descrip_instru"
        Me.BarSeries1.LegendItem.Format = ""
        GraphGroup2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.descrip_instru"))
        GraphGroup2.Name = "descrip_instruGroup2"
        GraphGroup2.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.ValorTransadoEquivalentePesos", Telerik.Reporting.SortDirection.Desc))
        Me.BarSeries1.SeriesGroup = GraphGroup2
        Me.BarSeries1.Y = "=(Fields.ValorTransadoEquivalentePesos)"
        '
        'GroupHeaderSection1
        '
        Me.GroupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.80624991655349731R)
        Me.GroupHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table1})
        Me.GroupHeaderSection1.Name = "GroupHeaderSection1"
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.0108952522277832R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4781500101089478R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.79577076435089111R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.2088582515716553R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.21874998509883881R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox5)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox6)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox7)
        Me.Table1.Body.SetCellContent(0, 3, Me.TextBox8)
        Me.Table1.Body.SetCellContent(1, 0, Me.TextBox3)
        Me.Table1.Body.SetCellContent(1, 1, Me.TextBox4)
        Me.Table1.Body.SetCellContent(1, 2, Me.TextBox9)
        Me.Table1.Body.SetCellContent(1, 3, Me.TextBox13)
        TableGroup1.ReportItem = Me.TextBox1
        TableGroup3.Name = "Group2"
        TableGroup3.ReportItem = Me.TextBox10
        TableGroup4.Name = "Group3"
        TableGroup4.ReportItem = Me.TextBox11
        TableGroup5.Name = "Group4"
        TableGroup5.ReportItem = Me.TextBox12
        TableGroup2.ChildGroups.Add(TableGroup3)
        TableGroup2.ChildGroups.Add(TableGroup4)
        TableGroup2.ChildGroups.Add(TableGroup5)
        TableGroup2.ReportItem = Me.TextBox2
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup2)
        Me.Table1.DataSource = Me.SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox3, Me.TextBox4, Me.TextBox9, Me.TextBox13, Me.TextBox1, Me.TextBox2, Me.TextBox10, Me.TextBox11, Me.TextBox12})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0R), Telerik.Reporting.Drawing.Unit.Inch(0.0R))
        Me.Table1.Name = "Table1"
        TableGroup6.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup6.Name = "Detail"
        TableGroup7.Name = "Group1"
        Me.Table1.RowGroups.Add(TableGroup6)
        Me.Table1.RowGroups.Add(TableGroup7)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.4936738014221191R), Telerik.Reporting.Drawing.Unit.Inch(0.80624997615814209R))
        Me.Table1.StyleName = "Normal.TableNormal"
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0108957290649414R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox5.Style.Font.Name = "Arial Narrow"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = "Normal.TableBody"
        Me.TextBox5.Value = "{Fields.descrip_instru}. {Fields.descrip_emisor}"
        '
        'TextBox6
        '
        Me.TextBox6.Format = "{0:N2}"
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4781498908996582R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox6.Style.Font.Name = "Arial Narrow"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.StyleName = "Normal.TableBody"
        Me.TextBox6.Value = "= Fields.ValorTransadoEquivalentePesos"
        '
        'TextBox7
        '
        Me.TextBox7.Format = "{0:P2}"
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79577130079269409R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox7.Style.Font.Name = "Arial Narrow"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox7.StyleName = "Normal.TableBody"
        Me.TextBox7.Value = "=Fields.PorcentajePesos"
        '
        'TextBox8
        '
        Me.TextBox8.Format = "{0:N2}"
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2088581323623657R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox8.Style.Font.Name = "Arial Narrow"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.StyleName = "Normal.TableBody"
        Me.TextBox8.Value = "= Fields.ValorTransadoDolares"
        '
        'TextBox3
        '
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0108957290649414R), Telerik.Reporting.Drawing.Unit.Inch(0.21874998509883881R))
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox3.Style.Font.Bold = True
        Me.TextBox3.Style.Font.Name = "Arial Narrow"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.StyleName = "Normal.TableBody"
        Me.TextBox3.Value = "Total Negociado en el MS en este día RD$"
        '
        'TextBox4
        '
        Me.TextBox4.Format = "{0:N2}"
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4781498908996582R), Telerik.Reporting.Drawing.Unit.Inch(0.21874998509883881R))
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Style.Font.Name = "Arial Narrow"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.StyleName = "Normal.TableBody"
        Me.TextBox4.Value = "= Sum(Fields.ValorTransadoEquivalentePesos)"
        '
        'TextBox9
        '
        Me.TextBox9.Format = "{0:P2}"
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.79577130079269409R), Telerik.Reporting.Drawing.Unit.Inch(0.21874998509883881R))
        Me.TextBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox9.Style.Font.Bold = True
        Me.TextBox9.Style.Font.Name = "Arial Narrow"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.StyleName = "Normal.TableBody"
        Me.TextBox9.Value = "=Sum(Fields.PorcentajePesos)"
        '
        'TextBox13
        '
        Me.TextBox13.Format = "{0:N2}"
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2088581323623657R), Telerik.Reporting.Drawing.Unit.Inch(0.21874998509883881R))
        Me.TextBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox13.Style.Font.Bold = True
        Me.TextBox13.Style.Font.Name = "Arial Narrow"
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox13.StyleName = "Normal.TableBody"
        Me.TextBox13.Value = "=Sum(Fields.ValorTransadoDolares)"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.detail.Name = "detail"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003890991210938R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9937566518783569R), Telerik.Reporting.Drawing.Unit.Inch(0.19999949634075165R))
        Me.TextBox81.Style.Font.Name = "Arial Narrow"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.PictureBox1, Me.TextBox58, Me.titleTextBox, Me.Table8})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4000000953674316R), Telerik.Reporting.Drawing.Unit.Inch(0.4479166567325592R))
        Me.PictureBox1.MimeType = "image/png"
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0957943201065063R), Telerik.Reporting.Drawing.Unit.Inch(0.547916829586029R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox1.Value = CType(resources.GetObject("PictureBox1.Value"), Object)
        '
        'TextBox58
        '
        Me.TextBox58.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.20208358764648438R), Telerik.Reporting.Drawing.Unit.Inch(1.0R))
        Me.TextBox58.Name = "TextBox58"
        Me.TextBox58.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.1000003814697266R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox58.Style.Font.Bold = True
        Me.TextBox58.Style.Font.Name = "Arial Narrow"
        Me.TextBox58.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox58.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox58.Value = resources.GetString("TextBox58.Value")
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.7020835876464844R), Telerik.Reporting.Drawing.Unit.Inch(0.4479166567325592R))
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.2999210357666016R), Telerik.Reporting.Drawing.Unit.Inch(0.54791665077209473R))
        Me.titleTextBox.Style.BackgroundColor = System.Drawing.Color.White
        Me.titleTextBox.Style.Color = System.Drawing.Color.Black
        Me.titleTextBox.Style.Font.Bold = True
        Me.titleTextBox.Style.Font.Name = "Arial Narrow"
        Me.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.titleTextBox.StyleName = "Title"
        Me.titleTextBox.Value = "Operaciones de Renta Fija por Emisor/Instrumento" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Mercado Secundario"
        '
        'Table8
        '
        Me.Table8.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R)))
        Me.Table8.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896R)))
        Me.Table8.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896R)))
        Me.Table8.Body.SetCellContent(1, 0, Me.TextBox90)
        Me.Table8.Body.SetCellContent(0, 0, Me.TextBox14)
        Me.Table8.ColumnGroups.Add(TableGroup8)
        Me.Table8.DataSource = Me.SqlBoletin
        Me.Table8.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox90, Me.TextBox14})
        Me.Table8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.03120756149292R), Telerik.Reporting.Drawing.Unit.Inch(0.000039339065551757813R))
        Me.Table8.Name = "Table8"
        TableGroup10.Name = "Group2"
        TableGroup11.Name = "Group1"
        TableGroup9.ChildGroups.Add(TableGroup10)
        TableGroup9.ChildGroups.Add(TableGroup11)
        TableGroup9.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup9.Name = "DetailGroup"
        Me.Table8.RowGroups.Add(TableGroup9)
        Me.Table8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791R))
        '
        'TextBox90
        '
        Me.TextBox90.Format = "{0:#.}"
        Me.TextBox90.Name = "TextBox90"
        Me.TextBox90.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Inch(0.11811023950576782R))
        Me.TextBox90.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox90.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox90.Value = "Rueda No. {Fields.Secuencial}"
        '
        'TextBox14
        '
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Cm(0.30000001192092896R))
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.StyleName = ""
        Me.TextBox14.Value = "BD {Fields.BD}"
        '
        'SqlBoletin
        '
        Me.SqlBoletin.ConnectionString = "CN"
        Me.SqlBoletin.Name = "SqlBoletin"
        Me.SqlBoletin.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value")})
        Me.SqlBoletin.SelectCommand = "dbo.SP_BuscarBoletinFecha"
        Me.SqlBoletin.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'OperacionesRentaFijaEmisorInstrumentoMercadoSecundario
        '
        Me.DataSource = Me.SqlBoletin
        Group1.GroupFooter = Me.GroupFooterSection1
        Group1.GroupHeader = Me.GroupHeaderSection1
        Group1.Name = "Group1"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.GroupHeaderSection1, Me.GroupFooterSection1, Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "OperacionesRentaFijaEmisorInstrumentoMercadoSecundario"
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaOperacion"
        ReportParameter1.Text = "Fecha Operación"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(7.5000004768371582R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox58 As Telerik.Reporting.TextBox
    Friend WithEvents titleTextBox As Telerik.Reporting.TextBox
    Friend WithEvents Group1 As Telerik.Reporting.Group
    Friend WithEvents GroupFooterSection1 As Telerik.Reporting.GroupFooterSection
    Friend WithEvents GroupHeaderSection1 As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents SqlOperacionesRentaFijaEmisorInstrumentoValorTransadoPorDia As Telerik.Reporting.SqlDataSource
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents Table8 As Telerik.Reporting.Table
    Friend WithEvents TextBox90 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents SqlBoletin As Telerik.Reporting.SqlDataSource
    Friend WithEvents Graph1 As Telerik.Reporting.Graph
    Friend WithEvents CartesianCoordinateSystem1 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents GraphAxis2 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis1 As Telerik.Reporting.GraphAxis
    Friend WithEvents BarSeries1 As Telerik.Reporting.BarSeries
End Class