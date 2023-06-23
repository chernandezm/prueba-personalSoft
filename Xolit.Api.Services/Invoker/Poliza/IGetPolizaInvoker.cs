using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.DTO.Poliza;
using Xolit.Api.Model.DTO.ResponseServices;

namespace Xolit.Api.Services.Invoker.Poliza
{
    public interface IGetPolizaInvoker
    {
        Task<ResponseServices<PolizaDTO>> Execute(string placa);
    }
}
