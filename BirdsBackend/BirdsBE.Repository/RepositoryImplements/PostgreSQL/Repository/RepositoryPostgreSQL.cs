using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryImplements.PostgreSQL.Repository
{
    public class RepositoryPostgreSQL<T> : IRepository<T> where T : class
    {

        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public RepositoryPostgreSQL(IDbTransaction transaction)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{type.Name}"; };
            _transaction = transaction;
        }

        public async Task<bool> Delete(T entity)
        {
            return await _connection?.DeleteAsync<T>(entity, _transaction);
        }

        public async Task<T> GetById(string id)
        {
            return await _connection?.GetAsync<T>(int.Parse(id), _transaction);
        }

        public async Task<IEnumerable<TResult>> GetBySP<TResult>(string sqlQuery, CommandType commandType = CommandType.StoredProcedure, IDictionary<string, dynamic> parameters = null)
        {
            DynamicParameters _parameters = new DynamicParameters();
            if (parameters is not null)
                foreach (var item in parameters)
                    _parameters.Add(item.Key, item.Value);

            var result = await _connection?.QueryAsync<TResult>(sqlQuery, _parameters, _transaction, commandType: commandType);
            return result;
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await _connection?.GetAllAsync<T>(_transaction);
        }

        public async Task<TResult> GetOnlyBySP<TResult>(string sqlQuery, CommandType commandType = CommandType.StoredProcedure, IDictionary<string, dynamic> parameters = null)
        {
            DynamicParameters _parameters = new DynamicParameters();
            if (parameters is not null)
                foreach (var item in parameters)
                    _parameters.Add(item.Key, item.Value);

            var result = await _connection?.QueryFirstOrDefaultAsync<TResult>(sqlQuery, _parameters, _transaction, commandType: commandType);
            return result;
        }


        public async Task<TResult> InsertEntity<TResult>(string sqlQuery,
            CommandType commandType = CommandType.StoredProcedure,
            IDictionary<string, dynamic> parameters = null)
        {
            object result = null;
            DynamicParameters _parameters = new DynamicParameters();
            if (parameters is not null)
                foreach (var item in parameters)
                    _parameters.Add(item.Key, item.Value);

            result = await _connection?.ExecuteScalarAsync(sqlQuery, _parameters, _transaction, commandType: commandType);
            return (TResult)result;
        }

        public async Task<int> Insert(T entity)
        {
            return await _connection?.InsertAsync(entity, _transaction);
        }

        public async Task<bool> Update(T entity)
        {
            return await _connection?.UpdateAsync(entity, _transaction);
        }
    }
}
