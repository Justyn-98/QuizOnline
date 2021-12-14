using Firebase.Database;
using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using QuizOnlineApp.Services.DataAccessLayer;
using QuizOnlineApp.Services.DataAccessLayer.Repositories;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseDbContext))]

namespace QuizOnlineApp.Services.DataAccessLayer
{
    public class FirebaseDbContext : IDatabaseContext
    {
        public FirebaseClient Client => new FirebaseClient("https://quizonline-ed972-default-rtdb.firebaseio.com/");
        public IDataRepository<Item> ItemsRepository => new FirebaseRepository<Item>(Client);
        public IDataRepository<UserProfile> ProfilesRepository => new FirebaseRepository<UserProfile>(Client);


    }
}
