using DataLayer.Interfaces;
using DataLayer.Services;

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
			Id = 0,
			Title = "Salam"
		});

		categories = repo.GetCategories();
	}
}


