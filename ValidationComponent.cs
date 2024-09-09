using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atv2
{
    public class ValidationComponent
    {
        public Entry EntryCampo { get; set; }
        public Label LabelValidation { get; set; }

        // Criar o constutor da classe e realizar o vinculo com as propriedades
        public ValidationComponent(Entry txtCampo, Label lblValidation)
        {
            EntryCampo = txtCampo;
            LabelValidation = lblValidation;
        }

        // Metodo para validar campo vazio
        public bool IsVazio()
        {
            return string.IsNullOrEmpty(EntryCampo.Text);
        }

        // Metodo para retorna a informação digitada pelo usuário no compo Entry
        public string GetText()
        {
            return EntryCampo.Text;
        }

        public void OcultarValidation()
        {
            LabelValidation.IsVisible = false;
        }

        // Metodo para definir e exibir a notificação
        public void SetValidation(string MsgValidation)
        {
            LabelValidation.Text = MsgValidation;
            LabelValidation.IsVisible = true;
        }

        // Metodo de sobrecarga SetValidation adicionando aimaçãod e tremor
        public void SetValidation(string MsgValidation, bool IsTremer)
        {
            if (IsTremer)
                Animation.Tremer(EntryCampo);

            SetValidation(MsgValidation);
        }
    }
}
