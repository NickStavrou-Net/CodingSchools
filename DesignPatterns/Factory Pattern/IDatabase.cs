using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory_Pattern
{
    public interface IDatabase<T> where T : Entity
    {
        void Add(T entity);     // INSERT INTO T VALUES (...)
        bool Delete(T entity);  // DELETE FROM T WHERE ...
        bool Update(T entity);  // UPDATE T SET ...
        T FindById(string id); // SELECT * FROM T WHERE id = '?'
        T FindById(int id); // SELECT * FROM T WHERE id = ?
        List<T> GetAll();   // SELECT * FROM T
    }
}
