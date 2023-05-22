using BirdsBE.Models;
using BirdsBE.Repository.RepositoryImplements.PostgreSQL.Parameters;
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
    public class UserRepository : RepositoryPostgreSQL<User>, IUserRepository
    {
        private IDbTransaction _transaction;

        private IDbConnection _connection { get { return _transaction.Connection; } }

        public UserRepository(IDbTransaction transaction) : base(transaction)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name}"; };
            _transaction = transaction;
        }
        public async Task<bool> DeleteUser(User User)
        {
            var R = await _connection?.DeleteAsync(User, _transaction);
            return R;
        }

        public async Task<User> GetByIdUser(string id)
        {
            var R = await _connection?.GetAsync<User>(id, _transaction);
            return R;
        }

        public async Task<IEnumerable<User>> GetListUser()
        {
            var R = await _connection?.GetAllAsync<User>(_transaction);
            return R;
        }

        public async Task<User> GetUser(string p)
        {
            //Parametros del procedimiento
            var ProcedimietoAlmacenado = "sp";
            Dictionary<string, dynamic> parameters =
                new PostgreSQLParameters().SetValues();

            //Implementacion del procedimiento almacenado
            var result = await GetOnlyBySP<User>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);
            return result;
        }

        public async Task<IEnumerable<User>> GetUser()
        {
            //Parametros del procedimiento
            var ProcedimietoAlmacenado = "sp";
            Dictionary<string, dynamic> parameters =
                new PostgreSQLParameters().SetValues(/*Parametros SP*/);

            //Implementacion del procedimiento almacenado
            var result = await GetBySP<User>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);
            return result;
        }

        public async Task<int> InsertUser(User User)
        {
            var R = await _connection?.InsertAsync(User, _transaction);
            return R;
        }

        public async Task<int> InsertUser(IEnumerable<User> User)
        {
            var R = 0;
            foreach (var item in User)
            {
                R += await _connection?.InsertAsync(User, _transaction);
            }
            return R;
        }

        public async Task<int> InsertUser(string input_xml)
        {
            var ProcedimietoAlmacenado = "sp";
            Dictionary<string, dynamic> parameters =
                new Parameters.PostgreSQLParameters().SetValueCrudSP(input_xml);

            //Implementacion del procedimiento almacenado
            return await InsertEntity<int>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);
        }

        public async Task<bool> UpdateUser(User User)
        {
            var R = await _connection?.UpdateAsync(User, _transaction);
            return R;
        }
    }
}
