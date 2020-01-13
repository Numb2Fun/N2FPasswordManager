using Microsoft.AspNet.Identity;
using PasswordManager.App.Models;
using PasswordManager.Library.DataAccess;
using PasswordManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PasswordManager.App.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileData _profileData;

        public ProfileController()
        {
            _profileData = new ProfileData();
        }

        public ProfileController(IProfileData profileData)
        {
            _profileData = profileData;
        }

        /// <summary>
        /// Gets list of profiles associated with currently logged user.
        /// </summary>
        /// <returns>Index view with list of ProfileModels</returns>
        public ActionResult Index()
        {
            List<ProfileModel> profiles = new List<ProfileModel>();
            string userId = User.Identity.GetUserId();
            IEnumerable<ProfileDataModel> data = _profileData.GetProfilesForUser(userId);

            foreach (var m in data)
            {
                profiles.Add(new ProfileModel(m));
            }

            return View(profiles);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
