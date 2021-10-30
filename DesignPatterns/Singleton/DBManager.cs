using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Singleton
{
    //sealed classes cannot be sub-classed 
    public sealed class DBManager
    {
        private static DBManager _instance;
        private static readonly object padlock = new object();  // This is just a "lock" object to achieve thread-safety
        private Guid gid = Guid.NewGuid();

        DBManager()
        {
            // private constructor: Cannot directly create objects for this class
        }

        /// <summary>
        /// This is where the singleton work is done!
        /// </summary>
        public static DBManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (padlock)  // This prevents any other thread from getting a new instance of our singleton
                    {
                        if (_instance == null)
                        {
                            _instance = new DBManager();
                        }
                    }
                }
                return _instance;
            }
        }

        public string GetId()
        {
            return this.gid.ToString();
        }

        public bool GetConnection()
        {
            Console.WriteLine("I am getting a DB connection from the pool...");
            return true;    // Normally we would return a connection object and not bool
        }

        public void Disconnect()
        {
            Console.WriteLine("I am disconnecting from the DB...");
        }
    }
}
