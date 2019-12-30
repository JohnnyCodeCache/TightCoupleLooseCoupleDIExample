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
            User user = new User(new MSSqlServerDatabase());
            user.Add("This is user data");
        }

        public class User
        {
            MSSqlServerDatabase _database;

            // passing the database object to the User constructor
            // is Dependency Injection!!!
            public User(MSSqlServerDatabase database)
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
    }
}
