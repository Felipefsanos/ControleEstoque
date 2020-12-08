using ControleEstoque.Application.AppServices.Interfaces;
using ControleEstoque.Application.Datas;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ControleEstoque.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosAppService usuariosAppService;

        public UsuariosController(IUsuariosAppService usuariosAppService)
        {
            this.usuariosAppService = usuariosAppService;
        }

        [HttpPost]
        public void CriarUsuario()
        {
            usuariosAppService.CriarUsuario(null);
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
            return usuariosAppService.ObterUsuarios();
        }

        [HttpGet("{id}")]
        public void ObterUsuario()
        {

        }
    }
}
