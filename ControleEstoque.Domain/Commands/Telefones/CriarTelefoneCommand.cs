using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Commands.Telefones
{
    public class CriarTelefoneCommand
    {
        public int DDD { get; set; }
        public long Numero { get; set; }
    }
}
