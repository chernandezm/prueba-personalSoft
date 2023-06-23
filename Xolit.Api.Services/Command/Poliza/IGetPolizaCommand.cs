using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.DTO.Poliza;

namespace Xolit.Api.Services.Command.Poliza
{
    public interface IGetPolizaCommand
    {
        Task<PolizaDTO> Execute(string placa);
    }
}
