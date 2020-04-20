using System;
using System.Collections.Generic;

namespace club.van.api.data.dto.PerfilArguments
{
    public class PerfilArguments
    {
        public PerfilArguments(Perfil perfil)
        {
            Id = perfil.Id;
            Nome = perfil.Nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
