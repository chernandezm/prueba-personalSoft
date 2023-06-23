using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.DTO.Poliza;
using Xolit.Api.Model.DTO.ResponseServices;
using Xolit.Api.Model.Util.Response;
using Xolit.Api.Services.Command.Poliza;
using Xolit.Api.Services.Invoker.Poliza;

namespace Xolit.Api.BusinessServices.Invoker.Poliza
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
