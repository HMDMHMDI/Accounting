namespace UI.Windows.ProductCategory;
using DataLayer.Entities;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Views;

public partial class Products : ContentPage
{
	public Products()
	{
		InitializeComponent();
        var list = Enumerable.Range(1, 10).Select(x => new Product { Name = x.ToString(), Price = Random.Shared.Next(100, 250).ToString() }).ToList();
        chart.ItemsSource = list;
    }
    private void Button_Clicked(object sender,EventArgs e)
    {
        this.ShowPopup(new PopupCreateProducts());
    }
}
