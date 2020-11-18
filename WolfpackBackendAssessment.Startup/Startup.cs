namespace WolfpackBackendAssessment.Startup
{
	using Microsoft.AspNetCore.Builder;
	using Microsoft.AspNetCore.Hosting;
	using Microsoft.Extensions.Hosting;
	using Microsoft.Extensions.Configuration;
	using Microsoft.Extensions.DependencyInjection;

	using Web;
	using Domain;
	using Application;
	using Web.Middleware;
	using Infrastructure;

	public class Startup
	{
		public Startup(IConfiguration configuration) => Configuration = configuration;

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
			=> services
				.AddDomain()
				.AddApplication()
				.AddInfrastructure(Configuration)
				.AddWebComponents()
				.AddSwaggerDocument(configure => 
				{
					configure.Title = "WolfPack Backend Assessment API";
					configure.Version = "1.0.0";
				});

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app
				.UseValidationExceptionHandler()
				.UseHttpsRedirection()
				.UseRouting()
				.UseCors(options => options
					.AllowAnyOrigin()
					.AllowAnyHeader()
					.AllowAnyMethod())
				.UseOpenApi()
				.UseSwaggerUi3()
				.UseEndpoints(endpoints => endpoints
					.MapControllers())
				.Initialize();
		}
	}
}
