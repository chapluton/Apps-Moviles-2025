using MauiApp3.Services;

namespace MauiApp3;

public partial class App : Application
{
    private static DatabaseService database;

    public static DatabaseService Database
    {
        get
        {
            if (database == null)
                database = new DatabaseService(Path.Combine(FileSystem.AppDataDirectory, "mydb.db3"));
            return database;
        }
    }

    public App()
    { 
        InitializeComponent();

        MainPage = new AppShell();
    }
}

