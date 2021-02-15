using ControleEstoque.Application.AppServices.Interfaces;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Usuarios;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Domain.UnitOfWork;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.Utils.Mapper;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System.Collections.Generic;

namespace ControleEstoque.Application.AppServices
{
    public class UsuariosAppService : IUsuariosAppService
    {
        private readonly IUsuariosRepository usuariosRepository;
        private readonly IUnitOfWork unitOfWork;

        public UsuariosAppService(IUsuariosRepository usuariosRepository, IUnitOfWork unitOfWork)
        {
            this.usuariosRepository = usuariosRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CriarUsuario(CriarUsuarioCommand command)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(command is null, "Comando não pode ser nulo");

            var usuario = new Usuario(command);

            usuariosRepository.Adicionar(usuario);

            unitOfWork.SaveChanges();
        }

        public void EditarUsuario(EditarUsuarioCommand command)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(command is null, "Comando não pode ser nulo");
            ValidacaoLogica.IsFalse<ValidacaoException>(command.Id > 0, "Deve ser informado um Id válido");

            var usuario = usuariosRepository.ObterUm(x => x.Id == command.Id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(usuario is null, "Usuário não encontrado.");

            usuario.Editar(command);

            usuariosRepository.Atualizar(usuario);

            unitOfWork.SaveChanges();
        }

        public void RemoverUsuario(long id)
        {
            ValidacaoLogica.IsFalse<ValidacaoException>(id > 0, "Deve ser informado um Id válido");

            var usuario = usuariosRepository.ObterUm(x => x.Id == id);

            ValidacaoLogica.IsTrue<RecursoNaoEncontradoException>(usuario is null, "Usuário não encontrado.");

            usuariosRepository.Remover(usuario);

            unitOfWork.SaveChanges();
        }

        public UsuarioData ObterUsuario(long id)
        {
            var usuario = usuariosRepository.ObterUm(x => x.Id == id);

            return Mapper.MapTo<UsuarioData>(usuario);
        }

        public IEnumerable<UsuarioData> ObterUsuarios()
        {
            var usuarios = usuariosRepository.ObterTodos();

            return Mapper.MapTo<IEnumerable<UsuarioData>>(usuarios);
        }


    }
}
