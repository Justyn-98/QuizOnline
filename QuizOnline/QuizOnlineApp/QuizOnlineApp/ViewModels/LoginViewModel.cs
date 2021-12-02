using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Views;
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
            LoginCommand = new Command(OnLoginClicked);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => LoginCommand.ChangeCanExecute();
        }

        private bool ValidateRegister()
        {
            return !string.IsNullOrWhiteSpace(email)
                && !string.IsNullOrWhiteSpace(password);
        }

        private async void OnCancel(object obj)
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

        private async void OnLoginClicked(object obj)
        {
            var auth = DependencyService.Get<ISignInService>();
            var token = await auth.SignIn(email, password);

            if(token != null)
            {
                await Shell.Current.GoToAsync($"//{nameof(MainMenuPage)}");
                Toast.Show("You re logged in.");
            }
            else
            {
                await Shell.Current.DisplayAlert("SignIn", "Wrong email or password", "OK");
            }
        }
    }
}
