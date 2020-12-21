using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Commands.Usuarios
{
    public class CriarUsuarioCommand
    {
        public string Nome { get; set; }
        public decimal Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
