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
    public class UserRepository : RepositoryPostgreSQL<Users>, IUserRepository
    {
        private IDbTransaction _transaction;

        private IDbConnection _connection { get { return _transaction.Connection; } }

        public UserRepository(IDbTransaction transaction) : base(transaction)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name}"; };
            _transaction = transaction;
        }
        public async Task<bool> DeleteUser(Users User)
        {
            var R = await _connection?.DeleteAsync(User, _transaction);
            return R;
        }

        public async Task<Users> GetByIdUser(string id)
        {
            var R = await _connection?.GetAsync<Users>(id, _transaction);
            return R;
        }

        public async Task<IEnumerable<Users>> GetListUser()
        {
            var R = await _connection?.GetAllAsync<Users>(_transaction);
            return R;
        }

        public async Task<Users> GetUser()
        {
            //Parametros del procedimiento
            var ProcedimietoAlmacenado = "sp";
            Dictionary<string, dynamic> parameters =
                new PostgreSQLParameters().SetValues(/*Parametros SP*/);

            //Implementacion del procedimiento almacenado
            var result = await GetBySP<Users>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);
            return result;
        }

        public async Task<int> InsertUser(Users user)
        {
            var R = await _connection?.InsertAsync(user, _transaction);
            return R;
        }
            
        public async Task<int> InsertUser(IEnumerable<Users> User)
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

        public async Task<bool> UpdateUser(string user_id)
        {
            var ProcedimietoAlmacenado = "sp_getuser";
            Dictionary<string, dynamic> parameters =
                new Parameters.PostgreSQLParameters().SetValuesActualizar(user_id);

            //Implementacion del procedimiento almacenado
            var user = await GetBySP<Users>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);
            if(user != null)
            {
                ProcedimietoAlmacenado = "sp_deleteuserbyid";
                parameters = new Parameters.PostgreSQLParameters().SetValuesDelete(user_id, user.AccountId);
                var delete = await GetBySP<int>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);

                if (delete >= 0)
                {
                    var result = await InsertUser(user);
                    if (result >= 0)
                        return true;
                }
            }

            return false;
        }
    }
}
