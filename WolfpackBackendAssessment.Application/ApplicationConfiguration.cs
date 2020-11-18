namespace WolfpackBackendAssessment.Application
{
    using System.Reflection;

    using MediatR;

    using AutoMapper;

	using Microsoft.Extensions.DependencyInjection;

	using Application.Behaviours;

	public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services)
            => services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
    }
}
