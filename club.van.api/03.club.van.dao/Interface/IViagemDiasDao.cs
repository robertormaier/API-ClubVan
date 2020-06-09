using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.dao.Interface
{
    public interface IViagemDiasDao
    {
        ViagemDia Obter(Guid id);

        ViagemDia ObterByUser(Usuario usuario, int numeroSemana);

        void Salvar(ViagemDia viagemDias);

        void Atualizar(ViagemDia viagemDias);

        List<ViagemDia> ObterTodas(string day, Rota rota, int numeroSemana);

    }
}
