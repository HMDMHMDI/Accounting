using System;
namespace Business.Product
{
	public class CreateNewProduct
	{
		private readonly DataLayer.Entities.Product _product;
		private readonly DataLayer.Interfaces.IProductRepository _repo;
		public CreateNewProduct(DataLayer.Entities.Product product , DataLayer.Interfaces.IProductRepository repo)
		{
			_repo = repo;
			_product = product;
		}
		public int Create(DataLayer.Entities.Product _product)
		{
			//if (string.IsNullOrEmpty(_product.Count) || string.IsNullOrEmpty(_product.Name) || string.IsNullOrEmpty(_product.Price))	
			//{
			//	return -1;
			//}
			//if (_product.Id > 0)
			//{
			//	return -2;
			//}
			_repo.Create(_product);
			return 0;
		}
		
	}
}

