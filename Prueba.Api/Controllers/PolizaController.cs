﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Api.Model.DTO.Poliza;
using Prueba.Api.Services.Service.Poliza;
using System.Threading.Tasks;

namespace Prueba.Api.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    [Authorize]
    public class PolizaController : ControllerBase
    {
        private readonly IPolizaService _polizaService;

        public PolizaController(IPolizaService polizaService)
        {
            _polizaService = polizaService;
        }

        [HttpPost]
        [Route("SavePoliza")]
        public async Task<IActionResult> SavePoliza([FromBody] PolizaDTO poliza)
        {
            return Ok(await _polizaService.SavePoliza(poliza));
        }

        [HttpGet]
        [Route("GetPoliza")]
        public async Task<IActionResult> GetPoliza(string placa)
        {
            return Ok(await _polizaService.GetPoliza(placa));
        }
    }
}
