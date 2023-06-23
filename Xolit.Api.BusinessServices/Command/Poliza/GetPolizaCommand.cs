using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.DTO.Poliza;
using Xolit.Api.Repository.Constants;
using Xolit.Api.Repository.Mongo;
using Xolit.Api.Repository.Repository.Generic.Interface;
using Xolit.Api.Services.Command.Poliza;
using Xolit.Api.Services.Mapper;

namespace Xolit.Api.BusinessServices.Command.Poliza
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
