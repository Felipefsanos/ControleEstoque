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
        //public virtual Cliente Cliente { get; set; }

        public Telefone()
        {

        }

        public Telefone(CriarTelefoneCommand criarTelefoneCommand)
        {
            ValidarPropriedades(criarTelefoneCommand.DDD, criarTelefoneCommand.Numero);

            DDD = criarTelefoneCommand.DDD;
            Numero = criarTelefoneCommand.Numero;
        }

        public void Editar(EditarTelefoneCommand editarTelefoneCommand)
        {
            ValidarPropriedades(editarTelefoneCommand.DDD, editarTelefoneCommand.Numero);

            DDD = editarTelefoneCommand.DDD;
            Numero = editarTelefoneCommand.Numero;
        }

        private static void ValidarPropriedades(int DDD, long Numero)
        {
            ValidacaoLogica.IsFalse<ValidacaoException>(DDD > 0 && DDD < 99, "DDD inválido.");
            ValidacaoLogica.IsFalse<ValidacaoException>(Numero.ToString().Length == 9 || Numero.ToString().Length == 8, "Número inválido, não reconhecido como celular e nem como fixo");
        }

        
    }
}
