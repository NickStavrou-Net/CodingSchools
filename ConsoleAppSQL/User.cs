using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppSQL
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"User ID is: {ID}")
              .Append($"Name is: {Username}")
              .Append($"Password id: {Password}");

            return sb.ToString();
        }
    }
}

