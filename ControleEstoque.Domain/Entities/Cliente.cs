using ControleEstoque.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Entities
{
    public class Cliente : EntidadeBase
    {
        public decimal Cpf { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}
