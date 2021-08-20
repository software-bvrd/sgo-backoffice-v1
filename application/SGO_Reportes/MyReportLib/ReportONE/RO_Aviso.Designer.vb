Partial Class RO_Aviso

    'NOTE: The following procedure is required by the telerik Reporting Designer
    'It can be modified using the telerik Reporting Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RO_Aviso))
        Dim NavigateToBookmarkAction1 As Telerik.Reporting.NavigateToBookmarkAction = New Telerik.Reporting.NavigateToBookmarkAction()
        Dim ReportParameter1 As Telerik.Reporting.ReportParameter = New Telerik.Reporting.ReportParameter()
        Dim StyleRule1 As Telerik.Reporting.Drawing.StyleRule = New Telerik.Reporting.Drawing.StyleRule()
        Me.pageHeaderSection1 = New Telerik.Reporting.PageHeaderSection()
        Me.detail = New Telerik.Reporting.DetailSection()
        Me.PictureBox3 = New Telerik.Reporting.PictureBox()
        Me.TextBox2 = New Telerik.Reporting.TextBox()
        Me.HtmlTextBox1 = New Telerik.Reporting.HtmlTextBox()
        Me.PictureBox2 = New Telerik.Reporting.PictureBox()
        Me.pageFooterSection1 = New Telerik.Reporting.PageFooterSection()
        Me.pageInfoTextBox = New Telerik.Reporting.TextBox()
        Me.TextBox81 = New Telerik.Reporting.TextBox()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'pageHeaderSection1
        '
        Me.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699R)
        Me.pageHeaderSection1.Name = "pageHeaderSection1"
        '
        'detail
        '
        Me.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(5.87155818939209R)
        Me.detail.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.PictureBox3, Me.TextBox2, Me.HtmlTextBox1, Me.PictureBox2})
        Me.detail.Name = "detail"
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273R), Telerik.Reporting.Drawing.Unit.Cm(0.00010012308484874666R))
        Me.PictureBox3.MimeType = "image/png"
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.02056884765625R), Telerik.Reporting.Drawing.Unit.Cm(4.1856083869934082R))
        Me.PictureBox3.Value = CType(resources.GetObject("PictureBox3.Value"), Object)
        '
        'TextBox2
        '
        Me.TextBox2.KeepTogether = False
        Me.TextBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0R), Telerik.Reporting.Drawing.Unit.Inch(3.5480740070343018R))
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0947127342224121R), Telerik.Reporting.Drawing.Unit.Inch(0.79992103576660156R))
        Me.TextBox2.Style.Font.Bold = True
        Me.TextBox2.Style.Font.Name = "Calibri"
        Me.TextBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18.0R)
        Me.TextBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center
        Me.TextBox2.Style.Visible = True
        Me.TextBox2.StyleName = "PParrafo"
        Me.TextBox2.Value = "¡BVRD, por un Mercado de Valores más Transparente, Equitativo y Eficiente!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'HtmlTextBox1
        '
        Me.HtmlTextBox1.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Cm(2.5399999618530273R), Telerik.Reporting.Drawing.Unit.Cm(4.1859087944030762R))
        Me.HtmlTextBox1.Name = "HtmlTextBox1"
        Me.HtmlTextBox1.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(18.02056884765625R), Telerik.Reporting.Drawing.Unit.Cm(4.8259992599487305R))
        Me.HtmlTextBox1.Value = resources.GetString("HtmlTextBox1.Value")
        '
        'PictureBox2
        '
        NavigateToBookmarkAction1.TargetBookmarkId = "BB_BoletinIndice"
        Me.PictureBox2.Action = NavigateToBookmarkAction1
        Me.PictureBox2.Location = New Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.0R), Telerik.Reporting.Drawing.Unit.Inch(4.3480739593505859R))
        Me.PictureBox2.MimeType = "image/png"
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.8976380825042725R), Telerik.Reporting.Drawing.Unit.Inch(0.82382887601852417R))
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
        'RO_Aviso
        '
        Me.DocumentName = "0"
        Me.Items.AddRange(New Telerik.Reporting.ReportItemBase() {Me.pageHeaderSection1, Me.detail, Me.pageFooterSection1})
        Me.Name = "RO_Aviso"
        Me.PageSettings.Landscape = true
        Me.PageSettings.Margins = New Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(1R), Telerik.Reporting.Drawing.Unit.Inch(1R), Telerik.Reporting.Drawing.Unit.Inch(1R), Telerik.Reporting.Drawing.Unit.Inch(1R))
        Me.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter
        ReportParameter1.Name = "Fecha"
        ReportParameter1.Text = "Fecha"
        ReportParameter1.Type = Telerik.Reporting.ReportParameterType.DateTime
        ReportParameter1.Value = "=Today()"
        ReportParameter1.Visible = true
        Me.ReportParameters.Add(ReportParameter1)
        Me.Style.BackgroundColor = System.Drawing.Color.White
        StyleRule1.Selectors.AddRange(New Telerik.Reporting.Drawing.ISelector() {New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.TextItemBase)), New Telerik.Reporting.Drawing.TypeSelector(GetType(Telerik.Reporting.HtmlTextBox))})
        StyleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2R)
        StyleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2R)
        Me.StyleSheet.AddRange(New Telerik.Reporting.Drawing.StyleRule() {StyleRule1})
        Me.Width = Telerik.Reporting.Drawing.Unit.Inch(9R)
        CType(Me,System.ComponentModel.ISupportInitialize).EndInit

End Sub
    Friend WithEvents pageHeaderSection1 As Telerik.Reporting.PageHeaderSection
    Friend WithEvents detail As Telerik.Reporting.DetailSection
    Friend WithEvents pageFooterSection1 As Telerik.Reporting.PageFooterSection
    Friend WithEvents pageInfoTextBox As Telerik.Reporting.TextBox
    Friend WithEvents TextBox81 As Telerik.Reporting.TextBox
    Friend WithEvents PictureBox3 As Telerik.Reporting.PictureBox
    Friend WithEvents TextBox2 As Telerik.Reporting.TextBox
    Friend WithEvents HtmlTextBox1 As Telerik.Reporting.HtmlTextBox
    Friend WithEvents PictureBox2 As Telerik.Reporting.PictureBox
End Class