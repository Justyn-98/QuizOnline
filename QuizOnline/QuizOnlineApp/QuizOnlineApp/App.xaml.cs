using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        protected override void OnStart()
        {
            SetMainPage();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            SetMainPage();
        }

        private void SetMainPage()
        {
            ISignInService signInService = DependencyService.Get<ISignInService>();

            if(signInService.IsSignIn())
            {
                MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }
        }
    }
}
