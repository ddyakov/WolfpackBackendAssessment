namespace WolfpackBackendAssessment.Infrastructure.Persistance.Repositories
{
	using System.Linq;
	using System.Threading;
	using System.Threading.Tasks;
	using System.Collections.Generic;

	using Microsoft.EntityFrameworkCore;

	using Domain.Models.Packs;
	using Application.Features.Packs;

	internal class PackRepository : 
		DataRepository<Pack>, 
		IPackRepository
	{
		public PackRepository(WolfPackDbContext db)
		   : base(db) { }

		public new async Task<IEnumerable<Pack>> FindAllAsync(
			int skip = 0,
			int take = int.MaxValue,
			CancellationToken cancellationToken = default)
			=> (await All()
				.Include(x => x.Wolves)
				.ToListAsync(cancellationToken))
				.Skip(skip)
				.Take(take);

		public new async Task<Pack> FindAsync(
			int id,
			CancellationToken cancellationToken = default)
			=> await All()
				.Include(x => x.Wolves)
				.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
	}
}
