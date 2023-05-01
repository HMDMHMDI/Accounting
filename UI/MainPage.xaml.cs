using System.Diagnostics;
using DataLayer.Interfaces;
using DataLayer.Services;
using UI.Windows.Person;

namespace UI;

public partial class MainPage : ContentPage
{	
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		ICategoryRepository repo = new CategoryRepository();
		var categories = repo.GetCategories();
		repo.Create(new DataLayer.Entities.Category()
		{
			Id = 0, //if u pass id which is not 0 is will throw and exception
			Title = txtCategory.Text
		});

		categories = repo.GetCategories();
		foreach (var item in categories)
		{
			Debug.Write(item.Title);
		}
	}

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushModalAsync(new CreatePersonPage());
    }
}


