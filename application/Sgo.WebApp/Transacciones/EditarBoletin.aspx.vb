Imports System.Data

Partial Class Transacciones_EditarBoletin
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then

            ViewState("EsNuevo") = Request.QueryString("EsNuevo")

            If Session("Ajax") = True Then
                ViewState("Code") = Session("Code")
            Else
                ViewState("Code") = Request.QueryString("BoletinID")
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If

            txtFecha.Focus()

            If ViewState("EsNuevo") = True Then
                Dim NumeroUltimoBoletin As String = oper.ExecuteScalar("SELECT TOP (1) Secuencial FROM Boletin ORDER BY Secuencial DESC")
                txtFecha.SelectedDate = Today.Date
                txtSecuencial.Text = Integer.Parse(NumeroUltimoBoletin) + 1

            End If
        End If


    End Sub

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            oper.ExecuteNonQuery("INSERT INTO Boletin (Fecha, Secuencial) VALUES ('" &
                                 Me.txtFecha.SelectedDate & "'," & txtSecuencial.Text & ")")
        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT Fecha, Secuencial FROM  [Boletin]  where BoletinID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow

        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Fecha")) Then Me.txtFecha.SelectedDate = Trim(MyRow.Item("Fecha"))
            If Not IsDBNull(MyRow.Item("Secuencial")) Then Me.txtSecuencial.Text = Trim(MyRow.Item("Secuencial"))
        Next
    End Sub

    Sub Actualizar()
        oper.ExecuteNonQuery("Update [Boletin] set  Fecha ='" & txtFecha.SelectedDate & "'," &
                             " Secuencial =" & txtSecuencial.Text &
                             " where BoletinID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub

    Protected Sub RadToolBar1_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar

            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

        Session("Ajax") = False

    End Sub

End Class
