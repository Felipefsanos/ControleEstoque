using ControleEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Services.Interfaces
{
    public interface IUsuariosService
    {
        void CriarUsuario(Usuario usuario);
    }
}
