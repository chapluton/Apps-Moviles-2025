using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MauiApp2.Model;

namespace MauiApp2.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private TipCalculation tipModel = new();

        public double ValorBoleta
        {
            get => tipModel.ValorBoleta;
            set
            {
                tipModel.ValorBoleta = value;
                OnPropertyChanged();
                Recalcular();
            }
        }

        public double PorcentajePropina
        {
            get => tipModel.PorcentajePropina;
            set
            {
                tipModel.PorcentajePropina = value;
                OnPropertyChanged();
                Recalcular();
            }
        }

        public int CantidadPersonas
        {
            get => tipModel.CantidadPersonas;
            set
            {
                if (value < 1) return; // Evita dividir por cero
                tipModel.CantidadPersonas = value;
                OnPropertyChanged();
                Recalcular();
            }
        }

        private double subtotal;
        public double Subtotal
        {
            get => subtotal;
            set { subtotal = value; OnPropertyChanged(); }
        }

        private double propina;
        public double Propina
        {
            get => propina;
            set { propina = value; OnPropertyChanged(); }
        }

        private double totalPorPersona;
        public double TotalPorPersona
        {
            get => totalPorPersona;
            set { totalPorPersona = value; OnPropertyChanged(); }
        }

        // Comandos para los botones de 10%, 15%, 20%
        public ICommand SetTipCommand { get; }

        public MainPageViewModel()
        {
            // Comando que toma un parámetro y lo convierte en porcentaje
            SetTipCommand = new Command<object>((param) =>
            {
                if (double.TryParse(param.ToString(), out double value))
                {
                    PorcentajePropina = value;
                }
            });

            // Inicializar con valores por defecto
            ValorBoleta = 0;
            PorcentajePropina = 0.1;
            CantidadPersonas = 1;
        }

        private void Recalcular()
        {
            Subtotal = tipModel.Subtotal;
            Propina = tipModel.Propina;
            TotalPorPersona = tipModel.TotalPorPersona;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
