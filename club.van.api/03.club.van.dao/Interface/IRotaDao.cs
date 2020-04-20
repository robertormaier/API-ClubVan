using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.dao.Interface
{
    public interface IRotaDao
    {
        List<Rota> ObterTodas();

        Rota Obter(Guid id);

        void Salvar(Rota rota);

        void Delete(Rota rota);
    }
}
