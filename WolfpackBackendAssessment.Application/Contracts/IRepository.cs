namespace WolfpackBackendAssessment.Application.Contracts
{
	using System.Threading;
	using System.Threading.Tasks;
    using System.Collections.Generic;

    using Domain.Common;

	public interface IRepository<TEntity> where TEntity : Entity<int>, IAggregateRoot
    {
        Task<IEnumerable<TEntity>> FindAllAsync(int skip = 0, int take = int.MaxValue, CancellationToken cancellationToken = default);

        Task<TEntity> FindAsync(int id, CancellationToken cancellationToken = default);

        Task<int> TotalAsync(CancellationToken cancellationToken = default);

        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        Task SaveAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
