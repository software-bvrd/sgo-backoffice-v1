Partial Class CalificacionesDeRiesgo
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CalificacionesDeRiesgo))
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim Group1 As Telerik.Reporting.Group = New Telerik.Reporting.Group()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.CN = New Telerik.Reporting.SqlDataSource()
        Me.Encabezado = New Telerik.Reporting.PageHeaderSection()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.Detalles = New Telerik.Reporting.DetailSection()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.PiedePagina = New Telerik.Reporting.PageFooterSection()
        Me.currentTimeTextBox = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.PieGrupo = New Telerik.Reporting.GroupFooterSection()
        Me.EncabezadoGrupo = New Telerik.Reporting.GroupHeaderSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'CN
        '
        Me.CN.ConnectionString = "CN"
        Me.CN.Name = "CN"
        Me.CN.SelectCommand = resources.GetString("CN.SelectCommand")
        '
        'Encabezado
        '
        Me.Encabezado.Height = Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582R)
        Me.Encabezado.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox30, Me.TextBox4, Me.PictureBox2})
        Me.Encabezado.Name = "Encabezado"
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:d}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.1999998092651367R), Telerik.Reporting.Drawing.Unit.Inch(0.33000001311302185R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.65791654586792R), Telerik.Reporting.Drawing.Unit.Inch(0.19297662377357483R))
        Me.TextBox30.Style.Color = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.TextBox30.Style.Font.Name = "Times New Roman"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox30.Value = "= ""Nomenclatura de Clasificación "" "
        '
        'TextBox4
        '
        Me.TextBox4.Format = "{0:d}"
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.65791654586792R), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134R))
        Me.TextBox4.Style.Color = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(74, Byte), Integer))
        Me.TextBox4.Style.Font.Bold = True
        Me.TextBox4.Style.Font.Name = "Times New Roman"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14.0R)
        Me.TextBox4.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox4.Value = "= Parameters.Empresa.Value"
        '
        'Detalles
        '
        Me.Detalles.Height = Telerik.Reporting.Drawing.Unit.Inch(0.43999990820884705R)
        Me.Detalles.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox2, Me.TextBox3})
        Me.Detalles.Name = "Detalles"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.21999995410442352R), Telerik.Reporting.Drawing.Unit.Inch(0.10999981313943863R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.87999993562698364R), Telerik.Reporting.Drawing.Unit.Inch(0.22000010311603546R))
        Me.TextBox2.Style.Color = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TextBox2.Style.Font.Name = "Verdana"
        Me.TextBox2.Value = "=Fields.CodEnSistema"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.3500394821166992R), Telerik.Reporting.Drawing.Unit.Inch(0.10999981313943863R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.5699601173400879R), Telerik.Reporting.Drawing.Unit.Inch(0.22000010311603546R))
        Me.TextBox3.Value = "=Fields.Definicion"
        '
        'PiedePagina
        '
        Me.PiedePagina.Height = Telerik.Reporting.Drawing.Unit.Inch(0.49499988555908203R)
        Me.PiedePagina.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.currentTimeTextBox, Me.pageInfoTextBox})
        Me.PiedePagina.Name = "PiedePagina"
        '
        'currentTimeTextBox
        '
        Me.currentTimeTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.054999988526105881R), Telerik.Reporting.Drawing.Unit.Inch(0.10999997705221176R))
        Me.currentTimeTextBox.Name = "currentTimeTextBox"
        Me.currentTimeTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0650393962860107R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.currentTimeTextBox.Style.Font.Name = "Times New Roman"
        Me.currentTimeTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.currentTimeTextBox.StyleName = "PageInfo"
        Me.currentTimeTextBox.Value = "=NOW()"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.6749997138977051R), Telerik.Reporting.Drawing.Unit.Inch(0.10999997705221176R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1829166412353516R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Times New Roman"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'PieGrupo
        '
        Me.PieGrupo.Height = Telerik.Reporting.Drawing.Unit.Inch(0.32999992370605469R)
        Me.PieGrupo.Name = "PieGrupo"
        Me.PieGrupo.Style.Visible = False
        '
        'EncabezadoGrupo
        '
        Me.EncabezadoGrupo.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28999996185302734R)
        Me.EncabezadoGrupo.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1})
        Me.EncabezadoGrupo.Name = "EncabezadoGrupo"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.054999988526105881R), Telerik.Reporting.Drawing.Unit.Inch(0.055416662245988846R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.8649992942810059R), Telerik.Reporting.Drawing.Unit.Inch(0.21999995410442352R))
        Me.TextBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(163, Byte), Integer))
        Me.TextBox1.Style.Color = System.Drawing.Color.White
        Me.TextBox1.Style.Font.Bold = True
        Me.TextBox1.Style.Font.Name = "Verdana"
        Me.TextBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox1.Value = "=Fields.NombreRango"
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1199996471405029R), Telerik.Reporting.Drawing.Unit.Inch(0.61549556255340576R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'CalificacionesDeRiesgo
        '
        Me.DataSource = Me.CN
        Me.Filters.Add(New Telerik.Reporting.Filter("=Fields.NombreEmpresa", Telerik.Reporting.FilterOperator.Equal, "=Parameters.Empresa.Value"))
        Group1.GroupFooter = Me.PieGrupo
        Group1.GroupHeader = Me.EncabezadoGrupo
        Group1.Groupings.Add(New Telerik.Reporting.Grouping("=Fields.NombreRango"))
        Group1.Name = "RangoCalificacion"
        Group1.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.CodEnSistema", Telerik.Reporting.SortDirection.Asc))
        Me.Groups.AddRange(New Telerik.Reporting.Group() {Group1})
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.EncabezadoGrupo, Me.PieGrupo, Me.Encabezado, Me.Detalles, Me.PiedePagina})
        Me.Name = "CalificacionesDeRiesgo"
        Me.PageSettings.Landscape = False
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R), Telerik.Reporting.Drawing.Unit.Inch(0.25R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.AvailableValues.DataSource = Me.CN
        ReportParameter1.AvailableValues.DisplayMember = "= Fields.NombreEmpresa"
        ReportParameter1.AvailableValues.Sortings.Add(New Telerik.Reporting.Sorting("=Fields.NombreEmpresa", Telerik.Reporting.SortDirection.Asc))
        ReportParameter1.AvailableValues.ValueMember = "= Fields.NombreEmpresa"
        ReportParameter1.Name = "Empresa"
        ReportParameter1.Value = ""
        ReportParameter1.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(8.0R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Encabezado As Telerik.Reporting.PageHeaderSection
    Friend WithEvents Detalles As Telerik.Reporting.DetailSection
    Friend WithEvents PiedePagina As Telerik.Reporting.PageFooterSection
    Friend WithEvents CN As Telerik.Reporting.SqlDataSource
    Friend WithEvents RangoCalificacion As Telerik.Reporting.Group
    Friend WithEvents PieGrupo As Telerik.Reporting.GroupFooterSection
    Friend WithEvents EncabezadoGrupo As Telerik.Reporting.GroupHeaderSection
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents currentTimeTextBox As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class