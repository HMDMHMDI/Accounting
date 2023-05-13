using System;
namespace Business.Category
{
	public class CreateNewCategory
	{
		private readonly DataLayer.Entities.Category _category;
		private readonly DataLayer.Interfaces.ICategoryRepository _repo;
        public CreateNewCategory(DataLayer.Entities.Category category, DataLayer.Interfaces.ICategoryRepository repo)
        {
            _category = category;
            _repo = repo;
        }

        public  int Do()
		{
			if(string.IsNullOrWhiteSpace(_category.Title)) { return -1; }
			if(_category.Id < 0)
			{
				return -2;
			}

			_repo.Create(_category);
			return 0;

		}
	}
}

