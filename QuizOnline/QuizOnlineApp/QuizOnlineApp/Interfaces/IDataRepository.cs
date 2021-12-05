using QuizOnlineApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuizOnlineApp.Interfaces
{
    public interface IDataRepository<T> where T : IPKModel
    {
        Task<bool> AddAsync(T item);
        Task<bool> UpdateAsync(T item);
        Task<bool> DeleteAsync(string id);
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
