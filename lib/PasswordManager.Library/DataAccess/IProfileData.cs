using System.Collections.Generic;
using PasswordManager.Library.Models;

namespace PasswordManager.Library.DataAccess
{
    public interface IProfileData
    {
        IEnumerable<ProfileDataModel> GetProfilesForUser(string userId);
        void InsertProfileForUser(ProfileDataModel data);
    }
}