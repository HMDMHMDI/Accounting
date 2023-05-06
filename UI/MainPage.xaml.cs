using System.Diagnostics;
using DataLayer.Interfaces;
using DataLayer.Services;
using UI.Windows.Person;
using UI.Windows.Product;
using UI.Windows.Category;
namespace UI;

public partial class MainPage : ContentPage
{	
	

	public MainPage()
	{
		InitializeComponent();
	}

	

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new CreatePersonPage());
    }

    async void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
		await Navigation.PushAsync(new CreateProductPage());
    }

    async void Button_Clicked_2(System.Object sender, System.EventArgs e)
    {
        await Navigation.PushAsync(new CreateCategoryPage());
    }
}


