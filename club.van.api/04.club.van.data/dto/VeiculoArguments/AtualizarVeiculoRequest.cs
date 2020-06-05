using System;

namespace club.van.api.data.dto.VeiculoArguments
{
    public class AtualizarVeiculoRequest
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Descricao { get; set; }
    }
}
