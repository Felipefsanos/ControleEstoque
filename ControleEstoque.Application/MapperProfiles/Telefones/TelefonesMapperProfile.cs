using AutoMapper;
using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Application.MapperProfiles.Telefones
{
    public class TelefonesMapperProfile : Profile
    {
        public TelefonesMapperProfile()
        {
            CreateMap<TelefoneData, Telefone>();
            CreateMap<Telefone, TelefoneData>();
        }
    }
}
