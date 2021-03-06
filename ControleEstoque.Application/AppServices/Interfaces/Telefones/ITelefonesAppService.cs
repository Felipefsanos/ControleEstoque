﻿using ControleEstoque.Application.Datas;
using ControleEstoque.Domain.Commands.Telefones;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Application.AppServices.Interfaces.Telefones
{
    public interface ITelefonesAppService
    {
        void AdicionarTelefone(decimal cpfCliente, CriarTelefoneCommand criarTelefoneCommand);

        void EditarTelefone(EditarTelefoneCommand editarTelefoneCommand);

        void RemoverTelefone(long id);

        IEnumerable<TelefoneData> ObterTelefonesCliente(decimal cpf);
    }
}
