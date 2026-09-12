using StarWars_Cyclopedia.Domain.Interfaces;
using StarWars_Cyclopedia.Infrastructure.Services;

namespace StarWars_Cyclopedia.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICharactersReader, CharactersReader>();
            return services;
        }
    }
}