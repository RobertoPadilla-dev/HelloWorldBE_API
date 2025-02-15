using Microsoft.AspNetCore.Mvc;
using System;

namespace HelloWorldBE_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMensaje()
        {
            var mensaje = new
            {
                texto = "Hola Mundo",
                fechaHora = DateTime.Now 
            };

            return Ok(mensaje);
        }
    }
}
