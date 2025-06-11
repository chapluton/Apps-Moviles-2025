using MAUIAPP2_1.ViewModels;

namespace MAUIAPP2_1.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new PropinaViewModel();
    }
}

