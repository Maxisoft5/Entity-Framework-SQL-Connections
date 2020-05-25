using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{
    [Table(Name = "Customers")]
    class Customers
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "idCustomer")]
        public int Id { get; set; }
        [Column(Name = "[UserName]")]
        public string UserName { get; set; }
        [Column(Name = "[Pass]")]
        public string Pass { get; set; }

    }
}
