using QuizOnlineApp.Common;
using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using QuizOnlineApp.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(ProfileUpdater))]
namespace QuizOnlineApp.Services
{
    public class ProfileUpdater : IProfileUpdater
    {

        private readonly IPhotoUploader PhotoUploader = DependencyService.Get<IPhotoUploader>();
        private readonly IDatabaseContext DbContext = DependencyService.Get<IDatabaseContext>();
        private readonly IProfileGetter ProfileGetter = DependencyService.Get<IProfileGetter>();

        public async Task<IServiceResponse<string>> UpdateProfilePhoto(string userId)
        {
            try
            {
                UserProfile profile = await ProfileGetter.GetUserProfile(userId);
                string path = await PhotoUploader.UploadPhotoFromGallery();

                profile.ProfilePhoto = path;
                _ = await DbContext.ProfilesRepository.UpdateAsync(profile);

                return ServiceResponse<string>.Ok(path);
            }
            catch (Exception exception)
            {
                return ServiceResponse<string>.Error(exception.Message);
            }
        }

        public async Task<IServiceResponse> UpdateUserName(string userId, string newUserName)
        {
            try
            {
                UserProfile profile = await ProfileGetter.GetUserProfile(userId);
                profile.Name = string.IsNullOrWhiteSpace(newUserName) ? profile.Name : newUserName;
                _ = await DbContext.ProfilesRepository.UpdateAsync(profile);

                return ServiceResponse.Ok();
            }
            catch (Exception exception)
            {
                return ServiceResponse.Error(exception.Message);
            }
        }
    }
}
