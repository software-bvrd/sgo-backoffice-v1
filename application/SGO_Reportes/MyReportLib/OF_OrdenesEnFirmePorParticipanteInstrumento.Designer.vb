Partial Class OF_OrdenesEnFirmePorParticipanteInstrumento
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OF_OrdenesEnFirmePorParticipanteInstrumento))
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter4 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter5 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.SqlTipoMercado = New Telerik.Reporting.SqlDataSource()
        Me.SqlMercado = New Telerik.Reporting.SqlDataSource()
        Me.SqlTipo = New Telerik.Reporting.SqlDataSource()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.ReportHeaderSection1 = New Telerik.Reporting.ReportHeaderSection()
        Me.TextBox47 = New Telerik.Reporting.TextBox()
        Me.TextBox46 = New Telerik.Reporting.TextBox()
        Me.TextBox24 = New Telerik.Reporting.TextBox()
        Me.TextBox30 = New Telerik.Reporting.TextBox()
        Me.TextBox23 = New Telerik.Reporting.TextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'SqlTipo
        '
        Me.SqlTipo.ConnectionString = "CN"
        Me.SqlTipo.Name = "SqlTipo"
        Me.SqlTipo.SelectCommand = "SELECT        ' Todos' AS Nombre, 'T' AS Codigo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UNION" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECT        'Vendedor' " &
    "AS Nombre, 'V' AS Codigo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "UNION" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SELECT        'Comprador' AS Nombre, 'C' AS Cod" &
    "igo"
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(2.0R)
        Me.detail.Name = "detail"
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003938674926758R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox81, Me.pageInfoTextBox})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7298412322998047R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD - {Now()}"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.4467697143554688R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5430099964141846R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Calibri"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'ReportHeaderSection1
        '
        Me.ReportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.80023622512817383R)
        Me.ReportHeaderSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox47, Me.TextBox46, Me.TextBox24, Me.TextBox30, Me.TextBox23, Me.PictureBox2})
        Me.ReportHeaderSection1.Name = "ReportHeaderSection1"
        '
        'TextBox47
        '
        Me.TextBox47.Format = "{0:d}"
        Me.TextBox47.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.650236189365387R))
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.1663131713867188R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox47.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox47.Style.Color = System.Drawing.Color.Black
        Me.TextBox47.Style.Font.Bold = False
        Me.TextBox47.Style.Font.Italic = False
        Me.TextBox47.Style.Font.Name = "Calibri"
        Me.TextBox47.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox47.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox47.Value = "Tipo: {IIf(Parameters.Tipo.Value='C',""Comprador"","""") + IIf(Parameters.Tipo.Value=" &
    "'V',""Vendedor"","""") + IIf(Parameters.Tipo.Value='A',""Vendedor y Comprador"","""")}"
        '
        'TextBox46
        '
        Me.TextBox46.Format = "{0:d}"
        Me.TextBox46.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.50015753507614136R))
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.1663131713867188R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox46.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox46.Style.Color = System.Drawing.Color.Black
        Me.TextBox46.Style.Font.Bold = False
        Me.TextBox46.Style.Font.Italic = False
        Me.TextBox46.Style.Font.Name = "Calibri"
        Me.TextBox46.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox46.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox46.Value = "Desde {ConvertirFechas.Formatdate(Parameters.FechaInicio.Value)} hasta {Convertir" &
    "Fechas.Formatdate(Parameters.FechaFinal.Value)}"
        '
        'TextBox24
        '
        Me.TextBox24.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.0020833809394389391R))
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.3479170799255371R), Telerik.Reporting.Drawing.Unit.Inch(0.19992129504680634R))
        Me.TextBox24.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox24.Style.Color = System.Drawing.Color.Black
        Me.TextBox24.Style.Font.Bold = True
        Me.TextBox24.Style.Font.Name = "Calibri"
        Me.TextBox24.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12.0R)
        Me.TextBox24.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox24.StyleName = "Title"
        Me.TextBox24.Value = "Bolsa y Mercados de Valores de la República Dominicana, S. A." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TextBox30
        '
        Me.TextBox30.Format = "{0:d}"
        Me.TextBox30.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.350078821182251R))
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.1663131713867188R), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448R))
        Me.TextBox30.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox30.Style.Color = System.Drawing.Color.Black
        Me.TextBox30.Style.Font.Bold = True
        Me.TextBox30.Style.Font.Italic = True
        Me.TextBox30.Style.Font.Name = "Calibri"
        Me.TextBox30.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox30.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox30.Value = "{Parameters.TipoMercado.Label} {IIF(Parameters.Mercado.Value<>'','->','')} {Param" &
    "eters.Mercado.Label}  "
        '
        'TextBox23
        '
        Me.TextBox23.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.20208334922790527R))
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.3479170799255371R), Telerik.Reporting.Drawing.Unit.Inch(0.14791679382324219R))
        Me.TextBox23.Style.BackgroundColor = System.Drawing.Color.White
        Me.TextBox23.Style.Color = System.Drawing.Color.Black
        Me.TextBox23.Style.Font.Bold = False
        Me.TextBox23.Style.Font.Name = "Calibri"
        Me.TextBox23.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10.0R)
        Me.TextBox23.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left
        Me.TextBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox23.StyleName = "Title"
        Me.TextBox23.Value = "Ordenes en Firme"
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(7.6154332160949707R), Telerik.Reporting.Drawing.Unit.Inch(0R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.3743462562561035R), Telerik.Reporting.Drawing.Unit.Inch(0.61549556255340576R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'OF_OrdenesEnFirmePorParticipanteInstrumento
        '
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1, Me.ReportHeaderSection1})
        Me.Name = "OF_OrdenesEnFirmePorParticipanteInstrumento"
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
        ReportParameter3.AvailableValues.DataSource = Me.SqlTipoMercado
        ReportParameter3.AvailableValues.DisplayMember = "= Fields.TipoMercado"
        ReportParameter3.AvailableValues.ValueMember = "= Fields.TipoMercadoID"
        ReportParameter3.Name = "TipoMercado"
        ReportParameter3.Text = "Tipo Mercado"
        ReportParameter3.Visible = True
        ReportParameter4.AllowNull = True
        ReportParameter4.AvailableValues.DataSource = Me.SqlMercado
        ReportParameter4.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter4.AvailableValues.Filters.Add(New Telerik.Reporting.Filter("=Fields.TipoMercadoID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.TipoMercado.Value"))
        ReportParameter4.AvailableValues.ValueMember = "= Fields.CodigoMercado"
        ReportParameter4.Name = "Mercado"
        ReportParameter4.Text = "Mercado"
        ReportParameter4.Visible = True
        ReportParameter5.AvailableValues.DataSource = Me.SqlTipo
        ReportParameter5.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter5.AvailableValues.ValueMember = "= Fields.Codigo"
        ReportParameter5.Name = "Tipo"
        ReportParameter5.Text = "Tipo"
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
    Friend WithEvents TextBox47 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox46 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox24 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox30 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox23 As Telerik.Reporting.TextBox
    Friend WithEvents SqlTipoMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlTipo As Telerik.Reporting.SqlDataSource
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class