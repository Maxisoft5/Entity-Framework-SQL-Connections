using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;


namespace LinqBD05.Models
{
    [Table(Name = "Самолёт")]
   public class Airplane
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "id_Самолёта")]
        public int Id { get; set; }
        [Column(Name = "[Тип Самолёта]")]
        public string Type_Airplane { get; set; }
        [Column(Name = "[Класс Самолёта]")]
        public string Class_Airplane { get; set; }

    }
}
