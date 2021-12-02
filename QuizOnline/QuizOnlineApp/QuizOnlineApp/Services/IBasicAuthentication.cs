using System.Threading.Tasks;

namespace QuizOnlineApp.Services
{
    public interface IBasicAuthentication
    {
        Task<string> Login(string email, string password);
        Task<string> Register(string email, string password);
    }
}
