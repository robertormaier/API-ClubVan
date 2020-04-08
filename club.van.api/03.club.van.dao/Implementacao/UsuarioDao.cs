using club.van.api.dao.Interface;
using club.van.api.data;
using System;

namespace club.van.api.dao.Implementacao
{
    public class UsuarioDao : IUsuarioDao
    {
        public bool Existe(string email)
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(string email, string senha)
        {
            throw new NotImplementedException();
        }

        public Usuario Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Salvar(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
