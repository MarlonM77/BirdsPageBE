using BirdsBE.Models;
using BirdsBE.Repository.RepositoryInterface;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryImplements.PostgreSQL.Repository
{
    public class AccountRepository : RepositoryPostgreSQL<Birds>, IAccountRepository
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public AccountRepository(IDbTransaction transaction) : base(transaction)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name}"; };
            _transaction = transaction;
        }

        public Task<Account> GetAccount(string p)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetAccount()
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAccount(IEnumerable<Account> account)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> GetListAccount()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByIdAccount(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAccount(string input_xml)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Account entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(Account entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Account>> IRepository<Account>.GetList()
        {
            throw new NotImplementedException();
        }

        Task<Account> IRepository<Account>.GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
