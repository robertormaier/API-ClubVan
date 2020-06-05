using System;

namespace club.van.api.data.dto.RotaArguments
{
    public class AtualizarRotaResponse
    {
        public AtualizarRotaResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
