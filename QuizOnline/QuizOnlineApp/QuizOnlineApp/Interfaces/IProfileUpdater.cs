using QuizOnlineApp.Models;
using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface IProfileUpdater
    {
        Task<IServiceResponse<string>> UpdateProfilePhoto(string userId);
        Task<IServiceResponse> UpdateUserName(string userId, string newUserName);
    }
}
