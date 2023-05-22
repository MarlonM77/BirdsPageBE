using BirdsBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryInterface
{
    public interface IUser : IRepository<User>
    {
        Task<IEnumerable<User>> GetInvcUser();
        Task<bool> DeleteInvcUser(User User);
        Task<bool> UpdateInvcUser(User User);
        Task<int> InsertInvcUser(IEnumerable<User> User);
        Task<IEnumerable<User>> GetListInvcUser();
        Task<User> GetByIdInvcUser(string id);
        Task<int> InsertInvcUser(string input_xml);
    }
}
