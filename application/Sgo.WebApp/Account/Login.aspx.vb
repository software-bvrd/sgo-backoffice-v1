
Partial Class Account_Login
    Inherits Page
    Private oper As New operation

    Dim AttemptsCounts As Integer = Convert.ToInt32(ConfigurationManager.AppSettings("AttemptsCounts").ToString())

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtUserName.Focus()
        End If
    End Sub

    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LoginButton.Click

        'TODO: Login | Activar para la bolsa


        Dim aAuthent As BVRD.Security.Utils.LDapAuthenticate = New BVRD.Security.Utils.LDapAuthenticate()

        Dim MSG As String
        Dim AppDomain As String = ConfigurationManager.AppSettings("AppDomain").ToString()

        If (Not aAuthent.SetDomain(AppDomain)) Then
            MSG = "Nombre de dominio no valido"
            Return
        End If

        If (Not aAuthent.SetUser(txtUserName.Text)) Then
            MSG = "Debe proporcionar un nombre de usuario valido, verifique!"
            Return
        End If

        If (Not aAuthent.SetPass(txtPassword.Text)) Then
            Dim _msg As String
            _msg = String.Format("Contraseña no valida para el usuario {0}, verifique!", txtUserName.Text.ToUpper())
            MSG = _msg
            Return
        End If

        aAuthent.SetAuthenticationType(False)

        'Dim users As List(Of BVRD.Security.Utils.Users)
        'users = aAuthent.GetADUsers()
        'For Each item In users
        '    Dim DisplayName As String = item.DisplayName
        '    Dim UserName As String = item.UserName
        '    Dim Mapped As String = item.isMapped

        '    txtUserName.Text = txtUserName.Text + " ; " + item.DisplayName + "-" + item.UserName + "-" + item.Email + "-" + item.isMapped.ToString()
        'Next

        aAuthent.GetADUsers()

        If (aAuthent.Login()) Then

            Dim ds As DataSet = oper.ExDataSet(String.Format("Select * from  TBL_Usuarios where IdEstatus='A' and NombreUsuario='{0}'", Trim(txtUserName.Text.Replace("'", ""))))
            If ds.Tables(0).Rows.Count > 0 Then
                If Not IsDBNull(ds.Tables(0).Rows(0)("IdUsuario")) Then
                    Session("IdUsuario") = CStr(ds.Tables(0).Rows(0)("IdUsuario"))
                    Session.Timeout = 40
                End If

                If Not IsDBNull(ds.Tables(0).Rows(0)("NombreUsuario")) Then Session("MyUserName") = CStr(ds.Tables(0).Rows(0)("NombreUsuario"))
                If Not IsDBNull(ds.Tables(0).Rows(0)("IdPerfil")) Then Session("IdPerfil") = CStr(ds.Tables(0).Rows(0)("IdPerfil"))

                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso al Sistema", "Inicio", "")

                FormsAuthentication.RedirectFromLoginPage(Me.txtUserName.Text, False)
                Response.Redirect("~/default.aspx")
            Else
                FailureText.Text = String.Format("Usuario {0} No tiene permiso en la aplicacion, Verifique!", txtUserName.Text)
                CurrentLoginCount.Value = CurrentLoginCount.Value + 1
            End If
        Else
            CurrentLoginCount.Value = CurrentLoginCount.Value + 1

            If (CurrentLoginCount.Value <= AttemptsCounts) Then
                'Muestra mensage de error
                FailureText.Text = aAuthent.MSG
            Else
                'Cancela
                Response.Redirect("Logout.aspx")
            End If
        End If

        operation.NombreUsuario = Session("MyUserName")


        ' Peopleworks

        'Dim ds As DataSet = oper.ExDataSet("Select * from  TBL_Usuarios where IdEstatus='A' and NombreUsuario='" & Trim(txtUserName.Text.Replace("'", "")) & "'")

        'If ds.Tables(0).Rows.Count > 0 Then

        '    ''
        '    If Not IsDBNull(ds.Tables(0).Rows(0)("IdUsuario")) Then
        '        Session("IdUsuario") = CStr(ds.Tables(0).Rows(0)("IdUsuario"))
        '        'Session.Timeout = 20
        '    End If

        '    If Not IsDBNull(ds.Tables(0).Rows(0)("NombreUsuario")) Then Session("MyUserName") = CStr(ds.Tables(0).Rows(0)("NombreUsuario"))
        '    If Not IsDBNull(ds.Tables(0).Rows(0)("IdPerfil")) Then Session("IdPerfil") = CStr(ds.Tables(0).Rows(0)("IdPerfil"))
        '    ''
        '    'oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso al Sistema", "Inicio", "")

        '    FormsAuthentication.RedirectFromLoginPage(Me.txtUserName.Text, False)
        '    Response.Redirect("~/default.aspx")
        'Else
        '    FailureText.Text = "Usuario " + txtUserName.Text + " No tiene permiso en la aplicacion, Verifique!"
        '    CurrentLoginCount.Value = CurrentLoginCount.Value + 1
        'End If
        ''Else
        ''    CurrentLoginCount.Value = CurrentLoginCount.Value + 1

        ''    If (CurrentLoginCount.Value <= AttemptsCounts) Then
        ''        'Muestra mensage de error
        ''        FailureText.Text = aAuthent.MSG
        ''    Else
        ''        'Cancela
        ''        Response.Redirect("Logout.aspx")
        ''    End If
        ''End If

        'operation.NombreUsuario = Session("MyUserName")


    End Sub

End Class