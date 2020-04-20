using System;

namespace club.van.api.data.dto.VeiculoArguments
{
    public class AdicionarVeiculoResponse
    {
        public AdicionarVeiculoResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
