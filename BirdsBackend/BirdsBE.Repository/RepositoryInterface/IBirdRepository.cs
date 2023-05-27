using BirdsBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryInterface
{
    public interface IBirdRepository : IRepository<Birds>
    {
        Task<Birds> GetBird(string p);
        Task<IEnumerable<Birds>> GetBird();
        Task<bool> DeleteBird(Birds Bird);
        Task<bool> UpdateBird(Birds Bird);
        Task<int> InsertBird(IEnumerable<Birds> Bird);
        Task<int> InsertBird(Birds Bird);
        Task<IEnumerable<Birds>> GetListBird();
        Task<Birds> GetByIdBird(string id);
        Task<int> InsertBird(string input_xml);
    }
}
