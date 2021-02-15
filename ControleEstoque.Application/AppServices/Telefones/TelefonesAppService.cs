using ControleEstoque.Application.AppServices.Interfaces.Telefones;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Telefones;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories.Clientes;
using ControleEstoque.Domain.Repositories.Telefones;
using ControleEstoque.Domain.UnitOfWork;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System.Collections.Generic;
using System.Linq;

namespace ControleEstoque.Application.AppServices.Telefones
{
    public class TelefonesAppService : ITelefonesAppService
    {
        private readonly IClientesRepository clientesRepository;
        private readonly ITelefonesRepository telefonesRepository;
        private readonly IUnitOfWork unitOfWork;

        public TelefonesAppService(IClientesRepository clientesRepository, IUnitOfWork unitOfWork, ITelefonesRepository telefonesRepository)
        {
            this.clientesRepository = clientesRepository;
            this.unitOfWork = unitOfWork;
            this.telefonesRepository = telefonesRepository;
        }

        public void AdicionarTelefone(decimal cpfCliente, CriarTelefoneCommand criarTelefoneCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(criarTelefoneCommand is null, "Comando de alteração de telefone não pode ser nulo.");

            var cliente = clientesRepository.ObterUm(x => x.Cpf == cpfCliente);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(cliente is null, "Cliente não encontrado.");

            if (cliente.Telefones is null)
                cliente.Telefones = new List<Telefone>();

            cliente.Telefones.Add(new Telefone(criarTelefoneCommand));

            clientesRepository.Atualizar(cliente);

            unitOfWork.SaveChanges();
        }

        public void EditarTelefone(EditarTelefoneCommand editarTelefoneCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(editarTelefoneCommand is null, "Comando de edição de telefone não pode ser nulo.");

            var cliente = clientesRepository.ObterUm(x => x.Cpf == editarTelefoneCommand.Cpf);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(cliente is null, "Cliente não encontrado.");

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(cliente.Telefones is null, "Este cliente não possui telefone cadastrado.");

            ValidacaoLogica.IsFalse<RecursoNaoEncontradoException>(cliente.Telefones.Any(x => x.Id == editarTelefoneCommand.Id), 
                                                                                    "Só é possível editar um telefone existente para esse cliente.");

            ValidacaoLogica.IsTrue<ValidacaoException>(cliente.Telefones.Any(x => editarTelefoneCommand.DDD == x.DDD 
                                                                            && editarTelefoneCommand.Numero == x.Numero), 
                                                                            "Esse número já está cadastrado para esse cliente.");

            cliente.Telefones.FirstOrDefault(x => x.Id == editarTelefoneCommand.Id).Editar(editarTelefoneCommand);

            clientesRepository.Atualizar(cliente);

            unitOfWork.SaveChanges();
        }

        public IEnumerable<TelefoneData> ObterTelefonesCliente(decimal cpf)
        {
            throw new System.NotImplementedException();
        }

        //public IEnumerable<TelefoneData> ObterTelefonesCliente(decimal cpf)
        //{
        //    var cliente = clientesRepository.ObterUm(x => x.Cpf == cpf);

        //    ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(cliente is null, "Cliente não encontrado.");

        //    var telefones = cliente.Telefones;

        //    return mapper.Map<IEnumerable<TelefoneData>>(telefones);
        //}

        public void RemoverTelefone(long id)
        {
            var telefone = telefonesRepository.ObterUm(x => x.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(telefone is null, "Telefone não encontrado.");

            telefonesRepository.Remover(telefone);

            unitOfWork.SaveChanges();
        }
    }
}
