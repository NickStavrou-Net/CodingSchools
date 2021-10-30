using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder_Pattern
{
    public class FluentSqlConnection :
        IServerSelection,
        IDatatabaseSelection,
        IUserSelection,
        IPasswordSelection,
        IConnectionInitializer
    {
        private string _server;
        private string _database;
        private string _user;
        private string _password;

        private FluentSqlConnection() { }

        //public static IServerSelection CreateConnection()
        //{
        //    return new FluentSqlConnection();
        //}

        public static IServerSelection CreateConnection(Action<ConnectionConfiguration> config)
        {
            var configuration = new ConnectionConfiguration();
            config?.Invoke(configuration);
            return new FluentSqlConnection();
        }

        public IDatatabaseSelection ForServer(string server)
        {
            _server = server;
            return this;
        }

        public IUserSelection AndDatabase(string database)
        {
            _database = database;
            return this;
        }

        public IPasswordSelection AsUser(string user)
        {
            _user = user;
            return this;
        }


        public IConnectionInitializer WithPassword(string password)
        {
            _password = password;
            return this;
        }


        public IDbConnection Connect()
        {
            var connection = new SqlConnection($"Server={_server};Database={_database};User Id={_user};Password={_password};Trusted_Connection=True");
            connection.Open();
            return connection;
        }
    }

    public class ConnectionConfiguration
    {
        public string ConnectionName { get; set; }
    }

    public interface IServerSelection
    {
        public IDatatabaseSelection ForServer(string server);
    }

    public interface IDatatabaseSelection
    {
        public IUserSelection AndDatabase(string database);
    }

    public interface IUserSelection
    {
        public IPasswordSelection AsUser(string user);
    }

    public interface IPasswordSelection
    {
        public IConnectionInitializer WithPassword(string password);
    }

    public interface IConnectionInitializer
    {
        public IDbConnection Connect();
    }
}
