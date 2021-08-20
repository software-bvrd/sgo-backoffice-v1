
Partial Class endsession
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Session.RemoveAll()
        FormsAuthentication.SignOut()
        Response.Redirect("~/accounts/login.aspx")
    End Sub
End Class
