using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Api.Repository.Mongo
{
    public class PolizaDoc
    {
        public ObjectId Id_poliza { get; set; }
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
        public bool TieneInspeccion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
