using QuizOnlineApp.Interfaces;
using Xamarin.Forms;

namespace QuizOnlineApp
{
    public partial class App : Application
    {
        private IAppAuthorizationService AuthorizationService = DependencyService.Get<IAppAuthorizationService>();
        public App()
        {
            InitializeComponent();
        }

        protected override void OnStart()
        {
            AuthorizationService.AuthorizeApplication();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            AuthorizationService.AuthorizeApplication();
        }
    }
}
