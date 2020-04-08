using club.van.api.data;
using System;

namespace club.van.api.dao.Interface
{
    interface IUsuarioDao
    {
        Usuario Obter(string email, string senha);
        Usuario Obter(Guid id);
        void Salvar(Usuario usuario);
        bool Existe(string email);
    }
}
