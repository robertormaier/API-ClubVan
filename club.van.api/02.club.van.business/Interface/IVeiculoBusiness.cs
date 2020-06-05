using club.van.api.data;
using club.van.api.data.dto.VeiculoArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Interface
{
    public interface IVeiculoBusiness
    {
        AdicionarVeiculoResponse AdicionarVeiculo(AdicionarVeiculoRequest adicionarVeiculoRequest);

        AtualizarVeiculoResponse Update(AtualizarVeiculoRequest atualizarVeiculoRequest);

        void Delete(Guid id);

        List<Veiculo> ObterTodos(string id);

    }
}
