using Firebase.Auth;
using QuizOnlineApp.Droid;
using QuizOnlineApp.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthentication))]

namespace QuizOnlineApp.Droid
{
    public class FirebaseAuthentication : IBasicAuthentication
    {
        public async Task<string> Login(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
            var token = authResult.User.GetIdToken(false);

            return token.Result.ToString();
        }
        public async Task<string> Register(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = authResult.User.GetIdToken(false);

            return token.Result.ToString();
        }
    }
}