using Proyecto3.ViewModels;

namespace Proyecto3;

public partial class MainPage : ContentPage
{
    public TransaccionesViewModel ViewModel { get; }
    private bool primeraCargaHecha = false;

    public MainPage()
    {
        InitializeComponent();

        ViewModel = new TransaccionesViewModel();
        BindingContext = ViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (!primeraCargaHecha)
        {
            primeraCargaHecha = true;
            return; // No recargar la primera vez
        }

        // Recarga solo si vuelves desde otra página
        await ViewModel.CargarTransacciones();
    }

    private async void OnAgregarTransaccionClicked(object sender, EventArgs e)
    {
        bool respuesta = await DisplayAlert("Agregar", "Aquí podrías agregar una transacción", "OK", "Cancelar");
        if (respuesta)
        {
            await Shell.Current.GoToAsync("AgregarTransaccionPage");
        }
    }
}





