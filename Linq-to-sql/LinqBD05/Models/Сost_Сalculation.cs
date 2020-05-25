using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{
    [Table(Name = "Рассчёт_стоимости")]
    class Сost_Сalculation
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "[id_Рассчёта стоимости]")]
        public int Id { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Страны")]
        public virtual Country IdCountry { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Клиента")]
        public virtual Country IdClient { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Самолёта")]
        public virtual Country IdAirplane { get; set; }
        [Column(IsDbGenerated = true, Name = "id_Рейса")]
        public int IdFlight { get; set; }
        [Column(IsDbGenerated = true, Name = "Общая стоимость билета")]
        public int TotalCost { get; set; }
        [Column(Name = "[Стоимость за перелёт из города в город]")]
        public int CostFlight { get; set; }
        [Column(Name = "[Разные страны в денежном выражении]")]
        public int DifferentCountriesInValue { get; set; }
        [Column(Name = "[ООН в денежном выражении]")]
        public int OONinValue { get; set; }
        [Column(Name = "[Таможенные формальности в денежном выражении]")]
        public int FormalnostiInValue { get; set; }

    }
}
