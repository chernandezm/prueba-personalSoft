using MongoDB.Driver;
using Prueba.Api.Model.DTO.Poliza;
using Prueba.Api.Repository.Constants;
using Prueba.Api.Repository.Mongo;
using Prueba.Api.Repository.Repository.Generic.Interface;
using Prueba.Api.Services.Command.Poliza;
using Prueba.Api.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.BusinessServices.Command.Poliza
{
    public class GetPolizaCommand : IGetPolizaCommand
    {
        private readonly IRepositoryGenericMongo<PolizaDoc> repositoryGenericMongo;
        private readonly IMapper<PolizaDTO, PolizaDoc> mapper;

        public GetPolizaCommand(IRepositoryGenericMongo<PolizaDoc> repositoryGenericMongo, IMapper<PolizaDTO, PolizaDoc> mapper) 
        {
            this.repositoryGenericMongo = repositoryGenericMongo;
            this.mapper = mapper;
        }
        public async Task<PolizaDTO> Execute(string placa)
        {
            var filterDefinition = Builders<PolizaDoc>.Filter;
            var filter = filterDefinition.Eq(x => x.Placa, placa);
            this.repositoryGenericMongo.Get(CollectionMongo.Polizas);
            var messages = this.repositoryGenericMongo.FindBy(filter);
            return messages.Select(x => this.mapper.MapTo(x)).First();
        }
    }
}
