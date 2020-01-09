using PasswordManagerApi.Library.DataAccess;
using PasswordManagerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordManagerApi.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserData _userData;

        public UserController()
        {
            _userData = new UserData();
        }

        public UserController(IUserData userData)
        {
            _userData = userData;
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {   
            var data = _userData.GetAllUsers();
            var users = new List<UserModel>();

            foreach (var user in data)
            {
                users.Add(new UserModel(user));
            }

            return View(users);
        }
    }
}
