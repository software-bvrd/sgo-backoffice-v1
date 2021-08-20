
Partial Class Consultas_CuboOperacionesMultiple
    Inherits System.Web.UI.Page

    Protected Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        If Not IsPostBack Then

            TOLAPCube1.Active = True

        End If
    End Sub
End Class
