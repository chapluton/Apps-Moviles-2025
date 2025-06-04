namespace MauiApp2.Model
{
    public class TipCalculation
    {
        public double ValorBoleta { get; set; }
        public double PorcentajePropina { get; set; }
        public int CantidadPersonas { get; set; }

        public double Subtotal => ValorBoleta;

        public double Propina => ValorBoleta * PorcentajePropina;

        public double Total => Subtotal + Propina;

        public double TotalPorPersona => CantidadPersonas == 0 ? 0 : Total / CantidadPersonas;
    }
}
