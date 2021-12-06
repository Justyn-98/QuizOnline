using QuizOnlineApp.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class ProfileViewModel: BaseViewModel, IAsyncInitialization
    {
        private IProfileGetter ProfileGetter = DependencyService.Get<IProfileGetter>();
        private ISignInService SignInService = DependencyService.Get<ISignInService>();
        private string username;
        private string rankPoints;
        private string rankGames;
        private string accountCreatedAt;
        private Task Initialization { get; set; }
        public ProfileViewModel()
        {
            Title = "User Profile";
            Initialization = InitializeAsync();
        }
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string RankPoints
        {
            get => rankPoints;
            set => SetProperty(ref rankPoints, value);
        }

        public string RankGames
        {
            get => rankGames;
            set => SetProperty(ref rankGames, value);
        }

        public string AccountCreatedAt
        {
            get => accountCreatedAt;
            set => SetProperty(ref accountCreatedAt, value);
        }
        public async Task InitializeAsync()
        {
            try
            {
                var userId = SignInService.GetLoggedUserId();
                var loggedUserProfile = await ProfileGetter.GetUserProfile(userId);

                Username = loggedUserProfile.Name;
                RankGames = loggedUserProfile.RankGames.ToString();
                RankPoints = loggedUserProfile.RankPoints.ToString();
                AccountCreatedAt = loggedUserProfile.CreatedAt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }


    }
}
