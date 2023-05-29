using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsBE.Repository.RepositoryImplements.PostgreSQL.Parameters
{
    public class PostgreSQLParameters
    {
        public Dictionary<string, dynamic> SetValues()
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            return parameters;
        }

        public Dictionary<string, dynamic> SetValuesActualizar(string user_id)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add("userid", user_id);
            return parameters;
        }

        public Dictionary<string, dynamic> SetValuesDelete(string user_id, string account_id)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add("userid", user_id);
            parameters.Add("accountid", account_id);
            return parameters;
        }

        public Dictionary<string, dynamic> SetValueCrudSP(string input_xml)
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            parameters.Add("_input_xml", input_xml);
            return parameters;
        }

    }
}
