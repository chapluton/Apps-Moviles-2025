using Proyecto3.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Proyecto3.ViewModels;

public partial class TransaccionesViewModel : ObservableObject
{
    public ObservableCollection<Transaccion> ListaTransacciones { get; } = new();

    [ObservableProperty] double totalIngresos;
    [ObservableProperty] double totalGastos;
    [ObservableProperty] double balance;

    public TransaccionesViewModel()
    {
        _ = CargarTransacciones();
    }

    public async Task CargarTransacciones()
    {
        ListaTransacciones.Clear();

        var transacciones = await MauiProgram.BaseDatos.ObtenerTransaccionesAsync();
        foreach (var transaccion in transacciones)
            ListaTransacciones.Add(transaccion);

        TotalIngresos = transacciones.Where(t => t.Tipo == "Ingreso").Sum(t => t.Monto);
        TotalGastos = transacciones.Where(t => t.Tipo == "Gasto").Sum(t => t.Monto);
        Balance = TotalIngresos - TotalGastos;
    }

    [RelayCommand]
    public async Task AgregarTransaccion(TransaccionInput input)
    {
        var nueva = new Transaccion
        {
            Tipo = input.Tipo,
            Monto = input.Monto,
            Descripcion = input.Descripcion
        };

        await MauiProgram.BaseDatos.GuardarTransaccionAsync(nueva);
        await CargarTransacciones();
    }

}

