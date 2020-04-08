using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Linq;

namespace club.van.dao.Implementacao
{
    public class ViagemDiasDao : IViagemDiasDao
    {
        private readonly ClubVanContext clubVanContext;

        public ViagemDias Obeter(Guid id)
        {
            return this.clubVanContext.ViagemDias.FirstOrDefault(x => x.Id == id);
        }

        public void Salvar(ViagemDias viagemDias)
        {
            this.clubVanContext.ViagemDias.Add(viagemDias);
        }
    }
}
