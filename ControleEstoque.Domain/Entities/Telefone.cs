using ControleEstoque.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Entities
{
    public class Telefone : EntidadeBase
    {
        public int DDD { get; set; }
        public long Numero { get; set; }
    }
}
