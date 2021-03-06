﻿using club.van.api.business.Interface;
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

        private IEmpresaDao empresaDao;

        public VeiculoBusiness(IVeiculoDao veiculoDao, IEmpresaDao empresaDao)
        {
            this.veiculoDao = veiculoDao;

            this.empresaDao = empresaDao;
        }

        public AdicionarVeiculoResponse AdicionarVeiculo(AdicionarVeiculoRequest adicionarVeiculoRequest)
        {
            var empresa = this.empresaDao.Obter(adicionarVeiculoRequest.EmpresaId);
            if (empresa == null)
                throw new Exception("Nenhuma empresa econtrada com esse id");

            var veiculo = new Veiculo()
            {
                Descricao = adicionarVeiculoRequest.Descricao,
                Modelo = adicionarVeiculoRequest.Modelo.ToUpper(),
                Placa = adicionarVeiculoRequest.Placa.ToUpper(),
                Empresa = empresa,
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

        public Veiculo GetVeiculoById(Guid id)
        {
            return this.veiculoDao.Obter(id);
        }

        public List<Veiculo> ObterTodos(string id)
        {
            var empresaId = Guid.Parse(id);

            return this.veiculoDao.ObterTodos(empresaId);
        }

        public AtualizarVeiculoResponse Update(AtualizarVeiculoRequest atualizarVeiculoRequest)
        {
            var veiculo = this.veiculoDao.Obter(atualizarVeiculoRequest.Id);

            veiculo.Modelo = atualizarVeiculoRequest.Modelo;
            veiculo.Placa = atualizarVeiculoRequest.Placa;
            veiculo.Descricao = atualizarVeiculoRequest.Descricao;

            this.veiculoDao.Atualizar(veiculo);

            return new AtualizarVeiculoResponse(veiculo.Id);
        }
    }
}
