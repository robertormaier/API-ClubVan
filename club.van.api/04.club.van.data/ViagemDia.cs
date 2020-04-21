using club.van.api.data.Base;

namespace club.van.api.data
{
    public class ViagemDia : EntidadeBase
    {
        public int NumeroSemana { get; set; }
        public bool SegundaFeira { get; set; }
        public bool TercaFeira { get; set; }
        public bool QuartaFeira { get; set; }
        public bool QuintaFeira { get; set; }
        public bool SextaFeira { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public Rota Rota { get; set; }
        public Usuario Usuario { get; set; }
    }
}
