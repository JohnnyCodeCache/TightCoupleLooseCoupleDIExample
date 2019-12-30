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
            User user = new User(new MongoDBServerDatabase());
            user.Add("This is user data");
        }

        public class User
        {
            // changing this to MongoDBServerDatabase
            MongoDBServerDatabase _database;

            // passing the database object to the User constructor
            // is Dependency Injection!!!

            // changing this to MongoDBServerDatabase
            public User(MongoDBServerDatabase database)
            {
                _database = database;
            }
            public void Add(string data)
            {
                _database.Persist(data);
            }
        }

        public class MSSqlServerDatabase
        {
            public void Persist(string data)
            {
                // pretend there is a LOT of code here 
                // doing all kinds of database stuff.
                Console.WriteLine("MSSqlServerDatabase has persisted: " + data);
            }
        }

        // adding a different class to handle db stuff
        public class MongoDBServerDatabase
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
