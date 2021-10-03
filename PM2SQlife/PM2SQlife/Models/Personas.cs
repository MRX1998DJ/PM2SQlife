using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2SQlife.Models
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set;}

        [MaxLength(70)]
        public String nombre { get; set;}

        [MaxLength(70)]
        public String apellido { get; set; }

        
        public int edad { get; set; }

        [MaxLength(100)]
        public String Direccion { get; set; }

        [MaxLength(100)]
        public String email { get; set; }

    }
}
