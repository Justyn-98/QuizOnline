using QuizOnlineApp.Models;

namespace QuizOnlineApp.Interfaces
{
    public interface IDatabaseContext
    {
        IDataRepository<Item> ItemsRepository { get; }
        IDataRepository<UserProfile> ProfilesRepository { get; }
    }
}
