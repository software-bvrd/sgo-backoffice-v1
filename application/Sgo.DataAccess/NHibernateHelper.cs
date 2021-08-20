using System.Reflection;
using Sgo.DataAccess.Maps;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using FluentNHibernate.Automapping;
using Sgo.Model.Entities;

namespace Sgo.DataAccess.DataAccess
{
	public class NHibernateHelper
	{
		private readonly string _connectionString;
		private ISessionFactory _sessionFactory;

		public ISessionFactory SessionFactory
		{
			get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
		}

		public NHibernateHelper(string connectionString)
		{
			_connectionString = connectionString;
		}

		private ISessionFactory CreateSessionFactory()
		{
           	
            var configuration = Fluently.Configure()
            .Database(MsSqlConfiguration.MsSql2008
            .ConnectionString(_connectionString)
            .ShowSql())
            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))            
            .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Drop(false, false);
            exporter.Execute(false, false , false);
            _sessionFactory = configuration.BuildSessionFactory();

            return _sessionFactory;
		}


	}
}