using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface IPhotoUploader
    {
        Task<IServiceResponse<string>> UploadPhotoFromGallery();
    }
}
