using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEnteties.Models
{
        public class Cruise
    {
        public int ID { get; set; }
        public string FromTown { get; set; }
        public DateTime DateDeparture { get; set; }
        public string ToTown { get; set; }
        public DateTime DateArrive { get; set; }
        public bool IsDifferentCountry { get; set; }
        public bool IsUnitedNation { get; set; }
    }
}
