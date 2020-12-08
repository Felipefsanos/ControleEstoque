using System;
using System.ComponentModel.DataAnnotations;

namespace ControleEstoque.Domain.Entities.Base
{
    public class EntidadeBase
    {
        [Key]
        public long Id { get; set; }
    }
}
