using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9BD.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public Airplane Airplane { get; set; }
        public int Id_Airplane { get; set; }
        public string Arrivel { get; set; }
        public string Daparture { get; set; }
        public DateTime ArrivelDate { get; set; }
        public DateTime DapartureDate { get; set; }
        public int Id_Allowance { get; set; }
        public Allowances Allowances { get; set; }
        public decimal Price { get; set; }
    }
}
