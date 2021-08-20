using System;
using System.Data;
using NHibernate;
using Sgo.DataAccess.Infrastructure;

namespace Sgo.DataAccess
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ISessionFactory _sessionFactory;
		private readonly ITransaction _transaction;
		public ISession Session { get; private set; }

		public UnitOfWork(ISessionFactory sessionFactory)
		{
			_sessionFactory = sessionFactory;
			Session = _sessionFactory.OpenSession();
			Session.FlushMode = FlushMode.Auto;
			_transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
            CurrentSession = Session;
		}

        public ISession CurrentSession { get; private set; }

		public void Dispose()
		{
			if(Session.IsOpen)
			{
				Session.Close();
			}
		}

		public void Commit()
		{
			if(!_transaction.IsActive)
			{
				throw new InvalidOperationException("No active transation");
			}
			_transaction.Commit();
		}

		public void Rollback()
		{
			if(_transaction.IsActive)
			{
				_transaction.Rollback();
			}
		}
	}
}