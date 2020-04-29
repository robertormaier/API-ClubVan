using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace club.van.dao.Implementacao
{
    public class ViagemDiasDao : IViagemDiasDao
    {
        private readonly ClubVanContext clubVanContext;

        public ViagemDiasDao(ClubVanContext clubVanContext)
        {
            this.clubVanContext = clubVanContext;
        }

        public void Delete(ViagemDia viagemDia)
        {
            this.clubVanContext.ViagemDias.Remove(viagemDia);
            this.clubVanContext.SaveChanges();
        }

        public ViagemDia Obter(Guid id)
        {
            return this.clubVanContext.ViagemDias.FirstOrDefault(x => x.Id == id);
        }

        public List<ViagemDia> ObterTodas(Usuario usuario, Rota rota, int numeroSemana)
        {
            return this.clubVanContext.ViagemDias
                        .Include(x => x.Usuario)
                        .Include(x => x.Rota)
                            .ThenInclude(rota => rota.Veiculo)
                        .Include(x => x.Rota)
                            .ThenInclude(rota => rota.Empresa)
                        .Where(x => x.NumeroSemana == numeroSemana && x.Usuario == usuario && x.Rota == rota)
                        .ToList();
        }

        public void Salvar(ViagemDia viagemDias)
        {
            this.clubVanContext.ViagemDias.Add(viagemDias);
            this.clubVanContext.SaveChanges();
        }

        public void Atualizar(ViagemDia viagemDias)
        {
            this.clubVanContext.ViagemDias.Update(viagemDias);
            this.clubVanContext.SaveChanges();
        }

    }
}
