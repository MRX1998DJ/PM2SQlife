using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2SQlife.Models;
using System.Threading.Tasks;

namespace PM2SQlife.Controller
{
    public class DataBaseSQLite
    {

        readonly SQLiteAsyncConnection db;

        //Constructor de la clase DataBaseSQLite
        public DataBaseSQLite(String pathdb)
        {
            //crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            //creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Personas>().Wait();
        }

        //Operaciones CRUD con SQLite

        public Task<List<Personas>> ObtenerListaPersonas()
        {
            return db.Table<Personas>().ToListAsync();
        }

        //READ one by one
        public Task<Personas> ObtenerPersona(int pcodigo)
        {
            return db.Table<Personas>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        //Create persona
        public Task<int> GrabarPersona(Personas persona)
        {

            if (persona.codigo != 0)
            {
                return db.UpdateAsync(persona);
            }
            else
            {
                return db.InsertAsync(persona);
            }
        }

        //Delete

        public Task<int> EliminarPersona(Personas persona)
        {
            return db.DeleteAsync(persona);
        }

    }
}
