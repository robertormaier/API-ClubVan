using club.van.api.data;
using club.van.api.data.dto.RotaArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Interface
{
    public interface IRotaBusiness
    {

        List<Rota> ObterTodas(string empresaId);

        AdicionarRotaResponse Adicionar(AdicionarRotaRequest adicionarRotaRequest);

        AtualizarRotaResponse Update(AtualizarRotaRequest atualizarRotaRequest);

        void Delete(Guid id);
    }
}
