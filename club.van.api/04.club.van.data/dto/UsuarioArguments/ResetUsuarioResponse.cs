using System;

namespace club.van.api.data.dto.UsuarioArguments
{
    public class ResetUsuarioResponse
    {
        public ResetUsuarioResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
