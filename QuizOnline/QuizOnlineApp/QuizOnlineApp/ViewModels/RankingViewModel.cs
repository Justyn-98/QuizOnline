using QuizOnlineApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    class RankingViewModel : BaseViewModel
    {
        Command OpenRankingCommand;
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
