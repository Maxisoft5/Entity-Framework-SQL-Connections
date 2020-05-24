using LinqToEnteties.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEnteties.EF
{
    public class TicketContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Cruise> Cruises { get; set; }
        static TicketContext()
        {
            Database.SetInitializer<TicketContext>(new AirplaneDbInitializer());
        }
        public TicketContext()
          : base("DBConnection")
        {
        }
    }

    public class AirplaneDbInitializer : DropCreateDatabaseIfModelChanges<TicketContext>
    {
        protected override void Seed(TicketContext db)
        {

            db.Airplanes.Add(new Airplane { ID = 1, Type_Airplane = "Boeing 777", Class_Airplane = "Business" });
            db.Airplanes.Add(new Airplane { ID = 2, Type_Airplane = "Boeing 677", Class_Airplane = "Econom" });
            db.Airplanes.Add(new Airplane { ID = 3, Type_Airplane = "Boeing 577", Class_Airplane = "First" });

            DateTime dt = new DateTime(2020, 10, 11, 10, 00, 00);
            DateTime dt1 = new DateTime(2020, 10, 11, 15, 00, 00);
            DateTime dt2 = new DateTime(2020, 10, 12, 21, 00, 00);

            db.Cruises.Add(new Cruise
            {
                ID = 1,
                FromTown = "Berlin",
                ToTown = "Kiev",
                DateDeparture = dt,
                DateArrive = dt2,
                IsDifferentCountry = true,
                IsUnitedNation = true
            });
            db.Cruises.Add(new Cruise
            {
                ID = 2,
                FromTown = "Moscov",
                ToTown = "Kiev",
                DateDeparture = dt,
                DateArrive = dt2,
                IsDifferentCountry = true,
                IsUnitedNation = true
            });
            db.Cruises.Add(new Cruise
            {
                ID = 3,
                FromTown = "Kharkov",
                ToTown = "Kiev",
                DateDeparture = dt,
                DateArrive = dt1,
                IsDifferentCountry = true,
                IsUnitedNation = true
            });
            db.Cruises.Add(new Cruise
            {
                ID = 4,
                FromTown = "Kharkov",
                ToTown = "Kiev",
                DateDeparture = dt,
                DateArrive = dt1,
                IsDifferentCountry = true,
                IsUnitedNation = true
            });

            db.Tickets.Add(new Ticket { ID = 1, Row = 1, Seat = 1, Price = 500 });
            db.Tickets.Add(new Ticket { ID = 1, Row = 1, Seat = 1, Price = 400 });
            db.Tickets.Add(new Ticket { ID = 1, Row = 1, Seat = 1, Price = 300 });

            db.SaveChanges();
        }
    }
}
