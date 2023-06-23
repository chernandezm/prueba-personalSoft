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
    public class CreatePolizaInvoker : ICreatePolizaInvoker
    {
        private readonly ICreatePolizaCommand _createPolizaCommand;

        public CreatePolizaInvoker(ICreatePolizaCommand createPolizaCommand)
        {
            _createPolizaCommand = createPolizaCommand;
        }

        public async Task<ResponseServices<bool>> Execute(PolizaDTO polizaDTO)
        {
            try
            {
                DateTime today = DateTime.Today;
                if (polizaDTO.FechaInicio > today && today < polizaDTO.FechaFin && polizaDTO.FechaInicio < polizaDTO.FechaFin)
                {
                    await _createPolizaCommand.Execute(polizaDTO);
                    return ResponseStatus.ResponseSucessful<bool>(true);
                }
                else
                {
                    return ResponseStatus.ResponseWithoutData<bool>("La fecha de la poliza no se encuentra vigente");
                }
            }
            catch (Exception)
            {
                return ResponseStatus.ResponseWithoutData<bool>("Error al crear la poliza");
            }
           
        }
    }
}
