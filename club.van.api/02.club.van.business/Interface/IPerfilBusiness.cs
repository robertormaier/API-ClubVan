using club.van.api.data;
using club.van.api.data.dto.PerfilArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace club.van.api.business.Interface
{
    public interface  IPerfilBusiness
    {
        List<Perfil> ObterTodos(); 
    }
}
