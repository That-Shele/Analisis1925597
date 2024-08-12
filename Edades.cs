using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Analisis1925597
{
    [Table("edades")]
    public class Edades
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("annio")]
        public string? Annio { get; set; }
        [Column("edad")]
        public string? Edad { get; set; }
    }
}
