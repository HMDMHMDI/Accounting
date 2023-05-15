using System;
namespace Business.People
{
	public class EditPeople
	{
		private readonly DataLayer.Entities.Person _person;
		private readonly DataLayer.Interfaces.IPersonRepository _repo;
		public EditPeople(DataLayer.Entities.Person person , DataLayer.Interfaces.IPersonRepository repo)
		{
			_repo = repo;
			_person = person;
		}
		public int Edit()
		{
			if (_person.Id <= 0 )	
			{
				return -1;
			}
			_repo.Edit(_person);
			return 0;
		}
	}
}

