using club.van.api.data;
using System;

namespace club.van.api.dao.Interface
{
    public interface IPerfilDao
    {
        Perfil Obter(Guid id);

        void Salvar(Perfil perfil);
    }


}
