using ControleEstoque.Application.Commands;
using ControleEstoque.Application.Datas;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Application.AppServices.Interfaces
{
    public interface IUsuariosAppService
    {
        IEnumerable<UsuarioData> ObterUsuarios();

        void CriarUsuario(CriarUsuarioCommand command);
    }
}
