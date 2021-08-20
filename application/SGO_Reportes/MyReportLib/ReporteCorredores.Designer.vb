Partial Class ReporteCorredores
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteCorredores))
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
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim Group2 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox55 = New Telerik.Reporting.TextBox()
        Me.TextBox35 = New Telerik.Reporting.TextBox()
        Me.TextBox41 = New Telerik.Reporting.TextBox()
        Me.TextBox36 = New Telerik.Reporting.TextBox()
        Me.TextBox57 = New Telerik.Reporting.TextBox()
        Me.TextBox39 = New Telerik.Reporting.TextBox()
        Me.labelsGroupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.labelsGroupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.fechaLicenciaCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.fechaLicenciaSIVCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.fechaLicenciaSIVVenceCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.fechaLicenciaVenceCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.licenciaCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.nombreCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.groupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.groupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.SqlPuestoBolsa = New Telerik.Reporting.SqlDataSource()
        Me.SqlEstadoCorredor = New Telerik.Reporting.SqlDataSource()
        Me.SqlConsultaCorredores = New Telerik.Reporting.SqlDataSource()
        Me.pageHeader = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.reportHeader = New Telerik.Reporting.ReportHeaderSection()
        Me.Table3 = New Telerik.Reporting.Table()
        Me.TextBox40 = New Telerik.Reporting.TextBox()
        Me.TextBox42 = New Telerik.Reporting.TextBox()
        Me.TextBox59 = New Telerik.Reporting.TextBox()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.fechaLicenciaDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.nombreDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.fechaLicenciaSIVDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.fechaLicenciaSIVVenceDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.licenciaDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.fechaLicenciaVenceDataTextBox1 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox55
        '
        Me.TextBox55.Name = "TextBox55"
        Me.TextBox55.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1310051679611206R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox55.Style.Font.Bold = True
        Me.TextBox55.Style.Font.Name = "Arial Narrow"
        Me.TextBox55.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox55.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox55.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox55.StyleName = ""
        Me.TextBox55.Value = "Estado Corredores:"
        '
        'TextBox35
        '
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1310051679611206R), Telerik.Reporting.Drawing.Unit.Inch(0.16999998688697815R))
        Me.TextBox35.Style.Font.Bold = True
        Me.TextBox35.Style.Font.Name = "Arial Narrow"
        Me.TextBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox35.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox35.Value = "Puesto De Bolsa:"
        '
        'TextBox41
        '
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10416697710752487R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox41.Style.Font.Name = "Arial Narrow"
        Me.TextBox41.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox41.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox41.StyleName = ""
        '
        'TextBox36
        '
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10416697710752487R), Telerik.Reporting.Drawing.Unit.Inch(0.16999998688697815R))
        Me.TextBox36.Style.Font.Name = "Arial Narrow"
        Me.TextBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox36.StyleName = ""
        '
        'TextBox57
        '
        Me.TextBox57.Format = "{0:d}"
        Me.TextBox57.Name = "TextBox57"
        Me.TextBox57.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1205887794494629R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox57.Style.Font.Name = "Arial Narrow"
        Me.TextBox57.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox57.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox57.StyleName = ""
        Me.TextBox57.Value = "= Parameters.EstadoCorredor.Label"
        '
        'TextBox39
        '
        Me.TextBox39.Format = "{0:d}"
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1205887794494629R), Telerik.Reporting.Drawing.Unit.Inch(0.16999995708465576R))
        Me.TextBox39.Style.Font.Name = "Arial Narrow"
        Me.TextBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox39.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox39.Value = "= Parameters.PuestoBolsaID.Label"
        '
        'labelsGroupFooterSection
        '
        Me.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144R)
        Me.labelsGroupFooterSection.Name = "labelsGroupFooterSection"
        Me.labelsGroupFooterSection.Style.Visible = False
        '
        'labelsGroupHeaderSection
        '
        Me.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.76200008392333984R)
        Me.labelsGroupHeaderSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.fechaLicenciaCaptionTextBox, Me.fechaLicenciaSIVCaptionTextBox, Me.fechaLicenciaSIVVenceCaptionTextBox, Me.fechaLicenciaVenceCaptionTextBox, Me.licenciaCaptionTextBox, Me.nombreCaptionTextBox, Me.TextBox4, Me.TextBox5})
        Me.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection"
        Me.labelsGroupHeaderSection.PrintOnEveryPage = True
        '
        'fechaLicenciaCaptionTextBox
        '
        Me.fechaLicenciaCaptionTextBox.CanGrow = True
        Me.fechaLicenciaCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.8420000076293945R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.fechaLicenciaCaptionTextBox.Name = "fechaLicenciaCaptionTextBox"
        Me.fechaLicenciaCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320014953613281R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.fechaLicenciaCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.fechaLicenciaCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaCaptionTextBox.Style.Font.Bold = False
        Me.fechaLicenciaCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.fechaLicenciaCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaCaptionTextBox.StyleName = "Caption"
        Me.fechaLicenciaCaptionTextBox.Value = "Télefono"
        '
        'fechaLicenciaSIVCaptionTextBox
        '
        Me.fechaLicenciaSIVCaptionTextBox.CanGrow = True
        Me.fechaLicenciaSIVCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.8740005493164062R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.fechaLicenciaSIVCaptionTextBox.Name = "fechaLicenciaSIVCaptionTextBox"
        Me.fechaLicenciaSIVCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7780001163482666R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.fechaLicenciaSIVCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.fechaLicenciaSIVCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaSIVCaptionTextBox.Style.Font.Bold = False
        Me.fechaLicenciaSIVCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaSIVCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaSIVCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.fechaLicenciaSIVCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaSIVCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaSIVCaptionTextBox.StyleName = "Caption"
        Me.fechaLicenciaSIVCaptionTextBox.Value = "Certificación"
        '
        'fechaLicenciaSIVVenceCaptionTextBox
        '
        Me.fechaLicenciaSIVVenceCaptionTextBox.CanGrow = True
        Me.fechaLicenciaSIVVenceCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.6522006988525391R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.fechaLicenciaSIVVenceCaptionTextBox.Name = "fechaLicenciaSIVVenceCaptionTextBox"
        Me.fechaLicenciaSIVVenceCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7775998115539551R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.Font.Bold = False
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaSIVVenceCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.fechaLicenciaSIVVenceCaptionTextBox.StyleName = "Caption"
        Me.fechaLicenciaSIVVenceCaptionTextBox.Value = "Fecha Inicio Certificación"
        '
        'fechaLicenciaVenceCaptionTextBox
        '
        Me.fechaLicenciaVenceCaptionTextBox.CanGrow = True
        Me.fechaLicenciaVenceCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.430001258850098R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.fechaLicenciaVenceCaptionTextBox.Name = "fechaLicenciaVenceCaptionTextBox"
        Me.fechaLicenciaVenceCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7999999523162842R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.fechaLicenciaVenceCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.fechaLicenciaVenceCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaVenceCaptionTextBox.Style.Font.Bold = False
        Me.fechaLicenciaVenceCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaVenceCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaVenceCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.fechaLicenciaVenceCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaVenceCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaVenceCaptionTextBox.StyleName = "Caption"
        Me.fechaLicenciaVenceCaptionTextBox.Value = "Fecha Venc Certificación"
        '
        'licenciaCaptionTextBox
        '
        Me.licenciaCaptionTextBox.CanGrow = True
        Me.licenciaCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.23020076751709R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.licenciaCaptionTextBox.Name = "licenciaCaptionTextBox"
        Me.licenciaCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6694186925888062R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.licenciaCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.licenciaCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.licenciaCaptionTextBox.Style.Font.Bold = False
        Me.licenciaCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.licenciaCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.licenciaCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.licenciaCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.licenciaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.licenciaCaptionTextBox.StyleName = "Caption"
        Me.licenciaCaptionTextBox.Value = "Licencia SIV"
        '
        'nombreCaptionTextBox
        '
        Me.nombreCaptionTextBox.CanGrow = True
        Me.nombreCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.05291656032204628R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.nombreCaptionTextBox.Name = "nombreCaptionTextBox"
        Me.nombreCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.7890834808349609R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.nombreCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.nombreCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.nombreCaptionTextBox.Style.Font.Bold = False
        Me.nombreCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.nombreCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.nombreCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0.5R)
        Me.nombreCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.nombreCaptionTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.nombreCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.nombreCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.nombreCaptionTextBox.StyleName = "Caption"
        Me.nombreCaptionTextBox.Value = "Nombre"
        '
        'TextBox4
        '
        Me.TextBox4.CanGrow = True
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.899820327758789R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7409628629684448R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.Font.Bold = False
        Me.TextBox4.Style.Font.Name = "Arial Narrow"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox4.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.StyleName = "Caption"
        Me.TextBox4.Value = "Fecha Inicio Licencia SIV"
        '
        'TextBox5
        '
        Me.TextBox5.CanGrow = True
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.640983581542969R), Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7899999618530273R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.Font.Bold = False
        Me.TextBox5.Style.Font.Name = "Arial Narrow"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox5.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.StyleName = "Caption"
        Me.TextBox5.Value = "Fecha Venc Licencia SIV"
        '
        'groupFooterSection
        '
        Me.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229155540466309R)
        Me.groupFooterSection.Name = "groupFooterSection"
        Me.groupFooterSection.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        '
        'groupHeaderSection
        '
        Me.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.74366700649261475R)
        Me.groupHeaderSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox3})
        Me.groupHeaderSection.Name = "groupHeaderSection"
        '
        'TextBox3
        '
        Me.TextBox3.CanGrow = True
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R), Telerik.Reporting.Drawing.Unit.Cm(0.067027702927589417R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.37806510925293R), Telerik.Reporting.Drawing.Unit.Cm(0.50800043344497681R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.Font.Bold = False
        Me.TextBox3.Style.Font.Name = "Arial Narrow"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.StyleName = "Caption"
        Me.TextBox3.Value = "=""Puesto de Bolsa: "" +Fields.PuestoBolsaNombre"
        '
        'SqlPuestoBolsa
        '
        Me.SqlPuestoBolsa.ConnectionString = "CN"
        Me.SqlPuestoBolsa.Name = "SqlPuestoBolsa"
        Me.SqlPuestoBolsa.SelectCommand = "SELECT 0 AS PuestoBolsaID, ' Todos' AS PuestoBolsaCodigo UNION SELECT PuestoBolsa" &
    "ID, PuestoBolsaCodigo FROM vPuestoBolsa ORDER BY PuestoBolsaCodigo"
        '
        'SqlEstadoCorredor
        '
        Me.SqlEstadoCorredor.ConnectionString = "CN"
        Me.SqlEstadoCorredor.Name = "SqlEstadoCorredor"
        Me.SqlEstadoCorredor.SelectCommand = "SELECT ' Todos' AS Nombre, 'T' AS Codigo UNION SELECT 'Activo' AS Nombre, '1' AS " &
    "Codigo UNION SELECT 'Inactivo' AS Nombre, '0' AS Codigo"
        '
        'SqlConsultaCorredores
        '
        Me.SqlConsultaCorredores.ConnectionString = "CN"
        Me.SqlConsultaCorredores.Name = "SqlConsultaCorredores"
        Me.SqlConsultaCorredores.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@PuestoBolsaID", System.Data.DbType.Int32, "=Parameters.PuestoBolsaID.Value"), New Telerik.Reporting.SqlDataSourceParameter("@EstadoCorredor", System.Data.DbType.[String], "=Parameters.EstadoCorredor.Value")})
        Me.SqlConsultaCorredores.SelectCommand = "[SP_PuestoBolsaCorredores]"
        Me.SqlConsultaCorredores.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'pageHeader
        '
        Me.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(2.0320000648498535R)
        Me.pageHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.TextBox1, Me.PictureBox2})
        Me.pageHeader.Name = "pageHeader"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.0791668891906738R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox2.Style.Color = System.Drawing.Color.Black
        Me.TextBox2.Style.Font.Bold = False
        Me.TextBox2.Style.Font.Name = "Arial Narrow"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Title"
        Me.TextBox2.Value = "Listado de Corredores con Certificación para Operar en la Bolsa de Valores de la " &
    "República Dominicana"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R), Telerik.Reporting.Drawing.Unit.Inch(0.000039365557313431054R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7791674137115479R), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Arial Narrow"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.StyleName = "Title"
        Me.TextBox1.Value = "Bolsa y Mercados de Valores de la República Dominicana"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.9673609733581543R), Telerik.Reporting.Drawing.Unit.Inch(0.000039365557313431054R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0957943201065064R), Telerik.Reporting.Drawing.Unit.Inch(0.547916829586029R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'pageFooter
        '
        Me.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.37570777535438538R)
        Me.pageFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81, Me.pageInfoTextBox})
        Me.pageFooter.Name = "pageFooter"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9937566518783569R), Telerik.Reporting.Drawing.Unit.Inch(0.14791637659072876R))
        Me.TextBox81.Style.Font.Name = "Arial Narrow"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8151812553405762R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4525356292724609R), Telerik.Reporting.Drawing.Unit.Inch(0.14791645109653473R))
        Me.pageInfoTextBox.Style.Font.Name = "Arial Narrow"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'reportHeader
        '
        Me.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(1.2954000234603882R)
        Me.reportHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table3})
        Me.reportHeader.Name = "reportHeader"
        '
        'Table3
        '
        Me.Table3.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.1310050487518311R)))
        Me.Table3.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.10416696220636368R)))
        Me.Table3.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.1205887794494629R)))
        Me.Table3.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.43180006742477417R)))
        Me.Table3.Body.SetCellContent(0, 0, Me.TextBox40)
        Me.Table3.Body.SetCellContent(0, 2, Me.TextBox42)
        Me.Table3.Body.SetCellContent(0, 1, Me.TextBox59)
        TableGroup3.Name = "Group7"
        TableGroup2.ChildGroups.Add(TableGroup3)
        TableGroup2.Name = "Group1"
        TableGroup2.ReportItem = Me.TextBox55
        TableGroup1.ChildGroups.Add(TableGroup2)
        TableGroup1.ReportItem = Me.TextBox35
        TableGroup6.Name = "Group8"
        TableGroup5.ChildGroups.Add(TableGroup6)
        TableGroup5.Name = "Group6"
        TableGroup5.ReportItem = Me.TextBox41
        TableGroup4.ChildGroups.Add(TableGroup5)
        TableGroup4.Name = "Group2"
        TableGroup4.ReportItem = Me.TextBox36
        TableGroup9.Name = "Group9"
        TableGroup8.ChildGroups.Add(TableGroup9)
        TableGroup8.Name = "Group3"
        TableGroup8.ReportItem = Me.TextBox57
        TableGroup7.ChildGroups.Add(TableGroup8)
        TableGroup7.ReportItem = Me.TextBox39
        Me.Table3.ColumnGroups.Add(TableGroup1)
        Me.Table3.ColumnGroups.Add(TableGroup4)
        Me.Table3.ColumnGroups.Add(TableGroup7)
        Me.Table3.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox40, Me.TextBox59, Me.TextBox42, Me.TextBox35, Me.TextBox55, Me.TextBox36, Me.TextBox41, Me.TextBox39, Me.TextBox57})
        Me.Table3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.Table3.Name = "Table3"
        TableGroup10.Name = "Group5"
        Me.Table3.RowGroups.Add(TableGroup10)
        Me.Table3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.3557608127593994R), Telerik.Reporting.Drawing.Unit.Cm(1.2954000234603882R))
        '
        'TextBox40
        '
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1310051679611206R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox40.Style.Font.Bold = True
        Me.TextBox40.Style.Font.Name = "Arial Narrow"
        Me.TextBox40.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox40.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox40.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox40.StyleName = ""
        '
        'TextBox42
        '
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1205887794494629R), Telerik.Reporting.Drawing.Unit.Cm(0.43180006742477417R))
        Me.TextBox42.Style.Font.Name = "Arial Narrow"
        Me.TextBox42.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox42.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox42.StyleName = ""
        '
        'TextBox59
        '
        Me.TextBox59.Name = "TextBox59"
        Me.TextBox59.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.10416697710752487R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox59.Style.Font.Name = "Arial Narrow"
        Me.TextBox59.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox59.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox59.StyleName = ""
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.13229165971279144R)
        Me.reportFooter.Name = "reportFooter"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.fechaLicenciaDataTextBox1, Me.nombreDataTextBox1, Me.PictureBox1, Me.fechaLicenciaSIVDataTextBox1, Me.fechaLicenciaSIVVenceDataTextBox1, Me.licenciaDataTextBox1, Me.TextBox6, Me.TextBox7, Me.fechaLicenciaVenceDataTextBox1})
        Me.detail.Name = "detail"
        '
        'fechaLicenciaDataTextBox1
        '
        Me.fechaLicenciaDataTextBox1.CanGrow = True
        Me.fechaLicenciaDataTextBox1.Format = "{0:d}"
        Me.fechaLicenciaDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(5.8420000076293945R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.fechaLicenciaDataTextBox1.Name = "fechaLicenciaDataTextBox1"
        Me.fechaLicenciaDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320007801055908R), Telerik.Reporting.Drawing.Unit.Cm(1.0999001264572144R))
        Me.fechaLicenciaDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaDataTextBox1.StyleName = "Data"
        Me.fechaLicenciaDataTextBox1.Value = "= Fields.Telefono"
        '
        'nombreDataTextBox1
        '
        Me.nombreDataTextBox1.CanGrow = True
        Me.nombreDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.1531170606613159R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.nombreDataTextBox1.Name = "nombreDataTextBox1"
        Me.nombreDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.6888833045959473R), Telerik.Reporting.Drawing.Unit.Cm(1.100000262260437R))
        Me.nombreDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.nombreDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.nombreDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.nombreDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.nombreDataTextBox1.StyleName = "Data"
        Me.nombreDataTextBox1.Value = "=Fields.Nombre"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.PictureBox1.MimeType = ""
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579R), Telerik.Reporting.Drawing.Unit.Cm(1.1000000238418579R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.PictureBox1.Value = "= Fields.Foto"
        '
        'fechaLicenciaSIVDataTextBox1
        '
        Me.fechaLicenciaSIVDataTextBox1.CanGrow = True
        Me.fechaLicenciaSIVDataTextBox1.Format = "{0:d}"
        Me.fechaLicenciaSIVDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.8742008209228516R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.fechaLicenciaSIVDataTextBox1.Name = "fechaLicenciaSIVDataTextBox1"
        Me.fechaLicenciaSIVDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7777998447418213R), Telerik.Reporting.Drawing.Unit.Cm(1.0999001264572144R))
        Me.fechaLicenciaSIVDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaSIVDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaSIVDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaSIVDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaSIVDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaSIVDataTextBox1.StyleName = "Data"
        Me.fechaLicenciaSIVDataTextBox1.Value = "= Fields.Licencia"
        '
        'fechaLicenciaSIVVenceDataTextBox1
        '
        Me.fechaLicenciaSIVVenceDataTextBox1.CanGrow = True
        Me.fechaLicenciaSIVVenceDataTextBox1.Format = "{0:d}"
        Me.fechaLicenciaSIVVenceDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.6522016525268555R), Telerik.Reporting.Drawing.Unit.Cm(-0.00000013457403724714823R))
        Me.fechaLicenciaSIVVenceDataTextBox1.Name = "fechaLicenciaSIVVenceDataTextBox1"
        Me.fechaLicenciaSIVVenceDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7946004867553711R), Telerik.Reporting.Drawing.Unit.Cm(1.1000003814697266R))
        Me.fechaLicenciaSIVVenceDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaSIVVenceDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaSIVVenceDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaSIVVenceDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaSIVVenceDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaSIVVenceDataTextBox1.StyleName = "Data"
        Me.fechaLicenciaSIVVenceDataTextBox1.Value = "= Fields.FechaLicencia"
        '
        'licenciaDataTextBox1
        '
        Me.licenciaDataTextBox1.CanGrow = True
        Me.licenciaDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.230201721191406R), Telerik.Reporting.Drawing.Unit.Cm(-0.00000013457403724714823R))
        Me.licenciaDataTextBox1.Name = "licenciaDataTextBox1"
        Me.licenciaDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.6694186925888062R), Telerik.Reporting.Drawing.Unit.Cm(1.1000003814697266R))
        Me.licenciaDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.licenciaDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.licenciaDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.licenciaDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.licenciaDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.licenciaDataTextBox1.StyleName = "Data"
        Me.licenciaDataTextBox1.Value = "=Fields.LicenciaSIV"
        '
        'TextBox6
        '
        Me.TextBox6.CanGrow = True
        Me.TextBox6.Format = "{0:d}"
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(14.899820327758789R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7409632205963135R), Telerik.Reporting.Drawing.Unit.Cm(1.1000003814697266R))
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.Font.Name = "Arial Narrow"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox6.StyleName = "Data"
        Me.TextBox6.Value = "= Fields.FechaLicenciaSIV"
        '
        'TextBox7
        '
        Me.TextBox7.CanGrow = True
        Me.TextBox7.Format = "{0:d}"
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(16.640983581542969R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7898998260498047R), Telerik.Reporting.Drawing.Unit.Cm(1.1000003814697266R))
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.Font.Name = "Arial Narrow"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.StyleName = "Data"
        Me.TextBox7.Value = "= Fields.FechaLicenciaSIVVence" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'fechaLicenciaVenceDataTextBox1
        '
        Me.fechaLicenciaVenceDataTextBox1.CanGrow = True
        Me.fechaLicenciaVenceDataTextBox1.Format = "{0:d}"
        Me.fechaLicenciaVenceDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(11.447002410888672R), Telerik.Reporting.Drawing.Unit.Cm(-0.00000013457403724714823R))
        Me.fechaLicenciaVenceDataTextBox1.Name = "fechaLicenciaVenceDataTextBox1"
        Me.fechaLicenciaVenceDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7829983234405518R), Telerik.Reporting.Drawing.Unit.Cm(1.1000003814697266R))
        Me.fechaLicenciaVenceDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaVenceDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaVenceDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaVenceDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaVenceDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaVenceDataTextBox1.StyleName = "Data"
        Me.fechaLicenciaVenceDataTextBox1.Value = "=Fields.FechaLicenciaVence"
        '
        'ReporteCorredores
        '
        Me.DataSource = Me.SqlConsultaCorredores
        Group1.GroupFooter = Me.labelsGroupFooterSection
        Group1.GroupHeader = Me.labelsGroupHeaderSection
        Group1.Name = "labelsGroup"
        Group2.GroupFooter = Me.groupFooterSection
        Group2.GroupHeader = Me.groupHeaderSection
        Group2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.PuestoBolsaNombre"))
        Group2.GroupKeepTogether = Telerik.Reporting.GroupKeepTogether.All
        Group2.Name = "group"
        Group2.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.PuestoBolsaNombre", Telerik.Reporting.SortDirection.Asc))
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1, Group2})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.labelsGroupHeaderSection, Me.labelsGroupFooterSection, Me.groupHeaderSection, Me.groupFooterSection, Me.pageHeader, Me.pageFooter, Me.reportHeader, Me.reportFooter, Me.detail})
        Me.Name = "ReporteCorredores"
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        ReportParameter1.AvailableValues.DataSource = Me.SqlPuestoBolsa
        ReportParameter1.AvailableValues.DisplayMember = "= Fields.PuestoBolsaCodigo"
        ReportParameter1.AvailableValues.ValueMember = "= Fields.PuestoBolsaID"
        ReportParameter1.Name = "PuestoBolsaID"
        ReportParameter1.Text = "Puesto Bolsa"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.[Integer]
        ReportParameter1.Visible = True
        ReportParameter2.AvailableValues.DataSource = Me.SqlEstadoCorredor
        ReportParameter2.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter2.AvailableValues.ValueMember = "= Fields.Codigo"
        ReportParameter2.Name = "EstadoCorredor"
        ReportParameter2.Text = "Estado Corredor"
        ReportParameter2.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Title")})
        StyleRule1.Style.Color = System.Drawing.Color.Black
        StyleRule1.Style.Font.Bold = True
        StyleRule1.Style.Font.Italic = False
        StyleRule1.Style.Font.Name = "Tahoma"
        StyleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18.0R)
        StyleRule1.Style.Font.Strikeout = False
        StyleRule1.Style.Font.Underline = False
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Caption")})
        StyleRule2.Style.Color = System.Drawing.Color.Black
        StyleRule2.Style.Font.Name = "Tahoma"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        StyleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Data")})
        StyleRule3.Style.Font.Name = "Tahoma"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("PageInfo")})
        StyleRule4.Style.Font.Name = "Tahoma"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        StyleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(18.43098258972168R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents SqlConsultaCorredores As Telerik.Reporting.SqlDataSource
    Friend WithEvents labelsGroupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents fechaLicenciaCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaSIVCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaSIVVenceCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaVenceCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents licenciaCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents nombreCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents labelsGroupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents pageHeader As Telerik.Reporting.PageHeaderSection
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
    Friend WithEvents reportHeader As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents fechaLicenciaDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaSIVDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaSIVVenceDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaVenceDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents licenciaDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents nombreDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents groupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents groupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents Table3 As Telerik.Reporting.Table
    Friend WithEvents TextBox40 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox42 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox59 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox55 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox35 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox41 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox36 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox57 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox39 As Telerik.Reporting.TextBox
    Friend WithEvents SqlEstadoCorredor As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlPuestoBolsa As Telerik.Reporting.SqlDataSource
End Class