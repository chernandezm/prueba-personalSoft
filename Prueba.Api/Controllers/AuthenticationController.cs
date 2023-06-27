using Microsoft.AspNetCore.Mvc;
using Prueba.Api.Services.Service;

namespace Prueba.Api.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }
        [HttpGet]
        [Route("GetToken")]
        public IActionResult RealizarInicioSesion()
        {
            return Ok(authenticationService.GetToken());
        }
    }
}
