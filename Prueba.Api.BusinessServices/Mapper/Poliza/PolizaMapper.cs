using Prueba.Api.Model.DTO.Poliza;
using Prueba.Api.Repository.Mongo;
using Prueba.Api.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.BusinessServices.Mapper.Poliza
{
    public class PolizaMapper : IMapper<PolizaDTO, PolizaDoc>
    {
        public PolizaDoc MapFrom(PolizaDTO model)
        {
            var poliza = new PolizaDoc();
            //poliza.Id_poliza = model.Id_poliza;
            poliza.NombreCliente = model.NombreCliente;
            poliza.NombrePlan = model.NombrePlan;
            poliza.ValorMaxPoliza = model.ValorMaxPoliza;
            poliza.Coberturas = model.Coberturas;
            poliza.IdCliente = model.IdCliente;
            poliza.Ciudad = model.Ciudad;
            poliza.Placa = model.Placa;
            poliza.Direccion = model.Direccion;
            poliza.TieneInspeccion = model.TieneInspeccion;
            poliza.FechaAdPoliza = model.FechaAdPoliza;
            poliza.FechaNacimiento = model.FechaNacimiento;
            poliza.FechaInicio = model.FechaInicio;
            poliza.FechaFin = model.FechaFin;
            return poliza;

        }

        public PolizaDTO MapTo(PolizaDoc model)
        {
            var poliza = new PolizaDTO();
            //poliza.Id_poliza = model.Id_poliza;
            poliza.NombreCliente = model.NombreCliente;
            poliza.NombrePlan = model.NombrePlan;
            poliza.ValorMaxPoliza = model.ValorMaxPoliza;
            poliza.Coberturas = model.Coberturas;
            poliza.IdCliente = model.IdCliente;
            poliza.Ciudad = model.Ciudad;
            poliza.Placa = model.Placa;
            poliza.Direccion = model.Direccion;
            poliza.TieneInspeccion = model.TieneInspeccion;
            poliza.FechaAdPoliza = model.FechaAdPoliza;
            poliza.FechaNacimiento = model.FechaNacimiento;
            poliza.FechaInicio = model.FechaInicio;
            poliza.FechaFin = model.FechaFin;
            return poliza;
        }
    }
}
