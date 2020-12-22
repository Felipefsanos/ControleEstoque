using AutoMapper;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Application.MapperProfiles.Usuarios
{
    public class UsuariosMapperProfile : Profile
    {
        public UsuariosMapperProfile()
        {
            CreateMap<UsuarioData, Usuario>();
            CreateMap<Usuario, UsuarioData>();
        }
    }
}
