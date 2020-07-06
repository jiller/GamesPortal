using AcmeGames.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AcmeGames
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration aConfiguration)
        {
            Configuration = aConfiguration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection aServiceCollection)
        {
            aServiceCollection
                .AddAcmeGamesLogging()
                .AddAcmeGamesDatabase()
                .AddAcmeGamesAuthentication(Configuration)
                .AddAcmeGamesAutoMapper()
                .AddAcmeGamesMediatr()
                .AddAcmeGamesSwagger()
                .AddAcmeGamesMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder aApplicationBuilder, IHostingEnvironment aHostingEnvironment)
        {
            if (aHostingEnvironment.IsDevelopment())
            {
                aApplicationBuilder.UseDeveloperExceptionPage();
            }

            aApplicationBuilder
                .UseDefaultFiles()
                .UseStaticFiles()
                .UseMvc();

            aApplicationBuilder.UseOpenApi();
            aApplicationBuilder.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "AcmeGames API"); });
        }
    }
}