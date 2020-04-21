using System;

namespace club.van.api.data.dto.ViagemDiasArguments
{
    public class AdicionarViagemDiasResponse
    {
        public AdicionarViagemDiasResponse(Guid id)
        {
            Id = id;
        }

        public Guid  Id { get; set; }
    }
}
