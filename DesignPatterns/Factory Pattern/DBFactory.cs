using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Factory_Pattern
{
    public class DBFactory
    {
        private string _dbType;

        public DBFactory(string dbType)
        {
            this._dbType = dbType;
        }

        public IDatabase<T> GetDatabase<T>() where T : Entity
        {
            switch (this._dbType.ToLower())
            {
                case "mssql":
                    return new MsSQL<T>();

                case "mysql":
                    return new MySQL<T>();

                case "mongodb":
                    return new MongoDB<T>();

                case "oracle":
                    return new Oracle<T>();
                default:
                    throw new Exception("Unknown database type");
            }
        }
    }
}
