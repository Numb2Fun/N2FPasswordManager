using System.Collections.Generic;
using PasswordManagerApi.Library.Models;

namespace PasswordManagerApi.Library.DataAccess
{
    public interface IUserData
    {
        IEnumerable<UserDataModel> GetAllUsers();
    }
}