using club.van.api.data;
using System;

namespace club.van.api.dao.Interface
{
    public interface IRotaDao
    {
        Rota Obter(Guid id);

        void Salvar(Rota rota);
    }
}
