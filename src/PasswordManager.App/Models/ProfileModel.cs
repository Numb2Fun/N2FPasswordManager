using PasswordManager.Library.Enums;
using PasswordManager.Library.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.App.Models
{
    public class ProfileModel
    {
        public int Id { get; set; }
        public ProfileCategory Category { get; set; }
        [Required]
        public string Title { get; set; }
        public string Website { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string SignUpEmail { get; set; }
        public DateTime LastUpdated { get; set; }

        public string PreviousPassword { get; set; }
        public string AgeOfPassword
        {
            get
            {
                string age = $"{(DateTime.Now - LastUpdated).Days.ToString()} days";
                return age;
            }
        }
        public bool HasPasswordChanged
        {
            get
            {
                bool changed = Password != PreviousPassword;
                return changed;
            }
        }

        public ProfileModel()
        {
            //Model requires parameterless constructor for view binding
        }

        public ProfileModel(ProfileDataModel data)
        {
            Id = data.Id;
            Category = (ProfileCategory)data.CategoryId;
            Title = data.Title;
            Website = data.Website;
            LoginName = data.LoginName;
            Password = data.Password;
            SignUpEmail = data.SignUpEmail;
            LastUpdated = data.LastUpdated;
        }
    }
}