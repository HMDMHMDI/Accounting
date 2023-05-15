using System;
namespace Business.Category
{
	public class DeleteCategory
	{
		private readonly DataLayer.Entities.Category _category;
		private readonly DataLayer.Interfaces.ICategoryRepository _repo;
		public DeleteCategory(DataLayer.Entities.Category category , DataLayer.Interfaces.ICategoryRepository repo)
		{
			_repo = repo;
			_category = category;
		}
		public int Delete(DataLayer.Entities.Category _category)
		{
			if (_category.Id < 0)
			{
				return -1;
			}
			_repo.Delete(_category);
			return 0;
		}
	}
}

