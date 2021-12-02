using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Services;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            var auth = DependencyService.Get<ISignInService>();
            if (auth.IsSignIn())
            {
                MainPage = new LoginPage();

            }
            else
            {
                MainPage = new AppShell();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
