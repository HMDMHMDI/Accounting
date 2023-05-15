using System;
namespace Business.Product
{
	public class DeleteProduct
	{
        private readonly DataLayer.Entities.Product _product;
        private readonly DataLayer.Interfaces.IProductRepository _repo;
        public DeleteProduct(DataLayer.Entities.Product product, DataLayer.Interfaces.IProductRepository repo)
		{
			_repo = repo;
			_product = product;
		}

		public int Delete(DataLayer.Entities.Product _product)
		{
			if (_product.Id <= 0 )	
			{
				return -1;
			}
			_repo.Delete(_product);
			return 0;
		}
	}
}

