using ControleEstoque.Domain.Commands.Telefones;
using ControleEstoque.Domain.Entities.Base;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Entities
{
    public class Telefone : EntidadeBase
    {
        public int DDD { get; set; }
        public long Numero { get; set; }

        public Telefone()
        {

        }

        public Telefone(CriarTelefoneCommand telefone)
        {
            ValidacaoLogica.IsFalse<ValidacaoException>(telefone.DDD > 0 && telefone.DDD < 99, "DDD inválido.");
            ValidacaoLogica.IsFalse<ValidacaoException>(telefone.Numero.ToString().Length == 9 || telefone.Numero.ToString().Length == 8, "Número inválido, não reconhecido como celular e nem como fixo");

            DDD = telefone.DDD;
            Numero = telefone.Numero;
        }
    }
}
