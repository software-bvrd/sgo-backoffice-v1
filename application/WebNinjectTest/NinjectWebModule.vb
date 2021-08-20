Imports Sgo.DataAccess.DataAccess
Imports NHibernate
Imports Sgo.DataAccess.Infrastructure
Imports WebNinjectTest.WebNinjectTest.App_Start
Imports Sgo.DataAccess

Public Class NinjectWebModule
    Inherits Ninject.Modules.NinjectModule

    Public Overrides Sub Load()
        'region Infrastructure
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("CN").ConnectionString
        Dim helper As NHibernateHelper = New NHibernateHelper(connectionString)

        Bind(Of ISessionFactory)().ToConstant(helper.SessionFactory).InSingletonScope()
        Bind(Of IUnitOfWork)().[To](Of UnitOfWork)()




        Kernel.Bind(GetType(IRepository(Of ))).[To](GetType(RepositoryBase(Of )))

    End Sub
End Class
