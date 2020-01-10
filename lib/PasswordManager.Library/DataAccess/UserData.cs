using PasswordManager.Library.Internal.DataAccess;
using PasswordManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Library.DataAccess
{
    public class UserData : IUserData
    {

        public IEnumerable<UserDataModel> GetAllUsers()
        {
            var dataAccess = new SqlDataAccess();

            IEnumerable<UserDataModel> users = dataAccess.LoadData<UserDataModel>(SqlDefinitions.spGetAllUsers, SqlDefinitions.dboName);

            return users;
        }
    }
}
