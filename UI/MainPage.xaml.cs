using System.Diagnostics;
using DataLayer.Interfaces;
using DataLayer.Services;
using UI.Windows.Person;
using UI.Windows.Product;
using Syncfusion.Maui.Charts;
using UI.Windows.Category;
using UI.Windows.ProductCategory;
using DataLayer.Entities;

namespace UI;

public partial class MainPage : ContentPage
{	
	

	public MainPage()
	{
		InitializeComponent();
        var list = Enumerable.Range(1, 10).Select(x => new Product { Name = x.ToString(), Price = Random.Shared.Next(100,250).ToString()}).ToList();
        chart.ItemsSource = list;
        
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
        await Navigation.PushAsync(new Products());
    }
}


