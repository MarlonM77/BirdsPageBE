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

        public Dictionary<string, dynamic> SetValuesActualizar()
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
            return parameters;
        }

        public Dictionary<string, dynamic> SetValuesDelete()
        {
            Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
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
