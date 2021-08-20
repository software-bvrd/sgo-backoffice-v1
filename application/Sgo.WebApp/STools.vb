Imports System.Data.SqlClient

Friend NotInheritable Class STools


    Public Shared Sub InsertarInformacionArchivo(pDocumento As String, pLineasValidas As Integer, pLineasNoValidas As Integer, vFileType As String)
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Try
            Dim Sql As String = "INSERT INTO  [ListaArchivosOperaciones] ([Nombre],[Fecha],[LineasValidas],[LineasNoValidas], [FileType]) VALUES (@Nombre,@Fecha,@LineasValidas,@LineasNoValidas,@FileType)"

            Cnx.Open()

            Dim cmd As New SqlCommand(Sql, Cnx)

            cmd.Parameters.Add(New SqlParameter("@Nombre", SqlDbType.VarChar)).Value = pDocumento
            cmd.Parameters.Add(New SqlParameter("@Fecha", SqlDbType.DateTime)).Value = Now.ToString()
            cmd.Parameters.Add(New SqlParameter("@LineasValidas", SqlDbType.Int)).Value = pLineasValidas
            cmd.Parameters.Add(New SqlParameter("@LineasNoValidas", SqlDbType.Int)).Value = pLineasNoValidas
            cmd.Parameters.Add(New SqlParameter("@FileType", SqlDbType.NChar)).Value = vFileType
            cmd.ExecuteNonQuery()

        Catch sql_ex As SqlClient.SqlException

            If sql_ex.ErrorCode = -2146232060 Then
                Exit Sub
            End If

        Catch ex As Exception
        Finally
            Cnx.Close()

        End Try
    End Sub

    Public Shared Function InfoFileSql(vFileType As String) As String

        Dim sql As String = "SELECT [Nombre], [Fecha], [LineasValidas], [LineasNoValidas] FROM [vListaArchivosOperaciones] WHERE FileType = '{0}' ORDER BY [Fecha] DESC"
        sql = String.Format(sql, vFileType)

        Return sql
    End Function

End Class


