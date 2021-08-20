Partial Class MK_PreciosCierreBonosTransados

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
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
        Dim TableGroup12 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup13 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup14 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MK_PreciosCierreBonosTransados))
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter4 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter5 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox36 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox7 = New Telerik.Reporting.TextBox()
        Me.TextBox23 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox11 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.SqlTipo = New Telerik.Reporting.SqlDataSource()
        Me.SqlTipoMercado = New Telerik.Reporting.SqlDataSource()
        Me.SqlMercado = New Telerik.Reporting.SqlDataSource()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.Table1 = New Telerik.Reporting.Table()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox22 = New Telerik.Reporting.TextBox()
        Me.TextBox37 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.SqlMK_PreciosCierreBonosTransados = New Telerik.Reporting.SqlDataSource()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox3
        '
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97052866220474243R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox3.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox3.Style.Color = System.Drawing.Color.Black
        Me.TextBox3.Style.Font.Name = "Calibri"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.StyleName = "Civic.TableHeader"
        Me.TextBox3.Value = "Código ISIN"
        '
        'TextBox36
        '
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.88773584365844727R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox36.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox36.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox36.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox36.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox36.Style.Color = System.Drawing.Color.Black
        Me.TextBox36.Style.Font.Name = "Calibri"
        Me.TextBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox36.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox36.StyleName = "Civic.TableHeader"
        Me.TextBox36.Value = "Código Local"
        '
        'TextBox4
        '
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5449463129043579R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox4.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox4.Style.Color = System.Drawing.Color.Black
        Me.TextBox4.Style.Font.Name = "Calibri"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.StyleName = "Civic.TableHeader"
        Me.TextBox4.Value = "Emisor"
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6807175874710083R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox5.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox5.Style.Color = System.Drawing.Color.Black
        Me.TextBox5.Style.Font.Name = "Calibri"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = "Civic.TableHeader"
        Me.TextBox5.Value = "Descripción Instrumento"
        '
        'TextBox6
        '
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.667654275894165R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox6.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox6.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox6.Style.Color = System.Drawing.Color.Black
        Me.TextBox6.Style.Font.Name = "Calibri"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox6.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.StyleName = "Civic.TableHeader"
        Me.TextBox6.Value = "Fecha Emi"
        '
        'TextBox7
        '
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.64676690101623535R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox7.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox7.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox7.Style.Color = System.Drawing.Color.Black
        Me.TextBox7.Style.Font.Name = "Calibri"
        Me.TextBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox7.StyleName = "Civic.TableHeader"
        Me.TextBox7.Value = "Fecha Venc"
        '
        'TextBox23
        '
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.3983492851257324R), Telerik.Reporting.Drawing.Unit.Inch(0.31250008940696716R))
        Me.TextBox23.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TextBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox23.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox23.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox23.Style.Color = System.Drawing.Color.White
        Me.TextBox23.Style.Font.Name = "Calibri"
        Me.TextBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox23.StyleName = "Civic.TableHeader"
        Me.TextBox23.Value = "Datos de la Emisión"
        '
        'TextBox8
        '
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65797102451324463R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox8.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox8.Style.Color = System.Drawing.Color.Black
        Me.TextBox8.Style.Font.Name = "Calibri"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.StyleName = "Civic.TableHeader"
        Me.TextBox8.Value = "Fecha Oper"
        '
        'TextBox10
        '
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0861717462539673R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox10.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox10.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox10.Style.Color = System.Drawing.Color.Black
        Me.TextBox10.Style.Font.Name = "Calibri"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox10.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.StyleName = "Civic.TableHeader"
        Me.TextBox10.Value = "Nominal Negociado"
        '
        'TextBox11
        '
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.59530621767044067R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox11.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox11.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox11.Style.Color = System.Drawing.Color.Black
        Me.TextBox11.Style.Font.Name = "Calibri"
        Me.TextBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox11.StyleName = "Civic.TableHeader"
        Me.TextBox11.Value = "Tasa Nom %"
        '
        'TextBox20
        '
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62587827444076538R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox20.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox20.Style.Color = System.Drawing.Color.Black
        Me.TextBox20.Style.Font.Name = "Calibri"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox20.StyleName = "Civic.TableHeader"
        Me.TextBox20.Value = "Precio %"
        '
        'TextBox24
        '
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.636322021484375R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox24.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(184, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.TextBox24.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox24.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox24.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox24.Style.Color = System.Drawing.Color.Black
        Me.TextBox24.Style.Font.Name = "Calibri"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.StyleName = "Civic.TableHeader"
        Me.TextBox24.Value = "Rend.  %"
        '
        'TextBox27
        '
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.601649284362793R), Telerik.Reporting.Drawing.Unit.Inch(0.31250008940696716R))
        Me.TextBox27.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(54, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.TextBox27.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox27.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox27.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.30000001192092896R)
        Me.TextBox27.Style.Color = System.Drawing.Color.White
        Me.TextBox27.Style.Font.Name = "Calibri"
        Me.TextBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox27.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox27.StyleName = "Civic.TableHeader"
        Me.TextBox27.Value = "Datos de la Negociación"
        '
        'SqlTipo
        '
        Me.SqlTipo.ConnectionString = "CN"
        Me.SqlTipo.Name = "SqlTipo"
        Me.SqlTipo.SelectCommand = "Select 'Ultimo' AS Nombre, 'U' AS Valor UNION  Select 'Ponderado' AS Nombre, 'P' " &
    "AS Valor "
        '
        'SqlTipoMercado
        '
        Me.SqlTipoMercado.ConnectionString = "CN"
        Me.SqlTipoMercado.Name = "SqlTipoMercado"
        Me.SqlTipoMercado.SelectCommand = "select distinct TipoMercadoID, TipoMercado " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM vMercados"
        '
        'SqlMercado
        '
        Me.SqlMercado.ConnectionString = "CN"
        Me.SqlMercado.Name = "SqlMercado"
        Me.SqlMercado.SelectCommand = "SELECT        TipoMercadoID,Nombre, CodigoMercado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM            vMercados" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "WHE" &
    "RE        (CodigoMercado <> '')" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ORDER BY Nombre" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.800000011920929R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.Table1})
        Me.detail.Name = "detail"
        '
        'Table1
        '
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.970528781414032R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.88773608207702637R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.5449464321136475R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.680717945098877R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.66765433549880981R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.6467670202255249R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.65797102451324463R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.0861719846725464R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.59530627727508545R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.62587827444076538R)))
        Me.Table1.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(0.63632220029830933R)))
        Me.Table1.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R)))
        Me.Table1.Body.SetCellContent(0, 0, Me.TextBox12)
        Me.Table1.Body.SetCellContent(0, 2, Me.TextBox13)
        Me.Table1.Body.SetCellContent(0, 3, Me.TextBox14)
        Me.Table1.Body.SetCellContent(0, 4, Me.TextBox15)
        Me.Table1.Body.SetCellContent(0, 5, Me.TextBox17)
        Me.Table1.Body.SetCellContent(0, 9, Me.TextBox19)
        Me.Table1.Body.SetCellContent(0, 10, Me.TextBox22)
        Me.Table1.Body.SetCellContent(0, 1, Me.TextBox37)
        Me.Table1.Body.SetCellContent(0, 7, Me.TextBox16)
        Me.Table1.Body.SetCellContent(0, 6, Me.TextBox18)
        Me.Table1.Body.SetCellContent(0, 8, Me.TextBox21)
        TableGroup2.Name = "Group1"
        TableGroup2.ReportItem = Me.TextBox3
        TableGroup3.Name = "Group23"
        TableGroup3.ReportItem = Me.TextBox36
        TableGroup4.Name = "Group2"
        TableGroup4.ReportItem = Me.TextBox4
        TableGroup5.Name = "Group3"
        TableGroup5.ReportItem = Me.TextBox5
        TableGroup6.Name = "Group4"
        TableGroup6.ReportItem = Me.TextBox6
        TableGroup7.Name = "Group6"
        TableGroup7.ReportItem = Me.TextBox7
        TableGroup1.ChildGroups.Add(TableGroup2)
        TableGroup1.ChildGroups.Add(TableGroup3)
        TableGroup1.ChildGroups.Add(TableGroup4)
        TableGroup1.ChildGroups.Add(TableGroup5)
        TableGroup1.ChildGroups.Add(TableGroup6)
        TableGroup1.ChildGroups.Add(TableGroup7)
        TableGroup1.ReportItem = Me.TextBox23
        TableGroup9.Name = "Group7"
        TableGroup9.ReportItem = Me.TextBox8
        TableGroup10.Name = "Group5"
        TableGroup10.ReportItem = Me.TextBox10
        TableGroup11.Name = "Group10"
        TableGroup11.ReportItem = Me.TextBox11
        TableGroup12.Name = "Group8"
        TableGroup12.ReportItem = Me.TextBox20
        TableGroup13.Name = "Group11"
        TableGroup13.ReportItem = Me.TextBox24
        TableGroup8.ChildGroups.Add(TableGroup9)
        TableGroup8.ChildGroups.Add(TableGroup10)
        TableGroup8.ChildGroups.Add(TableGroup11)
        TableGroup8.ChildGroups.Add(TableGroup12)
        TableGroup8.ChildGroups.Add(TableGroup13)
        TableGroup8.Name = "Group16"
        TableGroup8.ReportItem = Me.TextBox27
        Me.Table1.ColumnGroups.Add(TableGroup1)
        Me.Table1.ColumnGroups.Add(TableGroup8)
        Me.Table1.ColumnHeadersPrintOnEveryPage = True
        Me.Table1.DataSource = Me.SqlMK_PreciosCierreBonosTransados
        Me.Table1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox12, Me.TextBox37, Me.TextBox13, Me.TextBox14, Me.TextBox15, Me.TextBox17, Me.TextBox18, Me.TextBox16, Me.TextBox21, Me.TextBox19, Me.TextBox22, Me.TextBox23, Me.TextBox3, Me.TextBox36, Me.TextBox4, Me.TextBox5, Me.TextBox6, Me.TextBox7, Me.TextBox27, Me.TextBox8, Me.TextBox10, Me.TextBox11, Me.TextBox20, Me.TextBox24})
        Me.Table1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.Table1.Name = "Table1"
        TableGroup14.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup14.Name = "Detail"
        Me.Table1.RowGroups.Add(TableGroup14)
        Me.Table1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(10.0R), Telerik.Reporting.Drawing.Unit.Inch(0.71250003576278687R))
        Me.Table1.StyleName = "Civic.TableNormal"
        '
        'TextBox12
        '
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.97052866220474243R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox12.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox12.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox12.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox12.Style.Font.Name = "Calibri"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.StyleName = "Civic.TableBody"
        Me.TextBox12.Value = "=Fields.cod_isin"
        '
        'TextBox13
        '
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5449463129043579R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox13.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox13.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox13.Style.Font.Name = "Calibri"
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox13.StyleName = "Civic.TableBody"
        Me.TextBox13.Value = "=Fields.descrip_emisor"
        '
        'TextBox14
        '
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6807175874710083R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox14.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox14.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox14.Style.Font.Name = "Calibri"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.StyleName = "Civic.TableBody"
        Me.TextBox14.Value = "=Fields.descrip_instru"
        '
        'TextBox15
        '
        Me.TextBox15.Format = "{0:d}"
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.667654275894165R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox15.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox15.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox15.Style.Font.Name = "Calibri"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.StyleName = "Civic.TableBody"
        Me.TextBox15.Value = "=Fields.fecha_emi"
        '
        'TextBox17
        '
        Me.TextBox17.Format = "{0:d}"
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.64676690101623535R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox17.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox17.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox17.Style.Font.Name = "Calibri"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.StyleName = "Civic.TableBody"
        Me.TextBox17.Value = "=Fields.fecha_venc"
        '
        'TextBox19
        '
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62587827444076538R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox19.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox19.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox19.Style.Font.Name = "Calibri"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox19.StyleName = "Civic.TableBody"
        Me.TextBox19.Value = "=Fields.precio"
        '
        'TextBox22
        '
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.636322021484375R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox22.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox22.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox22.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox22.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox22.Style.Font.Name = "Calibri"
        Me.TextBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox22.StyleName = "Civic.TableBody"
        Me.TextBox22.Value = "=Fields.yield"
        '
        'TextBox37
        '
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.88773584365844727R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox37.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox37.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox37.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox37.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox37.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox37.Style.Font.Name = "Calibri"
        Me.TextBox37.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox37.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox37.StyleName = "Civic.TableBody"
        Me.TextBox37.Value = "=Fields.nemo_ins"
        '
        'TextBox16
        '
        Me.TextBox16.Format = "{0:N2}"
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0861717462539673R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox16.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox16.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox16.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox16.Style.Font.Name = "Calibri"
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox16.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox16.StyleName = "Civic.TableBody"
        Me.TextBox16.Value = "=Fields.valor_nom_tot"
        '
        'TextBox18
        '
        Me.TextBox18.Format = "{0:d}"
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.65797102451324463R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox18.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox18.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox18.Style.Font.Name = "Calibri"
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox18.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox18.StyleName = "Civic.TableBody"
        Me.TextBox18.Value = "=Fields.fecha_oper"
        '
        'TextBox21
        '
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.59530621767044067R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox21.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox21.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox21.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox21.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(0.5R)
        Me.TextBox21.Style.Font.Name = "Calibri"
        Me.TextBox21.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox21.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.TextBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox21.StyleName = "Civic.TableBody"
        Me.TextBox21.Value = "=Fields.tasa_interes"
        '
        'SqlMK_PreciosCierreBonosTransados
        '
        Me.SqlMK_PreciosCierreBonosTransados.ConnectionString = "CN"
        Me.SqlMK_PreciosCierreBonosTransados.Name = "SqlMK_PreciosCierreBonosTransados"
        Me.SqlMK_PreciosCierreBonosTransados.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@FechaInicio", System.Data.DbType.[Date], "=Parameters.FechaInicio.Value"), New Telerik.Reporting.SqlDataSourceParameter("@FechaFinal", System.Data.DbType.[Date], "=Parameters.FechaFinal.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Formato", System.Data.DbType.AnsiString, "=Parameters.Tipo.Value"), New Telerik.Reporting.SqlDataSourceParameter("@Mercado", System.Data.DbType.AnsiString, "=Parameters.Mercado.Value")})
        Me.SqlMK_PreciosCierreBonosTransados.SelectCommand = "dbo.SP_VentasUltimoPonderado"
        Me.SqlMK_PreciosCierreBonosTransados.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageInfoTextBox, Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.7515830993652344R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.2484169006347656R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Calibri"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.4032108783721924R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD / {Now()}"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.74791669845581055R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1, Me.TextBox30, Me.TextBox9, Me.TextBox25, Me.PictureBox2})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.000039339065551757812R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.0838890075683594R), Telerik.Reporting.Drawing.Unit.Inch(0.19992129504680634R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox1.Style.Color = System.Drawing.Color.Black
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox1.StyleName = "Title"
        Me.TextBox1.Value = "Bolsa y Mercados de Valores de la República Dominicana, S. A." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:d}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.4981134831905365R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.0799999237060547R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox30.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox30.Style.Color = System.Drawing.Color.Black
        Me.TextBox30.Style.Font.Bold = False
        Me.TextBox30.Style.Font.Name = "Calibri"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.Value = "Desde el {ConvertirFechas.Formatdate(Parameters.FechaInicio.Value)} hasta el {Con" &
    "vertirFechas.Formatdate(Parameters.FechaFinal.Value)}"
        '
        'TextBox9
        '
        Me.TextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.3501180112361908R))
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.0838890075683594R), Telerik.Reporting.Drawing.Unit.Inch(0.14791679382324219R))
        Me.TextBox9.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox9.Style.Color = System.Drawing.Color.Black
        Me.TextBox9.Style.Font.Bold = False
        Me.TextBox9.Style.Font.Name = "Calibri"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.StyleName = "Title"
        Me.TextBox9.Value = "Precios de Cierre de los  Bonos Transados"
        '
        'TextBox25
        '
        Me.TextBox25.Format = "{0:d}"
        Me.TextBox25.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0.20003931224346161R))
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(8.1423749923706055R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox25.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox25.Style.Color = System.Drawing.Color.Black
        Me.TextBox25.Style.Font.Bold = True
        Me.TextBox25.Style.Font.Italic = True
        Me.TextBox25.Style.Font.Name = "Calibri"
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.Value = "{Parameters.TipoMercado.Label} {IIF(Parameters.Mercado.Value<>'','->','')} {Param" &
    "eters.Mercado.Label}  "
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(8.14249324798584R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7322832345962524R), Telerik.Reporting.Drawing.Unit.Inch(0.42799559235572815R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'MK_PreciosCierreBonosTransados
        '
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "MK_PreciosCierreBonosTransados"
        Me.PageSettings.Landscape = True
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "FechaInicio"
        ReportParameter1.Text = "Fecha Inicio"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = True
        ReportParameter2.Name = "FechaFinal"
        ReportParameter2.Text = "Fecha Final"
        ReportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter2.Value = "=Today()"
        ReportParameter2.Visible = True
        ReportParameter3.AvailableValues.DataSource = Me.SqlTipo
        ReportParameter3.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter3.AvailableValues.ValueMember = "= Fields.Valor"
        ReportParameter3.Name = "Tipo"
        ReportParameter3.Text = "Tipo"
        ReportParameter3.Visible = True
        ReportParameter4.AvailableValues.DataSource = Me.SqlTipoMercado
        ReportParameter4.AvailableValues.DisplayMember = "= Fields.TipoMercado"
        ReportParameter4.AvailableValues.ValueMember = "= Fields.TipoMercadoID"
        ReportParameter4.Name = "TipoMercado"
        ReportParameter4.Text = "Tipo Mercado"
        ReportParameter4.Visible = True
        ReportParameter5.AllowNull = True
        ReportParameter5.AvailableValues.DataSource = Me.SqlMercado
        ReportParameter5.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter5.AvailableValues.Filters.Add(New Telerik.Reporting.Filter("=Fields.TipoMercadoID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.TipoMercado.Value"))
        ReportParameter5.AvailableValues.ValueMember = "= Fields.CodigoMercado"
        ReportParameter5.Name = "Mercado"
        ReportParameter5.Text = "Mercado"
        ReportParameter5.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.ReportParameters.Add(ReportParameter3)
        Me.ReportParameters.Add(ReportParameter4)
        Me.ReportParameters.Add(ReportParameter5)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(10.0R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents SqlTipo As Telerik.Reporting.SqlDataSource
    Friend WithEvents Table1 As Telerik.Reporting.Table
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox22 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox37 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox36 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox7 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox23 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox11 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents SqlMK_PreciosCierreBonosTransados As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents SqlMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlTipoMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class