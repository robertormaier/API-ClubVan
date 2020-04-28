using System;

namespace club.van.api.data.dto.ViagemDiasArguments
{
    public class AtualizarViagemDiasResponse
    {

        public AtualizarViagemDiasResponse(ViagemDia viagemDia)
        {
            this.Id = viagemDia.Id;
            this.NumeroSemana = viagemDia.NumeroSemana;
            this.SegundaFeira = viagemDia.SegundaFeira;
            this.TercaFeira = viagemDia.TercaFeira;
            this.QuartaFeira = viagemDia.QuartaFeira;
            this.QuintaFeira = viagemDia.QuintaFeira;
            this.SextaFeira = viagemDia.SegundaFeira;
            this.Sabado = viagemDia.Sabado;
            this.Domingo = viagemDia.Domingo;
            this.Rota = viagemDia.Rota;
            this.Usuario = viagemDia.Usuario;

        }

        public Guid Id { get; set; }
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
