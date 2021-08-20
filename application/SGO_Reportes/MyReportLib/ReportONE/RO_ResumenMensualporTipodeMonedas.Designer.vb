Partial Class RO_ResumenMensualporTipodeMonedas

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RO_ResumenMensualporTipodeMonedas))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup5 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim GraphGroup1 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim GraphTitle1 As Telerik.Reporting.GraphTitle = New Telerik.Reporting.GraphTitle()
        Dim CategoryScale1 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale1 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim GraphGroup2 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim GraphGroup3 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim GraphTitle2 As Telerik.Reporting.GraphTitle = New Telerik.Reporting.GraphTitle()
        Dim NumericalScale2 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim CategoryScale2 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim GraphGroup4 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim CategoryScale3 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale3 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.SP_RO_ResumenMensualporTipodeMonedas = New Telerik.Reporting.SqlDataSource()
        Me.Graph1 = New Telerik.Reporting.Graph()
        Me.CartesianCoordinateSystem1 = New Telerik.Reporting.CartesianCoordinateSystem()
        Me.GraphAxis2 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis1 = New Telerik.Reporting.GraphAxis()
        Me.BarSeries1 = New Telerik.Reporting.BarSeries()
        Me.Graph2 = New Telerik.Reporting.Graph()
        Me.PolarCoordinateSystem1 = New Telerik.Reporting.PolarCoordinateSystem()
        Me.GraphAxis5 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis6 = New Telerik.Reporting.GraphAxis()
        Me.BarSeries2 = New Telerik.Reporting.BarSeries()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.GraphAxis4 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis3 = New Telerik.Reporting.GraphAxis()
        Me.CartesianCoordinateSystem2 = New Telerik.Reporting.CartesianCoordinateSystem()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox6
        '
        Me.TextBox6.Multiline = True
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7458980083465576R), Telerik.Reporting.Drawing.Unit.Inch(0.40000033378601074R))
        Me.TextBox6.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.Font.Bold = True
        Me.TextBox6.Style.Font.Name = "Calibri"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox6.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox6.StyleName = "Normal.TableHeader"
        Me.TextBox6.TextWrap = True
        Me.TextBox6.Value = "Mercado"
        '
        'TextBox19
        '
        Me.TextBox19.CanShrink = True
        Me.TextBox19.Multiline = True
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3008337020874023R), Telerik.Reporting.Drawing.Unit.Inch(0.40000033378601074R))
        Me.TextBox19.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox19.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox19.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox19.Style.Font.Bold = True
        Me.TextBox19.Style.Font.Name = "Calibri"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox19.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox19.StyleName = "Normal.TableHeader"
        Me.TextBox19.TextWrap = True
        Me.TextBox19.Value = "Total Transado en la BVRD"
        '
        'TextBox7
        '
        Me.TextBox7.CanShrink = True
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8125007152557373R), Telerik.Reporting.Drawing.Unit.Inch(0.40000033378601074R))
        Me.TextBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox7.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox7.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox7.Style.Font.Bold = True
        Me.TextBox7.Style.Font.Name = "Calibri"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox7.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.StyleName = "Normal.TableHeader"
        Me.TextBox7.TextWrap = True
        Me.TextBox7.Value = "PORC"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.86614179611206055R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox3, Me.TextBox9, Me.TextBox18, Me.TextBox21, Me.PictureBox2})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8503546714782715R), Telerik.Reporting.Drawing.Unit.Inch(0.19992129504680634R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox3.Style.Color = System.Drawing.Color.Black
        Me.TextBox3.Style.Font.Bold = True
        Me.TextBox3.Style.Font.Name = "Calibri"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.StyleName = "Title"
        Me.TextBox3.Value = "Bolsa y Mercados de Valores de la República Dominicana, S. A."
        '
        'TextBox9
        '
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.20003938674926758R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8503546714782715R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox9.Style.Color = System.Drawing.Color.Black
        Me.TextBox9.Style.Font.Bold = False
        Me.TextBox9.Style.Font.Name = "Calibri"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.StyleName = "Title"
        Me.TextBox9.Value = "Resumen Mensual por Tipo de Monedas"
        '
        'TextBox18
        '
        Me.TextBox18.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000078837074397597462R), Telerik.Reporting.Drawing.Unit.Inch(0.35011816024780273R))
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8503150939941406R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox18.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox18.Style.Color = System.Drawing.Color.Black
        Me.TextBox18.Style.Font.Bold = False
        Me.TextBox18.Style.Font.Name = "Calibri"
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox18.StyleName = "Title"
        Me.TextBox18.Value = "Mercado Primario (MP) y Secundario (MS)"
        '
        'TextBox21
        '
        Me.TextBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000078837074397597462R), Telerik.Reporting.Drawing.Unit.Inch(0.50019693374633789R))
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8503150939941406R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox21.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox21.Style.Color = System.Drawing.Color.Black
        Me.TextBox21.Style.Font.Bold = False
        Me.TextBox21.Style.Font.Name = "Calibri"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox21.StyleName = "Title"
        Me.TextBox21.Value = "{ConvertirFechas.FormatdateAsMonthName(Parameters.Fecha.Value)} {CStr(CInt(Conver" &
    "tirFechas.FormatdateYear(Parameters.Fecha.Value)))}"
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.477783203125R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3743462562561035R), Telerik.Reporting.Drawing.Unit.Inch(0.61549556255340576R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(6.9291343688964844R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table1, Me.Graph1, Me.Graph2, Me.TextBox4})
        Me.detail.Name = "detail"
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(3.7458980083465576R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.3008344173431396R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.81250065565109253R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.50000143051147461R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox24)
        Me.Table1.Body.SetCellContent(1, 0, Me.TextBox1)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox16)
        Me.Table1.Body.SetCellContent(1, 1, Me.TextBox17)
        Me.Table1.Body.SetCellContent(1, 2, Me.TextBox5)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox2)
        TableGroup1.Name = "Group4"
        TableGroup1.ReportItem = Me.TextBox6
        TableGroup2.Name = "group4"
        TableGroup2.ReportItem = Me.TextBox19
        TableGroup3.Name = "group1"
        TableGroup3.ReportItem = Me.TextBox7
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup2)
        Me.Table1.ColumnGroups.Add(TableGroup3)
        Me.Table1.DataSource = Me.SP_RO_ResumenMensualporTipodeMonedas
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox24, Me.TextBox16, Me.TextBox2, Me.TextBox1, Me.TextBox17, Me.TextBox5, Me.TextBox6, Me.TextBox19, Me.TextBox7})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.12370077520608902R))
        Me.Table1.Name = "Table1"
        TableGroup4.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup4.Name = "Detail"
        TableGroup5.Name = "group"
        Me.Table1.RowGroups.Add(TableGroup4)
        Me.Table1.RowGroups.Add(TableGroup5)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8592329025268555R), Telerik.Reporting.Drawing.Unit.Inch(0.79685121774673462R))
        Me.Table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.Table1.StyleName = "Normal.TableNormal"
        '
        'TextBox24
        '
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7458980083465576R), Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R))
        Me.TextBox24.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox24.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox24.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox24.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox24.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox24.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox24.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox24.Style.Font.Name = "Calibri"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.StyleName = "Normal.TableBody"
        Me.TextBox24.Value = "= Fields.NombreMercado"
        '
        'TextBox1
        '
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7458980083465576R), Telerik.Reporting.Drawing.Unit.Cm(0.50000137090682983R))
        Me.TextBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox1.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox1.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.StyleName = "Normal.TableBody"
        Me.TextBox1.Value = "Total ambos merdados en RD$"
        '
        'TextBox16
        '
        Me.TextBox16.Format = "{0:N0}"
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3008337020874023R), Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R))
        Me.TextBox16.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox16.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox16.Style.Font.Name = "Calibri"
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox16.StyleName = "Normal.TableBody"
        Me.TextBox16.Value = "= Fields.ValorTransadoTotal"
        '
        'TextBox17
        '
        Me.TextBox17.Format = "{0:N0}"
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3008337020874023R), Telerik.Reporting.Drawing.Unit.Cm(0.50000143051147461R))
        Me.TextBox17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.Font.Bold = True
        Me.TextBox17.Style.Font.Name = "Calibri"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.StyleName = "Normal.TableBody"
        Me.TextBox17.Value = "=Sum(Fields.ValorTransadoTotal)"
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8125007152557373R), Telerik.Reporting.Drawing.Unit.Cm(0.50000143051147461R))
        Me.TextBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox5.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Style.Font.Name = "Calibri"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = "Normal.TableBody"
        Me.TextBox5.Value = "100%"
        '
        'TextBox2
        '
        Me.TextBox2.Format = "{0:P0}"
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8125007152557373R), Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R))
        Me.TextBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Normal.TableBody"
        Me.TextBox2.Value = "=Fields.Porcentaje"
        '
        'SP_RO_ResumenMensualporTipodeMonedas
        '
        Me.SP_RO_ResumenMensualporTipodeMonedas.ConnectionString = "CN"
        Me.SP_RO_ResumenMensualporTipodeMonedas.Name = "SP_RO_ResumenMensualporTipodeMonedas"
        Me.SP_RO_ResumenMensualporTipodeMonedas.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@pFechaFinal", System.Data.DbType.[Date], "= Parameters.Fecha.Value")})
        Me.SP_RO_ResumenMensualporTipodeMonedas.SelectCommand = "dbo.SP_RO_ResumenMensualporTipodeMonedas"
        Me.SP_RO_ResumenMensualporTipodeMonedas.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'Graph1
        '
        GraphGroup1.Name = "categoryGroup"
        Me.Graph1.CategoryGroups.Add(GraphGroup1)
        Me.Graph1.CoordinateSystems.Add(Me.CartesianCoordinateSystem1)
        Me.Graph1.DataSource = Me.SP_RO_ResumenMensualporTipodeMonedas
        Me.Graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(1.0629920959472656R))
        Me.Graph1.Name = "Graph1"
        Me.Graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph1.Series.Add(Me.BarSeries1)
        Me.Graph1.SeriesGroups.Add(GraphGroup2)
        Me.Graph1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8503937721252441R), Telerik.Reporting.Drawing.Unit.Inch(2.7100000381469727R))
        Me.Graph1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        GraphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter
        GraphTitle1.Style.LineColor = System.Drawing.Color.LightGray
        GraphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        GraphTitle1.Style.Visible = False
        GraphTitle1.Text = "Graph1"
        Me.Graph1.Titles.Add(GraphTitle1)
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
        Me.GraphAxis2.Scale = CategoryScale1
        Me.GraphAxis2.Style.Visible = False
        '
        'GraphAxis1
        '
        Me.GraphAxis1.LabelFormat = "{0:P0}"
        Me.GraphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MinorGridLineStyle.Visible = False
        Me.GraphAxis1.Name = "GraphAxis1"
        Me.GraphAxis1.Scale = NumericalScale1
        '
        'BarSeries1
        '
        Me.BarSeries1.CategoryGroup = GraphGroup1
        Me.BarSeries1.CoordinateSystem = Me.CartesianCoordinateSystem1
        Me.BarSeries1.DataPointLabel = "= Sum(Fields.Porcentaje)"
        Me.BarSeries1.DataPointLabelFormat = "{0:P0}"
        Me.BarSeries1.DataPointLabelStyle.Visible = True
        Me.BarSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries1.DataPointStyle.Visible = True
        Me.BarSeries1.LegendItem.Value = "= Fields.NombreMercado"
        Me.BarSeries1.Name = "BarSeries1"
        GraphGroup2.Groupings.Add(New Telerik.Reporting.Grouping("= Fields.NombreMercado"))
        GraphGroup2.Name = "nombreMercadoGroup"
        GraphGroup2.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.NombreMercado", Telerik.Reporting.SortDirection.Asc))
        Me.BarSeries1.SeriesGroup = GraphGroup2
        Me.BarSeries1.Y = "= Sum(Fields.Porcentaje)"
        '
        'Graph2
        '
        GraphGroup3.Name = "categoryGroup1"
        Me.Graph2.CategoryGroups.Add(GraphGroup3)
        Me.Graph2.CoordinateSystems.Add(Me.PolarCoordinateSystem1)
        Me.Graph2.DataSource = Me.SP_RO_ResumenMensualporTipodeMonedas
        Me.Graph2.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph2.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0088392896577715874R), Telerik.Reporting.Drawing.Unit.Inch(3.7730712890625R))
        Me.Graph2.Name = "Graph2"
        Me.Graph2.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph2.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph2.Series.Add(Me.BarSeries2)
        Me.Graph2.SeriesGroups.Add(GraphGroup4)
        Me.Graph2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8503937721252441R), Telerik.Reporting.Drawing.Unit.Inch(2.7100000381469727R))
        Me.Graph2.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.Graph2.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        GraphTitle2.Position = Telerik.Reporting.GraphItemPosition.TopCenter
        GraphTitle2.Style.LineColor = System.Drawing.Color.LightGray
        GraphTitle2.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        GraphTitle2.Style.Visible = False
        GraphTitle2.Text = "Graph2"
        Me.Graph2.Titles.Add(GraphTitle2)
        '
        'PolarCoordinateSystem1
        '
        Me.PolarCoordinateSystem1.AngularAxis = Me.GraphAxis5
        Me.PolarCoordinateSystem1.Name = "PolarCoordinateSystem1"
        Me.PolarCoordinateSystem1.RadialAxis = Me.GraphAxis6
        '
        'GraphAxis5
        '
        Me.GraphAxis5.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis5.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis5.MajorGridLineStyle.Visible = False
        Me.GraphAxis5.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis5.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis5.MinorGridLineStyle.Visible = False
        Me.GraphAxis5.Name = "GraphAxis5"
        Me.GraphAxis5.Scale = NumericalScale2
        Me.GraphAxis5.Style.Visible = False
        '
        'GraphAxis6
        '
        Me.GraphAxis6.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis6.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis6.MajorGridLineStyle.Visible = False
        Me.GraphAxis6.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis6.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis6.MinorGridLineStyle.Visible = False
        Me.GraphAxis6.Name = "GraphAxis6"
        CategoryScale2.PositionMode = Telerik.Reporting.AxisPositionMode.OnTicks
        CategoryScale2.SpacingSlotCount = 0R
        Me.GraphAxis6.Scale = CategoryScale2
        Me.GraphAxis6.Style.Visible = False
        '
        'BarSeries2
        '
        Me.BarSeries2.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Stacked100
        Me.BarSeries2.CategoryGroup = GraphGroup3
        Me.BarSeries2.CoordinateSystem = Me.PolarCoordinateSystem1
        Me.BarSeries2.DataPointLabel = "= Sum(Fields.ValorTransadoTotal)"
        Me.BarSeries2.DataPointLabelAlignment = Telerik.Reporting.BarDataPointLabelAlignment.OutsideColumn
        Me.BarSeries2.DataPointLabelConnectorStyle.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.BarSeries2.DataPointLabelConnectorStyle.Padding.Top = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.BarSeries2.DataPointLabelFormat = "{0:N2}"
        Me.BarSeries2.DataPointLabelOffset = Telerik.Reporting.Drawing.Unit.Mm(5.0R)
        Me.BarSeries2.DataPointLabelStyle.Visible = True
        Me.BarSeries2.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries2.DataPointStyle.Visible = True
        Me.BarSeries2.LegendItem.Value = "= Fields.NombreMercado"
        Me.BarSeries2.Name = "BarSeries2"
        GraphGroup4.Groupings.Add(New Telerik.Reporting.Grouping("= Fields.NombreMercado"))
        GraphGroup4.Name = "nombreMercadoGroup1"
        GraphGroup4.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.NombreMercado", Telerik.Reporting.SortDirection.Asc))
        Me.BarSeries2.SeriesGroup = GraphGroup4
        Me.BarSeries2.X = "= Sum(Fields.ValorTransadoTotal)"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0089181261137127876R), Telerik.Reporting.Drawing.Unit.Inch(6.5748038291931152R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.8503150939941406R), Telerik.Reporting.Drawing.Unit.Inch(0.23622067272663117R))
        Me.TextBox4.Style.Font.Name = "Calibri"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.Value = "Los valores emitidos en dólares (US$), son presentados por su equivalencia en pes" &
    "os (RD$) según la tasa del día en que fueron transados."
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003943145275116R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageInfoTextBox, Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.8000001907348633R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1999998092651367R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Calibri"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8999998569488525R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD / {Now()}"
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
        Me.GraphAxis4.Scale = CategoryScale3
        Me.GraphAxis4.Style.Visible = False
        '
        'GraphAxis3
        '
        Me.GraphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis3.MajorGridLineStyle.Visible = False
        Me.GraphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis3.MinorGridLineStyle.Visible = False
        Me.GraphAxis3.Name = "GraphAxis3"
        Me.GraphAxis3.Scale = NumericalScale3
        Me.GraphAxis3.Style.Visible = False
        Me.GraphAxis3.TitleStyle.Visible = False
        '
        'CartesianCoordinateSystem2
        '
        Me.CartesianCoordinateSystem2.Name = "CartesianCoordinateSystem2"
        Me.CartesianCoordinateSystem2.XAxis = Me.GraphAxis4
        Me.CartesianCoordinateSystem2.YAxis = Me.GraphAxis3
        '
        'RO_ResumenMensualporTipodeMonedas
        '
        Me.DocumentName = "Mdo g"
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "RO_ResumenMensualporTipodeMonedas"
        Me.PageSettings.Landscape = true
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "Fecha"
        ReportParameter1.Text = "Fecha"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(9.8521690368652344R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents SP_RO_ResumenMensualporTipodeMonedas As Telerik.Reporting.SqlDataSource
    Friend WithEvents GraphAxis4 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis3 As Telerik.Reporting.GraphAxis
    Friend WithEvents CartesianCoordinateSystem2 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents Graph1 As Telerik.Reporting.Graph
    Friend WithEvents CartesianCoordinateSystem1 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents GraphAxis2 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis1 As Telerik.Reporting.GraphAxis
    Friend WithEvents BarSeries1 As Telerik.Reporting.BarSeries
    Friend WithEvents Graph2 As Telerik.Reporting.Graph
    Friend WithEvents PolarCoordinateSystem1 As Telerik.Reporting.PolarCoordinateSystem
    Friend WithEvents GraphAxis5 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis6 As Telerik.Reporting.GraphAxis
    Friend WithEvents BarSeries2 As Telerik.Reporting.BarSeries
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class