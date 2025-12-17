using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionRoot
{
    public static class InversifyConfig
    {
        public static IServiceCollection AddCompositionRoot(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPlantaRepository, PlantaRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IPlantaUseCases, PlantaUseCases>();
            services.AddScoped<ICategoriaUseCases, CategoriaUseCases>();


            return services;
        }
    }
}
