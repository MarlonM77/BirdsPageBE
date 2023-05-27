using BirdsBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryInterface
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account> GetAccount(string p);
        Task<IEnumerable<Account>> GetAccount();
        Task<bool> DeleteAccount(Account account);
        Task<bool> UpdateAccount(Account account);
        Task<int> InsertAccount(IEnumerable<Account> account);
        Task<int> InsertAccount(Account account);
        Task<IEnumerable<Account>> GetListAccount();
        Task<Account> GetByIdAccount(string id);
        Task<int> InsertAccount(string input_xml);
    }
}
