using System;

namespace club.van.api.data.dto.RotaArguments
{
    public class AdicionarRotaRequest
    {
        public string Nome { get; set; }
        public Guid VeiculoId { get; set; }
        public Guid EmpresaId { get; set; }
    }
}
