﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Owin.Demo.Models;

namespace Owin.Demo.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            var model = new LoginModel();

            var providers = HttpContext.GetOwinContext()
                .Authentication.GetAuthenticationTypes(p => !string.IsNullOrEmpty(p.Caption))
                .ToList();

            model.GetAuthenticationTypes = providers;

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (model.Username.Equals("Sirwan", StringComparison.OrdinalIgnoreCase)
                && model.Password == "password")
            {
                var identity = new ClaimsIdentity("ApplicationCookie");
                identity.AddClaims(new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, model.Username),
                    new Claim(ClaimTypes.Name, model.Username)
                });

                HttpContext.GetOwinContext().Authentication.SignIn(identity);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            // در اینجا به کوکی میدل ویر گفته‌ایم که کاربر باید لاگ‌اوت شود
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/");
        }

        public ActionResult SocialLogin(string id)
        {
            HttpContext.GetOwinContext()
                .Authentication
                .Challenge(new AuthenticationProperties
                            {
                                RedirectUri = "/secret"
                            }, id);
            return new HttpUnauthorizedResult();
        }
    }
}