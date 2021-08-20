Imports Telerik.Web.UI
Imports RadarSoft.RadarCube.Web


Partial Class CuboInstrumentos
    Inherits System.Web.UI.Page
    Private oper As New operation

    Protected Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init
        RadarSoft.RadarCube.Common.RadarUtils.AddResourceStrings(MapPath("~/bin/es.Resources.resx"),
        New System.Globalization.CultureInfo("es-DO"))
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Cubo.Active = True

            With Grid
                .UsePreferredBrowserLanguage = False
            End With


            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Cubo de Instrumentos", "Cubo de Instrumentos", "")



        End If

    End Sub


    Protected Sub Grid_OnAfterPivot(sender As Object, e As TPivotEventArgs) Handles Grid.OnAfterPivot

        Grid.BeginUpdate()
        Grid.ApplyChanges()
        Grid.EndChange(RadarSoft.RadarCube.Common.TGridEventType.geActiveChanged)
        Grid.EndUpdate()

    End Sub

    
    Protected Sub Actualizar_Click(sender As Object, e As EventArgs) Handles Actualizar.Click

        With Grid

            .BeginUpdate()
            .ApplyChanges()
            .EndUpdate()


        End With

    End Sub

End Class
