using QuizOnlineApp.Models;
using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface ISignUpService
    {
        Task<AuthResult> SignUp(string email, string password);
    }
}
