using NHibernate;
using System;

namespace Sgo.DataAccess.Infrastructure
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
		void Rollback();
        ISession CurrentSession { get; }
	}
}