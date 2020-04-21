using club.van.api.data;
using club.van.api.data.dto.ViagemDiasArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Interface
{
    public interface IViagemDiasBusiness
    {
        List<ViagemDia> ObterTodos(Guid usuarioId, Guid rotaId, int numeroSemana);

        AdicionarViagemDiasResponse AdicionarViagemDia(AdicionarViagemDiasRequest adicionarViagemDiasRequest);

        AtualizarViagemDiasResponse Update(AtualizarViagemDiasRequest atualizarViagemDiasRequest);

        void Delete(Guid id);

    }
}
