using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Produtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {

        [HttpPost]
        public void CriarProduto(CriarProdutoCommand criarProdutoCommand)
        {
        }

        [HttpPut("{id}")]
        public void EditarProduto(long id, EditarProdutoCommand editarProdutoCommand)
        {
            
        }

        [HttpDelete("{id}")]
        public void RemoverProduto(long id)
        {
        }

        [HttpGet]
        public IEnumerable<ProdutoData> ObterProdutos()
        {
            return null;
        }

        [HttpGet("{id}")]
        public ProdutoData ObterProduto(long id)
        {
            return null;
        }
    }
}
