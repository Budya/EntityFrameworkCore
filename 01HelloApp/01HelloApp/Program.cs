using System;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace _01HelloApp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region oldver

            //    using (ApplicationContext db = new ApplicationContext())
            //    {
            //        // создаем два объекта User
            //        User user1 = new User { Name = "Tom", Age = 33 };
            //        User user2 = new User { Name = "Alice", Age = 26 };

            //        // добавляем их в бд
            //        db.Users.Add(user1);
            //        db.Users.Add(user2);
            //        db.SaveChanges();
            //        Console.WriteLine("Объекты успешно сохранены");

            //        // получаем объекты из бд и выводим на консоль
            //        var users = db.Users.ToList();
            //        Console.WriteLine("Список объектов:");
            //        foreach (User u in users)
            //        {
            //            Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
            //        }
            //    }
            //    Console.Read();
            //}


            #endregion

            var builder = new ConfigurationBuilder();
            // set path to THIS directory
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // get config from file
            builder.AddJsonFile("appsettings.json");
            // create configuration
            var config = builder.Build();

            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuidler = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuidler
                .UseSqlServer(connectionString)
                .Options;

            using (ApplicationContext db = new ApplicationContext(options))
            {
                var users = db.Users.ToList();
                foreach (User u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
                }
            }
            Console.Read();
        }
    }
}
