using Proyecto2.ViewModels;

namespace Proyecto2;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        var vm = new PropinaViewModel();
        vm.OnActualizarBotones = ActualizarColorBotones;
        vm.OnResetearBotones = ResetearColorBotones;
        vm.OnResaltarPersonas = ResaltarPersonas;
        vm.OnMarcarBotonMas = MarcarBotonMas;
        vm.OnMarcarBotonMenos = MarcarBotonMenos;
        BindingContext = vm;
    }

    private void ActualizarColorBotones(double porcentaje)
    {
        Color seleccionado = Color.FromArgb("#FF0077A6");
        Color normal = Color.FromArgb("#FF8BC8D3");

        btn10.BackgroundColor = porcentaje == 10 ? seleccionado : normal;
        btn15.BackgroundColor = porcentaje == 15 ? seleccionado : normal;
        btn20.BackgroundColor = porcentaje == 20 ? seleccionado : normal;
    }

    private void ResetearColorBotones()
    {
        Color normal = Color.FromArgb("#FF8BC8D3");
        btn10.BackgroundColor = normal;
        btn15.BackgroundColor = normal;
        btn20.BackgroundColor = normal;
    }

    private async void ResaltarPersonas()
    {
        var original = labelPersonas.BackgroundColor;
        labelPersonas.BackgroundColor = Color.FromArgb("#FF0077A6");
        await Task.Delay(250);
        labelPersonas.BackgroundColor = original;
    }

    private async void MarcarBotonMas()
    {
        var original = btnMas.BackgroundColor;
        btnMas.BackgroundColor = Color.FromArgb("#FF0077A6");
        await Task.Delay(250);
        btnMas.BackgroundColor = original;
    }

    private async void MarcarBotonMenos()
    {
        var original = btnMenos.BackgroundColor;
        btnMenos.BackgroundColor = Color.FromArgb("#FF0077A6");
        await Task.Delay(250);
        btnMenos.BackgroundColor = original;
    }
}