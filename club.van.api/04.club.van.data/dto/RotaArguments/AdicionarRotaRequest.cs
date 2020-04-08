namespace club.van.api.data.dto.RotaArguments
{
    public class AdicionarRotaRequest
    {
        public string Nome { get; set; }
        public Veiculo Veiculo { get; set; }
        public Empresa Empresa { get; set; }
    }
}
