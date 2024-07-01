using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using MudBlazor;

using ProConsulta.Models;
using ProConsulta.Repositories.Agendamentos;

namespace ProConsulta.Components.Pages.Agendamentos
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IAgendamentoRepository repository { get; set; } = null!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Agendamento?> Agendamentos { get; set; } = new();

        public bool HideButtons { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public void GoToUpdate(int agendamentoId)
        {
            NavigationManager.NavigateTo($"/agendamentos/update/{agendamentoId}");
        }

        public async Task DeleteAgendamento(Agendamento agendamento)
        {
            try
            {
                var result = await Dialog.ShowMessageBox
                (
                "Atenção"
                , $"Tem a certeza que quer apagar o agendamento {agendamento.Id}?"
                , yesText: "Sim",
                cancelText: "Não"
                );

                if (result is true)
                {
                    await repository.DeleteAsync(agendamento.Id);
                    Snackbar.Add($"Agendamento {agendamento.Id} apagado, e nunca mais será recuperado.", Severity.Success);
                    await OnInitializedAsync();
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add(ex.Message, Severity.Error);
            }
        }

        protected override async Task OnInitializedAsync()
        {
            var auth = await AuthenticationStateTask;
            HideButtons = !auth.User.IsInRole("Atendente");
            Agendamentos = await repository.GetAllAsync();
        }
    }

}
