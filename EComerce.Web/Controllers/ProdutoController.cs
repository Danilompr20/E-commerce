using EComerce.Dominios.Contratos;
using EComerce.Dominios.Entidades;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EComerce.Web.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;
        
        public ProdutoController(IProdutoRepositorio produtoRepositorio, 
            IHttpContextAccessor httpContextAccessor, IHostingEnvironment hostingEnvironment)
        {
            _produtoRepositorio = produtoRepositorio;
            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Json(_produtoRepositorio.ObterTodos());
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Produto produto)
        {
            try
            {
                produto.Validate();
                if (!produto.EhValido)
                {
                    
                    return BadRequest(produto.ObterMesnsagensValidacao());
                }
                
                _produtoRepositorio.Adicionar(produto);
                return Created("api/produto",produto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
        [HttpPost("EnviarArquivo")]
        public IActionResult EnviarArquivo()
        {
            try
            {
                //pega o arquivo enviado pelo metodo no angular usando a mesma chave
                var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["arquivoEnviado"];
                 
                //nome do aruivo
                var nomeArquivo = formFile.FileName;
                //separa em array para obter a extensão do arquivo
                var extensao = nomeArquivo.Split('.').Last();
                // usando o path para pegar o nome do arquivo sem a extensão Take define a quantidade de caracter que eu quero 
                //pegar do nome do arquivo e tranformar em um array
                var arrayNomeCompacto = Path.GetFileNameWithoutExtension(nomeArquivo).Take(10).ToArray();

                //pega o array tranformo em string novamente faz o replace para substituir espaço por - 
                var novoNomeArquivo = new string(arrayNomeCompacto).Replace(" ", "-");
                novoNomeArquivo =$"{novoNomeArquivo}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}" +
                    $"{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extensao}";
                //achando o caminho da pasta wwwroot
                var pastaArquivos =_hostingEnvironment.WebRootPath + "\\arquivos\\";
                //pasta onde eu quero por o arquivo mais o nome do arquivo
                var nomeCompleto = pastaArquivos + novoNomeArquivo;
                

                // formFile contem o arquivo que veio do angular, pego o arquivo e copio para o streamArquivo que é uma instancia
                //de FileStream que por sua vez aponta para o caminho onde o arquivo de ve ser salvo
                using (var streamArquivo = new FileStream(nomeCompleto,FileMode.Create))
                {
                    formFile.CopyTo(streamArquivo);
                }

                // retorna  o nome do arquivo para o angular
                return Json(nomeCompleto);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.ToString());
            }
        }
    }
}
