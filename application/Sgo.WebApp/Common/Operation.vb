Imports System.Data.SqlClient

''' <summary>
''' operation 
''' </summary>
Public Class operation

    Dim boConn As Connection.Connection.DBConnection = New Connection.Connection.DBConnection()
    Private sda As SqlDataAdapter
    Private command As SqlCommand
    Public strruta As String = ConfigurationManager.AppSettings("strruta").ToString() '"\\arp22b\xml\"
    Public Dias As String() = New String(1) {"SÁBADO", "DOMINGO"}
    Public HorarioEstadoLiquidacion As String() = New String(8) {"09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00"}
    Public struser As String = "BVRDADM"

    Public Sub New()
    End Sub

    Public Function ExDataSet(ByVal _sql As String) As DataSet
        Try
            Dim ds As New DataSet()
            sda = New SqlDataAdapter(_sql, boConn.Connect())
            sda.Fill(ds)
            Return ds
        Catch
            Return Nothing
        Finally
            boConn.Disconnect()
        End Try
    End Function

    Public Function ExecuteNonQuery(ByVal _sql As String) As Boolean

        Try
            command = New SqlCommand(_sql, boConn.Connect())
            command.CommandTimeout = 0
            command.ExecuteNonQuery()
            Return True
        Catch
            Return False
        Finally
            boConn.Disconnect()
        End Try

    End Function

    Public Function ExecuteScalar(ByVal _sql As String) As String
        command = New SqlCommand(_sql, boConn.Connect())
        command.CommandTimeout = 0

        Try
            Return command.ExecuteScalar().ToString()
        Catch
            Return ""
        Finally
            boConn.Disconnect()
        End Try
    End Function

    Public Function ToDataBase(ByVal str As String) As String
        Return ("")
    End Function

    Public Function ToHTML(ByVal str As String) As String
        Return str.Replace("‘", "'").Replace("——", "--") ''.Replace(""", " \ "") .Replace("〈", "<").Replace("〉", ">")
    End Function

    Public Function ConvertHtml(ByVal text As String) As String
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

    Public Function ConvertirFechaEnAmerican(ByVal dFechaHora As DateTime) As String
        Dim cFechaRetorna As String = ""
        cFechaRetorna = String.Format("{0}/{1}/{2}", dFechaHora.Month, dFechaHora.Day, dFechaHora.Year)
        Return cFechaRetorna
    End Function

    Public Function ConvertirFechaEnISO(ByVal dFechaHora As DateTime) As String
        Return String.Format("{0}-{1}-{2}", dFechaHora.Year, dFechaHora.Month, dFechaHora.Day)
    End Function

    Public Function IsTime(ByVal StrTemp As String) As Boolean
        Dim StrShortTime As String
        IsTime = False
        StrTemp = StrTemp.Trim
        If StrTemp <> Nothing Then
            If IsDate(StrTemp) Then
                StrShortTime = Format(StrTemp, vbShortTime)
                If StrShortTime.ToUpper.IndexOf("AM") > 0 Or StrShortTime.ToUpper.IndexOf("PM") > 0 Then
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
        Dim Ds As DataSet = oper.ExDataSet(String.Format("Select Max(CAST({0} as BigInt)) as Secuence from {1}{2}", Campo, Tabla, Condicion))
        If oper.CheckDataSet(Ds) Then
            For i As Integer = 0 To Ds.Tables(0).Rows.Count - 1
                If Not IsDBNull(Ds.Tables(0).Rows(i)("Secuence")) Then Secuencia = Ds.Tables(0).Rows(i)("Secuence")
            Next
            GetSecuence = Secuencia + 1
        Else
            GetSecuence = 1
        End If
    End Function

    ''' <summary>
    ''' Se envia la fecha en formato dd/mm/yyy como un caracter 
    ''' </summary>
    ''' <param name="cFechaHora"></param>
    ''' <returns>Fecha en formato americano</returns>
    ''' <remarks></remarks>
    ''' 
    Public Function ConvertirCadenaFechaEnAmerican(ByVal cFechaHora As String) As String
        Dim cFechaRetorna As String = ""
        ' Primero sacamos el dia ..
        cFechaRetorna = PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0")
        cFechaHora = cFechaHora.Substring(cFechaHora.IndexOf("/") + 1, cFechaHora.Trim.Length - (cFechaHora.IndexOf("/") + 1))
        ' Buscamos el Mes
        cFechaRetorna = String.Format("{0}/{1}", PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0"), cFechaRetorna)
        cFechaHora = cFechaHora.Substring(cFechaHora.IndexOf("/") + 1, cFechaHora.Trim.Length - (cFechaHora.IndexOf("/") + 1))
        ' Buscamos el año 
        cFechaRetorna = String.Format("{0}/{1}{2}", cFechaRetorna, IIf(cFechaHora.Trim.Length = 2, "20", ""), cFechaHora.Trim)
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
        cFechaHora = cFechaHora.Trim
        nTwoPointsPos = cFechaHora.IndexOf(":")

        If nTwoPointsPos > 0 Then
            cHora = cFechaHora.Substring(nTwoPointsPos - 3, cFechaHora.Trim.Length - (nTwoPointsPos - 3))
            cHora = cHora.Trim

            If cHora.Length = 4 Then
                cHora = cHora + ":00"
            End If

            cFechaHora = cFechaHora.Substring(0, nTwoPointsPos - 3)
            cFechaHora = cFechaHora.Trim
        End If

        If cFechaHora.IndexOf("/") > 0 Then
            ' Primero sacamos el dia ..
            cFechaRetorna = PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0")
            cFechaHora = cFechaHora.Substring(cFechaHora.IndexOf("/") + 1, cFechaHora.Trim.Length - (cFechaHora.IndexOf("/") + 1))
            cStringDia = cFechaRetorna

            ' Buscamos el Mes
            cFechaRetorna = String.Format("{0}/{1}", PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0"), cFechaRetorna)
            cStringMes = PadL(cFechaHora.Substring(0, cFechaHora.IndexOf("/")), 2, "0")
            cFechaHora = cFechaHora.Substring(cFechaHora.IndexOf("/") + 1, cFechaHora.Trim.Length - (cFechaHora.IndexOf("/") + 1))

            ' Buscamos el año 
            cFechaRetorna = String.Format("{0}/{1}{2}", cFechaRetorna, IIf(cFechaHora.Trim.Length = 2, "20", ""), cFechaHora.Trim)
            cStringAnyo = IIf(cFechaHora.Trim.Length = 2, "20", "") + cFechaHora.Trim

            If FormatoFecha = "Español" Then
                cFechaRetorna = String.Format("{0}-{1}-{2}", cStringAnyo, cStringMes, cStringDia)
            Else
                cFechaRetorna = String.Format("{0}-{1}-{2}", cStringAnyo, cStringDia, cStringMes)

            End If

        Else
            cFechaRetorna = cFechaHora.Trim

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

    Public Sub GenerarSeguimientoActividadUsuario(ByVal nUsuario As Integer, ByVal actividad As String, ByVal pantalla As String, ByVal comando As String)
        Dim oper As New operation
        comando = comando.Replace("'", "|")
        comando = comando.Replace("& vbCrLf &", "|")

        Dim sql As String = String.Format("INSERT INTO [UsuariosSeguimientoActividad] ([IdUsuario] ,[Actividad] ,[Pantalla] ,[Comando]) VALUES ({0},'{1}','{2}','{3}')", nUsuario, actividad, pantalla, comando)
        oper.ExecuteNonQuery(sql)
    End Sub

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
        Dim cFechaRetorna As String = ""
        cFechaRetorna = String.Format("{0}-{1}-{2}", pFecha.Year, pFecha.Month, pFecha.Day)
        Return cFechaRetorna
    End Function

    Public Shared NombreUsuario As String = "" 'Variable global que almacena el nombre de usuario para uso total de la aplicacion 

End Class


