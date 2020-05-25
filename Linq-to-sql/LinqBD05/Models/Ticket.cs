using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{
    [Table(Name = "Билет")]
    class Ticket
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "id_Билета")]
        public int Id { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Самолёта")]
        public int IdAirplane { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Страны")]
        public int IdCountry { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Клиента")]
        public int IdClient { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Рассчёта_стоимости")]
        public int IdCostCalc { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Рейс")]
        public int IdFlight { get; set; }
        [Column(Name = "[Ряд]")]
        public int Row { get; set; }
        [Column(Name = "[Место]")]
        public int Place { get; set; }
    }
    
}
