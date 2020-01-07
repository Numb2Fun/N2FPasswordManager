using PasswordManagerApi.Library.Internal.DataAccess;
using PasswordManagerApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManagerApi.Library.DataAccess
{
    public class UserData
    {

        public IEnumerable<UserDataModel> GetAllUsers()
        {
            var dataAccess = new SqlDataAccess();

            IEnumerable<UserDataModel> users = dataAccess.LoadData<UserDataModel>(SqlDefinitions.spGetAllUsers, SqlDefinitions.dboName);

            return users;
        }
    }
}
