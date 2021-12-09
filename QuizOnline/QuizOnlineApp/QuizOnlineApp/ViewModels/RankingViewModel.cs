using QuizOnlineApp.ViewModels.Commmon;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class RankingViewModel : AuthorizedPageViewModel
    {
        public Command OpenRankingCommand;
        public RankingViewModel ()
        {
            Title = "Ranking";
            OpenRankingCommand = new Command(OnRankingClicked);
        }

        private async void OnRankingClicked (object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RankingPage)}");
        }
    }
}
