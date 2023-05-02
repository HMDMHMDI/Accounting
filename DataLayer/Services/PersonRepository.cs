using System;
using DataLayer.Entities;
using DataLayer.Interfaces;
using SQLite;

namespace DataLayer.Services
{
	public class PersonRepository:IPersonRepository
	{
        private readonly SQLiteConnection _connection;
        public PersonRepository()
        {
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            _connection.CreateTable<Person>();
        }

        public void Create(Person person)
        {
            _connection.Insert(person);
        }

        public void Delete(int id)
        {
            var person = GetById(id);
            //Getting the person object from the below method (GetById)
            _connection.Delete(person);
          
        }

        public void Delete(Person person)
        {
            _connection.Delete(person);
        }

        public void Edit(Person person)
        {
            _connection.Update(person);
        }

        public List<Person> GetAll()
        {

            //From Table of person
            return _connection.Table<Person>().ToList();
        }

        public Person GetById(int id)
        {
            return _connection.Table<Person>().Where(x => x.Id == id).First();
        }
    }
}

