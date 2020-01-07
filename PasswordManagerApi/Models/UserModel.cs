using PasswordManagerApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordManagerApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateCreated { get; set; }

        public UserModel(UserDataModel user)
        {
            Id = user.Id;
            UserName = user.UserName;
            EmailAddress = user.EmailAddress;
            DateCreated = user.DateCreated;
        }
    }
}