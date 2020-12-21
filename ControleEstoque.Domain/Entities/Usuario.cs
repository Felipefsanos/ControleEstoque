using ControleEstoque.Domain.Commands.Usuarios;
using ControleEstoque.Domain.Entities.Base;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ExtensionsMethods;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;

namespace ControleEstoque.Domain.Entities
{
    public class Usuario : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Cpf { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public Usuario()
        {

        }

        public Usuario(CriarUsuarioCommand command)
        {
            ValidarCampos(command.Nome, command.Login, command.Senha);
            ValidacaoLogica.IsTrue<ValidacaoException>(command.Cpf <= 0, "Cpf deve ser maior que zero.");
            ValidacaoLogica.IsTrue<ValidacaoException>(command.Cpf.ToString().Length != 11, "Cpf inválido. Deve conter 11 dígitos.");
            

            Nome = command.Nome;
            Cpf = command.Cpf;
            Login = command.Login;
            Senha = command.Senha;
        }

        public void Editar(EditarUsuarioCommand command)
        {
            ValidarCampos(command.Nome, command.Login, command.Senha);

            Nome = command.Nome;
            Login = command.Login;
            Senha = command.Senha;
        }

        private void ValidarCampos(string nome, string login, string senha)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(nome.IsNullOrWhiteSpace(), "Nome não pode ser espaço ou nulo.");
            ValidacaoLogica.IsTrue<ValidacaoException>(login.IsNullOrWhiteSpace(), "Dados de login inválidos.");
            ValidacaoLogica.IsTrue<ValidacaoException>(senha.IsNullOrWhiteSpace(), "Dados de senha inválidos.");
        }
    }
}
