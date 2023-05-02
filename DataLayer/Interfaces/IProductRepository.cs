using System;
using DataLayer.Entities;
namespace DataLayer.Interfaces
{
	public interface IProductRepository
	{
		Product GetById(int id);
		List<Product> GetAll();
		void Create(Product product);
        void Delete(Product product);
        void Delete(int id);
        void Edit(Product product);

    }
}

