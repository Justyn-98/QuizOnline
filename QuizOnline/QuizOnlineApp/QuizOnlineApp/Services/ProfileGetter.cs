using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using QuizOnlineApp.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProfileGetter))]
namespace QuizOnlineApp.Services
{
    public class ProfileGetter : IProfileGetter
    {
        private readonly IDatabaseContext DatabaseContext = DependencyService.Get<IDatabaseContext>();
        public async Task<UserProfile> GetUserProfile(string userId)
        {
            IEnumerable<UserProfile> profiles = await DatabaseContext.ProfilesRepository.GetByConditionAsync(x => x.UserId == userId);
            
            return profiles.FirstOrDefault();
        }
    }
}
