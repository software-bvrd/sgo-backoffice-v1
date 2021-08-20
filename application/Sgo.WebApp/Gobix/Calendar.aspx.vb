
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls

Public Class Calendar
    Inherits System.Web.UI.Page

    Private _headerImage As Image = Nothing
    Private _footerImage As Image = Nothing

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not IsPostBack Then

        End If
    End Sub

    Protected Sub RadCalendar1_DefaultViewChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.DefaultViewChangedEventArgs)
        AddImages(e.NewView)
    End Sub

    Protected Sub RadCalendar1_Load(sender As Object, e As EventArgs) Handles RadCalendar1.Load
        _headerImage = DirectCast(RadCalendar1.FindControl("HeaderImage"), Image)
        _footerImage = DirectCast(RadCalendar1.FindControl("FooterImage"), Image)
        AddImages(RadCalendar1.CalendarView)

    End Sub


    Private Sub AddImages(ByVal inputView As Telerik.Web.UI.Calendar.View.CalendarView)
        _headerImage.ImageUrl = "../Images/Calendar/no-header.jpg"
        _footerImage.ImageUrl = "../Images/Calendar/no-footer.jpg"
        _headerImage.AlternateText = ""
        _footerImage.AlternateText = ""
    End Sub

End Class