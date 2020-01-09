using PasswordManagerApi.Controllers;
using PasswordManagerApi.Library.DataAccess;
using PasswordManagerApi.Library.Models;
using PasswordManagerApi.Models;
using PasswordManagerApi.Tests.MockObjects.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace PasswordManagerApi.Tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public void GetAllUsers_ViewContainsUsers()
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
            var viewData = (List<UserModel>)view.Model;

            Assert.Equal(3, viewData.Count);
        }
    }
}
