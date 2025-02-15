using HelloWorldBE_API.Data;
using HelloWorldBE_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HelloWorldBE_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        private readonly ApplicationDb _context;

        public HelloWorldController(ApplicationDb context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMensaje()
        {
            var mensaje = await _context.Mensajes.OrderByDescending(m => m.FechaHora).FirstOrDefaultAsync();

            if (mensaje == null)
            {
                mensaje = new Mensaje //Realiza el primer insert
                {
                    Texto = "Hola Mundo",
                    FechaHora = DateTime.Now
                };

                _context.Mensajes.Add(mensaje);
            }
            else
            {
                //Actualiza
                mensaje.FechaHora = DateTime.Now;
                _context.Mensajes.Update(mensaje);
            }

            await _context.SaveChangesAsync();

            return Ok(mensaje);
        }
    }
}
