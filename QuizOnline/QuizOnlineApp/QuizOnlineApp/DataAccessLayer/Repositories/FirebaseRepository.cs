using Firebase.Database;
using Firebase.Database.Query;
using QuizOnlineApp.Interfaces;
using QuizOnlineApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizOnlineApp.Services.DataAccessLayer.Repositories
{
    public class FirebaseRepository<T> : IDataRepository<T> where T : IPKModel
    {

        private readonly FirebaseClient _firebaseClient;
        private string _tableName;

        public FirebaseRepository(FirebaseClient firebaseClient)
        {
            _firebaseClient = firebaseClient;
            _tableName = typeof(T).Name + "s";
        }

        public async Task<bool> AddAsync(T model)
        {
           var savedModel = await _firebaseClient
              .Child(_tableName)
              .PostAsync(model);

            return  await Task.FromResult(savedModel != null);
        }

        public async Task<bool> UpdateAsync(T item)
        {
            var toUpdateItem = (await _firebaseClient
                .Child(_tableName)
                .OnceAsync<T>()).Where(a => a.Object.Id == item.Id).FirstOrDefault();

            await _firebaseClient
              .Child(_tableName)
              .Child(toUpdateItem.Key)
              .PutAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var toDeletePerson = (await _firebaseClient
              .Child(_tableName)
              .OnceAsync<T>()).Where(a => a.Object.Id == id).FirstOrDefault();
            await _firebaseClient.Child(_tableName).Child(toDeletePerson.Key).DeleteAsync();

            return await Task.FromResult(true);
        }

        public async Task<T> GetAsync(string id)
        {
            var list = await GetAllAsync();

            return await Task.FromResult(list.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Func<T, bool> expression)
        {
            var list = await  GetAllAsync();
            return list.Where(expression);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var list = (await _firebaseClient
            .Child(_tableName)
            .OnceAsync<T>()).Select((arg) => {
                return arg.Object;
            }).ToList();

            return await Task.FromResult(list);
        }
    }
}
