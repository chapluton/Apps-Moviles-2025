using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Proyecto2.ViewModels;

public class PropinaViewModel : INotifyPropertyChanged
{
    public Action<double>? OnActualizarBotones { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string name = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    double monto;
    public double Monto
    {
        get => monto;
        set
        {
            if (monto != value)
            {
                monto = value;
                Calcular();
                OnPropertyChanged();
            }
        }
    }

    int personas = 1;
    public int Personas
    {
        get => personas;
        set
        {
            if (personas != value && value >= 1)
            {
                personas = value;
                Calcular();
                OnPropertyChanged();
            }
        }
    }

    double porcentaje = 0;
    public double PorcentajePropina
    {
        get => porcentaje;
        set
        {
            int entero = (int)Math.Round(value);
            if (porcentaje != entero)
            {
                porcentaje = entero;
                Calcular();
                OnPropertyChanged();
            }
        }
    }

    double propina;
    public double Propina => propina;

    double subtotal;
    public double Subtotal => subtotal;

    double totalPorPersona;
    public double TotalPorPersona => totalPorPersona;

    void Calcular()
    {
        propina = monto * (porcentaje / 100);
        subtotal = monto + propina;
        totalPorPersona = subtotal / personas;

        OnPropertyChanged(nameof(Propina));
        OnPropertyChanged(nameof(Subtotal));
        OnPropertyChanged(nameof(TotalPorPersona));
    }

    public ICommand SeleccionarPropinaCommand => new Command<double>(SeleccionarPropina);
    public ICommand IncrementarPersonasCommand => new Command(() => Personas++);
    public ICommand DecrementarPersonasCommand => new Command(() =>
    {
        if (Personas > 1) Personas--;
    });

    private void SeleccionarPropina(double porcentaje)
    {
        PorcentajePropina = porcentaje;
        OnActualizarBotones?.Invoke(porcentaje);
    }


}
