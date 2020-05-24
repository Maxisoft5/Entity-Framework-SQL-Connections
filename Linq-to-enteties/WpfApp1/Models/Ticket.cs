using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEnteties.Models
{
       public class Ticket
    {
        public int ID { get; set; }
        public int Price { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public Airplane Airplane { get; set; }
        public Cruise Cruise { get; set; }
        public Customer Customer { get; set; }
    }
}
