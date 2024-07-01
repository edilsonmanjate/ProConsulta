using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using MudBlazor;

using ProConsulta.Extentions;
using ProConsulta.Models;
using ProConsulta.Repositories.Especialidades;
using ProConsulta.Repositories.Medicos;

namespace ProConsulta.Components.Pages.Medicos
{
    public class UpdateMedicoPage: ComponentBase
	{
		[Parameter]
		public int MedicoId { get; set; }

		[Inject]
		public IMedicoRespository respository { get; set; } = null!;

		[Inject]
		public ISnackbar Snackbar { get; set; } = null!;

		[Inject]
		public NavigationManager NavigationManager { get; set; } = null!;
        [Inject]
        public IEspecialidadeRepository especialidadeRespository { get; set; } = null!;

        public List<Especialidade> Especialidades { get; set; } = new();


        public MedicoInputModel InputModel { get; set; } = new();

		private Medico? CurrentMedico;
		public DateTime? DataCadastro { get; set; } = DateTime.Today;
		public DateTime? MaxDate { get; set; } = DateTime.Today;

		protected override async Task OnInitializedAsync()
		{
			CurrentMedico = await respository.GetByIdAsync(MedicoId);
            Especialidades = await especialidadeRespository.GetAllAsync();

            if (CurrentMedico is null)
				return;

			InputModel = new MedicoInputModel
			{
				Id = CurrentMedico.Id,
				Nome = CurrentMedico.Nome,
				Email = CurrentMedico.Email,
				CRM = CurrentMedico.CRM,
                Celular = CurrentMedico.Celular,
                Documento = CurrentMedico.Documento,
				DataCadastro = CurrentMedico.DataCadastro,
				EspecialidadeId = CurrentMedico.EspecialidadeId

			};
			DataCadastro = CurrentMedico.DataCadastro;
		}

		public async Task OnValidSubmitAsync(EditContext editContext)
		{
			try
			{
				if (editContext.Model is MedicoInputModel model)
				{
					CurrentMedico.Nome = model.Nome;
					CurrentMedico.DataCadastro = DataCadastro.Value;
					CurrentMedico.Email = model.Email;
					CurrentMedico.CRM = model.CRM;
                    CurrentMedico.Celular = model.Celular.OnlyCharacters();
					CurrentMedico.Documento = model.Documento.OnlyCharacters();
					CurrentMedico.EspecialidadeId = model.EspecialidadeId;

                    await respository.UpdateAsync(CurrentMedico);

					Snackbar.Add("Medico actualizado com sucesso", Severity.Success);
					NavigationManager.NavigateTo("/medicos");

				}
			}
			catch (Exception ex)
			{
				Snackbar.Add(ex.Message, Severity.Error);
			}
		}

    }
}
