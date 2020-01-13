using PasswordManager.Library.Internal.DataAccess;
using PasswordManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Library.DataAccess
{
    public class ProfileData : IProfileData
    {


        public IEnumerable<ProfileDataModel> GetProfilesForUser(string userId)
        {
            IEnumerable<ProfileDataModel> data;
            var access = new SqlDataAccess();

            data = access.LoadData<ProfileDataModel>(SqlDefinitions.spGetProfilesByUser, 
                                                        SqlDefinitions.dboName, 
                                                        new { userId = userId });

            return data;
        }
    }
}
