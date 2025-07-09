using Proyecto3.Data;
using Proyecto3;

public static class MauiProgram
{
    public static TransaccionDatabase BaseDatos { get; private set; } = null!;

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>();

        // Ruta a la base de datos
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "transacciones.db3");
        BaseDatos = new TransaccionDatabase(dbPath);

        return builder.Build();
    }
}
