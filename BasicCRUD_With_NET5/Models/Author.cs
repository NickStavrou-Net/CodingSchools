using System.Collections.Generic;

namespace BasicCRUD_With_NET5.Models
{
    public class Author : Person
    {
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}