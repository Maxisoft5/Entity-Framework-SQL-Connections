using Entity_Framework_Form_7.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC001.Models
{

    public class Ticket
    {
        public int Id { get; set; }
        public virtual Waybill Route { get; set; }
        public int? RouteID { get; set; }
        public virtual Customer Customer { get; set; }
        public int? CustomerID { get; set; }
        public virtual Airplane Airplane { get; set; }
        public int? AirplaneID { get; set; }
        public int Price { get; set; }
        public int NumberOfPassenger { get; set; }
        public int Seat { get; set; }
        public int Row { get; set; }

    }
}
