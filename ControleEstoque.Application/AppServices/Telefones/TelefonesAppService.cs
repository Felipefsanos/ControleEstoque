using ControleEstoque.Application.AppServices.Interfaces.Telefones;
using ControleEstoque.Domain.Commands.Telefones;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories.Clientes;
using ControleEstoque.Domain.UnitOfWork;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Application.AppServices.Telefones
{
    public class TelefonesAppService : ITelefonesAppService
    {
        private readonly IClientesRepository clientesRepository;
        private readonly IUnitOfWork unitOfWork;

        public TelefonesAppService(IClientesRepository clientesRepository, IUnitOfWork unitOfWork)
        {
            this.clientesRepository = clientesRepository;
            this.unitOfWork = unitOfWork;
        }

        public void AdicionarTelefone(decimal cpfCliente, CriarTelefoneCommand criarTelefoneCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(criarTelefoneCommand is null, "Comando de alteração de telefone não pode ser nulo.");

            var cliente = clientesRepository.ObterUm(x => x.Cpf == cpfCliente);

            ValidacaoLogica.IsTrue<ValidacaoException>(cliente is null, "Cliente não encontrado.");

            if (cliente.Telefones is null)
                cliente.Telefones = new List<Telefone>();

            cliente.Telefones.Add(new Telefone(criarTelefoneCommand));

            clientesRepository.Atualizar(cliente);

            unitOfWork.SaveChanges();
        }
    }
}
