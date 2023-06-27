using Microsoft.VisualBasic;
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
    public class CreatePolizaCommand : ICreatePolizaCommand
    {
        private readonly IRepositoryGenericMongo<PolizaDoc> _repositoryGeneric;
        private readonly IMapper<PolizaDTO, PolizaDoc> mapper;

        public CreatePolizaCommand(IRepositoryGenericMongo<PolizaDoc> repositoryGeneric, IMapper<PolizaDTO, PolizaDoc> mapper)
        {
            _repositoryGeneric = repositoryGeneric;
            this.mapper = mapper;
        }

        public async Task Execute(PolizaDTO poliza)
        {
            var polizaDoc = this.mapper.MapFrom(poliza);
            _repositoryGeneric.Get(CollectionMongo.Polizas);
            await _repositoryGeneric.InsertAsync(polizaDoc);
        }
    }
}
