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

        private void OnCancel()
        {
            Application.Current.MainPage = new RegisterPage();
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
            ISignInService auth = DependencyService.Get<ISignInService>();

            var result = await auth.SignIn(email, password);

            if (result.Success)
            {
                Application.Current.MainPage = new AppShell();
                Toast.Show("You re logged in.");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Login", result.Message, "OK");
            }
        }
    }
}
