using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Application.AppServices.Interfaces.Telefones;
using ControleEstoque.Domain.Commands.Telefones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    [Route("api/telefones")]
    [ApiController]
    public class TelefonesController : ControllerBase
    {
        private readonly ITelefonesAppService telefonesAppService;

        public TelefonesController(ITelefonesAppService telefonesAppService)
        {
            this.telefonesAppService = telefonesAppService;
        }

        [HttpPost("{cpf}")]
        public void AdicionarTelefone(decimal cpf,  CriarTelefoneCommand criarTelefoneCommand)
        {
            telefonesAppService.AdicionarTelefone(cpf, criarTelefoneCommand);
        }

        //[HttpPut("{id}")]
        //public void EditarCliente(long id, EditarClienteCommand editarClienteCommand)
        //{
        //    editarClienteCommand.Id = id;
        //    clientesAppService.EditarCliente(editarClienteCommand);
        //}

        //[HttpDelete("{id}")]
        //public void RemoverCliente(long id)
        //{
        //}

        //[HttpGet]
        //public IEnumerable<ClienteData> ObterClientes()
        //{
        //    return null;
        //}

        //[HttpGet("{id}")]
        //public ClienteData ObterCliente(long id)
        //{
        //    return null;
        //}
    }
}
