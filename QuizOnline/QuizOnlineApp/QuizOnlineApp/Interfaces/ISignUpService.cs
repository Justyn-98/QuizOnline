using QuizOnlineApp.Models;
using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface ISignUpService
    {
        Task<SignUpResult> SignUp(string email, string password);
    }
}
