using System.Text.RegularExpressions;

namespace atv2;

public partial class pgCadastro : ContentPage

{
    private List<ValidationComponent> _validationComponents;
    public pgCadastro()
	{
		InitializeComponent();

        _validationComponents = new List<ValidationComponent>
            {
                new ValidationComponent(FabricanteEntry, FabricanteLabelValidation),
                new ValidationComponent(CnpjEntry, CnpjLabelValidation),
                new ValidationComponent(NomeEntry, NomeLabelValidation),
                new ValidationComponent(CodigoBarrasEntry, CodigoBarrasLabelValidation),
                new ValidationComponent(DescricaoEntry, DescricaoLabelValidation),
                new ValidationComponent(PrecoEntry, PrecoLabelValidation),
                new ValidationComponent(CategoriaEntry, CategoriaLabelValidation),
                new ValidationComponent(IdadeMinimaEntry, IdadeMinimaLabelValidation)
            };
    }

    private void OnValidarClicked(object sender, EventArgs e)
    {
        bool isFormValid = true;

        foreach (var component in _validationComponents)
        {
            component.OcultarValidation(); // Oculta todas as validações antes de validar

            if (component.IsVazio())
            {
                component.SetValidation("Campo obrigatório", true);
                isFormValid = false;
                continue; // Passa para o próximo campo
            }

            if (component.EntryCampo == CnpjEntry && CnpjEntry.Text.Length != 14)
            {
                component.SetValidation("CNPJ deve ter 14 dígitos", true);
                isFormValid = false;
                continue;
            }

            if (component.EntryCampo == CodigoBarrasEntry && CodigoBarrasEntry.Text.Length != 13)
            {
                component.SetValidation("Código de Barras deve ter 13 dígitos", true);
                isFormValid = false;
                continue;
            }

            if (component.EntryCampo == PrecoEntry && !decimal.TryParse(PrecoEntry.Text, out _))
            {
                component.SetValidation("Preço inválido", true);
                isFormValid = false;
                continue;
            }

            if ((component.EntryCampo == NomeEntry ||
                 component.EntryCampo == DescricaoEntry ||
                 component.EntryCampo == CategoriaEntry) &&
                 (component.GetText().Length < 5 ||
                 !IsTextValid(component.GetText())))
            {
                component.SetValidation("Mínimo 5 caracteres sem especiais", true);
                isFormValid = false;
                continue;
            }

            if (component.EntryCampo == IdadeMinimaEntry && !int.TryParse(IdadeMinimaEntry.Text, out _))
            {
                component.SetValidation("Idade mínima inválida", true);
                isFormValid = false;
            }
        }

        if (isFormValid)
        {
            DisplayAlert("Sucesso", "Cadastro validado com sucesso!", "OK");
        }
        else
        {
            DisplayAlert("Erro", "Corrija os erros e tente novamente.", "OK");
        }
    }

    private bool IsTextValid(string text)
    {
        // Método para validar se o texto não contém caracteres especiais
        return Regex.IsMatch(text, @"^[a-zA-Z0-9\s]+$");
    }
}
