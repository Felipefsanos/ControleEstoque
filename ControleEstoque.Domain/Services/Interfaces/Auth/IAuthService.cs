using ControleEstoque.Domain.Commands.Login;
using ControleEstoque.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        public AuthToken GerarToken(LoginCommand loginCommand);
    }
}
