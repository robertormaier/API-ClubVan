using club.van.api.data;
using System;

namespace club.van.api.dao.Interface
{
    public interface IVeiculoDao
    {
        Veiculo Obter(Guid id);

        void Salvar(Veiculo veiculo);
    }
}
