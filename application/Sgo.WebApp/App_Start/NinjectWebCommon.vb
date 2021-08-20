Imports Microsoft.Web.Infrastructure.DynamicModuleHelper
Imports Ninject
Imports Ninject.Web.Common
Imports Sgo.DataAccess.Infrastructure
Imports NHibernate
Imports Sgo.DataAccess
Imports Sgo.DataAccess.DataAccess

<Assembly: WebActivator.PreApplicationStartMethod(GetType(Sgo.WebApp.App_Start.NinjectWebCommon), "StartNinject")>
<Assembly: WebActivator.ApplicationShutdownMethodAttribute(GetType(Sgo.WebApp.App_Start.NinjectWebCommon), "StopNinject")>

Namespace Sgo.WebApp.App_Start
    Public Module NinjectWebCommon
        Private ReadOnly bootstrapper As New Bootstrapper()

        ''' <summary>
        ''' Starts the application
        ''' </summary>
        Public Sub StartNinject()
            DynamicModuleUtility.RegisterModule(GetType(OnePerRequestHttpModule))
            bootstrapper.Initialize(AddressOf CreateKernel)
        End Sub

        ''' <summary>
        ''' Stops the application.
        ''' </summary>
        Public Sub StopNinject()
            bootstrapper.ShutDown()
        End Sub

        ''' <summary>
        ''' Creates the kernel that will manage your application.
        ''' </summary>
        ''' <returns>The created kernel.</returns>
        Private Function CreateKernel() As IKernel
            Dim kernel = New StandardKernel()
            RegisterServices(kernel)
            Return kernel
        End Function

        ''' <summary>
        ''' Load your modules or register your services here!
        ''' </summary>
        ''' <param name="kernel">The kernel.</param>
        Private Sub RegisterServices(ByVal kernel As IKernel)

            Dim boConn As Connection.Connection.DBConnection = New Connection.Connection.DBConnection()
            Dim helper As NHibernateHelper = New NHibernateHelper(boConn.getConnectionString)
            kernel.Bind(Of ISessionFactory)().ToConstant(helper.SessionFactory).InSingletonScope()
            kernel.Bind(Of IUnitOfWork)().[To](Of UnitOfWork)().InRequestScope()
            kernel.Bind(Of ISession)().ToProvider(New SessionProvider()).InRequestScope()
            kernel.Bind(GetType(IRepository(Of ))).[To](GetType(RepositoryBase(Of )))

        End Sub

    End Module

    Public Class SessionProvider

        Inherits Activation.Provider(Of ISession)

        Protected Overrides Function CreateInstance(context As Ninject.Activation.IContext) As ISession
            Dim unitOfWork As UnitOfWork = DirectCast(context.Kernel.[Get](Of IUnitOfWork)(), UnitOfWork)
            Return unitOfWork.Session

        End Function

    End Class

End Namespace