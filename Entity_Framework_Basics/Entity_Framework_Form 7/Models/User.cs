using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC001.Models
{
    public class User
    {
        public int ID { get; set; }
        public virtual Manager Manager { get; set; }
        public int? ManagerID { get; set; }
        public virtual Customer Customer { get; set; }
        public int? CustomerID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
  
}
