using DataLayer.Interfaces;
using DataLayer.Services;
using DataLayer.Entities;
using UI.Windows.Person;

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
		if(_id == 0)
		{

		_repo.Create(newPerson);
		await DisplayAlert("Done.", "The person was added.", "Ok");
		}
		else
		{
			_repo.Edit(newPerson);
            await DisplayAlert("Done.", "The person was edited.", "Ok");
			btnAdd.Text = "Add";

        }
		_id = 0;
		txtFName.Text = string.Empty;
		txtLName.Text = string.Empty;
		txtPhoneNumber.Text = string.Empty;
        clcPerson.ItemsSource = _repo.GetAll();

        await ShowData();

    }

    async void btnShowData_Clicked(System.Object sender, System.EventArgs e)
    {
		await ShowData();
    }

	//async void that returns nothign is task
	//async method that retusn something is Task<string> Task<int>

	private async Task ShowData()
	{
        foreach (var item in _repo.GetAll())
        {
			//Wnen accept parameter is passed the display alert retuns a boolean if accept true else false.
			var shouldEdit = await DisplayAlert(item.Id.ToString(), item.FName + " " + item.LName + " \n " + item.PhoneNumber, "Actions","Next");

			  
			
			if (shouldEdit)
			{
				var action = await DisplayAlert("Action", "Choose ur action.", "Edit", "Delete");

                 var person = _repo.GetById(item.Id);
				if (action)
				{
                    txtFName.Text = person.FName;
                    txtLName.Text = person.LName;
                    txtPhoneNumber.Text = person.PhoneNumber;
                    btnAdd.Text = "Edit";
                    _id = person.Id;
					return;
                }
				
				_repo.Delete(person);
				return;
				//Reduced out if else chain زنجیر
			}

        }
    }
}
