using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EComerce.Dominios.Contratos;
using EComerce.Dominios.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EComerce.Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private  readonly IPedidoRepositorio _pedidoRepositorio;
        // interface faz referencia ao pedidoRepositorio
        public PedidoController(IPedidoRepositorio pedidoRepositorio)
        {
            // passa para a variavel o atributo recebido por injeção de dependecia
            _pedidoRepositorio = pedidoRepositorio;
        }
        [HttpPost]
        public IActionResult Post([FromBody]Pedido pedido)
        {
            try
            {
                _pedidoRepositorio.Adicionar(pedido);
                return Ok(pedido.PedidoId);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
                
            }
        }
    }
}