Partial Class ReporteAcumuladosOperacionesDetalle

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteAcumuladosOperacionesDetalle))
        Dim FormattingRule1 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim FormattingRule2 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim Group2 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.labelsGroupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox23 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox22 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.TextBox34 = New Telerik.Reporting.TextBox()
        Me.TextBox36 = New Telerik.Reporting.TextBox()
        Me.TextBox35 = New Telerik.Reporting.TextBox()
        Me.labelsGroupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.groupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.Panel1 = New Telerik.Reporting.Panel()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox28 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.Panel3 = New Telerik.Reporting.Panel()
        Me.groupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.TextBox29 = New Telerik.Reporting.TextBox()
        Me.TextBox32 = New Telerik.Reporting.TextBox()
        Me.TextBox33 = New Telerik.Reporting.TextBox()
        Me.TextBox47 = New Telerik.Reporting.TextBox()
        Me.TextBox48 = New Telerik.Reporting.TextBox()
        Me.TextBox52 = New Telerik.Reporting.TextBox()
        Me.TextBox53 = New Telerik.Reporting.TextBox()
        Me.TextBox54 = New Telerik.Reporting.TextBox()
        Me.TextBox56 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.pageHeader = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.reportHeader = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox38 = New Telerik.Reporting.TextBox()
        Me.TextBox37 = New Telerik.Reporting.TextBox()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.SqlDataSource1 = New Telerik.Reporting.SqlDataSource()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'labelsGroupFooterSection
        '
        Me.labelsGroupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(3.3019990921020508R)
        Me.labelsGroupFooterSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox26, Me.TextBox23, Me.TextBox24, Me.TextBox25, Me.TextBox4, Me.TextBox22, Me.TextBox30, Me.TextBox31, Me.TextBox34, Me.TextBox36, Me.TextBox35})
        Me.labelsGroupFooterSection.Name = "labelsGroupFooterSection"
        Me.labelsGroupFooterSection.Style.Visible = True
        '
        'TextBox26
        '
        Me.TextBox26.Format = "{0:P2}"
        Me.TextBox26.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.4659948348999023R), Telerik.Reporting.Drawing.Unit.Cm(0.22753980755805969R))
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.0280065536499023R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox26.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox26.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox26.Value = "Mercado Secundario"
        '
        'TextBox23
        '
        Me.TextBox23.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.0160030126571655R), Telerik.Reporting.Drawing.Unit.Cm(1.3493738174438477R))
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.44979190826416R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox23.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.5R)
        Me.TextBox23.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox23.Value = "= ""Total Operaciones Año Anterior "" + (Cint(ConvertirFechas.FormatdateYear(Parame" &
    "ters.fecha.Value))-1)"
        '
        'TextBox24
        '
        Me.TextBox24.Format = "{0:$#,##0}"
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.4659948348999023R), Telerik.Reporting.Drawing.Unit.Cm(1.3493738174438477R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.6154007911682129R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox24.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox24.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.TextBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.Value = "= sum(Fields.TotalYearBeforeMS)"
        '
        'TextBox25
        '
        Me.TextBox25.Format = "{0:P2}"
        Me.TextBox25.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.081700325012207R), Telerik.Reporting.Drawing.Unit.Cm(0.78845679759979248R))
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4122989177703857R), Telerik.Reporting.Drawing.Unit.Cm(1.1216332912445068R))
        Me.TextBox25.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.Value = "= IIf(Fields.TotalYearBeforeMS = 0,(Fields.TotalActualYear-Fields.TotalYearBefore" &
    "MS)," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "((sum(Fields.TotalActualYear) - sum(Fields.TotalYearBeforeMS))/sum(Fields." &
    "TotalYearBeforeMS+0.000000000000001)))"
        '
        'TextBox4
        '
        Me.TextBox4.Format = "{0:$#,##0}"
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(9.4659948348999023R), Telerik.Reporting.Drawing.Unit.Cm(0.78845679759979248R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.615401029586792R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.Value = "= sum(Fields.TotalActualYear)"
        '
        'TextBox22
        '
        Me.TextBox22.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.0160030126571655R), Telerik.Reporting.Drawing.Unit.Cm(0.78845679759979248R))
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.44979190826416R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox22.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.5R)
        Me.TextBox22.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox22.Value = "= ""Total Operaciones Año Actual "" + ConvertirFechas.FormatdateYear(Parameters.fec" &
    "ha.Value)"
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:$#,##0}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.494202613830566R), Telerik.Reporting.Drawing.Unit.Cm(1.3493738174438477R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7448959350585938R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox30.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox30.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.Value = "= Fields.MontoTotalTransadoYearBeforeMS_MP"
        '
        'TextBox31
        '
        Me.TextBox31.Format = "{0:P2}"
        Me.TextBox31.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.494202613830566R), Telerik.Reporting.Drawing.Unit.Cm(0.22754062712192535R))
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.16519021987915R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox31.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox31.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox31.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox31.Value = "Mercado Total"
        '
        'TextBox34
        '
        Me.TextBox34.Format = "{0:$#,##0}"
        Me.TextBox34.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.494202613830566R), Telerik.Reporting.Drawing.Unit.Cm(0.78845679759979248R))
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.7448959350585938R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox34.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox34.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox34.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.TextBox34.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox34.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox34.Value = "= Fields.TotalTransadoMS_MP"
        '
        'TextBox36
        '
        Me.TextBox36.Format = "{0:P2}"
        Me.TextBox36.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.249393463134766R), Telerik.Reporting.Drawing.Unit.Cm(0.78845679759979248R))
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4100000858306885R), Telerik.Reporting.Drawing.Unit.Cm(1.1216332912445068R))
        Me.TextBox36.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox36.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox36.Value = resources.GetString("TextBox36.Value")
        '
        'TextBox35
        '
        Me.TextBox35.Format = "{0:d}"
        Me.TextBox35.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.0160030126571655R), Telerik.Reporting.Drawing.Unit.Cm(2.3350818157196045R))
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5372557640075684R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox35.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox35.Value = "Nota: Estas operaciones no inclyen MM."
        '
        'labelsGroupHeaderSection
        '
        Me.labelsGroupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(0.33020037412643433R)
        Me.labelsGroupHeaderSection.Name = "labelsGroupHeaderSection"
        Me.labelsGroupHeaderSection.PrintOnEveryPage = True
        Me.labelsGroupHeaderSection.Style.Visible = False
        '
        'groupFooterSection
        '
        Me.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0372666120529175R)
        Me.groupFooterSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Panel1, Me.Panel3})
        Me.groupFooterSection.Name = "groupFooterSection"
        Me.groupFooterSection.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.groupFooterSection.Style.Visible = True
        '
        'Panel1
        '
        FormattingRule1.Filters.Add(New Telerik.Reporting.Filter("=Fields.RENGLON", Telerik.Reporting.FilterOperator.Equal, "ACUMULADOS"))
        FormattingRule1.Style.Visible = False
        Me.Panel1.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.Panel1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox21, Me.TextBox16, Me.TextBox17, Me.TextBox18, Me.TextBox19, Me.TextBox20, Me.TextBox15, Me.TextBox28, Me.TextBox14})
        Me.Panel1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.067027881741523743R), Telerik.Reporting.Drawing.Unit.Cm(-0.00000026914807449429645R))
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.668050765991211R), Telerik.Reporting.Drawing.Unit.Cm(0.56091898679733276R))
        '
        'TextBox21
        '
        Me.TextBox21.Format = "{0:$#,##0}"
        Me.TextBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.81069278717041R), Telerik.Reporting.Drawing.Unit.Cm(0.00020105361181776971R))
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.19840669631958R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox21.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox21.Value = "= Sum(Fields.ValorTransadoMP)"
        '
        'TextBox16
        '
        Me.TextBox16.Format = "{0:$#,##0}"
        Me.TextBox16.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.1539583206176758R), Telerik.Reporting.Drawing.Unit.Cm(0.00020105361181776971R))
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2118425369262695R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox16.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox16.Value = "= Sum(Fields.ValorNominaMS)"
        '
        'TextBox17
        '
        Me.TextBox17.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0R), Telerik.Reporting.Drawing.Unit.Cm(0.00020105361181776971R))
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1298999786376953R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox17.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox17.Value = "Total"
        '
        'TextBox18
        '
        Me.TextBox18.Format = "{0:$#,##0}"
        Me.TextBox18.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.3660011291503906R), Telerik.Reporting.Drawing.Unit.Cm(0.00020105361181776971R))
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.203498363494873R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox18.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox18.Value = "= Sum(Fields.[Valor TransadoMS])"
        '
        'TextBox19
        '
        Me.TextBox19.Format = ""
        Me.TextBox19.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.569700241088867R), Telerik.Reporting.Drawing.Unit.Cm(0.00020105361181776971R))
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0191760063171387R), Telerik.Reporting.Drawing.Unit.Cm(0.56071716547012329R))
        Me.TextBox19.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox19.Value = "= Sum(Fields.CantidadOperacionesMP)"
        '
        'TextBox20
        '
        Me.TextBox20.Format = "{0:$#,##0}"
        Me.TextBox20.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.6069917678833R), Telerik.Reporting.Drawing.Unit.Cm(0.00020105361181776971R))
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2035000324249268R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox20.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox20.Value = "= Sum(Fields.ValorNominaMP)"
        '
        'TextBox15
        '
        Me.TextBox15.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1301009654998779R), Telerik.Reporting.Drawing.Unit.Cm(0.00020105361181776971R))
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0236573219299316R), Telerik.Reporting.Drawing.Unit.Cm(0.56071716547012329R))
        Me.TextBox15.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox15.Value = "= Sum(Fields.CantidadOperacionesMS)"
        '
        'TextBox28
        '
        Me.TextBox28.Format = "{0:$#,##0}"
        Me.TextBox28.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(21.46455192565918R), Telerik.Reporting.Drawing.Unit.Cm(0.00020266849605832249R))
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.203498363494873R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox28.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox28.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox28.Value = "=Sum(Fields.[Valor TransadoMS]) + Sum(Fields.ValorTransadoMP)"
        '
        'TextBox14
        '
        Me.TextBox14.Format = "{0:N2}"
        Me.TextBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.02458381652832R), Telerik.Reporting.Drawing.Unit.Cm(0.00020239935838617384R))
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4397709369659424R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox14.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.Value = "=sum(Fields.CantidadOperacionesMP) + sum(Fields.CantidadOperacionesMS)"
        '
        'Panel3
        '
        FormattingRule2.Filters.Add(New Telerik.Reporting.Filter("=Fields.RENGLON", Telerik.Reporting.FilterOperator.Equal, "OPERACIONES"))
        FormattingRule2.Style.Visible = False
        Me.Panel3.ConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule2})
        Me.Panel3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.066924728453159332R), Telerik.Reporting.Drawing.Unit.Cm(0.69860297441482544R))
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(24.668153762817383R), Telerik.Reporting.Drawing.Unit.Cm(0.33866351842880249R))
        '
        'groupHeaderSection
        '
        Me.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Cm(2.0105335712432861R)
        Me.groupHeaderSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox29, Me.TextBox32, Me.TextBox33, Me.TextBox47, Me.TextBox48, Me.TextBox52, Me.TextBox53, Me.TextBox54, Me.TextBox56, Me.TextBox5, Me.TextBox9})
        Me.groupHeaderSection.Name = "groupHeaderSection"
        Me.groupHeaderSection.Style.Visible = True
        '
        'TextBox29
        '
        Me.TextBox29.CanGrow = True
        Me.TextBox29.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(21.531482696533203R), Telerik.Reporting.Drawing.Unit.Cm(1.0159997940063477R))
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2035953998565674R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox29.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox29.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox29.Style.Font.Bold = False
        Me.TextBox29.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox29.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox29.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox29.StyleName = "Caption"
        Me.TextBox29.Value = "Transado (DOP)"
        '
        'TextBox32
        '
        Me.TextBox32.CanGrow = True
        Me.TextBox32.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.636626243591309R), Telerik.Reporting.Drawing.Unit.Cm(0.031550075858831406R))
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.4393987655639648R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox32.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox32.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox32.Style.Font.Bold = False
        Me.TextBox32.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox32.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox32.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox32.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox32.StyleName = "Caption"
        Me.TextBox32.Value = "Mercado Primario"
        '
        'TextBox33
        '
        Me.TextBox33.CanGrow = True
        Me.TextBox33.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1868367195129395R), Telerik.Reporting.Drawing.Unit.Cm(0.031550075858831406R))
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.4495887756347656R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox33.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox33.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox33.Style.Font.Bold = False
        Me.TextBox33.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox33.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox33.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox33.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox33.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox33.StyleName = "Caption"
        Me.TextBox33.Value = "Mercado Secundario (DOP)"
        '
        'TextBox47
        '
        Me.TextBox47.CanGrow = True
        Me.TextBox47.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.631526947021484R), Telerik.Reporting.Drawing.Unit.Cm(1.0159997940063477R))
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320014953613281R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox47.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox47.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox47.Style.Font.Bold = False
        Me.TextBox47.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox47.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox47.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox47.StyleName = "Caption"
        Me.TextBox47.Value = "Cant. Oper"
        '
        'TextBox48
        '
        Me.TextBox48.CanGrow = True
        Me.TextBox48.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.663727760314941R), Telerik.Reporting.Drawing.Unit.Cm(1.0159997940063477R))
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2034986019134521R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox48.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox48.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox48.Style.Font.Bold = False
        Me.TextBox48.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox48.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox48.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox48.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox48.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox48.StyleName = "Caption"
        Me.TextBox48.Value = "Valor Nominal (DOP)"
        '
        'TextBox52
        '
        Me.TextBox52.CanGrow = True
        Me.TextBox52.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.872525215148926R), Telerik.Reporting.Drawing.Unit.Cm(1.0159997940063477R))
        Me.TextBox52.Name = "TextBox52"
        Me.TextBox52.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2034986019134521R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox52.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox52.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox52.Style.Font.Bold = False
        Me.TextBox52.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox52.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox52.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox52.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox52.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox52.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox52.StyleName = "Caption"
        Me.TextBox52.Value = "Valor Transado (DOP)"
        '
        'TextBox53
        '
        Me.TextBox53.CanGrow = True
        Me.TextBox53.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.422736644744873R), Telerik.Reporting.Drawing.Unit.Cm(1.0159997940063477R))
        Me.TextBox53.Name = "TextBox53"
        Me.TextBox53.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2034986019134521R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox53.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox53.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox53.Style.Font.Bold = False
        Me.TextBox53.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox53.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox53.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox53.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox53.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox53.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox53.StyleName = "Caption"
        Me.TextBox53.Value = "Valor Transado (DOP)"
        '
        'TextBox54
        '
        Me.TextBox54.CanGrow = True
        Me.TextBox54.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.2190380096435547R), Telerik.Reporting.Drawing.Unit.Cm(1.0159997940063477R))
        Me.TextBox54.Name = "TextBox54"
        Me.TextBox54.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.2034986019134521R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox54.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox54.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox54.Style.Font.Bold = False
        Me.TextBox54.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox54.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox54.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox54.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox54.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox54.StyleName = "Caption"
        Me.TextBox54.Value = "Valor Nominal"
        '
        'TextBox56
        '
        Me.TextBox56.CanGrow = True
        Me.TextBox56.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1862273216247559R), Telerik.Reporting.Drawing.Unit.Cm(1.0159997940063477R))
        Me.TextBox56.Name = "TextBox56"
        Me.TextBox56.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320014953613281R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox56.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox56.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox56.Style.Font.Bold = False
        Me.TextBox56.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox56.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox56.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox56.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox56.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox56.StyleName = "Caption"
        Me.TextBox56.Value = "Cant. Oper"
        '
        'TextBox5
        '
        Me.TextBox5.CanGrow = True
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.076223373413086R), Telerik.Reporting.Drawing.Unit.Cm(1.0157991647720337R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4550602436065674R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.Font.Bold = False
        Me.TextBox5.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox5.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = "Caption"
        Me.TextBox5.Value = "Operaciones"
        '
        'TextBox9
        '
        Me.TextBox9.CanGrow = True
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.076223373413086R), Telerik.Reporting.Drawing.Unit.Cm(0.031550075858831406R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(5.65885591506958R), Telerik.Reporting.Drawing.Unit.Cm(0.70908337831497192R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.TextBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox9.Style.Font.Bold = False
        Me.TextBox9.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox9.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox9.StyleName = "Caption"
        Me.TextBox9.Value = "Total Cant. Operaciones & Valor Transado"
        '
        'pageHeader
        '
        Me.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(2.0320000648498535R)
        Me.pageHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.TextBox1, Me.PictureBox2})
        Me.pageHeader.Name = "pageHeader"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R), Telerik.Reporting.Drawing.Unit.Inch(0.19795602560043335R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.0791668891906738R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox2.Style.Color = System.Drawing.Color.Black
        Me.TextBox2.Style.Font.Bold = False
        Me.TextBox2.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Title"
        Me.TextBox2.Value = "Resumen de las Operaciones Mercado Primario y Secundario"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R), Telerik.Reporting.Drawing.Unit.Inch(0.000039365557313431054R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.1668152809143066R), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.StyleName = "Title"
        Me.TextBox1.Value = "Bolsa y Mercados de Valores de la República Dominicana"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.5964736938476562R), Telerik.Reporting.Drawing.Unit.Inch(0.000039365557313431054R))
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
        Me.TextBox81.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.7926602363586426R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4525356292724609R), Telerik.Reporting.Drawing.Unit.Inch(0.14791645109653473R))
        Me.pageInfoTextBox.Style.Font.Name = "Microsoft Sans Serif"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'reportHeader
        '
        Me.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(0.838100254535675R)
        Me.reportHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox38, Me.TextBox37})
        Me.reportHeader.Name = "reportHeader"
        '
        'TextBox38
        '
        Me.TextBox38.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.43133187294006348R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.63010567426681519R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox38.Style.Font.Bold = True
        Me.TextBox38.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox38.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox38.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox38.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox38.Value = "Fecha:"
        '
        'TextBox37
        '
        Me.TextBox37.Format = "{0:d}"
        Me.TextBox37.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.0055418014526367R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5372557640075684R), Telerik.Reporting.Drawing.Unit.Inch(0.17000000178813934R))
        Me.TextBox37.Style.Font.Name = "Microsoft Sans Serif"
        Me.TextBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox37.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox37.Value = "= Parameters.fecha.Value"
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.5079994797706604R)
        Me.reportFooter.Name = "reportFooter"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.560817301273346R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox10, Me.TextBox11, Me.TextBox12, Me.TextBox6, Me.TextBox8, Me.TextBox3, Me.TextBox7, Me.TextBox27, Me.TextBox13})
        Me.detail.Name = "detail"
        Me.detail.Style.Visible = True
        '
        'TextBox10
        '
        Me.TextBox10.Format = "{0:$#,##0}"
        Me.TextBox10.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(15.877820014953613R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.203498363494873R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox10.Value = "= Fields.ValorTransadoMP"
        '
        'TextBox11
        '
        Me.TextBox11.Format = "{0:$#,##0}"
        Me.TextBox11.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(12.674120903015137R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.203498363494873R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.Value = "= Fields.ValorNominaMP"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(10.63682746887207R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320014953613281R), Telerik.Reporting.Drawing.Unit.Cm(0.56071716547012329R))
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox12.Value = "= Fields.CantidadOperacionesMP"
        '
        'TextBox6
        '
        Me.TextBox6.Format = "{0:$#,##0}"
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(7.4331283569335938R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.203498363494873R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox6.Value = "= Fields.[Valor TransadoMS]"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.067127950489521027R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1298999786376953R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.Value = "=Fields.mone_trans"
        '
        'TextBox3
        '
        Me.TextBox3.Format = "{0:$#,##0}"
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.2294297218322754R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.203498363494873R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.Value = "= Fields.ValorNominaMS"
        '
        'TextBox7
        '
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.1972281932830811R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320014953613281R), Telerik.Reporting.Drawing.Unit.Cm(0.56071716547012329R))
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.Value = "= Fields.CantidadOperacionesMS"
        '
        'TextBox27
        '
        Me.TextBox27.Format = "{0:$#,##0}"
        Me.TextBox27.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(21.531482696533203R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(3.203498363494873R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox27.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox27.Value = "= Fields.[Valor TransadoMS]+ Fields.ValorTransadoMP"
        '
        'TextBox13
        '
        Me.TextBox13.Format = "{0:N2}"
        Me.TextBox13.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(19.091611862182617R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.43967342376709R), Telerik.Reporting.Drawing.Unit.Cm(0.56071633100509644R))
        Me.TextBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        Me.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox13.Value = "=Fields.CantidadOperacionesMP + Fields.CantidadOperacionesMS"
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.ConnectionString = "MyReportLib.My.MySettings.CN"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        Me.SqlDataSource1.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@Fecha", System.Data.DbType.DateTime, "=Parameters.fecha.Value")})
        Me.SqlDataSource1.SelectCommand = "SPC_REPORTE_OPERACIONES_DIARIAS"
        Me.SqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'ReporteAcumuladosOperacionesDetalle
        '
        Me.DataSource = Me.SqlDataSource1
        Group1.GroupFooter = Me.labelsGroupFooterSection
        Group1.GroupHeader = Me.labelsGroupHeaderSection
        Group1.Name = "labelsGroup"
        Group2.GroupFooter = Me.groupFooterSection
        Group2.GroupHeader = Me.groupHeaderSection
        Group2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.RENGLON"))
        Group2.GroupKeepTogether = Telerik.Reporting.GroupKeepTogether.All
        Group2.Name = "group"
        Group2.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.RENGLON", Telerik.Reporting.SortDirection.Desc))
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1, Group2})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.labelsGroupHeaderSection, Me.labelsGroupFooterSection, Me.groupHeaderSection, Me.groupFooterSection, Me.pageHeader, Me.pageFooter, Me.reportHeader, Me.reportFooter, Me.detail})
        Me.Name = "ReporteAcumuladosOperacionesDetalle"
        Me.PageSettings.Landscape = True
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "fecha"
        ReportParameter1.Text = "Fecha"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "= Today()"
        ReportParameter1.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
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
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(24.735078811645508R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeader As Telerik.Reporting.PageHeaderSection
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
    Friend WithEvents reportHeader As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents SqlDataSource1 As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents groupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents groupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents labelsGroupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents labelsGroupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents Panel1 As Telerik.Reporting.Panel
    Friend WithEvents TextBox28 As Telerik.Reporting.TextBox
    Friend WithEvents Panel3 As Telerik.Reporting.Panel
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox29 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox32 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox33 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox47 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox48 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox52 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox53 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox54 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox56 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox22 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox23 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox34 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox36 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox38 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox37 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox35 As Telerik.Reporting.TextBox
End Class