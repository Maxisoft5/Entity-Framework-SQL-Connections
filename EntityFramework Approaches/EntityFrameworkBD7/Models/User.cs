using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC001.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public Role Role { get; set; }

    }
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
}
