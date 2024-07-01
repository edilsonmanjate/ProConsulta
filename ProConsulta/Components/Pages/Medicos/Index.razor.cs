using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

using MudBlazor;

using ProConsulta.Models;
using ProConsulta.Repositories.Medicos;


namespace ProConsulta.Components.Pages.Medicos
{
    public class IndexPage : ComponentBase
	{
		[Inject]
		public IMedicoRespository respository { get; set; } = null!;

		[Inject]
		IDialogService Dialog { get; set; } = null!;

		[Inject]
		public ISnackbar Snackbar { get; set; } = null!;

		[Inject]
		public NavigationManager NavigationManager { get; set; } = null!;
        public List<Medico?> Medicos { get; set; } = new();

        public void GoToUpdate(int pacienteId)
		{
			NavigationManager.NavigateTo($"/medicos/update/{pacienteId}");
		}

        public bool HideButtons { get; set; }
		[CascadingParameter]
		private Task<AuthenticationState> AuthenticationStateTask { get; set; }

        public async Task DeleteMedico(Medico medico)
		{
			try
			{
				var result = await Dialog.ShowMessageBox
				(
				"Atenção"
				, $"Tem a certeza que quer apagar o médico {medico.Nome}?"
				, yesText: "Sim",
				cancelText: "Não"
				);

				if (result is true)
				{
					await respository.DeleteByIdAsync(medico.Id);
					Snackbar.Add($"Médico {medico.Nome} apagado, e nunca mais será recuperado.", Severity.Success);
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
			var auth= await AuthenticationStateTask;
			HideButtons = !auth.User.IsInRole("Atendente");

			Medicos = await respository.GetAllAsync();
		}
	}
}
