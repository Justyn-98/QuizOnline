using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(PasswordValidator))]
namespace QuizOnlineApp.Services
{
    public class PasswordValidator : IPasswordValidator
    {
        private const int MIN_SIZE = 6;

        public string GetValidationAlert(string password, string confirmPassword)
        {
            var validationAllert = "";

            if (!string.IsNullOrWhiteSpace(password) && password.Length < MIN_SIZE)
            {
                validationAllert += "Password must contains at least " + MIN_SIZE + " characters. ";
            }

            if (!string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(confirmPassword) && !string.Equals(password, confirmPassword))
            {
                validationAllert += "Password and confirm password does not match. ";
            }

            return validationAllert;
        }

        public bool GetResult(string password, string confirmPassword)
        {
            return !string.IsNullOrWhiteSpace(password)
                && password.Length >= MIN_SIZE
           && string.Equals(password, confirmPassword);
        }
    }
}
