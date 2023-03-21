using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Implementacao
{
    public class PerfilBusiness : IPerfilBusiness
    {

        private IPerfilDao _perfilDao;

        public PerfilBusiness(IPerfilDao perfilDao)
        {
            _perfilDao = perfilDao;
        }

        public List<Perfil> ObterTodos()
        {
            return _perfilDao.ObterTodos() ?? throw new Exception("Nenhum perfil encontrado");
        }
    }
}
