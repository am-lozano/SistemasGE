using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CompositionRoot
{
    public static class InversifyConfig
    {
        public static IServiceCollection AddCompositionRoot(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<PersonaRepository, PersonaRepository>();
            services.AddScoped<DepartamentoRepository, DepartamentoRepository>();

            services.AddScoped<IPersonaUseCases, PersonaUseCases>();
            services.AddScoped<IDepartamentoUseCases, DepartamentoUseCases>();

            return services;
        }
    }
}