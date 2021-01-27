using ControleEstoque.Domain.Commands.Enderecos;
using ControleEstoque.Domain.Entities.Base;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Domain.Entities
{
    public class Endereco : EntidadeBase
    {
        public long CEP { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco()
        {

        }

        public Endereco(CriarEnderecoCommand endereco)
        {
            ValidarPropriedades(endereco);

            CEP = endereco.CEP;
            Logradouro = endereco.Logradouro;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
            Bairro = endereco.Bairro;
            Cidade = endereco.Cidade;
            Estado = endereco.Estado;
        }

        private void ValidarPropriedades(CriarEnderecoCommand endereco)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.CEP <= 0, "Número do CEP inválido.");
            ValidacaoLogica.IsTrue<ValidacaoException>(endereco.Numero < 0, "Número da residência inválido.");
        }
    }
}
