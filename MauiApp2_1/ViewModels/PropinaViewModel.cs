using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace MAUIAPP2_1.ViewModels;

public partial class PropinaViewModel : ObservableObject 
{
    [ObservableProperty]
    double monto;

    [ObservableProperty]
    int personas = 1;

    [ObservableProperty]
    double porcentajePropina;

    [ObservableProperty]
    double propina;

    [ObservableProperty]
    double subtotal;

    [ObservableProperty]
    double totalPorPersona;

    [ObservableProperty]
    double porcentajeSeleccionado;

    [ObservableProperty]
    string montoTexto = "0";

    partial void OnMontoTextoChanged(string value)
    {
        if (double.TryParse(value, out double monto))
            Monto = monto;
        else
            Monto = 0;

        Calcular();
    }
    partial void OnPersonasChanged(int value) => Calcular();
    partial void OnPorcentajePropinaChanged(double value)
    {
        Calcular();

        // Si el usuario mueve el slider a un valor NO botón, deselecciona el botón
        if (value == 10 || value == 15 || value == 20)
            PorcentajeSeleccionado = value;
        else
            PorcentajeSeleccionado = -1; // un valor que no coincida con ningún botón
    }

    void Calcular()
    {
        Propina = Monto * (PorcentajePropina / 100);
        Subtotal = Monto + Propina;
        TotalPorPersona = Personas > 0 ? Subtotal / Personas : 0;
    }

    [RelayCommand]
    void SeleccionarPropina(object parametro)
    {
    if (parametro is string s && double.TryParse(s, out double porcentaje))
    {
        PorcentajePropina = porcentaje;
        PorcentajeSeleccionado = porcentaje;
    }
    else if (parametro is double d)
    {
        PorcentajePropina = d;
        PorcentajeSeleccionado = d;
    }
    }

    [RelayCommand]
    void IncrementarPersonas()
    {
        if (Personas < 99)
            Personas++;
    }

    [RelayCommand]
    void DecrementarPersonas()
    {
        if (Personas > 1)
            Personas--;
    }
}
