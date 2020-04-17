using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.dao.Interface
{
    public interface IUsuarioDao
    {
        Usuario Obter(string email, string senha);
        Usuario Obter(Guid id);
        List<Usuario> ObterTodos();
        void Salvar(Usuario usuario);
        bool Existe(string email);
    }
}
