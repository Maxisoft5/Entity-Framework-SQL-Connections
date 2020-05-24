using Lab9BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSQLite10.EF
{
    public class TicketContext : DbContext
    {
        public TicketContext() : base("DefaultConnection")
        {}
        public DbSet<Ticket> Tickets { get; set; }

    }
}
