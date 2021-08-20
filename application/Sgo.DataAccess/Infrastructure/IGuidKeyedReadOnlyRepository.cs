using System;

namespace Sgo.DataAccess.Infrastructure
{
	public interface IGuidKeyedReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity:class
	{
		TEntity FindBy(Guid id);
	}
}