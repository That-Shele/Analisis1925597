using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Analisis1925597
{
    public class LocalDbService
    {
        private const string DB_NAME = "analisis_1925597.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));

            //Le indica al sistema que crea la tabla de nuestro contexto
            _connection.CreateTableAsync<Edades>();
        }

        //Método para listar los registros de nuestra tabla
        public async Task<List<Edades>> GetEdades()
        {
            return await _connection.Table<Edades>().ToListAsync();
        }

        //Método para listar los registros por id
        public async Task<Edades> GetById(int id)
        {
            return await _connection.Table<Edades>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        //Método para crear registros
        public async Task Create(Edades edades)
        {
            await _connection.InsertAsync(edades);
        }

        //Método para actualizar
        public async Task Update(Edades edades)
        {
            await _connection.UpdateAsync(edades);
        }

        //Método para eliminar
        public async Task Delete(Edades edades)
        {
            await _connection.DeleteAsync(edades);
        }
    }
}
