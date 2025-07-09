namespace Proyecto3.Models;

public class TransaccionInput
{
    public string Tipo { get; set; } = string.Empty;
    public double Monto { get; set; }
    public string Descripcion { get; set; } = string.Empty;
}
