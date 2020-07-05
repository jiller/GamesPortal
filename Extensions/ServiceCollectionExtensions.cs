using AcmeGames.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeGames.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<Database>();
        }
    }
}