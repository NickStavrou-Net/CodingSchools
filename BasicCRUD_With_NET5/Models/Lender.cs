using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD_With_NET5.Models
{
    public class Lender : Person
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
