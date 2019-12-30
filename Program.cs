using System;

namespace TightCoupleLooseCoupleDIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // this becomes a Loosely Coupled example
            Console.WriteLine("Loosely Coupled Example");

            // since we've changed the User class constructor, 
            // we must pass in an instantiated MSSqlServerDatabase object

            // changing this to MongoDBServerDatabase
            // switching between MSSQL Class and Mongo Class is fairly easy now
            User user = new User(new MSSqlServerDatabase());
            user.Add("This is user data");
        }

        public class User
        {
            // changing this to Generic Interface
            IDatabase _database;

            // passing the database object to the User constructor
            // is Dependency Injection!!!

            // changing this to Generic Interface
            public User(IDatabase database)
            {
                _database = database;
            }
            public void Add(string data)
            {
                _database.Persist(data);
            }
        }

        // our Generic interface
        public interface IDatabase
        {
            public void Persist(string data);
        }

        // changing this class to inherit Generic Interface
        public class MSSqlServerDatabase : IDatabase
        {
            public void Persist(string data)
            {
                // pretend there is a LOT of code here 
                // doing all kinds of database stuff.
                Console.WriteLine("MSSqlServerDatabase has persisted: " + data);
            }
        }

        // adding a different class to handle db stuff
        // changing this class to inherit Generic Interface
        public class MongoDBServerDatabase : IDatabase
        {
            public void Persist(string data)
            {
                // pretend there is a LOT of code here 
                // doing all kinds of database stuff.
                Console.WriteLine("MongoDBServerDatabase has persisted: " + data);
            }
        }
    }
}
