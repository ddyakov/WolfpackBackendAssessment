namespace WolfpackBackendAssessment.Infrastructure.Persistance
{
	using Microsoft.EntityFrameworkCore;

	internal class WolfPackDbInitializer : IInitializer
	{
		private readonly WolfPackDbContext _db;

		public WolfPackDbInitializer(WolfPackDbContext db) => _db = db;

		public void Initialize()
		{
			_db.Database.Migrate();
			_db.SaveChanges();
		}
	}
}
