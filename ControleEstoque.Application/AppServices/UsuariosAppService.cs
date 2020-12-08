﻿using AutoMapper;
using ControleEstoque.Application.AppServices.Interfaces;
using ControleEstoque.Application.Commands;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Infra.Helpers.Exceptions;
using ControleEstoque.Infra.Helpers.ValidacaoUtils;
using System.Collections.Generic;

namespace ControleEstoque.Application.AppServices
{
    public class UsuariosAppService : IUsuariosAppService
    {
        private readonly IUsuariosRepository usuariosRepository;
        private readonly IMapper mapper;

        public UsuariosAppService(IUsuariosRepository usuariosRepository, IMapper mapper)
        {
            this.usuariosRepository = usuariosRepository;
            this.mapper = mapper;
        }

        public void CriarUsuario(CriarUsuarioCommand command)
        {
            ValidacaoLogica.IsTrue<ValidacaoException>(command is null, "Comando não pode ser nulo");
        }

        public IEnumerable<UsuarioData> ObterUsuarios()
        {
            var usuarios = usuariosRepository.ObterTodos();

            return mapper.Map<IEnumerable<UsuarioData>>(usuarios);
        }
    }
}