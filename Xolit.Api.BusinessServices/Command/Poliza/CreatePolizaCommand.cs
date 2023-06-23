using Microsoft.VisualBasic;
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
