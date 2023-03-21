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
        private readonly IRotaDao _rotaDao;
        private readonly IVeiculoDao _veiculoDao;
        private readonly IEmpresaDao _empresaDao;

        public RotaBusiness(IRotaDao rotaDao, IVeiculoDao veiculoDao, IEmpresaDao empresaDao)
        {
            _rotaDao = rotaDao;
            _veiculoDao = veiculoDao;
            _empresaDao = empresaDao;
        }

        public AdicionarRotaResponse Adicionar(AdicionarRotaRequest adicionarRotaRequest)
        {
            var veiculo = _veiculoDao.Obter(adicionarRotaRequest.VeiculoId);
            if (veiculo == null)
            {
                throw new ArgumentException("Nenhum Veiculo encontrado com este ID");
            }

            var empresa = _empresaDao.Obter(adicionarRotaRequest.EmpresaId);
            if (empresa == null)
            {
                throw new ArgumentException("Nenhuma empresa encontrada com este ID");
            }

            var rota = new Rota
            {
                Nome = adicionarRotaRequest.Nome,
                Empresa = empresa,
                Veiculo = veiculo
            };

            _rotaDao.Salvar(rota);

            return new AdicionarRotaResponse(rota.Id);
        }

        public void Delete(Guid id)
        {
            var rota = _rotaDao.Obter(id);

            if (rota == null)
            {
                throw new ArgumentException("Nenhuma Rota encontrada com este ID");
            }

            _rotaDao.Delete(rota);
        }

        public Rota GetRotaById(Guid id)
        {
            return _rotaDao.Obter(id);
        }

        public List<Rota> ObterTodas(string empresaId)
        {
            var empresaGuid = Guid.Parse(empresaId);

            return _rotaDao.ObterTodas(empresaGuid);
        }

        public AtualizarRotaResponse Update(AtualizarRotaRequest atualizarRotaRequest)
        {
            var rota = _rotaDao.Obter(atualizarRotaRequest.Id);

            var veiculo = _veiculoDao.Obter(atualizarRotaRequest.VeiculoId);
            if (veiculo == null)
            {
                throw new ArgumentException("Nenhum Veiculo encontrado com este ID");
            }

            rota.Nome = atualizarRotaRequest.Nome;
            rota.Veiculo = veiculo;

            _rotaDao.Atualizar(rota);

            return new AtualizarRotaResponse(rota.Id);
        }
    }

}
