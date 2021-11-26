using QuizOnlineApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class MainMenuViewModel : BaseViewModel
    {
        Command OpenMainMenuCommand;
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