using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Commands.Usuarios
{
    public class EditarUsuarioCommand
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
