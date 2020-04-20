using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace club.van.api.dao.Implementacao
{
    public class RotaDao : IRotaDao
    {
        private readonly ClubVanContext clubVanContext;

        public RotaDao(ClubVanContext clubVanContext)
        {
            this.clubVanContext = clubVanContext;
        }

        public Rota Obter(Guid id)
        {
            return this.clubVanContext.Rotas.FirstOrDefault(x => x.Id == id);
        }

        public List<Rota> ObterTodas()
        {
            return this.clubVanContext.Rotas.ToList();
        }

        public void Salvar(Rota rota)
        {
            this.clubVanContext.Rotas.Add(rota);
            this.clubVanContext.SaveChanges();
        }

        public void Delete(Rota rota)
        {
            this.clubVanContext.Rotas.Remove(rota);
            this.clubVanContext.SaveChanges();
        }
    }
}
