using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string userName;
        private string email;
        private string password;
        private string confirmPassword;
        private string validationAlert;

        public Command RegisterCommand { get; }
        public Command CancelCommand { get; }

        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked, ValidateRegister);
            CancelCommand = new Command(OnCancel);
            validationAlert = "";
            PropertyChanged += (_, __) => RegisterCommand.ChangeCanExecute();
        }

        private bool ValidateRegister()
        {
            var validator = DependencyService.Get<IPasswordValidator>();

            Device.BeginInvokeOnMainThread(() =>
            {
                ValidationAlert = validator.GetValidationAlert(password, confirmPassword);
            }); 

            return validator.GetResult(password, confirmPassword);
        }

        public string Username
        {
            get => userName;
            set => SetProperty(ref userName, value);
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
        public string ValidationAlert
        {
            get => validationAlert;
            set
            {
                validationAlert = value;
                OnPropertyChanged(nameof(ValidationAlert));
            }
        }

        private void OnCancel()
        {
            Application.Current.MainPage = new LoginPage();
        }

        private async void OnRegisterClicked()
        {
            ISignUpService signInService = DependencyService.Get<ISignUpService>();
            IProfileCreator profileCreaotr = DependencyService.Get<IProfileCreator>();
            IAppAuthorizationService authorizationService = DependencyService.Get<IAppAuthorizationService>();

            SignUpResult result = await signInService.SignUp(Email, Password);
            _ = await profileCreaotr.Create(result.UserId, Username);
            authorizationService.AuthorizeApplication();
            Toast.Show("Account created. You can sign in now.");
        }
    }
}
