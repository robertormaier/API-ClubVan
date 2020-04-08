using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Linq;

namespace club.van.dao.Implementacao
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

        public void Salvar(Rota rota)
        {
            this.clubVanContext.Rotas.Add(rota);
        }
    }
}
