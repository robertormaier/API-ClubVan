using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Linq;

namespace club.van.api.dao.Implementacao
{
    public class UsuarioDao : IUsuarioDao
    {
        private readonly ClubVanContext clubVanContext;

        public UsuarioDao(ClubVanContext clubVanContext)
        {
            this.clubVanContext = clubVanContext;
        }

        public bool Existe(string email)
        {
            return this.clubVanContext.Usuarios.Any(x => x.Email.Equals(email));
        }

        public Usuario Obter(string email, string senha)
        {
            return this.clubVanContext.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
        }

        public Usuario Obter(Guid id)
        {
            return this.clubVanContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public void Salvar(Usuario usuario)
        {
            this.clubVanContext.Usuarios.Add(usuario);
        }
    }
}
