using System.Collections.Generic;
using PasswordManager.Library.Models;

namespace PasswordManager.Library.DataAccess
{
    public interface IUserData
    {
        IEnumerable<UserDataModel> GetAllUsers();
    }
}