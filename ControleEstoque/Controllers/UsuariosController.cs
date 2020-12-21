using ControleEstoque.Application.AppServices.Interfaces;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public void CriarUsuario(CriarUsuarioCommand criarUsuarioCommand)
        {
            usuariosAppService.CriarUsuario(criarUsuarioCommand);
        }

        [HttpPut("{id}")]
        public void EditarUsuario(long id, EditarUsuarioCommand editarUsuarioCommand)
        {
            editarUsuarioCommand.Id = id;
            usuariosAppService.EditarUsuario(editarUsuarioCommand);
        }

        [HttpDelete("{id}")]
        public void RemoverUsuario(long id)
        {
            usuariosAppService.RemoverUsuario(id);
        }

        [HttpGet]
        public IEnumerable<UsuarioData> ObterUsuarios()
        {
            return usuariosAppService.ObterUsuarios();
        }

        [HttpGet("{id}")]
        public UsuarioData ObterUsuario(long id)
        {
            return usuariosAppService.ObterUsuario(id);
        }
    }
}
