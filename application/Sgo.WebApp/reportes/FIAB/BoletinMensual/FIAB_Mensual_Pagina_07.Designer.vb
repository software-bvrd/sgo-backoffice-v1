Partial Class FIAB_Mensual_Pagina_07

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FIAB_Mensual_Pagina_07))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup4 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup5 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup6 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup7 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup8 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup9 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.TextBox22 = New Telerik.Reporting.TextBox()
        Me.TextBox23 = New Telerik.Reporting.TextBox()
        Me.SqlConfiguracion = New Telerik.Reporting.SqlDataSource()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.HtmlTextBox12 = New Telerik.Reporting.HtmlTextBox()
        Me.HtmlTextBox2 = New Telerik.Reporting.HtmlTextBox()
        Me.HtmlTextBox7 = New Telerik.Reporting.HtmlTextBox()
        Me.Table2 = New Telerik.Reporting.Table()
        Me.TextBox5 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox9 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox13 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox17 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox28 = New Telerik.Reporting.TextBox()
        Me.TextBox29 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.HtmlTextBox9 = New Telerik.Reporting.HtmlTextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox21 = New Telerik.Reporting.TextBox()
        Me.HtmlTextBox4 = New Telerik.Reporting.HtmlTextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.HtmlTextBox1 = New Telerik.Reporting.HtmlTextBox()
        Me.TextBox15 = New Telerik.Reporting.TextBox()
        Me.HtmlTextBox3 = New Telerik.Reporting.HtmlTextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'TextBox20
        '
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2023167610168457R), Telerik.Reporting.Drawing.Unit.Cm(0.70379137992858887R))
        Me.TextBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox20.Style.Font.Bold = False
        Me.TextBox20.Style.Font.Name = "Times New Roman"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox20.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox20.StyleName = ""
        Me.TextBox20.Value = "Emisiones"
        '
        'TextBox22
        '
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Cm(0.70379132032394409R))
        Me.TextBox22.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox22.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox22.Style.Font.Bold = True
        Me.TextBox22.Style.Font.Name = "Times New Roman"
        Me.TextBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox22.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox22.StyleName = ""
        Me.TextBox22.Value = resources.GetString("TextBox22.Value")
        '
        'TextBox23
        '
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Cm(0.70379132032394409R))
        Me.TextBox23.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox23.Style.Font.Bold = True
        Me.TextBox23.Style.Font.Name = "Times New Roman"
        Me.TextBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox23.StyleName = ""
        Me.TextBox23.Value = "{ConvertirFechas.FormatdateAsMonthName(Parameters.FechaOperacion.Value)} - {Conve" &
    "rtirFechas.FormatdateYear(Parameters.FechaOperacion.Value)}" & Global.Microsoft.VisualBasic.ChrW(9)
        '
        'SqlConfiguracion
        '
        Me.SqlConfiguracion.ConnectionString = "CN"
        Me.SqlConfiguracion.Name = "SqlConfiguracion"
        Me.SqlConfiguracion.SelectCommand = "SELECT       *" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "FROM        Configuracion"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(24.6919002532959R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.HtmlTextBox12, Me.HtmlTextBox2, Me.HtmlTextBox7, Me.Table2, Me.HtmlTextBox9, Me.HtmlTextBox1, Me.HtmlTextBox3})
        Me.detail.Name = "detail"
        '
        'HtmlTextBox12
        '
        Me.HtmlTextBox12.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5383350849151611R), Telerik.Reporting.Drawing.Unit.Cm(0.39189991354942322R))
        Me.HtmlTextBox12.Name = "HtmlTextBox12"
        Me.HtmlTextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.047998428344727R), Telerik.Reporting.Drawing.Unit.Cm(0.60000014305114746R))
        Me.HtmlTextBox12.Style.Font.Name = "Times New Roman"
        Me.HtmlTextBox12.Value = resources.GetString("HtmlTextBox12.Value")
        '
        'HtmlTextBox2
        '
        Me.HtmlTextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5983340740203857R), Telerik.Reporting.Drawing.Unit.Cm(0.99210065603256226R))
        Me.HtmlTextBox2.Name = "HtmlTextBox2"
        Me.HtmlTextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.988000869750977R), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791R))
        Me.HtmlTextBox2.Style.Font.Name = "Times New Roman"
        Me.HtmlTextBox2.Value = resources.GetString("HtmlTextBox2.Value")
        '
        'HtmlTextBox7
        '
        Me.HtmlTextBox7.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5983340740203857R), Telerik.Reporting.Drawing.Unit.Cm(1.5923010110855103R))
        Me.HtmlTextBox7.Name = "HtmlTextBox7"
        Me.HtmlTextBox7.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.988000869750977R), Telerik.Reporting.Drawing.Unit.Cm(2.0995988845825195R))
        Me.HtmlTextBox7.Style.Font.Name = "Times New Roman"
        Me.HtmlTextBox7.Value = resources.GetString("HtmlTextBox7.Value")
        '
        'Table2
        '
        Me.Table2.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(3.20231556892395R)))
        Me.Table2.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0892839431762695R)))
        Me.Table2.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.0892839431762695R)))
        Me.Table2.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R)))
        Me.Table2.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Cm(0.6508747935295105R)))
        Me.Table2.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R)))
        Me.Table2.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999986886978149R)))
        Me.Table2.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.19999986886978149R)))
        Me.Table2.Body.SetCellContent(1, 1, Me.TextBox5)
        Me.Table2.Body.SetCellContent(1, 2, Me.TextBox8)
        Me.Table2.Body.SetCellContent(1, 0, Me.TextBox9)
        Me.Table2.Body.SetCellContent(3, 0, Me.TextBox15)
        Me.Table2.Body.SetCellContent(4, 0, Me.TextBox18)
        Me.Table2.Body.SetCellContent(3, 1, Me.TextBox13)
        Me.Table2.Body.SetCellContent(3, 2, Me.TextBox14)
        Me.Table2.Body.SetCellContent(4, 1, Me.TextBox17)
        Me.Table2.Body.SetCellContent(4, 2, Me.TextBox19)
        Me.Table2.Body.SetCellContent(0, 0, Me.TextBox24)
        Me.Table2.Body.SetCellContent(0, 1, Me.TextBox25)
        Me.Table2.Body.SetCellContent(0, 2, Me.TextBox26)
        Me.Table2.Body.SetCellContent(2, 1, Me.TextBox28)
        Me.Table2.Body.SetCellContent(2, 2, Me.TextBox29)
        Me.Table2.Body.SetCellContent(2, 0, Me.TextBox30)
        TableGroup1.Name = "group"
        TableGroup1.ReportItem = Me.TextBox20
        TableGroup2.Name = "tableGroup"
        TableGroup2.ReportItem = Me.TextBox22
        TableGroup3.Name = "tableGroup1"
        TableGroup3.ReportItem = Me.TextBox23
        Me.Table2.ColumnGroups.Add(TableGroup1)
        Me.Table2.ColumnGroups.Add(TableGroup2)
        Me.Table2.ColumnGroups.Add(TableGroup3)
        Me.Table2.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox24, Me.TextBox25, Me.TextBox26, Me.TextBox9, Me.TextBox5, Me.TextBox8, Me.TextBox30, Me.TextBox28, Me.TextBox29, Me.TextBox15, Me.TextBox13, Me.TextBox14, Me.TextBox18, Me.TextBox17, Me.TextBox19, Me.TextBox20, Me.TextBox22, Me.TextBox23})
        Me.Table2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.0983343124389648R), Telerik.Reporting.Drawing.Unit.Cm(5.391899585723877R))
        Me.Table2.Name = "Table2"
        TableGroup5.Name = "group6"
        TableGroup6.Name = "group1"
        TableGroup7.Name = "group7"
        TableGroup8.Name = "group2"
        TableGroup9.Name = "group3"
        TableGroup4.ChildGroups.Add(TableGroup5)
        TableGroup4.ChildGroups.Add(TableGroup6)
        TableGroup4.ChildGroups.Add(TableGroup7)
        TableGroup4.ChildGroups.Add(TableGroup8)
        TableGroup4.ChildGroups.Add(TableGroup9)
        TableGroup4.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup4.Name = "detailTableGroup"
        Me.Table2.RowGroups.Add(TableGroup4)
        Me.Table2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.312450408935547R), Telerik.Reporting.Drawing.Unit.Cm(3.3866653442382812R))
        Me.Table2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        '
        'TextBox5
        '
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Cm(0.65087473392486572R))
        Me.TextBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox5.Style.Font.Bold = False
        Me.TextBox5.Style.Font.Name = "Times New Roman"
        Me.TextBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox5.StyleName = ""
        '
        'TextBox8
        '
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Cm(0.65087473392486572R))
        Me.TextBox8.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox8.Style.Font.Bold = False
        Me.TextBox8.Style.Font.Name = "Times New Roman"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.StyleName = ""
        '
        'TextBox9
        '
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2023167610168457R), Telerik.Reporting.Drawing.Unit.Cm(0.6508747935295105R))
        Me.TextBox9.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox9.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox9.Style.Font.Bold = False
        Me.TextBox9.Style.Font.Name = "Times New Roman"
        Me.TextBox9.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox9.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox9.StyleName = ""
        Me.TextBox9.Value = "     Sector Privado"
        '
        'TextBox18
        '
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2023167610168457R), Telerik.Reporting.Drawing.Unit.Inch(0.19999986886978149R))
        Me.TextBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox18.Style.Font.Bold = False
        Me.TextBox18.Style.Font.Name = "Times New Roman"
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox18.StyleName = ""
        Me.TextBox18.Value = "Total"
        '
        'TextBox13
        '
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox13.Style.Font.Bold = False
        Me.TextBox13.Style.Font.Name = "Times New Roman"
        Me.TextBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox13.StyleName = ""
        '
        'TextBox14
        '
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox14.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox14.Style.Font.Bold = False
        Me.TextBox14.Style.Font.Name = "Times New Roman"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.StyleName = ""
        '
        'TextBox17
        '
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox17.Style.Font.Bold = False
        Me.TextBox17.Style.Font.Name = "Times New Roman"
        Me.TextBox17.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox17.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox17.StyleName = ""
        '
        'TextBox19
        '
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.19999998807907105R))
        Me.TextBox19.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox19.Style.Font.Bold = False
        Me.TextBox19.Style.Font.Name = "Times New Roman"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox19.StyleName = ""
        '
        'TextBox24
        '
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2023167610168457R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox24.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox24.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox24.Style.Font.Name = "Times New Roman"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.StyleName = ""
        Me.TextBox24.Value = "Domésticas"
        '
        'TextBox25
        '
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox25.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox25.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox25.Style.Font.Name = "Times New Roman"
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox25.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.StyleName = ""
        '
        'TextBox26
        '
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox26.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox26.Style.Font.Name = "Times New Roman"
        Me.TextBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox26.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox26.StyleName = ""
        '
        'TextBox28
        '
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox28.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox28.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox28.Style.Font.Name = "Times New Roman"
        Me.TextBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox28.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox28.StyleName = ""
        '
        'TextBox29
        '
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(4.0892848968505859R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox29.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox29.Style.Font.Name = "Times New Roman"
        Me.TextBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox29.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox29.StyleName = ""
        '
        'TextBox30
        '
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2023167610168457R), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985R))
        Me.TextBox30.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox30.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox30.Style.Font.Bold = False
        Me.TextBox30.Style.Font.Name = "Times New Roman"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.StyleName = ""
        Me.TextBox30.Value = "     Sector Público (Nacional, provicional o estatal) "
        '
        'HtmlTextBox9
        '
        Me.HtmlTextBox9.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(4.0983343124389648R), Telerik.Reporting.Drawing.Unit.Cm(8.8919000625610352R))
        Me.HtmlTextBox9.Name = "HtmlTextBox9"
        Me.HtmlTextBox9.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.312450408935547R), Telerik.Reporting.Drawing.Unit.Cm(0.51313519477844238R))
        Me.HtmlTextBox9.Style.Font.Name = "Times New Roman"
        Me.HtmlTextBox9.Value = resources.GetString("HtmlTextBox9.Value")
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23625946044921875R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox21, Me.HtmlTextBox4})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox21
        '
        Me.TextBox21.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.3167743682861328R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1811027526855469R), Telerik.Reporting.Drawing.Unit.Inch(0.23622004687786102R))
        Me.TextBox21.Value = "= CStr(pageNumber)"
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
        'HtmlTextBox1
        '
        Me.HtmlTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5999982357025146R), Telerik.Reporting.Drawing.Unit.Cm(3.9919002056121826R))
        Me.HtmlTextBox1.Name = "HtmlTextBox1"
        Me.HtmlTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.988000869750977R), Telerik.Reporting.Drawing.Unit.Cm(0.50000017881393433R))
        Me.HtmlTextBox1.Style.Font.Name = "Times New Roman"
        Me.HtmlTextBox1.Value = resources.GetString("HtmlTextBox1.Value")
        '
        'TextBox15
        '
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2023167610168457R), Telerik.Reporting.Drawing.Unit.Inch(0.19999986886978149R))
        Me.TextBox15.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None
        Me.TextBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid
        Me.TextBox15.Style.Font.Name = "Times New Roman"
        Me.TextBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11.0R)
        Me.TextBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox15.StyleName = ""
        Me.TextBox15.Value = "Extranjeras (*)"
        '
        'HtmlTextBox3
        '
        Me.HtmlTextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(3.5999982357025146R), Telerik.Reporting.Drawing.Unit.Cm(4.492100715637207R))
        Me.HtmlTextBox3.Name = "HtmlTextBox3"
        Me.HtmlTextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(16.988000869750977R), Telerik.Reporting.Drawing.Unit.Cm(0.60000002384185791R))
        Me.HtmlTextBox3.Style.Font.Name = "Times New Roman"
        Me.HtmlTextBox3.Value = resources.GetString("HtmlTextBox3.Value")
        '
        'FIAB_Mensual_Pagina_07
        '
        Me.DataSource = Me.SqlConfiguracion
        Me.DocumentMapText = "FIAB_Mensual_Pagina_07"
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "FIAB_Mensual_Pagina_07"
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
        Me.UnitOfMeasure = Telerik.Reporting.Drawing.UnitType.Inch
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(21.58460807800293R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents ReportHeaderSection1 As Telerik.Reporting.ReportHeaderSection
    Friend WithEvents SqlConfiguracion As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents HtmlTextBox4 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents TextBox21 As Telerik.Reporting.TextBox
    Friend WithEvents HtmlTextBox12 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents HtmlTextBox2 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents HtmlTextBox7 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents Table2 As Telerik.Reporting.Table
    Friend WithEvents TextBox5 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox9 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox13 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox17 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox28 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox29 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox22 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox23 As Telerik.Reporting.TextBox
    Friend WithEvents HtmlTextBox9 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents TextBox15 As Telerik.Reporting.TextBox
    Friend WithEvents HtmlTextBox1 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents HtmlTextBox3 As Telerik.Reporting.HtmlTextBox
End Class