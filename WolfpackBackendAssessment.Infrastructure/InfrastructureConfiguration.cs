namespace WolfpackBackendAssessment.Infrastructure
{
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	using Application.Contracts;
	using Infrastructure.Persistance;

	public static class InfrastructureConfiguration
	{
		public static IServiceCollection AddInfrastructure(
			this IServiceCollection services,
			IConfiguration configuration)
			=> services
				.AddDatabase(configuration)
				.AddRepositories();

		private static IServiceCollection AddDatabase(
			this IServiceCollection services,
			IConfiguration configuration)
			=> services
				.AddDbContext<WolfPackDbContext>(options => options
					.UseSqlServer(
						configuration.GetConnectionString("DefaultConnection"),
						sqlServer => sqlServer
							.MigrationsAssembly(typeof(WolfPackDbContext)
								.Assembly.FullName)))
				.AddTransient<IInitializer, WolfPackDbInitializer>();

		internal static IServiceCollection AddRepositories(this IServiceCollection services)
			=> services
				.Scan(scan => scan
					.FromCallingAssembly()
					.AddClasses(classes => classes
						.AssignableTo(typeof(IRepository<>)))
					.AsMatchingInterface()
					.WithTransientLifetime());
	}
}
