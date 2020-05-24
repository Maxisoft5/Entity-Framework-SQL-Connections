using Entity_Framework_Form_7.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC001.Models
{
    public class TicketContext : DbContext
    {
        public TicketContext(): base("DBConnection") { }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Waybill> Waybills { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Manager> Managers { get; set; }

    }
   
    public class AirsalesDbInitializer : DropCreateDatabaseAlways<TicketContext>
    {
        protected override void Seed(TicketContext db)
        {
            var airplane1 = new Airplane 
            { 
                ID = 1, 
                Airplane_type = "Boeing_322", 
                Airplane_class = "Business" 
            };
            var airplane2 = new Airplane 
            { 
                ID = 2, 
                Airplane_type = "Boeing_422", 
                Airplane_class = "Econom" 
            };
            db.Airplanes.AddRange(new List<Airplane> { airplane1, airplane2 });
            db.SaveChanges();

            var customer1 = new Customer 
            { 
                ID = 1, 
                FullName = "Maxim Grynyuk Alexandrovich",
                BankCard = "3226 4214 4256 5431", 
                CVV = 322, 
                Customs_Formalities = false, 
                DateValidicity = DateTime.Now 
            };
            db.SaveChanges();

            var route1 = new Waybill 
            { 
                Id = 1, 
                DispatchCountry = "Ukraine", 
                ArrivalCountry = "France", 
                IsDifferentCountry = true, 
                DispatchCity = "Kiev",
                ArrivalCity = "Paris",
                Arrival = DateTime.Now,
                Departure = DateTime.Now 
            };
            var route2 = new Waybill
            {
                Id = 2, 
                DispatchCountry = "Ukraine", 
                ArrivalCountry = "Germany", 
                DispatchCity = "Kiev",
                ArrivalCity = "Berlin",
                Arrival = DateTime.Now, 
                Departure = DateTime.Now 
            };
            db.Waybills.AddRange(new List<Waybill> { route1, route2 });
            db.SaveChanges();

            var ticket1 = new Ticket 
            { 
                Id = 2, 
                Airplane = airplane1, 
                AirplaneID = airplane1.ID,
                Customer=customer1, 
                CustomerID=customer1.ID, 
                Price = 500, 
                NumberOfPassenger = 3,
                Row = 1, 
                Seat = 1 
            };
            var ticket2 = new Ticket
            {
                Id = 3,
                Airplane = airplane2,
                AirplaneID = airplane2.ID,
                Customer = customer1,
                CustomerID = customer1.ID,
                Price = 400,
                NumberOfPassenger = 3,
                Row = 1,
                Seat = 1
            };
            db.Tickets.AddRange(new List<Ticket> { ticket1, ticket2 });
            db.SaveChanges();

            var manager = new Manager
            {
                ID = 1,
                ManagerName = "Nickolas",
                Pass = "220920"
            };

            db.Managers.Add(manager);
            db.SaveChanges();

            var user = new User
            {
                ID = 1,
                Customer = customer1,
                CustomerID = customer1.ID,
                Manager = manager,
                ManagerID = manager.ID,
                Email = "maxisoft4@gmail.com",
                Password = "qwe123"
            };
            db.Users.Add(user);
            db.SaveChanges();
           

        }


    }
}