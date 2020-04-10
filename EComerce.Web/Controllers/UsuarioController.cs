using EComerce.Dominios.Contratos;
using EComerce.Dominios.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EComerce.Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UsuarioController : Controller


    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }

        [HttpPost]
        public IActionResult Post()
        {
            try
            {
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }

        [HttpPost("VerificarUsuario")]
        public IActionResult VerificarUsuario([FromBody]Usuario usuario)
        {
            try
            {
                var usuarioRetorno = _usuarioRepositorio.Obter(usuario.Email, usuario.Senha);
                if (usuarioRetorno != null)
                {
                    // retorna um Json para o angular
                    return Ok(usuarioRetorno);
                }
                return BadRequest("Usuário ou senha  inválidos ");

            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }

        }
    }
}
