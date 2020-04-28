using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.ViagemDiasArguments;
using System;
using System.Collections.Generic;

namespace club.van.api.business.Implementacao
{
    public class ViagemDiasBusiness : IViagemDiasBusiness
    {

        private IUsuarioDao usuarioDao;

        private IRotaDao rotaDao;

        private IViagemDiasDao viagemDiasDao;

        public ViagemDiasBusiness(IUsuarioDao usuarioDao, IRotaDao rotaDao, IViagemDiasDao viagemDiasDao)
        {
            this.usuarioDao = usuarioDao;

            this.rotaDao = rotaDao;

            this.viagemDiasDao = viagemDiasDao;
        }

        public AdicionarViagemDiasResponse AdicionarViagemDia(AdicionarViagemDiasRequest adicionarViagemDiasRequest)
        {

            var usuario = this.usuarioDao.Obter(adicionarViagemDiasRequest.UsuarioId);
            if (usuario == null)
                throw new Exception("Nenhum usuario econtrada com esse id");

            var rota = this.rotaDao.Obter(adicionarViagemDiasRequest.RotaId);
            if (rota == null)
                throw new Exception("Nenhuma rota econtrada com esse id");

            var viagemdia = new ViagemDia()
            {
                NumeroSemana = adicionarViagemDiasRequest.NumeroSemana,
                SegundaFeira = adicionarViagemDiasRequest.SegundaFeira,
                TercaFeira = adicionarViagemDiasRequest.TercaFeira,
                QuartaFeira = adicionarViagemDiasRequest.QuartaFeira,
                QuintaFeira = adicionarViagemDiasRequest.QuintaFeira,
                SextaFeira = adicionarViagemDiasRequest.SextaFeira,
                Sabado = adicionarViagemDiasRequest.Sabado,
                Domingo = adicionarViagemDiasRequest.Domingo,
                Rota = rota,
                Usuario = usuario
            };

            this.viagemDiasDao.Salvar(viagemdia);

            return new AdicionarViagemDiasResponse(viagemdia.Id);
        }

        public void Delete(Guid id)
        {
            var response = this.viagemDiasDao.Obter(id);

            if (response == null)
                throw new Exception("O id da viagem informada não existe");

            this.viagemDiasDao.Delete(response);
        }

        public List<ViagemDia> ObterTodos(Guid usuarioId, Guid rotaId, int numeroSemana)
        {
            var usuario = this.usuarioDao.Obter(usuarioId);
            if (usuario == null)
                throw new Exception("Nenhum usuario econtrada com esse id");

            var rota = this.rotaDao.Obter(rotaId);
            if (rota == null)
                throw new Exception("Nenhuma rota econtrada com esse id");

            return this.viagemDiasDao.ObterTodas(usuario, rota, numeroSemana);

        }

        public AtualizarViagemDiasResponse Update(AtualizarViagemDiasRequest atualizarViagemDiasRequest)
        {
            if (atualizarViagemDiasRequest.Id == Guid.Empty)
                throw new Exception("id não poder vazio");

            var usuario = this.usuarioDao.Obter(atualizarViagemDiasRequest.UsuarioId);
            if (usuario == null)
                throw new Exception("Nenhum usuario econtrada com esse id");

            var rota = this.rotaDao.Obter(atualizarViagemDiasRequest.RotaId);
            if (rota == null)
                throw new Exception("Nenhuma rota econtrada com esse id");

            var viagemDia = this.viagemDiasDao.Obter(atualizarViagemDiasRequest.Id);
            if (viagemDia == null)
                throw new Exception("Nenhuma viagem econtrada com esse id");

            viagemDia.NumeroSemana = atualizarViagemDiasRequest.NumeroSemana;
            viagemDia.SegundaFeira = atualizarViagemDiasRequest.SegundaFeira;
            viagemDia.TercaFeira = atualizarViagemDiasRequest.TercaFeira;
            viagemDia.QuartaFeira = atualizarViagemDiasRequest.QuartaFeira;
            viagemDia.QuintaFeira = atualizarViagemDiasRequest.QuintaFeira;
            viagemDia.SextaFeira = atualizarViagemDiasRequest.SextaFeira;
            viagemDia.Sabado = atualizarViagemDiasRequest.Sabado;
            viagemDia.Domingo = atualizarViagemDiasRequest.Domingo;
            viagemDia.Rota = rota;
            viagemDia.Usuario = usuario;

            this.viagemDiasDao.Salvar(viagemDia);

            return new AtualizarViagemDiasResponse(viagemDia);
        }
    }
}
