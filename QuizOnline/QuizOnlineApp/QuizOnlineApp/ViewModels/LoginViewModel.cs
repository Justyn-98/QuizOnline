using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Views;
using System;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string email;
        private string password;
        public Command LoginCommand { get; }
        public Command CancelCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked, ValidateLogin);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateLogin()
        {
            return !string.IsNullOrWhiteSpace(email)
                          && !string.IsNullOrWhiteSpace(password);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async void OnLoginClicked()
        {
            var auth = DependencyService.Get<ISignInService>();

            try
            {
                await auth.SignIn(email, password);
            }
            catch (Exception)
            {
                await Shell.Current.DisplayAlert("Login", "Wrong email or password", "OK");
            }

            if (auth.IsSignIn())
            { 
                await Shell.Current.GoToAsync($"//{nameof(MainMenuPage)}");
                Toast.Show("You re logged in.");
            }
        }
    }
}
