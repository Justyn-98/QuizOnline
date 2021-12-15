using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class ProfileViewModel: BaseViewModel
    {
        private readonly IProfileGetter ProfileGetter = DependencyService.Get<IProfileGetter>();
        private readonly IProfileUpdater ProfileUpdater = DependencyService.Get<IProfileUpdater>();
        private readonly ISignInService SignInService = DependencyService.Get<ISignInService>();

        private string username;
        private string rankPoints;
        private string rankGames;
        private string accountCreatedAt;
        private ImageSource profilePhoto;

        public Command RefreshProfileCommand { get; }
        public Command ChangeProfilePhotoCommand { get; }
        public Command EditNameCommand { get; }

        public ProfileViewModel()
        {
            Title = "User Profile";
            RefreshProfileCommand = new Command(async () => await RefreshProfile());
            ChangeProfilePhotoCommand = new Command(ChangeProfilePhoto);
            EditNameCommand = new Command(EditName);
        }

        public void OnAppearing()
        {
            IsBusy = true;
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
        public ImageSource ProfilePhoto
        {
            get => profilePhoto;
            set => SetProperty(ref profilePhoto, value);
        }

        public async Task RefreshProfile()
        {
            IsBusy = true;
            try
            {
                string userId = SignInService.GetLoggedUserId();
                UserProfile loggedUserProfile = await ProfileGetter.GetUserProfile(userId);
                ProfilePhoto = loggedUserProfile.ProfilePhoto == null ? ImageSource.FromFile("basic_profile_photo.png") : ImageSource.FromFile(loggedUserProfile.ProfilePhoto);
                Username = loggedUserProfile.Name;
                RankGames = loggedUserProfile.RankGames.ToString();
                RankPoints = loggedUserProfile.RankPoints.ToString();
                AccountCreatedAt = loggedUserProfile.CreatedAt;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void ChangeProfilePhoto()
        {
            IsBusy = true;
            string userId = SignInService.GetLoggedUserId();
            _ = await ProfileUpdater.UpdateProfilePhoto(userId);
            IsBusy = false;
        }

        public async void EditName()
        {
            IsBusy = true;
            string userId = SignInService.GetLoggedUserId();
            string newNAme = await Application.Current.MainPage.DisplayPromptAsync("Edit username"," type in your new name");
            IServiceResponse result = await ProfileUpdater.UpdateUserName(userId, newNAme);
            ShowResult(result);
            IsBusy = false;
        }
    }
}
