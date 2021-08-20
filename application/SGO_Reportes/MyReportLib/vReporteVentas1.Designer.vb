Partial Class vReporteVentas1

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(vReporteVentas1))
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.CN = New Telerik.Reporting.SqlDataSource()
        Me.nemo_insGroupHeader = New Telerik.Reporting.GroupHeaderSection()
        Me.nemo_insGroupFooter = New Telerik.Reporting.GroupFooterSection()
        Me.cod_isinDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.nemo_insDataTextBox2 = New Telerik.Reporting.TextBox()
        Me.descrip_emisorDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.descrip_instruDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.fecha_emiDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.fecha_vencDataTextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.TextBox23 = New Telerik.Reporting.TextBox()
        Me.TextBox28 = New Telerik.Reporting.TextBox()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox29 = New Telerik.Reporting.TextBox()
        Me.Shape1 = New Telerik.Reporting.Shape()
        Me.reportFooter = New Telerik.Reporting.ReportFooterSection()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.TextBox32 = New Telerik.Reporting.TextBox()
        Me.cod_isinCaptionTextBox = New Telerik.Reporting.TextBox()
        Me.nemo_insCaptionTextBox1 = New Telerik.Reporting.TextBox()
        Me.pageHeader = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.TextBox22 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.pageFooter = New Telerik.Reporting.PageFooterSection()
        Me.currentTimeTextBox = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'CN
        '
        Me.CN.ConnectionString = "CN"
        Me.CN.Name = "CN"
        Me.CN.SelectCommand = "SELECT        *" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            vReporteVentas"
        '
        'nemo_insGroupHeader
        '
        Me.nemo_insGroupHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(0.49980291724205017R)
        Me.nemo_insGroupHeader.Name = "nemo_insGroupHeader"
        '
        'nemo_insGroupFooter
        '
        Me.nemo_insGroupFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.52771973609924316R)
        Me.nemo_insGroupFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.cod_isinDataTextBox1, Me.nemo_insDataTextBox2, Me.descrip_emisorDataTextBox1, Me.descrip_instruDataTextBox1, Me.fecha_emiDataTextBox1, Me.fecha_vencDataTextBox1, Me.TextBox10, Me.TextBox13, Me.TextBox14, Me.TextBox9, Me.TextBox27, Me.TextBox25, Me.TextBox23, Me.TextBox28, Me.TextBox26, Me.TextBox24, Me.TextBox29, Me.Shape1})
        Me.nemo_insGroupFooter.Name = "nemo_insGroupFooter"
        '
        'cod_isinDataTextBox1
        '
        Me.cod_isinDataTextBox1.CanGrow = True
        Me.cod_isinDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(-0.0000000066227383577199816R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.cod_isinDataTextBox1.Name = "cod_isinDataTextBox1"
        Me.cod_isinDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5791667103767395R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.cod_isinDataTextBox1.Style.Font.Name = "Times New Roman"
        Me.cod_isinDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.cod_isinDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.cod_isinDataTextBox1.StyleName = "Data"
        Me.cod_isinDataTextBox1.Value = "=isnull(Fields.cod_isin,'N/A')"
        '
        'nemo_insDataTextBox2
        '
        Me.nemo_insDataTextBox2.CanGrow = True
        Me.nemo_insDataTextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.nemo_insDataTextBox2.Name = "nemo_insDataTextBox2"
        Me.nemo_insDataTextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.60000038146972656R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.nemo_insDataTextBox2.Style.Font.Name = "Times New Roman"
        Me.nemo_insDataTextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.nemo_insDataTextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.nemo_insDataTextBox2.StyleName = "Data"
        Me.nemo_insDataTextBox2.Value = "=Fields.nemo_ins"
        '
        'descrip_emisorDataTextBox1
        '
        Me.descrip_emisorDataTextBox1.CanGrow = True
        Me.descrip_emisorDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.2399998903274536R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.descrip_emisorDataTextBox1.Name = "descrip_emisorDataTextBox1"
        Me.descrip_emisorDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3400000333786011R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.descrip_emisorDataTextBox1.Style.Font.Name = "Times New Roman"
        Me.descrip_emisorDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.descrip_emisorDataTextBox1.StyleName = "Data"
        Me.descrip_emisorDataTextBox1.Value = "=Fields.descrip_emisor"
        '
        'descrip_instruDataTextBox1
        '
        Me.descrip_instruDataTextBox1.Angle = 0R
        Me.descrip_instruDataTextBox1.CanGrow = True
        Me.descrip_instruDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6800000667572021R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.descrip_instruDataTextBox1.Name = "descrip_instruDataTextBox1"
        Me.descrip_instruDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.descrip_instruDataTextBox1.Style.Font.Name = "Times New Roman"
        Me.descrip_instruDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.descrip_instruDataTextBox1.StyleName = "Data"
        Me.descrip_instruDataTextBox1.Value = "=Fields.descrip_instru"
        '
        'fecha_emiDataTextBox1
        '
        Me.fecha_emiDataTextBox1.CanGrow = True
        Me.fecha_emiDataTextBox1.Format = "{0:d}"
        Me.fecha_emiDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.320833683013916R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.fecha_emiDataTextBox1.Name = "fecha_emiDataTextBox1"
        Me.fecha_emiDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.40000024437904358R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.fecha_emiDataTextBox1.Style.Font.Name = "Times New Roman"
        Me.fecha_emiDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.fecha_emiDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fecha_emiDataTextBox1.StyleName = "Data"
        Me.fecha_emiDataTextBox1.Value = "=Fields.fecha_emi"
        '
        'fecha_vencDataTextBox1
        '
        Me.fecha_vencDataTextBox1.CanGrow = True
        Me.fecha_vencDataTextBox1.Format = "{0:d}"
        Me.fecha_vencDataTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.8008337020874023R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.fecha_vencDataTextBox1.Name = "fecha_vencDataTextBox1"
        Me.fecha_vencDataTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.fecha_vencDataTextBox1.Style.Font.Name = "Times New Roman"
        Me.fecha_vencDataTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.fecha_vencDataTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.fecha_vencDataTextBox1.StyleName = "Data"
        Me.fecha_vencDataTextBox1.Value = "=Fields.fecha_venc"
        '
        'TextBox10
        '
        Me.TextBox10.Format = "{0:N2}"
        Me.TextBox10.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7140965461730957R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.64590388536453247R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox10.Style.Font.Name = "Times New Roman"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox10.Value = "=Fields.valor_nom_tot"
        '
        'TextBox13
        '
        Me.TextBox13.Format = "{0:N2}"
        Me.TextBox13.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4008336067199707R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.3591664731502533R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox13.Style.Font.Name = "Times New Roman"
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox13.Value = "=Fields.tasa_interes"
        '
        'TextBox14
        '
        Me.TextBox14.Format = "{0:N4}"
        Me.TextBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.800990104675293R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.44999998807907104R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox14.Style.Font.Name = "Times New Roman"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox14.Value = "=Fields.precio_limp"
        '
        'TextBox9
        '
        Me.TextBox9.Format = "{0:d}"
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2808337211608887R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000033113691788599908R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox9.Style.Font.Name = "Times New Roman"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox9.Value = "= Max(Fields.FechaOperImprimir.Date)"
        '
        'TextBox27
        '
        Me.TextBox27.Format = "{0:d}"
        Me.TextBox27.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.7100000381469727R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox27.Style.Font.Name = "Times New Roman"
        Me.TextBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox27.Value = "= Fields.FechaCompra"
        '
        'TextBox25
        '
        Me.TextBox25.Format = "{0:N4}"
        Me.TextBox25.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1303558349609375R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.47999998927116394R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox25.Style.Font.Name = "Times New Roman"
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.Value = "= IIF( Parameters.FormatoPrecio.Value =""U"", IIf(Fields.PriceCompra = 0, """",  Min(" &
    "Fields.PriceCompra))," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       IIf(Fields.PriceCompraAvg = 0, """",  Fields.PriceCo" &
    "mpraAvg) )"
        '
        'TextBox23
        '
        Me.TextBox23.Format = "{0:N2}"
        Me.TextBox23.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.68083381652832R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.31999999284744263R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox23.Style.Font.Name = "Times New Roman"
        Me.TextBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox23.Value = "= IIF( Parameters.FormatoPrecio.Value =""U"", IIf(Fields.YieldCompra = 0, """",  Min(" &
    "Fields.YieldCompra))," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       IIf(Fields.YieldCompraAvg = 0, """",  Fields.YieldCo" &
    "mpraAvg) )"
        '
        'TextBox28
        '
        Me.TextBox28.Format = "{0:d}"
        Me.TextBox28.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0629959106445312R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox28.Style.Font.Name = "Times New Roman"
        Me.TextBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox28.Value = "= Max(Fields.FechaVenta)"
        '
        'TextBox26
        '
        Me.TextBox26.Format = "{0:N4}"
        Me.TextBox26.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.4808330535888672R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.43999999761581421R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox26.Style.Font.Name = "Times New Roman"
        Me.TextBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox26.Value = "= IIF( Parameters.FormatoPrecio.Value =""U"", IIf(Fields.PriceVenta = 0, """",  Max(F" &
    "ields.PriceVenta))," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       IIf(Fields.PriceVentaAvg = 0, """",  Fields.PriceVenta" &
    "Avg) )"
        '
        'TextBox24
        '
        Me.TextBox24.Format = "{0:N2}"
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(10.000833511352539R), Telerik.Reporting.Drawing.Unit.Inch(0.0000000016556845894299954R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.34000000357627869R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox24.Style.Font.Name = "Times New Roman"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.Value = "= IIF( Parameters.FormatoPrecio.Value =""U"", IIf(Fields.YieldVenta = 0, """",  Max(F" &
    "ields.YieldVenta))," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "       IIf(Fields.YieldVentaAvg = 0, """",  Fields.YieldVenta" &
    "Avg) )"
        '
        'TextBox29
        '
        Me.TextBox29.Format = "{0:N2}"
        Me.TextBox29.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3208327293396R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.33749642968177795R), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612R))
        Me.TextBox29.Style.Font.Name = "Times New Roman"
        Me.TextBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox29.Value = "= Fields.yield"
        '
        'Shape1
        '
        Me.Shape1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.36771970987319946R))
        Me.Shape1.Name = "Shape1"
        Me.Shape1.ShapeType = New Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW)
        Me.Shape1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(10.491984367370606R), Telerik.Reporting.Drawing.Unit.Inch(0.1600000411272049R))
        Me.Shape1.Style.Color = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.Shape1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        '
        'reportFooter
        '
        Me.reportFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.45980298519134521R)
        Me.reportFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox31, Me.TextBox32})
        Me.reportFooter.Name = "reportFooter"
        Me.reportFooter.Style.Visible = True
        '
        'TextBox31
        '
        Me.TextBox31.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.019803047180175781R))
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.320000171661377R), Telerik.Reporting.Drawing.Unit.Inch(0.43996056914329529R))
        Me.TextBox31.Style.Font.Name = "Times New Roman"
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox31.Value = resources.GetString("TextBox31.Value")
        '
        'TextBox32
        '
        Me.TextBox32.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.8021669387817383R), Telerik.Reporting.Drawing.Unit.Inch(0.13980308175086975R))
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5608326196670532R), Telerik.Reporting.Drawing.Unit.Inch(0.23999994993209839R))
        Me.TextBox32.Style.Font.Name = "Times New Roman"
        Me.TextBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(5.0R)
        Me.TextBox32.Value = "= IIf(Parameters.FormatoPrecio.Value=""U"",""Ultimo Precio"",""Precio Promedio Pondera" &
    "do"")"
        '
        'cod_isinCaptionTextBox
        '
        Me.cod_isinCaptionTextBox.CanGrow = True
        Me.cod_isinCaptionTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.90000009536743164R))
        Me.cod_isinCaptionTextBox.Name = "cod_isinCaptionTextBox"
        Me.cod_isinCaptionTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.59999996423721313R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.cod_isinCaptionTextBox.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.cod_isinCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.cod_isinCaptionTextBox.Style.Color = System.Drawing.Color.Black
        Me.cod_isinCaptionTextBox.Style.Font.Name = "Arial"
        Me.cod_isinCaptionTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.cod_isinCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.cod_isinCaptionTextBox.Style.Visible = True
        Me.cod_isinCaptionTextBox.StyleName = "Caption"
        Me.cod_isinCaptionTextBox.Value = "Código ISIN"
        '
        'nemo_insCaptionTextBox1
        '
        Me.nemo_insCaptionTextBox1.CanGrow = True
        Me.nemo_insCaptionTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269R), Telerik.Reporting.Drawing.Unit.Inch(0.90000009536743164R))
        Me.nemo_insCaptionTextBox1.Name = "nemo_insCaptionTextBox1"
        Me.nemo_insCaptionTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.600000262260437R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.nemo_insCaptionTextBox1.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.nemo_insCaptionTextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.nemo_insCaptionTextBox1.Style.Color = System.Drawing.Color.Black
        Me.nemo_insCaptionTextBox1.Style.Font.Name = "Arial"
        Me.nemo_insCaptionTextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.nemo_insCaptionTextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.nemo_insCaptionTextBox1.StyleName = "Caption"
        Me.nemo_insCaptionTextBox1.Value = "Cód. Local"
        '
        'pageHeader
        '
        Me.pageHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1001969575881958R)
        Me.pageHeader.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1, Me.nemo_insCaptionTextBox1, Me.TextBox2, Me.TextBox3, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox8, Me.TextBox11, Me.TextBox12, Me.TextBox15, Me.TextBox16, Me.TextBox17, Me.TextBox18, Me.TextBox19, Me.cod_isinCaptionTextBox, Me.TextBox4, Me.TextBox20, Me.TextBox21, Me.TextBox22, Me.TextBox30, Me.PictureBox2})
        Me.pageHeader.Name = "pageHeader"
        '
        'TextBox1
        '
        Me.TextBox1.CanGrow = True
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.69305557012557983R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.2407546043396R), Telerik.Reporting.Drawing.Unit.Inch(0.19996058940887451R))
        Me.TextBox1.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Times New Roman"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.StyleName = "Caption"
        Me.TextBox1.Value = "Datos de la Emisión"
        '
        'TextBox2
        '
        Me.TextBox2.CanGrow = True
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.200079083442688R), Telerik.Reporting.Drawing.Unit.Inch(0.90000003576278687R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4206753969192505R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox2.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox2.Style.Color = System.Drawing.Color.Black
        Me.TextBox2.Style.Font.Name = "Arial"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.StyleName = "Caption"
        Me.TextBox2.Value = "Emisor"
        '
        'TextBox3
        '
        Me.TextBox3.CanGrow = True
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6208333969116211R), Telerik.Reporting.Drawing.Unit.Inch(0.90000009536743164R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6753212213516235R), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179R))
        Me.TextBox3.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.Color = System.Drawing.Color.Black
        Me.TextBox3.Style.Font.Name = "Arial"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.StyleName = "Caption"
        Me.TextBox3.Value = "Descripción Instrumento"
        '
        'TextBox5
        '
        Me.TextBox5.CanGrow = True
        Me.TextBox5.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2962336540222168R), Telerik.Reporting.Drawing.Unit.Inch(0.90000015497207642R))
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.47222137451171875R), Telerik.Reporting.Drawing.Unit.Inch(0.199881911277771R))
        Me.TextBox5.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.Color = System.Drawing.Color.Black
        Me.TextBox5.Style.Font.Name = "Arial"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.StyleName = "Caption"
        Me.TextBox5.Value = "Fecha Emi"
        '
        'TextBox6
        '
        Me.TextBox6.CanGrow = True
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.7685337066650391R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.47222137451171875R), Telerik.Reporting.Drawing.Unit.Inch(0.199881911277771R))
        Me.TextBox6.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.Color = System.Drawing.Color.Black
        Me.TextBox6.Style.Font.Name = "Arial"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox6.StyleName = "Caption"
        Me.TextBox6.Value = "Fecha Venc"
        '
        'TextBox7
        '
        Me.TextBox7.CanGrow = True
        Me.TextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2408337593078613R), Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582R))
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4600019454956055R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox7.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.Color = System.Drawing.Color.Black
        Me.TextBox7.Style.Font.Bold = True
        Me.TextBox7.Style.Font.Name = "Times New Roman"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.StyleName = "Caption"
        Me.TextBox7.Value = "Ultima Negociación"
        '
        'TextBox8
        '
        Me.TextBox8.CanGrow = True
        Me.TextBox8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2408337593078613R), Telerik.Reporting.Drawing.Unit.Inch(0.90000015497207642R))
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.47318330407142639R), Telerik.Reporting.Drawing.Unit.Inch(0.199881911277771R))
        Me.TextBox8.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.Color = System.Drawing.Color.Black
        Me.TextBox8.Style.Font.Name = "Arial"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.StyleName = "Caption"
        Me.TextBox8.Value = "Fecha "
        '
        'TextBox11
        '
        Me.TextBox11.CanGrow = True
        Me.TextBox11.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7140965461730957R), Telerik.Reporting.Drawing.Unit.Inch(0.90019696950912476R))
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.6866576075553894R), Telerik.Reporting.Drawing.Unit.Inch(0.19976381957530975R))
        Me.TextBox11.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.Color = System.Drawing.Color.Black
        Me.TextBox11.Style.Font.Name = "Arial"
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.StyleName = "Caption"
        Me.TextBox11.Value = "Nominal"
        '
        'TextBox12
        '
        Me.TextBox12.CanGrow = True
        Me.TextBox12.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.4008336067199707R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.40000048279762268R), Telerik.Reporting.Drawing.Unit.Inch(0.19976349174976349R))
        Me.TextBox12.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.Color = System.Drawing.Color.Black
        Me.TextBox12.Style.Font.Name = "Arial"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox12.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox12.StyleName = "Caption"
        Me.TextBox12.Value = "Cupón %"
        '
        'TextBox15
        '
        Me.TextBox15.CanGrow = True
        Me.TextBox15.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.8009123802185059R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49992096424102783R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox15.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.Color = System.Drawing.Color.Black
        Me.TextBox15.Style.Font.Name = "Arial"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox15.StyleName = "Caption"
        Me.TextBox15.Value = "Precio"
        '
        'TextBox16
        '
        Me.TextBox16.CanGrow = True
        Me.TextBox16.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3009123802185059R), Telerik.Reporting.Drawing.Unit.Inch(0.90000015497207642R))
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.39992311596870422R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox16.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.Color = System.Drawing.Color.Black
        Me.TextBox16.Style.Font.Name = "Arial"
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox16.StyleName = "Caption"
        Me.TextBox16.Value = "Rend %"
        '
        'TextBox17
        '
        Me.TextBox17.CanGrow = True
        Me.TextBox17.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.7009139060974121R), Telerik.Reporting.Drawing.Unit.Inch(0.6999213695526123R))
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6620843410491943R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox17.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox17.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.Color = System.Drawing.Color.Black
        Me.TextBox17.Style.Font.Bold = True
        Me.TextBox17.Style.Font.Name = "Times New Roman"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox17.StyleName = "Caption"
        Me.TextBox17.Value = "Precios Ultimas Ofertas en Firme"
        '
        'TextBox18
        '
        Me.TextBox18.CanGrow = True
        Me.TextBox18.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.7009139060974121R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.42936280369758606R), Telerik.Reporting.Drawing.Unit.Inch(0.19968514144420624R))
        Me.TextBox18.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.Color = System.Drawing.Color.Black
        Me.TextBox18.Style.Font.Name = "Arial"
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox18.StyleName = "Caption"
        Me.TextBox18.Value = "Fecha"
        '
        'TextBox19
        '
        Me.TextBox19.CanGrow = True
        Me.TextBox19.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.1303558349609375R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49992096424102783R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox19.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.Color = System.Drawing.Color.Black
        Me.TextBox19.Style.Font.Name = "Arial"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox19.StyleName = "Caption"
        Me.TextBox19.Value = "Compra"
        '
        'TextBox4
        '
        Me.TextBox4.CanGrow = True
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.6303558349609375R), Telerik.Reporting.Drawing.Unit.Inch(0.8999602198600769R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.39992311596870422R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox4.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.Color = System.Drawing.Color.Black
        Me.TextBox4.Style.Font.Name = "Arial"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.StyleName = "Caption"
        Me.TextBox4.Value = "Rend %"
        '
        'TextBox20
        '
        Me.TextBox20.CanGrow = True
        Me.TextBox20.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.9630756378173828R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.39992311596870422R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox20.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.Color = System.Drawing.Color.Black
        Me.TextBox20.Style.Font.Name = "Arial"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox20.StyleName = "Caption"
        Me.TextBox20.Value = "Rend %"
        '
        'TextBox21
        '
        Me.TextBox21.CanGrow = True
        Me.TextBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.4630756378173828R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49992096424102783R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox21.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.Color = System.Drawing.Color.Black
        Me.TextBox21.Style.Font.Name = "Arial"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox21.StyleName = "Caption"
        Me.TextBox21.Value = "Venta"
        '
        'TextBox22
        '
        Me.TextBox22.CanGrow = True
        Me.TextBox22.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(9.0303573608398438R), Telerik.Reporting.Drawing.Unit.Inch(0.90019702911376953R))
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.43263816833496094R), Telerik.Reporting.Drawing.Unit.Inch(0.19968514144420624R))
        Me.TextBox22.Style.BorderColor.Default = System.Drawing.Color.Black
        Me.TextBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox22.Style.Color = System.Drawing.Color.Black
        Me.TextBox22.Style.Font.Name = "Arial"
        Me.TextBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(6.0R)
        Me.TextBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox22.StyleName = "Caption"
        Me.TextBox22.Value = "Fecha"
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:d}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1200788021087646R), Telerik.Reporting.Drawing.Unit.Inch(0.50000011920928955R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.2429189682006836R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox30.Style.Color = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.TextBox30.Style.Font.Name = "Times New Roman"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox30.Value = "= ""Precios de Cierre y Ultimas Ofertas en Firme al "" + cdate(Parameters.FechaFina" &
    "l.Value).ToString(""dd/MM/yyyy"")"
        '
        'pageFooter
        '
        Me.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125R)
        Me.pageFooter.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.currentTimeTextBox, Me.pageInfoTextBox})
        Me.pageFooter.Name = "pageFooter"
        '
        'currentTimeTextBox
        '
        Me.currentTimeTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R))
        Me.currentTimeTextBox.Name = "currentTimeTextBox"
        Me.currentTimeTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.46875R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.currentTimeTextBox.Style.Font.Name = "Times New Roman"
        Me.currentTimeTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.currentTimeTextBox.StyleName = "PageInfo"
        Me.currentTimeTextBox.Value = "=NOW()"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(6.0R), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.4479165077209473R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Times New Roman"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.detail.Name = "detail"
        Me.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.detail.Style.Visible = False
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0399999618530273R), Telerik.Reporting.Drawing.Unit.Inch(0.52000004053115845R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'vReporteVentas1
        '
        Me.DataSource = Me.CN
        Me.Filters.Add(New Telerik.Reporting.Filter("=Fields.fecha_oper", Telerik.Reporting.FilterOperator.GreaterOrEqual, "=Parameters.FechaInicial.Value"))
        Me.Filters.Add(New Telerik.Reporting.Filter("=Fields.fecha_oper", Telerik.Reporting.FilterOperator.LessOrEqual, "=Parameters.FechaFinal.Value"))
        Me.Filters.Add(New Telerik.Reporting.Filter("=Fields.fecha_venc", Telerik.Reporting.FilterOperator.GreaterThan, "=Parameters.FechaFinal.Value"))
        Group1.GroupFooter = Me.nemo_insGroupFooter
        Group1.GroupHeader = Me.nemo_insGroupHeader
        Group1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.nemo_ins"))
        Group1.Name = "nemo_insGroup"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.nemo_insGroupHeader, Me.nemo_insGroupFooter, Me.reportFooter, Me.pageHeader, Me.pageFooter, Me.detail})
        Me.Name = "vReporteVentas"
        Me.PageSettings.Landscape = True
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.AllowBlank = False
        ReportParameter1.Name = "FechaInicial"
        ReportParameter1.Text = "Fecha Inicial"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Visible = True
        ReportParameter2.AllowBlank = False
        ReportParameter2.Name = "FechaFinal"
        ReportParameter2.Text = "Fecha Final"
        ReportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter2.Visible = True
        ReportParameter3.Name = "FormatoPrecio"
        ReportParameter3.Text = "Formato Precio (U=Ultimo, P=PPO)"
        ReportParameter3.Value = "U"
        ReportParameter3.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.ReportParameters.Add(ReportParameter3)
        Me.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.descrip_emisor", Telerik.Reporting.SortDirection.Asc))
        Me.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.descrip_instru", Telerik.Reporting.SortDirection.Asc))
        Me.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.fecha_oper", Telerik.Reporting.SortDirection.Asc))
        Me.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.cod_isin", Telerik.Reporting.SortDirection.Asc))
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Title")})
        StyleRule1.Style.Color = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(74, Byte), Integer))
        StyleRule1.Style.Font.Name = "Georgia"
        StyleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18.0R)
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Caption")})
        StyleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(140, Byte), Integer), CType(CType(174, Byte), Integer), CType(CType(173, Byte), Integer))
        StyleRule2.Style.BorderColor.Default = System.Drawing.Color.FromArgb(CType(CType(115, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(212, Byte), Integer))
        StyleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Dotted
        StyleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1.0R)
        StyleRule2.Style.Color = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(243, Byte), Integer))
        StyleRule2.Style.Font.Name = "Georgia"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        StyleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("Data")})
        StyleRule3.Style.Font.Name = "Georgia"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9.0R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector("PageInfo")})
        StyleRule4.Style.Font.Name = "Georgia"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        StyleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(10.5R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents CN As Telerik.Reporting.SqlDataSource
    Friend WithEvents nemo_insGroupHeader As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents nemo_insGroupFooter As Telerik.Reporting.GroupFooterSection
    Friend WithEvents nemo_insGroup As Telerik.Reporting.Group
    Friend WithEvents reportFooter As Telerik.Reporting.ReportFooterSection
    Friend WithEvents cod_isinCaptionTextBox As Telerik.Reporting.TextBox
    Friend WithEvents nemo_insCaptionTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents pageHeader As Telerik.Reporting.PageHeaderSection
    Friend WithEvents pageFooter As Telerik.Reporting.PageFooterSection
    Friend WithEvents currentTimeTextBox As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents cod_isinDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents nemo_insDataTextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents descrip_emisorDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents descrip_instruDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents fecha_emiDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents fecha_vencDataTextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox22 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox23 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox28 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox29 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents Shape1 As Telerik.Reporting.Shape
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox32 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class