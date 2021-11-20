using BasicCRUD_With_NET5.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicCRUD_With_NET5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BooksDbContext())
            {
                ////INSERT
                //var author = new Author
                //{
                //    FirstName = "Nick",
                //    LastName = "Stavrou",
                //    Books = new List<Book>
                //    {
                //        new Book{Title = "C# 9"},
                //        new Book{Title = "Design Patterns"},
                //        new Book{Title = "ADO.NET"},
                //    }
                //};

                //var author2 = new Author
                //{
                //    FirstName = "George",
                //    LastName = "Sovatzis",
                //    Books = new List<Book>
                //    {
                //        new Book{Title = "WebAPI"},
                //        new Book{Title = ".NET5"},
                //        new Book{Title = "Visual Studio"}
                //    }
                //};

                //var lender = new Lender
                //{
                //    FirstName = "Free",
                //    LastName = "Books",
                //    Books = new List<Book>
                //    {
                //        new Book{Title = "WebAPI", Author = author2},
                //        new Book{Title = ".ADO.NET", Author = author},
                //        new Book{Title = "Visual Studio", Author = author2}
                //    }

                //};
                //context.AddRange(author, author2, lender);
                //context.SaveChanges();

            }
        }
    }
}
