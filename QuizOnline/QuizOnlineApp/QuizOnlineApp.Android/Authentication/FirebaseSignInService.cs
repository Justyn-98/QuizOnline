using Firebase.Auth;
using QuizOnlineApp.Droid.Authentication;
using QuizOnlineApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseSignInService))]
namespace QuizOnlineApp.Droid.Authentication
{
    public class FirebaseSignInService : ISignInService
    {
        public async Task<string> SignIn(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = await authResult.User.GetIdTokenAsync(false);

            return token.ToString();
        }
        public void SignOut()
            => FirebaseAuth.Instance.SignOut();

        public bool IsSignIn()
          => FirebaseAuth.Instance.CurrentUser != null;
    }
}