
namespace atv2;

public partial class SplashScreen : ContentPage
{
	public SplashScreen()
	{
		InitializeComponent();
		Animation.Tremer(ubuntu);
        Animation.Tamanho(ubuntu);
        Animation.ChamarTelaInicial();
    }
}