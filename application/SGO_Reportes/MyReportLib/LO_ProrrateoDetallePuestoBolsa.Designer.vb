Partial Class LO_ProrrateoDetallePuestoBolsa
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
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
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LO_ProrrateoDetallePuestoBolsa))
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter4 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter5 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.groupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.TextBox44 = New Telerik.Reporting.TextBox()
        Me.TextBox45 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox49 = New Telerik.Reporting.TextBox()
        Me.TextBox50 = New Telerik.Reporting.TextBox()
        Me.TextBox51 = New Telerik.Reporting.TextBox()
        Me.TextBox52 = New Telerik.Reporting.TextBox()
        Me.TextBox53 = New Telerik.Reporting.TextBox()
        Me.TextBox54 = New Telerik.Reporting.TextBox()
        Me.TextBox55 = New Telerik.Reporting.TextBox()
        Me.groupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.TextBox28 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.TextBox33 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.SqlEmisor = New Telerik.Reporting.SqlDataSource()
        Me.SqlEmision = New Telerik.Reporting.SqlDataSource()
        Me.SqlPuestoBolsa = New Telerik.Reporting.SqlDataSource()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox34 = New Telerik.Reporting.TextBox()
        Me.TextBox35 = New Telerik.Reporting.TextBox()
        Me.TextBox36 = New Telerik.Reporting.TextBox()
        Me.TextBox37 = New Telerik.Reporting.TextBox()
        Me.TextBox38 = New Telerik.Reporting.TextBox()
        Me.TextBox39 = New Telerik.Reporting.TextBox()
        Me.TextBox40 = New Telerik.Reporting.TextBox()
        Me.TextBox41 = New Telerik.Reporting.TextBox()
        Me.TextBox42 = New Telerik.Reporting.TextBox()
        Me.TextBox43 = New Telerik.Reporting.TextBox()
        Me.SqlLO_ProrrateoDetallePuestoDeBolsa = New Telerik.Reporting.SqlDataSource()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox46 = New Telerik.Reporting.TextBox()
        Me.TextBox23 = New Telerik.Reporting.TextBox()
        Me.TextBox47 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'groupFooterSection
        '
        Me.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20007883012294769R)
        Me.groupFooterSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox44, Me.TextBox45, Me.TextBox12, Me.TextBox49, Me.TextBox50, Me.TextBox51, Me.TextBox52, Me.TextBox53, Me.TextBox54, Me.TextBox55})
        Me.groupFooterSection.Name = "groupFooterSection"
        Me.groupFooterSection.PageBreak = Telerik.Reporting.PageBreak.After
        '
        'TextBox44
        '
        Me.TextBox44.Format = "{0}"
        Me.TextBox44.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1254396438598633R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox44.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox44.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox44.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox44.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox44.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox44.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox44.Style.Font.Bold = True
        Me.TextBox44.Style.Font.Name = "Calibri"
        Me.TextBox44.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox44.StyleName = "Normal.TableBody"
        Me.TextBox44.Value = "Total "
        '
        'TextBox45
        '
        Me.TextBox45.Format = "{0:N2}"
        Me.TextBox45.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9423134326934814R), Telerik.Reporting.Drawing.Unit.Inch(0.000078837074397597462R))
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1879204511642456R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox45.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox45.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox45.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox45.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox45.Style.Font.Bold = True
        Me.TextBox45.Style.Font.Name = "Calibri"
        Me.TextBox45.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox45.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox45.StyleName = "Normal.TableBody"
        Me.TextBox45.Value = "=Sum(Fields.MontoDemandado)"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1298775672912598R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97695112228393555R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox12.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox12.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox12.Style.Font.Bold = True
        Me.TextBox12.Style.Font.Name = "Calibri"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.StyleName = "Normal.TableBody"
        '
        'TextBox49
        '
        Me.TextBox49.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1085729598999023R), Telerik.Reporting.Drawing.Unit.Inch(0.000078837074397597462R))
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.83416599035263062R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox49.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox49.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox49.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox49.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox49.Style.Font.Bold = True
        Me.TextBox49.Style.Font.Name = "Calibri"
        Me.TextBox49.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox49.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox49.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox49.StyleName = "Normal.TableBody"
        '
        'TextBox50
        '
        Me.TextBox50.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9427387714385986R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox50.Name = "TextBox50"
        Me.TextBox50.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99949586391448975R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox50.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox50.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox50.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox50.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox50.Style.Font.Bold = True
        Me.TextBox50.Style.Font.Name = "Calibri"
        Me.TextBox50.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox50.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox50.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox50.StyleName = "Normal.TableBody"
        '
        'TextBox51
        '
        Me.TextBox51.Format = "{0:N2}"
        Me.TextBox51.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1370787620544434R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox51.Name = "TextBox51"
        Me.TextBox51.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1224911212921143R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox51.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox51.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox51.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox51.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox51.Style.Font.Bold = True
        Me.TextBox51.Style.Font.Name = "Calibri"
        Me.TextBox51.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox51.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox51.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox51.StyleName = "Normal.TableBody"
        Me.TextBox51.Value = "=Sum(Fields.Cant_Tit)"
        '
        'TextBox52
        '
        Me.TextBox52.Format = "{0:N2}"
        Me.TextBox52.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.2621922492980957R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox52.Name = "TextBox52"
        Me.TextBox52.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2534564733505249R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox52.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox52.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox52.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox52.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox52.Style.Font.Bold = True
        Me.TextBox52.Style.Font.Name = "Calibri"
        Me.TextBox52.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox52.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox52.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox52.StyleName = "Normal.TableBody"
        Me.TextBox52.Value = "=Sum(Fields.MontoAdjudicadoFinal)"
        '
        'TextBox53
        '
        Me.TextBox53.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.515648365020752R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox53.Name = "TextBox53"
        Me.TextBox53.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.635416567325592R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox53.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox53.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox53.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox53.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox53.Style.Font.Bold = True
        Me.TextBox53.Style.Font.Name = "Calibri"
        Me.TextBox53.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox53.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox53.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox53.StyleName = "Normal.TableBody"
        '
        'TextBox54
        '
        Me.TextBox54.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1541814804077148R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox54.Name = "TextBox54"
        Me.TextBox54.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.85416632890701294R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox54.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox54.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox54.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox54.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox54.Style.Font.Bold = True
        Me.TextBox54.Style.Font.Name = "Calibri"
        Me.TextBox54.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox54.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox54.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox54.StyleName = "Normal.TableBody"
        '
        'TextBox55
        '
        Me.TextBox55.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0104169845581055R), Telerik.Reporting.Drawing.Unit.Inch(0.000078837074397597462R))
        Me.TextBox55.Name = "TextBox55"
        Me.TextBox55.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98958355188369751R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox55.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox55.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox55.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox55.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox55.Style.Font.Bold = True
        Me.TextBox55.Style.Font.Name = "Calibri"
        Me.TextBox55.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox55.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox55.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox55.StyleName = "Normal.TableBody"
        '
        'groupHeaderSection
        '
        Me.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.350078821182251R)
        Me.groupHeaderSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table1, Me.TextBox33, Me.TextBox3})
        Me.groupHeaderSection.KeepTogether = False
        Me.groupHeaderSection.Name = "groupHeaderSection"
        Me.groupHeaderSection.PrintOnEveryPage = True
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.1277940273284912R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.97899478673934937R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.8359103798866272R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.0015866756439209R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.190405011177063R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.1248390674591065R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.2560784816741943R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.636745810508728R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.8559530377388R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.99165374040603638R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox2)
        Me.Table1.Body.SetCellContent(0, 4, Me.TextBox26)
        Me.Table1.Body.SetCellContent(0, 5, Me.TextBox27)
        Me.Table1.Body.SetCellContent(0, 6, Me.TextBox28)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox11)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox14)
        Me.Table1.Body.SetCellContent(0, 3, Me.TextBox17)
        Me.Table1.Body.SetCellContent(0, 8, Me.TextBox20)
        Me.Table1.Body.SetCellContent(0, 9, Me.TextBox25)
        Me.Table1.Body.SetCellContent(0, 7, Me.TextBox31)
        TableGroup1.Name = "group7"
        TableGroup2.Name = "group8"
        TableGroup3.Name = "group9"
        TableGroup4.Name = "group10"
        TableGroup5.Name = "group11"
        TableGroup6.Name = "group12"
        TableGroup7.Name = "group13"
        TableGroup8.Name = "group14"
        TableGroup9.Name = "group15"
        TableGroup10.Name = "group16"
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup2)
        Me.Table1.ColumnGroups.Add(TableGroup3)
        Me.Table1.ColumnGroups.Add(TableGroup4)
        Me.Table1.ColumnGroups.Add(TableGroup5)
        Me.Table1.ColumnGroups.Add(TableGroup6)
        Me.Table1.ColumnGroups.Add(TableGroup7)
        Me.Table1.ColumnGroups.Add(TableGroup8)
        Me.Table1.ColumnGroups.Add(TableGroup9)
        Me.Table1.ColumnGroups.Add(TableGroup10)
        Me.Table1.ColumnHeadersPrintOnEveryPage = True
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.TextBox11, Me.TextBox14, Me.TextBox17, Me.TextBox26, Me.TextBox27, Me.TextBox28, Me.TextBox31, Me.TextBox20, Me.TextBox25})
        Me.Table1.KeepTogether = False
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0026620228309184313R), Telerik.Reporting.Drawing.Unit.Inch(0.15007884800434113R))
        Me.Table1.Name = "Table1"
        TableGroup11.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup11.Name = "Detail"
        Me.Table1.RowGroups.Add(TableGroup11)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(9.9999608993530273R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.Table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.Table1.StyleName = "Normal.TableNormal"
        '
        'TextBox2
        '
        Me.TextBox2.Format = "{0}"
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1277940273284912R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Normal.TableBody"
        Me.TextBox2.Value = "Puesto Bolsa"
        '
        'TextBox26
        '
        Me.TextBox26.Format = "{0}"
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.190405011177063R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox26.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox26.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox26.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox26.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox26.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox26.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox26.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox26.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox26.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox26.Style.Font.Bold = True
        Me.TextBox26.Style.Font.Name = "Calibri"
        Me.TextBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox26.StyleName = "Normal.TableBody"
        Me.TextBox26.Value = "Monto Demandado"
        '
        'TextBox27
        '
        Me.TextBox27.Format = "{0}"
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1248390674591065R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox27.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox27.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox27.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox27.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox27.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox27.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox27.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox27.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox27.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox27.Style.Font.Bold = True
        Me.TextBox27.Style.Font.Name = "Calibri"
        Me.TextBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox27.StyleName = "Normal.TableBody"
        Me.TextBox27.Value = "Cant. Titulos"
        '
        'TextBox28
        '
        Me.TextBox28.Format = "{0}"
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2560784816741943R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox28.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox28.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox28.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox28.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox28.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox28.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox28.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox28.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox28.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox28.Style.Font.Bold = True
        Me.TextBox28.Style.Font.Name = "Calibri"
        Me.TextBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox28.StyleName = "Normal.TableBody"
        Me.TextBox28.Value = "Demanda a Adjudicar"
        '
        'TextBox11
        '
        Me.TextBox11.Format = "{0}"
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97899484634399414R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox11.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox11.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox11.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox11.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox11.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox11.Style.Font.Bold = True
        Me.TextBox11.Style.Font.Name = "Calibri"
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox11.StyleName = "Normal.TableBody"
        Me.TextBox11.Value = "Monto Total Emisión"
        '
        'TextBox14
        '
        Me.TextBox14.Format = "{0}"
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8359103798866272R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox14.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.Font.Bold = True
        Me.TextBox14.Style.Font.Name = "Calibri"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.StyleName = "Normal.TableBody"
        Me.TextBox14.Value = "Nemotécnico"
        '
        'TextBox17
        '
        Me.TextBox17.Format = "{0}"
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0015866756439209R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox17.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.Font.Bold = True
        Me.TextBox17.Style.Font.Name = "Calibri"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.StyleName = "Normal.TableBody"
        Me.TextBox17.Value = "Fecha"
        '
        'TextBox20
        '
        Me.TextBox20.Format = "{0}"
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.8559530377388R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox20.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.Font.Bold = True
        Me.TextBox20.Style.Font.Name = "Calibri"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox20.StyleName = "Normal.TableBody"
        Me.TextBox20.Value = "RTN"
        '
        'TextBox25
        '
        Me.TextBox25.Format = "{0}"
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99165374040603638R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox25.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox25.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox25.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox25.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox25.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox25.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox25.Style.Font.Bold = True
        Me.TextBox25.Style.Font.Name = "Calibri"
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.StyleName = "Normal.TableBody"
        Me.TextBox25.Value = "NoRegistroLibro"
        '
        'TextBox31
        '
        Me.TextBox31.Format = "{0}"
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.636745810508728R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox31.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox31.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox31.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox31.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox31.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox31.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox31.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox31.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox31.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox31.Style.Font.Bold = True
        Me.TextBox31.Style.Font.Name = "Calibri"
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox31.StyleName = "Normal.TableBody"
        Me.TextBox31.Value = "Cant. Títulos"
        '
        'TextBox33
        '
        Me.TextBox33.Format = "{0:d}"
        Me.TextBox33.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1298775672912598R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0701227188110352R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox33.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox33.Style.Color = System.Drawing.Color.Black
        Me.TextBox33.Style.Font.Bold = False
        Me.TextBox33.Style.Font.Italic = False
        Me.TextBox33.Style.Font.Name = "Calibri"
        Me.TextBox33.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox33.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox33.Value = "= Fields.PuestoBolsaCodigo"
        '
        'TextBox3
        '
        Me.TextBox3.Format = "{0:d}"
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1278337240219116R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox3.Style.Color = System.Drawing.Color.Black
        Me.TextBox3.Style.Font.Bold = True
        Me.TextBox3.Style.Font.Italic = False
        Me.TextBox3.Style.Font.Name = "Calibri"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.Value = "Puesto de Bolsa:"
        '
        'SqlEmisor
        '
        Me.SqlEmisor.ConnectionString = "CN"
        Me.SqlEmisor.Name = "SqlEmisor"
        Me.SqlEmisor.SelectCommand = "SELECT [EmisorID], [NombreEmisor] FROM [Emisor] ORDER BY NombreEmisor"
        '
        'SqlEmision
        '
        Me.SqlEmision.ConnectionString = "CN"
        Me.SqlEmision.Name = "SqlEmision"
        Me.SqlEmision.SelectCommand = "SELECT        CodEmisionBVRD, EmisorID, Estatus, EmisionID" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            Emisi" &
    "on" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE        (Estatus = 'VI')"
        '
        'SqlPuestoBolsa
        '
        Me.SqlPuestoBolsa.ConnectionString = "CN"
        Me.SqlPuestoBolsa.Name = "SqlPuestoBolsa"
        Me.SqlPuestoBolsa.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@pCodEmisionBVRD", System.Data.DbType.AnsiString, "=Parameters.Emision.Value")})
        Me.SqlPuestoBolsa.SelectCommand = "dbo.SP_PuestoBolsaProrrogateo"
        Me.SqlPuestoBolsa.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003938674926758R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox34, Me.TextBox35, Me.TextBox36, Me.TextBox37, Me.TextBox38, Me.TextBox39, Me.TextBox40, Me.TextBox41, Me.TextBox42, Me.TextBox43})
        Me.detail.KeepTogether = False
        Me.detail.Name = "detail"
        '
        'TextBox34
        '
        Me.TextBox34.Format = "{0}"
        Me.TextBox34.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1254396438598633R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox34.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox34.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox34.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox34.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox34.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox34.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox34.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox34.Style.Font.Name = "Calibri"
        Me.TextBox34.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox34.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox34.StyleName = "Normal.TableBody"
        Me.TextBox34.Value = "= Fields.PuestoBolsaCodigo"
        '
        'TextBox35
        '
        Me.TextBox35.Format = "{0:N2}"
        Me.TextBox35.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1298774480819702R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97695112228393555R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox35.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox35.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox35.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox35.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox35.Style.Font.Name = "Calibri"
        Me.TextBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox35.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox35.StyleName = "Normal.TableBody"
        Me.TextBox35.Value = "=Fields.MontoTotalDeLaEmision"
        '
        'TextBox36
        '
        Me.TextBox36.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1085729598999023R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.83416599035263062R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox36.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox36.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox36.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox36.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox36.Style.Font.Name = "Calibri"
        Me.TextBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox36.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox36.StyleName = "Normal.TableBody"
        Me.TextBox36.Value = "=Fields.Nemotecnico"
        '
        'TextBox37
        '
        Me.TextBox37.Format = "{0:d}"
        Me.TextBox37.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.9427387714385986R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99949586391448975R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox37.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox37.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox37.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox37.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox37.Style.Font.Name = "Calibri"
        Me.TextBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox37.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox37.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox37.StyleName = "Normal.TableBody"
        Me.TextBox37.Value = "=Fields.Fecha"
        '
        'TextBox38
        '
        Me.TextBox38.Format = "{0:N2}"
        Me.TextBox38.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9423134326934814R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1879204511642456R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox38.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox38.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox38.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox38.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox38.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox38.Style.Font.Name = "Calibri"
        Me.TextBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox38.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox38.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox38.StyleName = "Normal.TableBody"
        Me.TextBox38.Value = "=Fields.MontoDemandado"
        '
        'TextBox39
        '
        Me.TextBox39.Format = "{0:N2}"
        Me.TextBox39.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.130312442779541R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1224911212921143R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox39.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox39.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox39.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox39.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox39.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox39.Style.Font.Name = "Calibri"
        Me.TextBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox39.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox39.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox39.StyleName = "Normal.TableBody"
        Me.TextBox39.Value = "=Fields.Cant_Tit"
        '
        'TextBox40
        '
        Me.TextBox40.Format = "{0:N2}"
        Me.TextBox40.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.2528824806213379R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.2534564733505249R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox40.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox40.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox40.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox40.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox40.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox40.Style.Font.Name = "Calibri"
        Me.TextBox40.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox40.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox40.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox40.StyleName = "Normal.TableBody"
        Me.TextBox40.Value = "= Fields.MontoAdjudicadoFinal"
        '
        'TextBox41
        '
        Me.TextBox41.Format = "{0:N0}"
        Me.TextBox41.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.5169777870178223R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.635416567325592R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox41.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox41.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox41.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox41.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox41.Style.Font.Name = "Calibri"
        Me.TextBox41.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox41.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox41.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox41.StyleName = "Normal.TableBody"
        Me.TextBox41.Value = "=Fields.MontoAdjudicadoFinal/1"
        '
        'TextBox42
        '
        Me.TextBox42.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1523923873901367R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.85416632890701294R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox42.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox42.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox42.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox42.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox42.Style.Font.Name = "Calibri"
        Me.TextBox42.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox42.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox42.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox42.StyleName = "Normal.TableBody"
        Me.TextBox42.Value = "=Fields.RTN"
        '
        'TextBox43
        '
        Me.TextBox43.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0104169845581055R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.98958355188369751R), Telerik.Reporting.Drawing.Unit.Inch(0.19999995827674866R))
        Me.TextBox43.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox43.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox43.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox43.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox43.Style.Font.Name = "Calibri"
        Me.TextBox43.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox43.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox43.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox43.StyleName = "Normal.TableBody"
        Me.TextBox43.Value = "=Fields.NoRegistroLibro"
        '
        'SqlLO_ProrrateoDetallePuestoDeBolsa
        '
        Me.SqlLO_ProrrateoDetallePuestoDeBolsa.ConnectionString = "CN"
        Me.SqlLO_ProrrateoDetallePuestoDeBolsa.Name = "SqlLO_ProrrateoDetallePuestoDeBolsa"
        Me.SqlLO_ProrrateoDetallePuestoDeBolsa.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@pFechaInicio", System.Data.DbType.[Date], "=Parameters.FechaInicio.Value"), New Telerik.Reporting.SqlDataSourceParameter("@pFechaFinal", System.Data.DbType.[Date], "=Parameters.FechaFinal.Value"), New Telerik.Reporting.SqlDataSourceParameter("@pEmision", System.Data.DbType.AnsiString, "=Parameters.Emision.Value"), New Telerik.Reporting.SqlDataSourceParameter("@pPuestoBolsa", System.Data.DbType.AnsiString, "=Parameters.PuestoBolsa.Value")})
        Me.SqlLO_ProrrateoDetallePuestoDeBolsa.SelectCommand = "dbo.SP_LO_ProrrateoDetallePuestoBolsa"
        Me.SqlLO_ProrrateoDetallePuestoDeBolsa.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003943145275116R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81, Me.pageInfoTextBox})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.9365968704223633R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "BVRD / {Now()}"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1523923873901367R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8476076126098633R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Calibri"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.64811378717422485R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox24, Me.TextBox1, Me.TextBox46, Me.TextBox23, Me.TextBox47, Me.PictureBox2})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'TextBox24
        '
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.7000002861022949R), Telerik.Reporting.Drawing.Unit.Inch(0.19992129504680634R))
        Me.TextBox24.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox24.Style.Color = System.Drawing.Color.Black
        Me.TextBox24.Style.Font.Bold = True
        Me.TextBox24.Style.Font.Name = "Calibri"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.StyleName = "Title"
        Me.TextBox24.Value = "Bolsa y Mercados de Valores de la República Dominicana, S. A." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox1
        '
        Me.TextBox1.Format = "{0:d}"
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.49811387062072754R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1278337240219116R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Italic = False
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.Value = "Código Emisión: "
        '
        'TextBox46
        '
        Me.TextBox46.Format = "{0:d}"
        Me.TextBox46.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.34803494811058044R))
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox46.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox46.Style.Color = System.Drawing.Color.Black
        Me.TextBox46.Style.Font.Bold = False
        Me.TextBox46.Style.Font.Italic = False
        Me.TextBox46.Style.Font.Name = "Calibri"
        Me.TextBox46.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox46.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox46.Value = "Desde {ConvertirFechas.Formatdate(Parameters.FechaInicio.Value)} hasta {Convertir" &
    "Fechas.Formatdate(Parameters.FechaFinal.Value)}"
        '
        'TextBox23
        '
        Me.TextBox23.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.20003938674926758R))
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.3479170799255371R), Telerik.Reporting.Drawing.Unit.Inch(0.14791679382324219R))
        Me.TextBox23.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox23.Style.Color = System.Drawing.Color.Black
        Me.TextBox23.Style.Font.Bold = True
        Me.TextBox23.Style.Font.Italic = True
        Me.TextBox23.Style.Font.Name = "Calibri"
        Me.TextBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox23.StyleName = "Title"
        Me.TextBox23.Value = "Prorrateo Detalle por Puesto de Bolsa"
        '
        'TextBox47
        '
        Me.TextBox47.Format = "{0:d}"
        Me.TextBox47.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1278337240219116R), Telerik.Reporting.Drawing.Unit.Inch(0.4981137216091156R))
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0721664428710938R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox47.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox47.Style.Color = System.Drawing.Color.Black
        Me.TextBox47.Style.Font.Bold = False
        Me.TextBox47.Style.Font.Italic = False
        Me.TextBox47.Style.Font.Name = "Calibri"
        Me.TextBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox47.Value = "=Parameters.Emision.Value"
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6256141662597656R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
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
        'LO_ProrrateoDetallePuestoBolsa
        '
        Me.DataSource = Me.SqlLO_ProrrateoDetallePuestoDeBolsa
        Group1.GroupFooter = Me.groupFooterSection
        Group1.GroupHeader = Me.groupHeaderSection
        Group1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.PuestoBolsaCodigo"))
        Group1.Name = "group6"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.groupHeaderSection, Me.groupFooterSection, Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "LO_ProrrateoDetallePuestoBolsa"
        Me.PageSettings.Landscape = True
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.AvailableValues.DataSource = Me.SqlEmisor
        ReportParameter1.AvailableValues.DisplayMember = "= Fields.NombreEmisor"
        ReportParameter1.AvailableValues.ValueMember = "= Fields.EmisorID"
        ReportParameter1.Name = "Emisor"
        ReportParameter1.Text = "Emisor"
        ReportParameter1.Visible = True
        ReportParameter2.AvailableValues.DataSource = Me.SqlEmision
        ReportParameter2.AvailableValues.DisplayMember = "= Fields.CodEmisionBVRD"
        ReportParameter2.AvailableValues.Filters.Add(New Telerik.Reporting.Filter("=Fields.EmisorID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.Emisor.Value"))
        ReportParameter2.AvailableValues.ValueMember = "= Fields.CodEmisionBVRD"
        ReportParameter2.Name = "Emision"
        ReportParameter2.Text = "Emisión"
        ReportParameter2.Visible = True
        ReportParameter3.Name = "FechaInicio"
        ReportParameter3.Text = "Fecha Inicio"
        ReportParameter3.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter3.Value = "=Today()"
        ReportParameter3.Visible = True
        ReportParameter4.Name = "FechaFinal"
        ReportParameter4.Text = "Fecha Final"
        ReportParameter4.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter4.Value = "=Today()"
        ReportParameter4.Visible = True
        ReportParameter5.AvailableValues.DataSource = Me.SqlPuestoBolsa
        ReportParameter5.AvailableValues.DisplayMember = "= Fields.NombrePuestoBolsa"
        ReportParameter5.AvailableValues.ValueMember = "= Fields.PuestoBolsaCodigo"
        ReportParameter5.Name = "PuestoBolsa"
        ReportParameter5.Text = "Puesto de Bolsa"
        ReportParameter5.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.ReportParameters.Add(ReportParameter3)
        Me.ReportParameters.Add(ReportParameter4)
        Me.ReportParameters.Add(ReportParameter5)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(10.0R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents SqlEmisor As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlEmision As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlPuestoBolsa As Telerik.Reporting.SqlDataSource
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox23 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox46 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox47 As Telerik.Reporting.TextBox
    Friend WithEvents SqlLO_ProrrateoDetallePuestoDeBolsa As Telerik.Reporting.SqlDataSource
    Friend WithEvents groupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents groupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents TextBox34 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox35 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox36 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox37 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox38 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox39 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox40 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox41 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox42 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox43 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox44 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox45 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox49 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox50 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox51 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox52 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox53 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox54 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox55 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox28 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox33 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class