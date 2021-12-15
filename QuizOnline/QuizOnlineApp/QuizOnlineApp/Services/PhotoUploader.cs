using Plugin.Media;
using Plugin.Media.Abstractions;
using QuizOnlineApp.Common;
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
        public async Task<IServiceResponse<string>> UploadPhotoFromGallery()
        {
            _ = await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsPickPhotoSupported)
            {
                MediaFile file = await  CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Full,
                    CompressionQuality = 40,
                });

                if(file == null)
                {
                    return ServiceResponse<string>.Error("Image not selected");
                }

                byte[] imageArray = File.ReadAllBytes(file.Path);

                string folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string filePath = Path.Combine(folder, Guid.NewGuid().ToString());

                File.WriteAllBytes(filePath, imageArray);

                return ServiceResponse<string>.Ok(filePath);
            }

            return ServiceResponse<string>.Error("Pick up photo is not supported on your device.");
        }
    }
}