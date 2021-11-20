using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD_With_NET5.Models
{
    public  abstract class Person
    {
        public int Id { get; set; }

        //[MaxLength(50)]
        public string FirstName { get; set; }
        
        //[MaxLength(50)]
        public string LastName { get; set; }
    }
}
