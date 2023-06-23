using System;

namespace Xolit.Api.Services.Mapper
{
    public interface IDocumentCollectionMapping
    {
        void RegisterMapping(Type type, string collection);

        string Resolve<TDoc>() where TDoc : class;

        string Resolve(Type docType);
    }
}
