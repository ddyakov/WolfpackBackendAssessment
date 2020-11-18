namespace WolfpackBackendAssessment.Domain
{
    using Microsoft.Extensions.DependencyInjection;

    using Factories;

    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services
                .Scan(scan => scan
                    .FromCallingAssembly()
                    .AddClasses(classes => classes
                        .AssignableTo(typeof(IFactory<>)))
                    .AsMatchingInterface()
                    .WithTransientLifetime());
    }
}
