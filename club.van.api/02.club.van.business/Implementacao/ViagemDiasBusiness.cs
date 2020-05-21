using club.van.api.business.Interface;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.ViagemDiasArguments;
using Microsoft.AspNetCore.JsonPatch.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;

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


        public ViagemDia ObertByUser(string usuarioId)
        {
            var id = Guid.Parse(usuarioId);

            var usuario = this.usuarioDao.Obter(id);
            if (usuario == null)
                throw new Exception("Nenhum usuario econtrada com esse id");

            var diasQueVou = this.viagemDiasDao.ObterByUser(usuario);

            if (diasQueVou != null)
                return diasQueVou;

            return new ViagemDia()
            {
                Id = Guid.Empty,
                NumeroSemana = GetWeekInyear(DateTime.Now),
                SegundaFeira = false,
                TercaFeira = false,
                QuartaFeira = false,
                QuintaFeira = false,
                SextaFeira = false,
                Sabado = false,
                Domingo = false,
            };
        }


        public void Delete(Guid id)
        {
            var response = this.viagemDiasDao.Obter(id);

            if (response == null)
                throw new Exception("O id da viagem informada não existe");

            this.viagemDiasDao.Delete(response);
        }

        public List<PontosResponse> ObterTodos(Guid rotaId)
        {
            var rota = this.rotaDao.Obter(rotaId);
            if (rota == null)
                throw new Exception("Nenhuma rota econtrada com esse id");

            var day = DateTime.Now;

            var numeroSemana = GetWeekInyear(day);

            var pontos = this.viagemDiasDao.ObterTodas(day.DayOfWeek.ToString(), rota, numeroSemana);

            var listPontos = new List<PontosResponse>();

            foreach (var item in pontos)
            {
                var ponto = new PontosResponse()
                {
                    Nome = item.Usuario.Nome,
                    Logradouro = item.Usuario.Rua,
                    Numero = "",
                    Bairro = item.Usuario.Bairro,
                    Cidade = item.Usuario.Cidade,
                    Estado = item.Usuario.Uf,
                };

                listPontos.Add(ponto);
            }
            return listPontos;
        }

        public SalvarViagemDiasResponse Salvar(SalvarViagemDiasRequest atualizarViagemDiasRequest)
        {
            if (atualizarViagemDiasRequest.Id == Guid.Empty)
            {
                var usuario = this.usuarioDao.Obter(atualizarViagemDiasRequest.UsuarioId);
                if (usuario == null)
                    throw new Exception("Nenhum usuario econtrada com esse id");

                var rota = this.rotaDao.Obter(usuario.Rota.Id);
                if (rota == null)
                    throw new Exception("Nenhuma rota econtrada com esse id");

                var numeroSemana = GetWeekInyear(DateTime.Now);

                var viagemdia = new ViagemDia()
                {
                    NumeroSemana = numeroSemana,
                    SegundaFeira = atualizarViagemDiasRequest.SegundaFeira,
                    TercaFeira = atualizarViagemDiasRequest.TercaFeira,
                    QuartaFeira = atualizarViagemDiasRequest.QuartaFeira,
                    QuintaFeira = atualizarViagemDiasRequest.QuintaFeira,
                    SextaFeira = atualizarViagemDiasRequest.SextaFeira,
                    Sabado = atualizarViagemDiasRequest.Sabado,
                    Domingo = atualizarViagemDiasRequest.Domingo,
                    Rota = rota,
                    Usuario = usuario
                };

                this.viagemDiasDao.Salvar(viagemdia);

                return new SalvarViagemDiasResponse(viagemdia);
            }

            else
            {
                var usuario = this.usuarioDao.Obter(atualizarViagemDiasRequest.UsuarioId);
                if (usuario == null)
                    throw new Exception("Nenhum usuario econtrada com esse id");

                var rota = this.rotaDao.Obter(usuario.Rota.Id);
                if (rota == null)
                    throw new Exception("Nenhuma rota econtrada com esse id");

                var viagemDia = this.viagemDiasDao.Obter(atualizarViagemDiasRequest.Id);
                if (viagemDia == null)
                    throw new Exception("Nenhuma viagem econtrada com esse id");

                viagemDia.SegundaFeira = atualizarViagemDiasRequest.SegundaFeira;
                viagemDia.TercaFeira = atualizarViagemDiasRequest.TercaFeira;
                viagemDia.QuartaFeira = atualizarViagemDiasRequest.QuartaFeira;
                viagemDia.QuintaFeira = atualizarViagemDiasRequest.QuintaFeira;
                viagemDia.SextaFeira = atualizarViagemDiasRequest.SextaFeira;
                viagemDia.Sabado = atualizarViagemDiasRequest.Sabado;
                viagemDia.Domingo = atualizarViagemDiasRequest.Domingo;
                viagemDia.Rota = rota;
                viagemDia.Usuario = usuario;

                this.viagemDiasDao.Atualizar(viagemDia);

                return new SalvarViagemDiasResponse(viagemDia);
            }
        }

        public static int GetWeekInyear(DateTime date)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, ciCurr.DateTimeFormat.FirstDayOfWeek);
            return weekNum;
        }
    }
}
