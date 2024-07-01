using Microsoft.AspNetCore.Components;

using MudBlazor;

using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;

using System.Globalization;

namespace ProConsulta.Components.Pages
{
    public class HomePage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository repository { get; set; }

        public ChartOptions Options = new ChartOptions
        {
            LineStrokeWidth = 20,
            YAxisTicks = 1
        };
        public String[] XAxisLabels { get; set; } = [];
        public List<ChartSeries> Series { get; set; } = new();

        public double[] data { get; set; } = [];
        public string[] labels { get; set; } = [];

        protected override async Task OnInitializedAsync()
        {
            var result = await repository.GetReportAsync();

            if (result is null || !result.Any())
                return;

            MontaGraficoBarra(result);
            MontaGraficoTorta(result);
        }

        private void MontaGraficoBarra(List<AgendamentosAnuais> agendamentos)
        {
            XAxisLabels = agendamentos
                            .Select(x => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Mes)).ToArray();

            var serie = new ChartSeries
            {
                Name = "Atendimentos Mensais",
                Data = agendamentos.Select(x => (double)x.QuantidadeAgendamentos).ToArray()
            };

            Series.Add(serie);
        }

        private void MontaGraficoTorta(List<AgendamentosAnuais> agendamentos)
        {
            labels = agendamentos
                        .Select(x => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.Mes)).ToArray();

            data = agendamentos.Select(x => (double)x.QuantidadeAgendamentos).ToArray();
        }
    }
}
