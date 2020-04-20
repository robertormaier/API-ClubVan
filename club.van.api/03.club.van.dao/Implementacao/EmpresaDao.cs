using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Linq;

namespace club.van.api.dao.Implementacao
{
    public class EmpresaDao : IEmpresaDao
    {
        private readonly ClubVanContext clubVanContext;

        public EmpresaDao(ClubVanContext clubVanContext)
        {
            this.clubVanContext = clubVanContext;
        }

        public Empresa Obter(Guid id)
        {
            return this.clubVanContext.Empresas.FirstOrDefault(x => x.Id == id);
        }

        public void Salvar(Empresa empresa)
        {
            this.clubVanContext.Empresas.Add(empresa);
            this.clubVanContext.SaveChanges();
        }
    }
}
