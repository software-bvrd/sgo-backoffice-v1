Imports System.Text.RegularExpressions
Imports System.Net.Mail
Imports System.Configuration

Public Class Mailer

    Public ReadOnly Property mailUser() As String
        Get
            Return ConfigurationManager.AppSettings.Get("mailUser")
        End Get

    End Property

    Public ReadOnly Property mailPwd() As String
        Get
            Return ConfigurationManager.AppSettings.Get("mailPwd")
        End Get
    End Property

    Public ReadOnly Property mailServer() As String
        Get
            Return ConfigurationManager.AppSettings.Get("mailServer")
        End Get
    End Property

    Public ReadOnly Property mailSender() As String
        Get
            Return ConfigurationManager.AppSettings.Get("mailSender")
        End Get
    End Property

    Public ReadOnly Property mailPort() As String
        Get
            Return ConfigurationManager.AppSettings.Get("mailPort")
        End Get
    End Property

    Public ReadOnly Property monitor() As String
        Get
            Return ConfigurationManager.AppSettings.Get("monitor")
        End Get
    End Property

    Public Sub SendMail(ByVal [From] As String, ByVal [To] As String,
                    ByVal Subject As String, ByVal Body As String, ByVal MailServer _
                    As String, Optional ByVal IsBodyHtml As Boolean = True,
                    Optional ByVal MailPort As Integer = 25,
                    Optional ByVal Attachments() As String = Nothing, Optional _
                    ByVal AuthUsername As String = Nothing, Optional ByVal _
                    AuthPassword As String = Nothing)

        Dim MailClient As New SmtpClient(MailServer, MailPort)

        Dim MailMessage = New MailMessage(
                          [From], [To], Subject, Body)

        MailMessage.IsBodyHtml = IsBodyHtml

        If (AuthUsername IsNot Nothing) AndAlso (AuthPassword _
            IsNot Nothing) Then
            With MailClient
                .DeliveryMethod = SmtpDeliveryMethod.Network
                .UseDefaultCredentials = True
                .EnableSsl = True
                .Credentials = New _
                                         Net.NetworkCredential(AuthUsername, AuthPassword)
            End With
        End If

        If (Attachments IsNot Nothing) Then
            For Each FileName In Attachments
                MailMessage.Attachments.Add(
                                            New Attachment(FileName))
            Next
        End If

        MailClient.Send(MailMessage)

    End Sub

    public Sub SendMail(ByVal Subject As String, ByVal Body As String, Optional ByVal IsBodyHtml As Boolean = True)

        Dim MailClient As New SmtpClient(mailServer, mailPort)
        Dim MailMessage = New MailMessage(mailSender, monitor, Subject, Body)
        MailMessage.IsBodyHtml = IsBodyHtml

        If (mailUser IsNot Nothing) AndAlso (mailPwd _
            IsNot Nothing) Then
            With MailClient
                .DeliveryMethod = SmtpDeliveryMethod.Network
                .UseDefaultCredentials = True
                .EnableSsl = True
                .Credentials = New _
                                         Net.NetworkCredential(mailUser, mailPwd)
            End With
        End If
                
        MailClient.Send(MailMessage)

    End Sub

    Shared Function validarCorreoElectronico(correo As String)
        Dim lEsvalido As Boolean = False
        Dim strMessage As String = ""
        Dim regex As Regex = New Regex("([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\." +
                                       ")|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})",
                                       RegexOptions.IgnoreCase _
                                       Or RegexOptions.CultureInvariant _
                                       Or RegexOptions.IgnorePatternWhitespace _
                                       Or RegexOptions.Compiled
                                       )
        Dim IsMatch As Boolean = regex.IsMatch(correo.Trim)
        If IsMatch Then
            If correo.Equals(regex.Match(correo.Trim).ToString) Then
                lEsvalido = True
            Else
                lEsvalido = False
            End If
        Else
            lEsvalido = False
        End If

        Return lEsvalido
    End Function

End Class
