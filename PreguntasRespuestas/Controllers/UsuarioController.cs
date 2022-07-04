using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreguntasRespuestas.Domain.IServices;
using PreguntasRespuestas.Domain.Models;
using PreguntasRespuestas.DTO;
using PreguntasRespuestas.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuarioController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var validateExistence = await _usuarioServices.ValidateExistence(usuario);
                if (validateExistence)
                {
                    return BadRequest(new { message = "Usuario " + usuario.NombreUsuario + " ya se encuentra registrado" });

                }
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);

                await _usuarioServices.SaveUser(usuario);
                return Ok(new { message = "Usuario registrado con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("CambiarPassword")]
        [HttpPut]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordDTO cambiarPassword)
        {
            try
            {
                int idUsuario = 3;
                string passwordEncriptado = Encriptar.EncriptarPassword(cambiarPassword.passwordAnterior);
                var usuario = await _usuarioServices.ValidatePassword(idUsuario, passwordEncriptado);
                if(usuario == null)
                {
                    return BadRequest(new { message = "La password es incorrecta" });
                }
                usuario.Password = Encriptar.EncriptarPassword(cambiarPassword.passwordNueva);
                await _usuarioServices.UpdatePassword(usuario);
                return Ok(new { message = "La password fue actualizada con exito" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
