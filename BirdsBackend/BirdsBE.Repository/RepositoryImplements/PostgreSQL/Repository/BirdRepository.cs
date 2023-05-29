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
    public class BirdRepository : RepositoryPostgreSQL<Birds>, IBirdRepository
    {

        private IDbTransaction _transaction;
        private IDbConnection _connection { get { return _transaction.Connection; } }

        public BirdRepository(IDbTransaction transaction) : base(transaction)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name}"; };
            _transaction = transaction;
        }

        public async Task<Birds> GetBird(string p)
        {
            //Parametros del procedimiento
            var ProcedimietoAlmacenado = "sp";
            Dictionary<string, dynamic> parameters =
                new PostgreSQLParameters().SetValues();

            //Implementacion del procedimiento almacenado
            var result = await GetOnlyBySP<Birds>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);
            return result;
        }


        public async Task<bool> DeleteBird(Birds Bird)
        {
            var R = await _connection?.DeleteAsync(Bird, _transaction);
            return R;
        }

        public async Task<bool> UpdateBird(Birds Bird)
        {
            var R = await _connection?.UpdateAsync(Bird, _transaction);
            return R;
        }

        public async Task<int> InsertBird(IEnumerable<Birds> Bird)
        {
            var R = 0;
            foreach (var item in Bird)
            {
                R += await _connection?.InsertAsync(Bird, _transaction);
            }
            return R;
        }

        public async Task<int> InsertBird(Birds Bird)
        {
            var R = await _connection?.InsertAsync(Bird, _transaction);
            return R;
        }

        public async Task<IEnumerable<Birds>> GetListBird()
        {
            var R = await _connection?.GetAllAsync<Birds>(_transaction);
            return R;
        }

        public async Task<Birds> GetByIdBird(string id)
        {
            return await _connection?.GetAsync<Birds>(int.Parse(id), _transaction);
        }

        public async Task<int> InsertBird(string input_xml)
        {
            var ProcedimietoAlmacenado = "sp";
            Dictionary<string, dynamic> parameters =
                new Parameters.PostgreSQLParameters().SetValueCrudSP(input_xml);

            //Implementacion del procedimiento almacenado
            return await InsertEntity<int>(ProcedimietoAlmacenado, CommandType.StoredProcedure, parameters);
        }
    }
}
