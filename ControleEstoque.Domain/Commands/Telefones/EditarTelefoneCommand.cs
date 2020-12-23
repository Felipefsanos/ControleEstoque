using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Commands.Telefones
{
    public class EditarTelefoneCommand
    {
        public long Id { get; set; }
        public decimal Cpf { get; set; }
        public int DDD { get; set; }
        public long Numero { get; set; }
    }
}
