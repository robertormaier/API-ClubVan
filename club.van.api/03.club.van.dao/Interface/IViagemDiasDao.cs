using club.van.api.data;
using System;

namespace club.van.api.dao.Interface
{
    public interface IViagemDiasDao
    {
        ViagemDia Obeter(Guid id);

        void Salvar(ViagemDia viagemDias);
    }
}
