using System;
namespace Business.People
{
	public class CreateNewPerson
	{
		private readonly DataLayer.Entities.Person _person;
		private readonly DataLayer.Interfaces.IPersonRepository _repo;
		public CreateNewPerson(DataLayer.Entities.Person person , DataLayer.Interfaces.IPersonRepository repo)
		{
			_repo = repo;
			_person = person;
		}
		public int Create(DataLayer.Entities.Person _person)
		{
			if (string.IsNullOrWhiteSpace( _person.FName) || string.IsNullOrWhiteSpace(_person.LName) || string.IsNullOrWhiteSpace(_person.PhoneNumber))	
			{
				return -1;
			}
			if (_person.Id > 0)	
			{
				return -2;
			}
			_repo.Create(_person);
			return 0;
		}
	}
}

