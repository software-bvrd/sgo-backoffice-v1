Imports System.Data.SqlClient
Imports System.IO
Imports System.Xml.Serialization
Imports OfficeOpenXml


Public Class GenerarArchivoGP
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Function ConsultaDataGP(fechainicio As Object, fechafin As Object) As DataSet
        Dim dsOperacionesGP As New DataSet
        Dim Cnx As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("CN").ToString())

        Dim Sql As String = "select '123456789'  AS RNC
                                ,'S004-1' AS CodigoServicio
                                ,'20180919' AS FechaFactura
                                ,120000.00 AS Monto
                                ,'RDPESOS' AS Moneda
                                ,30 AS DiasVencimiento
                                union all
                                select '123456789'  AS RNC
                                ,'S004-1' AS CodigoServicio
                                ,'20180919' AS FechaFactura
                                ,120000.00 AS Monto
                                ,'RDPESOS' AS Moneda
                                ,30 AS DiasVencimiento"
        Dim cmd As New SqlCommand(Sql, Cnx)
        Dim sqlAdap As New SqlDataAdapter

        ' cmd.Parameters.Add(New SqlParameter("@fechainicio", SqlDbType.DateTime)).Value = fechainicio
        ' cmd.Parameters.Add(New SqlParameter("@fechafin", SqlDbType.DateTime)).Value = fechafin
        sqlAdap.SelectCommand = cmd
        sqlAdap.Fill(dsOperacionesGP)
        Return dsOperacionesGP

    End Function
    ' ------------------------------------------------------------------------
    ' Barra de Botonos superior
    ' ------------------------------------------------------------------------
    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        lblmsg.Text = String.Empty
        If e.Item.Value = 0 Then 'Guardar


        ElseIf e.Item.Value = 1 Then ' Descargar

            If txtFechaInicial.DbSelectedDate = Nothing Or txtFechaFinal.DbSelectedDate = Nothing Then
                lblmsg.Text = "Las fechas inicial y final son obligatorias."
            Else
                Dim dsOperacionesGP As New DataSet
                Dim fileName As String = "GP_" + Format(txtFechaInicial.DbSelectedDate, "yyyyMMdd") + "_" + Format(txtFechaFinal.DbSelectedDate, "yyyyMMdd") + ".csv"

                dsOperacionesGP = ConsultaDataGP(txtFechaInicial.DbSelectedDate, txtFechaFinal.DbSelectedDate)


                If dsOperacionesGP.Tables(0).Rows.Count = 0 Then
                    lblmsg.Text = "No se encuentran registros para el rango de fecha definido."
                Else
                    Response.Clear()
                    Response.ContentType = "text/plain"
                    Response.AppendHeader("content-disposition", "attachment; filename=" + fileName)

                    Dim myData As Byte() = csvBytesWriter(dsOperacionesGP.Tables(0))

                    Response.BinaryWrite(myData)
                    Response.End()

                End If

            End If

        ElseIf e.Item.Value = 2 Then  ' Cancelar
            Me.txtFechaInicial.SelectedDate = Nothing
            Me.txtFechaFinal.SelectedDate = Nothing
            Me.lblmsg.Text = ""
        ElseIf e.Item.Value = 3 Then

        End If

    End Sub


    Function csvBytesWriter(ByRef dTable As DataTable) As Byte()

        '--------Columns Name---------------------------------------------------------------------------

        Dim sb As StringBuilder = New StringBuilder()
        Dim intClmn As Integer = dTable.Columns.Count

        Dim i As Integer = 0
        For i = 0 To intClmn - 1 Step i + 1
            sb.Append("" + dTable.Columns(i).ColumnName.ToString() + "")
            If i = intClmn - 1 Then
                sb.Append(" ")
            Else
                sb.Append(",")
            End If
        Next
        sb.Append(vbNewLine)

        '--------Data By  Columns---------------------------------------------------------------------------

        Dim row As DataRow
        For Each row In dTable.Rows

            Dim ir As Integer = 0
            For ir = 0 To intClmn - 1 Step ir + 1
                sb.Append("" + row(ir).ToString().Replace("""", """""") + "")
                If ir = intClmn - 1 Then
                    sb.Append(" ")
                Else
                    sb.Append(",")
                End If

            Next
            sb.Append(vbNewLine)
        Next

        Return System.Text.Encoding.UTF8.GetBytes(sb.ToString)

    End Function
End Class