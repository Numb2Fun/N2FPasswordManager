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
        private readonly SqlDataAccess _dataAccess;

        public ProfileData()
        {
            _dataAccess = new SqlDataAccess();
        }

        public IEnumerable<ProfileDataModel> GetProfilesForUser(string userId)
        {
            IEnumerable<ProfileDataModel> data;
            object sqlParams = new { @userId = userId };

            data = _dataAccess.LoadData<ProfileDataModel>(DboNames.spGetProfilesByUser, DboNames.dboNameAzure, sqlParams);

            return data;
        }

        public void InsertProfileForUser(ProfileDataModel data)
        {
            object sqlParams = new
            {
                @userId = data.UserId,
                @categoryId = data.CategoryId,
                @title = data.Title,
                @website = data.Website,
                @loginName = data.LoginName,
                @password = data.Password,
                @signUpEmail = data.SignUpEmail
            };

            _dataAccess.SaveData(DboNames.spInsertProfileByUser, DboNames.dboNameAzure, sqlParams);
        }

        public void UpdateProfile(ProfileDataModel data)
        {
            object sqlParams = new
            {
                @id = data.Id,
                @categoryId = data.CategoryId,
                @title = data.Title,
                @website = data.Website,
                @loginName = data.LoginName,
                @password = data.Password,
                @signUpEmail = data.SignUpEmail,
                @lastUpdated = data.LastUpdated
            };

            _dataAccess.SaveData(DboNames.spUpdateProfile, DboNames.dboNameAzure, sqlParams);
        }

        public void DeleteProfile(int id)
        {
            _dataAccess.SaveData(DboNames.spDeleteProfile, DboNames.dboNameAzure, new { @id = id });
        }
    }
}
