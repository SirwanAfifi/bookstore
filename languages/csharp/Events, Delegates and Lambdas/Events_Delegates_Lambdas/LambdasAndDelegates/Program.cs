using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdasAndDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, FirstName = "Shaho", LastName = "Toofani", City = "Tehran" },
                new Customer { Id = 2, FirstName = "Hamed", LastName = "Qaderi", City = "Sanandaj" },
                new Customer { Id = 3, FirstName = "Sattar", LastName = "Menbari", City = "Sanandaj" },
                new Customer { Id = 4, FirstName = "Rahmat", LastName = "Aj", City = "Sanandaj" },
                new Customer { Id = 5, FirstName = "Fateh", LastName = "Ahmadpanah", City = "Rasht" }
            };

            var sanandajCities = customers.Where((c, i) => c.City == "Sanandaj").Select((c, i) => new { City = c.City, i });

            foreach (var customer in sanandajCities)
            {
                Console.WriteLine(customer.i + " " + customer.City);
            }

            Console.Read();
        }
    }
}
