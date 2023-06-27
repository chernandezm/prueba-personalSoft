using Prueba.Api.Model.DTO.Poliza;
using Prueba.Api.Model.DTO.ResponseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Services.Service.Poliza
{
    public interface IPolizaService
    {
        Task<ResponseServices<bool>> SavePoliza(PolizaDTO polizaDTO);
        Task<ResponseServices<PolizaDTO>> GetPoliza(string placa);
    }
}
