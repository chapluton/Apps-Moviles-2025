using SQLite;
using Proyecto3.Models;

namespace Proyecto3.Data;

public class TransaccionDatabase
{
    readonly SQLiteAsyncConnection _database;

    public TransaccionDatabase(string dbPath)
    {
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Transaccion>().Wait();
    }

    public Task<List<Transaccion>> ObtenerTransaccionesAsync() =>
        _database.Table<Transaccion>().OrderByDescending(t => t.Fecha).ToListAsync();

    public Task<int> GuardarTransaccionAsync(Transaccion transaccion) =>
        _database.InsertAsync(transaccion);

    public Task<int> EliminarTransaccionAsync(Transaccion transaccion) =>
        _database.DeleteAsync(transaccion);
}
