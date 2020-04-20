using System;

namespace club.van.api.data.dto.RotaArguments
{
    public class AdicionarRotaResponse
    {
        public AdicionarRotaResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
