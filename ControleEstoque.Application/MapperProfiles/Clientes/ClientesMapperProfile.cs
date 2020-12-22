using AutoMapper;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Application.MapperProfiles.Clientes
{
    public class ClientesMapperProfile : Profile
    {
        public ClientesMapperProfile()
        {
            CreateMap<ClienteData, Cliente>();
            CreateMap<Cliente, ClienteData>();
        }
    }
}
