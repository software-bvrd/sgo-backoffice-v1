Partial Class VolumenesTransadosAnyoPesos

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim GraphGroup1 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim CategoryScale1 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale1 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim GraphGroup2 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VolumenesTransadosAnyoPesos))
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter4 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.SqlMoneda = New Telerik.Reporting.SqlDataSource()
        Me.SqlMercado = New Telerik.Reporting.SqlDataSource()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Graph1 = New Telerik.Reporting.Graph()
        Me.CartesianCoordinateSystem1 = New Telerik.Reporting.CartesianCoordinateSystem()
        Me.GraphAxis2 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis1 = New Telerik.Reporting.GraphAxis()
        Me.SqlVolumenesTransadosAnyoPesos = New Telerik.Reporting.SqlDataSource()
        Me.BarSeries1 = New Telerik.Reporting.BarSeries()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.titleTextBox = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlMoneda
        '
        Me.SqlMoneda.ConnectionString = "CN"
        Me.SqlMoneda.Name = "SqlMoneda"
        Me.SqlMoneda.SelectCommand = "SELECT ' Todo en DOP' as Nombre, 'T' as Simbolo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UNION" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECT        Nombre, RTR" & _
    "IM(Simbolo)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            TipoMoneda" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ORDER BY Nombre"
        '
        'SqlMercado
        '
        Me.SqlMercado.ConnectionString = "CN"
        Me.SqlMercado.Name = "SqlMercado"
        Me.SqlMercado.SelectCommand = "SELECT        Alias, CodigoMercado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            vMercado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE        (Codig" & _
    "oMercado <> '')" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ORDER BY Alias"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(3.7145833969116211R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Graph1})
        Me.detail.Name = "detail"
        '
        'Graph1
        '
        GraphGroup1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.Anyo"))
        GraphGroup1.Name = "anyoGroup1"
        GraphGroup1.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.Anyo", Telerik.Reporting.SortDirection.Asc))
        Me.Graph1.CategoryGroups.Add(GraphGroup1)
        Me.Graph1.CoordinateSystems.Add(Me.CartesianCoordinateSystem1)
        Me.Graph1.DataSource = Me.SqlVolumenesTransadosAnyoPesos
        Me.Graph1.Legend.Style.Font.Name = "Arial Narrow"
        Me.Graph1.Legend.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.Graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.0R))
        Me.Graph1.Name = "Graph1"
        Me.Graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.Graph1.Series.Add(Me.BarSeries1)
        Me.Graph1.SeriesGroups.Add(GraphGroup2)
        Me.Graph1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.9999213218688965R), Telerik.Reporting.Drawing.Unit.Inch(3.7145440578460693R))
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
        Me.GraphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis2.MinorGridLineStyle.Visible = False
        Me.GraphAxis2.Name = "GraphAxis2"
        CategoryScale1.SpacingSlotCount = 1.0R
        Me.GraphAxis2.Scale = CategoryScale1
        Me.GraphAxis2.Style.Font.Name = "Arial Narrow"
        Me.GraphAxis2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        '
        'GraphAxis1
        '
        Me.GraphAxis1.LabelFormat = "{0:N2}"
        Me.GraphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
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
        'SqlVolumenesTransadosAnyoPesos
        '
        Me.SqlVolumenesTransadosAnyoPesos.ConnectionString = "CN"
        Me.SqlVolumenesTransadosAnyoPesos.Name = "SqlVolumenesTransadosAnyoPesos"
        Me.SqlVolumenesTransadosAnyoPesos.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@AyoInicio", System.Data.DbType.Int32, "=Parameters.AnyoInicial.Value"), New Telerik.Reporting.SqlDataSourceParameter("@AyoFinal", System.Data.DbType.Int32, "=Parameters.AnyoFinal.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Moneda", System.Data.DbType.AnsiString, "=Parameters.Moneda.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Mercado", System.Data.DbType.AnsiString, "=Parameters.Mercado.Value")})
        Me.SqlVolumenesTransadosAnyoPesos.SelectCommand = "dbo.SP_VolumenesTransadosAnyoPesos"
        Me.SqlVolumenesTransadosAnyoPesos.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'BarSeries1
        '
        Me.BarSeries1.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Overlapped
        Me.BarSeries1.CategoryGroup = GraphGroup1
        Me.BarSeries1.CoordinateSystem = Me.CartesianCoordinateSystem1
        Me.BarSeries1.DataPointLabel = "=(Fields.ValorTransado)"
        Me.BarSeries1.DataPointLabelFormat = "{0:N2}"
        Me.BarSeries1.DataPointLabelStyle.Font.Name = "Arial Narrow"
        Me.BarSeries1.DataPointLabelStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.BarSeries1.DataPointLabelStyle.Visible = True
        Me.BarSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0.0R)
        Me.BarSeries1.DataPointStyle.Visible = True
        Me.BarSeries1.LegendItem.Value = "=Fields.Anyo"
        Me.BarSeries1.LegendItem.Format = ""
        GraphGroup2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.Anyo"))
        GraphGroup2.Name = "anyoGroup2"
        GraphGroup2.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.Anyo", Telerik.Reporting.SortDirection.Asc))
        Me.BarSeries1.SeriesGroup = GraphGroup2
        Me.BarSeries1.Y = "=(Fields.ValorTransado)"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003890991210938R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9937566518783569R), Telerik.Reporting.Drawing.Unit.Inch(0.19999949634075165R))
        Me.TextBox81.Style.Font.Name = "Arial Narrow"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.84783768653869629R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox9, Me.titleTextBox, Me.PictureBox2, Me.TextBox30})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582R), Telerik.Reporting.Drawing.Unit.Inch(0.30212268233299255R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.8260493278503418R), Telerik.Reporting.Drawing.Unit.Inch(0.19992129504680634R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox9.Style.Color = System.Drawing.Color.Black
        Me.TextBox9.Style.Font.Bold = True
        Me.TextBox9.Style.Font.Name = "Arial Narrow"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.StyleName = "Title"
        Me.TextBox9.Value = "Desde el año {Parameters.AnyoInicial.Value} hasta el {Parameters.AnyoFinal.Value}" & _
    " "
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582R), Telerik.Reporting.Drawing.Unit.Inch(0.0R))
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.8260493278503418R), Telerik.Reporting.Drawing.Unit.Inch(0.30204400420188904R))
        Me.titleTextBox.Style.BackgroundColor = System.Drawing.Color.White
        Me.titleTextBox.Style.Color = System.Drawing.Color.Black
        Me.titleTextBox.Style.Font.Bold = True
        Me.titleTextBox.Style.Font.Name = "Arial Narrow"
        Me.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16.0R)
        Me.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.titleTextBox.StyleName = "Title"
        Me.titleTextBox.Value = "Representación Gráfica de los Volúmenes Transados"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.52612829208374R), Telerik.Reporting.Drawing.Unit.Inch(0.000039339065551757813R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4738327264785767R), Telerik.Reporting.Drawing.Unit.Inch(0.74791687726974487R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:d}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582R), Telerik.Reporting.Drawing.Unit.Inch(0.50212264060974121R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.8260493278503418R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox30.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox30.Style.Color = System.Drawing.Color.Black
        Me.TextBox30.Style.Font.Bold = True
        Me.TextBox30.Style.Font.Name = "Arial Narrow"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.Value = "Valor en {IIF(Parameters.Moneda.Value='T','Todo en Pesos',Parameters.Moneda.Value" & _
    ")}"
        '
        'VolumenesTransadosAnyoPesos
        '
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "VolumenesTransadosAyoPesos"
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.AllowBlank = False
        ReportParameter1.Name = "AnyoInicial"
        ReportParameter1.Text = "Año Inicial:"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.[Integer]
        ReportParameter1.Value = ""
        ReportParameter1.Visible = True
        ReportParameter2.AllowBlank = False
        ReportParameter2.Name = "AnyoFinal"
        ReportParameter2.Text = "Año Final:"
        ReportParameter2.Type = Telerik.Reporting.ReportParameterType.[Integer]
        ReportParameter2.Visible = True
        ReportParameter3.AvailableValues.DataSource = Me.SqlMoneda
        ReportParameter3.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter3.AvailableValues.ValueMember = "= Fields.Simbolo"
        ReportParameter3.Name = "Moneda"
        ReportParameter3.Text = "Moneda:"
        ReportParameter3.Visible = True
        ReportParameter4.AvailableValues.DataSource = Me.SqlMercado
        ReportParameter4.AvailableValues.DisplayMember = "= Fields.Alias"
        ReportParameter4.AvailableValues.ValueMember = "= Fields.CodigoMercado"
        ReportParameter4.Name = "Mercado"
        ReportParameter4.Text = "Mercado"
        ReportParameter4.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.ReportParameters.Add(ReportParameter3)
        Me.ReportParameters.Add(ReportParameter4)
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
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents titleTextBox As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents SqlVolumenesTransadosAnyoPesos As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlMoneda As Telerik.Reporting.SqlDataSource
    Friend WithEvents Graph1 As Telerik.Reporting.Graph
    Friend WithEvents CartesianCoordinateSystem1 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents GraphAxis2 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis1 As Telerik.Reporting.GraphAxis
    Friend WithEvents BarSeries1 As Telerik.Reporting.BarSeries
    Friend WithEvents SqlMercado As Telerik.Reporting.SqlDataSource
End Class