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
        private readonly ISignInService SignInService = DependencyService.Get<ISignInService>();
        private readonly IPhotoUploader PhotoUploader = DependencyService.Get<IPhotoUploader>();
        private readonly IDatabaseContext DbContext = DependencyService.Get<IDatabaseContext>();

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
            try
            {
             var path = await PhotoUploader.UploadPhotoFromGallery();
                string userId = SignInService.GetLoggedUserId();
                UserProfile loggedUserProfile = await ProfileGetter.GetUserProfile(userId);
                loggedUserProfile.ProfilePhoto = path;
                await DbContext.ProfilesRepository.UpdateAsync(loggedUserProfile);
            }
            catch(Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");

            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void EditName()
        {
            IsBusy = true;
            try
            {
                var newNAme = await Application.Current.MainPage.DisplayPromptAsync("Input name"," type in your new name");
                string userId = SignInService.GetLoggedUserId();
                UserProfile loggedUserProfile = await ProfileGetter.GetUserProfile(userId);
                loggedUserProfile.Name = newNAme;
                await DbContext.ProfilesRepository.UpdateAsync(loggedUserProfile);
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
    }
}
