
Partial Class Consultas_CuboConsolidado
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


            oper.GenerarSeguimientoActividadUsuario(Session("IdUsuario"), "Ingreso a Consulta: Cubo Consolidado", "Cubo Consolidado", "")



        End If

    End Sub



End Class
