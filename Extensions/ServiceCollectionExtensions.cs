using AcmeGames.Data;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeGames.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            // Add database here as singleton to store in-memory data across requests 
            return serviceCollection.AddSingleton<Database>();
        }
    }
}