using System;
using DataLayer.Entities;
using DataLayer.Interfaces;
using SQLite;

namespace DataLayer.Services
{
	public class ProductRepository : IProductRepository
	{
        private readonly SQLiteConnection _connection;
        public ProductRepository()
        {
            _connection = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            _connection.CreateTable<Product>();
        }

        public void Create(Product product)
        {
            _connection.Insert(product);
        }

        public void Delete(Product product)
        {
            _connection.Delete(product);
        }

        public void Delete(int id)
        {
            var product = GetById(id);
            _connection.Delete(product);
        }

        public void Edit(Product product)
        {
            _connection.Update(product);
        }

        public List<Product> GetAll()
        {
            return _connection.Table<Product>().ToList();
        }

        public Product GetById(int id)
        {
            return _connection.Table<Product>().Where(x => x.Id == id).First();
        }
    }
}

