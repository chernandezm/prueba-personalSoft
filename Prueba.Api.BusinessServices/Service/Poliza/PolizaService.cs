using Prueba.Api.Model.DTO.Poliza;
using Prueba.Api.Model.DTO.ResponseServices;
using Prueba.Api.Services.Invoker.Poliza;
using Prueba.Api.Services.Service.Poliza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.BusinessServices.Service.Poliza
{
    public class PolizaService : IPolizaService
    {
        private readonly ICreatePolizaInvoker _polizaInvoker;
        private readonly IGetPolizaInvoker getPolizaInvoker;

        public PolizaService(ICreatePolizaInvoker polizaInvoker, IGetPolizaInvoker getPolizaInvoker)
        {
            _polizaInvoker = polizaInvoker;
            this.getPolizaInvoker = getPolizaInvoker;
        }

        public async Task<ResponseServices<PolizaDTO>> GetPoliza(string placa)
        {
            return await getPolizaInvoker.Execute(placa);
        }

        public async Task<ResponseServices<bool>> SavePoliza(PolizaDTO polizaDTO)
        {
            return await _polizaInvoker.Execute(polizaDTO);
        }
    }
}
