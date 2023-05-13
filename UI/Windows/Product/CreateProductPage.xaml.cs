﻿namespace UI.Windows.Product;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Services;
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

    void Test(int id)
    {
        DisplayAlert(id.ToString(), id.ToString(), id.ToString());
    }

    async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        DataLayer.Entities.Product newProduct = new();
        newProduct.Name = txtPName.Text;
        newProduct.Price = txtPPrice.Text;
        newProduct.Count = txtPCount.Text;
        newProduct.CategoryId = (pickCategory.SelectedItem as Category).Id;
        newProduct.Id = _id;
        if (_id == 0 )
        {
            _repo.Create(newProduct);
            await DisplayAlert("Information", "Your product is Added", "done");
        }
        else
        {
            _repo.Edit(newProduct);
            await DisplayAlert("Information", "Your product is Edited", "done");
            btnAdd.Text = "Add";

        }
        _id = 0;
        lstProducts.ItemsSource = _repo.GetAll();


        

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
                var Action = await DisplayAlert("Information", "Choose Your Action", "Edit", "Delete");
                var product = _repo.GetById(item.Id);
                if (Action)
                {
                    txtPName.Text = product.Name;
                    txtPPrice.Text = product.Price;
                    txtPCount.Text = product.Count;
                    var category = _cateRepo.GetCategoryById(product.CategoryId);
                    pickCategory.SelectedItem = category;
                    pickCategory.SelectedIndex = (pickCategory.ItemsSource as List<Category>).IndexOf(category);
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
