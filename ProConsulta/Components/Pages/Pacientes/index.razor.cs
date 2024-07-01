using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using MudBlazor;

using ProConsulta.Models;
using ProConsulta.Repositories.Pacientes;

namespace ProConsulta.Components.Pages.Pacientes
{
    public class IndexPage : ComponentBase
    {
        [Inject]
        public IPacienteRespository respository { get; set; } = null!;

        [Inject]
        IDialogService Dialog { get; set; } = null!;

        [Inject]
        public ISnackbar Snackbar { get; set; } = null!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = null!;

        public List<Paciente> Pacientes { get; set; } = new List<Paciente>();

        public bool HideButtons { get; set; }
        [CascadingParameter]
        private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public void GoToUpdate(int pacienteId)
        {
            NavigationManager.NavigateTo($"/pacientes/update/{pacienteId}");
        }


        public async Task DeletePaciente(Paciente paciente)
        {
            try
            {
                 var result = await Dialog.ShowMessageBox
                 (
                 "Atenção"
                 , $"Tem a certeza que quer apagar o paciente {paciente.Nome}?"
                 , yesText: "Sim",
                 cancelText: "Não"
                 );

                if (result is true)
                {
                    await respository.DeleteByIdAsync(paciente.Id);
                   // Pacientes = await respository.GetAllAsync();
                    Snackbar.Add($"Paciente {paciente.Nome} apagado, e nunca mais será recuperado.", Severity.Success);
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
            Pacientes = await respository.GetAllAsync();
        }
    }
}
