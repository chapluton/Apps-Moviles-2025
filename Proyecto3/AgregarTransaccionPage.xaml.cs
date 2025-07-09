using Proyecto3.Models;

namespace Proyecto3.Views;

public partial class AgregarTransaccionPage : ContentPage
{
    public AgregarTransaccionPage()
    {
        InitializeComponent();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        string descripcion = entryDescripcion.Text ?? "";
        if (!double.TryParse(entryMonto.Text, out double monto))
        {
            await DisplayAlert("Error", "Ingresa un monto válido", "OK");
            return;
        }

        string tipo = checkIngreso.IsChecked ? "Ingreso" : "Gasto";
        DateTime fecha = datePickerFecha.Date;

        var nueva = new Transaccion
        {
            Descripcion = descripcion,
            Monto = monto,
            Tipo = tipo,
            Fecha = fecha
        };

        await MauiProgram.BaseDatos.GuardarTransaccionAsync(nueva);
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}
