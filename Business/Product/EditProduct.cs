using System;
namespace Business.Product
{
	public class EditProduct
	{
        private readonly DataLayer.Entities.Product _product;
        private readonly DataLayer.Interfaces.IProductRepository _repo;
        public EditProduct(DataLayer.Entities.Product product , DataLayer.Interfaces.IProductRepository repo)
		{
			_repo = repo;
			_product = product;
		}

		public int Edit(DataLayer.Entities.Product _product)
		{
			if (_product.Id <= 0)
			{
				return -1;
			}
			_repo.Edit(_product);
			return 0;
		}
	}
}

