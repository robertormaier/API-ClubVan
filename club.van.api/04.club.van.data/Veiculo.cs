using club.van.api.data.Base;

namespace club.van.api.data
{
    public class Veiculo : EntidadeBase
    {
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Descricao { get; set; }
        public Empresa Empresa { get; set; }
    }
}
