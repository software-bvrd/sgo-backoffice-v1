Partial Class PlanillaPuestoBolsa

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PlanillaPuestoBolsa))
        Dim TableGroup1 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup2 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim TableGroup3 As Telerik.Reporting.TableGroup = New Telerik.Reporting.TableGroup()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule2 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim StyleRule3 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector1 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Dim StyleRule4 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Dim DescendantSelector2 As Telerik.Reporting.Drawing.DescendantSelector = New Telerik.Reporting.Drawing.DescendantSelector()
        Me.groupFooterSection = New Telerik.Reporting.GroupFooterSection()
        Me.groupHeaderSection = New Telerik.Reporting.GroupHeaderSection()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox6 = New Telerik.Reporting.TextBox()
        Me.TextBox8 = New Telerik.Reporting.TextBox()
        Me.TextBox10 = New Telerik.Reporting.TextBox()
        Me.TextBox12 = New Telerik.Reporting.TextBox()
        Me.TextBox14 = New Telerik.Reporting.TextBox()
        Me.TextBox16 = New Telerik.Reporting.TextBox()
        Me.TextBox18 = New Telerik.Reporting.TextBox()
        Me.TextBox19 = New Telerik.Reporting.TextBox()
        Me.TextBox20 = New Telerik.Reporting.TextBox()
        Me.Table2 = New Telerik.Reporting.Table()
        Me.TextBox26 = New Telerik.Reporting.TextBox()
        Me.TextBox28 = New Telerik.Reporting.TextBox()
        Me.SqlPersonalEjecutivo = New Telerik.Reporting.SqlDataSource()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.TextBox27 = New Telerik.Reporting.TextBox()
        Me.TextBox29 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.TextBox31 = New Telerik.Reporting.TextBox()
        Me.TextBox32 = New Telerik.Reporting.TextBox()
        Me.TextBox33 = New Telerik.Reporting.TextBox()
        Me.TextBox34 = New Telerik.Reporting.TextBox()
        Me.TextBox35 = New Telerik.Reporting.TextBox()
        Me.TextBox36 = New Telerik.Reporting.TextBox()
        Me.SqlPuestoBolsa = New Telerik.Reporting.SqlDataSource()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox22 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox25 = New Telerik.Reporting.TextBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.SP_PlanillaPuestoBolsa = New Telerik.Reporting.SqlDataSource()
        CType(Me,System.ComponentModel.ISupportInitialize).BeginInit
        '
        'groupFooterSection
        '
        Me.groupFooterSection.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.groupFooterSection.Name = "groupFooterSection"
        '
        'groupHeaderSection
        '
        Me.groupHeaderSection.Height = Telerik.Reporting.Drawing.Unit.Inch(3.1791272163391113R)
        Me.groupHeaderSection.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox3, Me.TextBox2, Me.TextBox6, Me.TextBox8, Me.TextBox10, Me.TextBox12, Me.TextBox14, Me.TextBox16, Me.TextBox18, Me.TextBox19, Me.TextBox20, Me.Table2, Me.TextBox4, Me.TextBox27, Me.TextBox29, Me.TextBox30, Me.TextBox31, Me.TextBox32, Me.TextBox33, Me.TextBox34, Me.TextBox35, Me.TextBox36})
        Me.groupHeaderSection.Name = "groupHeaderSection"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(2.2999999523162842R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.2676377296447754R), Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R))
        Me.TextBox3.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(93,Byte),Integer), CType(CType(162,Byte),Integer))
        Me.TextBox3.Style.Color = System.Drawing.Color.White
        Me.TextBox3.Style.Font.Name = "Calibri"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox3.Value = "PERSONAL ADMINISTRATIVO"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.2676377296447754R), Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R))
        Me.TextBox2.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(93,Byte),Integer), CType(CType(162,Byte),Integer))
        Me.TextBox2.Style.Color = System.Drawing.Color.White
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox2.Value = "DATOS GENERALES DEL PUESTO DE BOLSA "
        '
        'TextBox6
        '
        Me.TextBox6.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.60432505607605R), Telerik.Reporting.Drawing.Unit.Inch(0.30407348275184631R))
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18851518630981445R))
        Me.TextBox6.Style.Font.Name = "Calibri"
        Me.TextBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox6.Value = "= TrimEnd(Fields.DireccionPuestoBolsa)"
        '
        'TextBox8
        '
        Me.TextBox8.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6013889312744141R), Telerik.Reporting.Drawing.Unit.Inch(0.49266773462295532R))
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox8.Style.Font.Name = "Calibri"
        Me.TextBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox8.Value = "= Fields.Rnc"
        '
        'TextBox10
        '
        Me.TextBox10.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6013889312744141R), Telerik.Reporting.Drawing.Unit.Inch(0.68274664878845215R))
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox10.Style.Font.Name = "Calibri"
        Me.TextBox10.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox10.Value = "= Fields.TelefonoPuestoBolsa"
        '
        'TextBox12
        '
        Me.TextBox12.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6013889312744141R), Telerik.Reporting.Drawing.Unit.Inch(0.87282562255859375R))
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox12.Style.Font.Name = "Calibri"
        Me.TextBox12.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox12.Value = "= Fields.NoRegistroSIV"
        '
        'TextBox14
        '
        Me.TextBox14.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6013889312744141R), Telerik.Reporting.Drawing.Unit.Inch(1.0629045963287354R))
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox14.Style.Font.Name = "Calibri"
        Me.TextBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox14.Value = "= Fields.TipoParticipante"
        '
        'TextBox16
        '
        Me.TextBox16.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6013889312744141R), Telerik.Reporting.Drawing.Unit.Inch(1.2529834508895874R))
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox16.Style.Font.Name = "Calibri"
        Me.TextBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox16.Value = "= Fields.RepresentanteLegal"
        '
        'TextBox18
        '
        Me.TextBox18.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.60424542427063R), Telerik.Reporting.Drawing.Unit.Inch(1.443062424659729R))
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox18.Style.Font.Name = "Calibri"
        Me.TextBox18.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox18.Value = resources.GetString("TextBox18.Value")
        '
        'TextBox19
        '
        Me.TextBox19.Format = "{0:N2}"
        Me.TextBox19.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.6013889312744141R), Telerik.Reporting.Drawing.Unit.Inch(1.6331413984298706R))
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox19.Style.Font.Name = "Calibri"
        Me.TextBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox19.Value = "= Fields.CapitalSuscritoPagado"
        '
        'TextBox20
        '
        Me.TextBox20.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.60432505607605R), Telerik.Reporting.Drawing.Unit.Inch(1.8232203722000122R))
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6633920669555664R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox20.Style.Color = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(58,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.TextBox20.Style.Font.Name = "Calibri"
        Me.TextBox20.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox20.Value = "= Fields.Web"
        '
        'Table2
        '
        Me.Table2.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.30138897895813R)))
        Me.Table2.Body.Columns.Add(New Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.4541668891906738R)))
        Me.Table2.Body.Rows.Add(New Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796R)))
        Me.Table2.Body.SetCellContent(0, 0, Me.TextBox26)
        Me.Table2.Body.SetCellContent(0, 1, Me.TextBox28)
        TableGroup1.Name = "tableGroup2"
        TableGroup2.Name = "tableGroup3"
        Me.Table2.ColumnGroups.Add(TableGroup1)
        Me.Table2.ColumnGroups.Add(TableGroup2)
        Me.Table2.DataSource = Me.SqlPersonalEjecutivo
        Me.Table2.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox26, Me.TextBox28})
        Me.Table2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896R), Telerik.Reporting.Drawing.Unit.Inch(2.699960470199585R))
        Me.Table2.Name = "Table2"
        TableGroup3.Groupings.Add(New Telerik.Reporting.Grouping(Nothing))
        TableGroup3.Name = "detailTableGroup1"
        Me.Table2.RowGroups.Add(TableGroup3)
        Me.Table2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.7555561065673828R), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796R))
        '
        'TextBox26
        '
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3013887405395508R), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796R))
        Me.TextBox26.Style.Font.Name = "Calibri"
        Me.TextBox26.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox26.Value = "= Fields.NombreDirectorPuestoBolsa"
        '
        'TextBox28
        '
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.4541668891906738R), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796R))
        Me.TextBox28.Style.Font.Name = "Calibri"
        Me.TextBox28.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox28.Value = "= Fields.PuestoDirectorPuestoBolsa"
        '
        'SqlPersonalEjecutivo
        '
        Me.SqlPersonalEjecutivo.ConnectionString = "CN"
        Me.SqlPersonalEjecutivo.Name = "SqlPersonalEjecutivo"
        Me.SqlPersonalEjecutivo.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@PuestoBolsaID", System.Data.DbType.[String], "= Parameters.PuestoBolsa.Value")})
        Me.SqlPersonalEjecutivo.SelectCommand = resources.GetString("SqlPersonalEjecutivo.SelectCommand")
        '
        'TextBox4
        '
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.8909921285230666E-05R), Telerik.Reporting.Drawing.Unit.Inch(2.9791274070739746R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.2676377296447754R), Telerik.Reporting.Drawing.Unit.Inch(0.19999992847442627R))
        Me.TextBox4.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(93,Byte),Integer), CType(CType(162,Byte),Integer))
        Me.TextBox4.Style.Color = System.Drawing.Color.White
        Me.TextBox4.Style.Font.Name = "Calibri"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox4.Value = "CORREDORES DE BOLSA "
        '
        'TextBox27
        '
        Me.TextBox27.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60000008344650269R), Telerik.Reporting.Drawing.Unit.Inch(0.30407348275184631R))
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18851518630981445R))
        Me.TextBox27.Style.Font.Bold = true
        Me.TextBox27.Style.Font.Name = "Calibri"
        Me.TextBox27.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox27.Value = "Dirección"
        '
        'TextBox29
        '
        Me.TextBox29.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.59992110729217529R), Telerik.Reporting.Drawing.Unit.Inch(0.49266773462295532R))
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox29.Style.Font.Bold = true
        Me.TextBox29.Style.Font.Name = "Calibri"
        Me.TextBox29.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox29.Value = "RNC"
        '
        'TextBox30
        '
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.60000032186508179R), Telerik.Reporting.Drawing.Unit.Inch(0.68274664878845215R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox30.Style.Font.Bold = true
        Me.TextBox30.Style.Font.Name = "Calibri"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.Value = "Teléfonos"
        '
        'TextBox31
        '
        Me.TextBox31.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.59992110729217529R), Telerik.Reporting.Drawing.Unit.Inch(0.87282562255859375R))
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox31.Style.Font.Bold = true
        Me.TextBox31.Style.Font.Name = "Calibri"
        Me.TextBox31.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox31.Value = "No. Registro SIMV"
        '
        'TextBox32
        '
        Me.TextBox32.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.59992110729217529R), Telerik.Reporting.Drawing.Unit.Inch(1.0629045963287354R))
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox32.Style.Font.Bold = true
        Me.TextBox32.Style.Font.Name = "Calibri"
        Me.TextBox32.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox32.Value = "Tipo Participante"
        '
        'TextBox33
        '
        Me.TextBox33.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.59992110729217529R), Telerik.Reporting.Drawing.Unit.Inch(1.2529834508895874R))
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox33.Style.Font.Bold = true
        Me.TextBox33.Style.Font.Name = "Calibri"
        Me.TextBox33.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox33.Value = "Representante Legal"
        '
        'TextBox34
        '
        Me.TextBox34.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.59992110729217529R), Telerik.Reporting.Drawing.Unit.Inch(1.443062424659729R))
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox34.Style.Font.Bold = true
        Me.TextBox34.Style.Font.Name = "Calibri"
        Me.TextBox34.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox34.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox34.Value = "Fecha Constitución"
        '
        'TextBox35
        '
        Me.TextBox35.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.59992110729217529R), Telerik.Reporting.Drawing.Unit.Inch(1.6331413984298706R))
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox35.Style.Font.Bold = true
        Me.TextBox35.Style.Font.Name = "Calibri"
        Me.TextBox35.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox35.Value = "Capital Suscrito y Pagado"
        '
        'TextBox36
        '
        Me.TextBox36.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.602857232093811R), Telerik.Reporting.Drawing.Unit.Inch(1.8232200145721436R))
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0013890266418457R), Telerik.Reporting.Drawing.Unit.Inch(0.18999999761581421R))
        Me.TextBox36.Style.Font.Bold = true
        Me.TextBox36.Style.Font.Name = "Calibri"
        Me.TextBox36.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox36.Value = "Página Web"
        '
        'SqlPuestoBolsa
        '
        Me.SqlPuestoBolsa.ConnectionString = "CN"
        Me.SqlPuestoBolsa.Name = "SqlPuestoBolsa"
        Me.SqlPuestoBolsa.SelectCommand = "SELECT        PuestoBolsaID, Nombre"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"FROM            PuestoBolsa AS pb"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"WHERE    "& _ 
    "    (TipoParticipanteID = 1)"&Global.Microsoft.VisualBasic.ChrW(13)&Global.Microsoft.VisualBasic.ChrW(10)&"ORDER BY Nombre"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.56091594696044922R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox22, Me.TextBox24, Me.TextBox25})
        Me.detail.Name = "detail"
        '
        'TextBox22
        '
        Me.TextBox22.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.14281904697418213R), Telerik.Reporting.Drawing.Unit.Inch(3.920661038137041E-05R))
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3041670322418213R), Telerik.Reporting.Drawing.Unit.Inch(0.18851518630981445R))
        Me.TextBox22.Style.Font.Name = "Calibri"
        Me.TextBox22.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox22.Value = "= Fields.Nombre"
        '
        'TextBox24
        '
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.4471440315246582R), Telerik.Reporting.Drawing.Unit.Inch(3.920661038137041E-05R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5527772903442383R), Telerik.Reporting.Drawing.Unit.Inch(0.18851518630981445R))
        Me.TextBox24.Style.Color = System.Drawing.Color.FromArgb(CType(CType(0,Byte),Integer), CType(CType(58,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.TextBox24.Style.Font.Name = "Calibri"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.Value = "= Fields.Email"
        '
        'TextBox25
        '
        Me.TextBox25.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5R), Telerik.Reporting.Drawing.Unit.Inch(3.920661038137041E-05R))
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0555562973022461R), Telerik.Reporting.Drawing.Unit.Inch(0.18851518630981445R))
        Me.TextBox25.Style.Font.Name = "Calibri"
        Me.TextBox25.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.TextBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox25.Value = "= Fields.Licencia"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.347916841506958R)
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.2999999523162842R)
        Me.pageHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.PictureBox1, Me.TextBox1})
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Bindings.Add(New Telerik.Reporting.Binding("Value", "= Fields.Logo"))
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05R), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343R))
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.2675986289978027R), Telerik.Reporting.Drawing.Unit.Inch(0.99999994039535522R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.ScaleProportional
        '
        'TextBox1
        '
        Me.TextBox1.Format = "{0}"
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.2675991058349609R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8R)
        Me.TextBox1.Value = "Fecha de actualización:  {ConvertirFechas.Formatdate(Parameters.Fecha.Value)}"
        '
        'SP_PlanillaPuestoBolsa
        '
        Me.SP_PlanillaPuestoBolsa.ConnectionString = "CN"
        Me.SP_PlanillaPuestoBolsa.Name = "SP_PlanillaPuestoBolsa"
        Me.SP_PlanillaPuestoBolsa.Parameters.AddRange(New Telerik.Reporting.SqlDataSourceParameter() {New Telerik.Reporting.SqlDataSourceParameter("@PuestoBolsaID", System.Data.DbType.Int32, "= Parameters.PuestoBolsa.Value")})
        Me.SP_PlanillaPuestoBolsa.SelectCommand = "dbo.SP_PlanillaPuestoBolsa"
        Me.SP_PlanillaPuestoBolsa.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'PlanillaPuestoBolsa
        '
        Me.DataSource = Me.SP_PlanillaPuestoBolsa
        Group1.GroupFooter = Me.groupFooterSection
        Group1.GroupHeader = Me.groupHeaderSection
        Group1.Groupings.Add(New Telerik.Reporting.Grouping("= Fields.PuestoBolsaID"))
        Group1.Name = "group"
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.groupHeaderSection, Me.groupFooterSection, Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "PlanillaPuestoBolsa"
        Me.PageSettings.Landscape = false
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(0.5R), Telerik.Reporting.Drawing.Unit.Inch(1R), Telerik.Reporting.Drawing.Unit.Inch(1R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4
        ReportParameter1.AvailableValues.DataSource = Me.SqlPuestoBolsa
        ReportParameter1.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter1.AvailableValues.Sortings.Add(New Telerik.Reporting.Sorting("= Fields.Nombre", Telerik.Reporting.SortDirection.Asc))
        ReportParameter1.AvailableValues.ValueMember = "= Fields.PuestoBolsaID"
        ReportParameter1.Name = "PuestoBolsa"
        ReportParameter1.Text = "PuestoBolsa"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.[Integer]
        ReportParameter1.Visible = true
        ReportParameter2.Name = "Fecha"
        ReportParameter2.Text = "Fecha"
        ReportParameter2.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter2.Value = "= Today()"
        ReportParameter2.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.Table), "Normal.TableNormal")})
        StyleRule2.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule2.Style.Color = System.Drawing.Color.Black
        StyleRule2.Style.Font.Name = "Tahoma"
        StyleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        DescendantSelector1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableHeader")})
        StyleRule3.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector1})
        StyleRule3.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule3.Style.Font.Name = "Tahoma"
        StyleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10R)
        StyleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        DescendantSelector2.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.Table)), New Telerik.Reporting.Drawing.StyleSelector(GetType(Telerik.Reporting.ReportItem), "Normal.TableBody")})
        StyleRule4.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {DescendantSelector2})
        StyleRule4.Style.BorderColor.Default = System.Drawing.Color.Black
        StyleRule4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid
        StyleRule4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1R)
        StyleRule4.Style.Font.Name = "Tahoma"
        StyleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1, StyleRule2, StyleRule3, StyleRule4})
        Me.Width = Telerik.Reporting.Drawing.Unit.Cm(18.459999084472656R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents SqlPuestoBolsa As Telerik.Reporting.SqlDataSource
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents SP_PlanillaPuestoBolsa As Telerik.Reporting.SqlDataSource
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents groupHeaderSection As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents groupFooterSection As Telerik.Reporting.GroupFooterSection
    Friend WithEvents TextBox6 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox8 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox10 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox12 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox14 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox16 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox18 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox19 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox20 As Telerik.Reporting.TextBox
    Friend WithEvents Table2 As Telerik.Reporting.Table
    Friend WithEvents TextBox26 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox28 As Telerik.Reporting.TextBox
    Friend WithEvents SqlPersonalEjecutivo As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox22 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox25 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox27 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox29 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox31 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox32 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox33 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox34 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox35 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox36 As Telerik.Reporting.TextBox
End Class