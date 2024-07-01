using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;
using ProConsulta.Repositories.Medicos;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class CreateAgendamentoPage : ComponentBase
    {
        [Inject]
        private IAgendamentoRepository repository { get; set; } = null!;

        [Inject]
        private IMedicoRespository medicoRepository { get; set; } = null!;

        [Inject]
        private IPacienteRespository pacienteRepository { get; set; } = null!;

        [Inject]
        private ISnackbar Snackbar { get; set; } = null!;

        protected AgendamentoInputModel InputModel { get; set; } = new AgendamentoInputModel();

        public List<Medico> Medicos { get; set; } = new();
        public List<Paciente> Pacientes { get; set; } = new();

        [Inject]
        protected NavigationManager NavigationManager { get; set; } = null!;

        public DateTime? date { get; set; } = DateTime.Now.Date;
        public TimeSpan? time = new TimeSpan(8, 0, 0);
        public DateTime? MinDate { get; set; } = DateTime.Now.Date;


        public async Task OnValidSubmitAsync(EditContext editContext)
        {
            try
            {
                if (editContext.Model is AgendamentoInputModel model)
                {
                    var agendamento = new Agendamento
                    {
                        Data = date!.Value,
                        Hora = time!.Value,
                        Observacao = model.Observacao,
                        PacienteId = model.PacienteId,
                        MedicoId = model.MedicoId
                    };

                    await repository.AddAsync(agendamento);
                    Snackbar.Add("Agendamento adicionado com sucesso", Severity.Success);
                    NavigationManager.NavigateTo("/agendamentos");
                }

            }
            catch (Exception ex)
            {

                Snackbar.Add(ex.Message, Severity.Error);
            }

        }

        protected override async Task OnInitializedAsync()
        {
            Medicos = await medicoRepository.GetAllAsync();
            Pacientes = await pacienteRepository.GetAllAsync();
        }

    }
}
