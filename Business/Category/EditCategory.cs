using System;
namespace Business.Category
{
    public class EditCategory
    {
        private readonly DataLayer.Entities.Category _category;
        private readonly DataLayer.Interfaces.ICategoryRepository _repo;

        public EditCategory(DataLayer.Entities.Category category, DataLayer.Interfaces.ICategoryRepository repo)
        {
            _category = category;
            _repo = repo;
        }
        public int Edit(DataLayer.Entities.Category _category)
        {

            if (_category.Id < 0)
            {
                return -2;
            }
            _repo.Edit(_category);
            return -3;


        }
    }
}

