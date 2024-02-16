using PM2E15026.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2E15026.Controles
{
    public class UbicacionesControl
    {
        readonly SQLiteAsyncConnection _connection;

        public UbicacionesControl()
        {
            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
                                                SQLite.SQLiteOpenFlags.Create |
                                                SQLite.SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBSitios.db3"), extensiones);

            _connection.CreateTableAsync<Ubicaciones>();
        }

        public async Task<int> StoreSitios(Ubicaciones ubicaciones)
        {

            if (ubicaciones.Id == 0)
            {
                return await _connection.InsertAsync(ubicaciones);
            }
            else
            {
                return await _connection.UpdateAsync(ubicaciones);
            }
        }

        // Read
        public async Task<List<Modelos.Ubicaciones>> GetListSitios()
        {

            return await _connection.Table<Ubicaciones>().ToListAsync();
        }

        // Read Element
        public async Task<Modelos.Ubicaciones> GetSitio(int pid)
        {

            return await _connection.Table<Ubicaciones>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        // Delete Element
        public async Task<int> DeleteSitios(Ubicaciones sitios)
        {

            return await _connection.DeleteAsync(sitios);
        }

    }
}
