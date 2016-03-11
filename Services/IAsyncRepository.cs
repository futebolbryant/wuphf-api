using System.Collections.Generic;
using System.Threading.Tasks;
namespace Services
{
    public interface IAsyncRepository<T> where T: class, new()
    {
        Task<List<T>> FindAll();
        Task Save(T obj);
        Task Delete(string id);        
    }
}