namespace WolfpackBackendAssessment.Startup
{
    using Microsoft.AspNetCore.Builder;
	using Microsoft.Extensions.DependencyInjection;

	using Infrastructure;

	public static class ApplicationInitialization
    {
        public static IApplicationBuilder Initialize(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var initializers = serviceScope.ServiceProvider.GetServices<IInitializer>();

            foreach (var initializer in initializers)
                initializer.Initialize();

            return app;
        }
    }
}
