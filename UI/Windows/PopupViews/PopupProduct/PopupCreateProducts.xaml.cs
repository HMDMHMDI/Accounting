using CommunityToolkit.Maui.Views;
using DataLayer.Interfaces;
using DataLayer.Services;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Services;
using Business.Product;
namespace UI;

public partial class PopupCreateProducts : Popup
{
    private readonly IProductRepository _repo;
    private readonly ICategoryRepository _cateRepo;
    private int _id = 0;
    public PopupCreateProducts()
	{
        _repo = new ProductRepository();
        _cateRepo = new CategoryRepository();
        
        InitializeComponent();

	}
    private void btn_Cancel(object sender , EventArgs e)
    {
        Close();
    }
	private void btn_AddP(object sender , EventArgs e)
	{
        DataLayer.Entities.Product newProduct = new();
        newProduct.Name = txtName.Text;
        newProduct.Count = txtCount.Text;
        newProduct.Price = txtPrice.Text;
        newProduct.Id = _id;
        newProduct.CategoryId = (pickC.SelectedItem as Category).Id;
        CreateNewProduct create = new CreateNewProduct(newProduct, _repo);
        var res = create.Create(newProduct);
        switch (res)
        {
            case 0:
                return;

        }
        txtCount.Text = string.Empty;
        txtName.Text = string.Empty;
        txtPrice.Text = string.Empty;
        newProduct.CategoryId = (pickC.SelectedItem as Category).Id;
    }
}
