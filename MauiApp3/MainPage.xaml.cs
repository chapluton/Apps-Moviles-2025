using MauiApp3.ViewModels;

namespace MauiApp3.Views;

public partial class MainPage : ContentPage
{
    MainViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        viewModel = new MainViewModel(App.Database);
        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.CargarTransaccionesAsync();
    }

    private async void OnAgregarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTransactionPage(viewModel));
    }
}