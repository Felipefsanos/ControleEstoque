using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ExtensionsMethods;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Commands.Login
{
    public class LoginCommand
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(Login.IsNullOrEmpty(), "Usuário deve ser informado.");
            ValidacaoLogica.IsTrue<ValidacaoException>(Senha.IsNullOrEmpty(), "Senha deve ser informada.");
        }
    }
}
