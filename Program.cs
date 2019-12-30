using System;

namespace TightCoupleLooseCoupleDIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TightCouple Example");
            User user = new User();
            user.Add("This is user data");
        }

        public class User
        {
            MSSqlServerDatabase _database;

            public User()
            {
                // instantiating MSSqlServerDatabase here makes the 
                // User class tightly coupled to MSSqlServerDatabase class
                _database = new MSSqlServerDatabase();
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
