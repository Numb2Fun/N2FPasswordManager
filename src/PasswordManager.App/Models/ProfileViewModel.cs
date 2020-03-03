using PasswordManager.Library.Enums;
using PasswordManager.Library.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PasswordManager.App.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public ProfileCategory Category { get; set; }

        [Required]
        public string Title { get; set; }
        public string Website { get; set; }

        [Display(Name = "Login Name")]
        public string LoginName { get; set; }
        public string Password { get; set; }

        [Display(Name = "Sign Up Email")]
        public string SignUpEmail { get; set; }
        public DateTime LastUpdated { get; set; }
        public string PreviousPassword { get; set; }

        [Display(Name = "Age of Password")]
        public string AgeOfPassword
        {
            get
            {
                int days = (DateTime.Now - LastUpdated).Days;
                string age;
                if (days < 31)
                {
                    age = $"{days.ToString()} day(s)";
                }
                else
                {
                    age = $"{(days / 30f).ToString("0.0")} month(s)";
                }

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

        public ProfileViewModel()
        {
            //Model requires parameterless constructor for view binding
        }

        public ProfileViewModel(ProfileDataModel data)
        {
            Id = data.Id;
            Category = (ProfileCategory)data.CategoryId;
            Title = data.Title;
            Website = data.Website;
            LoginName = data.LoginName;
            Password = data.Password;
            PreviousPassword = data.Password;
            SignUpEmail = data.SignUpEmail;
            LastUpdated = data.LastUpdated;
        }
    }
}