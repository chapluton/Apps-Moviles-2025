using Proyecto2.ViewModels;

namespace Proyecto2;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		var vm = new PropinaViewModel();
		vm.OnActualizarBotones = ActualizarColorBotones;
		BindingContext = vm;
	}

	private void ActualizarColorBotones(double porcentaje)
	{
		Color seleccionado = Color.FromArgb("#FF0077A6"); // azul más oscuro
		Color normal = Color.FromArgb("#FF8BC8D3");       // celeste

		btn10.BackgroundColor = porcentaje == 10 ? seleccionado : normal;
		btn15.BackgroundColor = porcentaje == 15 ? seleccionado : normal;
		btn20.BackgroundColor = porcentaje == 20 ? seleccionado : normal;
	}
}
