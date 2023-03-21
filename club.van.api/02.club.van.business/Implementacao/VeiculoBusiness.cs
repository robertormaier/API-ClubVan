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

        private IVeiculoDao _veiculoDao;

        private IEmpresaDao _empresaDao;

        public VeiculoBusiness(IVeiculoDao veiculoDao, IEmpresaDao empresaDao)
        {
            _veiculoDao = veiculoDao;

            _empresaDao = empresaDao;
        }

        public AdicionarVeiculoResponse AdicionarVeiculo(AdicionarVeiculoRequest adicionarVeiculoRequest)
        {
            var empresa = _empresaDao.Obter(adicionarVeiculoRequest.EmpresaId);
            if (empresa == null)
                throw new Exception("Nenhuma empresa econtrada com esse id");

            var veiculo = new Veiculo()
            {
                Descricao = adicionarVeiculoRequest.Descricao,
                Modelo = adicionarVeiculoRequest.Modelo.ToUpper(),
                Placa = adicionarVeiculoRequest.Placa.ToUpper(),
                Empresa = empresa,
            };

            _veiculoDao.Salvar(veiculo);

            return new AdicionarVeiculoResponse(veiculo.Id);
        }

        public void Delete(Guid id)
        {
            var veiculo = _veiculoDao.Obter(id);

            if (veiculo == null)
                throw new Exception("Nenhum veiculo encontrado");

            _veiculoDao.Delete(veiculo);
        }

        public Veiculo GetVeiculoById(Guid id)
        {
            return _veiculoDao.Obter(id);
        }

        public List<Veiculo> ObterTodos(string id)
        {
            var empresaId = Guid.Parse(id);

            return _veiculoDao.ObterTodos(empresaId);
        }

        public AtualizarVeiculoResponse Update(AtualizarVeiculoRequest atualizarVeiculoRequest)
        {
            var veiculo = _veiculoDao.Obter(atualizarVeiculoRequest.Id);

            veiculo.Modelo = atualizarVeiculoRequest.Modelo;
            veiculo.Placa = atualizarVeiculoRequest.Placa;
            veiculo.Descricao = atualizarVeiculoRequest.Descricao;

            _veiculoDao.Atualizar(veiculo);

            return new AtualizarVeiculoResponse(veiculo.Id);
        }
    }
}
