using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Implementacao
{
    public class PerfilBusiness : IPerfilBusiness
    {

        private IPerfilDao perfilDao;

        public PerfilBusiness(IPerfilDao perfilDao)
        {
            this.perfilDao = perfilDao;
        }

        public List<Perfil> ObterTodos()
        {
            var response = this.perfilDao.ObterTodos();

            if (response == null)
                throw new Exception("Nenhum perfil encontrado");

            return response;
        }
    }
}
