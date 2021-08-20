Partial Class VolumenNegociadoActividadEconomicaMercadoPrimarioSecundario
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VolumenNegociadoActividadEconomicaMercadoPrimarioSecundario))
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim Group2 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.GroupFooterSection1 = New Telerik.Reporting.GroupFooterSection()
        Me.GroupHeaderSection1 = New Telerik.Reporting.GroupHeaderSection()
        Me.TextBox28 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.GroupFooterSection2 = New Telerik.Reporting.GroupFooterSection()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.GroupHeaderSection2 = New Telerik.Reporting.GroupHeaderSection()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox22 = New Telerik.Reporting.TextBox()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.titleTextBox = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario = New Telerik.Reporting.SqlDataSource()
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        '
        'GroupFooterSection1
        '
        Me.GroupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.GroupFooterSection1.Name = "GroupFooterSection1"
        '
        'GroupHeaderSection1
        '
        Me.GroupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463R)
        Me.GroupHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox28, Me.TextBox27, Me.TextBox26, Me.TextBox25, Me.TextBox24})
        Me.GroupHeaderSection1.Name = "GroupHeaderSection1"
        '
        'TextBox28
        '
        Me.TextBox28.Format = "{0}"
        Me.TextBox28.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7373793125152588R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox28.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.TextBox28.Style.Color = System.Drawing.Color.White
        Me.TextBox28.Style.Font.Bold = true
        Me.TextBox28.Style.Font.Name = "Arial Narrow"
        Me.TextBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox28.Value = "ACTIVIDAD ECONOMICA/ENTIDAD"
        '
        'TextBox27
        '
        Me.TextBox27.Format = "{0}"
        Me.TextBox27.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7374975681304932R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4319442510604858R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox27.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.TextBox27.Style.Color = System.Drawing.Color.White
        Me.TextBox27.Style.Font.Bold = true
        Me.TextBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox27.Value = "MP"
        '
        'TextBox26
        '
        Me.TextBox26.Format = "{0}"
        Me.TextBox26.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1749973297119141R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4319442510604858R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox26.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.TextBox26.Style.Color = System.Drawing.Color.White
        Me.TextBox26.Style.Font.Bold = true
        Me.TextBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox26.Value = "MS"
        '
        'TextBox25
        '
        Me.TextBox25.Format = "{0}"
        Me.TextBox25.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6151943206787109R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8173633813858032R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox25.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.TextBox25.Style.Color = System.Drawing.Color.White
        Me.TextBox25.Style.Font.Bold = true
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.Value = "Total Transado"
        '
        'TextBox24
        '
        Me.TextBox24.Format = "{0}"
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.4326376914978027R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56388825178146362R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox24.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.TextBox24.Style.Color = System.Drawing.Color.White
        Me.TextBox24.Style.Font.Bold = true
        Me.TextBox24.Style.Font.Name = "Arial Narrow"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11R)
        Me.TextBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.Value = "%"
        '
        'GroupFooterSection2
        '
        Me.GroupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20698399841785431R)
        Me.GroupFooterSection2.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7})
        Me.GroupFooterSection2.Name = "GroupFooterSection2"
        '
        'TextBox3
        '
        Me.TextBox3.Format = "{0:P2}"
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.4290871620178223R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56388825178146362R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox3.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox3.Style.Color = System.Drawing.Color.Black
        Me.TextBox3.Style.Font.Bold = true
        Me.TextBox3.Style.Font.Name = "Arial Narrow"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.Value = "= Sum(Fields.ProcentajeEntidad)"
        '
        'TextBox4
        '
        Me.TextBox4.Format = "{0:N2}"
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6116461753845215R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8173633813858032R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox4.Style.Color = System.Drawing.Color.Black
        Me.TextBox4.Style.Font.Bold = true
        Me.TextBox4.Style.Font.Name = "Arial Narrow"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.Value = "= Sum(Fields.TotalTransado)"
        '
        'TextBox5
        '
        Me.TextBox5.Format = "{0:N2}"
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1749973297119141R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4319442510604858R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox5.Style.Color = System.Drawing.Color.Black
        Me.TextBox5.Style.Font.Bold = true
        Me.TextBox5.Style.Font.Name = "Arial Narrow"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.Value = "= Sum(Fields.MS)"
        '
        'TextBox6
        '
        Me.TextBox6.Format = "{0:N2}"
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7374975681304932R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4319442510604858R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox6.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox6.Style.Color = System.Drawing.Color.Black
        Me.TextBox6.Style.Font.Bold = true
        Me.TextBox6.Style.Font.Name = "Arial Narrow"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.Value = "= Sum(Fields.MP)"
        '
        'TextBox7
        '
        Me.TextBox7.Format = "{0}"
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7373793125152588R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox7.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox7.Style.Color = System.Drawing.Color.Black
        Me.TextBox7.Style.Font.Bold = true
        Me.TextBox7.Style.Font.Name = "Arial Narrow"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox7.Value = "Total {Fields.ActividadEconomica}"
        '
        'GroupHeaderSection2
        '
        Me.GroupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179R)
        Me.GroupHeaderSection2.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.TextBox22})
        Me.GroupHeaderSection2.Name = "GroupHeaderSection2"
        '
        'TextBox2
        '
        Me.TextBox2.Format = "{0}"
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.4325194358825684R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149,Byte),Integer), CType(CType(179,Byte),Integer), CType(CType(215,Byte),Integer))
        Me.TextBox2.Style.Color = System.Drawing.Color.Black
        Me.TextBox2.Style.Font.Bold = true
        Me.TextBox2.Style.Font.Name = "Arial Narrow"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.Value = "= Fields.ActividadEconomica"
        '
        'TextBox22
        '
        Me.TextBox22.Format = "{0:P2}"
        Me.TextBox22.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.4326376914978027R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56388825178146362R), Telerik.Reporting.Drawing.Unit.Inch(0.19301626086235046R))
        Me.TextBox22.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149,Byte),Integer), CType(CType(179,Byte),Integer), CType(CType(215,Byte),Integer))
        Me.TextBox22.Style.Color = System.Drawing.Color.Black
        Me.TextBox22.Style.Font.Bold = true
        Me.TextBox22.Style.Font.Name = "Arial Narrow"
        Me.TextBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox22.Value = "= Fields.PorcentajeActividad"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.19301612675189972R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1, Me.TextBox14, Me.TextBox15, Me.TextBox19, Me.TextBox21})
        Me.detail.Name = "detail"
        Me.detail.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        '
        'TextBox1
        '
        Me.TextBox1.Format = "{0}"
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5374977588653564R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = false
        Me.TextBox1.Style.Font.Name = "Arial Narrow"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.Value = "= Fields.NombreEmisor"
        '
        'TextBox14
        '
        Me.TextBox14.Format = "{0:N2}"
        Me.TextBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7374975681304932R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4319442510604858R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox14.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.Color = System.Drawing.Color.Black
        Me.TextBox14.Style.Font.Bold = false
        Me.TextBox14.Style.Font.Name = "Arial Narrow"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.Value = "= Fields.MP"
        '
        'TextBox15
        '
        Me.TextBox15.Format = "{0:N2}"
        Me.TextBox15.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.1694416999816895R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4319442510604858R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox15.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox15.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox15.Style.Color = System.Drawing.Color.Black
        Me.TextBox15.Style.Font.Bold = false
        Me.TextBox15.Style.Font.Name = "Arial Narrow"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.Value = "= Fields.MS"
        '
        'TextBox19
        '
        Me.TextBox19.Format = "{0:N2}"
        Me.TextBox19.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6152744293212891R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8173633813858032R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox19.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox19.Style.Color = System.Drawing.Color.Black
        Me.TextBox19.Style.Font.Bold = false
        Me.TextBox19.Style.Font.Name = "Arial Narrow"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox19.Value = "= Fields.TotalTransado"
        '
        'TextBox21
        '
        Me.TextBox21.Format = "{0:P2}"
        Me.TextBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.4326376914978027R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.56388825178146362R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox21.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox21.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox21.Style.Color = System.Drawing.Color.Black
        Me.TextBox21.Style.Font.Bold = false
        Me.TextBox21.Style.Font.Name = "Arial Narrow"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox21.Value = "= Fields.ProcentajeEntidad"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003890991210938R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9937566518783569R), Telerik.Reporting.Drawing.Unit.Inch(0.19999949634075165R))
        Me.TextBox81.Style.Font.Name = "Arial Narrow"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.0479167699813843R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox30, Me.PictureBox2, Me.titleTextBox, Me.TextBox8})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:d}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3988723754882813R), Telerik.Reporting.Drawing.Unit.Inch(0.55497950315475464R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1260490417480469R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox30.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox30.Style.Color = System.Drawing.Color.Black
        Me.TextBox30.Style.Font.Bold = true
        Me.TextBox30.Style.Font.Name = "Arial Narrow"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.Value = "Desde el {ConvertirFechas.Formatdate(Parameters.FechaInicial.Value)} hasta el  {C"& _ 
    "onvertirFechas.Formatdate(Parameters.FechaFinal.Value)}"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.5250000953674316R), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4738327264785767R), Telerik.Reporting.Drawing.Unit.Inch(0.74791687726974487R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"),Object)
        '
        'titleTextBox
        '
        Me.titleTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3988723754882813R), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05R))
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1260490417480469R), Telerik.Reporting.Drawing.Unit.Inch(0.547877311706543R))
        Me.titleTextBox.Style.BackgroundColor = System.Drawing.Color.White
        Me.titleTextBox.Style.Color = System.Drawing.Color.Black
        Me.titleTextBox.Style.Font.Bold = true
        Me.titleTextBox.Style.Font.Name = "Arial Narrow"
        Me.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16R)
        Me.titleTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.titleTextBox.StyleName = "Title"
        Me.titleTextBox.Value = "Volúmenes Negociados por Actividad Económica "&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Mercado Primario y Secundario"
        '
        'TextBox8
        '
        Me.TextBox8.Format = "{0:d}"
        Me.TextBox8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3988723754882813R), Telerik.Reporting.Drawing.Unit.Inch(0.75494003295898438R))
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.1260490417480469R), Telerik.Reporting.Drawing.Unit.Inch(0.19297663867473602R))
        Me.TextBox8.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox8.Style.Color = System.Drawing.Color.Black
        Me.TextBox8.Style.Font.Bold = true
        Me.TextBox8.Style.Font.Name = "Arial Narrow"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.Value = "Valor en DOP"
        '
        'SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario
        '
        Me.SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario.ConnectionString = "CN"
        Me.SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario.Name = "SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario"
        Me.SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaInicio", System.Data.DbType.[Date], "=Parameters.FechaInicial.Value"), New Telerik.Reporting.SqlDataSourceParameter("@FechaFinal", System.Data.DbType.[Date], "=Parameters.FechaFinal.Value")})
        Me.SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario.SelectCommand = "dbo.SP_VolumenNegociadoActividadEconomicaMercadoPrimarioSecundario"
        Me.SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'VolumenNegociadoActividadEconomicaMercadoPrimarioSecundario
        '
        Me.DataSource = Me.SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario
        Group1.GroupFooter = Me.GroupFooterSection1
        Group1.GroupHeader = Me.GroupHeaderSection1
        Group1.Name = "Group1"
        Group2.GroupFooter = Me.GroupFooterSection2
        Group2.GroupHeader = Me.GroupHeaderSection2
        Group2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.ActividadEconomica"))
        Group2.Name = "Group2"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1, Group2})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.GroupHeaderSection1, Me.GroupFooterSection1, Me.GroupHeaderSection2, Me.GroupFooterSection2, Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "VolumenNegociadoActividadEconomicaMercadoPrimarioSecundario"
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
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(7.9999604225158691R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents titleTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents SqlVolumenNegociadoActividadEconomicaMercadoPrimarioSecundario As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents Group1 As Telerik.Reporting.Group
    Friend WithEvents GroupFooterSection1 As Telerik.Reporting.GroupFooterSection
    Friend WithEvents GroupHeaderSection1 As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents Group2 As Telerik.Reporting.Group
    Friend WithEvents GroupFooterSection2 As Telerik.Reporting.GroupFooterSection
    Friend WithEvents GroupHeaderSection2 As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox28 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox22 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
End Class