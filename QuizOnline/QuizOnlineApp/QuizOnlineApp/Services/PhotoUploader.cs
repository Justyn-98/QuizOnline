
using Plugin.Media;
using Plugin.Media.Abstractions;
using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Services;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(PhotoUploader))]
namespace QuizOnlineApp.Services
{
    public class PhotoUploader : IPhotoUploader
    {
        public async Task<string> UploadPhotoFromGallery()
        {
            _ = await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile file = await  CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Full,
                    CompressionQuality = 40,
                });
                byte[] imageArray = File.ReadAllBytes(file.Path);

                string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var filePath = Path.Combine(folder, Guid.NewGuid().ToString());

                if (File.Exists(filePath))
                    File.Delete(filePath);

                File.WriteAllBytes(filePath, imageArray);

                return filePath;
            }
            return "";
        }
    }
}