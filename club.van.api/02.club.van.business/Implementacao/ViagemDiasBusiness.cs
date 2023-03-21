using club.van.api.business.Interface;
using club.van.api.dao.Implementacao;
using club.van.api.dao.Interface;
using club.van.api.data;
using club.van.api.data.dto.ViagemDiasArguments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace club.van.api.business.Implementacao
{
    public class ViagemDiasBusiness : IViagemDiasBusiness
    {

        private IUsuarioDao _usuarioDao;

        private IRotaDao rotaDao;

        private IViagemDiasDao viagemDiasDao;

        public ViagemDiasBusiness(IUsuarioDao usuarioDao, IRotaDao rotaDao, IViagemDiasDao viagemDiasDao)
        {
            _usuarioDao = usuarioDao;

            this.rotaDao = rotaDao;

            this.viagemDiasDao = viagemDiasDao;
        }


        public ViagemDia ObertByUser(string usuarioId)
        {
            var id = Guid.Parse(usuarioId);
            var usuario = _usuarioDao.Obter(id) ?? throw new Exception("Nenhum usuario econtrada com esse id");
            var numeroSemana = GetWeekInYear(DateTime.Now);
            var diasQueVou = viagemDiasDao.ObterByUser(usuario, numeroSemana);
            return diasQueVou ?? new ViagemDia
            {
                Id = Guid.Empty,
                NumeroSemana = numeroSemana,
                SegundaFeira = false,
                TercaFeira = false,
                QuartaFeira = false,
                QuintaFeira = false,
                SextaFeira = false,
                Sabado = false,
                Domingo = false,
            };

        }

        public List<PontosResponse> ObterTodos(Guid rotaId)
        {
            var rota = rotaDao.Obter(rotaId) ?? throw new Exception("Nenhuma rota encontrada com esse id");

            var today = DateTime.Today;
            var numeroSemana = GetWeekInYear(today);
            var pontos = viagemDiasDao.ObterTodas(today.DayOfWeek.ToString(), rota, numeroSemana);

            return pontos.Select(item => new PontosResponse
            {
                Nome = item.Usuario.Nome,
                Logradouro = item.Usuario.Rua,
                Numero = "",
                Bairro = item.Usuario.Bairro,
                Cidade = item.Usuario.Cidade,
                Estado = item.Usuario.Uf,
            }).ToList();

        }

        public SalvarViagemDiasResponse Salvar(SalvarViagemDiasRequest atualizarViagemDiasRequest)
        {
            if (atualizarViagemDiasRequest.Id == Guid.Empty)
            {
                var usuario = this._usuarioDao.Obter(atualizarViagemDiasRequest.UsuarioId)
                        ?? throw new Exception("Nenhum usuario econtrada com esse id");

                var rota = this.rotaDao.Obter(usuario.Rota.Id)
                        ?? throw new Exception("Nenhuma rota econtrada com esse id");

                var numeroSemana = GetWeekInYear(DateTime.Now);

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
                var usuario = this._usuarioDao.Obter(atualizarViagemDiasRequest.UsuarioId)
                           ?? throw new Exception("Nenhum usuario econtrada com esse id");

                var rota = this.rotaDao.Obter(usuario.Rota.Id)
                          ?? throw new Exception("Nenhuma rota econtrada com esse id");

                var viagemDia = this.viagemDiasDao.Obter(atualizarViagemDiasRequest.Id)
                          ?? throw new Exception("Nenhuma viagem econtrada com esse id");

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

        public static int GetWeekInYear(DateTime date)
        {
            var calendar = CultureInfo.CurrentCulture.Calendar;
            var weekNum = calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
            return weekNum;
        }

    }
}
