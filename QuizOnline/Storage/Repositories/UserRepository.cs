using Firebase.Database.Query;
using Storage.DataAccessLayer;
using Storage.Interfaces;
using Storage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;
        public UserRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<List<AppUser>> GetAllUsers()
        {

            return (await _context.firebaseClient
              .Child("Users")
              .OnceAsync<AppUser>()).Select(item => new AppUser
              {
                  Name = item.Object.Name,
                  Id = item.Object.Id
              }).ToList();
        }

        public async Task CreateUser(string name)
        {
            await _context.firebaseClient
              .Child("Users")
              .PostAsync(new AppUser() { Id =  GetAllUsers().Result.Count + 1, Name = name });
        }

        public async Task<AppUser> GetPerson(int personId)
        {
            var allPersons = await GetAllUsers();
            await _context.firebaseClient
              .Child("Users")
              .OnceAsync<AppUser>();
            return allPersons.Where(a => a.Id == personId).FirstOrDefault();
        }

        public async Task UpdateUser(int personId, string name)
        {
            var toUpdatePerson = (await _context.firebaseClient
              .Child("Users")
              .OnceAsync<AppUser>()).Where(a => a.Object.Id == personId).FirstOrDefault();

            await _context.firebaseClient
              .Child("Users")
              .Child(toUpdatePerson.Key)
              .PutAsync(new AppUser() { Id = personId, Name = name });
        }

        public async Task DeleteUser(int id)
        {
            var toDeletePerson = (await _context.firebaseClient
              .Child("Users")
              .OnceAsync<AppUser>()).Where(a => a.Object.Id == id).FirstOrDefault();
            await _context.firebaseClient.Child("Users").Child(toDeletePerson.Key).DeleteAsync();

        }
    }
}

