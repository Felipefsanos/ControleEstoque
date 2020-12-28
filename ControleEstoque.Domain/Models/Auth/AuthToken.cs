using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Models.Auth
{
    public class AuthToken
    {
        public DateTime DataExpiracao { get; set; }
        public string Token { get; set; }
    }
}
