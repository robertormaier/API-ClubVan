using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.dao.Interface
{
    public interface IPerfilDao
    {
        Perfil Obter(Guid id);

        List<Perfil> ObterTodos();

        void Salvar(Perfil perfil);
    }


}
