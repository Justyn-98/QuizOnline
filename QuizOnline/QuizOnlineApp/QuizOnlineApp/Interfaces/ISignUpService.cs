using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface ISignUpService
    {
        Task<string> SignUp(string email, string password);
    }
}
