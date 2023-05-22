using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Delete(T entity);
        Task<bool> Update(T entity);
        Task<int> Insert(T entity);
        Task<IEnumerable<T>> GetList();
        Task<T> GetById(string id);
        Task<IEnumerable<TResult>> GetBySP<TResult>(string sqlQuery, System.Data.CommandType commandType = System.Data.CommandType.StoredProcedure, IDictionary<string, dynamic> parameters = null);
    }
}
