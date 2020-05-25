using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{
        [Table(Name = "Страны")]
        class Country
        {
            [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "id_Страны")]
            public int Id { get; set; }
            [Column(Name = "[Страна вылета]")]
            public string CountryFrom { get; set; }
            [Column(Name = "[Страна назначения]")]
            public string CountryTo { get; set; }
            [Column(Name = "[Разные страны]")]
            public byte DifferentCountries { get; set; }
            [Column(Name = "[Входит ли в ООН]")]
            public byte IncludeOON { get; set; }
        }
}
