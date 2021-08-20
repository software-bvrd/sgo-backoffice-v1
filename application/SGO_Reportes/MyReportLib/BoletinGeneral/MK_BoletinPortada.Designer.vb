Partial Class MK_BoletinPortada
    
    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MK_BoletinPortada))
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter2 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim ReportParameter3 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.SqlTipoMercado = New Telerik.Reporting.SqlDataSource()
        Me.SqlMercado = New Telerik.Reporting.SqlDataSource()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.TextBox1 = New Telerik.Reporting.TextBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.PictureBox1 = New Telerik.Reporting.PictureBox()
        Me.TextBox3 = New Telerik.Reporting.TextBox()
        Me.TextBox4 = New Telerik.Reporting.TextBox()
        Me.PictureBox3 = New Telerik.Reporting.PictureBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
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
        Me.SqlMercado.SelectCommand = "dbo.SP_Mercados"
        Me.SqlMercado.SelectCommandType = Telerik.Reporting.SqlDataSourceCommandType.StoredProcedure
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(5.3479170799255371R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.TextBox1, Me.TextBox2, Me.PictureBox1, Me.TextBox3, Me.TextBox4, Me.PictureBox3, Me.PictureBox2})
        Me.detail.Name = "detail"
        '
        'TextBox1
        '
        Me.TextBox1.Bindings.Add(New Telerik.Reporting.Binding("Visible", "=IIF(Parameters.Mercado.Value='33','True','False')"))
        Me.TextBox1.KeepTogether = False
        Me.TextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0R), Telerik.Reporting.Drawing.Unit.Inch(1.3479167222976685R))
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0R), Telerik.Reporting.Drawing.Unit.Inch(3.2999999523162842R))
        Me.TextBox1.Style.Font.Name = "Calibri"
        Me.TextBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox1.Style.Visible = False
        Me.TextBox1.StyleName = "PParrafo"
        Me.TextBox1.Value = resources.GetString("TextBox1.Value")
        '
        'TextBox2
        '
        Me.TextBox2.Bindings.Add(New Telerik.Reporting.Binding("Visible", "=IIF(Parameters.Mercado.Value='33','True','False')"))
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896R), Telerik.Reporting.Drawing.Unit.Inch(0.74783807992935181R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0R), Telerik.Reporting.Drawing.Unit.Inch(0.40000009536743164R))
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8.0R)
        Me.TextBox2.Style.Font.Underline = True
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.Style.Visible = False
        Me.TextBox2.StyleName = "PParrafo"
        Me.TextBox2.Value = "Términos sobre el Uso de la Data" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Data Use Terms"
        '
        'PictureBox1
        '
        Me.PictureBox1.Bindings.Add(New Telerik.Reporting.Binding("Visible", "=IIF(Parameters.Mercado.Value='33','True','False')"))
        Me.PictureBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000002861022949R), Telerik.Reporting.Drawing.Unit.Inch(0.000039339065551757812R))
        Me.PictureBox1.MimeType = "image/png"
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7000004053115845R), Telerik.Reporting.Drawing.Unit.Inch(0.54795616865158081R))
        Me.PictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.AutoSize
        Me.PictureBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0R)
        Me.PictureBox1.Style.Visible = False
        Me.PictureBox1.Value = CType(resources.GetObject("PictureBox1.Value"), Object)
        '
        'TextBox3
        '
        Me.TextBox3.Bindings.Add(New Telerik.Reporting.Binding("Visible", "=IIF(Parameters.Mercado.Value='33','False','True')"))
        Me.TextBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90000021457672119R), Telerik.Reporting.Drawing.Unit.Inch(3.753309965133667R))
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.19266939163208R), Telerik.Reporting.Drawing.Unit.Inch(0.60000038146972656R))
        Me.TextBox3.Style.Font.Name = "Calibri"
        Me.TextBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16.0R)
        Me.TextBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox3.StyleName = "PParrafo"
        Me.TextBox3.Value = "¨BVRD, por un mercado de valores más Transparente, Justo y Eficiente!¨"
        '
        'TextBox4
        '
        Me.TextBox4.Bindings.Add(New Telerik.Reporting.Binding("Visible", "=IIF(Parameters.Mercado.Value='33','False','True')"))
        Me.TextBox4.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.90000003576278687R), Telerik.Reporting.Drawing.Unit.Inch(1.8766350746154785R))
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.1947126388549805R), Telerik.Reporting.Drawing.Unit.Inch(1.8765956163406372R))
        Me.TextBox4.Style.Font.Name = "Calibri"
        Me.TextBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16.0R)
        Me.TextBox4.StyleName = "PParrafo"
        Me.TextBox4.Value = resources.GetString("TextBox4.Value")
        '
        'PictureBox3
        '
        Me.PictureBox3.Bindings.Add(New Telerik.Reporting.Binding("Visible", "=IIF(Parameters.Mercado.Value='33','False','True')"))
        Me.PictureBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5400004386901855R), Telerik.Reporting.Drawing.Unit.Cm(0.00010007261880673468R))
        Me.PictureBox3.MimeType = "image/png"
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.02056884765625R), Telerik.Reporting.Drawing.Unit.Cm(3.9316084384918213R))
        Me.PictureBox3.Value = CType(resources.GetObject("PictureBox3.Value"), Object)
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0000003576278687R), Telerik.Reporting.Drawing.Unit.Inch(4.6479954719543457R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6377954483032227R), Telerik.Reporting.Drawing.Unit.Inch(0.59988182783126831R))
        Me.PictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch
        Me.PictureBox2.Style.BackgroundImage.MimeType = ""
        Me.PictureBox2.Style.BackgroundImage.Repeat = Telerik.Reporting.Drawing.BackgroundRepeat.NoRepeat
        Me.PictureBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525R)
        Me.PictureBox2.Style.Visible = True
        Me.PictureBox2.Value = CType(resources.GetObject("PictureBox2.Value"), Object)
        '
        'pageFooterSection1
        '
        Me.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.20003943145275116R)
        Me.pageFooterSection1.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageInfoTextBox, Me.TextBox81})
        Me.pageFooterSection1.Name = "pageFooterSection1"
        '
        'pageInfoTextBox
        '
        Me.pageInfoTextBox.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.8000001907348633R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.pageInfoTextBox.Name = "pageInfoTextBox"
        Me.pageInfoTextBox.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1999998092651367R), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224R))
        Me.pageInfoTextBox.Style.Font.Name = "Calibri"
        Me.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right
        Me.pageInfoTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.pageInfoTextBox.StyleName = "PageInfo"
        Me.pageInfoTextBox.Value = "=""Página  "" + CStr(pageNumber)"
        '
        'TextBox81
        '
        Me.TextBox81.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0R), Telerik.Reporting.Drawing.Unit.Inch(0.000039418537198798731R))
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8999998569488525R), Telerik.Reporting.Drawing.Unit.Inch(0.19996008276939392R))
        Me.TextBox81.Style.Font.Name = "Calibri"
        Me.TextBox81.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7.0R)
        Me.TextBox81.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle
        Me.TextBox81.Value = "Departamento de Operaciones  BVRD / {Now()}"
        '
        'MK_BoletinPortada
        '
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "MK_BoletinPortada"
        Me.PageSettings.Landscape = True
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1.0R), Telerik.Reporting.Drawing.Unit.Inch(1.0R), Telerik.Reporting.Drawing.Unit.Inch(1.0R), Telerik.Reporting.Drawing.Unit.Inch(1.0R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "Fecha"
        ReportParameter1.Text = "Fecha"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = True
        ReportParameter2.AvailableValues.DataSource = Me.SqlTipoMercado
        ReportParameter2.AvailableValues.DisplayMember = "= Fields.TipoMercado"
        ReportParameter2.AvailableValues.ValueMember = "= Fields.TipoMercadoID"
        ReportParameter2.Name = "TipoMercado"
        ReportParameter2.Text = "Tipo Mercado"
        ReportParameter2.Visible = True
        ReportParameter3.AllowNull = True
        ReportParameter3.AvailableValues.DataSource = Me.SqlMercado
        ReportParameter3.AvailableValues.DisplayMember = "= Fields.Nombre"
        ReportParameter3.AvailableValues.Filters.Add(New Telerik.Reporting.Filter("=Fields.TipoMercadoID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.TipoMercado.Value"))
        ReportParameter3.AvailableValues.ValueMember = "= Fields.CodigoMercado"
        ReportParameter3.Name = "Mercado"
        ReportParameter3.Text = "Mercado"
        ReportParameter3.Visible = True
        Me.ReportParameters.Add(ReportParameter1)
        Me.ReportParameters.Add(ReportParameter2)
        Me.ReportParameters.Add(ReportParameter3)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2.0R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(8.9899997711181641R)
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox1 As Telerik.Reporting.TextBox
    Friend WithEvents SqlTipoMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents SqlMercado As Telerik.Reporting.SqlDataSource
    Friend WithEvents PictureBox1 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox3 As Telerik.Reporting.TextBox
    Friend WithEvents TextBox4 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox3 As Telerik.Reporting.PictureBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class