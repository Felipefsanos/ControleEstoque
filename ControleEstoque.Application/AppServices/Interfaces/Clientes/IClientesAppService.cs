using ControleEstoque.Domain.Commands.Clientes;

namespace ControleEstoque.Application.AppServices.Interfaces.Clientes
{
    public interface IClientesAppService
    {
        void CriarCliente(CriarClienteCommand criarClienteCommand);
        void EditarCliente(EditarClienteCommand editarClienteCommand);
    }
}
