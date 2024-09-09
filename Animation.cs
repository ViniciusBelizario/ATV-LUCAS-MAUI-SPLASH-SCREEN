using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atv2
{
    public static class Animation
    {
        static public async void Tremer(VisualElement elemento)
        {
            if (elemento == null)
                return;

            uint tempo = 50;

            // Lista com os valores de deslocamento
            var deslocamento = new[] { -15, 15, -10, 10, -5, 5, 0 };

            // Aplicar um loop para cada item da lista
            foreach (var deslocar in deslocamento)
            {
                await elemento.TranslateTo(deslocar, 0, tempo);
            }

            elemento.TranslationX = 0;
        }

        static public async void Tamanho(VisualElement elemento)
        {
            await Task.Delay(2000);
            await elemento.ScaleTo(7.5, 500, Easing.Linear);

        }

        static public async void ChamarTelaInicial()
        {
            await Task.Delay(3000);
            Application.Current.MainPage = new NavigationPage(new MainPage());
        }
        static public async void ChamarTelaCadastro()
        {
            await Task.Delay(100);
            Application.Current.MainPage = new NavigationPage(new pgCadastro());
        }
    }
}
