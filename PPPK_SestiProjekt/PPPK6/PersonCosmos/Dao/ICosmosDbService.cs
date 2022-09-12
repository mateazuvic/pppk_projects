using PersonCosmos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonCosmos.Dao
{
    public interface ICosmosDbService<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string queryString);
        Task<T> GetOneAsync(string id); 
        Task AddAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(T obj);
    }
}
