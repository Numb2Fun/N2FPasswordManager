using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Library.Internal.DataAccess
{
    internal class DboNames
    {
        public const string dboNameLocal = "PMData";
        public const string dboNameAzure = "AzurePasswordManagerData";

        public const string spGetAllUsers = "dbo.spUser_GetAll";
        public const string spGetProfilesByUser = "dbo.spProfiles_GetForUser";
        public const string spDeleteProfilesForUser = "dbo.spProfiles_DeleteAllForUser";

        public const string spInsertProfileByUser = "dbo.spProfiles_InsertForUser";
        public const string spUpdateProfile = "dbo.spProfiles_UpdateProfile";
        public const string spDeleteProfile = "dbo.spProfiles_DeleteProfile";
    }
}
