Imports Sgo
Imports Sgo.DataAccess
Imports Sgo.Model.Entities
Imports Ninject

Imports Sgo.DataAccess.Infrastructure

Public Class _Default
    Inherits Ninject.Web.PageBase


    <Inject()>
    Property UofWork As IUnitOfWork

    <Inject()>
    Property PaisRepo As IRepository(Of Pais)



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
   


        Dim objPais As New Pais

        objPais.Paisid = 1
        objPais.Nombre = 1
        objPais.Isonum = 1
        objPais.Iso2 = 1
        objPais.Iso3 = 1

        PaisRepo.Update(objPais)

        UofWork.Commit()
    End Sub
End Class