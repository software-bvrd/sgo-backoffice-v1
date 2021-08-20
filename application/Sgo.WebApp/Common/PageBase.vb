Imports Ninject
Imports Sgo.DataAccess.Infrastructure

Public Class PageBase
    Inherits Ninject.Web.PageBase

    <Inject()>
    Property UofWork As IUnitOfWork

End Class
