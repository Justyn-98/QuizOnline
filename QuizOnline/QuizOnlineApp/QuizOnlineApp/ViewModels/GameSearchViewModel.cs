using QuizOnlineApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    class GameSearchViewModel : BaseViewModel
    {
        Command OpenGameSearchCommand;

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
