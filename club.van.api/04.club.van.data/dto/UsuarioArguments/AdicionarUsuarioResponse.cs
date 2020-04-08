using System;

namespace club.van.api.data.dto.UsuarioArguments
{
    public class AdicionarUsuarioResponse
    {
        public AdicionarUsuarioResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
