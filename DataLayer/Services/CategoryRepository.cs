using System;
using DataLayer.Entities;
using DataLayer.Interfaces;
using SQLite;

namespace DataLayer.Services
{
	public class CategoryRepository:ICategoryRepository
	{
        private readonly SQLiteConnection _connection;
		public CategoryRepository()
		{
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            _connection.CreateTable<Category>();
            		}

        public void Create(Category category)
        {
            _connection.Insert(category);
        }

        public void Delete(int id)
        {
            var category = GetCategoryById(id);
            _connection.Delete(category);
        }
        public void Delete(Category category)
        {
            _connection.Delete(category);
        }

        public void Edit(Category category)
        {
            _connection.Update(category);
        }

        public List<Category> GetCategories()
        {
            return _connection.Table<Category>().ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _connection.Table<Category>().Where(i => i.Id == id).First();

        }
    }
}

