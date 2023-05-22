using BirdsBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryInterface
{
    public interface IUserRepository : IRepository<User>
    {
        Task <User> GetUser(string p);
        Task<IEnumerable<User>> GetUser();
        Task<bool> DeleteUser(User User);
        Task<bool> UpdateUser(User User);
        Task<int> InsertUser(IEnumerable<User> User);
        Task<int> InsertUser(User User);
        Task<IEnumerable<User>> GetListUser();
        Task<User> GetByIdUser(string id);
        Task<int> InsertUser(string input_xml);
    }
}
