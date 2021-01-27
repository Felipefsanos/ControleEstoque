using ControleEstoque.Domain.Commands.Clientes;
using ControleEstoque.Domain.Entities.Base;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ExtensionsMethods;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Entities
{
    public class Cliente : EntidadeBase
    {
        public decimal Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public virtual Endereco Endereco { get; set; }

        public Cliente()
        {

        }

        public Cliente(CriarClienteCommand command)
        {
            ValidarParametros(command.Cpf, command.Nome);

            Cpf = command.Cpf;
            Nome = command.Nome;
            Email = command.Email;

            AdicionarTelefones(command);
            Endereco = new Endereco(command.Endereco);
        }

        private void AdicionarTelefones(CriarClienteCommand command)
        {
            var telefones = new List<Telefone>();

            if (command.Telefones is null)
            {
                Telefones = telefones;
                return;
            }

            foreach (var telefone in command.Telefones)
            {
                telefones.Add(new Telefone(telefone));
            }

            Telefones = telefones;
        }

        private void ValidarParametros(decimal cpf, string nome)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(cpf <= 0, "CPF informado é inválido.");
            ValidacaoLogica.IsTrue<ValidacaoException>(nome.IsNullOrWhiteSpace(), "Nome do cliente deve ser informado.");
        }

        public void Editar(EditarClienteCommand editarClienteCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(editarClienteCommand.Nome.IsNullOrWhiteSpace(), "Nome não pode ser nulo nem espaço em branco");

            Nome = editarClienteCommand.Nome;
            if (!editarClienteCommand.Email.IsNullOrWhiteSpace())
                Email = editarClienteCommand.Email;
        }
    }
}
