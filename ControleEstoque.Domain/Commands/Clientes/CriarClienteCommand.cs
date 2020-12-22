using ControleEstoque.Domain.Commands.Telefones;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ExtensionsMethods;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Commands.Clientes
{
    public class CriarClienteCommand
    {
        public decimal Cpf { get; set; }
        public string Nome { get; set; }
        public IEnumerable<CriarTelefoneCommand> Telefones { get; set; }
    }
}
