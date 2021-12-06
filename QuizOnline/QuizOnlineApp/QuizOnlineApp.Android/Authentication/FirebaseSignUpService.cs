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
        public async Task<SignUpResult> SignUp(string email, string password)
        {
            try
            {
                var authResult = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                GetTokenResult token = await authResult.User.GetIdTokenAsync(false);

                return await Task.FromResult(new SignUpResult
                {
                    UserId = authResult.User.Uid,
                    Token = token.Token
                });

            }
            catch (Exception ex) {
                Toast.MakeText(Android.App.Application.Context, ex.Message, ToastLength.Long).Show();
                throw new Exception();
            }

        }
    }
}