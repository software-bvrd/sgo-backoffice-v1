Partial Class ReporteUltimas10TasasCambio
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReporteUltimas10TasasCambio))
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.fechaLicenciaCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.fechaLicenciaSIVCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.nombreCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.pageHeader = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.reportHeader = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.fechaLicenciaDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.nombreDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.fechaLicenciaSIVDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.SqlConsultaUltimas10Tasas = New Telerik.Reporting.SqlDataSource()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'fechaLicenciaCaptionTextBox
        '
        Me.fechaLicenciaCaptionTextBox.CanGrow = True
        Me.fechaLicenciaCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5001997947692871R), Telerik.Reporting.Drawing.Unit.Cm(0.56779962778091431R))
        Me.fechaLicenciaCaptionTextBox.Name = "fechaLicenciaCaptionTextBox"
        Me.fechaLicenciaCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.1000001430511475R), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433R))
        Me.fechaLicenciaCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White
        Me.fechaLicenciaCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaCaptionTextBox.Style.Font.Bold = True
        Me.fechaLicenciaCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.fechaLicenciaCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaCaptionTextBox.StyleName = "Caption"
        Me.fechaLicenciaCaptionTextBox.Value = "Tasa Compra"
        '
        'fechaLicenciaSIVCaptionTextBox
        '
        Me.fechaLicenciaSIVCaptionTextBox.CanGrow = True
        Me.fechaLicenciaSIVCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.532200813293457R), Telerik.Reporting.Drawing.Unit.Cm(0.56779962778091431R))
        Me.fechaLicenciaSIVCaptionTextBox.Name = "fechaLicenciaSIVCaptionTextBox"
        Me.fechaLicenciaSIVCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0677998065948486R), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433R))
        Me.fechaLicenciaSIVCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White
        Me.fechaLicenciaSIVCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaSIVCaptionTextBox.Style.Font.Bold = True
        Me.fechaLicenciaSIVCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaSIVCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaSIVCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.fechaLicenciaSIVCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaSIVCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fechaLicenciaSIVCaptionTextBox.StyleName = "Caption"
        Me.fechaLicenciaSIVCaptionTextBox.Value = "Tasa Venta"
        '
        'nombreCaptionTextBox
        '
        Me.nombreCaptionTextBox.CanGrow = True
        Me.nombreCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.05291656032204628R), Telerik.Reporting.Drawing.Unit.Cm(0.56779962778091431R))
        Me.nombreCaptionTextBox.Name = "nombreCaptionTextBox"
        Me.nombreCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4470829963684082R), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433R))
        Me.nombreCaptionTextBox.Style.BackgroundColor = System.Drawing.Color.White
        Me.nombreCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.nombreCaptionTextBox.Style.Font.Bold = True
        Me.nombreCaptionTextBox.Style.Font.Name = "Arial Narrow"
        Me.nombreCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.nombreCaptionTextBox.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0.20000000298023224R)
        Me.nombreCaptionTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.nombreCaptionTextBox.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.nombreCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.nombreCaptionTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.nombreCaptionTextBox.StyleName = "Caption"
        Me.nombreCaptionTextBox.Value = "Fecha"
        '
        'pageHeader
        '
        Me.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(2.2999999523162842R)
        Me.pageHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.TextBox1, Me.TextBox5, Me.TextBox3, Me.PictureBox2})
        Me.pageHeader.Name = "pageHeader"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2155638933181763R), Telerik.Reporting.Drawing.Unit.Inch(0.18962268531322479R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2999603748321533R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox2.Style.Color = System.Drawing.Color.Black
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Arial Narrow"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.StyleName = "Title"
        Me.TextBox2.Value = "Tasa de Cambio Promedio de los Ultimos 10 días"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2155641317367554R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.6663260459899902R), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463R))
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
        'TextBox5
        '
        Me.TextBox5.Format = "{0:d}"
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.9685039520263672R), Telerik.Reporting.Drawing.Unit.Inch(0.38962265849113464R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0373290777206421R), Telerik.Reporting.Drawing.Unit.Inch(0.19992130994796753R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox5.Style.Color = System.Drawing.Color.Black
        Me.TextBox5.Style.Font.Bold = True
        Me.TextBox5.Style.Font.Name = "Arial Narrow"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = "Title"
        Me.TextBox5.Value = "= Fields.Fecha"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.0875322818756104R), Telerik.Reporting.Drawing.Unit.Cm(1.0081840753555298R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(1.7470831871032715R), Telerik.Reporting.Drawing.Unit.Cm(0.576000452041626R))
        Me.TextBox3.Style.Font.Bold = True
        Me.TextBox3.Style.Font.Name = "Arial Narrow"
        Me.TextBox3.Value = "Para el dia"
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.034461498260498047R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0999606847763062R), Telerik.Reporting.Drawing.Unit.Inch(0.66654872894287109R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'pageFooter
        '
        Me.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.37570777535438538R)
        Me.pageFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageInfoTextBox})
        Me.pageFooter.Name = "pageFooter"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.347464919090271R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1328500509262085R), Telerik.Reporting.Drawing.Unit.Inch(0.14791645109653473R))
        Me.pageInfoTextBox.Style.Font.Name = "Arial Narrow"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(8.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'reportHeader
        '
        Me.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Cm(1.0678999423980713R)
        Me.reportHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox7, Me.TextBox6, Me.nombreCaptionTextBox, Me.fechaLicenciaCaptionTextBox, Me.fechaLicenciaSIVCaptionTextBox})
        Me.reportHeader.Name = "reportHeader"
        '
        'TextBox7
        '
        Me.TextBox7.CanGrow = True
        Me.TextBox7.Format = "{0:N4}"
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.50019907951355R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320014953613281R), Telerik.Reporting.Drawing.Unit.Cm(0.56799989938735962R))
        Me.TextBox7.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.Color = System.Drawing.Color.Navy
        Me.TextBox7.Style.Font.Bold = True
        Me.TextBox7.Style.Font.Name = "Arial Narrow"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox7.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox7.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.25R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox7.StyleName = "Caption"
        Me.TextBox7.Value = "= Fields.TPCV10"
        '
        'TextBox6
        '
        Me.TextBox6.CanGrow = True
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052916664630174637R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4470829963684082R), Telerik.Reporting.Drawing.Unit.Cm(0.56799989938735962R))
        Me.TextBox6.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.Font.Bold = True
        Me.TextBox6.Style.Font.Name = "Arial Narrow"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.TextBox6.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Cm(0.5R)
        Me.TextBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox6.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.StyleName = "Caption"
        Me.TextBox6.Value = "Tasa Prom. C/V 10"
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Cm(0.50789940357208252R)
        Me.reportFooter.Name = "reportFooter"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.4616081714630127R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.fechaLicenciaDataTextBox1, Me.nombreDataTextBox1, Me.fechaLicenciaSIVDataTextBox1})
        Me.detail.Name = "detail"
        '
        'fechaLicenciaDataTextBox1
        '
        Me.fechaLicenciaDataTextBox1.CanGrow = True
        Me.fechaLicenciaDataTextBox1.Format = "{0:N4}"
        Me.fechaLicenciaDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5001997947692871R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.fechaLicenciaDataTextBox1.Name = "fechaLicenciaDataTextBox1"
        Me.fechaLicenciaDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0320007801055908R), Telerik.Reporting.Drawing.Unit.Cm(0.46150806546211243R))
        Me.fechaLicenciaDataTextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.fechaLicenciaDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaDataTextBox1.Style.Color = System.Drawing.Color.Black
        Me.fechaLicenciaDataTextBox1.Style.Font.Bold = False
        Me.fechaLicenciaDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaDataTextBox1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.fechaLicenciaDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaDataTextBox1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.25R)
        Me.fechaLicenciaDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.fechaLicenciaDataTextBox1.StyleName = "Data"
        Me.fechaLicenciaDataTextBox1.Value = "= Fields.TasaCompra"
        '
        'nombreDataTextBox1
        '
        Me.nombreDataTextBox1.CanGrow = True
        Me.nombreDataTextBox1.Format = "{0:d}"
        Me.nombreDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.052916459739208221R), Telerik.Reporting.Drawing.Unit.Cm(0R))
        Me.nombreDataTextBox1.Name = "nombreDataTextBox1"
        Me.nombreDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.4470834732055664R), Telerik.Reporting.Drawing.Unit.Cm(0.46160820126533508R))
        Me.nombreDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.nombreDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.nombreDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.nombreDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0.10000000149011612R)
        Me.nombreDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.nombreDataTextBox1.StyleName = "Data"
        Me.nombreDataTextBox1.Value = "= Fields.Fecha"
        '
        'fechaLicenciaSIVDataTextBox1
        '
        Me.fechaLicenciaSIVDataTextBox1.CanGrow = True
        Me.fechaLicenciaSIVDataTextBox1.Format = "{0:N4}"
        Me.fechaLicenciaSIVDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.5324010848999023R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.fechaLicenciaSIVDataTextBox1.Name = "fechaLicenciaSIVDataTextBox1"
        Me.fechaLicenciaSIVDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(2.0675995349884033R), Telerik.Reporting.Drawing.Unit.Cm(0.46150806546211243R))
        Me.fechaLicenciaSIVDataTextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.fechaLicenciaSIVDataTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.fechaLicenciaSIVDataTextBox1.Style.Color = System.Drawing.Color.Black
        Me.fechaLicenciaSIVDataTextBox1.Style.Font.Bold = False
        Me.fechaLicenciaSIVDataTextBox1.Style.Font.Name = "Arial Narrow"
        Me.fechaLicenciaSIVDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Pixel(10.0R)
        Me.fechaLicenciaSIVDataTextBox1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        Me.fechaLicenciaSIVDataTextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Cm(0R)
        Me.fechaLicenciaSIVDataTextBox1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Cm(0.25R)
        Me.fechaLicenciaSIVDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.fechaLicenciaSIVDataTextBox1.StyleName = "Data"
        Me.fechaLicenciaSIVDataTextBox1.Value = "= Fields.TasaVenta"
        '
        'SqlConsultaUltimas10Tasas
        '
        Me.SqlConsultaUltimas10Tasas.ConnectionString = "CN"
        Me.SqlConsultaUltimas10Tasas.Name = "SqlConsultaUltimas10Tasas"
        Me.SqlConsultaUltimas10Tasas.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@Fecha", System.Data.DbType.[Date], "= Parameters.Fecha.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Simbolo", System.Data.DbType.StringFixedLength, "= Parameters.Simbolo.Value")})
        Me.SqlConsultaUltimas10Tasas.SelectCommand = "dbo.SP_ReporteUltimas10Tasas"
        Me.SqlConsultaUltimas10Tasas.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'ReporteUltimas10TasasCambio
        '
        Me.DataSource = Me.SqlConsultaUltimas10Tasas
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeader, Me.pageFooter, Me.reportHeader, Me.reportFooter, Me.detail})
        Me.Name = "ReporteUltimas10TasasCambio"
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        ReportParameter1.Name = "Fecha"
        ReportParameter1.Text = "Fecha"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = True
        ReportParameter2.Name = "Simbolo"
        ReportParameter2.Value = "USD"
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
    Friend WithEvents fechaLicenciaCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaSIVCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents nombreCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents pageHeader As Telerik.Reporting.PageHeaderSection
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
    Friend WithEvents reportHeader As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents fechaLicenciaDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents fechaLicenciaSIVDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents nombreDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents SqlConsultaUltimas10Tasas As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class