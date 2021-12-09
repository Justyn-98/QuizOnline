using Android.Widget;
using QuizOnlineApp.Droid.Services;
using QuizOnlineApp.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastService))]
namespace QuizOnlineApp.Droid.Services
{
    public class ToastService : IToast
    {
        public void Show(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}