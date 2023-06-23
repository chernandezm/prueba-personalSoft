using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Xolit.Api.Config;
using Xolit.Api.Extensions;
using Xolit.Configuration.Core.Extensions;

namespace Xolit.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string connectionString { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            this.connectionString = this.Configuration.GetConnectionString(ConfigurationWebApi.ConnectionStringDefault);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.ConfigureSwagger();
            services.ConfigureAuthentication(this.Configuration);
            services.ConfigureDependencyInjection();
            services.ConfigureCors();
            services.AddSignalR();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Xolit.Api v1");
                    config.DefaultModelsExpandDepth(ConfigurationWebApi.ShowModelSwagger);
                    config.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseCors(ConfigurationWebApi.OriginCors);
            app.UseErrorHanldinMiddleware();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
