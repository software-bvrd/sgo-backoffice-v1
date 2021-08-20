Imports Telerik.Web.UI

Public Class ActivarCorredor
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        InjectScriptLabel.Text = ""

        If IsPostBack = False Then


            txtCodigoPuestoBolsaCorredorID.Text = Request.QueryString("PuestoBolsaCorredorID")  'PuestoBolsaCorredorID
            lblNombreCorredor.Text = Request.QueryString("Nombre") ' Nombre Corredor


            RadComboBoxPuestoBolsaID.Focus()

        End If

    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        Dim nPuestoBolaCorredor As Integer = 0
        Dim cPuestoBolsaCorredor As String = ""
        Dim cCedula As String = ""
        Dim cCodBVRD As String = ""


        If e.Item.Value = 0 Then ' Guardar

            '
            ' Garantizar que no se este activando un corredor que ya exista
            '
            Dim cSql As String = ""

            ' Paso 1
            cSql = "Select Cedula FROM dbo.PuestoBolsaCorredor WHERE PuestoBolsaCorredorID = " & txtCodigoPuestoBolsaCorredorID.Text
            cCedula = oper.ExecuteScalar(cSql)

            ' Paso 2
            cSql = "Select CodBVRD FROM dbo.PuestoBolsaCorredor WHERE PuestoBolsaCorredorID = " & txtCodigoPuestoBolsaCorredorID.Text
            cCodBVRD = oper.ExecuteScalar(cSql)

            ' Paso 3
            cSql = "Select PuestoBolsaCorredorID FROM dbo.PuestoBolsaCorredor WHERE Activo = 1 and ( Cedula='" & cCedula & "' or CodBVRD = '" & cCodBVRD & "' )"
            cPuestoBolsaCorredor = oper.ExecuteScalar(cSql)

            ' Paso 4 : Solo activar si no existe un activo que tenga estos parametros..
            If cPuestoBolsaCorredor.TrimEnd() = "" Then

                cSql = "Update [PuestoBolsaCorredor] set Activo = 1, PuestoBolsaID = " & RadComboBoxPuestoBolsaID.SelectedValue & " where PuestoBolsaCorredorID = " & txtCodigoPuestoBolsaCorredorID.Text
                oper.ExecuteNonQuery(cSql)

                oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Activar Corredor", "Consulta Corredores", cSql)

                Exit Sub
            End If



            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub



End Class