using club.van.api.data.Base;

namespace club.van.api.data
{
    public class Empresa : EntidadeBase
    {
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public bool Ativo { get; set; }
    }
}
