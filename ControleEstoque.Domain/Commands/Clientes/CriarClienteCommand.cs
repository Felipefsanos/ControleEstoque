using ControleEstoque.Domain.Commands.Enderecos;
using ControleEstoque.Domain.Commands.Telefones;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Commands.Clientes
{
    public class CriarClienteCommand
    {
        public decimal Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IEnumerable<CriarTelefoneCommand> Telefones { get; set; }
        public CriarEnderecoCommand Endereco { get; set; }
    }
}
