using System;

namespace club.van.api.data.dto.RotaArguments
{
    public class AtualizarRotaRequest
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid VeiculoId { get; set; }
    }
}
