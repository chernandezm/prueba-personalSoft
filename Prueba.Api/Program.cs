using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Xolit.Api;
using Xolit.Configuration.Core.Configuracion;

namespace Prueba.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Log.Logger = InicializarConfiguracionSerilog.ConfiguracionSerilog().CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
