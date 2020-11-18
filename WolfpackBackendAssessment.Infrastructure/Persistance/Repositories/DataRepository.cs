namespace WolfpackBackendAssessment.Infrastructure.Persistance.Repositories
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Microsoft.EntityFrameworkCore;

    using Domain.Common;
	using Application.Contracts;

	internal abstract class DataRepository<TEntity> : IRepository<TEntity> where TEntity : 
        Entity<int>, 
        IAggregateRoot
    {
        protected DataRepository(WolfPackDbContext db) => Data = db;

        protected WolfPackDbContext Data { get; }

        public async Task<IEnumerable<TEntity>> FindAllAsync(
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default)
            => (await All()
                .AsNoTracking()
                .ToListAsync(cancellationToken))
                .Skip(skip)
                .Take(take);

        public async Task<TEntity> FindAsync(
            int id,
            CancellationToken cancellationToken = default)
            => await All().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<int> TotalAsync(CancellationToken cancellationToken = default)
            => await All().CountAsync(cancellationToken);

        public async Task<bool> DeleteAsync(
            int id,
            CancellationToken cancellationToken = default)
        {
            var entity = await Data.Set<TEntity>().FindAsync(id);

            if (entity == null)
                return false;

            Data.Set<TEntity>().Remove(entity);
            await Data.SaveChangesAsync(cancellationToken);

            return true;
        }

        public async Task SaveAsync(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            Data.Update(entity);
            await Data.SaveChangesAsync(cancellationToken);
        }

        protected IQueryable<TEntity> All() => Data.Set<TEntity>();
    }
}
