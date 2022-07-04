using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreguntasRespuestas.Domain.IServices;
using PreguntasRespuestas.Domain.Models;
using PreguntasRespuestas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            try
            {
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                var user = await _loginServices.ValidateUser(usuario);
                if(user == null)
                {
                    return BadRequest(new { message = "Usuario o contrasenia invalidos" });
                }
                return Ok(new { usuario= user.NombreUsuario });
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
