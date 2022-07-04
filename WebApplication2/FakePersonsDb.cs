﻿namespace WebApplication2
{
    public class FakePersonsDb
    {
        public List<Person> Persons { get; set; }
        public FakePersonsDb()
        {
            Persons = new List<Person>();
        }

        public void Add(Person person)
        {
            Persons.Add(person);
        }

        public List<Person> GetAll()
        {
            return Persons;
        }
    }
}
