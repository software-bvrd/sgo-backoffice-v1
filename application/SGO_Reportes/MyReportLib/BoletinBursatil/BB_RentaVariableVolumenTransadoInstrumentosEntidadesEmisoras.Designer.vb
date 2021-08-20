Partial Class BB_RVVolTransInsEEmisoras

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BB_RVVolTransInsEEmisoras))
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
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector1 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector2 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.SqlBoletinConfiguracion = New Telerik.Reporting.SqlDataSource()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox38 = New Telerik.Reporting.TextBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox82 = New Telerik.Reporting.TextBox()
        Me.TextBox84 = New Telerik.Reporting.TextBox()
        Me.TextBox85 = New Telerik.Reporting.TextBox()
        Me.TextBox87 = New Telerik.Reporting.TextBox()
        Me.TextBox88 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras = New Telerik.Reporting.SqlDataSource()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox2
        '
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3295581340789795R), Telerik.Reporting.Drawing.Unit.Inch(0.31805449724197388R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox2.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox2.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.StyleName = "Normal.TableHeader"
        Me.TextBox2.Value = "Entidad Emisora"
        '
        'TextBox17
        '
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3295581340789795R), Telerik.Reporting.Drawing.Unit.Inch(0.19999951124191284R))
        Me.TextBox17.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox17.Style.Color = System.Drawing.Color.Black
        Me.TextBox17.Style.Font.Bold = True
        Me.TextBox17.Style.Font.Name = "Calibri"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox17.StyleName = "Normal.TableHeader"
        '
        'TextBox4
        '
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4854164123535156R), Telerik.Reporting.Drawing.Unit.Inch(0.31805461645126343R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox4.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox4.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Style.Font.Name = "Calibri"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.StyleName = "Normal.TableHeader"
        Me.TextBox4.Value = "Transado USD"
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5479164123535156R), Telerik.Reporting.Drawing.Unit.Inch(0.31805461645126343R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox5.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox5.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Style.Font.Name = "Calibri"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.StyleName = "Normal.TableHeader"
        Me.TextBox5.Value = "USD Equivalente DOP"
        '
        'TextBox7
        '
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5375003814697266R), Telerik.Reporting.Drawing.Unit.Inch(0.31805461645126343R))
        Me.TextBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox7.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox7.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox7.Style.Font.Bold = True
        Me.TextBox7.Style.Font.Name = "Calibri"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.StyleName = "Normal.TableHeader"
        Me.TextBox7.Value = "Transado DOP"
        '
        'TextBox21
        '
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5708317756652832R), Telerik.Reporting.Drawing.Unit.Inch(0.19999960064888R))
        Me.TextBox21.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox21.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox21.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox21.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox21.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox21.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox21.Style.Color = System.Drawing.Color.Black
        Me.TextBox21.Style.Font.Bold = True
        Me.TextBox21.Style.Font.Name = "Calibri"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox21.StyleName = "Normal.TableHeader"
        Me.TextBox21.Value = resources.GetString("TextBox21.Value")
        '
        'TextBox8
        '
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6104170083999634R), Telerik.Reporting.Drawing.Unit.Inch(0.31805461645126343R))
        Me.TextBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox8.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox8.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox8.Style.Font.Bold = True
        Me.TextBox8.Style.Font.Name = "Calibri"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.StyleName = "Normal.TableHeader"
        Me.TextBox8.Value = "Acum Mes DOP"
        '
        'TextBox14
        '
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.475000262260437R), Telerik.Reporting.Drawing.Unit.Inch(0.31805461645126343R))
        Me.TextBox14.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox14.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox14.Style.Font.Bold = True
        Me.TextBox14.Style.Font.Name = "Calibri"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.StyleName = "Normal.TableHeader"
        Me.TextBox14.Value = "Acum Año DOP"
        '
        'TextBox20
        '
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0854177474975586R), Telerik.Reporting.Drawing.Unit.Inch(0.19999960064888R))
        Me.TextBox20.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.Font.Bold = True
        Me.TextBox20.Style.Font.Name = "Calibri"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox20.StyleName = "Normal.TableHeader"
        Me.TextBox20.Value = "Total Acumulado"
        '
        'SqlBoletinConfiguracion
        '
        Me.SqlBoletinConfiguracion.ConnectionString = "CN"
        Me.SqlBoletinConfiguracion.Name = "SqlBoletinConfiguracion"
        Me.SqlBoletinConfiguracion.SelectCommand = "SELECT BoletinConfiguracionID, Descripcion, PrecioEnListaDePrecios, TopTitulosMas" &
    "Transados, FechaCreacion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            vBoletinConfiguracion"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.4173229932785034R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox9, Me.TextBox1, Me.TextBox38, Me.PictureBox2})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.020952774211764336R), Telerik.Reporting.Drawing.Unit.Cm(1.523900032043457R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.378946304321289R), Telerik.Reporting.Drawing.Unit.Cm(0.62960851192474365R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox9.Style.Color = System.Drawing.Color.White
        Me.TextBox9.Style.Font.Bold = True
        Me.TextBox9.Style.Font.Name = "Calibri"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.Value = "Renta Variable Mercado Primario"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.020952774211764336R), Telerik.Reporting.Drawing.Unit.Cm(2.1537084579467773R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.378946304321289R), Telerik.Reporting.Drawing.Unit.Cm(0.54609119892120361R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox1.Style.Color = System.Drawing.Color.White
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Value = "Volumen Transado Instrumentos de Entidades Emisoras"
        '
        'TextBox38
        '
        Me.TextBox38.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0082491235807538033R), Telerik.Reporting.Drawing.Unit.Inch(1.0629920959472656R))
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(25.378946304321289R), Telerik.Reporting.Drawing.Unit.Inch(0.19999928772449493R))
        Me.TextBox38.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(54, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox38.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox38.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox38.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox38.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox38.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox38.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox38.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox38.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox38.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox38.Style.Color = System.Drawing.Color.White
        Me.TextBox38.Style.Font.Bold = True
        Me.TextBox38.Style.Font.Name = "Calibri"
        Me.TextBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox38.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox38.StyleName = "Normal.TableHeader"
        Me.TextBox38.Value = resources.GetString("TextBox38.Value")
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3188973665237427R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table1, Me.TextBox31})
        Me.detail.KeepTogether = False
        Me.detail.Name = "detail"
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.3295581340789795R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4854158163070679R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.5479152202606201R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.537500262260437R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.6104171276092529R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4750001430511475R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.50800025463104248R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.50800025463104248R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox10)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox12)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox13)
        Me.Table1.Body.SetCellContent(0, 3, Me.TextBox15)
        Me.Table1.Body.SetCellContent(0, 4, Me.TextBox16)
        Me.Table1.Body.SetCellContent(1, 0, Me.TextBox82)
        Me.Table1.Body.SetCellContent(1, 1, Me.TextBox84)
        Me.Table1.Body.SetCellContent(1, 2, Me.TextBox85)
        Me.Table1.Body.SetCellContent(1, 3, Me.TextBox87)
        Me.Table1.Body.SetCellContent(1, 4, Me.TextBox88)
        Me.Table1.Body.SetCellContent(0, 5, Me.TextBox18)
        Me.Table1.Body.SetCellContent(1, 5, Me.TextBox19)
        TableGroup2.Name = "Group1"
        TableGroup2.ReportItem = Me.TextBox2
        TableGroup1.ChildGroups.Add(TableGroup2)
        TableGroup1.ReportItem = Me.TextBox17
        TableGroup4.Name = "Group3"
        TableGroup4.ReportItem = Me.TextBox4
        TableGroup5.Name = "Group4"
        TableGroup5.ReportItem = Me.TextBox5
        TableGroup6.Name = "Group6"
        TableGroup6.ReportItem = Me.TextBox7
        TableGroup3.ChildGroups.Add(TableGroup4)
        TableGroup3.ChildGroups.Add(TableGroup5)
        TableGroup3.ChildGroups.Add(TableGroup6)
        TableGroup3.Name = "group1"
        TableGroup3.ReportItem = Me.TextBox21
        TableGroup8.Name = "Group7"
        TableGroup8.ReportItem = Me.TextBox8
        TableGroup9.Name = "group4"
        TableGroup9.ReportItem = Me.TextBox14
        TableGroup7.ChildGroups.Add(TableGroup8)
        TableGroup7.ChildGroups.Add(TableGroup9)
        TableGroup7.Name = "group5"
        TableGroup7.ReportItem = Me.TextBox20
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup3)
        Me.Table1.ColumnGroups.Add(TableGroup7)
        Me.Table1.DataSource = Me.SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox10, Me.TextBox12, Me.TextBox13, Me.TextBox15, Me.TextBox16, Me.TextBox18, Me.TextBox82, Me.TextBox84, Me.TextBox85, Me.TextBox87, Me.TextBox88, Me.TextBox19, Me.TextBox17, Me.TextBox2, Me.TextBox21, Me.TextBox4, Me.TextBox5, Me.TextBox7, Me.TextBox20, Me.TextBox8, Me.TextBox14})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0082491235807538033R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.Table1.Name = "Table1"
        TableGroup10.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup10.Name = "Detail"
        TableGroup11.Name = "group"
        Me.Table1.RowGroups.Add(TableGroup10)
        Me.Table1.RowGroups.Add(TableGroup11)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(9.9858064651489258R), Telerik.Reporting.Drawing.Unit.Cm(2.3318576812744141R))
        Me.Table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.Table1.StyleName = "Normal.TableNormal"
        '
        'TextBox10
        '
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3295581340789795R), Telerik.Reporting.Drawing.Unit.Cm(0.50800019502639771R))
        Me.TextBox10.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox10.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox10.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox10.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox10.Style.Font.Name = "Calibri"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.StyleName = "Normal.TableBody"
        Me.TextBox10.Value = "= Fields.nemo_emisor"
        '
        'TextBox12
        '
        Me.TextBox12.Format = "{0:N2}"
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4854164123535156R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox12.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox12.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox12.Style.Font.Name = "Calibri"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.StyleName = "Normal.TableBody"
        Me.TextBox12.Value = "= Fields.TransadoDolar"
        '
        'TextBox13
        '
        Me.TextBox13.Format = "{0:N2}"
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5479164123535156R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox13.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox13.Style.Font.Name = "Calibri"
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox13.StyleName = "Normal.TableBody"
        Me.TextBox13.Value = "= Fields.TransadoDolarEquivalentePesos"
        '
        'TextBox15
        '
        Me.TextBox15.Format = "{0:N2}"
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5375003814697266R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox15.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox15.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox15.Style.Font.Name = "Calibri"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.StyleName = "Normal.TableBody"
        Me.TextBox15.Value = "= Fields.TransadoPesos"
        '
        'TextBox16
        '
        Me.TextBox16.Format = "{0:N2}"
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6104170083999634R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox16.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox16.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox16.Style.Font.Name = "Calibri"
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox16.StyleName = "Normal.TableBody"
        Me.TextBox16.Value = "= Fields.AcumuladoMesPesos"
        '
        'TextBox82
        '
        Me.TextBox82.Name = "TextBox82"
        Me.TextBox82.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3295581340789795R), Telerik.Reporting.Drawing.Unit.Cm(0.50800019502639771R))
        Me.TextBox82.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox82.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox82.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
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
        Me.TextBox82.Value = "Total "
        '
        'TextBox84
        '
        Me.TextBox84.Format = "{0:N2}"
        Me.TextBox84.Name = "TextBox84"
        Me.TextBox84.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4854164123535156R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox84.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox84.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox84.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
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
        Me.TextBox84.Value = "=Sum(Fields.TransadoDolar)"
        '
        'TextBox85
        '
        Me.TextBox85.Format = "{0:N2}"
        Me.TextBox85.Name = "TextBox85"
        Me.TextBox85.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5479164123535156R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox85.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox85.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox85.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox85.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox85.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox85.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox85.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox85.Style.Font.Bold = True
        Me.TextBox85.Style.Font.Name = "Calibri"
        Me.TextBox85.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox85.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox85.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox85.StyleName = "Normal.TableBody"
        Me.TextBox85.Value = "=Sum(Fields.TransadoDolarEquivalentePesos)"
        '
        'TextBox87
        '
        Me.TextBox87.Format = "{0:N2}"
        Me.TextBox87.Name = "TextBox87"
        Me.TextBox87.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5375003814697266R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox87.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox87.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox87.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox87.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox87.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox87.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox87.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox87.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox87.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox87.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox87.Style.Font.Bold = True
        Me.TextBox87.Style.Font.Name = "Calibri"
        Me.TextBox87.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox87.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox87.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox87.StyleName = "Normal.TableBody"
        Me.TextBox87.Value = "=Sum(Fields.TransadoPesos)"
        '
        'TextBox88
        '
        Me.TextBox88.Format = "{0:N2}"
        Me.TextBox88.Name = "TextBox88"
        Me.TextBox88.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6104170083999634R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox88.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox88.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox88.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox88.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox88.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox88.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox88.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox88.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox88.Style.Font.Bold = True
        Me.TextBox88.Style.Font.Name = "Calibri"
        Me.TextBox88.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox88.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox88.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox88.StyleName = "Normal.TableBody"
        Me.TextBox88.Value = "=Sum(Fields.AcumuladoMesPesos)"
        '
        'TextBox18
        '
        Me.TextBox18.Format = "{0:N2}"
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.475000262260437R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox18.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox18.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox18.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox18.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox18.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox18.Style.Font.Name = "Calibri"
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox18.StyleName = "Normal.TableBody"
        Me.TextBox18.Value = "= Fields.AcumuladoAnioPesos"
        '
        'TextBox19
        '
        Me.TextBox19.Format = "{0:N2}"
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.475000262260437R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox19.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.TextBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(0.30000001192092896R)
        Me.TextBox19.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox19.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox19.Style.Font.Bold = True
        Me.TextBox19.Style.Font.Name = "Calibri"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox19.StyleName = "Normal.TableBody"
        Me.TextBox19.Value = "= Sum(Fields.AcumuladoAnioPesos)"
        '
        'SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras
        '
        Me.SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras.ConnectionString = "CN"
        Me.SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras.Name = "SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras"
        Me.SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@pFecha", System.Data.DbType.[Date], "= Parameters.FechaOperacion.Value")})
        Me.SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras.SelectCommand = "dbo.SP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras"
        Me.SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'TextBox31
        '
        Me.TextBox31.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(1.0826770067214966R))
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(9.99405574798584R), Telerik.Reporting.Drawing.Unit.Inch(0.23622035980224609R))
        Me.TextBox31.Style.Font.Name = "Calibri"
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox31.Value = "Nota: Los montos presentados en esos reportes representan la punta compradora."
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
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8232231140136719R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD / {Now()}"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.9086380004882812R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0854175090789795R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.pageInfoTextBox.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
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
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7925002574920654R), Telerik.Reporting.Drawing.Unit.Inch(0.59071516990661621R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'BB_RVVolTransInsEEmisoras
        '
        Me.BookmarkId = "BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras"
        Me.DocumentMapText = "Renta Variable | Volumen Transado Instrumentos de Entidades Emisoras"
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "BB_RVVolTransInsEEmisoras"
        Me.PageSettings.Landscape = true
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaOperacion"
        ReportParameter1.Text = "Fecha"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = true
        ReportParameter2.AvailableValues.DataSource = Me.SqlBoletinConfiguracion
        ReportParameter2.AvailableValues.DisplayMember = "= Fields.Descripcion"
        ReportParameter2.AvailableValues.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.Descripcion", Telerik.Reporting.SortDirection.Asc))
        ReportParameter2.AvailableValues.ValueMember = "= Fields.BoletinConfiguracionID"
        ReportParameter2.Name = "Configuracion"
        ReportParameter2.Text = "Configuracion"
        ReportParameter2.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.Table), "Normal.TableNormal")})
        StyleRule2.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule2.Style.Color = System.Drawing.Color.Black
        StyleRule2.Style.Font.Name = "Tahoma"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        DescendantSelector1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableHeader")})
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector1})
        StyleRule3.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule3.Style.Font.Name = "Tahoma"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        DescendantSelector2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableBody")})
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector2})
        StyleRule4.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule4.Style.Font.Name = "Tahoma"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(10R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox82 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox84 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox85 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox87 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox88 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents SqlBoletinConfiguracion As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlSP_BB_RentaVariableVolumenTransadoInstrumentosEntidadesEmisoras As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox38 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class