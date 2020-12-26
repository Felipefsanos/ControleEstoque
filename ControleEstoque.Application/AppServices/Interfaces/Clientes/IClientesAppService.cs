using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Clientes;
using System.Collections.Generic;

namespace ControleEstoque.Application.AppServices.Interfaces.Clientes
{
    public interface IClientesAppService
    {
        void CriarCliente(CriarClienteCommand criarClienteCommand);
        void EditarCliente(EditarClienteCommand editarClienteCommand);
        void RemoverCliente(long id);
        IEnumerable<ClienteData> ObterTodosClientes();
        ClienteData ObterCliente(decimal cpf);
    }
}
