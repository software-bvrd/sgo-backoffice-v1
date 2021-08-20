Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class Operation

    Public Shared StrCnnString As String = ConfigurationManager.ConnectionStrings("CN").ConnectionString
    Private conn As SqlConnection
    Private sda As SqlDataAdapter
    Private command As SqlCommand

    Public Sub New()
    End Sub

    Public Sub Con()
        conn = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())
        conn.Open()
    End Sub

    Public Function ExDataSet(ByVal sql As String) As DataSet
        Con()
        Dim ds As New DataSet()
        sda = New SqlDataAdapter(sql, conn)
        Try
            sda.Fill(ds)
            Return ds
        Catch
            Return Nothing
        Finally
            conn.Close()
        End Try
    End Function

     Public Function ExecuteNonQuery(ByVal sql As String) As Boolean
        Con()
        command = New SqlCommand(sql, conn)
        Try
            command.ExecuteNonQuery()
            Return True
        Catch
            Return False
        Finally
            conn.Close()
        End Try

    End Function

    Public Function ExecuteScalar(ByVal sql As String) As String
        Con()
        command = New SqlCommand(sql, conn)
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

    Public Function ToHtml(ByVal str As String) As String
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
    End Sub

    Public Function ConvertirFechaEnAmerican(ByVal dFechaHora As Date) As String
        Dim nAnoTemporal As Integer = dFechaHora.Year
        Dim nMesTemporal As Integer = dFechaHora.Month
        Dim nDiaTemporal As Integer = dFechaHora.Day
        Dim cFechaRetorna As String = ""
        cFechaRetorna = dFechaHora.Month.ToString & "/" & dFechaHora.Day.ToString & "/" & dFechaHora.Year.ToString
        Return cFechaRetorna
    End Function

    Public Function ConvertirFechaEnIso(ByVal dFechaHora As DateTime) As String
        Dim nAnoTemporal As Integer = dFechaHora.Year
        Dim nMesTemporal As Integer = dFechaHora.Month
        Dim nDiaTemporal As Integer = dFechaHora.Day
        Return dFechaHora.Year.ToString & "-" & dFechaHora.Month.ToString & "-" & dFechaHora.Day.ToString
    End Function

    Public Function IsTime(ByVal strTemp As String) As Boolean
        Dim strShortTime As String
        IsTime = False
        strTemp = strTemp.Trim

        If strTemp <> Nothing Then
            If IsDate(strTemp) Then
                strShortTime = Format(strTemp, vbShortTime)
                If strShortTime.IndexOf("AM") > 0 Or strShortTime.IndexOf("PM") > 0 Then
                    IsTime = True
                Else
                    IsTime = False
                End If
            End If
        End If
    End Function
    
    Function GetSecuence(ByVal tabla As String, ByVal campo As String, Optional ByVal condicion As String = Nothing) As Int64
        Dim oper As New Operation
        Dim secuencia As Int64 = 0
        Dim ds As DataSet = oper.ExDataSet("Select Max(CAST(" & campo & " as BigInt)) as Secuence from " & tabla & "" & condicion & "")
        If oper.CheckDataSet(ds) Then
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                If Not IsDBNull(ds.Tables(0).Rows(i)("Secuence")) Then secuencia = ds.Tables(0).Rows(i)("Secuence")
            Next
            GetSecuence = secuencia + 1
        Else
            GetSecuence = 1
        End If
    End Function
    
    Public Function ConvertirCadenaFechaEnAmerican(ByVal cFechaHora As String) As String
        Dim cFechaRetorna As String = ""
        cFechaRetorna = cFechaHora.Substring(3, 2) & "/" & cFechaHora.Substring(0, 2) & "/" & cFechaHora.Substring(6, 4)
        Return cFechaRetorna
    End Function
    
    Public Function App_Path() As String
        Return AppDomain.CurrentDomain.BaseDirectory().Trim
    End Function

End Class


