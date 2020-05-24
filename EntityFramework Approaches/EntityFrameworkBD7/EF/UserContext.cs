using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC001.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DBConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
    public class UserDbInitialize : DropCreateDatabaseAlways<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Roles.Add(new Role { ID = 1, Name = "admin"});
            db.Roles.Add(new Role { ID = 2, Name = "user" });
            db.Users.Add(new User
            {
                ID = 1,
                Email = "maxisoft@gmail.com",
                Password = "051099",
                RoleID = 1
            });
            base.Seed(db);
        }
    }

}