using ControleEstoque.Domain.Commands.Login;
using ControleEstoque.Domain.Models.Auth;
using ControleEstoque.Domain.Services.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleEstoque.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public AuthToken RealizarLogin(LoginCommand loginCommand)
        {
            return authService.GerarToken(loginCommand);
        }
    }
}
