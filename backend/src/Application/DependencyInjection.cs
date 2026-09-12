using StarWars_Cyclopedia.Application.Interfaces;
using StarWars_Cyclopedia.Application.UseCases.GetCharacters;
using StarWars_Cyclopedia.Infrastructure.Services;

namespace StarWars_Cyclopedia.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IHttpClientWrapper, HttpClientWrapper>();
            services.AddScoped<GetCharactersHandler>();
            return services;
        }
    }
}
