namespace WolfpackBackendAssessment.Infrastructure.Persistance
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;

	using Domain.Models.Packs;
    using Domain.Models.Wolves;

	internal class WolfPackDbContext : DbContext
    {
        public WolfPackDbContext(DbContextOptions<WolfPackDbContext> options)
            : base(options)
        {
        }

        public DbSet<Wolf> Wolves { get; set; } = default!;

        public DbSet<Pack> Packs { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
