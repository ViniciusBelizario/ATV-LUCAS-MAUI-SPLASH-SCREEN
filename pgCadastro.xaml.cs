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
            component.OcultarValidation(); // Oculta todas as valida��es antes de validar

            if (component.IsVazio())
            {
                component.SetValidation("Campo obrigat�rio", true);
                isFormValid = false;
                continue; // Passa para o pr�ximo campo
            }

            if (component.EntryCampo == CnpjEntry && CnpjEntry.Text.Length != 14)
            {
                component.SetValidation("CNPJ deve ter 14 d�gitos", true);
                isFormValid = false;
                continue;
            }

            if (component.EntryCampo == CodigoBarrasEntry && CodigoBarrasEntry.Text.Length != 13)
            {
                component.SetValidation("C�digo de Barras deve ter 13 d�gitos", true);
                isFormValid = false;
                continue;
            }

            if (component.EntryCampo == PrecoEntry && !decimal.TryParse(PrecoEntry.Text, out _))
            {
                component.SetValidation("Pre�o inv�lido", true);
                isFormValid = false;
                continue;
            }

            if ((component.EntryCampo == NomeEntry ||
                 component.EntryCampo == DescricaoEntry ||
                 component.EntryCampo == CategoriaEntry) &&
                 (component.GetText().Length < 5 ||
                 !IsTextValid(component.GetText())))
            {
                component.SetValidation("M�nimo 5 caracteres sem especiais", true);
                isFormValid = false;
                continue;
            }

            if (component.EntryCampo == IdadeMinimaEntry && !int.TryParse(IdadeMinimaEntry.Text, out _))
            {
                component.SetValidation("Idade m�nima inv�lida", true);
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
        // M�todo para validar se o texto n�o cont�m caracteres especiais
        return Regex.IsMatch(text, @"^[a-zA-Z0-9\s]+$");
    }
}
