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
        Task<IEnumerable<Account>> GetAccount();
        Task<bool> DeleteAccount(Account User);
        Task<bool> UpdateAccount(Account User);
        Task<int> InsertAccount(IEnumerable<Account> User);
        Task<IEnumerable<Account>> GetListAccounts();
        Task<Birds> GetByIdAccount(string id);
        Task<int> InsertAccount(string input_xml);
    }
}
