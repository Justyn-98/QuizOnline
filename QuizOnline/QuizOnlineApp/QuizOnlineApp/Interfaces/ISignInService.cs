using QuizOnlineApp.Models;
using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface ISignInService
    {
        Task<AuthResult> SignIn(string email, string password);
        void SignOut();
        bool IsSignIn();
        string GetLoggedUserId();
    }
}
