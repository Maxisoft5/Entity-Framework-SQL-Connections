using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC001.Models
{

    public class Ticket
    {
        public int Id { get; set; }
        public DateTime FromTownDate { get; set; }
        public DateTime ToTownDate { get; set; }
        public int Price { get; set; }
        public int NumberOfPassenger { get; set; }
        public int Seat { get; set; }
        public int Row { get; set; }

    }
}
