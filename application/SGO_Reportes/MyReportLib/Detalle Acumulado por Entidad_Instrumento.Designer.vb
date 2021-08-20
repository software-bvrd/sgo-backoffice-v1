Partial Class Detalle_Acumulado_por_Entidad_Instrumento
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Detalle_Acumulado_por_Entidad_Instrumento))
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
        Dim GraphGroup1 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim GraphTitle1 As Telerik.Reporting.GraphTitle = New Telerik.Reporting.GraphTitle()
        Dim CategoryScale1 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale1 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim GraphGroup2 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim CategoryScale2 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale2 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim NumericalScaleCrossAxisPosition1 As Telerik.Reporting.NumericalScaleCrossAxisPosition = New Telerik.Reporting.NumericalScaleCrossAxisPosition()
        Dim GraphGroup3 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim FormattingRule1 As Telerik.Reporting.Drawing.FormattingRule = New Telerik.Reporting.Drawing.FormattingRule()
        Dim GraphGroup4 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim CategoryScale3 As Telerik.Reporting.CategoryScale = New Telerik.Reporting.CategoryScale()
        Dim NumericalScale3 As Telerik.Reporting.NumericalScale = New Telerik.Reporting.NumericalScale()
        Dim NumericalScaleCrossAxisPosition2 As Telerik.Reporting.NumericalScaleCrossAxisPosition = New Telerik.Reporting.NumericalScaleCrossAxisPosition()
        Dim GraphGroup5 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim GraphGroup6 As Telerik.Reporting.GraphGroup = New Telerik.Reporting.GraphGroup()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule5 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule6 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector1 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Dim StyleRule7 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector2 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.SQLEmisoresInstrumentosAlaFecha = New Telerik.Reporting.SqlDataSource()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.pageHeader = New Telerik.Reporting.PageHeaderSection()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.reportHeader = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox101 = New Telerik.Reporting.TextBox()
        Me.Table8 = New Telerik.Reporting.Table()
        Me.TextBox90 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.SqlBoletin = New Telerik.Reporting.SqlDataSource()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.TextBox22 = New Telerik.Reporting.TextBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Graph2 = New Telerik.Reporting.Graph()
        Me.CartesianCoordinateSystem1 = New Telerik.Reporting.CartesianCoordinateSystem()
        Me.GraphAxis8 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis7 = New Telerik.Reporting.GraphAxis()
        Me.BarSeries4 = New Telerik.Reporting.BarSeries()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.GraphAxis2 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis1 = New Telerik.Reporting.GraphAxis()
        Me.PolarCoordinateSystem1 = New Telerik.Reporting.PolarCoordinateSystem()
        Me.BarSeries1 = New Telerik.Reporting.BarSeries()
        Me.GraphAxis4 = New Telerik.Reporting.GraphAxis()
        Me.GraphAxis3 = New Telerik.Reporting.GraphAxis()
        Me.PolarCoordinateSystem2 = New Telerik.Reporting.PolarCoordinateSystem()
        Me.BarSeries2 = New Telerik.Reporting.BarSeries()
        Me.SqlDataSource1 = New Telerik.Reporting.SqlDataSource()
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        '
        'TextBox1
        '
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2829158306121826R), Telerik.Reporting.Drawing.Unit.Inch(0.39375004172325134R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149,Byte),Integer), CType(CType(179,Byte),Integer), CType(CType(215,Byte),Integer))
        Me.TextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox1.Style.Font.Bold = true
        Me.TextBox1.Style.Font.Name = "Arial Narrow"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.StyleName = "Normal.TableHeader"
        Me.TextBox1.Value = "Instrumento"
        '
        'TextBox2
        '
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9566663503646851R), Telerik.Reporting.Drawing.Unit.Inch(0.39375004172325134R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149,Byte),Integer), CType(CType(179,Byte),Integer), CType(CType(215,Byte),Integer))
        Me.TextBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox2.Style.Font.Bold = true
        Me.TextBox2.Style.Font.Name = "Arial Narrow"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.StyleName = "Normal.TableHeader"
        Me.TextBox2.Value = "Valor Transado RD$ y Equiv"
        '
        'TextBox3
        '
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7999998927116394R), Telerik.Reporting.Drawing.Unit.Inch(0.39375004172325134R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149,Byte),Integer), CType(CType(179,Byte),Integer), CType(CType(215,Byte),Integer))
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox3.Style.Font.Bold = true
        Me.TextBox3.Style.Font.Name = "Arial Narrow"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.StyleName = "Normal.TableHeader"
        Me.TextBox3.Value = "% DOP"
        '
        'TextBox7
        '
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4499999284744263R), Telerik.Reporting.Drawing.Unit.Inch(0.39375004172325134R))
        Me.TextBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(149,Byte),Integer), CType(CType(179,Byte),Integer), CType(CType(215,Byte),Integer))
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox7.Style.Font.Bold = true
        Me.TextBox7.Style.Font.Name = "Arial Narrow"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.StyleName = "Normal.TableHeader"
        Me.TextBox7.Value = "Valor Transado USD"
        '
        'SQLEmisoresInstrumentosAlaFecha
        '
        Me.SQLEmisoresInstrumentosAlaFecha.CommandTimeout = 0
        Me.SQLEmisoresInstrumentosAlaFecha.ConnectionString = "CN"
        Me.SQLEmisoresInstrumentosAlaFecha.Name = "SQLEmisoresInstrumentosAlaFecha"
        Me.SQLEmisoresInstrumentosAlaFecha.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Mercado", System.Data.DbType.AnsiString, "15")})
        Me.SQLEmisoresInstrumentosAlaFecha.SelectCommand = "dbo.SP_TotalTransadoEmisorInstrurumentoHastaFecha"
        Me.SQLEmisoresInstrumentosAlaFecha.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.reportFooter.Name = "reportFooter"
        Me.reportFooter.Style.Visible = true
        '
        'pageHeader
        '
        Me.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.pageHeader.Name = "pageHeader"
        '
        'pageFooter
        '
        Me.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003890991210938R)
        Me.pageFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81})
        Me.pageFooter.Name = "pageFooter"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0000002384185791R), Telerik.Reporting.Drawing.Unit.Inch(0.19999949634075165R))
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD"
        '
        'reportHeader
        '
        Me.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475R)
        Me.reportHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox11, Me.TextBox101, Me.Table8, Me.PictureBox2, Me.Table1})
        Me.reportHeader.Name = "reportHeader"
        '
        'TextBox11
        '
        Me.TextBox11.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6208728551864624R), Telerik.Reporting.Drawing.Unit.Inch(0.34791669249534607R))
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.2791275978088379R), Telerik.Reporting.Drawing.Unit.Inch(0.4479166567325592R))
        Me.TextBox11.Style.Font.Bold = true
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox11.Value = "Detalle Acumulado por Entidad/Instrumento"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"Mercado Secundario"
        '
        'TextBox101
        '
        Me.TextBox101.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6208728551864624R), Telerik.Reporting.Drawing.Unit.Inch(0.79591202735900879R))
        Me.TextBox101.Name = "TextBox101"
        Me.TextBox101.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.2791275978088379R), Telerik.Reporting.Drawing.Unit.Inch(0.21309243142604828R))
        Me.TextBox101.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox101.Style.Color = System.Drawing.Color.Black
        Me.TextBox101.Style.Font.Bold = true
        Me.TextBox101.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox101.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox101.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox101.TextWrap = false
        Me.TextBox101.Value = resources.GetString("TextBox101.Value")
        '
        'Table8
        '
        Me.Table8.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R)))
        Me.Table8.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.39145839214324951R)))
        Me.Table8.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.39314728975296021R)))
        Me.Table8.Body.SetCellContent(1, 0, Me.TextBox90)
        Me.Table8.Body.SetCellContent(0, 0, Me.TextBox8)
        Me.Table8.ColumnGroups.Add(TableGroup1)
        Me.Table8.DataSource = Me.SqlBoletin
        Me.Table8.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox8, Me.TextBox90})
        Me.Table8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.03749418258667R), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05R))
        Me.Table8.Name = "Table8"
        TableGroup3.Name = "Group2"
        TableGroup4.Name = "Group1"
        TableGroup2.ChildGroups.Add(TableGroup3)
        TableGroup2.ChildGroups.Add(TableGroup4)
        TableGroup2.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup2.Name = "DetailGroup"
        Me.Table8.RowGroups.Add(TableGroup2)
        Me.Table8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Cm(0.78460568189620972R))
        '
        'TextBox90
        '
        Me.TextBox90.Format = "{0:#.}"
        Me.TextBox90.Name = "TextBox90"
        Me.TextBox90.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Inch(0.15478239953517914R))
        Me.TextBox90.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6R)
        Me.TextBox90.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox90.Value = "Rueda No. {Fields.Secuencial}"
        '
        'TextBox8
        '
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4624665975570679R), Telerik.Reporting.Drawing.Unit.Cm(0.39145839214324951R))
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.StyleName = ""
        Me.TextBox8.Value = "BD {Fields.BD}"
        '
        'SqlBoletin
        '
        Me.SqlBoletin.CommandTimeout = 0
        Me.SqlBoletin.ConnectionString = "CN"
        Me.SqlBoletin.Name = "SqlBoletin"
        Me.SqlBoletin.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value")})
        Me.SqlBoletin.SelectCommand = "dbo.SP_BuscarBoletinFecha"
        Me.SqlBoletin.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4041666984558105R), Telerik.Reporting.Drawing.Unit.Inch(0.461087703704834R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0957943201065064R), Telerik.Reporting.Drawing.Unit.Inch(0.547916829586029R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"),Object)
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(3.2829158306121826R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.9566663503646851R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.7999998927116394R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.4499999284744263R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.18541659414768219R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox10)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox12)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox14)
        Me.Table1.Body.SetCellContent(0, 3, Me.TextBox15)
        Me.Table1.Body.SetCellContent(1, 0, Me.TextBox17)
        Me.Table1.Body.SetCellContent(1, 1, Me.TextBox19)
        Me.Table1.Body.SetCellContent(1, 2, Me.TextBox20)
        Me.Table1.Body.SetCellContent(1, 3, Me.TextBox21)
        Me.Table1.Body.SetCellContent(2, 0, Me.TextBox22, 1, 4)
        TableGroup5.ReportItem = Me.TextBox1
        TableGroup6.ReportItem = Me.TextBox2
        TableGroup7.ReportItem = Me.TextBox3
        TableGroup8.ReportItem = Me.TextBox7
        Me.Table1.ColumnGroups.Add(TableGroup5)
        Me.Table1.ColumnGroups.Add(TableGroup6)
        Me.Table1.ColumnGroups.Add(TableGroup7)
        Me.Table1.ColumnGroups.Add(TableGroup8)
        Me.Table1.DataSource = Me.SQLEmisoresInstrumentosAlaFecha
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox10, Me.TextBox12, Me.TextBox14, Me.TextBox15, Me.TextBox17, Me.TextBox19, Me.TextBox20, Me.TextBox21, Me.TextBox22, Me.TextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox7})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(1.1000000238418579R))
        Me.Table1.Name = "Table1"
        TableGroup9.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup9.Name = "Detail"
        TableGroup10.Name = "Group1"
        TableGroup11.Name = "Group2"
        Me.Table1.RowGroups.Add(TableGroup9)
        Me.Table1.RowGroups.Add(TableGroup10)
        Me.Table1.RowGroups.Add(TableGroup11)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.4895820617675781R), Telerik.Reporting.Drawing.Unit.Inch(0.97916662693023682R))
        Me.Table1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None
        Me.Table1.StyleName = "Normal.TableNormal"
        '
        'TextBox10
        '
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2829158306121826R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox10.Style.Font.Name = "Arial Narrow"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.StyleName = "Normal.TableBody"
        Me.TextBox10.Value = "=Fields.EmisorInstrumento"
        '
        'TextBox12
        '
        Me.TextBox12.Format = "{0:N2}"
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9566663503646851R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox12.Style.Font.Name = "Arial Narrow"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox12.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.StyleName = "Normal.TableBody"
        Me.TextBox12.Value = "=Fields.ValorTransadoEquivalentePesos"
        '
        'TextBox14
        '
        Me.TextBox14.Format = "{0}"
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7999998927116394R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox14.Style.Font.Name = "Arial Narrow"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox14.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.StyleName = "Normal.TableBody"
        Me.TextBox14.Value = "{OperacionesNumericas.FormatoNumeroEnPorcentaje(Fields.PorcentajePesos)}%"
        '
        'TextBox15
        '
        Me.TextBox15.Format = "{0:N2}"
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4499999284744263R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox15.Style.Font.Name = "Arial Narrow"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox15.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.StyleName = "Normal.TableBody"
        Me.TextBox15.Value = "=Fields.ValorTransadoUSD"
        '
        'TextBox17
        '
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2829158306121826R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox17.Style.Font.Bold = true
        Me.TextBox17.Style.Font.Name = "Arial Narrow"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox17.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.StyleName = "Normal.TableBody"
        Me.TextBox17.Value = "Total Transado ==>"
        '
        'TextBox19
        '
        Me.TextBox19.Format = "{0:N2}"
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.9566663503646851R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox19.Style.Font.Bold = true
        Me.TextBox19.Style.Font.Name = "Arial Narrow"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox19.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox19.StyleName = "Normal.TableBody"
        Me.TextBox19.Value = "=Sum(Fields.ValorTransadoEquivalentePesos)"
        '
        'TextBox20
        '
        Me.TextBox20.Format = "{0:0.00%}"
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.7999998927116394R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox20.Style.Font.Bold = true
        Me.TextBox20.Style.Font.Name = "Arial Narrow"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox20.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox20.StyleName = "Normal.TableBody"
        Me.TextBox20.Value = "=Sum(Fields.PorcentajePesos)"
        '
        'TextBox21
        '
        Me.TextBox21.Format = "{0:N2}"
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4499999284744263R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox21.Style.Font.Bold = true
        Me.TextBox21.Style.Font.Name = "Arial Narrow"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox21.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox21.StyleName = "Normal.TableBody"
        Me.TextBox21.Value = "=Sum(Fields.ValorTransadoUSD)"
        '
        'TextBox22
        '
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.4895820617675781R), Telerik.Reporting.Drawing.Unit.Inch(0.18541665375232697R))
        Me.TextBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox22.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5R)
        Me.TextBox22.Style.Font.Name = "Arial Narrow"
        Me.TextBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5R)
        Me.TextBox22.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.019999999552965164R)
        Me.TextBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox22.StyleName = "Normal.TableBody"
        Me.TextBox22.Value = "* Valorizado según la tasa de cambio del día de realización de las operaciones."
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(3.1000399589538574R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Graph2})
        Me.detail.Name = "detail"
        '
        'Graph2
        '
        GraphGroup1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.CodigoInstrumento"))
        GraphGroup1.Name = "codigoInstrumentoGroup"
        GraphGroup1.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.CodigoInstrumento", Telerik.Reporting.SortDirection.Asc))
        Me.Graph2.CategoryGroups.Add(GraphGroup1)
        Me.Graph2.CoordinateSystems.Add(Me.CartesianCoordinateSystem1)
        Me.Graph2.DataSource = Me.SQLEmisoresInstrumentosAlaFecha
        Me.Graph2.Legend.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6R)
        Me.Graph2.Legend.Style.LineColor = System.Drawing.Color.LightGray
        Me.Graph2.Legend.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9365557313431054E-05R), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05R))
        Me.Graph2.Name = "Graph2"
        Me.Graph2.PlotAreaStyle.LineColor = System.Drawing.Color.LightGray
        Me.Graph2.PlotAreaStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.Graph2.Series.Add(Me.BarSeries4)
        Me.Graph2.SeriesGroups.Add(GraphGroup2)
        Me.Graph2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.4895424842834473R), Telerik.Reporting.Drawing.Unit.Inch(3.1000001430511475R))
        Me.Graph2.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(10R)
        Me.Graph2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(10R)
        Me.Graph2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(10R)
        Me.Graph2.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(10R)
        GraphTitle1.Position = Telerik.Reporting.GraphItemPosition.TopCenter
        GraphTitle1.Style.LineColor = System.Drawing.Color.LightGray
        GraphTitle1.Style.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        GraphTitle1.Style.Visible = false
        GraphTitle1.Text = "Graph2"
        Me.Graph2.Titles.Add(GraphTitle1)
        '
        'CartesianCoordinateSystem1
        '
        Me.CartesianCoordinateSystem1.Name = "CartesianCoordinateSystem1"
        Me.CartesianCoordinateSystem1.XAxis = Me.GraphAxis8
        Me.CartesianCoordinateSystem1.YAxis = Me.GraphAxis7
        '
        'GraphAxis8
        '
        Me.GraphAxis8.LabelAngle = -45
        Me.GraphAxis8.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis8.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis8.MajorGridLineStyle.Visible = false
        Me.GraphAxis8.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis8.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis8.MinorGridLineStyle.Visible = false
        Me.GraphAxis8.Name = "GraphAxis8"
        Me.GraphAxis8.Scale = CategoryScale1
        Me.GraphAxis8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6R)
        '
        'GraphAxis7
        '
        Me.GraphAxis7.LabelFormat = "{0:N2}"
        Me.GraphAxis7.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis7.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis7.MajorGridLineStyle.Visible = false
        Me.GraphAxis7.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis7.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis7.MinorGridLineStyle.Visible = false
        Me.GraphAxis7.Name = "GraphAxis7"
        Me.GraphAxis7.Scale = NumericalScale1
        Me.GraphAxis7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6R)
        '
        'BarSeries4
        '
        Me.BarSeries4.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Overlapped
        Me.BarSeries4.CategoryGroup = GraphGroup1
        Me.BarSeries4.CoordinateSystem = Me.CartesianCoordinateSystem1
        Me.BarSeries4.DataPointLabel = "=(Fields.ValorTransadoEquivalentePesos)"
        Me.BarSeries4.DataPointLabelAlignment = Telerik.Reporting.BarDataPointLabelAlignment.Center
        Me.BarSeries4.DataPointLabelStyle.Visible = false
        Me.BarSeries4.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries4.DataPointStyle.Visible = true
        Me.BarSeries4.LegendItem.Value = "{Fields.CodigoInstrumento} - {Fields.descrip_emisor} ({OperacionesNumericas.Forma"& _ 
    "toNumeroEnPorcentaje(Fields.PorcentajePesos)}%)"
        GraphGroup2.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.descrip_instru"))
        GraphGroup2.Name = "descrip_instruGroup"
        GraphGroup2.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.descrip_instru", Telerik.Reporting.SortDirection.Asc))
        Me.BarSeries4.SeriesGroup = GraphGroup2
        Me.BarSeries4.Y = "=(Fields.ValorTransadoEquivalentePesos)"
        '
        'TextBox4
        '
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.03125R), Telerik.Reporting.Drawing.Unit.Inch(0.30208325386047363R))
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4850834608078003R), Telerik.Reporting.Drawing.Unit.Inch(0.23256278038024902R))
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        '
        'TextBox6
        '
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80979883670806885R), Telerik.Reporting.Drawing.Unit.Inch(0.23256281018257141R))
        '
        'TextBox9
        '
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5937472581863403R), Telerik.Reporting.Drawing.Unit.Inch(0.21874988079071045R))
        Me.TextBox9.StyleName = ""
        '
        'TextBox13
        '
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0086052417755127R), Telerik.Reporting.Drawing.Unit.Inch(0.2395833432674408R))
        Me.TextBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox13.StyleName = ""
        '
        'TextBox16
        '
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.80979883670806885R), Telerik.Reporting.Drawing.Unit.Inch(0.2395833432674408R))
        Me.TextBox16.StyleName = ""
        '
        'TextBox18
        '
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1354162693023682R), Telerik.Reporting.Drawing.Unit.Inch(0.23256281018257141R))
        Me.TextBox18.StyleName = ""
        '
        'GraphAxis2
        '
        Me.GraphAxis2.LabelPlacement = Telerik.Reporting.GraphAxisLabelPlacement.AtMaximum
        Me.GraphAxis2.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis2.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis2.MajorGridLineStyle.Visible = false
        Me.GraphAxis2.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis2.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis2.MinorGridLineStyle.Visible = false
        Me.GraphAxis2.Name = "GraphAxis2"
        CategoryScale2.PositionMode = Telerik.Reporting.AxisPositionMode.OnTicks
        CategoryScale2.SpacingSlotCount = 0R
        Me.GraphAxis2.Scale = CategoryScale2
        Me.GraphAxis2.Style.Visible = false
        '
        'GraphAxis1
        '
        Me.GraphAxis1.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis1.MajorGridLineStyle.Visible = false
        Me.GraphAxis1.MajorTickMarkDisplayType = Telerik.Reporting.GraphAxisTickMarkDisplayType.Outside
        Me.GraphAxis1.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis1.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis1.MinorGridLineStyle.Visible = false
        Me.GraphAxis1.Name = "GraphAxis1"
        NumericalScaleCrossAxisPosition1.Position = Telerik.Reporting.GraphScaleCrossAxisPosition.[Auto]
        NumericalScaleCrossAxisPosition1.Value = 0R
        NumericalScale2.CrossAxisPositions.Add(NumericalScaleCrossAxisPosition1)
        Me.GraphAxis1.Scale = NumericalScale2
        Me.GraphAxis1.Style.Visible = false
        '
        'PolarCoordinateSystem1
        '
        Me.PolarCoordinateSystem1.AngularAxis = Me.GraphAxis1
        Me.PolarCoordinateSystem1.Name = "PolarCoordinateSystem1"
        Me.PolarCoordinateSystem1.RadialAxis = Me.GraphAxis2
        Me.PolarCoordinateSystem1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0R)
        '
        'BarSeries1
        '
        Me.BarSeries1.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Stacked100
        GraphGroup3.Name = "categoryGroup1"
        Me.BarSeries1.CategoryGroup = GraphGroup3
        Me.BarSeries1.CoordinateSystem = Me.PolarCoordinateSystem1
        Me.BarSeries1.DataPointLabel = "= Fields.PorcentajePesos"
        FormattingRule1.Filters.Add(New Telerik.Reporting.Filter("=Fields.PorcentajePesos", Telerik.Reporting.FilterOperator.LessThan, "0.05"))
        FormattingRule1.Style.Color = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(128,Byte),Integer), CType(CType(255,Byte),Integer))
        FormattingRule1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(2R)
        Me.BarSeries1.DataPointLabelConditionalFormatting.AddRange(New Telerik.Reporting.Drawing.FormattingRule() {FormattingRule1})
        Me.BarSeries1.DataPointLabelStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.BarSeries1.DataPointLabelStyle.Font.Strikeout = false
        Me.BarSeries1.DataPointLabelStyle.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries1.DataPointLabelStyle.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries1.DataPointLabelStyle.Padding.Right = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries1.DataPointLabelStyle.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries1.DataPointLabelStyle.Visible = true
        Me.BarSeries1.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries1.DataPointStyle.Visible = true
        Me.BarSeries1.LegendItem.Value = "= Fields.descrip_emisor"
        GraphGroup4.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.EmisorInstrumento"))
        GraphGroup4.Name = "emisorInstrumentoGroup1"
        GraphGroup4.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.EmisorInstrumento", Telerik.Reporting.SortDirection.Asc))
        Me.BarSeries1.SeriesGroup = GraphGroup4
        Me.BarSeries1.X = "=(Fields.ValorTotalTransadoLocal)"
        '
        'GraphAxis4
        '
        Me.GraphAxis4.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis4.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis4.MajorGridLineStyle.Visible = false
        Me.GraphAxis4.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis4.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis4.MinorGridLineStyle.Visible = false
        Me.GraphAxis4.Name = "GraphAxis4"
        CategoryScale3.PositionMode = Telerik.Reporting.AxisPositionMode.OnTicks
        CategoryScale3.SpacingSlotCount = 0R
        Me.GraphAxis4.Scale = CategoryScale3
        Me.GraphAxis4.Style.Visible = false
        '
        'GraphAxis3
        '
        Me.GraphAxis3.MajorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis3.MajorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis3.MajorGridLineStyle.Visible = false
        Me.GraphAxis3.MinorGridLineStyle.LineColor = System.Drawing.Color.LightGray
        Me.GraphAxis3.MinorGridLineStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        Me.GraphAxis3.MinorGridLineStyle.Visible = false
        Me.GraphAxis3.Name = "GraphAxis3"
        NumericalScaleCrossAxisPosition2.Position = Telerik.Reporting.GraphScaleCrossAxisPosition.[Auto]
        NumericalScaleCrossAxisPosition2.Value = 0R
        NumericalScale3.CrossAxisPositions.Add(NumericalScaleCrossAxisPosition2)
        Me.GraphAxis3.Scale = NumericalScale3
        Me.GraphAxis3.Style.Visible = false
        '
        'PolarCoordinateSystem2
        '
        Me.PolarCoordinateSystem2.AngularAxis = Me.GraphAxis3
        Me.PolarCoordinateSystem2.Name = "PolarCoordinateSystem2"
        Me.PolarCoordinateSystem2.RadialAxis = Me.GraphAxis4
        '
        'BarSeries2
        '
        Me.BarSeries2.ArrangeMode = Telerik.Reporting.GraphSeriesArrangeMode.Stacked100
        GraphGroup5.Name = "categoryGroup1"
        Me.BarSeries2.CategoryGroup = GraphGroup5
        Me.BarSeries2.CoordinateSystem = Me.PolarCoordinateSystem2
        Me.BarSeries2.DataPointLabel = "{OperacionesNumericas.FormatoNumeros(Fields.PorcentajePesos)}%"
        Me.BarSeries2.DataPointLabelStyle.Font.Name = "Arial Narrow"
        Me.BarSeries2.DataPointLabelStyle.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7R)
        Me.BarSeries2.DataPointLabelStyle.Visible = false
        Me.BarSeries2.DataPointStyle.LineWidth = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.BarSeries2.DataPointStyle.Visible = true
        Me.BarSeries2.LegendItem.Value = "{Fields.descrip_instru} ({OperacionesNumericas.FormatoNumeros(Fields.PorcentajePe"& _ 
    "sos)}%)"
        GraphGroup6.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.descrip_instru"))
        GraphGroup6.Name = "descrip_instruGroup1"
        GraphGroup6.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.descrip_instru", Telerik.Reporting.SortDirection.Asc))
        Me.BarSeries2.SeriesGroup = GraphGroup6
        Me.BarSeries2.X = "=(Fields.ValorTransadoEquivalentePesos)"
        '
        'SqlDataSource1
        '
        Me.SqlDataSource1.CommandTimeout = 0
        Me.SqlDataSource1.ConnectionString = "CN"
        Me.SqlDataSource1.Name = "SqlDataSource1"
        Me.SqlDataSource1.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaOperacion", System.Data.DbType.[Date], "=Parameters.FechaOperacion.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Mercado", System.Data.DbType.AnsiString, "15")})
        Me.SqlDataSource1.SelectCommand = "dbo.SP_TotalTransadoEmisorInstrurumentoHastaFecha"
        Me.SqlDataSource1.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'Detalle_Acumulado_por_Entidad_Instrumento
        '
        Me.DataSource = Nothing
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.reportFooter, Me.pageHeader, Me.pageFooter, Me.reportHeader, Me.detail})
        Me.Name = "Detalle_Acumulado_por_Entidad_Instrumento"
        Me.PageSettings.Landscape = false
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.AllowBlank = false
        ReportParameter1.Name = "FechaOperacion"
        ReportParameter1.Text = "Fecha Desde"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "= Today()"
        ReportParameter1.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Title")})
        StyleRule1.Style.Color = System.Drawing.Color.FromArgb(CType(CType(214,Byte),Integer), CType(CType(97,Byte),Integer), CType(CType(74,Byte),Integer))
        StyleRule1.Style.Font.Name = "Georgia"
        StyleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18R)
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Caption")})
        StyleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(140,Byte),Integer), CType(CType(174,Byte),Integer), CType(CType(173,Byte),Integer))
        StyleRule2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(CType(CType(115,Byte),Integer), CType(CType(168,Byte),Integer), CType(CType(212,Byte),Integer))
        StyleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Dotted
        StyleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule2.Style.Color = System.Drawing.Color.FromArgb(CType(CType(228,Byte),Integer), CType(CType(238,Byte),Integer), CType(CType(243,Byte),Integer))
        StyleRule2.Style.Font.Name = "Georgia"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10R)
        StyleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Data")})
        StyleRule3.Style.Font.Name = "Georgia"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("PageInfo")})
        StyleRule4.Style.Font.Name = "Georgia"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        StyleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule5.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.Table), "Normal.TableNormal")})
        StyleRule5.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule5.Style.Color = System.Drawing.Color.Black
        StyleRule5.Style.Font.Name = "Tahoma"
        StyleRule5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        DescendantSelector1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableHeader")})
        StyleRule6.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector1})
        StyleRule6.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule6.Style.Font.Name = "Tahoma"
        StyleRule6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10R)
        StyleRule6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        DescendantSelector2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableBody")})
        StyleRule7.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector2})
        StyleRule7.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule7.Style.Font.Name = "Tahoma"
        StyleRule7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4, StyleRule5, StyleRule6, StyleRule7})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(7.5R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents SQLEmisoresInstrumentosAlaFecha As Telerik.Reporting.SqlDataSource
    Friend WithEvents labelsGroup As Telerik.Reporting.Group
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents pageHeader As Telerik.Reporting.PageHeaderSection
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
    Friend WithEvents reportHeader As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents Group1 As Telerik.Reporting.Group
    Friend WithEvents TextBox101 As Telerik.Reporting.TextBox
    Friend WithEvents SqlBoletin As Telerik.Reporting.SqlDataSource
    Friend WithEvents Table8 As Telerik.Reporting.Table
    Friend WithEvents TextBox90 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
    Friend WithEvents GraphAxis2 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis1 As Telerik.Reporting.GraphAxis
    Friend WithEvents PolarCoordinateSystem1 As Telerik.Reporting.PolarCoordinateSystem
    Friend WithEvents BarSeries1 As Telerik.Reporting.BarSeries
    Friend WithEvents SqlDataSource1 As Telerik.Reporting.SqlDataSource
    Friend WithEvents GraphAxis4 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis3 As Telerik.Reporting.GraphAxis
    Friend WithEvents PolarCoordinateSystem2 As Telerik.Reporting.PolarCoordinateSystem
    Friend WithEvents BarSeries2 As Telerik.Reporting.BarSeries
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox22 As Telerik.Reporting.TextBox
    Friend WithEvents Graph2 As Telerik.Reporting.Graph
    Friend WithEvents CartesianCoordinateSystem1 As Telerik.Reporting.CartesianCoordinateSystem
    Friend WithEvents GraphAxis8 As Telerik.Reporting.GraphAxis
    Friend WithEvents GraphAxis7 As Telerik.Reporting.GraphAxis
    Friend WithEvents BarSeries4 As Telerik.Reporting.BarSeries
End Class