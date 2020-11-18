namespace WolfpackBackendAssessment.Infrastructure.Persistance.Repositories
{
	using Domain.Models.Wolves;
	using Application.Features.Wolves;

	internal class WolfRepository : 
		DataRepository<Wolf>, 
		IWolfRepository
	{
		public WolfRepository(WolfPackDbContext db)
		   : base(db) { }
	}
}
