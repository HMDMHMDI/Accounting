namespace UI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		var navpage = new NavigationPage(new MainPage());
		navpage.BarBackground = Colors.Chocolate;
		navpage.BarTextColor = Colors.White;
		MainPage = navpage;
	}

}

