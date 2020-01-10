using PasswordManager.Library.DataAccess;
using PasswordManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Tests.MockObjects.DataAccess
{
    public class MockUserData : IUserData
    {
        public IEnumerable<UserDataModel> GetAllUsersResult { get; set; }

        public IEnumerable<UserDataModel> GetAllUsers()
        {
            return GetAllUsersResult;
        }
    }
}
