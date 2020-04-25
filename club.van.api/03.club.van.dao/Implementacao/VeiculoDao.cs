using club.van.api.dao.EF;
using club.van.api.dao.Interface;
using club.van.api.data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace club.van.api.dao.Implementacao
{
    public class VeiculoDao : IVeiculoDao
    {
        private readonly ClubVanContext clubVanContext;

        public VeiculoDao(ClubVanContext clubVanContext)
        {
            this.clubVanContext = clubVanContext;
        }

        public Veiculo Obter(Guid id)
        {
            return this.clubVanContext.Veiculos.FirstOrDefault(x => x.Id == id);
        }

        public List<Veiculo> ObterTodos()
        {
            return this.clubVanContext.Veiculos.ToList();
        }

        public void Salvar(Veiculo veiculo)
        {
            this.clubVanContext.Veiculos.Add(veiculo);
        }

        public void Delete(Veiculo veiculo)
        {
            this.clubVanContext.Veiculos.Remove(veiculo);
        }
    }
}
