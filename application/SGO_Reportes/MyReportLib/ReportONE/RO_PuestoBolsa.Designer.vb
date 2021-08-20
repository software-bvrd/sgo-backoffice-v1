Partial Class RO_PuestoBolsa

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RO_PuestoBolsa))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup5 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup6 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup7 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup8 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup9 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup10 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup11 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup12 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup13 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup14 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup15 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup16 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim GraphGroup1 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim GraphTitle1 As Telerik.Reporting.GraphTitle = New Telerik.Reporting.GraphTitle()
        Dim CategoryScale1 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale1 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim GraphGroup2 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.SP_RO_OperacionesPorPuestodeBolsa_MP = New Telerik.Reporting.SqlDataSource()
        Me.Graph1 = New Telerik.Reporting.Graph()
        Me.CartesianCoordinateSystem1 = New Telerik.Reporting.CartesianCoordinateSystem()
        Me.GraphAxis2 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis1 = New Telerik.Reporting.GraphAxis()
        Me.BarSeries1 = New Telerik.Reporting.BarSeries()
        Me.BarSeries2 = New Telerik.Reporting.BarSeries()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4723832607269287R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox5.Style.Color = System.Drawing.Color.Black
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Style.Font.Name = "Calibri"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = "Civic.TableHeader"
        Me.TextBox5.Value = "PUESTO DE BOLSA"
        '
        'TextBox21
        '
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.083332896232605R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox21.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox21.Style.Color = System.Drawing.Color.Black
        Me.TextBox21.Style.Font.Bold = True
        Me.TextBox21.Style.Font.Name = "Calibri"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox21.StyleName = "Civic.TableHeader"
        Me.TextBox21.Value = "SIGLAS PB"
        '
        'TextBox10
        '
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5445064306259155R), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343R))
        Me.TextBox10.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox10.Style.Color = System.Drawing.Color.Black
        Me.TextBox10.Style.Font.Bold = True
        Me.TextBox10.Style.Font.Name = "Calibri"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.StyleName = "Civic.TableHeader"
        Me.TextBox10.Value = "COMPRADOR"
        '
        'TextBox4
        '
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82291626930236816R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox4.Style.Color = System.Drawing.Color.Black
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Style.Font.Name = "Calibri"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.StyleName = "Civic.TableHeader"
        Me.TextBox4.Value = "%"
        '
        'TextBox7
        '
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.52083420753479R), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343R))
        Me.TextBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox7.Style.Color = System.Drawing.Color.Black
        Me.TextBox7.Style.Font.Bold = True
        Me.TextBox7.Style.Font.Name = "Calibri"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox7.StyleName = "Civic.TableHeader"
        Me.TextBox7.Value = "VENDEDOR"
        '
        'TextBox11
        '
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77083402872085571R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox11.Style.Color = System.Drawing.Color.Black
        Me.TextBox11.Style.Font.Bold = True
        Me.TextBox11.Style.Font.Name = "Calibri"
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox11.StyleName = "Civic.TableHeader"
        Me.TextBox11.Value = "%"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.80003947019577026R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1, Me.TextBox9, Me.TextBox30, Me.PictureBox2})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.000039339065551757812R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.100182056427002R), Telerik.Reporting.Drawing.Unit.Inch(0.19992129504680634R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.StyleName = "Title"
        Me.TextBox1.Value = "Bolsa y Mercados de Valores de la República Dominicana, S. A."
        '
        'TextBox9
        '
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.20003922283649445R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.100182056427002R), Telerik.Reporting.Drawing.Unit.Inch(0.14791679382324219R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox9.Style.Color = System.Drawing.Color.Black
        Me.TextBox9.Style.Font.Bold = False
        Me.TextBox9.Style.Font.Name = "Calibri"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.StyleName = "Title"
        Me.TextBox9.Value = "Mercado Primario (MP) y Secundario (MS)"
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:d}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.34803485870361328R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.100182056427002R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox30.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox30.Style.Color = System.Drawing.Color.Black
        Me.TextBox30.Style.Font.Bold = False
        Me.TextBox30.Style.Font.Name = "Calibri"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.Value = "Operaciones del Mes por Entidades Emisoras - {ConvertirFechas.FormatdateAsMonthNa" &
    "me(Parameters.Fecha.Value)} {CStr(CInt(ConvertirFechas.FormatdateYear(Parameters" &
    ".Fecha.Value)))}"
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.8300457000732422R), Telerik.Reporting.Drawing.Unit.Inch(0R))
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
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(4.0999608039855957R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table1, Me.Graph1})
        Me.detail.Name = "detail"
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.4723830223083496R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.0833327770233154R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.5445059537887573R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.82291620969772339R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.5208343267440796R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.77083414793014526R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox14)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox16)
        Me.Table1.Body.SetCellContent(0, 3, Me.TextBox2)
        Me.Table1.Body.SetCellContent(0, 4, Me.TextBox3)
        Me.Table1.Body.SetCellContent(0, 5, Me.TextBox6)
        Me.Table1.Body.SetCellContent(1, 2, Me.TextBox12)
        Me.Table1.Body.SetCellContent(1, 4, Me.TextBox15)
        Me.Table1.Body.SetCellContent(1, 0, Me.TextBox18)
        Me.Table1.Body.SetCellContent(1, 5, Me.TextBox8)
        Me.Table1.Body.SetCellContent(1, 1, Me.TextBox20)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox17)
        Me.Table1.Body.SetCellContent(1, 3, Me.TextBox19)
        TableGroup2.Name = "Group3"
        TableGroup2.ReportItem = Me.TextBox5
        TableGroup1.ChildGroups.Add(TableGroup2)
        TableGroup1.Groupings.Add(New Telerik.Reporting.Grouping("=""T"""))
        TableGroup1.Name = "columnGroup"
        TableGroup1.Sortings.Add(New Telerik.Reporting.Sorting("=""T""", Telerik.Reporting.SortDirection.Asc))
        TableGroup4.Name = "group11"
        TableGroup4.ReportItem = Me.TextBox21
        TableGroup3.ChildGroups.Add(TableGroup4)
        TableGroup3.Name = "group10"
        TableGroup6.Name = "Group5"
        TableGroup6.ReportItem = Me.TextBox10
        TableGroup5.ChildGroups.Add(TableGroup6)
        TableGroup5.Name = "group4"
        TableGroup8.Name = "group"
        TableGroup8.ReportItem = Me.TextBox4
        TableGroup7.ChildGroups.Add(TableGroup8)
        TableGroup7.Name = "group5"
        TableGroup10.Name = "group1"
        TableGroup10.ReportItem = Me.TextBox7
        TableGroup9.ChildGroups.Add(TableGroup10)
        TableGroup9.Name = "group6"
        TableGroup12.Name = "group2"
        TableGroup12.ReportItem = Me.TextBox11
        TableGroup11.ChildGroups.Add(TableGroup12)
        TableGroup11.Name = "group7"
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup3)
        Me.Table1.ColumnGroups.Add(TableGroup5)
        Me.Table1.ColumnGroups.Add(TableGroup7)
        Me.Table1.ColumnGroups.Add(TableGroup9)
        Me.Table1.ColumnGroups.Add(TableGroup11)
        Me.Table1.ColumnHeadersPrintOnEveryPage = True
        Me.Table1.DataSource = Me.SP_RO_OperacionesPorPuestodeBolsa_MP
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox14, Me.TextBox17, Me.TextBox16, Me.TextBox2, Me.TextBox3, Me.TextBox6, Me.TextBox18, Me.TextBox20, Me.TextBox12, Me.TextBox19, Me.TextBox15, Me.TextBox8, Me.TextBox5, Me.TextBox21, Me.TextBox10, Me.TextBox4, Me.TextBox7, Me.TextBox11})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.Table1.Name = "Table1"
        TableGroup14.Name = "group8"
        TableGroup13.ChildGroups.Add(TableGroup14)
        TableGroup13.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup13.Name = "Detail"
        TableGroup16.Name = "group9"
        TableGroup15.ChildGroups.Add(TableGroup16)
        TableGroup15.Name = "group3"
        Me.Table1.RowGroups.Add(TableGroup13)
        Me.Table1.RowGroups.Add(TableGroup15)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.21480655670166R), Telerik.Reporting.Drawing.Unit.Inch(0.59999996423721313R))
        Me.Table1.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.MontoVendedor", Telerik.Reporting.SortDirection.Desc))
        Me.Table1.StyleName = "Civic.TableNormal"
        '
        'TextBox14
        '
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4723832607269287R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox14.Style.Font.Name = "Calibri"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.StyleName = "Civic.TableBody"
        Me.TextBox14.Value = "= Fields.PuestoBolsa"
        '
        'TextBox16
        '
        Me.TextBox16.Format = "{0:N0}"
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5445064306259155R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox16.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox16.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox16.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox16.Style.Font.Name = "Calibri"
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox16.StyleName = "Civic.TableBody"
        Me.TextBox16.Value = "=Fields.MontoComprador"
        '
        'TextBox2
        '
        Me.TextBox2.Format = "{0:P2}"
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82291626930236816R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Civic.TableBody"
        Me.TextBox2.Value = "= Fields.PorcentajeComprador"
        '
        'TextBox3
        '
        Me.TextBox3.Format = "{0:N0}"
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.52083420753479R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox3.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox3.Style.Font.Name = "Calibri"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.StyleName = "Civic.TableBody"
        Me.TextBox3.Value = "= Fields.MontoVendedor"
        '
        'TextBox6
        '
        Me.TextBox6.Format = "{0:P2}"
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77083402872085571R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox6.Style.Font.Name = "Calibri"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.StyleName = "Civic.TableBody"
        Me.TextBox6.Value = "= Fields.PorcentajeVendedor"
        '
        'TextBox12
        '
        Me.TextBox12.Format = "{0:N0}"
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5445064306259155R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox12.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox12.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox12.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox12.Style.Color = System.Drawing.Color.White
        Me.TextBox12.Style.Font.Bold = True
        Me.TextBox12.Style.Font.Name = "Calibri"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.StyleName = "Civic.TableBody"
        Me.TextBox12.Value = "=Sum(Fields.MontoComprador)"
        '
        'TextBox15
        '
        Me.TextBox15.Format = "{0:N0}"
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.52083420753479R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox15.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox15.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox15.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox15.Style.Color = System.Drawing.Color.White
        Me.TextBox15.Style.Font.Bold = True
        Me.TextBox15.Style.Font.Name = "Calibri"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.StyleName = "Civic.TableBody"
        Me.TextBox15.Value = "=Sum(Fields.MontoVendedor)"
        '
        'TextBox18
        '
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4723832607269287R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox18.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox18.Style.Color = System.Drawing.Color.White
        Me.TextBox18.Style.Font.Bold = True
        Me.TextBox18.Style.Font.Name = "Calibri"
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox18.StyleName = "Civic.TableHeader"
        Me.TextBox18.Value = "TOTALES"
        '
        'TextBox8
        '
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.77083402872085571R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox8.Style.Color = System.Drawing.Color.White
        Me.TextBox8.Style.Font.Bold = True
        Me.TextBox8.Style.Font.Name = "Calibri"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.StyleName = "Civic.TableHeader"
        Me.TextBox8.Value = "100.00%"
        '
        'TextBox20
        '
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.083332896232605R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox20.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox20.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox20.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox20.Style.Color = System.Drawing.Color.White
        Me.TextBox20.Style.Font.Bold = True
        Me.TextBox20.Style.Font.Name = "Calibri"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox20.StyleName = "Civic.TableBody"
        '
        'TextBox17
        '
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.083332896232605R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox17.Style.Font.Name = "Calibri"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.StyleName = "Civic.TableBody"
        Me.TextBox17.Value = "= Fields.SiglasPB"
        '
        'TextBox19
        '
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.82291626930236816R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox19.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox19.Style.Color = System.Drawing.Color.White
        Me.TextBox19.Style.Font.Bold = True
        Me.TextBox19.Style.Font.Name = "Calibri"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox19.StyleName = "Civic.TableHeader"
        Me.TextBox19.Value = "100.00%"
        '
        'SP_RO_OperacionesPorPuestodeBolsa_MP
        '
        Me.SP_RO_OperacionesPorPuestodeBolsa_MP.ConnectionString = "CN"
        Me.SP_RO_OperacionesPorPuestodeBolsa_MP.Name = "SP_RO_OperacionesPorPuestodeBolsa_MP"
        Me.SP_RO_OperacionesPorPuestodeBolsa_MP.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@pFechaFinal", System.Data.DbType.[Date], "= Parameters.Fecha.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Mercado", System.Data.DbType.AnsiStringFixedLength, "23"), New Telerik.Reporting.SqlDataSourceParameter("@PeriodoEvaluar", System.Data.DbType.AnsiStringFixedLength, "M"), New Telerik.Reporting.SqlDataSourceParameter("@DetalleResumen", System.Data.DbType.AnsiStringFixedLength, "D")})
        Me.SP_RO_OperacionesPorPuestodeBolsa_MP.SelectCommand = "dbo.SP_RO_OperacionesPorPuestodeBolsa"
        Me.SP_RO_OperacionesPorPuestodeBolsa_MP.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'Graph1
        '
        GraphGroup1.Groupings.Add(New Telerik.Reporting.Grouping("= Fields.SiglasPB"))
        GraphGroup1.Name = "siglasPBGroup"
        GraphGroup1.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.MontoComprador", Telerik.Reporting.SortDirection.Desc))
        GraphGroup1.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.MontoVendedor", Telerik.Reporting.SortDirection.Desc))
        Me.Graph1.CategoryGroups.Add(GraphGroup1)
        Me.Graph1.CoordinateSystems.Add(Me.CartesianCoordinateSystem1)
        Me.Graph1.DataSource = Me.SP_RO_OperacionesPorPuestodeBolsa_MP
        Me.Graph1.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph1.Legend.Style.Visible = True
        Me.Graph1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.79996061325073242R))
        Me.Graph1.Name = "Graph1"
        Me.Graph1.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph1.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph1.Series.Add(Me.BarSeries1)
        Me.Graph1.Series.Add(Me.BarSeries2)
        Me.Graph1.SeriesGroups.Add(GraphGroup2)
        Me.Graph1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.2147674560546875R), Telerik.Reporting.Drawing.Unit.Inch(3.1000001430511475R))
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
        Me.GraphAxis2.MajorGridLineStyle.Visible = False
        Me.GraphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis2.MinorGridLineStyle.Visible = False
        Me.GraphAxis2.Name = "GraphAxis2"
        Me.GraphAxis2.Scale = CategoryScale1
        '
        'GraphAxis1
        '
        Me.GraphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MajorGridLineStyle.Visible = False
        Me.GraphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.GraphAxis1.MinorGridLineStyle.Visible = False
        Me.GraphAxis1.Name = "GraphAxis1"
        Me.GraphAxis1.Scale = NumericalScale1
        Me.GraphAxis1.Style.Visible = False
        '
        'BarSeries1
        '
        Me.BarSeries1.CategoryGroup = GraphGroup1
        Me.BarSeries1.CoordinateSystem = Me.CartesianCoordinateSystem1
        Me.BarSeries1.DataPointLabel = "= Sum(Fields.MontoComprador)"
        Me.BarSeries1.DataPointLabelStyle.Visible = False
        Me.BarSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries1.DataPointStyle.Visible = True
        Me.BarSeries1.LegendItem.Value = "'Sum(MontoComprador)'"
        Me.BarSeries1.Name = "BarSeries1"
        GraphGroup2.Name = "seriesGroup"
        Me.BarSeries1.SeriesGroup = GraphGroup2
        Me.BarSeries1.Y = "= Sum(Fields.MontoComprador)"
        '
        'BarSeries2
        '
        Me.BarSeries2.CategoryGroup = GraphGroup1
        Me.BarSeries2.CoordinateSystem = Me.CartesianCoordinateSystem1
        Me.BarSeries2.DataPointLabel = "= Sum(Fields.MontoVendedor)"
        Me.BarSeries2.DataPointLabelStyle.Visible = False
        Me.BarSeries2.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries2.DataPointStyle.Visible = True
        Me.BarSeries2.LegendItem.Value = "'Sum(MontoVendedor)'"
        Me.BarSeries2.Name = "BarSeries2"
        Me.BarSeries2.SeriesGroup = GraphGroup2
        Me.BarSeries2.Y = "= Sum(Fields.MontoVendedor)"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageInfoTextBox, Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1002216339111328R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.104170560836792R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Calibri"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.5557155609130859R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD / {Now()}"
        '
        'RO_PuestoBolsa
        '
        Me.DocumentName = "PB"
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "RO_PuestoBolsa"
        Me.PageSettings.Landscape = true
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "Fecha"
        ReportParameter1.Text = "Fecha Final"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.ValorTransadoTotal", Telerik.Reporting.SortDirection.Desc))
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(8.214808464050293R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents SP_RO_OperacionesPorPuestodeBolsa_MP As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents Graph1 As Telerik.Reporting.Graph
    Friend WithEvents CartesianCoordinateSystem1 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents GraphAxis2 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis1 As Telerik.Reporting.GraphAxis
    Friend WithEvents BarSeries1 As Telerik.Reporting.BarSeries
    Friend WithEvents BarSeries2 As Telerik.Reporting.BarSeries
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class