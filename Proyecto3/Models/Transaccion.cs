namespace Proyecto3.Models;

public class Transaccion
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;  // inicializado
    public double Monto { get; set; }
    public string Descripcion { get; set; } = string.Empty; // inicializado
    public DateTime Fecha { get; set; } = DateTime.Now;
}

