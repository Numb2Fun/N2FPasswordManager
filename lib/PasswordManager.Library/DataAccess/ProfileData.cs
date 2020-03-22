using PasswordManager.Library.Internal.DataAccess;
using PasswordManager.Library.Internal.Encryption;
using PasswordManager.Library.Models;
using System;
using System.Collections.Generic;

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
            object sqlParams = new { @userId = userId };

            IEnumerable<ProfileDataModel> data = _dataAccess.LoadData<ProfileDataModel>(DboNames.spGetProfilesByUser, DboNames.dboNameAzure, sqlParams);

            // Decrypt and reassign profile passwords
            foreach(var profile in data)
            {
                profile.Password = ProfileEncrypter.DecryptPassword(profile.Password, profile.UserId);
            }

            return data;
        }

        public void InsertProfileForUser(ProfileDataModel data)
        {
            data.Password = ProfileEncrypter.EncryptPassword(data.Password, data.UserId);

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
            data.Password = ProfileEncrypter.EncryptPassword(data.Password, data.UserId);

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

        public void DeleteProfilesForUser(string userId)
        {
            _dataAccess.SaveData(DboNames.spDeleteProfilesForUser, DboNames.dboNameAzure, new { @userId = userId });
        }
    }
}
