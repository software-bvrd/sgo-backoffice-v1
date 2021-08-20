Imports System.Data

Public Class EditarEstatusEmision

    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ViewState("EsNuevo") = Request.QueryString("EsNuevo")


        If Session("Ajax") = True Then
            ViewState("Code") = Session("Code")
        Else
            ViewState("Code") = Request.QueryString("EmisionEstatusID")
        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False
        End If

        If IsPostBack = False Then
            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If

        'Borrar Serie  utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()

        End If

        txtDescripcion.Focus()
        txtDescripcion.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

    End Sub
    Protected Sub RadToolBar1_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar1.ButtonClick
        If e.Item.Value = 0 Then ' Guardar

            If ViewState("EsNuevo") = True Then
                Call Nuevo()
            End If

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Actualizar()
            End If

            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"

        ElseIf e.Item.Value = 2 Then ' Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then
            Dim Check As String
            Dim CheckMostrar As String
            Check = CheckBox1.Checked
            CheckMostrar = ckMostrarEnEdicion.Checked

            oper.ExecuteNonQuery("INSERT INTO EmisionEstatus (Descripcion,CodigoEstatus, Activo, MostrarEnEdicion) VALUES ('" & txtDescripcion.Text & "','" & txtCodigoEstatus.Text & "','" & Check & "','" & CheckMostrar & "')")

        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [EmisionEstatus]  where EmisionEstatusID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Descripcion")) Then Me.txtDescripcion.Text = Trim(MyRow.Item("Descripcion"))
            If Not IsDBNull(MyRow.Item("CodigoEstatus")) Then Me.txtCodigoEstatus.Text = Trim(MyRow.Item("CodigoEstatus"))
            If Not IsDBNull(MyRow.Item("MostrarEnEdicion")) Then Me.ckMostrarEnEdicion.Checked = Trim(MyRow.Item("MostrarEnEdicion"))
            If Not IsDBNull(MyRow.Item("Activo")) Then Me.CheckBox1.Checked = Trim(MyRow.Item("Activo"))
        Next
    End Sub

    Sub Actualizar()
        Dim Check As String
        Dim CheckMostrar As String
        Check = CheckBox1.Checked
        CheckMostrar = ckMostrarEnEdicion.Checked

        oper.ExecuteNonQuery("Update [EmisionEstatus] set  Descripcion='" & txtDescripcion.Text & "', CodigoEstatus = '" & txtCodigoEstatus.Text & "', Activo='" & Check & "', MostrarEnEdicion='" & CheckMostrar & "'  where EmisionEstatusID='" & CInt(ViewState("Code")) & "'")
        ViewState("EsNuevo") = False
    End Sub

    Sub Borrar()

        If oper.ExecuteNonQuery("delete from dbo.EmisionEstatus where EmisionEstatusID='" & ViewState("Code") & "'") Then
            InjectScriptLabel.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
            InjectScriptLabelImprimir.Text = "<script>ClosePage()</" + "script>"
        Else
            InjectScriptLabel.Text = "<script>MensajePopup('No se pudo borrar el registro, esta asociado a otras entidades.')</" + "script>"
        End If
    End Sub

    Protected Sub txtCodigoEstatus_TextChanged(sender As Object, e As EventArgs) Handles txtCodigoEstatus.TextChanged

        txtCodigoEstatus.Text = txtCodigoEstatus.Text.ToUpper()

    End Sub
End Class
