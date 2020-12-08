using ControleEstoque.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
