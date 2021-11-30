using QuizOnlineApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    class ProfileViewModel: BaseViewModel
    {
        Command OpenProfileCommand;

        public ProfileViewModel ()
        {
            Title = "Profile";
            OpenProfileCommand = new Command(OnProfileClicked);
        }

        private async void OnProfileClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(ProfilePage)}");
        }
    }
}
