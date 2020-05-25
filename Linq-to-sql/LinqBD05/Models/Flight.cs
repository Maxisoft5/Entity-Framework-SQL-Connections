using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{
    [Table(Name = "Рейс")]
    class Flight
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "id_Рейса")]
        public int Id { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Страны")]
        public int IDCountry { get; set; }
        [Column(Name = "[Дата и время вылета]")]
        public DateTime DateFrom { get; set; }
        [Column(Name = "[Дата и время прибытия]")]
        public DateTime DateTo { get; set; }
        [Column(Name = "[Город вылета")]
        public string TownFrom { get; set; }
        [Column(Name = "[Город прибытия]")]
        public string TownTo { get; set; }
    }
}
