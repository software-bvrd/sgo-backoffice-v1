Imports Ninject
Imports Sgo.Model.Entities
Imports Sgo.DataAccess.Infrastructure

Partial Class EditarPais
    Inherits PageBase

    <Inject()>
    Property PaisRepo As IRepository(Of Pais)

    Private oper As New operation
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        InjectScriptLabelImprimir.Text = ""
        InjectScriptLabel.Text = ""
        ViewState("EsNuevo") = Request.QueryString("EsNuevo")

        If Session("Ajax") = True Then
            ViewState("Code") = Session("Code")
        Else
            ViewState("Code") = Request.QueryString("PaisID")
        End If

        If ViewState("EsNuevo") = True Then
            RadToolBar1.Items.Item(2).Enabled = False

        End If
        If IsPostBack = False Then

            If ViewState("EsNuevo") = False And ViewState("EstaBorrando") = False Then
                Call Editar()
            End If
        End If

        'Borrar pais utilizando la confirmacion del usuario
        If Request.Params("__EVENTTARGET") = "borrar" Then
            Borrar()
        End If

        'txtNombre.Focus()
        TxtNombre.SelectionOnFocus = Telerik.Web.UI.SelectionOnFocus.SelectAll

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

        ElseIf e.Item.Value = 3 Then 'Borrar
            InjectScriptLabel.Text = "<script>Delete()</" + "script>"

        ElseIf e.Item.Value = 1 Then  ' Cancelar
            InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
        End If

    End Sub

    Sub Nuevo()
        If ViewState("EsNuevo") = True Then

            Dim objPais As New Pais

            objPais.Nombre = TxtNombre.Text
            objPais.Isonum = TxtISONUM.Text
            objPais.Iso2 = TxtISO2.Text
            objPais.Iso3 = TxtISO3.Text

            PaisRepo.Add(objPais)
            UofWork.Commit()

        End If
    End Sub

    Sub Editar()
        Dim ds As DataSet = oper.ExDataSet("SELECT * FROM  [Pais]  where PaisID='" & CInt(ViewState("Code")) & "'")
        Dim MyRow As DataRow
        For Each MyRow In ds.Tables(0).Rows
            If Not IsDBNull(MyRow.Item("Nombre")) Then Me.TxtNombre.Text = Trim(MyRow.Item("Nombre"))
            If Not IsDBNull(MyRow.Item("ISONUM")) Then Me.TxtISONUM.Text = Trim(MyRow.Item("ISONUM"))
            If Not IsDBNull(MyRow.Item("ISO2")) Then Me.TxtISO2.Text = Trim(MyRow.Item("ISO2"))
            If Not IsDBNull(MyRow.Item("ISO3")) Then Me.TxtISO3.Text = Trim(MyRow.Item("ISO3"))


        Next
    End Sub

    Sub Actualizar()
        
        Dim objPais As New Pais

        objPais.Paisid = CInt(ViewState("Code"))
        objPais.Nombre = TxtNombre.Text
        objPais.Isonum = TxtISONUM.Text
        objPais.Iso2 = TxtISO2.Text
        objPais.Iso3 = TxtISO3.Text

        PaisRepo.Update(objPais)

        UofWork.Commit()

        ViewState("EsNuevo") = False
    End Sub

    Sub Borrar()

        Dim ID = CInt(ViewState("Code"))
        Dim ValorAsociadoCiudad As String = ""
        Dim ValorAsociadoEmisor As String = ""
        ValorAsociadoCiudad = oper.ExecuteScalar("select Count(*) from Ciudad where PaisID ='" & ViewState("Code") & "'")
        ValorAsociadoEmisor = oper.ExecuteScalar("select Count(*) from Emisor where PaisID ='" & ViewState("Code") & "'")

        If Integer.Parse(ValorAsociadoCiudad) > 0 And Integer.Parse(ValorAsociadoEmisor) > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se puede borrar. Este registro esta asociado a ciudad y emisor.')</" + "script>"
        ElseIf Integer.Parse(ValorAsociadoCiudad) > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se puede borrar el país, esta asociado a una ciudad.')</" + "script>"
        ElseIf Integer.Parse(ValorAsociadoEmisor) > 0 Then
            InjectScriptLabel.Text = "<script>MensajePopup('No se puede borrar el país, esta asociado a un emisor.')</" + "script>"
        Else
            Dim resultDeletePais As Boolean
            '' resultDeletePais = oper.ExecuteNonQuery("delete from dbo.Pais where PaisID='" & ID & "'")
            Dim objPais As Pais
            objPais = PaisRepo.FindBy(Function(x) x.Paisid = ID)


            resultDeletePais = PaisRepo.Delete(objPais)
            UofWork.Commit()

            If resultDeletePais Then
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Registro borrado exitosamente.')</" + "script>"
                InjectScriptLabel.Text = "<script>ClosePage()</" + "script>"
            Else
                InjectScriptLabelImprimir.Text = "<script>MensajePopup('Error al borrar el registro.')</" + "script>"
            End If
        End If

    End Sub


End Class
