namespace UI.Windows.Category;
using DataLayer.Interfaces;
using DataLayer.Services;
using DataLayer.Entities;
using Business.Category;
//using Android.Icu.Text;

//using static Android.Content.ClipData;

public partial class CreateCategoryPage : ContentPage
{
    //private readonly ICategoryRepository _repo;
    private int _id = 0;

    public CreateCategoryPage()
    {
    //    _repo = new CategoryRepository();
        InitializeComponent();
    //    clcCategory.ItemsSource = _repo.GetCategories();
    }

    //void btnEdit_clicked(System.Object sender, System.EventArgs e)
    //{
    //    btnAdd.Text = "Edit";
    //    _id = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
    //    var get = _repo.GetCategoryById(_id);
    //    txtTitle.Text = get.Title;
    //    get.Id = _id;
        
    //}
    //async void btnDelete_Clicked(System.Object sender, System.EventArgs e)
    //{
    //    //DataLayer.Entities.Category category = new();
    //    int _id = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
    //    var get = _repo.GetCategoryById(_id);
    //    DeleteCategory delete = new DeleteCategory(get , _repo);
        
    //    var Confirm = await DisplayAlert("Information", "You Want to Delete This Category?", "Yes", "No");
    //    if (Confirm)
    //    {
    //        var res = delete.Delete(get);
    //        switch (res)    
    //        {
    //            case -1:
    //                await DisplayAlert("Information", "Your Data Doesnt exist", "Done");
    //                return;
    //        }
    //        await DisplayAlert("Information", "Your Data deleted", "Done");
    //    }



    //}
    //async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    //{
    //    DataLayer.Entities.Category newCategory = new();
    //    newCategory.Title = txtTitle.Text;
    //    newCategory.Id = _id;
    //    if (_id == 0)
    //    {
    //        CreateNewCategory command = new CreateNewCategory(newCategory, _repo);
    //        var res = command.Do();
    //        switch (res)
    //        {
    //            case -1:
    //                await DisplayAlert("Error", "Please enter title.", "Done.");
    //                return;
    //            case -2:
    //                await DisplayAlert("Error", "Id is not valid", "Done.");
    //                return;
    //        }
    //        await DisplayAlert("Information", "Your Data Added", "Done");
    //    }
    //    else
    //    {
    //        DataLayer.Entities.Category category = new();

    //        EditCategory edit = new EditCategory(category, _repo);
    //        category.Title = txtTitle.Text;
    //        category.Id = _id;
    //        var res = edit.Edit(category);


    //        switch (res)
    //        {
    //            case -2:
    //                await DisplayAlert("Error", "You want to Create Category? Go To Add Section", "Done");
    //                return;
    //        }
    //        await DisplayAlert("Information", "Your data Edited", "Done");

            
    //    }
    //    _id = 0;

    //    clcCategory.ItemsSource = _repo.GetCategories();

    //    txtTitle.Text = string.Empty;
    //}

    
}
