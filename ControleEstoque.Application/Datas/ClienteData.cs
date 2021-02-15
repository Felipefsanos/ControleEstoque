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
        public string Email { get; set; }
        public ICollection<TelefoneData> Telefones { get; set; }
        public EnderecoData Endereco { get; set; }
    }
}
