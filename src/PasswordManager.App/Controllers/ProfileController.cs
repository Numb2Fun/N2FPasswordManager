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
        private string passwordBeforeEdit;

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
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account");
            }

            List<ProfileModel> profiles = new List<ProfileModel>();
            string userId = User.Identity.GetUserId();
            IEnumerable<ProfileDataModel> data = _profileData.GetProfilesForUser(userId);

            foreach (var m in data)
            {
                profiles.Add(new ProfileModel(m));
            }

            return View(profiles);
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(ProfileModel profile)
        {
            profile.PreviousPassword = profile.Password;
            return View(profile);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProfileModel profile)
        {
            if (ModelState.IsValid == false)
                return View();

            if (profile.HasPasswordChanged)
                profile.LastUpdated = DateTime.Now;

            int catId = (int)profile.Category;

            var data = new ProfileDataModel()
            {
                Id = id,
                CategoryId = catId,
                Title = profile.Title,
                Website = profile.Website,
                LoginName = profile.LoginName,
                Password = profile.Password,
                SignUpEmail = profile.SignUpEmail,
                LastUpdated = profile.LastUpdated
            };

            _profileData.UpdateProfile(data);

            return RedirectToAction("Index");
        }

        // GET: Profile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(ProfileModel profile)
        {
            if (ModelState.IsValid == false)
                return View();

            string userId = User.Identity.GetUserId();
            int catId = (int)profile.Category;

            var data = new ProfileDataModel()
            {
                UserId = userId,
                CategoryId = catId,
                Title = profile.Title,
                Website = profile.Website,
                LoginName = profile.LoginName,
                Password = profile.Password,
                SignUpEmail = profile.SignUpEmail
            };

            _profileData.InsertProfileForUser(data);

            return RedirectToAction("Index");
        }

        // GET: Profile/Delete/5
        public ActionResult Delete(ProfileModel profile)
        {
            return View(profile);
        }

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _profileData.DeleteProfile(id);

            return RedirectToAction("Index");
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
