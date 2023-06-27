using Prueba.Api.Model.DTO.Poliza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Services.Command.Poliza
{
    public interface IGetPolizaCommand
    {
        Task<PolizaDTO> Execute(string placa);
    }
}
