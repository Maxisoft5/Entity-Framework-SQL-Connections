using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9BD.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        public int Id_Ticket { get; set; }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public DateTime DateBirth { get; set; }

    }
}
