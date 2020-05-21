using club.van.api.data;
using club.van.api.data.dto.ViagemDiasArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Interface
{
    public interface IViagemDiasBusiness
    {
        List<PontosResponse> ObterTodos(Guid rotaId);

        ViagemDia ObertByUser(string usuarioId);

        SalvarViagemDiasResponse Salvar(SalvarViagemDiasRequest atualizarViagemDiasRequest);

        void Delete(Guid id);

    }
}
