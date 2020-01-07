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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUsers()
        {   
            var userData = new UserData();
            var data = userData.GetAllUsers();
            var users = new List<UserModel>();

            foreach (var user in data)
            {
                users.Add(new UserModel(user));
            }

            return View(users);
        }
    }
}
