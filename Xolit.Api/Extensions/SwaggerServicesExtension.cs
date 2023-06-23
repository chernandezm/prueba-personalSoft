using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Xolit.Api.Config;

namespace Xolit.Api.Extensions
{
    public static class SwaggerServicesExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(configuration =>
            {
                configuration.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v 1.0.0",
                    Title = "Administrado de conexión",
                    Description = "Aplicacion administración de conexión whatsapp"
                });
                configuration.AddSecurityDefinition(ConfigurationWebApi.AuthenticationTittle, new OpenApiSecurityScheme()
                {
                    Description = ConfigurationWebApi.DescriptionSwagger,
                    In = ParameterLocation.Header,
                    Name = ConfigurationWebApi.HeaderSwagger,
                    Type = SecuritySchemeType.ApiKey
                });
                configuration.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }
    }
}