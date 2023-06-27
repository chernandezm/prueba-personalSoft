using Microsoft.Extensions.DependencyInjection;
using Prueba.Api.Config;

namespace Xolit.Api.Extensions
{
    public static class CorsServicesExtension
    {
        public static void ConfigureCors(this IServiceCollection servicios)
        {
            //servicios.AddCors(options =>
            //{
            //    options.AddPolicy(name: ConfigurationWebApi.OriginCors,
            //        builder =>
            //        {
            //            builder.SetIsOriginAllowed(_ => true);
            //            builder.AllowAnyOrigin();
            //            builder.AllowAnyMethod();
            //            builder.AllowAnyHeader();
            //        });
            //});

            servicios.AddCors(options =>
            {
                options.AddPolicy(ConfigurationWebApi.OriginCors,
                    builder => builder.SetIsOriginAllowed(_ => true)
                     .WithMethods("GET", "POST")
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .AllowCredentials());
            });
        }
    }
}
