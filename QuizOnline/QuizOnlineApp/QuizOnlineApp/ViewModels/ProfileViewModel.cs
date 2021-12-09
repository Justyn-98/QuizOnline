using QuizOnlineApp.ViewModels.Commmon;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class ProfileViewModel: AuthorizedPageViewModel
    {
        public Command OpenProfileCommand;
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
