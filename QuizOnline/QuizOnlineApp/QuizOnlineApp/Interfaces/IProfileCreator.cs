using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface IProfileCreator
    {
        Task<bool> Create(string userId, string userName);
    }
}
