using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Views;
using Xamarin.Forms;

namespace QuizOnlineApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
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

        public string ValidationAlert
        {
            get => validationAlert; 
            set
            {
                validationAlert = value;
                OnPropertyChanged(nameof(ValidationAlert)); 
            }
        }
        private async void OnRegisterClicked()
        {
            var auth = DependencyService.Get<ISignUpService>();
            await auth.SignUp(Email, Password);
            await Shell.Current.GoToAsync($"//{nameof(MainMenuPage)}");
            Toast.Show("Account created. You can sign in now.");
        }
    }
}
