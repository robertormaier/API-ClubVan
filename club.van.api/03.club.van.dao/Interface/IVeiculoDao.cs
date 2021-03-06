﻿using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.dao.Interface
{
    public interface IVeiculoDao
    {
        List<Veiculo> ObterTodos(Guid empresaId);

        Veiculo Obter(Guid id);

        void Salvar(Veiculo veiculo);

        void Delete(Veiculo veiculo);

        void Atualizar(Veiculo veiculo);
    }
}
