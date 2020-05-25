using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{
    [Table(Name = "Клиент")]
    class Client
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "id_Клиента")]
        public int Id { get; set; }
        [Column(Name = "[Фио]")]
        public string FullName { get; set; }
        [Column(Name = "[Гражданство]")]
        public string Nation { get; set; }

        [Column(Name = "[Дата_рождения]")]
        public DateTime DateBirth { get; set; }
        [Column(Name = "[Пол]")]
        public byte Gender { get; set; }
        [Column(Name = "[Таможенные_формальности]")]
        public byte Formalities { get; set; }
    }
}
