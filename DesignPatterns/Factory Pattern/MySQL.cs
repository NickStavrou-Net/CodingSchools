using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory_Pattern
{
    public class MySQL<T> : IDatabase<T> where T : Entity
    {
        public void Add(T entity)
        {
            Console.WriteLine($"Adding entity {entity.ToString()} to MySQL...");
        }

        public bool Delete(T entity)
        {
            Console.WriteLine($"Deleting entity {entity.ToString()} from MySQL...");
            return true;
        }

        public T FindById(string id)
        {
            Console.WriteLine($"Finding MySQL entity with id {id}");
            return null;
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            Console.WriteLine("Getting all MySQL entity records...");
            return null;
        }

        public bool Update(T entity)
        {
            Console.WriteLine($"Updating MySQL entity {entity.ToString()}...");
            return true;
        }
    }
}
