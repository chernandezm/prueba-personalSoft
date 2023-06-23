using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xolit.Api.Model.DTO.Poliza;
using Xolit.Api.Repository.Mongo;

namespace Xolit.Api.Services.Command.Poliza
{
    public interface ICreatePolizaCommand
    {
        Task Execute(PolizaDTO poliza);
    }
}
