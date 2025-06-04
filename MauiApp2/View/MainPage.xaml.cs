namespace MauiApp2.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnIncreaseClicked(object sender, EventArgs e)
    {
        if (BindingContext is ViewModel.MainPageViewModel vm)
        {
            vm.CantidadPersonas++;
        }
    }

    private void OnDecreaseClicked(object sender, EventArgs e)
    {
        if (BindingContext is ViewModel.MainPageViewModel vm && vm.CantidadPersonas > 1)
        {
            vm.CantidadPersonas--;
        }
    }
}
