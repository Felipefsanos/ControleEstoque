using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Application.AppServices.Interfaces.Clientes;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Clientes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    [Authorize]
    public class ClientesController : ControllerBase
    {
        private readonly IClientesAppService clientesAppService;

        public ClientesController(IClientesAppService clientesAppService)
        {
            this.clientesAppService = clientesAppService;
        }

        [HttpPost]
        public void CriarCliente(CriarClienteCommand criarClienteCommand)
        {
            clientesAppService.CriarCliente(criarClienteCommand);
        }

        [HttpPut("{id}")]
        public void EditarCliente(long id, EditarClienteCommand editarClienteCommand)
        {
            editarClienteCommand.Id = id;
            clientesAppService.EditarCliente(editarClienteCommand);
        }

        [HttpDelete("{id}")]
        public void RemoverCliente(long id)
        {
            clientesAppService.RemoverCliente(id);
        }

        [HttpGet]
        public IEnumerable<ClienteData> ObterClientes()
        {
            return clientesAppService.ObterTodosClientes();
        }

        [HttpGet("{cpf}")]
        public ClienteData ObterCliente(decimal cpf)
        {
            return clientesAppService.ObterCliente(cpf);
        }
    }
}
