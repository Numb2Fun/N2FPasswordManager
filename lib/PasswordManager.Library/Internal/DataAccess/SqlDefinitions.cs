using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Library.Internal.DataAccess
{
    internal class SqlDefinitions
    {
        public const string dboName = "PMData";

        public const string spGetAllUsers = "dbo.spUser_GetAll";
        public const string spGetProfilesByUser = "dbo.spProfiles_GetForUser";
    }
}
