using club.van.api.data.Base;
using System;

namespace club.van.api.data
{
    public class Rota : EntidadeBase
    {
        public string Nome { get; set; }
        public Veiculo Veiculo { get; set; }
        public Empresa Empresa { get; set; }
    }
}
