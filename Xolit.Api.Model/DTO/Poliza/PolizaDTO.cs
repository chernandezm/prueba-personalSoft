using System;
using System.Collections.Generic;
using System.Text;

namespace Xolit.Api.Model.DTO.Poliza
{
    public class PolizaDTO
    {
        //public int Id_poliza { get; set; }
        public string NombreCliente { get; set; }
        public string IdCliente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaAdPoliza { get; set; }
        public string Coberturas { get; set; }
        public double ValorMaxPoliza { get; set; }
        public string NombrePlan { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Placa { get; set; }
        public int Modelo { get; set; }
        public bool TieneInspeccion { get; set;}
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
