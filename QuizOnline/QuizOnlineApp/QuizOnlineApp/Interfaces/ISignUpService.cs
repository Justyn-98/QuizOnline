using QuizOnlineApp.Models;
using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface ISignUpService
    {
        Task<IServiceResponse<string>> SignUp(string email, string password);
    }
}
