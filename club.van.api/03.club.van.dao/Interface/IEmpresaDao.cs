using club.van.api.data;
using System;

namespace club.van.api.dao.Interface
{
    public interface IEmpresaDao
    {
        Empresa Obter(Guid id);

        void Salvar(Empresa empresa);
    }
}
