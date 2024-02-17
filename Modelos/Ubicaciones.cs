using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM2E15026.Modelos
{
    // Atributo Table indica el nombre de la tabla en la base de datos SQLite
    [Table("Ubicaciones")]
    public class Ubicaciones
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20), NotNull]
        public double Latitud { get; set; }

        [MaxLength(20), NotNull]
        public double Longitud { get; set; }

        public string Desc { get; set; }

        public string foto { get; set; }

    }
}
