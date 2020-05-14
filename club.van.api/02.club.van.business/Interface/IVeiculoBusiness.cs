using club.van.api.data;
using club.van.api.data.dto.VeiculoArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Interface
{
    public interface IVeiculoBusiness
    {
        AdicionarVeiculoResponse AdicionarVeiculo(AdicionarVeiculoRequest adicionarVeiculoRequest);

        void Delete(Guid id);

        List<Veiculo> ObterTodos(Guid empresaId);

    }
}
