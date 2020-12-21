using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Usuarios;
using System.Collections.Generic;

namespace ControleEstoque.Application.AppServices.Interfaces
{
    public interface IUsuariosAppService
    {
        IEnumerable<UsuarioData> ObterUsuarios();

        void CriarUsuario(CriarUsuarioCommand command);

        void EditarUsuario(EditarUsuarioCommand command);

        void RemoverUsuario(long id);

        UsuarioData ObterUsuario(long id);
    }
}
