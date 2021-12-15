using Firebase.Auth;
using QuizOnlineApp.Common;
using QuizOnlineApp.Droid.Authentication;
using QuizOnlineApp.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseSignUpService))]
namespace QuizOnlineApp.Droid.Authentication
{
    public class FirebaseSignUpService : ISignUpService
    {
        public async Task<IServiceResponse<string>> SignUp(string email, string password)
        {
            try
            {
                IAuthResult authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                GetTokenResult token = await authResult.User.GetIdTokenAsync(false);

                return ServiceResponse<string>.Ok(authResult.User.Uid);
            }
            catch (FirebaseAuthException ex) {
                return ServiceResponse<string>.Error(ex.Message);
            }
        }
    }
}