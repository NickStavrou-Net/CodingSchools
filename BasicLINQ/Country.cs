using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLINQ
{
    class Country
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
        public double Population { get; set; }

        public Country() {
            Cities = new List<City>();
        }
    }
}
