using System;
using System.Linq;
using System.Reflection;
using System.Text;
using AcmeGames.Data;
using AcmeGames.Filters;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AcmeGames.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAcmeGamesLogging(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddLogging(builder =>
            {
                builder.AddConsole();
            });
        }

        public static IServiceCollection AddAcmeGamesAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    var signatureKey = configuration["JWTKey"];
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "localhost:56653",
                        ValidAudience = "localhost:56653",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signatureKey))
                    };
                });
            return serviceCollection;
        }

        public static IServiceCollection AddAcmeGamesAutoMapper(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddAcmeGamesMediatr(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddMediatR(AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.GetName().Name.StartsWith("AcmeGames"))
                .ToArray());
        }
        
        public static IServiceCollection AddAcmeGamesSwagger(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSwaggerDocument(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "AcmeGames API";
                };
            });
        }
        
        public static IServiceCollection AddAcmeGamesMvc(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvc(options => { options.Filters.Add(typeof(ExceptionFilter), 0); });
            return serviceCollection;
        }
        
        public static IServiceCollection AddAcmeGamesDatabase(this IServiceCollection serviceCollection)
        {
            // Add database here as singleton to store in-memory data across requests 
            return serviceCollection.AddSingleton<Database>();
        }
    }
}