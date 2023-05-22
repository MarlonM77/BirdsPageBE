using BirdsBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryInterface
{
    public interface IBirdRepository :IRepository<Birds>
    {
        Task<IEnumerable<Birds>> GetBird();
        Task<bool> DeleteBird(Birds User);
        Task<bool> UpdateBird(Birds User);
        Task<int> InsertBird(IEnumerable<Birds> User);
        Task<IEnumerable<Birds>> GetListBirds();
        Task<Birds> GetByIdBird(string id);
        Task<int> InsertBird(string input_xml);
    }
}
