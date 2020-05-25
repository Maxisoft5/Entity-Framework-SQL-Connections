using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBD05.Models
{

    [Table(Name = "Users")]
    class Users
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, Name = "idUser")]
        public int Id { get; set; }
        [Column(Name = "[LoginName]")]
        public string LoginName { get; set; }
        [Column(Name = "[Pass]")]
        public string Pass { get; set; }

    }
}
