using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC001.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext() : base("DBConnection") { }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Route> Routes { get; set; }

    }

}
