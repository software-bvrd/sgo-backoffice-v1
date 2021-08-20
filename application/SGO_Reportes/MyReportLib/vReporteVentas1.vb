

Imports System.Globalization

Partial Public Class vReporteVentas1
    Inherits Telerik.Reporting.Report
    Public Sub New()

        Dim ciNewFormat As New CultureInfo(CultureInfo.CurrentCulture.ToString())
        ciNewFormat.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"

        System.Threading.Thread.CurrentThread.CurrentCulture = ciNewFormat
        InitializeComponent()
    End Sub
End Class