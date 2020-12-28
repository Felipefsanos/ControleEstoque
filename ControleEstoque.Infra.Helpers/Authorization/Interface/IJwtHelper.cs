using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ControleEstoque.Infra.Helpers.Authorization.Interface
{
    public interface IJwtHelper
    {
        JwtSecurityToken GerarTokenAcesso(string nomeCompleto, decimal cpf, dynamic roles);
    }
}
