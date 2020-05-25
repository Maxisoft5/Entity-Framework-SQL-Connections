using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{

    [Table(Name = "Managers")]
    class Managers
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "idManager")]
        public int Id { get; set; }
        [Column(Name = "[ManagerName]")]
        public string ManagerName { get; set; }
        [Column(Name = "[Pass]")]
        public string Pass { get; set; }
    
    }
}
