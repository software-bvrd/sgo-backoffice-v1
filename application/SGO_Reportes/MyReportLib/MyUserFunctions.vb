Imports System.Drawing
Imports Telerik.Reporting.Expressions

''' <summary>
''' 2017-02-28
''' ------------------------------------------------------------------------------------
''' Funciones Para los reportes
''' ------------------------------------------------------------------------------------
''' Están clasificadas en :
''' --- ConvertirFecha = Son funciones que tienen que ver con formatos de fecha y demás
''' --- OperacionesNumericas = Calculo de %, Formatos a Números.
''' --- OperacionesTextos = Funciones con para formatear textos
''' ---
''' </summary>
Public NotInheritable Class MyUserFunctions


    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesNumericas", Description:="Devuelve el color de acuerdo a una condición")> _
    Public Shared Function ColorDatosNumericos(ByVal colorName As String) As Color
        If Not String.IsNullOrEmpty(colorName) Then
            Return Color.FromName(colorName)
        End If
        Return Color.Transparent
    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Devuelve el inicio del mes")> _
    Public Shared Function FechaInicioMes(dFecha As DateTime) As String
        Dim FechaInicio As Date = DateAdd(DateInterval.Day, -(DatePart(DateInterval.Day, dFecha)) + 1, dFecha)
        Return Format(FechaInicio, "dd/MM/yyyy")
    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Solo fecha")> _
    Public Shared Function Formatdate(dFecha As DateTime) As String
        Return Format(dFecha, "dd/MM/yyyy")
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Convertir fecha en día")> _
    Public Shared Function FormatdateAsDate(dFecha As DateTime) As String
        Return Format(dFecha, "dd")
    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Convertir fecha en nombre Mes")> _
    Public Shared Function FormatdateAsMonthName(dFecha As DateTime) As String
        Dim NumeroMes As Integer = Month(dFecha)
        Dim textomes As String = String.Empty

        If NumeroMes = 1 Then
            textomes = "Enero"
        ElseIf NumeroMes = 2 Then
            textomes = "Febrero"
        ElseIf NumeroMes = 3 Then
            textomes = "Marzo"
        ElseIf NumeroMes = 4 Then
            textomes = "Abril"
        ElseIf NumeroMes = 5 Then
            textomes = "Mayo"
        ElseIf NumeroMes = 6 Then
            textomes = "Junio"
        ElseIf NumeroMes = 7 Then
            textomes = "Julio"
        ElseIf NumeroMes = 8 Then
            textomes = "Agosto"
        ElseIf NumeroMes = 9 Then
            textomes = "Septiembre"
        ElseIf NumeroMes = 10 Then
            textomes = "Octubre"
        ElseIf NumeroMes = 11 Then
            textomes = "Noviembre"
        ElseIf NumeroMes = 12 Then
            textomes = "Diciembre"
        End If

        Return textomes
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Convertir fecha en nombre día")> _
    Public Shared Function FormatdateAsNameDate(dFecha As DateTime) As String
        Dim diaSemana As Integer = Weekday(dFecha)
        Dim textosemana As String = String.Empty

        If diaSemana = 1 Then
            textosemana = "Domingo"
        ElseIf diaSemana = 2 Then
            textosemana = "Lunes"
        ElseIf diaSemana = 3 Then
            textosemana = "Martes"
        ElseIf diaSemana = 4 Then
            textosemana = "Míercoles"
        ElseIf diaSemana = 5 Then
            textosemana = "Jueves"
        ElseIf diaSemana = 6 Then
            textosemana = "Viernes"
        ElseIf diaSemana = 7 Then
            textosemana = "Sábado"
        End If


        Return textosemana
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Covertir fecha en Año")> _
    Public Shared Function FormatdateYear(dFecha As DateTime) As String
        Return Format(dFecha, "yyyy")
    End Function


    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesNumericas", Description:="Devuelve el fromato del número dependiendo si es negativo")> _
    Public Shared Function FormatNumeros(ByVal ValorNumero As Double, Optional ByVal ZeroComoBlanco As Boolean = True) As String
        If ValorNumero = 0 And ZeroComoBlanco Then
            Return Format(ValorNumero, "#")
        ElseIf ValorNumero < 0 Then
            Return Format(Math.Abs(ValorNumero), "(#,##0.00)")
        Else
            Return Format(Math.Abs(ValorNumero), "#,##0.00")
        End If
    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesNumericas", Description:="Retornar un valor con formato de numero en base a un número 0.55")> _
    Public Shared Function FormatoNumeroEnPorcentaje(nNumero As Decimal) As String
        Dim Por As Decimal = nNumero * 100
        Dim TestString As String = Format(Por, "##,##0.00")
        Return TestString
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesNumericas", Description:="Retornar un valor con formato de numero")> _
    Public Shared Function FormatoNumeros(nNumero As Decimal) As String
        Dim TestString As String = Format(nNumero, "##,##0.00")
        Return TestString
    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesNumericas", Description:="Retornar un valor concatenado")> _
    Public Shared Function ImportesMayoresNValor(nMonto As String, nMoneda As String, nEquivalenteMonedaLocal As String) As String
        Dim texto As String = String.Empty
        Dim simbolo As String = String.Empty
        If (nMoneda = "DOP") Then
            simbolo = "RD$"
        ElseIf (nMoneda = "USD") Then
            simbolo = "US$"
        ElseIf (nMoneda = "EUR") Then
            simbolo = "€"
        End If


        If nEquivalenteMonedaLocal = "si" Then
            texto = "Operaciones de Importes Mayores a US$ " & nMonto & " o su Equivalente en Pesos"

        Else
            texto = "Operaciones de Importes Mayores a " & simbolo & " " & nMonto
        End If
        Return texto
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Devuelve el Mes en Nombre y Año")>
    Public Shared Function MesConAnioEnLetras(dFecha As DateTime) As String
        Dim NombreMes As String = String.Empty

        NombreMes = FormatdateAsMonthName(dFecha).TrimEnd() + " " + FormatdateYear(dFecha).TrimEnd()

        Return NombreMes
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Devuelve el primer mes o ultimo del trimetres")> _
    Public Shared Function MesDelTrimestre(dFecha As DateTime, cMes As String) As String
        Dim FechaInicio As Date

        If cMes = "P" Then ' Primer Mes
            FechaInicio = PrimerDiaTrimestre(dFecha)
        Else
            FechaInicio = UltimoDiaTrimestre(dFecha)
        End If

        Dim NombreMesTrimestre As String = FormatdateAsMonthName(FechaInicio)

        Return NombreMesTrimestre
    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="Usuario", Description:="Retornar el nombre de usuario")> _
    Public Shared Function NombreUsuario() As String
        Dim Nombre As String
        Nombre = String.Empty
        Return Nombre
    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Convertir fecha en numero de semana")> _
    Public Shared Function NumeroSemana(dFecha As DateTime) As Integer
        Dim dt As New DateTime
        dt = dFecha
        Dim weeknumber As Integer = DatePart(DateInterval.WeekOfYear, dFecha)
        Return weeknumber
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Devuelve el primer día del trimestre de la fecha pasada como argumento o en su defecto la actual")> _
    Public Shared Function PrimerDiaTrimestre(dFecha As DateTime) As DateTime
        PrimerDiaTrimestre = DateSerial(Year(dFecha), Int((Month(dFecha) - 1) / 3) * 3 + 1, 1)
    End Function

    '2016.02.09
    'Verificar si puede ser menor que cero.
    '----------------------------------------------
    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesNumericas", Description:="Retornar la división de dos números")>
    Public Shared Function RetornaDivisionDosNumeros(nPrimerValor As Decimal, nSegundoValor As Decimal) As Decimal
        If (nSegundoValor) > 0 Then
            Return ((nPrimerValor) / nSegundoValor)
        Else
            Return 0
        End If
    End Function

    '2016.02.24
    'Convertir un teléfono en formato (999)999-9999.
    '---------------------------------------------------------------
    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesTextos", Description:="Retornar el número de teléfono formateado")>
    Public Shared Function RetornaFormatoTelefono(cTelefono As String) As String

        If cTelefono.TrimEnd.Length = 10 Then

            Return "(" + cTelefono.TrimEnd.Substring(0, 3) + ")" +
                   cTelefono.TrimEnd.Substring(3, 3) + "-" + cTelefono.TrimEnd.Substring(6)

        Else
            Return String.Empty
        End If


    End Function
    <[Function](Category:="Funciones Reportes", [Namespace]:="OperacionesNumericas", Description:="Retornar el % de dos números")> _
    Public Shared Function RetornaPorcentajeDosNumeros(nPrimerValor As Decimal, nSegundoValor As Decimal) As Decimal
        If (nPrimerValor + nSegundoValor) > 0 Then
            Return (nPrimerValor - nSegundoValor) / IIf(nSegundoValor = 0, nPrimerValor, nSegundoValor)
        Else
            Return 0
        End If
    End Function


    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Devuelve el Trimestre en Nombre y Año")> _
    Public Shared Function TrimestreEnLetras(dFecha As DateTime) As String
        Dim NombreTrimestre As String = String.Empty

        NombreTrimestre = MesDelTrimestre(dFecha, "P").TrimEnd() + "-" + MesDelTrimestre(dFecha, "F").TrimEnd() + " del " + FormatdateYear(dFecha).TrimEnd()


        Return NombreTrimestre
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Retorna el ultimo día del mes")> _
    Public Shared Function UltimoDiaDelMes(ByVal dtmFecha As DateTime) As DateTime
        UltimoDiaDelMes = DateSerial(Year(dtmFecha), Month(dtmFecha) + 1, 0)
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Retorna el ultimo día del mes anterior")>
    Public Shared Function UltimoDiaDelMesAnterior(ByVal dtmFecha As DateTime) As DateTime
        UltimoDiaDelMesAnterior = DateSerial(Year(dtmFecha), Month(dtmFecha), 0)
    End Function

    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Devuelve el ultimo día del trimestre de la fecha pasada como argumento o en su defecto la actual")> _
    Public Shared Function UltimoDiaTrimestre(dFecha As DateTime) As DateTime
        UltimoDiaTrimestre = DateSerial(Year(dFecha), Int((Month(dFecha) - 1) / 3) * 3 + 4, 0)
    End Function



    <[Function](Category:="Funciones Reportes", [Namespace]:="ConvertirFechas", Description:="Retorna primer día del mes actual")>
    Public Shared Function PrimerDiaDelMesActual(ByVal dtmFecha As DateTime) As Date
        PrimerDiaDelMesActual = DateSerial(Year(dtmFecha), Month(dtmFecha), 1)
    End Function



End Class
