using ControleEstoque.Application.AppServices.Interfaces.Clientes;
using ControleEstoque.Domain.Commands.Clientes;
using ControleEstoque.Domain.Repositories.Clientes;
using ControleEstoque.Domain.UnitOfWork;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;

namespace ControleEstoque.Application.AppServices.Clientes
{
    public class ClientesAppService : IClientesAppService
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IUnitOfWork unitOfWork;

        public ClientesAppService(IClientesRepository clientesRepository, IUnitOfWork unitOfWork)
        {
            this.clientesRepository = clientesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CriarCliente(CriarClienteCommand criarClienteCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(criarClienteCommand is null, "Comando de criar cliente não pode ser nulo.");

            var cliente = clientesRepository.ObterUm(x => x.Cpf == criarClienteCommand.Cpf);

            ValidacaoLogica.IsFalse<ValidacaoException>(cliente is null, "Já existe um cliente para esse CPF.");

            cliente = new Domain.Entities.Cliente(criarClienteCommand);

            clientesRepository.Adicionar(cliente);

            unitOfWork.SaveChanges();
        }

        public void EditarCliente(EditarClienteCommand editarClienteCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(editarClienteCommand is null, "Comando de editar cliente não pode ser nulo.");

            var cliente = clientesRepository.ObterUm(x => x.Id == editarClienteCommand.Id);

            ValidacaoLogica.IsTrue<ValidacaoException>(cliente is null, "Só é possível editar informações de clientes previamente cadastrados.");

            cliente.Editar(editarClienteCommand);

            clientesRepository.Atualizar(cliente);

            unitOfWork.SaveChanges();
        }
    }
}
