using Firebase.Database;
using Firebase.Database.Query;
using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizOnlineApp.Services
{
    public class MockDataStore : IDataStore<Item>
    {

       private readonly FirebaseClient firebaseClient = new FirebaseClient("https://quizonline-ed972-default-rtdb.firebaseio.com/");

        public async Task<bool> AddItemAsync(Item item)
        {
            await firebaseClient
              .Child("Items")
              .PostAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var toUpdateItem = (await firebaseClient
                .Child("Items")
                .OnceAsync<Item>()).Where(a => a.Object.Id == item.Id).FirstOrDefault();

            await firebaseClient
              .Child("Items")
              .Child(toUpdateItem.Key)
              .PutAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var toDeletePerson = (await firebaseClient
              .Child("Items")
              .OnceAsync<Item>()).Where(a => a.Object.Id == id).FirstOrDefault();
                        await firebaseClient.Child("Items").Child(toDeletePerson.Key).DeleteAsync();

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            var list = (await firebaseClient
                 .Child("Items")
                 .OnceAsync<Item>()).Select(item => new Item
                 {
                     Text = item.Object.Text,
                     Id = item.Object.Id,
                     Description = item.Object.Description
                 }).ToList();

            return await Task.FromResult(list.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var list = (await firebaseClient
            .Child("Items")
            .OnceAsync<Item>()).Select(item => new Item
            {
                Text = item.Object.Text,
                Id = item.Object.Id,
                Description = item.Object.Description
            }).ToList();

            return await Task.FromResult(list);
        }
    }
}