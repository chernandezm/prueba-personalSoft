using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System;
using System.Reflection;
using Xolit.Api.Helpers;
using Xolit.Api.Repository.Entity;
using Xolit.Api.Repository.Mongo;
using Xolit.Api.Repository.Repository.Generic.Interface;
using Xolit.Api.Repository.Repository.Generic.Service;
using Xolit.Api.Services.Mapper;

namespace Xolit.Api.Extensions
{
    public static class SolveDependecyInjectionServicesExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositoryGenericMongo<>), typeof(RepositoryGenericMongo<>));
            
            Assembly assemblyServicesInterface = AppDomain.CurrentDomain.Load("Xolit.Api.Services");
            Assembly assemblyServicesImplementation = AppDomain.CurrentDomain.Load("Xolit.Api.BusinessServices");
            Assembly assemblyDataInterface = AppDomain.CurrentDomain.Load("Xolit.Api.Repository");
            Assembly assemblyDataImplementation = AppDomain.CurrentDomain.Load("Xolit.Api.Repository");

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
