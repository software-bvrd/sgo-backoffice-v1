Partial Class FIAB_Mensual_Portada

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FIAB_Mensual_Portada))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.SqlConfiguracion = New Telerik.Reporting.SqlDataSource()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.HtmlTextBox1 = New Telerik.Reporting.HtmlTextBox()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.HtmlTextBox2 = New Telerik.Reporting.HtmlTextBox()
        Me.Table2 = New Telerik.Reporting.Table()
        Me.HtmlTextBox3 = New Telerik.Reporting.HtmlTextBox()
        Me.HtmlTextBox5 = New Telerik.Reporting.HtmlTextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.HtmlTextBox4 = New Telerik.Reporting.HtmlTextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'SqlConfiguracion
        '
        Me.SqlConfiguracion.ConnectionString = "CN"
        Me.SqlConfiguracion.Name = "SqlConfiguracion"
        Me.SqlConfiguracion.SelectCommand = "SELECT       *" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM        Configuracion"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(20.065900802612305R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.HtmlTextBox1, Me.Table1, Me.HtmlTextBox2, Me.Table2, Me.HtmlTextBox5})
        Me.detail.Name = "detail"
        '
        'HtmlTextBox1
        '
        Me.HtmlTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.2752944231033325R), Telerik.Reporting.Drawing.Unit.Cm(11.937899589538574R))
        Me.HtmlTextBox1.Name = "HtmlTextBox1"
        Me.HtmlTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(20.060705184936523R), Telerik.Reporting.Drawing.Unit.Cm(7.8740010261535645R))
        Me.HtmlTextBox1.Value = resources.GetString("HtmlTextBox1.Value")
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(12.953999519348145R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(4.0637998580932617R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.PictureBox2)
        TableGroup1.Name = "tableGroup"
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.PictureBox2})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.8260002136230469R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.Table1.Name = "Table1"
        TableGroup2.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup2.Name = "detailTableGroup"
        Me.Table1.RowGroups.Add(TableGroup2)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.953999519348145R), Telerik.Reporting.Drawing.Unit.Cm(4.0637998580932617R))
        '
        'PictureBox2
        '
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(12.953999519348145R), Telerik.Reporting.Drawing.Unit.Cm(4.0637998580932617R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox2.StyleName = ""
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'HtmlTextBox2
        '
        Me.HtmlTextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.8260002136230469R), Telerik.Reporting.Drawing.Unit.Cm(4.31790018081665R))
        Me.HtmlTextBox2.Name = "HtmlTextBox2"
        Me.HtmlTextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(13.208003044128418R), Telerik.Reporting.Drawing.Unit.Cm(0.76199966669082642R))
        Me.HtmlTextBox2.Value = resources.GetString("HtmlTextBox2.Value")
        '
        'Table2
        '
        Me.Table2.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(8.6360006332397461R)))
        Me.Table2.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(4.82580041885376R)))
        Me.Table2.Body.SetCellContent(0, 0, Me.HtmlTextBox3)
        TableGroup3.Name = "tableGroup2"
        Me.Table2.ColumnGroups.Add(TableGroup3)
        Me.Table2.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.HtmlTextBox3})
        Me.Table2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(6.8580002784729R), Telerik.Reporting.Drawing.Unit.Cm(5.3339004516601562R))
        Me.Table2.Name = "Table2"
        TableGroup4.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup4.Name = "detailTableGroup1"
        Me.Table2.RowGroups.Add(TableGroup4)
        Me.Table2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.6360006332397461R), Telerik.Reporting.Drawing.Unit.Cm(4.82580041885376R))
        '
        'HtmlTextBox3
        '
        Me.HtmlTextBox3.Name = "HtmlTextBox3"
        Me.HtmlTextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.6360006332397461R), Telerik.Reporting.Drawing.Unit.Cm(4.82580041885376R))
        Me.HtmlTextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.HtmlTextBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.HtmlTextBox3.StyleName = ""
        Me.HtmlTextBox3.Value = resources.GetString("HtmlTextBox3.Value")
        '
        'HtmlTextBox5
        '
        Me.HtmlTextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(1.2752944231033325R), Telerik.Reporting.Drawing.Unit.Cm(10.667900085449219R))
        Me.HtmlTextBox5.Name = "HtmlTextBox5"
        Me.HtmlTextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(20.060705184936523R), Telerik.Reporting.Drawing.Unit.Cm(1.0160006284713745R))
        Me.HtmlTextBox5.Value = resources.GetString("HtmlTextBox5.Value")
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Cm(0.59999889135360718R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.HtmlTextBox4, Me.TextBox31})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'HtmlTextBox4
        '
        Me.HtmlTextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(0.0082375463098287582R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.HtmlTextBox4.Name = "HtmlTextBox4"
        Me.HtmlTextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(11.92976188659668R), Telerik.Reporting.Drawing.Unit.Cm(0.5079001784324646R))
        Me.HtmlTextBox4.Value = resources.GetString("HtmlTextBox4.Value")
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003940165042877R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(13.208000183105469R), Telerik.Reporting.Drawing.Unit.Cm(0.000099921220680698752R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(8.3766078948974609R), Telerik.Reporting.Drawing.Unit.Cm(0.50800013542175293R))
        Me.TextBox1.Style.Font.Name = "Times New Roman"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox1.Value = "Bolsa de Valores de la República Dominicana"
        '
        'TextBox31
        '
        Me.TextBox31.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3168139457702637R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811027526855469R), Telerik.Reporting.Drawing.Unit.Inch(0.23622004687786102R))
        Me.TextBox31.Value = "= CStr(pageNumber)"
        '
        'FIAB_Mensual_Portada
        '
        Me.DataSource = Me.SqlConfiguracion
        Me.DocumentMapText = "Portada"
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "FIAB_Portada"
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Pixel(0.10000000149011612R), Telerik.Reporting.Drawing.Unit.Pixel(0.10000000149011612R), Telerik.Reporting.Drawing.Unit.Pixel(0.10000000149011612R), Telerik.Reporting.Drawing.Unit.Pixel(0.10000000149011612R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaOperacion"
        ReportParameter1.Text = "Fecha Operación"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Cm
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(21.584707260131836R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents SqlConfiguracion As Telerik.Reporting.SqlDataSource
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents HtmlTextBox2 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents Table2 As Telerik.Reporting.Table
    Friend WithEvents HtmlTextBox3 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents HtmlTextBox4 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents HtmlTextBox1 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents HtmlTextBox5 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
End Class