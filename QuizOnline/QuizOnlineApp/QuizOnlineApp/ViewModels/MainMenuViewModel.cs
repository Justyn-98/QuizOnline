using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Views;

using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public Command OpenMainMenuCommand;
        public MainMenuViewModel()
        {
            var auth = DependencyService.Get<ISignInService>();
            if (auth.IsSignIn())
            {
                 Shell.Current.GoToAsync($"//{nameof(LoginPage)}").Wait();

            }
            Title = "Main Menu";
            OpenMainMenuCommand = new Command(OnMainMenuClicked);
        }

        private async void OnMainMenuClicked (object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainMenuPage)}");
        }
    }
}