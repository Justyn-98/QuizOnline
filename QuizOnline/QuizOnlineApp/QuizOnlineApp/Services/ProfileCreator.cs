using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using QuizOnlineApp.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProfileCreator))]
namespace QuizOnlineApp.Services
{
    public sealed class ProfileCreator : IProfileCreator
    {
        private const int DEAFAULT_START_RANK_POINTS = 1000;
        private const int DEAFAULT_START_RANK_GAMES = 0;

        private readonly IDatabaseContext DataStore = DependencyService.Get<IDatabaseContext>();
        private readonly IDateTimeGetter DateTimeGetter = DependencyService.Get<IDateTimeGetter>();

        public async Task<bool> Create(string userId, string userName)
        {
            await DataStore.ProfilesRepository.AddAsync(new UserProfile
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Name = userName,
                RankPoints = DEAFAULT_START_RANK_POINTS,
                RankGames = DEAFAULT_START_RANK_GAMES,
                CreatedAt = DateTimeGetter.Now.ToString(),
                UpdatedAt = DateTimeGetter.Now.ToString()
            });

            return await Task.FromResult(true);
        }
    }
}
