using QuizOnlineApp.Services;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        protected IBasicAuthentication auth => DependencyService.Get<IBasicAuthentication>();

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
