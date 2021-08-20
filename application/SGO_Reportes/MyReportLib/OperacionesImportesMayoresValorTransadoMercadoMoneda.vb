Partial Public Class OperacionesImportesMayoresValorTransadoMercadoMoneda
    Inherits Telerik.Reporting.Report
    Public Sub New()
        InitializeComponent()
    End Sub
    'Private Sub Report1_NeedDataSource(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.NeedDataSource
    '    'Take the Telerik.Reporting.Processing.Report instance
    '    Dim report As Telerik.Reporting.Processing.Report = DirectCast(sender, Telerik.Reporting.Processing.Report)

    '    ' Transfer the value of the processing instance of ReportParameter
    '    ' to the parameter value of the sqlDataSource component
    '    Me.sqlDataSource1.Parameters(0).Value = report.Parameters("ManagerID").Value

    '    ' Set the SqlDataSource component as it's DataSource
    '    report.DataSource = Me.sqlDataSource1
    'End Sub
End Class