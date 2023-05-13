using System;
using System.Collections;
using DataLayer.Entities;

namespace DataLayer.Interfaces
{
	public interface ICategoryRepository
	{
		List<Category> GetCategories();
		Category GetCategoryById(int id);
		void Create(Category category);
		void Edit(Category category);
		void Delete(int id);
		void Delete(Category category);
    }
}

