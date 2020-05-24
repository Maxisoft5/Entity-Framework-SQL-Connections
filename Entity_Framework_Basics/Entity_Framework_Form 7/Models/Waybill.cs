using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC001.Models
{
    public class Waybill
    {
        public int Id { get; set; }
        public string DispatchCountry { get; set; }
        public string ArrivalCountry { get; set; }
        public bool? IsDifferentCountry { get; set; }
        public string DispatchCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
    }
}
