using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.DTO.Poliza;
using Xolit.Api.Model.DTO.ResponseServices;

namespace Xolit.Api.Services.Service.Poliza
{
    public interface IPolizaService
    {
        Task<ResponseServices<bool>> SavePoliza(PolizaDTO polizaDTO);
        Task<ResponseServices<PolizaDTO>> GetPoliza(string placa);
    }
}
