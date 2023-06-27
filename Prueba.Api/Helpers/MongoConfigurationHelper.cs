using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Prueba.Api.BusinessServices.Mapper.Document;
using Prueba.Api.Repository.Util.Configuration.Mongo;
using Prueba.Api.Services.Mapper;

namespace Prueba.Api.Helpers
{
    public class MongoConfigurationHelper
    {
        public IDocumentCollectionMapping DocumentCollectionMapping { get; set; }

        private ICollection<Assembly> Assemblies { get; set; }
        public MongoConfigurationHelper()
        {
            DocumentCollectionMapping = new DocumentCollectionMapping();
            Assemblies = new HashSet<Assembly>();
        }

        public MongoConfigurationHelper IncludeAssembly(Assembly assembly)
        {
            Assemblies.Add(assembly);
            return this;
        }

        public void RegisterMappings()
        {
            foreach (var assemblyData in Assemblies)
            {
                var mappingConfigurations = assemblyData
                    .GetTypes()
                    .Where(t => t.IsClass && !t.IsAbstract && t.BaseType != null && IsType(t.BaseType) && !t.ContainsGenericParameters)
                    .ToList();

                foreach (var configuration in mappingConfigurations)
                {
                    var collectionName = configuration.GetProperty("CollectionName");
                    var configureMethod = configuration.GetMethod("Configure");
                    var configurationInstace = Activator.CreateInstance(configuration);
                    configureMethod.Invoke(configurationInstace, null);
                    Type documentType = configuration.BaseType.GetGenericArguments()[0];

                    DocumentCollectionMapping.RegisterMapping(documentType, collectionName.GetValue(configurationInstace).ToString());
                }
            }

            bool IsType(Type type)
            {
                return type.IsGenericType && type.GetGenericTypeDefinition().IsAssignableFrom(typeof(DocumentConfigurationBase<>));
            }
        }
    }
}
