using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControleEstoque.Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControleEstoque.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        public void CriarUsuario()
        {

        }

        [HttpPut("{id}")]
        public void EditarUsuario()
        {

        }

        [HttpDelete]
        public void RemoverUsuario()
        {

        }

        [HttpGet]
        public IEnumerable<UsuarioData> ObterUsuarios()
        {

        }

        [HttpGet("{id}")]
        public void ObterUsuario()
        {

        }
    }
}
