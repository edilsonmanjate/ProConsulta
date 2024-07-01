using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using ProConsulta.Extentions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos
{
	public class CreateMedicoPage : ComponentBase
	{
		[Inject]
		public IMedicoRespository respository { get; set; } = null!;

		[Inject]
		public IEspecialidadeRepository especialidadeRespository { get; set; } = null!;
		[Inject]
		IDialogService Dialog { get; set; } = null!;

		[Inject]
		public ISnackbar Snackbar { get; set; } = null!;

		[Inject]
		public NavigationManager NavigationManager { get; set; } = null!;

		public List<Especialidade> Especialidades { get; set; } = new();
        public MedicoInputModel InputModel { get; set; } = new MedicoInputModel();
		public DateTime? DataCadastro { get; set; } = DateTime.Today;

		public async Task OnValidSubmitAsync(EditContext editContext)
		{
			try
			{
				if (editContext.Model is MedicoInputModel model)
				{
					var medico = new Medico
					{
						Nome = model.Nome,
						DataCadastro = DataCadastro.Value,
						Email = model.Email,
						CRM = model.CRM,
						EspecialidadeId = model.EspecialidadeId,
						Celular = model.Celular.OnlyCharacters(),
						Documento = model.Documento.OnlyCharacters(),
					};
					await respository.AddAsync(medico);
					Snackbar.Add("Médico adicionado com sucesso", Severity.Success);
					NavigationManager.NavigateTo("/medicos");

				}

			}
			catch (Exception ex)
			{
				Snackbar.Add(ex.Message, Severity.Error);
			}
		}

		protected override async void OnInitialized()
		{
			//base.OnInitialized();
			Especialidades = await especialidadeRespository.GetAllAsync();
		}

	}
}
