using Firebase.Auth;
using QuizOnlineApp.Droid.Authentication;
using QuizOnlineApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseSignUpService))]
namespace QuizOnlineApp.Droid.Authentication
{
    public class FirebaseSignUpService : ISignUpService
    {
        public async Task<string> SignUp(string email, string password)
        {
            var authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
            var token = await authResult.User.GetIdTokenAsync(false);

            return token.ToString();
        }
    }
}