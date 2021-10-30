using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory_Pattern
{
    public class Entity
    {
        public string Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string OwnerId { get; set; }
        public bool Deleted { get; set; }
    }
}
