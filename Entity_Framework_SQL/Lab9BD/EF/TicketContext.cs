using Lab9BD.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Lab9BD.EF
{
    public class TicketContext : DbContext
    {
        public TicketContext() : base("DefaultConnection")
        {
        }
        public DbSet<Ticket> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Allowances> Allowances { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }

    }

    //public class ShopDbInitializer : DropCreateDatabaseIfModelChanges<TicketContext>
    //{
    //    protected override void Seed(TicketContext db)
    //    {
    //        Airplane airplane = new Airplane()
    //        {
    //            Id = 1,
    //            Airplane_Class = "Business",
    //            Airplane_Type = "Boeing"
    //        };
    //        Allowances allowances = new Allowances()
    //        {
    //            Id = 1,
    //            CustomerFormalities = false,
    //            DifferentCountries = false,
    //            OONCountry = false
    //        };
    //        Ticket ticket = new Ticket()
    //        {
    //            Id = 1,
    //            Id_Airplane = airplane.Id,
    //            Id_Allowance = allowances.Id,
    //            Airplane = airplane,
    //            Allowances = allowances,
    //            Arrivel = "Kiev",
    //            Daparture = "Kharkiv",
    //            ArrivelDate = DateTime.Now,
    //            DapartureDate = DateTime.Now,
    //            Price = 200
    //        };
    //        Client client = new Client()
    //        {
    //            Id = 1,
    //            Id_Ticket = ticket.Id,
    //            Ticket = ticket,
    //            FirstName = "Maxim",
    //            SurName = "Grynyuk",
    //            DateBirth = DateTime.Now
    //        };
    //    }
    //}
}
