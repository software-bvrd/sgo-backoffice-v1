Partial Class ReporteOperacionesPuestoBolsaSIMV
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteOperacionesPuestoBolsaSIMV))
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter4 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter5 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.groupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.groupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.TextBox67 = New Telerik.Reporting.TextBox()
        Me.TextBox68 = New Telerik.Reporting.TextBox()
        Me.TextBox69 = New Telerik.Reporting.TextBox()
        Me.TextBox70 = New Telerik.Reporting.TextBox()
        Me.TextBox71 = New Telerik.Reporting.TextBox()
        Me.TextBox72 = New Telerik.Reporting.TextBox()
        Me.TextBox73 = New Telerik.Reporting.TextBox()
        Me.TextBox74 = New Telerik.Reporting.TextBox()
        Me.TextBox75 = New Telerik.Reporting.TextBox()
        Me.TextBox76 = New Telerik.Reporting.TextBox()
        Me.TextBox77 = New Telerik.Reporting.TextBox()
        Me.TextBox79 = New Telerik.Reporting.TextBox()
        Me.TextBox78 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.TextBox28 = New Telerik.Reporting.TextBox()
        Me.TextBox29 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.TextBox32 = New Telerik.Reporting.TextBox()
        Me.TextBox33 = New Telerik.Reporting.TextBox()
        Me.TextBox45 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.SqlTipo = New Telerik.Reporting.SqlDataSource()
        Me.SqlMercado = New Telerik.Reporting.SqlDataSource()
        Me.SqlPuestoBolsa = New Telerik.Reporting.SqlDataSource()
        Me.pageHeader = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.reportHeader = New Telerik.Reporting.ReportHeaderSection()
        Me.reportData = New Telerik.Reporting.SqlDataSource()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox23 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.TextBox56 = New Telerik.Reporting.TextBox()
        Me.TextBox58 = New Telerik.Reporting.TextBox()
        Me.TextBox60 = New Telerik.Reporting.TextBox()
        Me.TextBox61 = New Telerik.Reporting.TextBox()
        Me.TextBox62 = New Telerik.Reporting.TextBox()
        Me.TextBox63 = New Telerik.Reporting.TextBox()
        Me.TextBox64 = New Telerik.Reporting.TextBox()
        Me.TextBox65 = New Telerik.Reporting.TextBox()
        Me.TextBox66 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.SqlNombrePuestoBolsa = New Telerik.Reporting.SqlDataSource()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'groupFooterSection
        '
        Me.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.26448321342468262R)
        Me.groupFooterSection.Name = "groupFooterSection"
        Me.groupFooterSection.PageBreak = Telerik.Reporting.PageBreak.After
        Me.groupFooterSection.Style.Visible = False
        '
        'groupHeaderSection
        '
        Me.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(4.2631664276123047R)
        Me.groupHeaderSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox67, Me.TextBox68, Me.TextBox69, Me.TextBox70, Me.TextBox71, Me.TextBox72, Me.TextBox73, Me.TextBox74, Me.TextBox75, Me.TextBox76, Me.TextBox77, Me.TextBox79, Me.TextBox78, Me.TextBox3, Me.TextBox4, Me.TextBox7, Me.TextBox8, Me.TextBox24, Me.TextBox26, Me.TextBox27, Me.TextBox28, Me.TextBox29, Me.TextBox30, Me.TextBox31, Me.TextBox32, Me.TextBox33, Me.TextBox45, Me.TextBox9, Me.TextBox10, Me.TextBox11, Me.TextBox17, Me.TextBox5, Me.TextBox20, Me.TextBox16, Me.TextBox15, Me.TextBox21, Me.TextBox12, Me.TextBox6})
        Me.groupHeaderSection.Name = "groupHeaderSection"
        Me.groupHeaderSection.PageBreak = Telerik.Reporting.PageBreak.After
        Me.groupHeaderSection.PrintOnEveryPage = True
        '
        'TextBox67
        '
        Me.TextBox67.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.4324777126312256R), Telerik.Reporting.Drawing.Unit.Cm(3.5609960556030273R))
        Me.TextBox67.Name = "TextBox67"
        Me.TextBox67.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.54305571317672729R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox67.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox67.Style.Font.Name = "Arial Narrow"
        Me.TextBox67.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox67.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox67.StyleName = "Normal.TableHeader"
        Me.TextBox67.Value = "Hora"
        '
        'TextBox68
        '
        Me.TextBox68.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.780647277832031R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox68.Name = "TextBox68"
        Me.TextBox68.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.50782287120819092R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox68.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox68.Style.Font.Name = "Arial Narrow"
        Me.TextBox68.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox68.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox68.StyleName = "Normal.TableHeader"
        Me.TextBox68.Value = "Tas de Venta"
        '
        'TextBox69
        '
        Me.TextBox69.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.912614822387695R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox69.Name = "TextBox69"
        Me.TextBox69.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.34166690707206726R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox69.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox69.Style.Font.Name = "Arial Narrow"
        Me.TextBox69.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox69.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox69.StyleName = "Normal.TableHeader"
        Me.TextBox69.Value = "M/T"
        '
        'TextBox70
        '
        Me.TextBox70.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.594788551330566R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox70.Name = "TextBox70"
        Me.TextBox70.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.51875019073486328R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox70.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox70.Style.Font.Name = "Arial Narrow"
        Me.TextBox70.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox70.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox70.StyleName = "Normal.TableHeader"
        Me.TextBox70.Value = "Inter�s Nominal"
        '
        'TextBox71
        '
        Me.TextBox71.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.880086898803711R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox71.Name = "TextBox71"
        Me.TextBox71.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67499995231628418R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox71.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox71.Style.Font.Name = "Arial Narrow"
        Me.TextBox71.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox71.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox71.StyleName = "Normal.TableHeader"
        Me.TextBox71.Value = "Monto Transado"
        '
        'TextBox72
        '
        Me.TextBox72.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.729831695556641R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox72.Name = "TextBox72"
        Me.TextBox72.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.45277804136276245R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox72.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox72.Style.Font.Name = "Arial Narrow"
        Me.TextBox72.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox72.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox72.StyleName = "Normal.TableHeader"
        Me.TextBox72.Value = "Precio %"
        '
        'TextBox73
        '
        Me.TextBox73.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.697629928588867R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox73.Name = "TextBox73"
        Me.TextBox73.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000036954879761R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox73.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox73.Style.Font.Name = "Arial Narrow"
        Me.TextBox73.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox73.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox73.StyleName = "Normal.TableHeader"
        Me.TextBox73.Value = "Valor Nominal Total"
        '
        'TextBox74
        '
        Me.TextBox74.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.7061214447021484R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox74.Name = "TextBox74"
        Me.TextBox74.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.39027801156044006R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox74.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox74.Style.Font.Name = "Arial Narrow"
        Me.TextBox74.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox74.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox74.StyleName = "Normal.TableHeader"
        Me.TextBox74.Value = "Rend."
        '
        'TextBox75
        '
        Me.TextBox75.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.2824630737304688R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox75.Name = "TextBox75"
        Me.TextBox75.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56041675806045532R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox75.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox75.Style.Font.Name = "Arial Narrow"
        Me.TextBox75.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox75.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox75.StyleName = "Normal.TableHeader"
        Me.TextBox75.Value = "Fecha de Vencimiento"
        '
        'TextBox76
        '
        Me.TextBox76.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.2999997138977051R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox76.Name = "TextBox76"
        Me.TextBox76.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78041946887969971R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox76.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox76.Style.Font.Name = "Arial Narrow"
        Me.TextBox76.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox76.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox76.StyleName = "Normal.TableHeader"
        Me.TextBox76.Value = "Emisor"
        '
        'TextBox77
        '
        Me.TextBox77.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.426548957824707R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox77.Name = "TextBox77"
        Me.TextBox77.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.73750036954879761R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox77.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox77.Style.Font.Name = "Arial Narrow"
        Me.TextBox77.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox77.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox77.StyleName = "Normal.TableHeader"
        Me.TextBox77.Value = "Titulo Valor"
        '
        'TextBox79
        '
        Me.TextBox79.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052917119115591049R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox79.Name = "TextBox79"
        Me.TextBox79.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.54305541515350342R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox79.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox79.Style.Font.Name = "Arial Narrow"
        Me.TextBox79.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox79.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox79.StyleName = "Normal.TableHeader"
        Me.TextBox79.Value = "Fecha de Operaci�n"
        '
        'TextBox78
        '
        Me.TextBox78.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.8120388984680176R), Telerik.Reporting.Drawing.Unit.Cm(3.5610957145690918R))
        Me.TextBox78.Name = "TextBox78"
        Me.TextBox78.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66455155611038208R), Telerik.Reporting.Drawing.Unit.Inch(0.27636629343032837R))
        Me.TextBox78.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox78.Style.Font.Name = "Arial Narrow"
        Me.TextBox78.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox78.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox78.StyleName = "Normal.TableHeader"
        Me.TextBox78.Value = "N�mero de Operaci�n"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475R), Telerik.Reporting.Drawing.Unit.Cm(1.9195176362991333R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.464566707611084R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox3.Style.Font.Name = "Arial Narrow"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.StyleName = ""
        Me.TextBox3.Value = "= Fields.NombrePuestoBolsa"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20459432899951935R), Telerik.Reporting.Drawing.Unit.Cm(1.9178122282028198R))
        Me.TextBox4.Multiline = False
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.66748255491256714R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox4.Style.Font.Bold = False
        Me.TextBox4.Style.Font.Name = "Arial Narrow"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.StyleName = ""
        Me.TextBox4.TextWrap = False
        Me.TextBox4.Value = "Participante:"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(0.47123688459396362R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.15972234308719635R))
        Me.TextBox7.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.Font.Name = "Arial Narrow"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox7.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox7.StyleName = ""
        Me.TextBox7.Value = "= Count(Fields.fecha_oper)"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(0.47123688459396362R))
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.15972234308719635R))
        Me.TextBox8.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.Font.Bold = True
        Me.TextBox8.Style.Font.Name = "Arial Narrow"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox8.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.StyleName = ""
        Me.TextBox8.Value = "Cant.de Operaciones:"
        '
        'TextBox24
        '
        Me.TextBox24.Format = "{0:N2}"
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(0.87713170051574707R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.15999999642372131R))
        Me.TextBox24.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox24.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox24.Style.Font.Name = "Arial Narrow"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox24.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.StyleName = ""
        Me.TextBox24.Value = "= Sum(Fields.TransadoPesos)"
        '
        'TextBox26
        '
        Me.TextBox26.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(0.87713170051574707R))
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.15999999642372131R))
        Me.TextBox26.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox26.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox26.Style.Font.Bold = True
        Me.TextBox26.Style.Font.Name = "Arial Narrow"
        Me.TextBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox26.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox26.StyleName = ""
        Me.TextBox26.Value = "Transado en DOP:"
        '
        'TextBox27
        '
        Me.TextBox27.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(1.2837322950363159R))
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.17739266157150269R))
        Me.TextBox27.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox27.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox27.Style.Font.Bold = True
        Me.TextBox27.Style.Font.Name = "Arial Narrow"
        Me.TextBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox27.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox27.StyleName = ""
        Me.TextBox27.Value = "Transado en USD:"
        '
        'TextBox28
        '
        Me.TextBox28.Format = "{0:N2}"
        Me.TextBox28.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(1.2837322950363159R))
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.17747165262699127R))
        Me.TextBox28.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox28.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox28.Style.Font.Name = "Arial Narrow"
        Me.TextBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox28.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox28.StyleName = ""
        Me.TextBox28.Value = "= Sum(Fields.TransadoDolar)"
        '
        'TextBox29
        '
        Me.TextBox29.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(1.7345103025436401R))
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.16000001132488251R))
        Me.TextBox29.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox29.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox29.Style.Font.Bold = True
        Me.TextBox29.Style.Font.Name = "Arial Narrow"
        Me.TextBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox29.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox29.StyleName = ""
        Me.TextBox29.Value = "Equivalente en DOP:"
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:N2}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(1.7347104549407959R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.15999999642372131R))
        Me.TextBox30.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox30.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox30.Style.Font.Name = "Arial Narrow"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox30.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.StyleName = ""
        Me.TextBox30.Value = "=Sum(Fields.EquivalentePesos)"
        '
        'TextBox31
        '
        Me.TextBox31.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(2.1411101818084717R))
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.1660851389169693R))
        Me.TextBox31.Style.BackgroundColor = System.Drawing.Color.Empty
        Me.TextBox31.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox31.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox31.Style.Font.Bold = True
        Me.TextBox31.Style.Font.Name = "Arial Narrow"
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox31.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox31.StyleName = ""
        Me.TextBox31.Value = "Valor para Comisionar:"
        '
        'TextBox32
        '
        Me.TextBox32.Format = "{0:N2}"
        Me.TextBox32.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(2.1411101818084717R))
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.16608507931232452R))
        Me.TextBox32.Style.BackgroundColor = System.Drawing.Color.Empty
        Me.TextBox32.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox32.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox32.Style.Font.Bold = False
        Me.TextBox32.Style.Font.Name = "Arial Narrow"
        Me.TextBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox32.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox32.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox32.StyleName = ""
        Me.TextBox32.Value = "= Sum(Fields.ValorTransadoEquivalentePesos)"
        '
        'TextBox33
        '
        Me.TextBox33.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(2.9697666168212891R))
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.1599997878074646R))
        Me.TextBox33.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox33.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox33.Style.Font.Bold = True
        Me.TextBox33.Style.Font.Name = "Arial Narrow"
        Me.TextBox33.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox33.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox33.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox33.StyleName = ""
        Me.TextBox33.Value = "Total a Comisionar:"
        '
        'TextBox45
        '
        Me.TextBox45.Format = "{0:N2}"
        Me.TextBox45.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(2.9697666168212891R))
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.15999999642372131R))
        Me.TextBox45.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox45.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox45.Style.Font.Bold = False
        Me.TextBox45.Style.Font.Name = "Arial Narrow"
        Me.TextBox45.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox45.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox45.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox45.StyleName = ""
        Me.TextBox45.Value = "=Sum(Fields.ComisionaCobrarSIMV)"
        '
        'TextBox9
        '
        Me.TextBox9.Format = "{0:d}"
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.9999997615814209R), Telerik.Reporting.Drawing.Unit.Cm(1.5239990949630737R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.984173059463501R), Telerik.Reporting.Drawing.Unit.Inch(0.15496577322483063R))
        Me.TextBox9.Style.Font.Name = "Arial Narrow"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.StyleName = ""
        Me.TextBox9.Value = "= Parameters.FechaFinal.Value"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5296111106872559R), Telerik.Reporting.Drawing.Unit.Cm(1.5239990949630737R))
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.18511360883712769R), Telerik.Reporting.Drawing.Unit.Inch(0.15496577322483063R))
        Me.TextBox10.Style.Font.Bold = False
        Me.TextBox10.Style.Font.Name = "Arial Narrow"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.StyleName = ""
        Me.TextBox10.Value = "al:"
        '
        'TextBox11
        '
        Me.TextBox11.Format = "{0:d}"
        Me.TextBox11.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.7792285680770874R), Telerik.Reporting.Drawing.Unit.Cm(1.5239994525909424R))
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.68904846906661987R), Telerik.Reporting.Drawing.Unit.Inch(0.15496577322483063R))
        Me.TextBox11.Style.Font.Name = "Arial Narrow"
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox11.Value = "= Parameters.FechaInicial.Value"
        '
        'TextBox17
        '
        Me.TextBox17.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.20469476282596588R), Telerik.Reporting.Drawing.Unit.Cm(1.5239994525909424R))
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.58870285749435425R), Telerik.Reporting.Drawing.Unit.Inch(0.15496577322483063R))
        Me.TextBox17.Style.Font.Bold = False
        Me.TextBox17.Style.Font.Name = "Arial Narrow"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.Value = "Desde el:"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.080588497221469879R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2999606132507324R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox5.Style.Color = System.Drawing.Color.Black
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Style.Font.Name = "Arial Narrow"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = "Title"
        Me.TextBox5.Value = "= Fields.NombreMercado"
        '
        'TextBox20
        '
        Me.TextBox20.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.080588623881340027R), Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R))
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.210749626159668R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox20.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox20.Style.Color = System.Drawing.Color.Black
        Me.TextBox20.Style.Font.Bold = True
        Me.TextBox20.Style.Font.Name = "Arial Narrow"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox20.StyleName = "Title"
        Me.TextBox20.Value = "= Fields.NombreMecanismo"
        '
        'TextBox16
        '
        Me.TextBox16.Format = "{0}"
        Me.TextBox16.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(0.034535396844148636R))
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.15972234308719635R))
        Me.TextBox16.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.Font.Name = "Arial Narrow"
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox16.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox16.StyleName = ""
        Me.TextBox16.Value = "= Fields.OperacionTipo"
        '
        'TextBox15
        '
        Me.TextBox15.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(0.034535396844148636R))
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.15972234308719635R))
        Me.TextBox15.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.Font.Bold = True
        Me.TextBox15.Style.Font.Name = "Arial Narrow"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox15.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.StyleName = ""
        Me.TextBox15.Value = "Punta:"
        '
        'TextBox21
        '
        Me.TextBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.080548882484436035R), Telerik.Reporting.Drawing.Unit.Inch(0.39999985694885254R))
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2999606132507324R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox21.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox21.Style.Color = System.Drawing.Color.Black
        Me.TextBox21.Style.Font.Bold = False
        Me.TextBox21.Style.Font.Name = "Arial Narrow"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox21.StyleName = "Title"
        Me.TextBox21.Value = "Para la Superintendencia del Mercado de Valores"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.100000381469727R), Telerik.Reporting.Drawing.Unit.Cm(2.5631659030914307R))
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6101565361022949R), Telerik.Reporting.Drawing.Unit.Inch(0.16000001132488251R))
        Me.TextBox12.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.Font.Bold = True
        Me.TextBox12.Style.Font.Name = "Arial Narrow"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox12.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.StyleName = ""
        Me.TextBox12.Value = "Comisi�n Regulatoria:"
        '
        'TextBox6
        '
        Me.TextBox6.Format = "{0:N2}"
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.189996719360352R), Telerik.Reporting.Drawing.Unit.Cm(2.5631659030914307R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5277645587921143R), Telerik.Reporting.Drawing.Unit.Inch(0.15999999642372131R))
        Me.TextBox6.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.Font.Name = "Arial Narrow"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox6.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(1.0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.StyleName = ""
        Me.TextBox6.Value = "=Fields.ComisionSIMV"
        '
        'SqlTipo
        '
        Me.SqlTipo.ConnectionString = "CN"
        Me.SqlTipo.Name = "SqlTipo"
        Me.SqlTipo.SelectCommand = "SELECT        ' Todos' AS Nombre, 'T' AS Codigo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UNION" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECT        'Vendedor' " &
    "AS Nombre, 'V' AS Codigo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UNION" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECT        'Comprador' AS Nombre, 'C' AS Cod" &
    "igo"
        '
        'SqlMercado
        '
        Me.SqlMercado.ConnectionString = "CN"
        Me.SqlMercado.Name = "SqlMercado"
        Me.SqlMercado.SelectCommand = "SELECT        Alias, CodigoMercado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            vMercado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHERE        (Codig" &
    "oMercado <> '')" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ORDER BY Alias"
        '
        'SqlPuestoBolsa
        '
        Me.SqlPuestoBolsa.ConnectionString = "CN"
        Me.SqlPuestoBolsa.Name = "SqlPuestoBolsa"
        Me.SqlPuestoBolsa.SelectCommand = "SELECT        ' Todos' AS PuestoBolsaCodigo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UNION " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECT        PuestoBolsaCod" &
    "igo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            vPuestoBolsa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ORDER BY PuestoBolsaCodigo"
        '
        'pageHeader
        '
        Me.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(1.5045421123504639R)
        Me.pageHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1, Me.TextBox2, Me.PictureBox1})
        Me.pageHeader.Name = "pageHeader"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0805884450674057R), Telerik.Reporting.Drawing.Unit.Inch(0.19233925640583038R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7406411170959473R), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Arial Narrow"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.StyleName = "Title"
        Me.TextBox1.Value = "Bolsa y Mercados de Valores de la Rep�blica Dominicana"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0805884450674057R), Telerik.Reporting.Drawing.Unit.Inch(0.39241811633110046R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2999606132507324R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox2.Style.Color = System.Drawing.Color.Black
        Me.TextBox2.Style.Font.Bold = False
        Me.TextBox2.Style.Font.Name = "Arial Narrow"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Title"
        Me.TextBox2.Value = "Reporte de Operaciones por Punta y por Participante"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5R), Telerik.Reporting.Drawing.Unit.Inch(0.034858930855989456R))
        Me.PictureBox1.MimeType = "image/png"
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0957943201065064R), Telerik.Reporting.Drawing.Unit.Inch(0.547916829586029R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox1.Value = CType(resources.GetObject("PictureBox1.Value"), Object)
        '
        'pageFooter
        '
        Me.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.37570756673812866R)
        Me.pageFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81})
        Me.pageFooter.Name = "pageFooter"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9937566518783569R), Telerik.Reporting.Drawing.Unit.Inch(0.14787696301937103R))
        Me.TextBox81.Style.Font.Name = "Arial Narrow"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'reportHeader
        '
        Me.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144R)
        Me.reportHeader.Name = "reportHeader"
        Me.reportHeader.Style.Visible = False
        '
        'reportData
        '
        Me.reportData.ConnectionString = "CN"
        Me.reportData.Name = "reportData"
        Me.reportData.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaInicio", System.Data.DbType.[Date], "=Parameters.FechaInicial.Value"), New Telerik.Reporting.SqlDataSourceParameter("@FechaFinal", System.Data.DbType.[Date], "=Parameters.FechaFinal.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Tipo", System.Data.DbType.AnsiString, "=Parameters.Tipo.Value"), New Telerik.Reporting.SqlDataSourceParameter("@PuestoBolsa", System.Data.DbType.AnsiString, "=Parameters.PuestoBolsa.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Mercado", System.Data.DbType.AnsiString, "=Parameters.Mercado.Value")})
        Me.reportData.SelectCommand = "dbo.SP_OperacionesMercadoSecundarioPuestoBolsa_SIMV"
        Me.reportData.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144R)
        Me.reportFooter.Name = "reportFooter"
        Me.reportFooter.PageBreak = Telerik.Reporting.PageBreak.None
        Me.reportFooter.Style.Visible = False
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.50815868377685547R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox14, Me.TextBox23, Me.TextBox25, Me.TextBox56, Me.TextBox58, Me.TextBox60, Me.TextBox61, Me.TextBox62, Me.TextBox63, Me.TextBox64, Me.TextBox65, Me.TextBox66, Me.TextBox13})
        Me.detail.Name = "detail"
        Me.detail.PageBreak = Telerik.Reporting.PageBreak.After
        '
        'TextBox14
        '
        Me.TextBox14.Format = "{0:N4}"
        Me.TextBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(17.778642654418945R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.508176863193512R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.Font.Name = "Arial Narrow"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.StyleName = "Normal.TableBody"
        Me.TextBox14.Value = "=Fields.TasaVenta"
        '
        'TextBox23
        '
        Me.TextBox23.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.910610198974609R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.34166690707206726R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox23.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox23.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox23.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox23.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox23.Style.Font.Name = "Arial Narrow"
        Me.TextBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox23.StyleName = "Normal.TableBody"
        Me.TextBox23.Value = "=Fields.mone_trans"
        '
        'TextBox25
        '
        Me.TextBox25.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.592983245849609R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.518670916557312R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox25.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox25.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox25.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox25.Style.Font.Name = "Arial Narrow"
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.StyleName = "Normal.TableBody"
        Me.TextBox25.Value = "=Fields.tasa_interes"
        '
        'TextBox56
        '
        Me.TextBox56.Format = "{0:N2}"
        Me.TextBox56.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.878883361816406R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox56.Name = "TextBox56"
        Me.TextBox56.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.67476344108581543R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox56.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox56.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox56.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox56.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox56.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox56.Style.Font.Name = "Arial Narrow"
        Me.TextBox56.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox56.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox56.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox56.StyleName = "Normal.TableBody"
        Me.TextBox56.Value = "=Fields.valor_tran"
        '
        'TextBox58
        '
        Me.TextBox58.Format = "{0:N4}"
        Me.TextBox58.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.728630065917969R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox58.Name = "TextBox58"
        Me.TextBox58.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.45277804136276245R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox58.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox58.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox58.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox58.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox58.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox58.Style.Font.Name = "Arial Narrow"
        Me.TextBox58.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox58.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox58.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox58.StyleName = "Normal.TableBody"
        Me.TextBox58.Value = "=Fields.precio_limp"
        '
        'TextBox60
        '
        Me.TextBox60.Format = "{0:N2}"
        Me.TextBox60.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.696428298950195R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox60.Name = "TextBox60"
        Me.TextBox60.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80000036954879761R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox60.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox60.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox60.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox60.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox60.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox60.Style.Font.Name = "Arial Narrow"
        Me.TextBox60.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox60.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox60.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox60.StyleName = "Normal.TableBody"
        Me.TextBox60.Value = "=Fields.valor_nom_tot"
        '
        'TextBox61
        '
        Me.TextBox61.Format = "{0:N2}"
        Me.TextBox61.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.7061223983764648R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox61.Name = "TextBox61"
        Me.TextBox61.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.38980498909950256R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox61.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox61.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox61.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox61.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox61.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox61.Style.Font.Name = "Arial Narrow"
        Me.TextBox61.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox61.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox61.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox61.StyleName = "Normal.TableBody"
        Me.TextBox61.Value = "=Fields.yield"
        '
        'TextBox62
        '
        Me.TextBox62.Format = "{0:d}"
        Me.TextBox62.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(8.2824630737304688R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox62.Name = "TextBox62"
        Me.TextBox62.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56041675806045532R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox62.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox62.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox62.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox62.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox62.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox62.Style.Font.Name = "Arial Narrow"
        Me.TextBox62.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox62.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox62.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox62.StyleName = "Normal.TableBody"
        Me.TextBox62.Value = "=Fields.fecha_venc"
        '
        'TextBox63
        '
        Me.TextBox63.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.2999997138977051R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox63.Name = "TextBox63"
        Me.TextBox63.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.78041881322860718R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox63.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox63.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox63.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox63.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox63.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox63.Style.Font.Name = "Arial Narrow"
        Me.TextBox63.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox63.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox63.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox63.StyleName = "Normal.TableBody"
        Me.TextBox63.Value = "=Fields.Emisor"
        '
        'TextBox64
        '
        Me.TextBox64.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.4265494346618652R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox64.Name = "TextBox64"
        Me.TextBox64.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.73750019073486328R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox64.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox64.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox64.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox64.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox64.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox64.Style.Font.Name = "Arial Narrow"
        Me.TextBox64.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox64.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox64.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox64.StyleName = "Normal.TableBody"
        Me.TextBox64.Value = "=Fields.TituloValor"
        '
        'TextBox65
        '
        Me.TextBox65.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.8120388984680176R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox65.Name = "TextBox65"
        Me.TextBox65.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62518149614334106R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox65.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox65.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox65.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox65.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox65.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox65.Style.Font.Name = "Arial Narrow"
        Me.TextBox65.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox65.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox65.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox65.StyleName = "Normal.TableBody"
        Me.TextBox65.Value = "=Fields.num_oper"
        '
        'TextBox66
        '
        Me.TextBox66.Format = "{0:d}"
        Me.TextBox66.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R), Telerik.Reporting.Drawing.Unit.Cm(0.00020024616969749332R))
        Me.TextBox66.Name = "TextBox66"
        Me.TextBox66.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.54305541515350342R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox66.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox66.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox66.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox66.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox66.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox66.Style.Font.Name = "Arial Narrow"
        Me.TextBox66.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox66.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox66.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox66.StyleName = "Normal.TableBody"
        Me.TextBox66.Value = "=Fields.fecha_oper"
        '
        'TextBox13
        '
        Me.TextBox13.Format = "{0:t}"
        Me.TextBox13.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.4324777126312256R), Telerik.Reporting.Drawing.Unit.Cm(0.00020051530736964196R))
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.54305571317672729R), Telerik.Reporting.Drawing.Unit.Inch(0.1999836266040802R))
        Me.TextBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox13.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox13.Style.Font.Name = "Arial Narrow"
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox13.StyleName = "Normal.TableBody"
        Me.TextBox13.Value = "=Fields.hora_oper"
        '
        'SqlNombrePuestoBolsa
        '
        Me.SqlNombrePuestoBolsa.ConnectionString = "CN"
        Me.SqlNombrePuestoBolsa.Name = "SqlNombrePuestoBolsa"
        Me.SqlNombrePuestoBolsa.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaInicio", System.Data.DbType.[Date], "=Parameters.FechaInicial.Value"), New Telerik.Reporting.SqlDataSourceParameter("@FechaFinal", System.Data.DbType.[Date], "=Parameters.FechaFinal.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Tipo", System.Data.DbType.AnsiString, "=Parameters.Tipo.Value"), New Telerik.Reporting.SqlDataSourceParameter("@PuestoBolsa", System.Data.DbType.AnsiString, "=Parameters.PuestoBolsa.Value")})
        Me.SqlNombrePuestoBolsa.SelectCommand = "dbo.SP_OperacionesMercadoSecundarioNombrePuestoBolsa"
        Me.SqlNombrePuestoBolsa.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'ReporteOperacionesPuestoBolsaSIMV
        '
        Me.DataSource = Me.reportData
        Group1.GroupFooter = Me.groupFooterSection
        Group1.GroupHeader = Me.groupHeaderSection
        Group1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.Tipo"))
        Group1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.PuestoBolsa"))
        Group1.GroupKeepTogether = Telerik.Reporting.GroupKeepTogether.All
        Group1.Name = "groupOperacionTipo"
        Group1.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.PuestoBolsa", Telerik.Reporting.SortDirection.Asc))
        Group1.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.OperacionTipo", Telerik.Reporting.SortDirection.Asc))
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.groupHeaderSection, Me.groupFooterSection, Me.pageHeader, Me.pageFooter, Me.reportHeader, Me.reportFooter, Me.detail})
        Me.Name = "ReporteOperacionesPuestoBolsa"
        Me.PageSettings.Landscape = false
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaInicial"
        ReportParameter1.Text = "Fecha Inicial"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = true
        ReportParameter2.Name = "FechaFinal"
        ReportParameter2.Text = "Fecha Final"
        ReportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter2.Value = "=Today()"
        ReportParameter2.Visible = true
        ReportParameter3.AvailableValues.DataSource = Me.SqlTipo
        ReportParameter3.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter3.AvailableValues.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.Nombre", Telerik.Reporting.SortDirection.Asc))
        ReportParameter3.AvailableValues.ValueMember = "= Fields.Codigo"
        ReportParameter3.Name = "Tipo"
        ReportParameter3.Visible = true
        ReportParameter4.AvailableValues.DataSource = Me.SqlMercado
        ReportParameter4.AvailableValues.DisplayMember = "= Fields.Alias"
        ReportParameter4.AvailableValues.ValueMember = "= Fields.CodigoMercado"
        ReportParameter4.Name = "Mercado"
        ReportParameter4.Visible = true
        ReportParameter5.AvailableValues.DataSource = Me.SqlPuestoBolsa
        ReportParameter5.AvailableValues.DisplayMember = "= Fields.PuestoBolsaCodigo"
        ReportParameter5.AvailableValues.ValueMember = "= Fields.PuestoBolsaCodigo"
        ReportParameter5.Name = "PuestoBolsa"
        ReportParameter5.Text = "Puesto de Bolsa"
        ReportParameter5.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.ReportParameters.Add(ReportParameter3)
        Me.ReportParameters.Add(ReportParameter4)
        Me.ReportParameters.Add(ReportParameter5)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Title")})
        StyleRule1.Style.Color = System.Drawing.Color.Black
        StyleRule1.Style.Font.Bold = true
        StyleRule1.Style.Font.Italic = false
        StyleRule1.Style.Font.Name = "Tahoma"
        StyleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18R)
        StyleRule1.Style.Font.Strikeout = false
        StyleRule1.Style.Font.Underline = false
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Caption")})
        StyleRule2.Style.Color = System.Drawing.Color.Black
        StyleRule2.Style.Font.Name = "Tahoma"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10R)
        StyleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Data")})
        StyleRule3.Style.Font.Name = "Tahoma"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("PageInfo")})
        StyleRule4.Style.Font.Name = "Tahoma"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        StyleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(19.3236083984375R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents pageHeader As Telerik.Reporting.PageHeaderSection
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents reportHeader As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
    Friend WithEvents reportData As Telerik.Reporting.SqlDataSource
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents groupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents groupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox23 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox56 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox58 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox60 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox61 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox62 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox63 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox64 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox65 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox66 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox67 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox68 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox69 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox70 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox71 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox72 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox73 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox74 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox75 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox76 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox77 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox79 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox78 As Telerik.Reporting.TextBox
    Friend WithEvents SqlTipo As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlNombrePuestoBolsa As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlPuestoBolsa As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox28 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox29 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox32 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox33 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox45 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
End Class