using MauiApp2;

namespace MauiApp2;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(Views.MainPage), typeof(Views.MainPage));
    }
}

