using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using IT1.Models;
using IT1.ViewModels;

namespace IT1.Controllers.Web
{
    public class AuthController : Controller
    {
        private SignInManager<IT1User> _signInManager;

        public AuthController(SignInManager<IT1User> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                string referer = HttpContext.Request.Query["ReturnUrl"]; //getting null
                var test = referer.Split('/');

                return RedirectToAction(test[2], test[1]);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(IT1UserViewModel vm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);

                if (signInResult.Succeeded)
                {
                    //string referer = HttpContext.Request.Query["ReturnUrl"]; //getting null
                    //var test = referer.Split('/');

                    //return RedirectToAction(test[2], test[1]);
                    if (String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "App");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Sign in attempt failed");
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "App");
        }
    }
}