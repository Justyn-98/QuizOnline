using QuizOnlineApp.Services;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string email;
        private string password;
        private string confirmPassword;
        protected IBasicAuthentication auth => DependencyService.Get<IBasicAuthentication>();

        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked, ValidateRegister);
            CancelCommand = new Command(OnCancel);
            PropertyChanged += (_, __) => RegisterCommand.ChangeCanExecute();
        }

        private bool ValidateRegister()
        {
            return true;
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

        public string ConfirmPasssword
        {
            get => confirmPassword;
            set => SetProperty(ref confirmPassword, value);
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnRegisterClicked()
        {
            await auth.Register(Email, Password);

            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
        }
    }
}
