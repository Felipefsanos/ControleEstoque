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

        public LoginCommand(string usuario, string senha)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(usuario.IsNullOrEmpty(), "Usuário deve ser informado.");
            ValidacaoLogica.IsTrue<ValidacaoException>(senha.IsNullOrEmpty(), "Senha deve ser informada.");

            Login = usuario;
            Senha = senha;
        }
    }
}
