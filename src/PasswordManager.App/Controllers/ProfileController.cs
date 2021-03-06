﻿using Microsoft.AspNet.Identity;
using PasswordManager.App.Models;
using PasswordManager.Library.DataAccess;
using PasswordManager.Library.Enums;
using PasswordManager.Library.Models;
using System;
using System.Collections.Generic;
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
            if (User.Identity.IsAuthenticated == false)
            {
                return RedirectToAction("Login", "Account");
            }

            Dictionary<string, List<ProfileViewModel>> profilesByCat = new Dictionary<string, List<ProfileViewModel>>();
            List<SelectListItem> categoryItems = new List<SelectListItem>();

            // Retrieve all profiles for logged user
            string userId = User.Identity.GetUserId();
            IEnumerable<ProfileDataModel> data = _profileData.GetProfilesForUser(userId);

            // Set up categories from enum and assign in ViewBag for use in view dropdowns
            foreach (var name in Enum.GetNames(typeof(ProfileCategory)))
            {
                profilesByCat.Add(name, new List<ProfileViewModel>());

                categoryItems.Add(new SelectListItem()
                {
                    Text = name,
                    Value = ((int)(ProfileCategory)Enum.Parse(typeof(ProfileCategory), name)).ToString()
                });
            }

            ViewBag.categoryItems = categoryItems;

            // Create view models and add them to lists by category
            foreach (var m in data)
            {
                var profile = new ProfileViewModel(m);
                string category = Enum.GetName(typeof(ProfileCategory), profile.Category);

                if (profilesByCat.ContainsKey(category) == false)
                {
                    profile.Category = ProfileCategory.None;
                    category = Enum.GetName(typeof(ProfileCategory), profile.Category);
                }

                profilesByCat[category].Add(profile);
            }

            return View(profilesByCat);
        }

        // POST: Profile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProfileViewModel profile)
        {
            if (ModelState.IsValid == false)
                return View();

            if (profile.HasPasswordChanged)
                profile.LastUpdated = DateTime.Now;

            string userId = User.Identity.GetUserId();
            int catId = (int)profile.Category;

            var data = new ProfileDataModel()
            {
                Id = id,
                UserId = userId,
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

        // POST: Profile/Create
        [HttpPost]
        public ActionResult Create(ProfileViewModel profile)
        {
            if (ModelState.IsValid == false)
                return PartialView();

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

        // POST: Profile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _profileData.DeleteProfile(id);

            return RedirectToAction("Index");
        }
    }
}
