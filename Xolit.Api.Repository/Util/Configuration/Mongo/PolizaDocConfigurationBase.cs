using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using Xolit.Api.Repository.Constants;
using Xolit.Api.Repository.Mongo;

namespace Xolit.Api.Repository.Util.Configuration.Mongo
{
    public class PolizaDocConfigurationBase : DocumentConfigurationBase<PolizaDoc>
    {
        public override string CollectionName => CollectionMongo.Polizas;

        protected override void Map(BsonClassMap<PolizaDoc> mapper)
        {
            mapper.AutoMap();
            mapper.MapIdMember(c => c.Id_poliza).SetIdGenerator(ObjectIdGenerator.Instance);
        }
    }
}