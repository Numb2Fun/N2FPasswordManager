using PasswordManager.App.Controllers;
using PasswordManager.App.Models;
using PasswordManager.Library.DataAccess;
using PasswordManager.Library.Models;
using PasswordManager.Tests.MockObjects.DataAccess;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Xunit;

namespace PasswordManager.Tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public void GetAllUsers_ViewContainsUserCount()
        {
            var user1 = new UserDataModel() { UserName = "user1", EmailAddress = "user1@mail.com", DateCreated = DateTime.Today };
            var user2 = new UserDataModel() { UserName = "user2", EmailAddress = "user2@mail.com", DateCreated = DateTime.Today };
            var user3 = new UserDataModel() { UserName = "user3", EmailAddress = "user3@mail.com", DateCreated = DateTime.Today };

            var users = new List<UserDataModel>();
            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            var userData = new MockUserData();
            userData.GetAllUsersResult = users;

            var controller = new UserController(userData);
            var view = controller.GetAllUsers() as ViewResult;
            var viewData = view.Model as List<UserModel>;

            Assert.Equal(3, viewData.Count);
        }
    }
}
