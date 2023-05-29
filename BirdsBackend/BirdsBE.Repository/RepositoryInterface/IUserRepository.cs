using BirdsBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryInterface
{
    public interface IUserRepository : IRepository<Users>
    {
        //Task <Users> GetUser(string p);
        //Task<IEnumerable<Users>> GetUser();
        Task<bool> DeleteUser(Users User);
        Task<bool> UpdateUser(string UserId);
        Task<int> InsertUser(IEnumerable<Users> User);
        Task<int> InsertUser(Users User);
        Task<IEnumerable<Users>> GetListUser();
        Task<Users> GetByIdUser(string id);
        Task<int> InsertUser(string input_xml);
    }
}
