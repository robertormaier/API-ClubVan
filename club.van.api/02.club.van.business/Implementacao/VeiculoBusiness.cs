using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.VeiculoArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Implementacao
{
    public class VeiculoBusiness : IVeiculoBusiness
    {

        private IVeiculoDao veiculoDao;

        public VeiculoBusiness(IVeiculoDao veiculoDao)
        {
            this.veiculoDao = veiculoDao;
        }

        public AdicionarVeiculoResponse AdicionarVeiculo(AdicionarVeiculoRequest adicionarVeiculoRequest)
        {
            var veiculo = new Veiculo()
            {
                Descricao = adicionarVeiculoRequest.Descricao,
                Modelo = adicionarVeiculoRequest.Modelo,
                Placa = adicionarVeiculoRequest.Placa
            };

            this.veiculoDao.Salvar(veiculo);

            return new AdicionarVeiculoResponse(veiculo.Id);
        }

        public void Delete(Guid id)
        {
            var veiculo = this.veiculoDao.Obter(id);

            if (veiculo == null)
                throw new Exception("Nenhum veiculo encontrado");

            this.veiculoDao.Delete(veiculo);
        }

        public List<Veiculo> ObterTodos()
        {
            return this.veiculoDao.ObterTodos();
        }
    }
}
