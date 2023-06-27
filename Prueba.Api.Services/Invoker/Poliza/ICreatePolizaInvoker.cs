using Prueba.Api.Model.DTO.Poliza;
using Prueba.Api.Model.DTO.ResponseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Services.Invoker.Poliza
{
    public interface ICreatePolizaInvoker
    {
        Task<ResponseServices<bool>> Execute(PolizaDTO polizaDTO);
    }
}
