using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Commands.Clientes
{
    public class EditarClienteCommand
    {
        public long Id { get; set; }
        public string Nome { get; set; }
    }
}
