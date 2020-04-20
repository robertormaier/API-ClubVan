using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace club.van.api.dao.Implementacao
{
    public class PerfilDao : IPerfilDao
    {
        private readonly ClubVanContext clubVanContext;

        public PerfilDao(ClubVanContext clubVanContext)
        {
            this.clubVanContext = clubVanContext;
        }

        public Perfil Obter(Guid id)
        {
            return this.clubVanContext.Perfis.FirstOrDefault(x => x.Id == id);
        }

        public List<Perfil> ObterTodos()
        {
            return this.clubVanContext.Perfis.ToList();
        }

        public void Salvar(Perfil perfil)
        {
            this.clubVanContext.Perfis.Add(perfil);
            this.clubVanContext.SaveChanges();
        }
    }
}
