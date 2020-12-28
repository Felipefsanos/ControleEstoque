using ControleEstoque.Domain.Commands.Login;
using ControleEstoque.Domain.Models.Auth;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Domain.Services.Interfaces.Auth;
using ControleEstoque.Infra.Helpers.Authorization.Interface;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ControleEstoque.Domain.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsuariosRepository usuariosRepository;
        private readonly IJwtHelper jwtHelper;

        public AuthService(IUsuariosRepository usuariosRepository, IJwtHelper jwtHelper)
        {
            this.usuariosRepository = usuariosRepository;
            this.jwtHelper = jwtHelper;
        }

        public AuthToken GerarToken(LoginCommand loginCommand)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(loginCommand is null, "Comando de login não pode ser nulo.");

            loginCommand.Validar();

            var usuario = usuariosRepository.ObterUm(x => x.Login == loginCommand.Login);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(usuario is null, "Usuário não encontrado.");

            ValidacaoLogica.IsTrue<NaoAutorizadoException>(usuario.Senha != loginCommand.Senha, "Senha incorrenta.");

            // TODO: Implementar as roles
            var token = jwtHelper.GerarTokenAcesso(usuario.Nome, usuario.Cpf, null);

            return new AuthToken() { DataExpiracao = token.ValidTo, Token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}
