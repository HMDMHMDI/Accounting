namespace UI;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		var navpage = new NavigationPage(new MainPage());
		navpage.BarBackgroundColor = Colors.Red;
		MainPage = navpage;
	}

}

