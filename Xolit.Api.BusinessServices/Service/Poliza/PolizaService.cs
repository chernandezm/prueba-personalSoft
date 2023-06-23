using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.DTO.Poliza;
using Xolit.Api.Model.DTO.ResponseServices;
using Xolit.Api.Services.Invoker.Poliza;
using Xolit.Api.Services.Service.Poliza;

namespace Xolit.Api.BusinessServices.Service.Poliza
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
            return await this.getPolizaInvoker.Execute(placa);
        }

        public async Task<ResponseServices<bool>> SavePoliza(PolizaDTO polizaDTO)
        {
            return await _polizaInvoker.Execute(polizaDTO);
        }
    }
}
