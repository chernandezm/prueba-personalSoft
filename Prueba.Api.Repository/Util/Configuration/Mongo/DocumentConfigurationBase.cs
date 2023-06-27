using MongoDB.Bson.Serialization;

namespace Prueba.Api.Repository.Util.Configuration.Mongo
{
    public abstract class DocumentConfigurationBase<TDoc> where TDoc : class
    {
        public abstract string CollectionName { get; }

        protected virtual void Map(BsonClassMap<TDoc> mapper)
        {
            mapper.AutoMap();
        }

        public virtual void Configure()
        {
            BsonClassMap.RegisterClassMap<TDoc>(m =>
            {
                Map(m);
            });
        }
    }
}
