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
        // recebe os dados do usuario  enviados pelo angular no [FromBody]
        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario )
        {
            try
            {
                //verifica se o email do usuario ao se cadastrar ja esxite na base de dados
                var  usuarioCadastrado = _usuarioRepositorio.Obter(usuario.Email);
                if (usuarioCadastrado!=null)
                {
                    return BadRequest("E-mail já cadastrado no sistema");

                }
                // caso não exita o email no banco ele cadastrada o usuario recebido por parametro no [fromBody]
                _usuarioRepositorio.Adicionar(usuario);
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
                // ao logar verifica se o usuario digitado se encontra cadastrado no banco 
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
