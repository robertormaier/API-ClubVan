using club.van.api.data;
using System;

namespace club.van.api.dao.Interface
{
    public interface IViagemDiasDao
    {
        ViagemDias Obeter(Guid id);

        void Salvar(ViagemDias viagemDias);
    }
}
