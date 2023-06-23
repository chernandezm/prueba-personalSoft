using Microsoft.AspNetCore.Mvc;
using Xolit.Api.Services.Service;

namespace Xolit.Api.Controllers
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
            return Ok(this.authenticationService.GetToken());
        }
    }
}
