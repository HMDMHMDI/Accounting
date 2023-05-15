using System;
namespace Business.People
{
	public class DeletePeople
	{
		private readonly DataLayer.Entities.Person _person;
		private readonly DataLayer.Interfaces.IPersonRepository _repo;
		public DeletePeople(DataLayer.Entities.Person person , DataLayer.Interfaces.IPersonRepository repo)
		{
			_repo = repo;
			_person = person;
		}

		public int Delete()
		{
			if (_person.Id <= 0)	
			{
				return -1;
			}
			_repo.Delete(_person);
			return 0;
		}
	}
}

