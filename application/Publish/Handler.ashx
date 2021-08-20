<%@ WebHandler Language="VB" Class="Handler" %>
Imports System
Imports System.Web
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient

Public Class Handler : Implements IHttpHandler
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "image/jpeg"
        Dim img As Image = GetImage(context.Request.QueryString("id"))
        img.Save(context.Response.OutputStream, ImageFormat.Jpeg)
        
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property
    
    Private Function GetImage(inID As Long) As Image
        Dim ms As MemoryStream = New MemoryStream

      
        Dim cnStr As String = ConfigurationManager.ConnectionStrings("CN").ToString()
        Dim cn As New SqlConnection(cnStr)
        Try
            cn.Open()
        Catch ex As Exception

        End Try
        Dim ssql As String = "SELECT [Foto] FROM [vPuestoBolsaCorredores]s where PuestoBolsaCorredorID = " & inID
        'inID
        Dim cmd As SqlCommand = New SqlCommand(ssql, cn)
        Dim dr As SqlDataReader = cmd.ExecuteReader
        dr.Read()
        Dim img() As Byte = CType(dr("Foto"), Byte())
        ms = New MemoryStream(img, False)
        
        Return Image.FromStream(ms)
        
    End Function
End Class