using QuizOnlineApp.Models;
using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface IProfileGetter
    {
        Task<UserProfile> GetUserProfile(string userId);
    }
}
