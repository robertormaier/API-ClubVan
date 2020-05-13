using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.RotaArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Implementacao
{
    public class RotaBusiness : IRotaBusiness
    {
        private IRotaDao rotaDao;

        private IVeiculoDao veiculoDao;

        private IEmpresaDao empresaDao;


        public RotaBusiness(IRotaDao rotaDao, IVeiculoDao veiculoDao, IEmpresaDao empresaDao)
        {
            this.rotaDao = rotaDao;
            this.veiculoDao = veiculoDao;
            this.empresaDao = empresaDao;
        }

        public AdicionarRotaResponse Adicionar(AdicionarRotaRequest adicionarRotaRequest)
        {
            var veiculo = this.veiculoDao.Obter(adicionarRotaRequest.VeiculoId);
            if (veiculo == null)
                throw new Exception("Nenhum Veiculo econtrado com esse id");

            var empresa = this.empresaDao.Obter(adicionarRotaRequest.EmpresaId);
            if (empresa == null)
                throw new Exception("Nenhuma empresa econtrada com esse id");

            var rota = new Rota()
            {
                Nome = adicionarRotaRequest.Nome,
                Empresa = empresa,
                Veiculo = veiculo
            };

            this.rotaDao.Salvar(rota);

            return new AdicionarRotaResponse(rota.Id);
        }

        public void Delete(Guid id)
        {
            var rota = this.rotaDao.Obter(id);

            if (rota == null)
                throw new Exception("Nenhuma Rota encontrada");

            this.rotaDao.Delete(rota);
        }

        public List<Rota> ObterTodas(string empresaId)
        {
            var empresaid = Guid.Parse(empresaId);

            return this.rotaDao.ObterTodas(empresaid);
        }
    }
}
