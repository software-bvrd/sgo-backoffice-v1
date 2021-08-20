Partial Public Class SecundarioBoletinBursatildeOperacionesdeRentaFija
    Inherits Telerik.Reporting.Report

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Function FechaEnLetras(ByVal dFecha As DateTime) As String
        Dim diaSemana As Integer = dFecha.DayOfWeek
        Dim textosemana As String = ""

        If diaSemana = 7 Then
            textosemana = "Domingo"
        ElseIf diaSemana = 1 Then
            textosemana = "Lunes"
        ElseIf diaSemana = 2 Then
            textosemana = "Martes"
        ElseIf diaSemana = 3 Then
            textosemana = "Míercoles"
        ElseIf diaSemana = 4 Then
            textosemana = "Jueves"
        ElseIf diaSemana = 5 Then
            textosemana = "Viernes"
        ElseIf diaSemana = 6 Then
            textosemana = "Sábado"
        End If


        Return textosemana
    End Function



End Class