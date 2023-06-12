namespace UI.Windows.Product;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Services;
using Business.Product;

public partial class CreateProductPage : ContentPage
{
    private readonly IProductRepository _repo;
    private readonly ICategoryRepository _cateRepo;
    private int _id = 0;
    public CreateProductPage()
    {
        InitializeComponent();
        _repo = new ProductRepository();
        _cateRepo = new CategoryRepository();
        lstProducts.ItemsSource = _repo.GetAll();
        pickCategory.ItemsSource = _cateRepo.GetCategories();

    }



    async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        DataLayer.Entities.Product newProduct = new();
        newProduct.Name = txtPName.Text;
        newProduct.Price = txtPPrice.Text;
        newProduct.Count = txtPCount.Text;
        newProduct.CategoryId = (pickCategory.SelectedItem as Category).Id;
        newProduct.Id = _id;
        if (_id == 0)
        {
            CreateNewProduct create = new CreateNewProduct(newProduct, _repo);
            var res = create.Create(newProduct);
            switch (res)
            {
                case -1:
                    await DisplayAlert("Information", "Please Enter Validation", "Done");
                    return;
                case -2:
                    await DisplayAlert("Information", "Go To Edit Section", "Done");
                    return;
            }
            await DisplayAlert("Information", "Your data Added", "Done");
            btnAdd.Text = "Add";
        }
        else
        {
            DataLayer.Entities.Product product = new();
            EditProduct edit = new EditProduct(product, _repo);
            product.Name = txtPName.Text;
            product.Price = txtPPrice.Text;
            product.Count = txtPCount.Text;
            product.Id = _id;
            product.CategoryId = (pickCategory.SelectedItem as Category).Id;
            var res = edit.Edit(product);
            switch (res)
            {
                case -1:
                    await DisplayAlert("Information", "Go to Create section", "Done");
                    return;
            }
            await DisplayAlert("Information", "Your Data Edited", "Done");
        }
        _id = 0;
        txtPCount.Text = string.Empty;
        txtPName.Text = string.Empty;
        txtPPrice.Text = string.Empty;
        lstProducts.ItemsSource = _repo.GetAll();
    }

     void btnEdit_Clicked(System.Object sender, System.EventArgs e)
    {
        btnAdd.Text = "Edit";
        int _id = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
        var get = _repo.GetById(_id);
        txtPCount.Text = get.Count;
        txtPName.Text = get.Name;
        txtPPrice.Text = get.Price;
        (pickCategory.SelectedItem as Category).Id = get.CategoryId;
        _id = get.Id;
    }

    async void btnDelete_Clicked(System.Object sender, System.EventArgs e)
    {
        int _id = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
        var get = _repo.GetById(_id);
        DeleteProduct delete = new DeleteProduct(get, _repo);
        var confirm = await DisplayAlert("Information", "You Sure Want To Delete?", "yes", "no");
        if (confirm)
        {
            var res = delete.Delete(get);
            switch (res)
            {
                case -1:
                    await DisplayAlert("Information", "Item Is Not Valid", "Done");
                    return;
            }
            await DisplayAlert("Information", "Your Data Deleted", "Done");

        }
    }





}
