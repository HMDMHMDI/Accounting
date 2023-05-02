namespace UI.Windows.Product;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Services;
public partial class CreateProductPage : ContentPage
{
    private readonly IProductRepository _repo;
    private int _id = 0;
    public CreateProductPage()
    {
        InitializeComponent();
        _repo = new ProductRepository();

    }

    async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        DataLayer.Entities.Product NewProduct = new();
        NewProduct.Name = txtPName.Text;
        NewProduct.Price = txtPPrice.Text;
        NewProduct.Count = txtPCount.Text;
        NewProduct.Id = _id;
        if (_id == 0)
        {
            _repo.Create(NewProduct);
            await DisplayAlert("Information", "Your product is Added", "done");
        }
        else
        {
            _repo.Edit(NewProduct);
            await DisplayAlert("Information", "Your product is Edited", "done");
            btnAdd.Text = "Add";
        }

    }

    async void btnShowData_Clicked(System.Object sender, System.EventArgs e)
    {
        await ShowData();
    }


    private async Task ShowData()
    {

        foreach (var item in _repo.GetAll())
        {
            var ShouldEdit = await DisplayAlert(item.Id.ToString(), item.Name + " \n " + item.Price + " \n " + item.Count, "Actions", "Next");
            if (ShouldEdit)
            {
                 var Action = await DisplayAlert("Information" , "Choose Your Action", "Edit" , "Delete");
                var product = _repo.GetById(item.Id);
                if (Action)
                {
                    txtPName.Text = product.Name;
                    txtPPrice.Text = product.Price;
                    txtPCount.Text = product.Count;
                    btnAdd.Text = "Edit";
                    _id = product.Id;
                    return;
                }
                _repo.Delete(product);
                return;
            }

        }
    }
}
