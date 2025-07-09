namespace Proyecto3;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell(); // usar AppShell, no MainPage directo
    }
}

