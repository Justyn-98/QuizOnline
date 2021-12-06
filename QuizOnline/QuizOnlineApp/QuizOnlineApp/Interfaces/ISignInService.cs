using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface ISignInService
    {
        Task<string> SignIn(string email, string password);
        void SignOut();
        bool IsSignIn();
        string GetLoggedUserId();
    }
}
