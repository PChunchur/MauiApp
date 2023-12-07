namespace Lets_Try;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new LoginPage());
        
    }
}