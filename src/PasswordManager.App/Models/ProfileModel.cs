﻿using PasswordManager.Library.Enums;
using PasswordManager.Library.Models;
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