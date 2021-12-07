using Android.Widget;
using Firebase.Auth;
using QuizOnlineApp.Droid.Authentication;
using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseSignUpService))]
namespace QuizOnlineApp.Droid.Authentication
{
    public class FirebaseSignUpService : ISignUpService
    {
        public async Task<AuthResult> SignUp(string email, string password)
        {
            try
            {
                var authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                GetTokenResult token = await authResult.User.GetIdTokenAsync(false);

                return AuthResult.Ok(token.Token, authResult.User.Uid);
            }
            catch (FirebaseAuthException ex) {
                return AuthResult.Error(ex.Message);
            }
        }
    }
}