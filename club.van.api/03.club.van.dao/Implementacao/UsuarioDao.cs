using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
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

        public List<Usuario> ObterTodos()
        {
            return
                this.clubVanContext.Usuarios
                .Include(x => x.Perfil)
                .Include(x => x.Empresa)
                .Include(x => x.Rota)
                .Where(x => x.Ativo == true)
                .ToList();
        }

        public void Salvar(Usuario usuario)
        {
            this.clubVanContext.Usuarios.Update(usuario);
            this.clubVanContext.SaveChanges();
        }

        public void Delete(Usuario usuario)
        {
            this.clubVanContext.Usuarios.Remove(usuario);
            this.clubVanContext.SaveChanges();
        }

        public Usuario FindByEmail(string email)
        {
            return this.clubVanContext.Usuarios.Find(email);
        }
    }
}
