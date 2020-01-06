using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;

namespace PasswordManagerApi.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {

        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public IEnumerable<T> LoadData<T>(string storedProcedure, string connectionName, object parameters = null)
        {
            string connString = GetConnectionString(connectionName);

            using (IDbConnection connection = new SqlConnection(connString))
            {
                IEnumerable<T> data = connection.Query<T>(storedProcedure, commandType: CommandType.StoredProcedure, param: parameters);

                return data;
            }
        }

        public void SaveData(string storedProcedure, string connectionName, object parameters)
        {
            string connString = GetConnectionString(connectionName);

            using (IDbConnection connection = new SqlConnection(connString))
            {
                connection.Execute(storedProcedure, commandType: CommandType.StoredProcedure, param: parameters);
            }
        }
    }
}
