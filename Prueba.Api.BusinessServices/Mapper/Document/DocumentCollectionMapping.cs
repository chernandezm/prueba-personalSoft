using Prueba.Api.Services.Mapper;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Prueba.Api.BusinessServices.Mapper.Document
{
    public class DocumentCollectionMapping : IDocumentCollectionMapping
    {
        private readonly IDictionary<Type, string> Mappings;
        public DocumentCollectionMapping()
        {
            this.Mappings = new ConcurrentDictionary<Type, string>();
        }

        public void RegisterMapping(Type type, string collection)
        {
            if (this.Mappings.TryGetValue(type, out string collectionName))
                throw new Exception($"{collection} is already mapped");

            this.Mappings.Add(type, collection);
        }

        public string Resolve<TDoc>() where TDoc : class
        {
            var type = typeof(TDoc);
            if (this.Mappings.TryGetValue(type, out string value)) return value;

            throw new ArgumentException($"Type: {type.Name} is not mapped");
        }

        public string Resolve(Type docType)
        {
            if (this.Mappings.TryGetValue(docType, out string value)) return value;

            throw new ArgumentException($"Type: {docType.Name} is not mapped");
        }
    }
}
