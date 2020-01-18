using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Library.Internal.DataAccess
{
    internal class DboNames
    {
        public const string dboName = "PMData";

        public const string spGetAllUsers = "dbo.spUser_GetAll";
        public const string spGetProfilesByUser = "dbo.spProfiles_GetForUser";
        public const string spInsertProfileByUser = "dbo.spProfiles_InsertForUser";
        public const string spUpdateProfile = "dbo.spProfiles_UpdateProfile";
        public const string spDeleteProfile = "dbo.spProfiles_DeleteProfile";
    }
}
