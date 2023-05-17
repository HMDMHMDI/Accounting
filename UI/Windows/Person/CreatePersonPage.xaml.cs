using DataLayer.Interfaces;
using DataLayer.Services;
using DataLayer.Entities;
using UI.Windows.Person;
using Business.People;
using static System.Net.Mime.MediaTypeNames;

namespace UI.Windows.Person;

public partial class CreatePersonPage : ContentPage
{
    private readonly IPersonRepository _repo;
    CollectionView CollectionView = new();
    private int _id = 0;
    public CreatePersonPage()
    {
        InitializeComponent();
        _repo = new PersonRepository();
        clcPerson.ItemsSource = _repo.GetAll();
    }

    async void btnAdd_Clicked(System.Object sender, System.EventArgs e)
    {
        DataLayer.Entities.Person newPerson = new();
        newPerson.FName = txtFName.Text;
        newPerson.LName = txtLName.Text;
        newPerson.PhoneNumber = txtPhoneNumber.Text;
        newPerson.Id = _id;
        if (_id == 0)
        {
            CreateNewPerson command = new CreateNewPerson(newPerson, _repo);
            var res = command.Create(newPerson);
            switch (res)
            {
                case -1:
                    await DisplayAlert("Information", "Please Enter Value", "Done");
                    return;
                case -2:
                    await DisplayAlert("Information", "You want to edit? go to edit section", "Done");
                    return;
            }
            await DisplayAlert("Information", "Your Data Added", "Done");

        }
        else
        {
            DataLayer.Entities.Person person = new();
            EditPeople edit = new EditPeople(person, _repo);
            person.PhoneNumber = txtPhoneNumber.Text;
            person.LName = txtLName.Text;
            person.FName = txtFName.Text;
            person.Id = _id;
            var res = edit.Edit(person);
            switch (res)
            {
                case -1:
                    await DisplayAlert("Information", "Go To Create Section", "Done");
                    return;
            }
            await DisplayAlert("Information", "Your Data Edited", "Done");
            btnAdd.Text = "Add";

        }
        _id = 0;
        txtFName.Text = string.Empty;
        txtLName.Text = string.Empty;
        txtPhoneNumber.Text = string.Empty;
        clcPerson.ItemsSource = _repo.GetAll();


    }

    void btnEdit_Clicked(System.Object sender, System.EventArgs e)
    {
        btnAdd.Text = "Edit";
        _id = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
        var get = _repo.GetById(_id);
        txtFName.Text = get.FName;
        txtLName.Text = get.LName;
        txtPhoneNumber.Text = get.PhoneNumber;
        _id = get.Id;
    }
    async void btnDelete_Clicked(System.Object sender, System.EventArgs e)
    {
        int _id = Convert.ToInt32(((SwipeItem)sender).CommandParameter);
        var get = _repo.GetById(_id);
        DeletePeople delete = new DeletePeople(get, _repo);
        var Confirm = await DisplayAlert("Information", "You Want to Delete This Category?", "Yes", "No");
        if (Confirm)
        {
            var res = delete.Delete(get);
            switch (res)
            {
                case -1:
                    await DisplayAlert("Information", "Doesnt Exist!", "Done");
                    return;
            }
            await DisplayAlert("Information", "Your Data Deleted", "Done");
            
        }
    }
}
