using QuizOnlineApp.Views;

using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        public Command OpenMainMenuCommand;
        public MainMenuViewModel()
        {
            Title = "Main Menu";
            OpenMainMenuCommand = new Command(OnMainMenuClicked);
        }

        private async void OnMainMenuClicked (object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(MainMenuPage)}");
        }
    }
}