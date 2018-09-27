using System;
using System.Linq;

namespace _02FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (helloappdbContext db = new helloappdbContext())
            {
                // get objects from db
                var users = db.Users.ToList();
                Console.WriteLine("Список объектов");
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name}-{u.Age}");
                }
            }

            Console.ReadKey();

        }
    }
}
