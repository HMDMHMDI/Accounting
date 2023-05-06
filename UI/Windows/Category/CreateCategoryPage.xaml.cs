namespace UI.Windows.Category;
using DataLayer.Interfaces;
using DataLayer.Services;
using DataLayer.Entities;

public partial class CreateCategoryPage : ContentPage
{
    private readonly ICategoryRepository _repo;
    private int _id = 0;

    public CreateCategoryPage()
    {
        _repo = new CategoryRepository();
        InitializeComponent();
    }

    async void btnShowData_Clicked(System.Object sender, System.EventArgs e)
    {
        await ShowData();
    }

    async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        DataLayer.Entities.Category newCategory = new();
        newCategory.Title = txtTitle.Text;
        newCategory.Id = _id;
        if (_id == 0)
        {
            _repo.Create(newCategory);
            await DisplayAlert("Information", "Your Data Added", "Done");
        }
        else
        {
            _repo.Edit(newCategory);
            await DisplayAlert("Information", "Your Data Edited", "Done");
            btnAdd.Text = "Add";
        }
        _id = 0;
        txtTitle.Text = string.Empty;
        await ShowData();
    }
    private async Task ShowData()
    {
        foreach (var item in _repo.GetCategories())
        {
            var ShouldEdit = await DisplayAlert(item.Id.ToString(), item.Title, "Actions", "Next");
            if (ShouldEdit)
            {
                var action = await DisplayAlert("Action", "Choose ur action.", "Edit", "Delete");
                var category = _repo.GetCategoryById(item.Id);
                if (action)
                {
                    txtTitle.Text = category.Title;
                    _id = category.Id;
                    return;
                }
                _repo.Delete(category);
                return;
            }
        }
    }
}
