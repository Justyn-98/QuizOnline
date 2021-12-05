using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class GameSearchViewModel : BaseViewModel
    {
        public Command OpenGameSearchCommand;

        public GameSearchViewModel ()
        {
            OpenGameSearchCommand = new Command(OnGameSearchClicked);
        }

        private async void OnGameSearchClicked (object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(GameSearchPage)}");
        }
    }
}
