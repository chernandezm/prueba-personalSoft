using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Reflection;
using Prueba.Api.Helpers;
using Prueba.Api.Repository.Repository.Generic.Interface;
using Prueba.Api.Repository.Repository.Generic.Service;
using Prueba.Api.Services.Mapper;

namespace Prueba.Api.Extensions
{
    public static class SolveDependecyInjectionServicesExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryGenericMongo<>), typeof(RepositoryGenericMongo<>));

            Assembly assemblyServicesInterface = AppDomain.CurrentDomain.Load("Prueba.Api.Services");
            Assembly assemblyServicesImplementation = AppDomain.CurrentDomain.Load("Prueba.Api.BusinessServices");
            Assembly assemblyDataInterface = AppDomain.CurrentDomain.Load("Prueba.Api.Repository");
            Assembly assemblyDataImplementation = AppDomain.CurrentDomain.Load("Prueba.Api.Repository");

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
                .Where(c => c.Name.EndsWith("Command"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
                .Where(c => c.Name.EndsWith("Invoker"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyServicesInterface, assemblyServicesImplementation })
                .Where(c => c.Name.EndsWith("Mapper"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDataInterface, assemblyDataImplementation })
                .Where(c => c.Name.Contains("QueryObject"))
                .AsPublicImplementedInterfaces();

            var mongoHelper = new MongoConfigurationHelper().IncludeAssembly(assemblyDataImplementation);
            mongoHelper.RegisterMappings();
            services.AddSingleton(typeof(IDocumentCollectionMapping), mongoHelper.DocumentCollectionMapping);
        }
    }
}
