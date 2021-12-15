using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Services;
using QuizOnlineApp.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppAuthorizationService))]
namespace QuizOnlineApp.Services
{
    public class AppAuthorizationService : IAppAuthorizationService
    {
        public void AuthorizeApplication()
        {
            ISignInService signInService = DependencyService.Get<ISignInService>();

            if (signInService.IsSignIn())
            {
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                Application.Current.MainPage = new LoginPage();
            }
        }
    }
}
