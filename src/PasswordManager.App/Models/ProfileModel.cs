using PasswordManager.Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PasswordManager.App.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public ProfileCategory Category { get; set; }
        public string Title { get; set; }
        public string Website { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string SignUpEmail { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}