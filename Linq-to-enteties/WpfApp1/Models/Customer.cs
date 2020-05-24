using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEnteties.Models
{
   public class Customer
    {
        public int ID { get; set; }
        public string CustomerFullName { get; set; }
        public string Citizenship { get; set; }
        public DateTime DateBirth { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


    }
}
