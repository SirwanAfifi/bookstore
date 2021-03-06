﻿using System;
using System.Collections.Generic;
using PersonRepository.Interface;

namespace PersonRepository.Fake
{
    public class FakeRepository : IPersonRepository
    {
        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>
            {
                new Person() { FirstName = "John", LastName = "Smith",
                    Rating = 7, StartDate = DateTime.Now },
                new Person() { FirstName = "Mary", LastName = "Thomas",
                    Rating = 9, StartDate = DateTime.Now}
            };
            return people;
        }

        public Person GetPerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void AddPerson(Person newPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdatePeople(IEnumerable<Person> updatedPeople)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(string lastName, Person updatedPerson)
        {
            throw new NotImplementedException();
        }
    }
}