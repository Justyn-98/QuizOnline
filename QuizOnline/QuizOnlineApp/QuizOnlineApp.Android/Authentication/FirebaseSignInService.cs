using Firebase.Auth;
using QuizOnlineApp.Common;
using QuizOnlineApp.Droid.Authentication;
using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseSignInService))]
namespace QuizOnlineApp.Droid.Authentication
{
    public class FirebaseSignInService : ISignInService
    {
        private const string INVALID_CREDENTIALS_MESSAGE = "Wrong email or password.";
        private const string UNKNOW_AUTH_ERROR_MESSAGE = "Application error.";

        public async Task<IServiceResponse<string>> SignIn(string email, string password)
        {
            try
            {
                IAuthResult authResult = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                GetTokenResult token = await authResult.User.GetIdTokenAsync(false);

                return ServiceResponse<string>.Ok(token.Token);
            }
            catch (FirebaseAuthException exception)
            {
                if(exception is FirebaseAuthInvalidCredentialsException || exception is FirebaseAuthInvalidUserException)
                {
                    return ServiceResponse<string>.Error(INVALID_CREDENTIALS_MESSAGE);
                }

                return ServiceResponse<string>.Error(UNKNOW_AUTH_ERROR_MESSAGE);
            }
        }

        public void SignOut()
            => FirebaseAuth.Instance.SignOut();

        public bool IsSignIn()
          => FirebaseAuth.Instance.CurrentUser != null;

        public string GetLoggedUserId()
            => FirebaseAuth.Instance.Uid;
    }
}