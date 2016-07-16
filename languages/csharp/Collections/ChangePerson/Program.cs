using System;

namespace ChangePerson
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[]
            {
                new Person { Name = "Sirwan", Age = 27 },
                new Person { Name = "Omid", Age = 31 }
            };

            foreach (Person person in people)
            {
                //person = new Person();
                Console.WriteLine(person);
            }

            Console.ReadLine();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name}, age={Age}";
        }
    }
}
