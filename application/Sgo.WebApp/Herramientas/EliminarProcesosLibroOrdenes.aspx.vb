Imports Telerik.Web.UI
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Public Class EliminarProcesosLibroOrdenes
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick

        If e.Item.Value = 0 Then ' Procesar
            Try

                Dim vEmision As String = cbEmisionSerie.SelectedValue.Trim()
                Dim vTipoLibroOrdenes As String = cboTipoLibroOrdenes.SelectedValue.Trim()
                Dim vTipoProceso As String = cboTipoProceso.SelectedValue.Trim()

                If vTipoProceso = "O" Then 'Ordenes en subasta
                    If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) 1  FROM Subasta WHERE Bono='" & vEmision & "' AND CHARINDEX (','+CAST(RTRIM(TipoLibroOrdenes) AS VARCHAR(50))+',','," & vTipoLibroOrdenes & ",')>0) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 0 Then
                        Throw New Exception("No hay ordenes para eliminar.")

                    End If
                ElseIf vTipoProceso = "P" Then 'Prorrateo
                    If oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) 1  FROM ResultadoProrrateo WHERE CodEmisionBVRD='" & vEmision & "' AND CHARINDEX (','+CAST(RTRIM(TipoLibroOrdenes) AS VARCHAR(50))+',','," & vTipoLibroOrdenes & ",')>0) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 0 Then
                        Throw New Exception("No hay procesos de prorrateo para eliminar.")
                    End If
                ElseIf vTipoProceso = "T" Then 'Prorrateo y subasta
                    If (oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) 1  FROM Subasta WHERE Bono='" & vEmision & "' AND CHARINDEX (','+CAST(RTRIM(TipoLibroOrdenes) AS VARCHAR(50))+',','," & vTipoLibroOrdenes & ",')>0) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 0) And
                        (oper.ExecuteScalar("IF EXISTS (SELECT TOP (1) 1  FROM ResultadoProrrateo WHERE CodEmisionBVRD='" & vEmision & "' AND CHARINDEX (','+CAST(RTRIM(TipoLibroOrdenes) AS VARCHAR(50))+',','," & vTipoLibroOrdenes & ",')>0) BEGIN SELECT 1 END ELSE BEGIN SELECT 0 END ") = 0) Then
                        Throw New Exception("No hay ordenes ni procesos de prorrateo para eliminar.")
                    End If
                    End If

                Dim cmd As New SqlCommand
                Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

                cmd.CommandText = "dbo.PA_EliminarProcesoLibroOrdenes"
                cmd.CommandType = CommandType.StoredProcedure

                Dim paramFe As System.Data.SqlClient.SqlParameter
                paramFe = New System.Data.SqlClient.SqlParameter()
                paramFe.ParameterName = "@pTipoLibroOrdenes"
                paramFe.SqlDbType = SqlDbType.Char
                paramFe.Value = vTipoLibroOrdenes
                cmd.Parameters.Add(paramFe)

                Dim paramEm As System.Data.SqlClient.SqlParameter
                paramEm = New System.Data.SqlClient.SqlParameter()
                paramEm.ParameterName = "@pEmision"
                paramEm.SqlDbType = SqlDbType.Char
                paramEm.Value = vEmision
                cmd.Parameters.Add(paramEm)

                Dim paramTp As System.Data.SqlClient.SqlParameter
                paramTp = New System.Data.SqlClient.SqlParameter()
                paramTp.ParameterName = "@pTipoProceso"
                paramTp.SqlDbType = SqlDbType.Char
                paramTp.Value = vTipoProceso
                cmd.Parameters.Add(paramTp)


                Cnx.Open()
                cmd.Connection = Cnx
                cmd.ExecuteScalar()

                Mensaje.ForeColor = Drawing.Color.Blue
                Mensaje.Text = "El proceso se ejecutó correctamente."
            Catch ex As Exception
                Mensaje.ForeColor = Drawing.Color.Red
                Mensaje.Text = "Error: No se realizado el proceso. " & ex.Message
            End Try

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If
    End Sub

End Class