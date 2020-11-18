namespace WolfpackBackendAssessment.Web
{
	using FluentValidation.AspNetCore;

	using Microsoft.Extensions.DependencyInjection;

	using Application.Common;

	public static class WebConfiguration
	{
		public static IServiceCollection AddWebComponents(this IServiceCollection services)
			=> services.
				AddControllers()
				.AddFluentValidation(validation => validation
					.RegisterValidatorsFromAssemblyContaining<Result>())
				.AddNewtonsoftJson()
				.ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
				.Services;
	}
}
