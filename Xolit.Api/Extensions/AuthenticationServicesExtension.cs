using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Xolit.Api.Config;

namespace Xolit.Api.Extensions
{
    public static class AuthenticationServicesExtension
    {
        public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            IConfigurationSection configuracionFocos = configuration.GetSection(ConfigurationWebApi.AuthenticationSecretToken);
            string sectretsForToken = configuracionFocos.GetSection("Secrect").Value;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(option =>
                                option.TokenValidationParameters = new TokenValidationParameters
                                {
                                    ValidateIssuerSigningKey = true,
                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sectretsForToken)),
                                    ValidateIssuer = false,
                                    ValidateAudience = false,
                                });
        }
    }
}
