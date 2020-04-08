﻿namespace club.van.api.data.dto.ViagemDiasArguments
{
    public class AdicionarViagemDiasRequest
    {
        public int NumeroSemana { get; set; }
        public bool SegundaFeira { get; set; }
        public bool TercaFeira { get; set; }
        public bool QuartaFeira { get; set; }
        public bool QuintaFeira { get; set; }
        public bool SextaFeira { get; set; }
        public bool Sabado { get; set; }
        public bool Domingo { get; set; }
        public Empresa Empresa { get; set; }
        public Usuario Usuario { get; set; }
    }
}
