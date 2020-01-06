using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace PasswordManagerApi.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {

        public string GetConnectionString(string connectionName)
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
    }
}
