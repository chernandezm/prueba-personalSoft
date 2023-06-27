using Prueba.Api.Model.DTO.Poliza;
using Prueba.Api.Model.DTO.ResponseServices;
using Prueba.Api.Services.Command.Poliza;
using Prueba.Api.Services.Invoker.Poliza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.Util.Response;

namespace Prueba.Api.BusinessServices.Invoker.Poliza
{
    public class GetPolizaInvoker : IGetPolizaInvoker
    {
        private readonly IGetPolizaCommand getPolizaCommand;

        public GetPolizaInvoker(IGetPolizaCommand getPolizaCommand) 
        {
            this.getPolizaCommand = getPolizaCommand;
        }
        public async Task<ResponseServices<PolizaDTO>> Execute(string placa)
        {
            return ResponseStatus.ResponseSucessful(await this.getPolizaCommand.Execute(placa));
        }
    }
}
