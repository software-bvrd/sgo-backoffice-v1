Partial Class BB_RentaFijaVolumenTransadoPuestoBolsaRanking

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BB_RentaFijaVolumenTransadoPuestoBolsaRanking))
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup5 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector1 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector2 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.groupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.groupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox82 = New Telerik.Reporting.TextBox()
        Me.TextBox84 = New Telerik.Reporting.TextBox()
        Me.TextBox85 = New Telerik.Reporting.TextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro = New Telerik.Reporting.SqlDataSource()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox2
        '
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0014337301254273R), Telerik.Reporting.Drawing.Unit.Inch(0.35972112417221069R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox2.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox2.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox2.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.StyleName = "Normal.TableHeader"
        Me.TextBox2.Value = "Ranking"
        '
        'TextBox4
        '
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0852100849151611R), Telerik.Reporting.Drawing.Unit.Inch(0.35972109436988831R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox4.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox4.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox4.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Style.Font.Name = "Calibri"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.StyleName = "Normal.TableHeader"
        Me.TextBox4.Value = "Nombre"
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5895826816558838R), Telerik.Reporting.Drawing.Unit.Inch(0.35972112417221069R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox5.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox5.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox5.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Style.Font.Name = "Calibri"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.StyleName = "Normal.TableHeader"
        Me.TextBox5.Value = "Equivalente DOP"
        '
        'groupFooterSection
        '
        Me.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.50714236497879028R)
        Me.groupFooterSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox31})
        Me.groupFooterSection.Name = "groupFooterSection"
        '
        'TextBox31
        '
        Me.TextBox31.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0082491235807538033R), Telerik.Reporting.Drawing.Unit.Inch(0.13222472369670868R))
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(10.211641311645508R), Telerik.Reporting.Drawing.Unit.Inch(0.3749176561832428R))
        Me.TextBox31.Style.Font.Name = "Calibri"
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox31.Value = resources.GetString("TextBox31.Value")
        '
        'groupHeaderSection
        '
        Me.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.groupHeaderSection.Name = "groupHeaderSection"
        Me.groupHeaderSection.Style.Visible = False
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3779526948928833R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox9, Me.TextBox1, Me.TextBox14, Me.PictureBox2})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.020952774211764336R), Telerik.Reporting.Drawing.Unit.Cm(1.523900032043457R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.937568664550781R), Telerik.Reporting.Drawing.Unit.Cm(0.62960851192474365R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox9.Style.Color = System.Drawing.Color.White
        Me.TextBox9.Style.Font.Bold = True
        Me.TextBox9.Style.Font.Name = "Calibri"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.Value = "Renta Fija Mercado Secundario"
        '
        'TextBox1
        '
        Me.TextBox1.DocumentMapText = ""
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.020952774211764336R), Telerik.Reporting.Drawing.Unit.Cm(2.1537089347839355R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.937568664550781R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox1.Style.Color = System.Drawing.Color.White
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Value = "Ranking Metodologia BVRD Volumen Transado por Participante | Creadores de Mercado" &
    " Ministerio Hacienda"
        '
        'TextBox14
        '
        Me.TextBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0082492828369140625R), Telerik.Reporting.Drawing.Unit.Inch(1.047995924949646R))
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.937568664550781R), Telerik.Reporting.Drawing.Unit.Inch(0.19999966025352478R))
        Me.TextBox14.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.Color = System.Drawing.Color.White
        Me.TextBox14.Style.Font.Bold = True
        Me.TextBox14.Style.Font.Name = "Calibri"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.StyleName = "Normal.TableHeader"
        Me.TextBox14.Value = "Acumulado en {ConvertirFechas.FormatdateAsMonthName(Parameters.FechaOperacion.Val" &
    "ue)} de {ConvertirFechas.FormatdateYear(Parameters.FechaOperacion.Value)}"
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6377954483032227R), Telerik.Reporting.Drawing.Unit.Inch(0.59988194704055786R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.787401556968689R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table1})
        Me.detail.KeepTogether = False
        Me.detail.Name = "detail"
        Me.detail.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(6.0R)
        Me.detail.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.detail.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.0014337301254273R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(3.085209846496582R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.5895826816558838R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.50799953937530518R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.50799953937530518R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox10)
        Me.Table1.Body.SetCellContent(1, 0, Me.TextBox82)
        Me.Table1.Body.SetCellContent(1, 1, Me.TextBox84)
        Me.Table1.Body.SetCellContent(1, 2, Me.TextBox85)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox3)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox6)
        TableGroup1.Name = "Group1"
        TableGroup1.ReportItem = Me.TextBox2
        TableGroup2.Name = "Group3"
        TableGroup2.ReportItem = Me.TextBox4
        TableGroup3.Name = "Group4"
        TableGroup3.ReportItem = Me.TextBox5
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup2)
        Me.Table1.ColumnGroups.Add(TableGroup3)
        Me.Table1.DataSource = Me.SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox10, Me.TextBox82, Me.TextBox84, Me.TextBox85, Me.TextBox2, Me.TextBox4, Me.TextBox5, Me.TextBox3, Me.TextBox6})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0082491235807538033R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.Table1.Name = "Table1"
        TableGroup4.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup4.Name = "Detail"
        TableGroup5.Name = "group"
        Me.Table1.RowGroups.Add(TableGroup4)
        Me.Table1.RowGroups.Add(TableGroup5)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.6762266159057617R), Telerik.Reporting.Drawing.Unit.Cm(1.9296907186508179R))
        Me.Table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.Table1.StyleName = "Normal.TableNormal"
        '
        'TextBox10
        '
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0014337301254273R), Telerik.Reporting.Drawing.Unit.Cm(0.50800013542175293R))
        Me.TextBox10.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox10.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox10.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox10.Style.Font.Name = "Calibri"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.StyleName = "Normal.TableBody"
        Me.TextBox10.Value = "= Fields.Rank"
        '
        'TextBox82
        '
        Me.TextBox82.Name = "TextBox82"
        Me.TextBox82.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0014337301254273R), Telerik.Reporting.Drawing.Unit.Cm(0.50800013542175293R))
        Me.TextBox82.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox82.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox82.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox82.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox82.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox82.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox82.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox82.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox82.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox82.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox82.Style.Font.Bold = True
        Me.TextBox82.Style.Font.Name = "Calibri"
        Me.TextBox82.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox82.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox82.StyleName = "Normal.TableBody"
        '
        'TextBox84
        '
        Me.TextBox84.Format = "{0:N2}"
        Me.TextBox84.Name = "TextBox84"
        Me.TextBox84.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0852100849151611R), Telerik.Reporting.Drawing.Unit.Cm(0.5079999566078186R))
        Me.TextBox84.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox84.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox84.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox84.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox84.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox84.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox84.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox84.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox84.Style.Font.Bold = True
        Me.TextBox84.Style.Font.Name = "Calibri"
        Me.TextBox84.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox84.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox84.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox84.StyleName = "Normal.TableBody"
        '
        'TextBox85
        '
        Me.TextBox85.Format = "{0:N2}"
        Me.TextBox85.Name = "TextBox85"
        Me.TextBox85.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5895826816558838R), Telerik.Reporting.Drawing.Unit.Cm(0.50799953937530518R))
        Me.TextBox85.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox85.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox85.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox85.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox85.Style.Font.Bold = True
        Me.TextBox85.Style.Font.Name = "Calibri"
        Me.TextBox85.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox85.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox85.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox85.StyleName = "Normal.TableBody"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.19999949634075165R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81, Me.pageInfoTextBox})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.4023909568786621R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD / {Now()}"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9711418151855469R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.2487483024597168R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Calibri"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        Me.ReportHeaderSection1.Style.Visible = False
        '
        'SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro
        '
        Me.SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro.ConnectionString = "CN"
        Me.SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro.Name = "SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro"
        Me.SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@pFecha", System.Data.DbType.[Date], "= Parameters.FechaOperacion.Value")})
        Me.SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro.SelectCommand = "dbo.SP_BB_RentaFijaVolumenTransadoPuestoBolsaRankingMM"
        Me.SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'TextBox3
        '
        Me.TextBox3.Format = "{0:C2}"
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5895826816558838R), Telerik.Reporting.Drawing.Unit.Cm(0.50799953937530518R))
        Me.TextBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox3.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox3.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox3.Style.Font.Name = "Calibri"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.StyleName = "Normal.TableBody"
        Me.TextBox3.Value = "= Fields.ValorTransadoEquivalentePesos"
        '
        'TextBox6
        '
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0852100849151611R), Telerik.Reporting.Drawing.Unit.Cm(0.5079999566078186R))
        Me.TextBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.TextBox6.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.Font.Name = "Calibri"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.StyleName = "Normal.TableBody"
        Me.TextBox6.Value = "= Fields.Nombre"
        '
        'BB_RentaFijaVolumenTransadoPuestoBolsaRanking
        '
        Me.BookmarkId = "BB_RentaFijaVolumenTransadoPuestoBolsaRanking"
        Me.DocumentMapText = "Ranking BVRD Volumen Transado por Participante | CM del MH"
        Group1.GroupFooter = Me.groupFooterSection
        Group1.GroupHeader = Me.groupHeaderSection
        Group1.Name = "GrupoNotas"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.groupHeaderSection, Me.groupFooterSection, Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "BB_RentaFijaVolumenTransadoPuestoBolsaRanking"
        Me.PageSettings.Landscape = True
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaOperacion"
        ReportParameter1.Text = "Fecha"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = True
        ReportParameter2.Name = "UltimoDiaMes"
        ReportParameter2.Text = "Ultimo Dia de Mes"
        ReportParameter2.Type = Telerik.Reporting.ReportParameterType.[Boolean]
        ReportParameter2.Value = "=False"
        ReportParameter2.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.Table), "Normal.TableNormal")})
        StyleRule2.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        StyleRule2.Style.Color = System.Drawing.Color.Black
        StyleRule2.Style.Font.Name = "Tahoma"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        DescendantSelector1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableHeader")})
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector1})
        StyleRule3.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        StyleRule3.Style.Font.Name = "Tahoma"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        DescendantSelector2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableBody")})
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector2})
        StyleRule4.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        StyleRule4.Style.Font.Name = "Tahoma"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(10.219891548156738R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox82 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox84 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox85 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents groupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents groupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents SqlSP_BB_RentaFijaVolumenTransadoPuestoBolsaRegistro As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
End Class