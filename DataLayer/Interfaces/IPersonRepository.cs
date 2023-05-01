using System;
using DataLayer.Entities;

namespace DataLayer.Interfaces
{
	public interface IPersonRepository
	{
		Person GetById(int id);
		List<Person> GetAll();
		void Create(Person person);
		void Edit(Person person);
		void Delete(int id);
	}
}

