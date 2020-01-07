using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerApi.Library.Internal.DataAccess
{
    internal class SqlDefinitions
    {
        public const string dboName = "PMData";

        public const string spGetAllUsers = "dbo.spUser_GetAll";
    }
}
