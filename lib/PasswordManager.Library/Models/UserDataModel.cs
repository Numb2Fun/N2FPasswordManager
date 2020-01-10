using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Library.Models
{
    public class UserDataModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
