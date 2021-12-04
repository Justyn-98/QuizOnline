using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels.Commmon
{
    public abstract class AuthorizedPageViewModel : BaseViewModel
    {
        protected ISignInService SignInService => DependencyService.Get<ISignInService>();

        public AuthorizedPageViewModel()
        {
            CheckCanDisplay().Wait();
        }

        private async Task CheckCanDisplay()
        {
            if (SignInService.IsSignIn())
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
        }
    }
}
