using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface IPhotoUploader
    {
        Task<string> UploadPhotoFromGallery();
    }
}
