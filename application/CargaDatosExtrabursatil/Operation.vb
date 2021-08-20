Imports System
Imports System.Data
Imports System.Configuration

Imports System.Data.SqlClient
Imports System.Text.RegularExpressions


Imports Microsoft.VisualBasic
Imports System.Text

''' <summary>
''' operation 的摘要说明
''' </summary>
Public Class operation

    Public Shared strCnnString As String = ConfigurationManager.ConnectionStrings("CN").ConnectionString
    Private conn As SqlConnection
    Private sda As SqlDataAdapter
    Private command As SqlCommand



    Public Sub New()
    End Sub
    Public Sub con()
        conn = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        conn.Open()
    End Sub
    ''' <summary>
    ''' return DataSet
    ''' </summary>
    ''' <param name="_sql">sql</param>
    ''' <returns>DastaSet</returns>
    Public Function ExDataSet(ByVal _sql As String) As DataSet
        con()
        Dim ds As New DataSet()
        sda = New SqlDataAdapter(_sql, conn)
        Try
            sda.Fill(ds)
            Return ds
        Catch
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function
    ''' <summary>
    ''' return null
    ''' </summary>
    ''' <param name="_sql">sql</param>
    ''' <returns>null</returns>
    Public Function ExecuteNonQuery(ByVal _sql As String) As Boolean
        con()
        command = New SqlCommand(_sql, conn)
        Try
            command.ExecuteNonQuery()
            Return True
        Catch
            Return False
        Finally
            conn.Close()
        End Try

    End Function
    ''' <summary>
    ''' return string
    ''' </summary>
    ''' <param name="_sql">sql</param>
    ''' <returns>string</returns>
    Public Function ExecuteScalar(ByVal _sql As String) As String
        con()
        command = New SqlCommand(_sql, conn)
        Try
            Return command.ExecuteScalar().ToString()
        Catch
            Return ""
        Finally
            conn.Close()
        End Try
    End Function

    Public Function ToDataBase(ByVal str As String) As String
        'Return str.Replace("'", "‘").Replace("--", "——").Replace("""", "“").Replace("<", "(").Replace(">", ")")
        Return ("")
    End Function

    Public Function ToHTML(ByVal str As String) As String
        Return str.Replace("‘", "'").Replace("——", "--") ''.Replace(""", " \ "") .Replace("〈", "<").Replace("〉", ">")
    End Function
    Public Function ConvertHtml(ByVal text As String) As String
        Dim pattern As String = "<[\s\S]*?>"
        Dim regex As New Regex(pattern)
        Return text
    End Function
    Public Function CheckDataSet(ByVal ds As DataSet) As Boolean
        If IsNothing(ds) Then Return False

        If ds.Tables(0).Rows.Count <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub CleanCharFromtext(ByVal cTextToConvert As String)
        Dim s As String = cTextToConvert
        'MsgBox(Regex.Replace(s, "[^0-9]", ""))
    End Sub

    Public Function ConvertirFechaEnAmerican(ByVal dFechaHora As Date) As String
        Dim nAnoTemporal As Integer = dFechaHora.Year
        Dim nMesTemporal As Integer = dFechaHora.Month
        Dim nDiaTemporal As Integer = dFechaHora.Day

        Dim cFechaRetorna As String = ""
        cFechaRetorna = dFechaHora.Month.ToString & "/" & dFechaHora.Day.ToString & "/" & dFechaHora.Year.ToString
        Return cFechaRetorna
    End Function

    Public Function ConvertirFechaEnISO(ByVal dFechaHora As DateTime) As String
        Dim nAnoTemporal As Integer = dFechaHora.Year
        Dim nMesTemporal As Integer = dFechaHora.Month
        Dim nDiaTemporal As Integer = dFechaHora.Day
        Return dFechaHora.Year.ToString & "-" & dFechaHora.Month.ToString & "-" & dFechaHora.Day.ToString
    End Function

    Public Function IsTime(ByVal StrTemp As String) As Boolean

        Dim StrShortTime As String

        IsTime = False
        StrTemp = StrTemp.Trim

        If StrTemp <> Nothing Then
            If IsDate(StrTemp) Then
                StrShortTime = Format(StrTemp, vbShortTime)
                If StrShortTime.IndexOf("AM") > 0 Or StrShortTime.IndexOf("PM") > 0 Then
                    IsTime = True
                Else
                    IsTime = False
                End If
            End If
        End If

    End Function


    Function GetSecuence(ByVal Tabla As String, ByVal Campo As String, Optional ByVal Condicion As String = Nothing) As Int64
        Dim oper As New operation
        Dim Secuencia As Int64 = 0
        Dim Ds As DataSet = oper.ExDataSet("Select Max(CAST(" & Campo & " as BigInt)) as Secuence from " & Tabla & "" & Condicion & "")
        If oper.CheckDataSet(Ds) Then
            For i As Integer = 0 To Ds.Tables(0).Rows.Count - 1
                If Not IsDBNull(Ds.Tables(0).Rows(i)("Secuence")) Then Secuencia = Ds.Tables(0).Rows(i)("Secuence")
            Next
            GetSecuence = Secuencia + 1
        Else
            GetSecuence = 1
        End If
    End Function


    Public Function ConvertirCadenaFechaEnAmerican(ByVal cFechaHora As String) As String
        Dim cFechaRetorna As String = ""
        cFechaRetorna = cFechaHora.Substring(3, 2) & "/" & cFechaHora.Substring(0, 2) & "/" & cFechaHora.Substring(6, 4)
        Return cFechaRetorna
    End Function


    ''' <summary>
    ''' Se envia la fecha en formato dd/mm/yyyy como un caracter 
    ''' </summary>
    ''' <param name="cFechaHora"></param>
    ''' <returns>Fecha en formato ISO</returns>
    ''' <remarks></remarks>
    Public Function ConvertirCadenaFechaEnISO(ByVal cFechaHora As String, ByVal FormatoFecha As String) As String
        Dim cFechaRetorna As String = ""

        Dim cStringDia As String = ""
        Dim cStringMes As String = ""
        Dim cStringAnyo As String = ""
        Dim nTwoPointsPos As Integer = 0
        Dim cHora As String = ""

        ' Verificar si tiene Hora

        nTwoPointsPos = cFechaHora.IndexOf(":")
        If nTwoPointsPos > 0 Then

            cHora = cFechaHora.Substring(nTwoPointsPos - 3, cFechaHora.Trim.Length - (nTwoPointsPos - 3))


            cHora = cHora.Trim

            If cHora.Length = 4 Then
                cHora = cHora + ":00"
            End If

            cFechaHora = cFechaHora.Substring(1, nTwoPointsPos - 3)
            cFechaHora = cFechaHora.Trim

        End If


        ' Primero sacamos el dia ..
        cFechaRetorna = PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0")
        cFechaHora = cFechaHora.Substring(cFechaHora.IndexOf("/") + 1, cFechaHora.Trim.Length - (cFechaHora.IndexOf("/") + 1))
        cStringDia = cFechaRetorna


        ' Buscamos el Mes
        cFechaRetorna = PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0") + "/" + cFechaRetorna
        cStringMes = PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0")
        cFechaHora = cFechaHora.Substring(cFechaHora.IndexOf("/") + 1, cFechaHora.Trim.Length - (cFechaHora.IndexOf("/") + 1))



        ' Buscamos el año 
        cFechaRetorna = cFechaRetorna + "/" + IIf(cFechaHora.Trim.Length = 2, "20", "") + cFechaHora.Trim
        cStringAnyo = IIf(cFechaHora.Trim.Length = 2, "20", "") + cFechaHora.Trim

        If FormatoFecha = "Español" Then
            cFechaRetorna = cStringAnyo + "-" + cStringMes + "-" + cStringDia
        Else
            cFechaRetorna = cStringAnyo + "-" + cStringDia + "-" + cStringMes

        End If

        Return cFechaRetorna.Trim + IIf(cHora.Trim.Length > 0, " ", "") + cHora.Trim

    End Function

    Public Function LimpiarComasdeCadena(ByVal cCadena As String) As String
        Dim cNuevaCadena As String = ""
        Try
            For i As Integer = 0 To cCadena.Length - 1
                If cCadena.Substring(i, 1) = "|" Then
                    Dim n As Integer = cCadena.Substring(i + 1, cCadena.Length - (i + 1)).IndexOf("|")
                    Dim trozo As String = cCadena.Substring(i + 1, n)
                    Dim posfinal As Integer = i + trozo.Length
                    trozo = trozo.Replace("|", "")
                    trozo = trozo.Replace(",", "")
                    cCadena = cCadena.Substring(0, i) + trozo + cCadena.Substring(posfinal + 2, cCadena.Length - (posfinal + 2))
                End If
            Next
        Catch ex As Exception
            cNuevaCadena = ""
        Finally
            cNuevaCadena = cCadena
        End Try
        Return cNuevaCadena
    End Function
    Public Shared Function PadL(ByVal cExpression As String, ByVal nResultSize As Integer, ByVal cPaddingChar As Char) As String
        Return cExpression.PadLeft(nResultSize, cPaddingChar)
    End Function

    Public Function CovertirComandoATexto(command As IDbCommand) As String
        Dim builder As New StringBuilder()
        If command.CommandType = CommandType.StoredProcedure Then
            builder.AppendLine("Stored procedure: " + command.CommandText)
        Else
            builder.AppendLine("Sql command: " + command.CommandText)
        End If

        builder.AppendLine("Parámetro: ")

        For Each param As IDataParameter In command.Parameters
            builder.AppendFormat(" {0}: {1}", param.ParameterName, (If(param.Value Is Nothing, "NULL", param.Value.ToString()))).AppendLine()
        Next

        Return builder.ToString()
    End Function

    Public Function FormatoFechayymmdd(ByVal pFecha As Date) As String
        Dim nAnoTemporal As Integer = pFecha.Year
        Dim nMesTemporal As Integer = pFecha.Month
        Dim nDiaTemporal As Integer = pFecha.Day
        Dim cFechaRetorna As String = ""
        cFechaRetorna = pFecha.Year.ToString & "-" & pFecha.Month.ToString & "-" & pFecha.Day.ToString
        Return cFechaRetorna
    End Function




End Class


