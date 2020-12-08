using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    [Route("api/teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly ControleEstoqueContext controleEstoqueContext;

        public TesteController(ControleEstoqueContext controleEstoqueContext)
        {
            this.controleEstoqueContext = controleEstoqueContext;
        }

        [HttpGet("database")]
        public IActionResult TestarConexaoBancoDados()
        {
            try
            {
                controleEstoqueContext.Database.BeginTransaction();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

            return Ok(new { acessível = controleEstoqueContext.Database.CanConnect(), providerName = controleEstoqueContext.Database.ProviderName });
        }
    }
}
