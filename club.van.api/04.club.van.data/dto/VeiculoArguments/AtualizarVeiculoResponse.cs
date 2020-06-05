using System;

namespace club.van.api.data.dto.VeiculoArguments
{
    public class AtualizarVeiculoResponse
    {
        public AtualizarVeiculoResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
