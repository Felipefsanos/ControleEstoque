using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Application.Datas
{
    public class ClienteData
    {
        public long Id { get; set; }
        public decimal Cpf { get; set; }
        public string Nome { get; set; }
        public virtual IEnumerable<TelefoneData> Telefones { get; set; }
    }
}
