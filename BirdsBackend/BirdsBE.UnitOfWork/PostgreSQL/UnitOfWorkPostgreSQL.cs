using BirdsBE.Repository.RepositoryImplements.PostgreSQL.Repository;
using BirdsBE.Repository.RepositoryInterface;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.UnitOfWork.PostgreSQL
{
    public class UnitOfWorkPostgreSQL : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public UnitOfWorkPostgreSQL(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            User = new UserRepository(_transaction);
            //Account = new AccountRepository(_transaction);
            //Bird = new BirdRepository(_transaction);
        }
        public IUserRepository User { get; }

        public IAccountRepository Account { get; }

        public IBirdRepository Bird { get; }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
