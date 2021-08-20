Partial Class BB_BoletinPortada

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BB_BoletinPortada))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.SqlBoletinConfiguracion = New Telerik.Reporting.SqlDataSource()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.PictureBox3 = New Telerik.Reporting.PictureBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.HtmlTextBox1 = New Telerik.Reporting.HtmlTextBox()
        Me.HtmlTextBox2 = New Telerik.Reporting.HtmlTextBox()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.PictureBox5 = New Telerik.Reporting.PictureBox()
        Me.PictureBox6 = New Telerik.Reporting.PictureBox()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlBoletinConfiguracion
        '
        Me.SqlBoletinConfiguracion.ConnectionString = "CN"
        Me.SqlBoletinConfiguracion.Name = "SqlBoletinConfiguracion"
        Me.SqlBoletinConfiguracion.SelectCommand = "SELECT        BoletinConfiguracionID, Descripcion, PrecioEnListaDePrecios, TopTit" &
    "ulosMasTransados, FechaCreacion" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            vBoletinConfiguracion"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(21.530345916748047R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.PictureBox3, Me.TextBox4, Me.HtmlTextBox1, Me.HtmlTextBox2, Me.Table1, Me.PictureBox1})
        Me.detail.Name = "detail"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7940001487731934R), Telerik.Reporting.Drawing.Unit.Cm(3.4963529109954834R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.017999649047852R), Telerik.Reporting.Drawing.Unit.Cm(2.0320000648498535R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox2.Style.Color = System.Drawing.Color.White
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(26.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.Value = "Boletín Bursátil"
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7940001487731934R), Telerik.Reporting.Drawing.Unit.Cm(6.036353588104248R))
        Me.PictureBox3.MimeType = "image/png"
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.017999649047852R), Telerik.Reporting.Drawing.Unit.Cm(1.5237990617752075R))
        Me.PictureBox3.Value = CType(resources.GetObject("PictureBox3.Value"), Object)
        '
        'TextBox4
        '
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7940001487731934R), Telerik.Reporting.Drawing.Unit.Cm(5.5285534858703613R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.017999649047852R), Telerik.Reporting.Drawing.Unit.Cm(0.50800031423568726R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(146, Byte), Integer))
        Me.TextBox4.Style.Color = System.Drawing.Color.White
        Me.TextBox4.Style.Font.Name = "Tahoma"
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.Value = resources.GetString("TextBox4.Value")
        '
        'HtmlTextBox1
        '
        Me.HtmlTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7940001487731934R), Telerik.Reporting.Drawing.Unit.Cm(8.0683526992797852R))
        Me.HtmlTextBox1.Name = "HtmlTextBox1"
        Me.HtmlTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.018001556396484R), Telerik.Reporting.Drawing.Unit.Cm(5.3340005874633789R))
        Me.HtmlTextBox1.Value = resources.GetString("HtmlTextBox1.Value")
        '
        'HtmlTextBox2
        '
        Me.HtmlTextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7940001487731934R), Telerik.Reporting.Drawing.Unit.Cm(14.164353370666504R))
        Me.HtmlTextBox2.Name = "HtmlTextBox2"
        Me.HtmlTextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.017999649047852R), Telerik.Reporting.Drawing.Unit.Cm(1.5237990617752075R))
        Me.HtmlTextBox2.Value = "<p style=""text-align: center""><strong><span style=""font-size: 16pt"">¨BVRD, por un" &
    " mercado de valores más Transparente, Equitativo y Eficiente!¨</span></strong></" &
    "p>"
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.392085075378418R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(6.2018346786499023R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.4291243553161621R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(4.0639991760253906R)))
        Me.Table1.Body.SetCellContent(0, 1, Me.PictureBox2)
        Me.Table1.Body.SetCellContent(0, 2, Me.PictureBox5)
        Me.Table1.Body.SetCellContent(0, 0, Me.PictureBox6)
        TableGroup1.Name = "group"
        TableGroup2.Name = "tableGroup"
        TableGroup3.Name = "tableGroup2"
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup2)
        Me.Table1.ColumnGroups.Add(TableGroup3)
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.PictureBox6, Me.PictureBox2, Me.PictureBox5})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.7940001487731934R), Telerik.Reporting.Drawing.Unit.Cm(16.704353332519531R))
        Me.Table1.Name = "Table1"
        TableGroup4.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup4.Name = "detailTableGroup"
        Me.Table1.RowGroups.Add(TableGroup4)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(17.023044586181641R), Telerik.Reporting.Drawing.Unit.Cm(4.0639991760253906R))
        '
        'PictureBox2
        '
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.2018342018127441R), Telerik.Reporting.Drawing.Unit.Cm(4.0639991760253906R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox2.StyleName = ""
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'PictureBox5
        '
        Me.PictureBox5.MimeType = "image/png"
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.4291243553161621R), Telerik.Reporting.Drawing.Unit.Cm(4.0639991760253906R))
        Me.PictureBox5.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox5.StyleName = ""
        Me.PictureBox5.Value = CType(resources.GetObject("PictureBox5.Value"), Object)
        '
        'PictureBox6
        '
        Me.PictureBox6.MimeType = "image/png"
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(6.3920841217041016R), Telerik.Reporting.Drawing.Unit.Cm(4.0639991760253906R))
        Me.PictureBox6.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox6.StyleName = ""
        Me.PictureBox6.Value = CType(resources.GetObject("PictureBox6.Value"), Object)
        '
        'PictureBox1
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox1.Action = NavigateToBookmarkAction1
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579R), Telerik.Reporting.Drawing.Unit.Inch(0.66921615600585938R))
        Me.PictureBox1.MimeType = "image/png"
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7925002574920654R), Telerik.Reporting.Drawing.Unit.Inch(0.70722222328186035R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox1.Style.BackgroundImage.MimeType = ""
        Me.PictureBox1.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox1.Style.Visible = True
        Me.PictureBox1.Value = CType(resources.GetObject("PictureBox1.Value"), Object)
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.70235377550125122R)
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.47139981389045715R)
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'BB_BoletinPortada
        '
        Me.DocumentMapText = "Portada"
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "BoletinPortada"
        Me.PageSettings.Landscape = false
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Pixel(0.10000000149011612R), Telerik.Reporting.Drawing.Unit.Pixel(0.10000000149011612R), Telerik.Reporting.Drawing.Unit.Pixel(0.25R), Telerik.Reporting.Drawing.Unit.Pixel(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaOperacion"
        ReportParameter1.Text = "Fecha Operación"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = true
        ReportParameter2.AvailableValues.DataSource = Me.SqlBoletinConfiguracion
        ReportParameter2.AvailableValues.DisplayMember = "= Fields.Descripcion"
        ReportParameter2.AvailableValues.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.Descripcion", Telerik.Reporting.SortDirection.Asc))
        ReportParameter2.AvailableValues.ValueMember = "= Fields.BoletinConfiguracionID"
        ReportParameter2.Name = "Configuracion"
        ReportParameter2.Text = "Configuración"
        ReportParameter2.Value = ""
        ReportParameter2.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Cm
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(21.576669692993164R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox3 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents SqlBoletinConfiguracion As Telerik.Reporting.SqlDataSource
    Friend WithEvents HtmlTextBox1 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents HtmlTextBox2 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents PictureBox5 As Telerik.Reporting.PictureBox
    Friend WithEvents PictureBox6 As Telerik.Reporting.PictureBox
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
End Class