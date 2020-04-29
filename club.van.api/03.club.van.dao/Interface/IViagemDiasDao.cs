using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.dao.Interface
{
    public interface IViagemDiasDao
    {
        ViagemDia Obter(Guid id);

        void Salvar(ViagemDia viagemDias);

        void Atualizar(ViagemDia viagemDias);


        void Delete(ViagemDia viagemDias);

        List<ViagemDia> ObterTodas(Usuario usuario, Rota rota, int numeroSemana);

    }
}
