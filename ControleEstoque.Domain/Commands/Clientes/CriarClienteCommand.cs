using ControleEstoque.Domain.Commands.Telefones;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Commands.Clientes
{
    public class CriarClienteCommand
    {
        public decimal Cpf { get; set; }
        public string Nome { get; set; }
        public IEnumerable<CriarTelefoneCommand> Telefones { get; set; }
    }
}
