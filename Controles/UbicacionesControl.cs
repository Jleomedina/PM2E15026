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
            // Configuración de la conexión SQLite
            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
                                                SQLite.SQLiteOpenFlags.Create |
                                                SQLite.SQLiteOpenFlags.SharedCache;

            // Inicialización de la conexión SQLite utilizando un archivo de base de datos en el directorio de datos de la aplicación
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBSitios.db3"), extensiones);

            // Crear la tabla 'Ubicaciones' si no existe
            _connection.CreateTableAsync<Ubicaciones>();
        }

        // Almacena o actualiza una ubicación en la base de datos
        public async Task<int> StoreSitios(Ubicaciones ubicaciones)
        {

            if (ubicaciones.Id == 0)
            {
                // Si la ubicación no tiene un ID (es nueva), la inserta en la base de datos
                return await _connection.InsertAsync(ubicaciones);
            }
            else
            {
                // Si la ubicación ya tiene un ID, la actualiza en la base de datos
                return await _connection.UpdateAsync(ubicaciones);
            }
        }

        // Obtiene una lista de todas las ubicaciones en la base de datos
        public async Task<List<Modelos.Ubicaciones>> GetListSitios()
        {

            return await _connection.Table<Ubicaciones>().ToListAsync();
        }

        // Obtiene una ubicación específica por su ID
        public async Task<Modelos.Ubicaciones> GetSitio(int pid)
        {

            return await _connection.Table<Ubicaciones>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        // Elimina una ubicación de la base de datos
        public async Task<int> DeleteSitios(Ubicaciones sitios)
        {

            return await _connection.DeleteAsync(sitios);
        }

    }
}
